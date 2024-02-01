Imports System.ComponentModel
Imports System.DirectoryServices.AccountManagement
Imports System.Drawing.Printing
Imports System.Net
Public Class Form1
    Private ctlMDI As MdiClient
    Private colorConv As New ColorConverter
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ctl As Control
        ' Loop through all of the form's controls looking
        ' for the control of type MdiClient.

        For Each ctl In Me.Controls
            Try
                ' Attempt to cast the control to type MdiClient.
                ctlMDI = CType(ctl, MdiClient)

                ' Set the BackColor of the MdiClient control.
                Me.BackgroundImageLayout = ImageLayout.Zoom
                ctlMDI.BackColor = Color.White
                'ctlMDI.BackgroundImage = My.Resources.eplogo
                Timer1.Start()
            Catch exc As InvalidCastException
                ' Catch and ignore the error if casting failed.
            End Try
        Next
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        DTRMain.MdiParent = Me
        DTRMain.Show()
    End Sub
    Public Sub getUpdate()
        Dim wc As WebClient
        Dim currentADUser As UserPrincipal
        currentADUser = UserPrincipal.Current
        wc = New WebClient()

        AddHandler wc.DownloadProgressChanged, AddressOf OnDownloadProgressChanged
        AddHandler wc.DownloadFileCompleted, AddressOf OnFileDownloadCompleted
        If IO.File.Exists("C:\Users\" & currentADUser.ToString & "\Downloads\DILGDTRSetup.msi") Then
            IO.File.Delete("C:\Users\" & currentADUser.ToString & "\Downloads\DILGDTRSetup.msi")
            wc.DownloadFileAsync(New Uri("https://www.dropbox.com/scl/fi/51qmp8z01emqew466j2uh/DILGDTRSetup.msi?rlkey=2rjp88hwq0ns96y5zucm1kwgn&dl=1"), "C:\Users\" & currentADUser.ToString & "\Downloads\DILGDTRSetup.msi")
        Else
            wc.DownloadFileAsync(New Uri("https://www.dropbox.com/scl/fi/51qmp8z01emqew466j2uh/DILGDTRSetup.msi?rlkey=2rjp88hwq0ns96y5zucm1kwgn&dl=1"), "C:\Users\" & currentADUser.ToString & "\Downloads\DILGDTRSetup.msi")
        End If

    End Sub

    Private Sub OnFileDownloadCompleted(sender As Object, e As AsyncCompletedEventArgs)
        If e.Cancelled Then
            'Cancelled
        ElseIf Not e.Error Is Nothing Then
            'Error occured
            MsgBox(e.Error)
        Else
            'File Downloaded Successfuly
            updateProg.Button1.Enabled = True
        End If
    End Sub

    Private Sub OnDownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        Dim totalSize As Long = e.TotalBytesToReceive
        Dim downloadedBytes As Long = e.BytesReceived
        Dim percentage As Integer = e.ProgressPercentage
        updateProg.ProgressBar1.Value = percentage
        updateProg.Label1.Text = percentage.ToString & "% out of 100%"
        updateProg.Show()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        DTRMain.PageSetupDialog1.Document = DTRMain.PrintDocument1
        DTRMain.PageSetupDialog1.Document.DefaultPageSettings.Color = False
        DTRMain.PageSetupDialog1.Document.DefaultPageSettings.PaperSize = New PaperSize("A4", 830, 1170)
        DTRMain.PageSetupDialog1.Document.DefaultPageSettings.Margins = New Margins(0.1, 0.1, 0.1, 0.1)
        DTRMain.PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        LoginForm1.Show()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        AllData.MdiParent = Me
        AllData.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'checkTotalEmpIn()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        ToolStripLabel1.Text = "Total Login as of " & DateTime.Now & ":"
    End Sub

    Private Sub lbl_empInCount_Click(sender As Object, e As EventArgs) Handles lbl_empInCount.Click
        'LoggedIn.MdiParent = Me
        'LoggedIn.Show()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            If ToolStripStatusLabel1.Tag = "admin" Then
                Database_Updater.MdiParent = Me
                Database_Updater.Show()
            End If
        End If
    End Sub
End Class