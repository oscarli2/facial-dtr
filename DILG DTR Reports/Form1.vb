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
            wc.DownloadFileAsync(New Uri("https://www.dropbox.com/scl/fi/y4jqtf7pe6262g1txa8wj/DILG-DTR-Setup.msi?rlkey=t6kty6m3w7v6kwtkataila8xs&dl=1"), "C:\Users\" & currentADUser.ToString & "\Downloads\DILGDTRSetup.msi")
        Else
            wc.DownloadFileAsync(New Uri("https://www.dropbox.com/scl/fi/y4jqtf7pe6262g1txa8wj/DILG-DTR-Setup.msi?rlkey=t6kty6m3w7v6kwtkataila8xs&dl=1"), "C:\Users\" & currentADUser.ToString & "\Downloads\DILGDTRSetup.msi")
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
        DTRMain.PageSetupDialog1.Document.DefaultPageSettings.Color = True
        DTRMain.PageSetupDialog1.Document.DefaultPageSettings.PaperSize = New PaperSize("A4", 830, 1170)
        DTRMain.PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        Me.Close()
        LoginForm1.Show()
    End Sub
End Class