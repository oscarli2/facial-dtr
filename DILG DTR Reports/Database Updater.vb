Imports System.Security.Cryptography

Public Class Database_Updater
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        DBUpdater(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox11.Text))

    End Sub
End Class