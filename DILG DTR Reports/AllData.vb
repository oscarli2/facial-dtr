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

    Private Sub AllData_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        isActive = False
        If Application.OpenForms().OfType(Of DTRMain).Any Then
            Form1.ToolStripButton3.Enabled = True
        Else
            Form1.ToolStripButton3.Enabled = False
        End If
    End Sub

    Private Sub AllData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isActive = True
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim bm As New Bitmap(Me.Panel1.Width + 2, Me.Panel1.Height + 10)
        Panel1.DrawToBitmap(bm, New Rectangle(15, 15, Me.Panel1.Width, Me.Panel1.Height))
        e.Graphics.DrawImage(bm, 20, 20, Panel1.Width - 20, Me.Panel1.Height)
    End Sub

End Class