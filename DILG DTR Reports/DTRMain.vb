Imports System.Drawing.Printing
Imports System.DirectoryServices.AccountManagement
Imports System.Net.Http
Imports Mysqlx.XDevAPI
Imports Mysqlx.XDevAPI.Relational
Imports System.Net
Imports System.ComponentModel

Public Class DTRMain
    Dim dateFrmTo As String = ""
    Dim ifDTPChanged As Boolean = False
    Dim directoryPath As String = My.Application.Info.DirectoryPath
    Dim wClient As New System.Net.WebClient
    Dim tool As String = directoryPath + "\DILG DTR Reports.exe"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtEmployee.Text = "CLICK HERE TO SEARCH" Then
            MsgBox("Please select an employee")
        ElseIf ifDTPChanged = False Then
            MsgBox("Please change your FROM Date!")
        Else
            If RadioButton1.Checked = True And RadioButton2.Checked = False And RadioButton3.Checked = False Then
                searchDTR(Convert.ToInt32(emp_id.Text), True, False, False)
            ElseIf RadioButton2.Checked = True And RadioButton1.Checked = False And RadioButton3.Checked = False Then
                searchDTR(Convert.ToInt32(emp_id.Text), False, True, False)
            ElseIf RadioButton3.Checked = True And RadioButton2.Checked = False And RadioButton1.Checked = False Then
                searchDTR(Convert.ToInt32(emp_id.Text), False, False, True)
            End If
        End If
    End Sub

    Private Sub DTRMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtp_from.Value = Date.Now
        dtp_to.Value = Date.Now

        ListView1.Columns.Add("Day", CStr(50), HorizontalAlignment.Center)
        ListView1.Columns.Add("Arrive", CStr(80), HorizontalAlignment.Center)
        ListView1.Columns.Add("Depart", CStr(80), HorizontalAlignment.Center)
        ListView1.Columns.Add("Arrive", CStr(80), HorizontalAlignment.Center)
        ListView1.Columns.Add("Depart", CStr(80), HorizontalAlignment.Center)
        ListView1.Columns.Add("Hours", CStr(30), HorizontalAlignment.Center)
        ListView1.Columns.Add("Minutes", CStr(50), HorizontalAlignment.Center)

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


    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim h As Integer = 0
        Dim bm As New Bitmap(Me.Panel1.Width + 2, Me.Panel1.Height + 10)
        Panel1.DrawToBitmap(bm, New Rectangle(15, 15, Me.Panel1.Width + 2, Me.Panel1.Height))
        e.Graphics.DrawImage(bm, 0, 0)
        h += 104
        e.Graphics.DrawString("________________________________________", New Font("Arial", 10), Brushes.Black, 120, h)
        h += 780
        e.Graphics.DrawString("______________________________", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, 50, h)
        h += 105
        e.Graphics.DrawString("______________________________", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, 50, h)
    End Sub

    Private Sub txtEmployee_Click(sender As Object, e As EventArgs) Handles txtEmployee.Click
        SearchEmp.ShowDialog()
    End Sub

    Private Sub DTRMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            Database_Updater.Show()
        End If
    End Sub

    Private Sub dtp_from_ValueChanged(sender As Object, e As EventArgs) Handles dtp_from.ValueChanged
        ifDTPChanged = True
        updateMonth()
    End Sub

    Private Sub dtp_to_ValueChanged(sender As Object, e As EventArgs) Handles dtp_to.ValueChanged
        updateMonth()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        ifDTPChanged = True
        updateMonth()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        updateMonth()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        updateMonth()
    End Sub

End Class
