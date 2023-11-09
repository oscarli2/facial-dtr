Imports System.Security.Cryptography

Public Class Database_Updater
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True And RadioButton2.Checked = True Then
            DBUpdater(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox11.Text), True, True)
            DBUpdater(Convert.ToInt32(TextBox2.Text), Convert.ToInt32(TextBox12.Text), True, True)
            DBUpdater(Convert.ToInt32(TextBox3.Text), Convert.ToInt32(TextBox13.Text), True, True)
            DBUpdater(Convert.ToInt32(TextBox4.Text), Convert.ToInt32(TextBox14.Text), True, True)
            DBUpdater(Convert.ToInt32(TextBox5.Text), Convert.ToInt32(TextBox15.Text), True, True)
            DBUpdater(Convert.ToInt32(TextBox6.Text), Convert.ToInt32(TextBox16.Text), True, True)
            DBUpdater(Convert.ToInt32(TextBox7.Text), Convert.ToInt32(TextBox17.Text), True, True)
            DBUpdater(Convert.ToInt32(TextBox8.Text), Convert.ToInt32(TextBox18.Text), True, True)
            DBUpdater(Convert.ToInt32(TextBox9.Text), Convert.ToInt32(TextBox19.Text), True, True)
            DBUpdater(Convert.ToInt32(TextBox10.Text), Convert.ToInt32(TextBox20.Text), True, True)
        ElseIf RadioButton1.Checked = True And RadioButton2.Checked = False Then
            DBUpdater(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox11.Text), True, False)
            DBUpdater(Convert.ToInt32(TextBox2.Text), Convert.ToInt32(TextBox12.Text), True, False)
            DBUpdater(Convert.ToInt32(TextBox3.Text), Convert.ToInt32(TextBox13.Text), True, False)
            DBUpdater(Convert.ToInt32(TextBox4.Text), Convert.ToInt32(TextBox14.Text), True, False)
            DBUpdater(Convert.ToInt32(TextBox5.Text), Convert.ToInt32(TextBox15.Text), True, False)
            DBUpdater(Convert.ToInt32(TextBox6.Text), Convert.ToInt32(TextBox16.Text), True, False)
            DBUpdater(Convert.ToInt32(TextBox7.Text), Convert.ToInt32(TextBox17.Text), True, False)
            DBUpdater(Convert.ToInt32(TextBox8.Text), Convert.ToInt32(TextBox18.Text), True, False)
            DBUpdater(Convert.ToInt32(TextBox9.Text), Convert.ToInt32(TextBox19.Text), True, False)
            DBUpdater(Convert.ToInt32(TextBox10.Text), Convert.ToInt32(TextBox20.Text), True, False)
        Else
            DBUpdater(Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox11.Text), False, True)
            DBUpdater(Convert.ToInt32(TextBox2.Text), Convert.ToInt32(TextBox12.Text), False, True)
            DBUpdater(Convert.ToInt32(TextBox3.Text), Convert.ToInt32(TextBox13.Text), False, True)
            DBUpdater(Convert.ToInt32(TextBox4.Text), Convert.ToInt32(TextBox14.Text), False, True)
            DBUpdater(Convert.ToInt32(TextBox5.Text), Convert.ToInt32(TextBox15.Text), False, True)
            DBUpdater(Convert.ToInt32(TextBox6.Text), Convert.ToInt32(TextBox16.Text), False, True)
            DBUpdater(Convert.ToInt32(TextBox7.Text), Convert.ToInt32(TextBox17.Text), False, True)
            DBUpdater(Convert.ToInt32(TextBox8.Text), Convert.ToInt32(TextBox18.Text), False, True)
            DBUpdater(Convert.ToInt32(TextBox9.Text), Convert.ToInt32(TextBox19.Text), False, True)
            DBUpdater(Convert.ToInt32(TextBox10.Text), Convert.ToInt32(TextBox20.Text), False, True)
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each txt As Control In Me.GroupBox2.Controls.OfType(Of TextBox)()
            txt.Text = ""
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub txtEmployee_Click(sender As Object, e As EventArgs) Handles txtEmployee.Click

    End Sub
End Class