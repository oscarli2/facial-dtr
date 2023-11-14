<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoggedIn
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
        ComboBox1 = New ComboBox()
        lv_employees = New ListView()
        SuspendLayout()
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(12, 12)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(245, 23)
        ComboBox1.TabIndex = 0
        ' 
        ' lv_employees
        ' 
        lv_employees.Location = New Point(12, 41)
        lv_employees.Name = "lv_employees"
        lv_employees.Size = New Size(750, 394)
        lv_employees.TabIndex = 1
        lv_employees.UseCompatibleStateImageBehavior = False
        ' 
        ' LoggedIn
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(777, 454)
        Controls.Add(lv_employees)
        Controls.Add(ComboBox1)
        Name = "LoggedIn"
        Text = "EditTime"
        ResumeLayout(False)
    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents lv_employees As ListView
End Class
