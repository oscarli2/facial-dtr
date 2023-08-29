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

        If txtEmployee.Text = "CLICK TO SEARCH" Then
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim h As Integer = 0
        Dim bm As New Bitmap(Me.Panel1.Width, Me.Panel1.Height + 10)
        Panel1.DrawToBitmap(bm, New Rectangle(15, 15, Me.Panel1.Width, Me.Panel1.Height))
        e.Graphics.DrawImage(bm, 0, 0)
        h += 104
        e.Graphics.DrawString("________________________________________", New Font("Arial", 10), Brushes.Black, 120, h)
        h += 846
        e.Graphics.DrawString("______________________________", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, 50, h)
        h += 100
        e.Graphics.DrawString("______________________________", New Font("Arial", 20, FontStyle.Bold), Brushes.Black, 50, h)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PageSetupDialog1.Document = PrintDocument1
        PageSetupDialog1.Document.DefaultPageSettings.Color = True
        PageSetupDialog1.Document.DefaultPageSettings.PaperSize = New PaperSize("A4", 830, 1170)
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

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        Dim request As HttpWebRequest = HttpWebRequest.Create("https://www.dropbox.com/scl/fi/h4vw7a3acgvmlw7zb5cj8/updatenum.txt?rlkey=rlvdu4hrzuosjl1j6h89jf7i3&dl=1")
        Dim response As HttpWebResponse = request.GetResponse()
        Dim sr As IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
        Dim newestversion As String = sr.ReadToEnd()
        Dim currentversion As String = Application.ProductVersion

        If newestversion.Contains(currentversion) Then
            'Do nothing
            MsgBox("System is up to date.." + Application.ProductVersion.ToString)
        Else
            If MsgBox("New Version Available. Do you want to update now?", MsgBoxStyle.YesNo, "Close Window") = MsgBoxResult.Yes Then
                getUpdate()
            End If
        End If
    End Sub
    Dim wc As WebClient
    Public Sub getUpdate()
        Dim currADUser As UserPrincipal
        currADUser = UserPrincipal.Current

        wc = New WebClient()

        If IO.File.Exists("C:\Users\" & currADUser.ToString & "\Downloads\DILG DTR Setup.msi") Then
            IO.File.Delete("C:\Users\" & currADUser.ToString & "\Downloads\DILG DTR Setup.msi")
            wc.DownloadFileAsync(New Uri("https://www.dropbox.com/scl/fi/y4jqtf7pe6262g1txa8wj/DILG-DTR-Setup.msi?rlkey=t6kty6m3w7v6kwtkataila8xs&dl=1"), "C:\Users\" & currADUser.ToString & "\Downloads\DILG DTR Setup.msi")
        Else
            wc.DownloadFileAsync(New Uri("https://www.dropbox.com/scl/fi/y4jqtf7pe6262g1txa8wj/DILG-DTR-Setup.msi?rlkey=t6kty6m3w7v6kwtkataila8xs&dl=1"), "C:\Users\" & currADUser.ToString & "\Downloads\DILG DTR Setup.msi")
        End If
        MsgBox("Closing application for installation of updates..")
        Process.Start("C:\Users\" & currADUser.ToString & "\Downloads\DILG DTR Setup.msi")
        Me.Close()
    End Sub
End Class
