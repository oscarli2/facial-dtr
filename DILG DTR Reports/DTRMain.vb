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
    Dim wClient As New WebClient
    Dim tool As String = directoryPath + "\DILG DTR Reports.exe"
    Dim itemIndex As Integer = 0
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If txtEmployee.Text = "CLICK HERE TO SEARCH" Then
            MsgBox("Please select an employee")
        ElseIf ComboBox1.Text = "" Then
            MsgBox("Please select a month or range of dates!")
        Else
            Dim month As String
            If ComboBox1.Text = "JANUARY" Then
                month = "01"
                dayCount = "31"
            ElseIf ComboBox1.Text = "FEBRUARY" Then
                month = "02"
                dayCount = "30"
            ElseIf ComboBox1.Text = "MARCH" Then
                month = "03"
                dayCount = "31"
            ElseIf ComboBox1.Text = "APRIL" Then
                month = "04"
                dayCount = "30"
            ElseIf ComboBox1.Text = "MAY" Then
                month = "05"
                dayCount = "31"
            ElseIf ComboBox1.Text = "JUNE" Then
                month = "06"
                dayCount = "30"
            ElseIf ComboBox1.Text = "JULY" Then
                month = "07"
                dayCount = "31"
            ElseIf ComboBox1.Text = "AUGUST" Then
                month = "08"
                dayCount = "31"
            ElseIf ComboBox1.Text = "SEPTEMBER" Then
                month = "09"
                dayCount = "30"
            ElseIf ComboBox1.Text = "OCTOBER" Then
                month = "10"
                dayCount = "31"
            ElseIf ComboBox1.Text = "NOVEMBER" Then
                month = "11"
                dayCount = "30"
            ElseIf ComboBox1.Text = "DECEMBER" Then
                month = "12"
                dayCount = "31"
            End If
            Dim isSecurity As Boolean = False

            If CheckBox1.Checked = True Then
                isSecurity = True
            Else
                isSecurity = False
            End If
            If cb_weekends.Checked = True Then
                DG_SearchWeekends(Convert.ToInt32(emp_id.Text), True, False, False, month, cbYear.Text, isSecurity)
            ElseIf RadioButton1.Checked = True And RadioButton2.Checked = False And RadioButton3.Checked = False Then
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
        isActive = False
        Panel2.Visible = False
        RadioButton1.Enabled = False
        RadioButton2.Enabled = False
        RadioButton3.Enabled = True
        Form1.ToolStripButton3.Enabled = True

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

    Private Sub DTRMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.ToolStripButton3.Enabled = False
    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Panel2.Visible = False
        txt_ArivalAM.Text = ""
        txt_ArrivalPM.Text = ""
        txt_DepAM.Text = ""
        txt_DepPM.Text = ""
    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        If ListView1.SelectedItems.Item(0).SubItems(1).Text <> "" Or ListView1.SelectedItems.Item(0).SubItems(2).Text <> "" Or ListView1.SelectedItems.Item(0).SubItems(3).Text <> "" Or ListView1.SelectedItems.Item(0).SubItems(4).Text <> "" Then
            Panel2.Visible = True
            txt_ArivalAM.Text = ListView1.FocusedItem.SubItems(1).Text
            txt_DepAM.Text = ListView1.FocusedItem.SubItems(2).Text
            txt_ArrivalPM.Text = ListView1.FocusedItem.SubItems(3).Text
            txt_DepPM.Text = ListView1.FocusedItem.SubItems(4).Text
            lbl_index.Text = ListView1.FocusedItem.Index
            itemIndex = ListView1.FocusedItem.Index
        Else
            MsgBox("No data in selected date!")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel2.Visible = False
        ListView1.Items(itemIndex).SubItems(1).Text = txt_ArivalAM.Text
        ListView1.Items(itemIndex).SubItems(2).Text = txt_DepAM.Text
        ListView1.Items(itemIndex).SubItems(3).Text = txt_ArrivalPM.Text
        ListView1.Items(itemIndex).SubItems(4).Text = txt_DepPM.Text
    End Sub
End Class
