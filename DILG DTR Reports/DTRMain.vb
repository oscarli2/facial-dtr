Imports Mysqlx.XDevAPI.Relational

Public Class DTRMain
    Dim dateFrmTo As String = ""
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtEmployee.Text = "" Then
            MsgBox("Please select an employee")
        ElseIf dtp_from.Value.Date = dtp_to.Value.Date Then
            MsgBox("Please select a range of dates!")
        Else
            searchDTR(Convert.ToInt32(emp_id.Text), dtp_from.Value, dtp_to.Value)
        End If
    End Sub

    Private Sub DTRMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtp_from.Value = Date.Now
        dtp_to.Value = Date.Now

        ListView1.Columns.Add("Day", 50, HorizontalAlignment.Center)
        ListView1.Columns.Add("Arrive(AM)", 80, HorizontalAlignment.Center)
        ListView1.Columns.Add("Depart(AM)", 80, HorizontalAlignment.Center)
        ListView1.Columns.Add("Arrive(PM", 80, HorizontalAlignment.Center)
        ListView1.Columns.Add("Depart(PM)", 80, HorizontalAlignment.Center)
        ListView1.Columns.Add("Hours", 30, HorizontalAlignment.Center)
        ListView1.Columns.Add("Minutes", 50, HorizontalAlignment.Center)

        Dim days As Integer = 0
        While days < 31
            days += 1
            Dim items As New ListViewItem
            items.Text = "     " & days.ToString
            items.SubItems.Add("")
            items.SubItems.Add("")
            items.SubItems.Add("")
            items.SubItems.Add("")
            items.SubItems.Add("")
            items.SubItems.Add("")
            items.SubItems.Add("")
            ListView1.View = View.Details
            ListView1.Items.Add(items)
        End While
        Dim BoldFont As Font = New Font(ListView1.Font.FontFamily, ListView1.Font.Size, FontStyle.Bold)
        For i As Integer = 0 To ListView1.Items.Count - 1
            ListView1.Items(i).UseItemStyleForSubItems = False
            ListView1.Items(i).Font = BoldFont
            ListView1.Items(i).BackColor = Color.LightGray
        Next
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dtp_from.ValueChanged
        Dim day As Integer = Convert.ToInt32(dtp_from.Value.ToString("dd"))
        If day <= 15 Then
            lblMonth.Text = dtp_from.Value.ToString("MMMM").ToUpper & " 1 - 15 , " & dtp_from.Value.ToString("yyyy").ToUpper
        Else
            lblMonth.Text = dtp_from.Value.ToString("MMMM").ToUpper & " 16 - 30 , " & dtp_from.Value.ToString("yyyy").ToUpper
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim h As Integer = 0
        Dim bm As New Bitmap(Me.Panel1.Width, Me.Panel1.Height + 10)
        Panel1.DrawToBitmap(bm, New Rectangle(15, 15, Me.Panel1.Width, Me.Panel1.Height))
        e.Graphics.DrawImage(bm, 0, 0)
        h += 105
        e.Graphics.DrawString("________________________________________", New Font("Arial", 10), Brushes.Black, 120, h)
        h += 844
        e.Graphics.DrawString("______________________________", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, 50, h)
        h += 102
        e.Graphics.DrawString("______________________________", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, 50, h)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PageSetupDialog1.Document = PrintDocument1
        PageSetupDialog1.Document.DefaultPageSettings.Color = False
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub txtEmployee_Click(sender As Object, e As EventArgs) Handles txtEmployee.Click
        SearchEmp.ShowDialog()
    End Sub

    Private Sub DTRMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            Database_Updater.Show()
        End If
    End Sub
End Class
