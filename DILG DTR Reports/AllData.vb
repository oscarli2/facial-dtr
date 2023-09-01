Public Class AllData
    Dim dtpFrChanged = False
    Dim dtpToChanged = False
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtEmployee.Text = "CLICK HERE TO SEARCH" Then
            MsgBox("Select an Employee!")
        ElseIf dtpFrChanged = False Then
            MsgBox("Please change your FROM DATE")
        ElseIf dtpToChanged = False Then
            MsgBox("Please change your TO DATE")
        Else
            searchDTRAll(Convert.ToInt32(emp_id.Text), dtp_from.Value, dtp_to.Value)
        End If
    End Sub

    Private Sub dtp_from_ValueChanged(sender As Object, e As EventArgs) Handles dtp_from.ValueChanged
        dtpFrChanged = True
    End Sub

    Private Sub dtp_to_ValueChanged(sender As Object, e As EventArgs) Handles dtp_to.ValueChanged
        dtpToChanged = True
    End Sub

    Private Sub txtEmployee_Click(sender As Object, e As EventArgs) Handles txtEmployee.Click
        SearchEmp.ShowDialog()
    End Sub
End Class