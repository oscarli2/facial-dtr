<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class LoginForm1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub
    Friend WithEvents LogoPictureBox As PictureBox
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents PasswordLabel As Label
    Friend WithEvents UsernameTextBox As TextBox
    Friend WithEvents PasswordTextBox As TextBox
    Friend WithEvents OK As Button
    Friend WithEvents Cancel As Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        LogoPictureBox = New PictureBox()
        UsernameLabel = New Label()
        PasswordLabel = New Label()
        UsernameTextBox = New TextBox()
        PasswordTextBox = New TextBox()
        OK = New Button()
        Cancel = New Button()
        LinkLabel1 = New LinkLabel()
        RadioButton1 = New RadioButton()
        RadioButton2 = New RadioButton()
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LogoPictureBox
        ' 
        LogoPictureBox.BackgroundImageLayout = ImageLayout.Center
        LogoPictureBox.Image = My.Resources.Resources.pngaaa_com_4194622
        LogoPictureBox.Location = New Point(12, 9)
        LogoPictureBox.Name = "LogoPictureBox"
        LogoPictureBox.Size = New Size(170, 194)
        LogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom
        LogoPictureBox.TabIndex = 0
        LogoPictureBox.TabStop = False
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Location = New Point(198, 7)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(220, 23)
        UsernameLabel.TabIndex = 0
        UsernameLabel.Text = "&User name"
        UsernameLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PasswordLabel
        ' 
        PasswordLabel.Location = New Point(198, 63)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New Size(220, 23)
        PasswordLabel.TabIndex = 2
        PasswordLabel.Text = "&Password"
        PasswordLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' UsernameTextBox
        ' 
        UsernameTextBox.Location = New Point(197, 27)
        UsernameTextBox.Name = "UsernameTextBox"
        UsernameTextBox.Size = New Size(213, 23)
        UsernameTextBox.TabIndex = 1
        ' 
        ' PasswordTextBox
        ' 
        PasswordTextBox.Location = New Point(197, 84)
        PasswordTextBox.Name = "PasswordTextBox"
        PasswordTextBox.PasswordChar = "*"c
        PasswordTextBox.Size = New Size(213, 23)
        PasswordTextBox.TabIndex = 2
        ' 
        ' OK
        ' 
        OK.Location = New Point(206, 176)
        OK.Name = "OK"
        OK.Size = New Size(94, 23)
        OK.TabIndex = 6
        OK.Text = "&OK"
        ' 
        ' Cancel
        ' 
        Cancel.DialogResult = DialogResult.Cancel
        Cancel.Location = New Point(309, 176)
        Cancel.Name = "Cancel"
        Cancel.Size = New Size(94, 23)
        Cancel.TabIndex = 7
        Cancel.Text = "&Cancel"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Location = New Point(267, 148)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(84, 15)
        LinkLabel1.TabIndex = 5
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "Login as Guest"
        ' 
        ' RadioButton1
        ' 
        RadioButton1.AutoSize = True
        RadioButton1.Location = New Point(199, 120)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New Size(103, 19)
        RadioButton1.TabIndex = 3
        RadioButton1.TabStop = True
        RadioButton1.Text = "Old Biometrics"
        RadioButton1.UseVisualStyleBackColor = True
        ' 
        ' RadioButton2
        ' 
        RadioButton2.AutoSize = True
        RadioButton2.Location = New Point(305, 120)
        RadioButton2.Name = "RadioButton2"
        RadioButton2.Size = New Size(108, 19)
        RadioButton2.TabIndex = 4
        RadioButton2.TabStop = True
        RadioButton2.Text = "New Biometrics"
        RadioButton2.UseVisualStyleBackColor = True
        ' 
        ' LoginForm1
        ' 
        AcceptButton = OK
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = Cancel
        ClientSize = New Size(433, 223)
        Controls.Add(RadioButton2)
        Controls.Add(RadioButton1)
        Controls.Add(LinkLabel1)
        Controls.Add(Cancel)
        Controls.Add(OK)
        Controls.Add(PasswordTextBox)
        Controls.Add(UsernameTextBox)
        Controls.Add(PasswordLabel)
        Controls.Add(UsernameLabel)
        Controls.Add(LogoPictureBox)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "LoginForm1"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        CType(LogoPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
End Class
