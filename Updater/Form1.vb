Public Class Form1
    Dim directoryPath As String = My.Application.Info.DirectoryPath
    Dim wClient As New System.Net.WebClient
    Dim tool As String = directoryPath + "\DILG DTR Reports.exe"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class
