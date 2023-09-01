Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class SearchEmp

    Private Sub txtEmployee_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmployee.KeyPress
        'prevent numbers or symbols to be accepted
        If Not (Asc(e.KeyChar) = 8) Then
            If Not Char.IsLetterOrDigit(e.KeyChar) And e.KeyChar <> Chr(9) And e.KeyChar <> Chr(13) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtEmployee_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployee.KeyDown
        If e.KeyCode = Keys.Enter Then
            searchEmployee(txtEmployee.Text)
        End If
    End Sub

    Private Sub SearchEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'initialize columns
        lv_employees.Columns.Add("ID", 100)
        lv_employees.Columns.Add("Emp_ID", 100)
        lv_employees.Columns.Add("First Name", 250)
        lv_employees.Columns.Add("Last Name", 250)
    End Sub
    Private Sub lv_employees_DoubleClick(sender As Object, e As EventArgs) Handles lv_employees.DoubleClick
        'initialize columns in DTRMain Form
        DTRMain.ListView1.Columns.Add("Day", CStr(50), HorizontalAlignment.Center)
        DTRMain.ListView1.Columns.Add("Arrive", CStr(80), HorizontalAlignment.Center)
        DTRMain.ListView1.Columns.Add("Depart", CStr(80), HorizontalAlignment.Center)
        DTRMain.ListView1.Columns.Add("Arrive", CStr(80), HorizontalAlignment.Center)
        DTRMain.ListView1.Columns.Add("Depart", CStr(80), HorizontalAlignment.Center)
        DTRMain.ListView1.Columns.Add("Hours", CStr(30), HorizontalAlignment.Center)
        DTRMain.ListView1.Columns.Add("Minutes", CStr(50), HorizontalAlignment.Center)

        With DTRMain
            .emp_id.Text = lv_employees.SelectedItems(0).Text
            .txtEmployee.Text = lv_employees.SelectedItems(0).SubItems(2).Text & " " & lv_employees.SelectedItems(0).SubItems(3).Text
            .txtEmpName.Text = lv_employees.SelectedItems(0).SubItems(2).Text & " " & lv_employees.SelectedItems(0).SubItems(3).Text

            Dim BoldFont As Font = New Font(.ListView1.Font.FontFamily, .ListView1.Font.Size, FontStyle.Bold)
            For i As Integer = 0 To .ListView1.Items.Count - 1
                .ListView1.Items(i).UseItemStyleForSubItems = False
                .ListView1.Items(i).Font = BoldFont
                .ListView1.Items(i).BackColor = Color.LightGray
            Next
        End With

        With AllData
            .emp_id.Text = lv_employees.SelectedItems(0).Text
            .txtEmployee.Text = lv_employees.SelectedItems(0).SubItems(2).Text & " " & lv_employees.SelectedItems(0).SubItems(3).Text
        End With

        Me.Close()
    End Sub
End Class