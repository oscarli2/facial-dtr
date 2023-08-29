Imports System.DirectoryServices.AccountManagement
Public Class updateProg
    Dim currentADUser As UserPrincipal
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        currentADUser = UserPrincipal.Current
        MsgBox("Closing application for the installation of Updates..")
        Process.Start("cmd", "/c start C:\Users\" & currentADUser.ToString & "\Downloads\DILGDTRSetup.msi")
        Form1.Close()
    End Sub

    Private Sub updateProg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
    End Sub

    Private Sub Label1_TextChanged(sender As Object, e As EventArgs) Handles Label1.TextChanged
        If Label1.Text = "100% out of 100%" Then
            Label1.ForeColor = Color.Green
            ProgressBar1.ForeColor = Color.Green
        End If
    End Sub
End Class