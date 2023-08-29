Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Module dbMod

    'Database Variables
    Public conn As MySqlConnection
    Public str As String
    Public cmd As MySqlCommand
    Public dr As MySqlDataReader

    Dim server As String = "172.20.72.124"
    Dim port As String = "3307"
    Dim user As String = "root"
    Dim pass As String = "CDPabina"
    Dim db As String = "zkteco"

    'Dim server As String = "localhost"
    'Dim port As String = "3306"
    'Dim user As String = "root"
    'Dim pass As String = "CDPabina"
    'Dim db As String = "zkteco"
    Public Sub connection()
        Try

            str = "Server=" & server & ";Port=" & port & ";Uid=" & user & ";Pwd=" & pass & ";Database=" & db & ";persist security info=false; SslMode=none;"

            conn = New MySqlConnection(str)
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

    Public Sub CloseDB()
        Try
            conn.Close()
            conn.Dispose()
        Catch myerror As MySqlException
        End Try
    End Sub
    Public Sub searchEmployee(ByVal txtEmployee As String)
        connection()
        Dim query As String = "SELECT id, emp_pin, emp_firstname, emp_lastname FROM hr_employee WHERE emp_firstname LIKE '%" & txtEmployee & "%' or emp_lastname LIKE '%" & txtEmployee & "%'"
        cmd = New MySqlCommand(query, conn)
        dr = cmd.ExecuteReader

        SearchEmp.lv_employees.Clear() 'clear the table
        SearchEmp.lv_employees.Columns.Add("ID", 100)
        SearchEmp.lv_employees.Columns.Add("Emp_ID", 100)
        SearchEmp.lv_employees.Columns.Add("First Name", 250)
        SearchEmp.lv_employees.Columns.Add("Last Name", 250)

        If dr.HasRows Then
            While dr.Read
                Dim items As New ListViewItem
                items.Text = dr("id").ToString
                items.SubItems.Add(dr("emp_pin").ToString)
                items.SubItems.Add(dr("emp_firstname").ToString)
                items.SubItems.Add(dr("emp_lastname").ToString)
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

    Public Sub searchDTR(emp_id As Integer, a As Boolean, b As Boolean, c As Boolean)

        Dim query As String
        query = "
            WITH RECURSIVE date_ranges AS (
            SELECT @dateFrm dt UNION ALL
            SELECT dt + INTERVAL 1 DAY FROM date_ranges 
            WHERE dt + INTERVAL 1 DAY <= @dateTo)
            SELECT date_ranges.dt
            , MAX(CASE WHEN T.workstate = 0 AND T.employee_id = @emp_id AND TIME(T.punch_time) BETWEEN '03:00:00' AND '11:59:00' THEN DATE_FORMAT(T.punch_time, '%l:%i %p') END) AS ArrivalAM 
            , MAX(CASE WHEN T.workstate = 1 AND T.employee_id = @emp_id  AND TIME(T.punch_time) BETWEEN '12:00:00' AND '14:00:00' THEN DATE_FORMAT(T.punch_time, '%l:%i %p') END) AS DepartAM 
            , MAX(CASE WHEN T.workstate = 0 AND T.employee_id = @emp_id  AND TIME(T.punch_time) BETWEEN '12:00:00' AND '13:00:00' THEN DATE_FORMAT(T.punch_time, '%l:%i %p') END) AS ArrivalPM 
            , MAX(CASE WHEN T.workstate = 1 AND T.employee_id = @emp_id  AND TIME(T.punch_time) BETWEEN '13:00:01' AND '23:59:00' THEN DATE_FORMAT(T.punch_time, '%l:%i %p') END) AS DepartPM 
             FROM date_ranges
            LEFT JOIN `att_punches` T
            ON date_ranges.dt = CAST(punch_time AS DATE)
            GROUP BY date_ranges.dt;
            "

        str = "Server=" & server & ";Port=" & port & ";Uid=" & user & ";Pwd=" & pass & ";Database=" & db & ";persist security info=false; SslMode=none;"
        conn = New MySqlConnection(str)
        cmd = New MySqlCommand(query, conn)


        Dim dayFrom As Integer = Convert.ToInt32(DTRMain.dtp_from.Value.ToString("dd"))
        Dim days As Integer = 0

        If a = True And b = False And c = False Then
            cmd.Parameters.AddWithValue("@dateFrm", "2023-08-01")
            cmd.Parameters.AddWithValue("@dateTo", "2023-08-15")
            days = 1
        ElseIf b = True And a = False And c = False Then
            cmd.Parameters.AddWithValue("@dateFrm", "2023-08-16")
            cmd.Parameters.AddWithValue("@dateTo", "2023-08-31")
            days = 16
        ElseIf b = False And a = False And c = True Then
            cmd.Parameters.AddWithValue("@dateFrm", "2023-08-01")
            cmd.Parameters.AddWithValue("@dateTo", "2023-08-31")
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
                                Dim items As New ListViewItem
                                items.Text = days.ToString
                                items.SubItems.Add(dr(1).ToString)
                                items.SubItems.Add(dr(2).ToString)
                                items.SubItems.Add(dr(3).ToString)
                                items.SubItems.Add(dr(4).ToString)
                                items.SubItems.Add("")
                                items.SubItems.Add("")
                                items.SubItems.Add("")
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
                If dr.HasRows Then
                    While dr.Read()
                        Dim items As New ListViewItem
                        items.Text = days.ToString
                        items.SubItems.Add(dr(1).ToString)
                        items.SubItems.Add(dr(2).ToString)
                        items.SubItems.Add(dr(3).ToString)
                        items.SubItems.Add(dr(4).ToString)
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        DTRMain.ListView1.View = View.Details
                        DTRMain.ListView1.Items.Add(items)
                        days += 1
                    End While
                Else
                    Exit Sub
                End If
            ElseIf days = 1 And c = True Then
                If dr.HasRows Then
                    While dr.Read()
                        Dim items As New ListViewItem
                        items.Text = days.ToString
                        items.SubItems.Add(dr(1).ToString)
                        items.SubItems.Add(dr(2).ToString)
                        items.SubItems.Add(dr(3).ToString)
                        items.SubItems.Add(dr(4).ToString)
                        items.SubItems.Add("")
                        items.SubItems.Add("")
                        items.SubItems.Add("")
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

    Public Sub DBUpdater(OldID As Integer, NewID As Integer, hr_employee As Boolean, hr_biometrics As Boolean)

        Dim i As Integer
        Dim query As String
        connection()
        If hr_employee = True Then
            query = "SET FOREIGN_KEY_CHECKS = 0; UPDATE hr_employee SET id=@OldID WHERE id=@NewID"
            cmd = New MySqlCommand(query, conn)

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
            query = "SET FOREIGN_KEY_CHECKS = 0; UPDATE hr_biotemplate SET employee_id='" & OldID & "' WHERE employee_id='" & NewID & "'"

            cmd = New MySqlCommand(query, conn)
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
    Public Sub updateMonth()
        Dim day As Integer = Convert.ToInt32(DTRMain.dtp_from.Value.ToString("dd"))
        Dim dayTo As Integer = Convert.ToInt32(DTRMain.dtp_to.Value.ToString("dd"))
        If DTRMain.RadioButton1.Checked = True Then
            DTRMain.lblMonth.Text = DTRMain.dtp_from.Value.ToString("MMMM").ToUpper & " 1 - 15 , " & DTRMain.dtp_from.Value.ToString("yyyy").ToUpper
        ElseIf DTRMain.RadioButton3.Checked = True Then
            DTRMain.lblMonth.Text = DTRMain.dtp_from.Value.ToString("MMMM yyyy").ToUpper
        ElseIf DTRMain.RadioButton2.Checked = True Then
            DTRMain.lblMonth.Text = DTRMain.dtp_from.Value.ToString("MMMM").ToUpper & " 16 - 30 , " & DTRMain.dtp_from.Value.ToString("yyyy").ToUpper
        End If
    End Sub

End Module

