Imports System.DirectoryServices.AccountManagement

Public Class Form1
    Dim directoryPath As String = My.Application.Info.DirectoryPath
    Dim wClient As New System.Net.WebClient
    Dim tool As String = directoryPath + "\DILG DTR Reports.exe"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim currADUser As UserPrincipal
        currADUser = UserPrincipal.Current
        MsgBox("Closing application for installation of updates..")
        Process.Start("C:\Users\" & currADUser.ToString & "\Downloads\DILG DTR Setup.msi")
        Me.Close()
    End Sub
End Class
