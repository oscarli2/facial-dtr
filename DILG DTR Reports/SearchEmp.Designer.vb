<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchEmp
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
        Label1 = New Label()
        txtEmployee = New TextBox()
        lv_employees = New ListView()
        StatusStrip1 = New StatusStrip()
        ToolStripStatusLabel2 = New ToolStripStatusLabel()
        recordCount = New ToolStripStatusLabel()
        Label2 = New Label()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Calibri", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(10, 14)
        Label1.Name = "Label1"
        Label1.Size = New Size(126, 18)
        Label1.TabIndex = 3
        Label1.Text = "Name of Employee"
        ' 
        ' txtEmployee
        ' 
        txtEmployee.BorderStyle = BorderStyle.FixedSingle
        txtEmployee.Font = New Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point)
        txtEmployee.Location = New Point(10, 38)
        txtEmployee.Name = "txtEmployee"
        txtEmployee.Size = New Size(322, 27)
        txtEmployee.TabIndex = 2
        ' 
        ' lv_employees
        ' 
        lv_employees.BackColor = SystemColors.Window
        lv_employees.BorderStyle = BorderStyle.FixedSingle
        lv_employees.Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        lv_employees.ForeColor = Color.Black
        lv_employees.FullRowSelect = True
        lv_employees.HoverSelection = True
        lv_employees.Location = New Point(10, 75)
        lv_employees.Name = "lv_employees"
        lv_employees.Size = New Size(595, 400)
        lv_employees.TabIndex = 4
        lv_employees.UseCompatibleStateImageBehavior = False
        lv_employees.View = View.Details
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {ToolStripStatusLabel2, recordCount})
        StatusStrip1.Location = New Point(0, 493)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Padding = New Padding(1, 0, 12, 0)
        StatusStrip1.Size = New Size(615, 22)
        StatusStrip1.TabIndex = 5
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' ToolStripStatusLabel2
        ' 
        ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        ToolStripStatusLabel2.Size = New Size(77, 17)
        ToolStripStatusLabel2.Text = "Total Records"
        ' 
        ' recordCount
        ' 
        recordCount.Name = "recordCount"
        recordCount.Size = New Size(13, 17)
        recordCount.Text = "0"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Calibri", 9F, FontStyle.Italic, GraphicsUnit.Point)
        Label2.ForeColor = Color.Red
        Label2.Location = New Point(338, 44)
        Label2.Name = "Label2"
        Label2.Size = New Size(216, 14)
        Label2.TabIndex = 6
        Label2.Text = "Enter FIRST or LAST NAME and Hit 'ENTER'"
        ' 
        ' SearchEmp
        ' 
        AutoScaleDimensions = New SizeF(6F, 14F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(615, 515)
        Controls.Add(Label2)
        Controls.Add(StatusStrip1)
        Controls.Add(lv_employees)
        Controls.Add(Label1)
        Controls.Add(txtEmployee)
        Font = New Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point)
        KeyPreview = True
        Name = "SearchEmp"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Search Employee"
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtEmployee As TextBox
    Friend WithEvents lv_employees As ListView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents recordCount As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents Label2 As Label
End Class
