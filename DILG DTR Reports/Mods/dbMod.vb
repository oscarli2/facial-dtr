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

    Public Sub searchDTR(emp_id As Integer, dtrDatefrm As Date, dtrDateTo As Date)

        Dim query As String
        query = "
            SELECT CAST(punch_time AS DATE) punch_date, DAY(punch_time) punch_day
            , MAX(CASE WHEN workstate = 0 AND employee_id = @emp_id AND TIME(punch_time) BETWEEN '05:00:00' AND '11:59:00' THEN TIME(punch_time) END) as ArrivalAM 
            , MAX(CASE WHEN workstate = 1 AND employee_id = @emp_id AND TIME(punch_time) BETWEEN '12:00:00' AND '14:00:00' THEN TIME(punch_time) END) as DepartAM 
            , MAX(CASE WHEN workstate = 0 AND employee_id = @emp_id AND TIME(punch_time) BETWEEN '12:00:00' AND '14:00:00' THEN TIME(punch_time) END) as ArrivalPM 
            , MAX(CASE WHEN workstate = 1 AND employee_id = @emp_id AND TIME(punch_time) BETWEEN '13:00:00' AND '19:00:00' THEN TIME(punch_time) END) as DepartPM 
            FROM att_punches 
            GROUP BY punch_date
            HAVING punch_date BETWEEN @dateFrm AND @dateTo;
            "

        str = "Server=" & server & ";Port=" & port & ";Uid=" & user & ";Pwd=" & pass & ";Database=" & db & ";persist security info=false; SslMode=none;"
        conn = New MySqlConnection(str)
        cmd = New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@dateFrm", dtrDatefrm.AddDays(-1))
        cmd.Parameters.AddWithValue("@dateTo", dtrDateTo)
        cmd.Parameters.AddWithValue("@emp_id", emp_id)
        conn.Open()
        dr = cmd.ExecuteReader

        DTRMain.ListView1.Clear()
        DTRMain.ListView1.Columns.Add("Day", 50, HorizontalAlignment.Center)
        DTRMain.ListView1.Columns.Add("Arrive", 80, HorizontalAlignment.Center)
        DTRMain.ListView1.Columns.Add("Depart", 80, HorizontalAlignment.Center)
        DTRMain.ListView1.Columns.Add("Arrive", 80, HorizontalAlignment.Center)
        DTRMain.ListView1.Columns.Add("Depart", 80, HorizontalAlignment.Center)
        DTRMain.ListView1.Columns.Add("Hours", 30, HorizontalAlignment.Center)
        DTRMain.ListView1.Columns.Add("Minutes", 50, HorizontalAlignment.Center)

        Dim days As Integer = 1
        Dim punchday As Integer = 1
        Try
            While days <= 31
                If days = 1 Then
                    If dr.HasRows Then
                        While dr.Read()
                            punchday = Convert.ToInt32(dr(1))
                            Dim items As New ListViewItem
                            items.Text = punchday.ToString
                            items.SubItems.Add(dr(2).ToString)
                            items.SubItems.Add(dr(3).ToString)
                            items.SubItems.Add(dr(4).ToString)
                            items.SubItems.Add(dr(5).ToString)
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                            items.SubItems.Add("")
                            DTRMain.ListView1.View = View.Details
                            DTRMain.ListView1.Items.Add(items)
                            days += 1
                        End While
                    Else
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
                    punchday += 1
                End If
            End While
            With DTRMain
                Dim BoldFont As Font = New Font(.ListView1.Font.FontFamily, .ListView1.Font.Size, FontStyle.Bold)
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

    Public Sub DBUpdater(OldID As Integer, NewID As Integer)
        Dim i As Integer
        connection()
        Dim query As String
        query = "UPDATE hr_employee SET id=@OldID WHERE id=@NewID"

        cmd = New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@OldID", OldID)
        cmd.Parameters.AddWithValue("@NewID", NewID)

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

        query = "UPDATE hr_biotemplate SET id=@OldID WHERE id=@NewID"

        cmd = New MySqlCommand(query, conn)
        cmd.Parameters.AddWithValue("@OldID", OldID)
        cmd.Parameters.AddWithValue("@NewID", NewID)

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

    End Sub
End Module

