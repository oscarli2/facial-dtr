Public Class LoginForm1

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MsgBox("Please select a biometric device!")
        ElseIf RadioButton1.Checked = True And RadioButton2.Checked = False Then 'old biometrics
            server = "26.113.153.103" '"localhost" 
            user = "root"
            pass = "CDPabina"
            db = "zkteco"
            searchLogin(UsernameTextBox.Text, PasswordTextBox.Text)
        ElseIf RadioButton1.Checked = False And RadioButton2.Checked = True Then 'new biometrics
            server = "26.113.153.103" '"localhost" 
            user = "sa"
            pass = "CDPabina"
            db = "anviz"
            searchLogin(UsernameTextBox.Text, PasswordTextBox.Text)
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If RadioButton1.Checked = False Or RadioButton2.Checked = False Then
            MsgBox("Please select a biometric device!")
        Else
            Me.Hide()
            Form1.ToolStripStatusLabel1.Text = "Welcome Guest!"
            Form1.Show()
        End If
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form1.ToolStripButton3.Enabled = False
        Form1.ToolStripButton2.Enabled = False
    End Sub
End Class
