<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class updateProg
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
        ProgressBar1 = New ProgressBar()
        Button1 = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(44, 63)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(370, 36)
        ProgressBar1.Style = ProgressBarStyle.Continuous
        ProgressBar1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.LightGray
        Button1.Font = New Font("Bahnschrift", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Button1.Location = New Point(114, 159)
        Button1.Name = "Button1"
        Button1.Size = New Size(230, 47)
        Button1.TabIndex = 1
        Button1.Text = "Install Updates"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(44, 100)
        Label1.Name = "Label1"
        Label1.Size = New Size(370, 30)
        Label1.TabIndex = 2
        Label1.Text = "Label1"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' updateProg
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(449, 242)
        Controls.Add(Label1)
        Controls.Add(Button1)
        Controls.Add(ProgressBar1)
        Name = "updateProg"
        Text = "updateProg"
        ResumeLayout(False)
    End Sub

    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
End Class
