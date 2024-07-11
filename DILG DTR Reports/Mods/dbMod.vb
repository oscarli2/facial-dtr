Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports Mysqlx
Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Diagnostics.Eventing
Imports MySql.Data.Types

Module dbMod

    'Database Variables
    ' Public conn As MySqlConnection
    Public conn As New SqlConnection
    Public str As String
    'Public cmd As MySqlCommand
    Public cmd As SqlCommand
    'Public dr As MySqlDataReader
    Public dr As SqlDataReader
    Public server As String = "26.113.153.103" '"localhost" 
    Dim port As String = "3307"
    Public user As String = "sa"
    Public pass As String = "CDPabina"
    Public db As String = "anviz"
    Dim dbSQLServer As String = "anviz"

    'DTR days 30 or 31 days
    Public dayCount As String = ""

    'Employee TimeIn Database Variables
    Public conn2 As MySqlConnection
    Public str2 As String
    Public cmd2 As MySqlCommand
    Public dr2 As MySqlDataReader
    Dim server2 As String = "172.20.72.124"
    Dim port2 As String = "3307"
    Dim user2 As String = "root"
    Dim pass2 As String = "CDPabina"
    Dim db2 As String = "zkteco"

    'Employee TimeIn Database Variables
    Public conn3 As MySqlConnection
    Public str3 As String
    Public cmd3 As MySqlCommand
    Public dr3 As MySqlDataReader
    Dim server3 As String = "172.20.72.124"
    Dim port3 As String = "3307"
    Dim user3 As String = "root"
    Dim pass3 As String = "CDPabina"
    Dim db3 As String = "zkteco"

    'For printing
    Public isActive As Boolean

    'Dim server As String = "localhost"
    'Dim port As String = "3306"
    'Dim user As String = "root"
    'Dim pass As String = "CDPabina"
    'Dim db As String = "zkteco"
    Public Sub connection()
        Try

            str = "Server=" & server & ";Port=" & port & ";Uid=" & user & ";Pwd=" & pass & ";Database=" & db & ";persist security info=false; SslMode=none;"

            'conn = New MySqlConnection(str)
            conn = New SqlConnection(str)
            'test connection
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            Else
                conn.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub

    Public Sub ConnDB()

        conn.Close()

        Try
            conn.ConnectionString = "Server = '" & server & "';  " _
                                         & "Database = '" & db & "'; " _
                                         & "user id = '" & user & "'; " _
                                         & "password = '" & pass & "'"

            conn.Open()

        Catch ex As Exception
            MsgBox("The system failed to establish a connection", MsgBoxStyle.Information, "Database Settings")
        End Try

    End Sub

    Public Sub CloseDB()
        Try
            conn.Close()
            conn.Dispose()
        Catch myerror As MySqlException
        End Try
    End Sub
    Public Sub connection2()
        Try

            str2 = "Server=" & server2 & ";Port=" & port2 & ";Uid=" & user2 & ";Pwd=" & pass2 & ";Database=" & db2 & ";persist security info=false; SslMode=none;"

            conn2 = New MySqlConnection(str2)
            'test connection
            If conn2.State = ConnectionState.Closed Then
                conn2.Open()
            Else
                conn2.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Public Sub CloseDB2()
        Try
            conn2.Close()
            conn2.Dispose()
        Catch myerror As MySqlException
        End Try
    End Sub
    Public Sub connection3()
        Try

            str3 = "Server=" & server3 & ";Port=" & port3 & ";Uid=" & user3 & ";Pwd=" & pass3 & ";Database=" & db3 & ";persist security info=false; SslMode=none;"

            conn3 = New MySqlConnection(str3)
            'test connection
            If conn3.State = ConnectionState.Closed Then
                conn3.Open()
            Else
                conn3.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
    End Sub
    Public Sub CloseDB3()
        Try
            conn3.Close()
            conn3.Dispose()
        Catch myerror As MySqlException
        End Try
    End Sub
    Public Sub searchEmployee(ByVal txtEmployee As String)
        ConnDB()
        Dim query As String = "SELECT Userid, UserCode, Name FROM Userinfo WHERE Name LIKE '%" & txtEmployee & "%'"
        'cmd = New MySqlCommand(query, conn)
        cmd = New SqlCommand(query, conn)
        dr = cmd.ExecuteReader

        SearchEmp.lv_employees.Clear() 'clear the table
        SearchEmp.lv_employees.Columns.Add("ID", 80)
        SearchEmp.lv_employees.Columns.Add("UserCode", 100)
        SearchEmp.lv_employees.Columns.Add("Name", 500)

        If dr.HasRows Then
            While dr.Read
                Dim items As New ListViewItem
                items.Text = dr("Userid").ToString
                items.SubItems.Add(dr("UserCode").ToString)
                items.SubItems.Add(dr("Name").ToString)
                SearchEmp.lv_employees.View = View.Details
                SearchEmp.lv_employees.Items.Add(items)
                SearchEmp.recordCount.Text = SearchEmp.lv_employees.Items.Count
            End While
            For i As Integer = 0 To SearchEmp.lv_employees.Items.Count - 1
                If i Mod 2 Then
                    SearchEmp.lv_employees.Items(i).BackColor = Color.LightBlue
                Else
                    SearchEmp.lv_employees.Items(i).BackColor = Color.White
                End If
            Next
            Exit Sub
        End If
        CloseDB()
    End Sub
    Function IsLeapYear(year As Integer) As Boolean
        If year Mod 4 = 0 Then
            If year Mod 100 = 0 Then
                If year Mod 400 = 0 Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function
    Public Sub DG_Search(emp_id As Integer, a As Boolean, b As Boolean, c As Boolean, month As String, year As String, ifSG As Boolean)
        ConnDB()

        cmd.CommandType = CommandType.StoredProcedure
        Dim query As String
        Dim dateMonth As String = year & "-" & month
        Dim dateFrom, dateToo As Date
        Dim days As Integer = 0

        If a = True And b = False And c = False Then
            dateFrom = dateMonth & "-01"
            dateToo = dateMonth & "-15"
            days = 1
        ElseIf b = True And a = False And c = False Then
            dateFrom = Convert.ToDateTime(dateMonth & "-16")
            dateMonth = dateMonth & "-" & dayCount
            dateToo = DateTime.Parse(dateMonth)
            days = 16
        ElseIf b = False And a = False And c = True Then
            dateFrom = dateMonth & "-01"
            If month = 2 Then
                If IsLeapYear(year) Then
                    dateMonth = dateMonth & "-29"
                Else
                    dateMonth = dateMonth & "-28"
                End If
            Else
                dateMonth = dateMonth & "-" & dayCount
            End If
            dateToo = DateTime.Parse(dateMonth)
            days = 1
        End If
        If ifSG = False Then
            query = "
            SET NOCOUNT ON;

            -- Disable foreign key checks
            EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL';

            -- Your original CTE and main query
            WITH date_ranges AS (
                SELECT CAST(@dateFrom AS DATE) AS dt
                UNION ALL
                SELECT DATEADD(DAY, 1, dt) 
                FROM date_ranges 
                WHERE DATEADD(DAY, 1, dt) <= CAST(@dateToo AS DATE)
            )
            SELECT 
                DAY(date_ranges.dt) as 'Days',
                MAX(CASE WHEN T.Checktype = 0 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '03:00:00' AND '11:59:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS ArrivalAM,
                MIN(CASE WHEN T.Checktype = 1 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '12:00:00' AND '14:00:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS DepartAM,
                MAX(CASE WHEN T.Checktype = 0 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '12:00:00' AND '14:00:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS ArrivalPM,
                MAX(CASE WHEN T.Checktype = 1 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '14:00:01' AND '23:59:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS DepartPM,
                DATEPART(WEEKDAY, date_ranges.dt) AS Weekend
            FROM 
                date_ranges
            LEFT JOIN 
                Checkinout T ON date_ranges.dt = CAST(T.Checktime AS DATE)
            GROUP BY 
                date_ranges.dt;

            -- Enable foreign key checks
            EXEC sp_msforeachtable 'ALTER TABLE ? CHECK CONSTRAINT ALL';
            "
        Else
            query = "   
                SET NOCOUNT ON;

                -- Disable foreign key checks
                EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL';

                -- Your original CTE and main query
                WITH date_ranges AS (
                    SELECT CAST(@dateFrom AS DATE) AS dt
                    UNION ALL
                    SELECT DATEADD(DAY, 1, dt) 
                    FROM date_ranges 
                    WHERE DATEADD(DAY, 1, dt) <= CAST(@dateToo AS DATE)
                )
                SELECT 
                    DAY(date_ranges.dt) as 'Days',
                    MAX(CASE WHEN T.Checktype = 1 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '03:00:00' AND '11:59:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS ArrivalAM,
                    MIN(CASE WHEN T.Checktype = 0 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '12:00:00' AND '14:00:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS DepartAM,
                    MAX(CASE WHEN T.Checktype = 1 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '12:00:00' AND '14:00:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS ArrivalPM,
                    MAX(CASE WHEN T.Checktype = 0 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '15:00:01' AND '23:59:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS DepartPM,
                    DATEPART(WEEKDAY, date_ranges.dt) AS Weekend
                FROM 
                    date_ranges
                LEFT JOIN 
                    Checkinout T ON date_ranges.dt = CAST(T.Checktime AS DATE)
                GROUP BY 
                    date_ranges.dt;

                -- Enable foreign key checks
                EXEC sp_msforeachtable 'ALTER TABLE ? CHECK CONSTRAINT ALL';
                "
        End If
        cmd = New SqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@dateFrom", dateFrom)
        cmd.Parameters.AddWithValue("@dateToo", dateToo)
        cmd.Parameters.AddWithValue("@emp_id", emp_id)
        dr = cmd.ExecuteReader()


        DTRMain.ListView1.Clear()
        DTRMain.ListView1.Columns.Add("Day", 50, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Arrive", 80, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Depart", 80, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Arrive", 80, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Depart", 80, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Hours", 40, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Minutes", 40, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))

        Try
            If days = 1 And c = False Then
                While days <= 31
                    If days = 1 Then
                        If dr.HasRows Then
                            While dr.Read()
                                Dim weekEnd As String = dr(5).ToString
                                Dim items As New ListViewItem
                                If weekEnd = "7" Or weekEnd = "" Then
                                    items.Text = days.ToString
                                    items.SubItems.Add("")
                                    items.SubItems.Add("Saturday").ForeColor = Color.Red
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                ElseIf weekEnd = "1" Or weekEnd = "" Then
                                    items.Text = days.ToString
                                    items.SubItems.Add("")
                                    items.SubItems.Add("Sunday").ForeColor = Color.Red
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                Else
                                    items.Text = days.ToString
                                    items.SubItems.Add(dr(1).ToString)
                                    items.SubItems.Add(dr(2).ToString)
                                    items.SubItems.Add(dr(3).ToString)
                                    items.SubItems.Add(dr(4).ToString)
                                    items.SubItems.Add("")
                                End If
                                DTRMain.ListView1.View = View.Details
                                DTRMain.ListView1.Items.Add(items)
                                days += 1
                            End While
                        Else
                            Exit Sub
                        End If
                    Else
                        Dim items As New ListViewItem
                        items.Text = days.ToString
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        DTRMain.ListView1.View = View.Details
                        DTRMain.ListView1.Items.Add(items)
                        days += 1
                    End If
                End While
            ElseIf days = 16 And c = False Then
                Dim count As Integer = 1
                While count <= 15
                    Dim items As New ListViewItem
                    items.Text = count.ToString
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    DTRMain.ListView1.View = View.Details
                    DTRMain.ListView1.Items.Add(items)
                    count += 1
                End While
                If days = 16 Then
                    If dr.HasRows Then
                        While dr.Read()
                            Dim weekEnd As String = dr(5).ToString
                            Dim items As New ListViewItem
                            If weekEnd = "7" Or weekEnd = "" Then
                                items.Text = days.ToString
                                items.SubItems.Add("")
                                items.SubItems.Add("Saturday").ForeColor = Color.Red
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                            ElseIf weekEnd = "1" Or weekEnd = "" Then
                                items.Text = days.ToString
                                items.SubItems.Add("")
                                items.SubItems.Add("Sunday").ForeColor = Color.Red
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                            Else
                                items.Text = days.ToString
                                items.SubItems.Add(dr(1).ToString)
                                items.SubItems.Add(dr(2).ToString)
                                items.SubItems.Add(dr(3).ToString)
                                items.SubItems.Add(dr(4).ToString)
                                items.SubItems.Add("")
                            End If
                            DTRMain.ListView1.View = View.Details
                            DTRMain.ListView1.Items.Add(items)
                            days += 1
                        End While
                    Else
                        Exit Sub
                    End If
                Else
                    Dim items As New ListViewItem
                    items.Text = days.ToString
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    DTRMain.ListView1.View = View.Details
                    DTRMain.ListView1.Items.Add(items)
                    days += 1
                End If
            ElseIf days = 1 And c = True Then
                If dr.HasRows Then
                    While dr.Read()
                        Dim weekEnd As String = dr(5).ToString
                        Dim items As New ListViewItem
                        If weekEnd = "7" Then
                            items.Text = days.ToString
                            items.SubItems.Add("")
                            items.SubItems.Add("Saturday").ForeColor = Color.Red
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                        ElseIf weekEnd = "1" Then
                            items.Text = days.ToString
                            items.SubItems.Add("")
                            items.SubItems.Add("Sunday").ForeColor = Color.Red
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                        Else
                            items.Text = days.ToString
                            items.SubItems.Add(dr(1).ToString)
                            items.SubItems.Add(dr(2).ToString)
                            items.SubItems.Add(dr(3).ToString)
                            items.SubItems.Add(dr(4).ToString)
                            items.SubItems.Add("")
                        End If
                        DTRMain.ListView1.View = View.Details
                        DTRMain.ListView1.Items.Add(items)
                        days += 1
                    End While
                Else
                    Exit Sub
                End If
            Else
                Dim weekEnd As String = dr(5).ToString
                    Dim items As New ListViewItem
                    If weekEnd = "7" Then
                        items.Text = days.ToString
                        items.SubItems.Add("")
                        items.SubItems.Add("Saturday").ForeColor = Color.Red
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                    ElseIf weekEnd = "1" Then
                        items.Text = days.ToString
                        items.SubItems.Add("")
                        items.SubItems.Add("Sunday").ForeColor = Color.Red
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                    Else
                        items.Text = days.ToString
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                    End If
                    DTRMain.ListView1.View = View.Details
                    DTRMain.ListView1.Items.Add(items)
                    days += 1
                End If

                With DTRMain
                    Dim BoldFont As Font = New Font(.ListView1.Font.FontFamily, .ListView1.Font.Size, Drawing.FontStyle.Bold)
                    For i As Integer = 0 To .ListView1.Items.Count - 1
                        .ListView1.Items(i).UseItemStyleForSubItems = False
                        .ListView1.Items(i).Font = BoldFont
                        .ListView1.Items(i).BackColor = Color.LightGray
                    Next
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
        End Try
        CloseDB()
    End Sub
    Public Sub DG_SearchWeekends(emp_id As Integer, a As Boolean, b As Boolean, c As Boolean, month As String, year As String, ifSG As Boolean)
        ConnDB()

        cmd.CommandType = CommandType.StoredProcedure
        Dim query As String
        Dim dateMonth As String = year & "-" & month
        Dim dateFrom, dateToo As Date
        Dim days As Integer = 0

        If a = True And b = False And c = False Then
            dateFrom = dateMonth & "-01"
            dateToo = dateMonth & "-15"
            days = 1
        ElseIf b = True And a = False And c = False Then
            dateFrom = dateMonth & "-16"
            dateMonth = dateMonth & "-" & dayCount
            dateToo = DateTime.Parse(dateMonth)
            days = 16
        ElseIf b = False And a = False And c = True Then
            dateFrom = dateMonth & "-01"
            If month = 2 Then
                If IsLeapYear(year) Then
                    dateMonth = dateMonth & "-29"
                Else
                    dateMonth = dateMonth & "-28"
                End If
            Else
                dateMonth = dateMonth & "-" & dayCount
            End If
            dateToo = DateTime.Parse(dateMonth)
            days = 1
        End If
        If ifSG = False Then
            query = "
            SET NOCOUNT ON;

            -- Disable foreign key checks
            EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL';

            -- Your original CTE and main query
            WITH date_ranges AS (
                SELECT CAST(@dateFrom AS DATE) AS dt
                UNION ALL
                SELECT DATEADD(DAY, 1, dt) 
                FROM date_ranges 
                WHERE DATEADD(DAY, 1, dt) <= CAST(@dateToo AS DATE)
               )
            SELECT 
                DAY(date_ranges.dt) as 'Days',
                MAX(CASE WHEN T.Checktype = 0 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '03:00:00' AND '11:59:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS ArrivalAM,
                MAX(CASE WHEN T.Checktype = 1 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '12:00:00' AND '14:00:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS DepartAM,
                MAX(CASE WHEN T.Checktype = 0 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '12:00:00' AND '14:00:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS ArrivalPM,
                MAX(CASE WHEN T.Checktype = 1 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '15:00:01' AND '23:59:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS DepartPM,
                DATEPART(WEEKDAY, date_ranges.dt) AS Weekend
            FROM 
                date_ranges
            LEFT JOIN 
                Checkinout T ON date_ranges.dt = CAST(T.Checktime AS DATE)
            GROUP BY 
                date_ranges.dt;

            -- Enable foreign key checks
            EXEC sp_msforeachtable 'ALTER TABLE ? CHECK CONSTRAINT ALL';
            "
        Else
            query = "   
                SET NOCOUNT ON;

                -- Disable foreign key checks
                EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL';

                -- Your original CTE and main query
                WITH date_ranges AS (
                    SELECT CAST(@dateFrom AS DATE) AS dt
                    UNION ALL
                    SELECT DATEADD(DAY, 1, dt) 
                    FROM date_ranges 
                    WHERE DATEADD(DAY, 1, dt) <= CAST(@dateToo AS DATE)
                )
                SELECT 
                    DAY(date_ranges.dt) as 'Days',
                    MAX(CASE WHEN T.Checktype = 1 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '03:00:00' AND '11:59:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS ArrivalAM,
                    MIN(CASE WHEN T.Checktype = 0 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '12:00:00' AND '14:00:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS DepartAM,
                    MAX(CASE WHEN T.Checktype = 1 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '12:00:00' AND '14:00:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS ArrivalPM,
                    MAX(CASE WHEN T.Checktype = 0 AND T.Userid = @emp_id AND CAST(T.Checktime AS TIME) BETWEEN '15:00:01' AND '23:59:00' THEN FORMAT(T.Checktime, 'h:mm tt') END) AS DepartPM,
                    DATEPART(WEEKDAY, date_ranges.dt) AS Weekend
                FROM 
                    date_ranges
                LEFT JOIN 
                    Checkinout T ON date_ranges.dt = CAST(T.Checktime AS DATE)
                GROUP BY 
                    date_ranges.dt;

                -- Enable foreign key checks
                EXEC sp_msforeachtable 'ALTER TABLE ? CHECK CONSTRAINT ALL';
                "
        End If
        cmd = New SqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@dateFrom", dateFrom)
        cmd.Parameters.AddWithValue("@dateToo", dateToo)
        cmd.Parameters.AddWithValue("@emp_id", emp_id)
        dr = cmd.ExecuteReader()

        DTRMain.ListView1.Clear()
        DTRMain.ListView1.Columns.Add("Day", 50, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Arrive", 80, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Depart", 80, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Arrive", 80, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Depart", 80, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Hours", 40, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Minutes", 40, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))

        Try
            If days = 1 And c = False Then
                While days <= 31
                    If days = 1 Then
                        If dr.HasRows Then
                            While dr.Read()
                                Dim weekEnd As String = dr(5).ToString
                                Dim items As New ListViewItem
                                If weekEnd = "7" Or weekEnd = "" Then
                                    items.Text = days.ToString
                                    If dr.IsDBNull(2) = True Then
                                        items.SubItems.Add("")
                                        items.SubItems.Add("Saturday")
                                        items.SubItems.Add("")
                                        items.SubItems.Add("")
                                        items.SubItems.Add("")
                                    End If
                                    items.SubItems.Add(dr(1).ToString)
                                    items.SubItems.Add(dr(2).ToString)
                                    items.SubItems.Add(dr(3).ToString)
                                    items.SubItems.Add(dr(4).ToString)
                                    items.SubItems.Add("")
                                ElseIf weekEnd = "1" Or weekEnd = "" Then
                                    items.Text = days.ToString
                                    items.SubItems.Add(dr(1).ToString)
                                    items.SubItems.Add(dr(2).ToString)
                                    items.SubItems.Add(dr(3).ToString)
                                    items.SubItems.Add(dr(4).ToString)
                                    items.SubItems.Add("")
                                Else
                                    items.Text = days.ToString
                                    items.SubItems.Add(dr(1).ToString)
                                    items.SubItems.Add(dr(2).ToString)
                                    items.SubItems.Add(dr(3).ToString)
                                    items.SubItems.Add(dr(4).ToString)
                                    items.SubItems.Add("")
                                End If
                                DTRMain.ListView1.View = View.Details
                                DTRMain.ListView1.Items.Add(items)
                                days += 1
                            End While
                        Else
                            Exit Sub
                        End If
                    Else
                        Dim items As New ListViewItem
                        items.Text = days.ToString
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        DTRMain.ListView1.View = View.Details
                        DTRMain.ListView1.Items.Add(items)
                        days += 1
                    End If
                End While
            ElseIf days = 16 And c = False Then
                Dim count As Integer = 1
                While count <= 15
                    Dim items As New ListViewItem
                    items.Text = count.ToString
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    DTRMain.ListView1.View = View.Details
                    DTRMain.ListView1.Items.Add(items)
                    count += 1
                End While
                If days = 16 Then
                    If dr.HasRows Then
                        While dr.Read()
                            Dim weekEnd As String = dr(5).ToString
                            Dim items As New ListViewItem
                            If weekEnd = "7" Or weekEnd = "" Then
                                items.Text = days.ToString
                                items.SubItems.Add(dr(1).ToString)
                                items.SubItems.Add(dr(2).ToString)
                                items.SubItems.Add(dr(3).ToString)
                                items.SubItems.Add(dr(4).ToString)
                                items.SubItems.Add("")
                            ElseIf weekEnd = "1" Or weekEnd = "" Then
                                items.Text = days.ToString
                                items.SubItems.Add(dr(1).ToString)
                                items.SubItems.Add(dr(2).ToString)
                                items.SubItems.Add(dr(3).ToString)
                                items.SubItems.Add(dr(4).ToString)
                                items.SubItems.Add("")
                            Else
                                items.Text = days.ToString
                                items.SubItems.Add(dr(1).ToString)
                                items.SubItems.Add(dr(2).ToString)
                                items.SubItems.Add(dr(3).ToString)
                                items.SubItems.Add(dr(4).ToString)
                                items.SubItems.Add("")
                            End If
                            DTRMain.ListView1.View = View.Details
                            DTRMain.ListView1.Items.Add(items)
                            days += 1
                        End While
                    Else
                        Exit Sub
                    End If
                Else
                    Dim items As New ListViewItem
                    items.Text = days.ToString
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    DTRMain.ListView1.View = View.Details
                    DTRMain.ListView1.Items.Add(items)
                    days += 1
                End If
            ElseIf days = 1 And c = True Then
                If dr.HasRows Then
                    While dr.Read()
                        Dim weekEnd As String = dr(5).ToString
                        Dim items As New ListViewItem
                        If weekEnd = "7" Then
                            items.Text = days.ToString
                            items.SubItems.Add(dr(1).ToString)
                            items.SubItems.Add(dr(2).ToString)
                            items.SubItems.Add(dr(3).ToString)
                            items.SubItems.Add(dr(4).ToString)
                            items.SubItems.Add("")
                        ElseIf weekEnd = "1" Then
                            items.Text = days.ToString
                            items.SubItems.Add(dr(1).ToString)
                            items.SubItems.Add(dr(2).ToString)
                            items.SubItems.Add(dr(3).ToString)
                            items.SubItems.Add(dr(4).ToString)
                            items.SubItems.Add("")
                        Else
                            items.Text = days.ToString
                            items.SubItems.Add(dr(1).ToString)
                            items.SubItems.Add(dr(2).ToString)
                            items.SubItems.Add(dr(3).ToString)
                            items.SubItems.Add(dr(4).ToString)
                            items.SubItems.Add("")
                        End If
                        DTRMain.ListView1.View = View.Details
                        DTRMain.ListView1.Items.Add(items)
                        days += 1
                    End While
                Else
                    Exit Sub
                End If
            Else
                Dim weekEnd As String = dr(5).ToString
                Dim items As New ListViewItem
                If weekEnd = "7" Then
                    items.Text = days.ToString
                    items.SubItems.Add(dr(1).ToString)
                    items.SubItems.Add(dr(2).ToString)
                    items.SubItems.Add(dr(3).ToString)
                    items.SubItems.Add(dr(4).ToString)
                    items.SubItems.Add("")
                ElseIf weekEnd = "1" Then
                    items.Text = days.ToString
                    items.SubItems.Add(dr(1).ToString)
                    items.SubItems.Add(dr(2).ToString)
                    items.SubItems.Add(dr(3).ToString)
                    items.SubItems.Add(dr(4).ToString)
                    items.SubItems.Add("")
                Else
                    items.Text = days.ToString
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                End If
                DTRMain.ListView1.View = View.Details
                DTRMain.ListView1.Items.Add(items)
                days += 1
            End If

            With DTRMain
                Dim BoldFont As Font = New Font(.ListView1.Font.FontFamily, .ListView1.Font.Size, Drawing.FontStyle.Bold)
                For i As Integer = 0 To .ListView1.Items.Count - 1
                    .ListView1.Items(i).UseItemStyleForSubItems = False
                    .ListView1.Items(i).Font = BoldFont
                    .ListView1.Items(i).BackColor = Color.LightGray
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
        CloseDB()
    End Sub
    Public Sub searchDTR(emp_id As Integer, a As Boolean, b As Boolean, c As Boolean, month As String, year As Integer, ifSG As Boolean)

        Dim query As String
        If ifSG = False Then
            query = "
            WITH RECURSIVE date_ranges AS (
            SELECT @dateFrm dt UNION ALL
            SELECT dt + INTERVAL 1 DAY FROM date_ranges 
            WHERE dt + INTERVAL 1 DAY <= @dateTo)
            SELECT date_ranges.dt
            , MAX(CASE WHEN T.workstate = 0 AND T.employee_id = @emp_id AND TIME(T.punch_time) BETWEEN '03:00:00' AND '11:59:00' THEN DATE_FORMAT(T.punch_time, '%l:%i %p') END) AS ArrivalAM 
            , MAX(CASE WHEN T.workstate = 1 AND T.employee_id = @emp_id  AND TIME(T.punch_time) BETWEEN '12:00:00' AND '14:00:00' THEN DATE_FORMAT(T.punch_time, '%l:%i %p') END) AS DepartAM 
            , MAX(CASE WHEN T.workstate = 0 AND T.employee_id = @emp_id  AND TIME(T.punch_time) BETWEEN '12:00:00' AND '14:00:00' THEN DATE_FORMAT(T.punch_time, '%l:%i %p') END) AS ArrivalPM 
            , MAX(CASE WHEN T.workstate = 1 AND T.employee_id = @emp_id  AND TIME(T.punch_time) BETWEEN '15:00:01' AND '23:59:00' THEN DATE_FORMAT(T.punch_time, '%l:%i %p') END) AS DepartPM 
            , DAYOFWEEK(CAST(dt AS DATE)) AS Weekend
            FROM date_ranges
            LEFT JOIN `att_punches` T
            ON date_ranges.dt = CAST(punch_time AS DATE)
            GROUP BY date_ranges.dt;
            "
        Else
            query = "
            WITH RECURSIVE date_ranges AS (
            SELECT @dateFrm dt UNION ALL
            SELECT dt + INTERVAL 1 DAY FROM date_ranges 
            WHERE dt + INTERVAL 1 DAY <= @dateTo)
            SELECT date_ranges.dt
            , MAX(CASE WHEN T.workstate = 1 AND T.employee_id = @emp_id AND TIME(T.punch_time) BETWEEN '03:00:00' AND '11:59:00' THEN DATE_FORMAT(T.punch_time, '%l:%i %p') END) AS ArrivalAM 
            , MAX(CASE WHEN T.workstate = 0 AND T.employee_id = @emp_id  AND TIME(T.punch_time) BETWEEN '12:00:00' AND '14:00:00' THEN DATE_FORMAT(T.punch_time, '%l:%i %p') END) AS DepartAM 
            , MAX(CASE WHEN T.workstate = 1 AND T.employee_id = @emp_id  AND TIME(T.punch_time) BETWEEN '12:00:00' AND '14:00:00' THEN DATE_FORMAT(T.punch_time, '%l:%i %p') END) AS ArrivalPM 
            , MAX(CASE WHEN T.workstate = 0 AND T.employee_id = @emp_id  AND TIME(T.punch_time) BETWEEN '15:00:01' AND '23:59:00' THEN DATE_FORMAT(T.punch_time, '%l:%i %p') END) AS DepartPM 
            , DAYOFWEEK(CAST(dt AS DATE)) AS Weekend
            FROM date_ranges
            LEFT JOIN `att_punches` T
            ON date_ranges.dt = CAST(punch_time AS DATE)
            GROUP BY date_ranges.dt;
            "
        End If

        str = "Server=" & server & ";Port=" & port & ";Uid=" & user & ";Pwd=" & pass & ";Database=" & db & ";persist security info=false; SslMode=none;"
        'conn = New MySqlConnection(str)
        'cmd = New MySqlCommand(query, conn)
        Dim days As Integer = 0

        If a = True And b = False And c = False Then
            Dim dateMonth As String = year & "-" & month
            cmd.Parameters.AddWithValue("@dateFrm", dateMonth & "-01")
            cmd.Parameters.AddWithValue("@dateTo", dateMonth & "-15")
            days = 1
        ElseIf b = True And a = False And c = False Then
            Dim dateMonth As String = year & "-" & month
            cmd.Parameters.AddWithValue("@dateFrm", dateMonth & "-16")
            cmd.Parameters.AddWithValue("@dateTo", dateMonth & "-31")
            days = 16
        ElseIf b = False And a = False And c = True Then
            Dim dateMonth As String = year & "-" & month
            cmd.Parameters.AddWithValue("@dateFrm", dateMonth & "-01")
            cmd.Parameters.AddWithValue("@dateTo", dateMonth & "-31")
            days = 1
        End If
        cmd.Parameters.AddWithValue("@emp_id", emp_id)
        conn.Open()
        dr = cmd.ExecuteReader

        DTRMain.ListView1.Clear()
        DTRMain.ListView1.Columns.Add("Day", 50, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Arrive", 80, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Depart", 80, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Arrive", 80, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Depart", 80, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Hours", 30, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        DTRMain.ListView1.Columns.Add("Minutes", 50, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))

        Try
            If days = 1 And c = False Then
                While days <= 31
                    If days = 1 Then
                        If dr.HasRows Then
                            While dr.Read()
                                Dim weekEnd As String = dr(5).ToString
                                Dim items As New ListViewItem
                                If weekEnd = "7" Or weekEnd = "" Then
                                    items.Text = days.ToString
                                    items.SubItems.Add("")
                                    items.SubItems.Add("Saturday").ForeColor = Color.Red
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                ElseIf weekEnd = "1" Or weekEnd = "" Then
                                    items.Text = days.ToString
                                    items.SubItems.Add("")
                                    items.SubItems.Add("Sunday").ForeColor = Color.Red
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                Else
                                    items.Text = days.ToString
                                    items.SubItems.Add(dr(1).ToString)
                                    items.SubItems.Add(dr(2).ToString)
                                    items.SubItems.Add(dr(3).ToString)
                                    items.SubItems.Add(dr(4).ToString)
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                    items.SubItems.Add("")
                                End If
                                DTRMain.ListView1.View = View.Details
                                DTRMain.ListView1.Items.Add(items)
                                days += 1
                            End While
                        Else
                            Exit Sub
                        End If
                    Else
                        Dim items As New ListViewItem
                        items.Text = days.ToString
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        DTRMain.ListView1.View = View.Details
                        DTRMain.ListView1.Items.Add(items)
                        days += 1
                    End If
                End While
            ElseIf days = 16 And c = False Then
                Dim count As Integer = 1
                While count <= 15
                    Dim items As New ListViewItem
                    items.Text = count.ToString
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    DTRMain.ListView1.View = View.Details
                    DTRMain.ListView1.Items.Add(items)
                    count += 1
                End While
                If days = 16 Then
                    If dr.HasRows Then
                        While dr.Read()
                            Dim weekEnd As String = dr(5).ToString
                            Dim items As New ListViewItem
                            If weekEnd = "7" Or weekEnd = "" Then
                                items.Text = days.ToString
                                items.SubItems.Add("")
                                items.SubItems.Add("Saturday").ForeColor = Color.Red
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                            ElseIf weekEnd = "1" Or weekEnd = "" Then
                                items.Text = days.ToString
                                items.SubItems.Add("")
                                items.SubItems.Add("Sunday").ForeColor = Color.Red
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                            Else
                                items.Text = days.ToString
                                items.SubItems.Add(dr(1).ToString)
                                items.SubItems.Add(dr(2).ToString)
                                items.SubItems.Add(dr(3).ToString)
                                items.SubItems.Add(dr(4).ToString)
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                            End If
                            DTRMain.ListView1.View = View.Details
                            DTRMain.ListView1.Items.Add(items)
                            days += 1
                        End While
                    Else
                        Exit Sub
                    End If
                Else
                    Dim items As New ListViewItem
                    items.Text = days.ToString
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    DTRMain.ListView1.View = View.Details
                    DTRMain.ListView1.Items.Add(items)
                    days += 1
                End If
            ElseIf days = 1 And c = True Then
                If dr.HasRows Then
                    While dr.Read()
                        Dim weekEnd As String = dr(5).ToString
                        Dim items As New ListViewItem
                        If weekEnd = "7" Then
                            items.Text = days.ToString
                            items.SubItems.Add("")
                            items.SubItems.Add("Saturday").ForeColor = Color.Red
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                        ElseIf weekEnd = "1" Then
                            items.Text = days.ToString
                            items.SubItems.Add("")
                            items.SubItems.Add("Sunday").ForeColor = Color.Red
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                        Else
                            items.Text = days.ToString
                            items.SubItems.Add(dr(1).ToString)
                            items.SubItems.Add(dr(2).ToString)
                            items.SubItems.Add(dr(3).ToString)
                            items.SubItems.Add(dr(4).ToString)
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                        End If
                        DTRMain.ListView1.View = View.Details
                        DTRMain.ListView1.Items.Add(items)
                        days += 1
                    End While
                Else
                    Exit Sub
                End If
            Else
                Dim weekEnd As String = dr(5).ToString
                Dim items As New ListViewItem
                If weekEnd = "7" Then
                    items.Text = days.ToString
                    items.SubItems.Add("")
                    items.SubItems.Add("Saturday").ForeColor = Color.Red
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                ElseIf weekEnd = "1" Then
                    items.Text = days.ToString
                    items.SubItems.Add("")
                    items.SubItems.Add("Sunday").ForeColor = Color.Red
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                Else
                    items.Text = days.ToString
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                    items.SubItems.Add("")
                End If
                DTRMain.ListView1.View = View.Details
                DTRMain.ListView1.Items.Add(items)
                days += 1
            End If

            With DTRMain
                Dim BoldFont As Font = New Font(.ListView1.Font.FontFamily, .ListView1.Font.Size, Drawing.FontStyle.Bold)
                For i As Integer = 0 To .ListView1.Items.Count - 1
                    .ListView1.Items(i).UseItemStyleForSubItems = False
                    .ListView1.Items(i).Font = BoldFont
                    .ListView1.Items(i).BackColor = Color.LightGray
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
        CloseDB()

    End Sub
    Public Sub searchDTRAll(emp_id As Integer, dtpFrom As Date, dtpTo As Date)

        Dim query As String
        'query = "
        '        SELECT 
        '          `hr_employee`.`emp_pin`,
        '          `hr_employee`.`emp_firstname`,
        '          `hr_employee`.`emp_lastname`,
        '          `employee_id`,
        '          `workstate`,
        '          `punch_time`
        '        FROM
        '          `att_punches`
        '        LEFT JOIN `hr_employee` 
        '        ON `att_punches`.`employee_id` = `hr_employee`.`id`
        '        WHERE `employee_id` = @emp_id
        '        AND CAST(`punch_time` AS DATE) BETWEEN @dtpFrom AND @dtpTo
        '        ORDER BY `punch_time` DESC;
        '        "
        query = "
                SELECT 
                  Checkinout.Userid,
                  Userinfo.Name,
                  CheckType,
                  Checktime
                FROM
                  Checkinout
                LEFT JOIN Userinfo 
                ON Checkinout.Userid = Userinfo.Userid
                WHERE Checkinout.Userid = @emp_id
                AND CAST(Checktime AS DATE) BETWEEN CAST(@dateFrom as Date) AND CAST(@dateToo as Date)
                ORDER BY Checktime DESC;
                "

        str = "Server=" & server & ";Port=" & port & ";Uid=" & user & ";Pwd=" & pass & ";Database=" & db & ";persist security info=false; SslMode=none;"
        'conn = New MySqlConnection(str)
        'cmd = New MySqlCommand(query, conn)

        ConnDB()
        cmd = New SqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@dateFrom", dtpFrom)
        cmd.Parameters.AddWithValue("@dateToo", dtpTo)
        cmd.Parameters.AddWithValue("@emp_id", emp_id)
        dr = cmd.ExecuteReader()

        AllData.ListView1.Clear()
        AllData.ListView1.Columns.Add("Emp_ID", 70, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        AllData.ListView1.Columns.Add("Full Name", 300, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        AllData.ListView1.Columns.Add("Status", 100, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))
        AllData.ListView1.Columns.Add("Date/Time", 150, CType(HorizontalAlignment.Center, Forms.HorizontalAlignment))

        Try
            Dim days As Integer = 0
            Dim workstate As String = ""
            If dr.HasRows Then
                While dr.Read()
                    workstate = dr(2).ToString
                    If workstate = 1 Then
                        workstate = "TIME-OUT"
                    Else
                        workstate = "TIME-IN"
                    End If
                    Dim items As New ListViewItem
                    items.Text = dr(0).ToString
                    items.SubItems.Add(dr(1).ToString)
                    items.SubItems.Add(workstate)
                    items.SubItems.Add(dr(3).ToString)
                    AllData.ListView1.View = View.Details
                    AllData.ListView1.Items.Add(items)
                    days += 1
                End While
            Else
                Exit Sub
            End If
            With AllData
                Dim BoldFont As Font = New Font(.ListView1.Font.FontFamily, .ListView1.Font.Size, Drawing.FontStyle.Bold)
                For i As Integer = 0 To .ListView1.Items.Count - 1
                    .ListView1.Items(i).UseItemStyleForSubItems = False
                    .ListView1.Items(i).Font = BoldFont
                    .ListView1.Items(i).BackColor = Color.LightGray
                Next
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
        End Try
        CloseDB()

    End Sub
    Public Sub DBUpdater(OldID As Integer, NewID As Integer, hr_employee As Boolean, hr_biometrics As Boolean)

        Dim i As Integer
        Dim query As String
        connection()
        If hr_employee = True Then
            query = "SET FOREIGN_KEY_CHECKS = 0; UPDATE hr_employee SET id=@OldID WHERE id=@NewID"
            'cmd = New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@OldID", OldID)
            cmd.Parameters.AddWithValue("@NewID", NewID)
            Database_Updater.RichTextBox1.Text = query
            Try
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("User Updated!")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                CloseDB()
            End Try
        End If

        If hr_biometrics = True Then
            connection()
            query = "SET FOREIGN_KEY_CHECKS = 0; INSERT hr_biotemplate SET employee_id='" & OldID & "' WHERE employee_id='" & NewID & "'"

            'cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@OldID", OldID)
            cmd.Parameters.AddWithValue("@NewID", NewID)
            Database_Updater.RichTextBox1.Text = query
            Try
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("Fingeprint Updated!")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                CloseDB()
            End Try
        End If
    End Sub
    Public Sub DBInsert(EmpID As Integer, DatePunch As Date, WorkState As Integer, undo As Boolean)
        Dim i As Integer
        If undo = False Then
            connection()
            Dim query As String = "EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'; INSERT INTO `anviz`.`Checkinout` ( `Userid`,`CheckTime`,`CheckType` ) VALUES ( @Userid, @CheckTime, @CheckType );"

            'cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@Userid", EmpID)
            cmd.Parameters.AddWithValue("@CheckTime", DatePunch)
            cmd.Parameters.AddWithValue("@CheckType", WorkState)
            Database_Updater.RichTextBox1.Text = query

            Try
                i = cmd.ExecuteNonQuery
                If i > 0 Then
                    MsgBox("Done")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                CloseDB()
            End Try
        ElseIf undo = True Then
            connection()
            Dim query As String = "EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'; delete from `zkteco`.`att_punches` where `id` = @EmpID AND `punch_time` = @DatePunch;"

            'cmd = New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@EmpID", EmpID)
            cmd.Parameters.AddWithValue("@DatePunch", DatePunch)
            cmd.Parameters.AddWithValue("@WorkState", WorkState)
            Database_Updater.RichTextBox1.Text = query

            Try
                MsgBox("Done")
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                CloseDB()
            End Try
        End If

    End Sub
    Public Sub updateMonth()
        If DTRMain.RadioButton1.Checked = True Then
            DTRMain.lblMonth.Text = DTRMain.ComboBox1.Text & " 1 - 15 , " & DTRMain.cbYear.Text.ToUpper
        ElseIf DTRMain.RadioButton3.Checked = True Then
            DTRMain.lblMonth.Text = DTRMain.ComboBox1.Text & " " & DTRMain.cbYear.Text.ToUpper
        ElseIf DTRMain.RadioButton2.Checked = True Then
            DTRMain.lblMonth.Text = DTRMain.ComboBox1.Text & " 16 - 30 , " & DTRMain.cbYear.Text.ToUpper
        End If
    End Sub

    Public Sub searchLogin(ByVal txtUser As String, txtPass As String)
        'connection()
        ConnDB()
        Dim query As String = "SELECT OPName, OPPwd, OPGroupID FROM OPinfo WHERE OPName = @txtUser and OPPwd = @txtPass"
        'cmd = New MySqlCommand(query, conn)
        cmd = New SqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@txtUser", txtUser)
        cmd.Parameters.AddWithValue("@txtPass", txtPass)
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            Form1.ToolStripButton3.Enabled = True
            Form1.ToolStripButton2.Enabled = True
            Form1.Show()
            Form1.ToolStripStatusLabel1.Text = "Welcome " + txtUser + "!"
            While dr.Read
                If dr(2).ToString = "1" Then
                    Form1.ToolStripStatusLabel1.Tag = "admin"
                Else
                    Form1.ToolStripStatusLabel1.Tag = ""
                End If
            End While
            LoginForm1.Hide()
        Else
            MsgBox("User not found or User/Pass not correct")
        End If
        CloseDB()
    End Sub
    Public Sub checkTotalEmpIn()
        Dim counter As Integer = 0
        connection2()
        Dim query As String = "SELECT 
          `hr_employee`.`emp_lastname`,
          `hr_employee`.`emp_firstname`,
          `hr_department`.`dept_name`,
          `employee_id`,
          `workstate`,
          `punch_time`
        FROM
          `att_punches`
        LEFT JOIN `hr_employee` 
        ON `att_punches`.`employee_id` = `hr_employee`.`id`
        LEFT JOIN `hr_department`
        ON `hr_department`.`id` = `hr_employee`.`department_id`
        WHERE
        CAST(`punch_time` AS DATE) = CURDATE() AND TIME(`punch_time`) 
        BETWEEN '05:00:00' AND '10:59:00' 
        AND `workstate` = '0'
        ORDER BY `hr_employee`.`emp_lastname` ASC;"
        cmd2 = New MySqlCommand(query, conn2)
        dr2 = cmd2.ExecuteReader
        If dr2.HasRows Then
            While dr2.Read
                counter += 1
            End While
        Else
            Exit Sub
        End If
        Form1.lbl_empInCount.Text = counter.ToString
        CloseDB2()

        connection2()
        query = "SELECT 
          `hr_employee`.`emp_firstname`,
          `hr_employee`.`emp_lastname`,
          `employee_id`,
          `workstate`,
          `punch_time`
        FROM
          `att_punches`
        LEFT JOIN `hr_employee` 
        ON `att_punches`.`employee_id` = `hr_employee`.`id`
        WHERE
        CAST(`punch_time` AS DATE) = CURDATE() AND TIME(`punch_time`) 
        BETWEEN '11:00:00' AND '14:00:00' 
        AND `workstate` = '1'
        ORDER BY `hr_employee`.`emp_lastname` ASC;"

        cmd2 = New MySqlCommand(query, conn2)
        dr2 = cmd2.ExecuteReader
        If dr2.HasRows Then
            While dr2.Read
                counter -= 1
            End While
        Else
            Exit Sub
        End If
        Form1.lbl_empInCount.Text = counter.ToString
        CloseDB2()

        connection2()
        query = "SELECT 
          `hr_employee`.`emp_lastname`,
          `hr_employee`.`emp_firstname`,
          `hr_department`.`dept_name`,
          `employee_id`,
          `workstate`,
          `punch_time`
        FROM
          `att_punches`
        LEFT JOIN `hr_employee` 
        ON `att_punches`.`employee_id` = `hr_employee`.`id`
        LEFT JOIN `hr_department`
        ON `hr_department`.`id` = `hr_employee`.`department_id`
        WHERE
        CAST(`punch_time` AS DATE) = CURDATE() AND TIME(`punch_time`) 
        BETWEEN '11:00:00' AND '14:00:00' 
        AND `workstate` = '0'
        ORDER BY `hr_employee`.`emp_lastname` ASC;"

        cmd2 = New MySqlCommand(query, conn2)
        dr2 = cmd2.ExecuteReader
        If dr2.HasRows Then
            While dr2.Read
                counter += 1
            End While
        Else
            Exit Sub
        End If
        Form1.lbl_empInCount.Text = counter.ToString
        CloseDB2()

        connection2()
        query = "SELECT 
          `hr_employee`.`emp_firstname`,
          `hr_employee`.`emp_lastname`,
          `employee_id`,
          `workstate`,
          `punch_time`
        FROM
          `att_punches`
        LEFT JOIN `hr_employee` 
        ON `att_punches`.`employee_id` = `hr_employee`.`id`
        WHERE
        CAST(`punch_time` AS DATE) = CURDATE() AND TIME(`punch_time`) 
        BETWEEN '14:00:05' AND '20:00:00' 
        AND `workstate` = '1'
        ORDER BY `hr_employee`.`emp_lastname` ASC;"

        cmd2 = New MySqlCommand(query, conn2)
        dr2 = cmd2.ExecuteReader
        If dr2.HasRows Then
            While dr2.Read
                counter -= 1
            End While
        Else
            Exit Sub
        End If
        Form1.lbl_empInCount.Text = counter.ToString
        CloseDB2()
    End Sub

    Public Sub checkTotalEmpIn2()
        connection3()
        Dim counter As Integer = 0
        Dim query As String = "SELECT 
          `hr_employee`.`id`,
          `hr_employee`.`emp_lastname`,
          `hr_employee`.`emp_firstname`,
          `hr_department`.`dept_name`,
          `employee_id`,
          `workstate`,
          `punch_time`
        FROM
          `att_punches`
        LEFT JOIN `hr_employee` 
        ON `att_punches`.`employee_id` = `hr_employee`.`id`
        LEFT JOIN `hr_department`
        ON `hr_department`.`id` = `hr_employee`.`department_id`
        WHERE
        CAST(`punch_time` AS DATE) = CURDATE() AND TIME(`punch_time`) 
        BETWEEN '05:00:00' AND '10:59:00'
        AND `workstate` = '0'
        ORDER BY `hr_department`.`dept_name` ASC;"

        LoggedIn.lv_employees.Clear() 'clear the table
        LoggedIn.lv_employees.Columns.Add("ID", 50)
        LoggedIn.lv_employees.Columns.Add("Last Name", 200)
        LoggedIn.lv_employees.Columns.Add("First Name", 200)
        LoggedIn.lv_employees.Columns.Add("Dept. Name", 150)
        LoggedIn.lv_employees.Columns.Add("Time in", 150)
        cmd3 = New MySqlCommand(query, conn3)
        dr3 = cmd3.ExecuteReader

        If dr3.HasRows Then
            While dr3.Read
                Dim items As New ListViewItem
                items.Text = dr3(0).ToString
                items.SubItems.Add(dr3(1).ToString)
                items.SubItems.Add(dr3(2).ToString)
                items.SubItems.Add(dr3(3).ToString)
                LoggedIn.lv_employees.View = View.Details
                LoggedIn.lv_employees.Items.Add(items)
                counter += 1
            End While
        Else
            Exit Sub
        End If
        Form1.lbl_empInCount.Text = counter.ToString
        CloseDB3()

        connection3()
        query = "SELECT 
          `hr_employee`.`id`,
          `hr_employee`.`emp_lastname`,
          `hr_employee`.`emp_firstname`,
          `hr_department`.`dept_name`,
          `employee_id`,
          `workstate`,
          `punch_time`
        FROM
          `att_punches`
        LEFT JOIN `hr_employee` 
        ON `att_punches`.`employee_id` = `hr_employee`.`id`
        LEFT JOIN `hr_department`
        ON `hr_department`.`id` = `hr_employee`.`department_id`
        WHERE
        CAST(`punch_time` AS DATE) = CURDATE() AND TIME(`punch_time`) 
        BETWEEN '11:00:00' AND '14:00:00' 
        AND `workstate` = '1'
        ORDER BY `hr_department`.`dept_name` ASC;"

        cmd3 = New MySqlCommand(query, conn3)
        dr3 = cmd3.ExecuteReader
        If dr3.HasRows Then
            While dr3.Read
                counter -= 1
            End While
        Else
            Exit Sub
        End If
        Form1.lbl_empInCount.Text = counter.ToString
        CloseDB3()

        connection3()
        query = "SELECT 
          `hr_employee`.`id`,
          `hr_employee`.`emp_lastname`,
          `hr_employee`.`emp_firstname`,
          `hr_department`.`dept_name`,
          `employee_id`,
          `workstate`,
          `punch_time`
        FROM
          `att_punches`
        LEFT JOIN `hr_employee` 
        ON `att_punches`.`employee_id` = `hr_employee`.`id`
        LEFT JOIN `hr_department`
        ON `hr_department`.`id` = `hr_employee`.`department_id`
        WHERE
        CAST(`punch_time` AS DATE) = CURDATE() AND TIME(`punch_time`) 
        BETWEEN '11:00:00' AND '14:00:00' 
        AND `workstate` = '0'
        ORDER BY `hr_department`.`dept_name` ASC;"

        LoggedIn.lv_employees.Clear() 'clear the table
        LoggedIn.lv_employees.Columns.Add("ID", 50)
        LoggedIn.lv_employees.Columns.Add("Last Name", 200)
        LoggedIn.lv_employees.Columns.Add("First Name", 200)
        LoggedIn.lv_employees.Columns.Add("Dept. Name", 150)
        LoggedIn.lv_employees.Columns.Add("Time in", 150)
        cmd3 = New MySqlCommand(query, conn3)
        dr3 = cmd3.ExecuteReader

        If dr3.HasRows Then
            While dr3.Read
                Dim items As New ListViewItem
                items.Text = dr3(0).ToString
                items.SubItems.Add(dr3(1).ToString)
                items.SubItems.Add(dr3(2).ToString)
                items.SubItems.Add(dr3(3).ToString)
                LoggedIn.lv_employees.View = View.Details
                LoggedIn.lv_employees.Items.Add(items)
                counter += 1
            End While
        Else
            Exit Sub
        End If
        Form1.lbl_empInCount.Text = counter.ToString
        CloseDB3()

        connection3()
        query = "SELECT 
          `hr_employee`.`id`,
          `hr_employee`.`emp_lastname`,
          `hr_employee`.`emp_firstname`,
          `hr_department`.`dept_name`,
          `employee_id`,
          `workstate`,
          `punch_time`
        FROM
          `att_punches`
        LEFT JOIN `hr_employee` 
        ON `att_punches`.`employee_id` = `hr_employee`.`id`
        LEFT JOIN `hr_department`
        ON `hr_department`.`id` = `hr_employee`.`department_id`
        WHERE
        CAST(`punch_time` AS DATE) = CURDATE() AND TIME(`punch_time`) 
        BETWEEN '14:00:05' AND '20:00:00' 
        AND `workstate` = '1'
        ORDER BY `hr_department`.`dept_name` ASC;"

        LoggedIn.lv_employees.Clear() 'clear the table
        LoggedIn.lv_employees.Columns.Add("ID", 50)
        LoggedIn.lv_employees.Columns.Add("Last Name", 200)
        LoggedIn.lv_employees.Columns.Add("First Name", 200)
        LoggedIn.lv_employees.Columns.Add("Dept. Name", 150)
        LoggedIn.lv_employees.Columns.Add("Time in", 150)
        cmd3 = New MySqlCommand(query, conn3)
        dr3 = cmd3.ExecuteReader

        If dr3.HasRows Then
            While dr3.Read
                Dim items As New ListViewItem
                items.Text = dr3(0).ToString
                items.SubItems.Add(dr3(1).ToString)
                items.SubItems.Add(dr3(2).ToString)
                items.SubItems.Add(dr3(3).ToString)
                LoggedIn.lv_employees.View = View.Details
                LoggedIn.lv_employees.Items.Add(items)
                counter -= 1
            End While
        Else
            Exit Sub
        End If
        Form1.lbl_empInCount.Text = counter.ToString
        LoggedIn.ToolStripStatusLabel1.Text = LoggedIn.lv_employees.Items.Count.ToString
        CloseDB3()
    End Sub
End Module

