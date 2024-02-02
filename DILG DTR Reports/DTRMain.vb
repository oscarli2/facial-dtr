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
        ElseIf ComboBox1.Text = "" Then
            MsgBox("Please select a month or range of dates!")
        Else
            Dim month As String
            If ComboBox1.Text = "JANUARY" Then
                month = "01"
            ElseIf ComboBox1.Text = "FEBRUARY" Then
                month = "02"
            ElseIf ComboBox1.Text = "MARCH" Then
                month = "03"
            ElseIf ComboBox1.Text = "APRIL" Then
                month = "04"
            ElseIf ComboBox1.Text = "MAY" Then
                month = "05"
            ElseIf ComboBox1.Text = "JUNE" Then
                month = "06"
            ElseIf ComboBox1.Text = "JULY" Then
                month = "07"
            ElseIf ComboBox1.Text = "AUGUST" Then
                month = "08"
            ElseIf ComboBox1.Text = "SEPTEMBER" Then
                month = "09"
            ElseIf ComboBox1.Text = "OCTOBER" Then
                month = "10"
            ElseIf ComboBox1.Text = "NOVEMBER" Then
                month = "11"
            ElseIf ComboBox1.Text = "DECEMBER" Then
                month = "12"
            End If
            Dim isSecurity As Boolean = False

            If CheckBox1.Checked = True Then
                isSecurity = True
            Else
                isSecurity = False
            End If
            If RadioButton1.Checked = True And RadioButton2.Checked = False And RadioButton3.Checked = False Then
                DG_Search(Convert.ToInt32(emp_id.Text), True, False, False, month, cbYear.Text, isSecurity)
                'searchDTR(Convert.ToInt32(emp_id.Text), True, False, False, month, cbYear.Text, isSecurity)
            ElseIf RadioButton2.Checked = True And RadioButton1.Checked = False And RadioButton3.Checked = False Then
                DG_Search(Convert.ToInt32(emp_id.Text), False, True, False, month, cbYear.Text, isSecurity)
                'searchDTR(Convert.ToInt32(emp_id.Text), False, True, False, month, cbYear.Text, isSecurity)
            ElseIf RadioButton3.Checked = True And RadioButton2.Checked = False And RadioButton1.Checked = False Then
                DG_Search(Convert.ToInt32(emp_id.Text), False, False, True, month, cbYear.Text, isSecurity)
                'searchDTR(Convert.ToInt32(emp_id.Text), False, False, True, month, cbYear.Text, isSecurity)
            End If
        End If
    End Sub

    Private Sub DTRMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        RadioButton3.Enabled = False

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
        Panel1.DrawToBitmap(bm, New Rectangle(15, 15, Me.Panel1.Width, Me.Panel1.Height))
        e.Graphics.DrawImage(bm, 0, 0, Panel1.Width - 125, Me.Panel1.Height - 205)
        e.Graphics.DrawImage(bm, 400, 0, Panel1.Width - 125, Me.Panel1.Height - 205)
        h += 200
        e.Graphics.DrawString("______________________", New Font("Arial", 10), Brushes.Black, 110, 75)
        e.Graphics.DrawString("______________________", New Font("Arial", 10), Brushes.Black, 515, 75)
        h += 578
        e.Graphics.DrawString("_____________________", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, 30, h)
        e.Graphics.DrawString("_____________________", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, 425, h)
        h += 84
        e.Graphics.DrawString("_____________________", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, 30, h)
        e.Graphics.DrawString("_____________________", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, 425, h)
    End Sub

    Private Sub txtEmployee_Click(sender As Object, e As EventArgs) Handles txtEmployee.Click
        SearchEmp.ShowDialog()
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        updateMonth()
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        RadioButton3.Enabled = True
    End Sub

    Private Sub DTRMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            If Form1.ToolStripStatusLabel1.Tag = "admin" Then
                Database_Updater.MdiParent = Form1
                Database_Updater.Show()
            End If
        End If
    End Sub

    Private Sub cbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbYear.SelectedIndexChanged
        updateMonth()
    End Sub

End Class
