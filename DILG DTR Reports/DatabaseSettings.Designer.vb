<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DatabaseSettings
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        txt_ServerIP = New TextBox()
        txt_port = New TextBox()
        txt_user = New TextBox()
        txt_pass = New TextBox()
        txt_dbName = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        PictureBox1 = New PictureBox()
        Label6 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txt_ServerIP
        ' 
        txt_ServerIP.Location = New Point(21, 109)
        txt_ServerIP.Name = "txt_ServerIP"
        txt_ServerIP.Size = New Size(154, 23)
        txt_ServerIP.TabIndex = 0
        ' 
        ' txt_port
        ' 
        txt_port.Location = New Point(181, 109)
        txt_port.Name = "txt_port"
        txt_port.Size = New Size(76, 23)
        txt_port.TabIndex = 1
        ' 
        ' txt_user
        ' 
        txt_user.Location = New Point(21, 167)
        txt_user.Name = "txt_user"
        txt_user.Size = New Size(91, 23)
        txt_user.TabIndex = 2
        ' 
        ' txt_pass
        ' 
        txt_pass.Location = New Point(118, 167)
        txt_pass.Name = "txt_pass"
        txt_pass.PasswordChar = "•"c
        txt_pass.Size = New Size(139, 23)
        txt_pass.TabIndex = 3
        ' 
        ' txt_dbName
        ' 
        txt_dbName.Location = New Point(22, 225)
        txt_dbName.Name = "txt_dbName"
        txt_dbName.Size = New Size(236, 23)
        txt_dbName.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(21, 87)
        Label1.Name = "Label1"
        Label1.Size = New Size(52, 15)
        Label1.TabIndex = 5
        Label1.Text = "Server IP"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(181, 87)
        Label2.Name = "Label2"
        Label2.Size = New Size(29, 15)
        Label2.TabIndex = 6
        Label2.Text = "Port"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(21, 145)
        Label3.Name = "Label3"
        Label3.Size = New Size(30, 15)
        Label3.TabIndex = 7
        Label3.Text = "User"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(118, 145)
        Label4.Name = "Label4"
        Label4.Size = New Size(57, 15)
        Label4.TabIndex = 8
        Label4.Text = "Password"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(22, 203)
        Label5.Name = "Label5"
        Label5.Size = New Size(90, 15)
        Label5.TabIndex = 9
        Label5.Text = "Database Name"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.blue_database_server_settings_20288
        PictureBox1.Location = New Point(23, 22)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(50, 51)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 10
        PictureBox1.TabStop = False
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label6.Location = New Point(79, 44)
        Label6.Name = "Label6"
        Label6.Size = New Size(170, 25)
        Label6.TabIndex = 11
        Label6.Text = "Database Settings"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(37, 268)
        Button1.Name = "Button1"
        Button1.Size = New Size(90, 29)
        Button1.TabIndex = 12
        Button1.Text = "Test"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(145, 268)
        Button2.Name = "Button2"
        Button2.Size = New Size(90, 29)
        Button2.TabIndex = 13
        Button2.Text = "Save/Connect"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' DatabaseSettings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(276, 328)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label6)
        Controls.Add(PictureBox1)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txt_dbName)
        Controls.Add(txt_pass)
        Controls.Add(txt_user)
        Controls.Add(txt_port)
        Controls.Add(txt_ServerIP)
        Name = "DatabaseSettings"
        StartPosition = FormStartPosition.CenterScreen
        Text = "DatabaseSettings"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txt_ServerIP As TextBox
    Friend WithEvents txt_port As TextBox
    Friend WithEvents txt_user As TextBox
    Friend WithEvents txt_pass As TextBox
    Friend WithEvents txt_dbName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
