<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AllData
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
        ListView1 = New ListView()
        GroupBox1 = New GroupBox()
        dtp_to = New DateTimePicker()
        Label3 = New Label()
        Label4 = New Label()
        dtp_from = New DateTimePicker()
        lblName = New Label()
        emp_id = New Label()
        Button1 = New Button()
        Label1 = New Label()
        txtEmployee = New TextBox()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ListView1
        ' 
        ListView1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        ListView1.BorderStyle = BorderStyle.FixedSingle
        ListView1.Location = New Point(304, 12)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(670, 414)
        ListView1.TabIndex = 0
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Linen
        GroupBox1.Controls.Add(dtp_to)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(dtp_from)
        GroupBox1.Controls.Add(lblName)
        GroupBox1.Controls.Add(emp_id)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(txtEmployee)
        GroupBox1.FlatStyle = FlatStyle.Flat
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(286, 414)
        GroupBox1.TabIndex = 9
        GroupBox1.TabStop = False
        ' 
        ' dtp_to
        ' 
        dtp_to.CustomFormat = "yyyy-MM-dd"
        dtp_to.Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        dtp_to.Format = DateTimePickerFormat.Custom
        dtp_to.Location = New Point(154, 139)
        dtp_to.Name = "dtp_to"
        dtp_to.Size = New Size(111, 26)
        dtp_to.TabIndex = 22
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(30, 115)
        Label3.Name = "Label3"
        Label3.Size = New Size(40, 17)
        Label3.TabIndex = 20
        Label3.Text = "From"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.Location = New Point(148, 115)
        Label4.Name = "Label4"
        Label4.Size = New Size(23, 17)
        Label4.TabIndex = 23
        Label4.Text = "To"
        ' 
        ' dtp_from
        ' 
        dtp_from.CustomFormat = "yyyy-MM-dd"
        dtp_from.Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        dtp_from.Format = DateTimePickerFormat.Custom
        dtp_from.Location = New Point(40, 139)
        dtp_from.Name = "dtp_from"
        dtp_from.Size = New Size(106, 26)
        dtp_from.TabIndex = 21
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(119, 235)
        lblName.Name = "lblName"
        lblName.Size = New Size(94, 15)
        lblName.TabIndex = 9
        lblName.Text = "Employee Name"
        lblName.Visible = False
        ' 
        ' emp_id
        ' 
        emp_id.AutoSize = True
        emp_id.Location = New Point(66, 235)
        emp_id.Name = "emp_id"
        emp_id.Size = New Size(47, 15)
        emp_id.TabIndex = 8
        emp_id.Text = "EMP_ID"
        emp_id.Visible = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Khaki
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.ForeColor = Color.Black
        Button1.Location = New Point(18, 187)
        Button1.Name = "Button1"
        Button1.Size = New Size(247, 45)
        Button1.TabIndex = 7
        Button1.Text = "Search"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(18, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(128, 19)
        Label1.TabIndex = 1
        Label1.Text = "EMPLOYEE NAME"
        ' 
        ' txtEmployee
        ' 
        txtEmployee.BorderStyle = BorderStyle.FixedSingle
        txtEmployee.Cursor = Cursors.Hand
        txtEmployee.Font = New Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point)
        txtEmployee.Location = New Point(18, 74)
        txtEmployee.Name = "txtEmployee"
        txtEmployee.ReadOnly = True
        txtEmployee.Size = New Size(247, 27)
        txtEmployee.TabIndex = 0
        txtEmployee.Text = "CLICK HERE TO SEARCH"
        txtEmployee.TextAlign = HorizontalAlignment.Center
        ' 
        ' AllData
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(997, 446)
        Controls.Add(GroupBox1)
        Controls.Add(ListView1)
        Name = "AllData"
        Text = "Search All Records"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblName As Label
    Friend WithEvents emp_id As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEmployee As TextBox
    Friend WithEvents dtp_to As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtp_from As DateTimePicker
End Class
