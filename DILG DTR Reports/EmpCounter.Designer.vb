<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmpCoounter
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
        lbl_totalCount = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' lbl_totalCount
        ' 
        lbl_totalCount.Font = New Font("Bahnschrift", 72F, FontStyle.Bold, GraphicsUnit.Point)
        lbl_totalCount.Location = New Point(2, 9)
        lbl_totalCount.Name = "lbl_totalCount"
        lbl_totalCount.Size = New Size(274, 178)
        lbl_totalCount.TabIndex = 0
        lbl_totalCount.Text = "20"
        lbl_totalCount.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(67, 162)
        Label2.Name = "Label2"
        Label2.Size = New Size(144, 25)
        Label2.TabIndex = 1
        Label2.Text = "Total Timed-in"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(57, 340)
        Label1.Name = "Label1"
        Label1.Size = New Size(164, 25)
        Label1.TabIndex = 3
        Label1.Text = "Total Employees"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.Font = New Font("Bahnschrift", 72F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(2, 187)
        Label3.Name = "Label3"
        Label3.Size = New Size(274, 178)
        Label3.TabIndex = 2
        Label3.Text = "20"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' EmpCoounter
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1021, 537)
        Controls.Add(Label1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(lbl_totalCount)
        FormBorderStyle = FormBorderStyle.None
        Name = "EmpCoounter"
        Text = "EmpCoounter"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lbl_totalCount As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
End Class
