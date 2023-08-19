Imports System.Security.Cryptography

Public Class Database_Updater
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DBUpdater(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox11.Text))
        DBUpdater(Convert.ToInt32(TextBox2.Text), Convert.ToInt32(TextBox12.Text))
        DBUpdater(Convert.ToInt32(TextBox3.Text), Convert.ToInt32(TextBox13.Text))
        DBUpdater(Convert.ToInt32(TextBox4.Text), Convert.ToInt32(TextBox14.Text))
        DBUpdater(Convert.ToInt32(TextBox5.Text), Convert.ToInt32(TextBox15.Text))
        DBUpdater(Convert.ToInt32(TextBox6.Text), Convert.ToInt32(TextBox16.Text))
        DBUpdater(Convert.ToInt32(TextBox7.Text), Convert.ToInt32(TextBox17.Text))
        DBUpdater(Convert.ToInt32(TextBox8.Text), Convert.ToInt32(TextBox18.Text))
        DBUpdater(Convert.ToInt32(TextBox9.Text), Convert.ToInt32(TextBox19.Text))
        DBUpdater(Convert.ToInt32(TextBox10.Text), Convert.ToInt32(TextBox20.Text))

    End Sub
End Class