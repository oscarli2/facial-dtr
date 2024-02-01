<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DTRMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(DTRMain))
        txtEmployee = New TextBox()
        Label1 = New Label()
        Label3 = New Label()
        Button1 = New Button()
        GroupBox1 = New GroupBox()
        cbYear = New ComboBox()
        Label16 = New Label()
        CheckBox1 = New CheckBox()
        ComboBox1 = New ComboBox()
        RadioButton3 = New RadioButton()
        RadioButton2 = New RadioButton()
        RadioButton1 = New RadioButton()
        Label5 = New Label()
        lblName = New Label()
        emp_id = New Label()
        Label4 = New Label()
        dtp_to = New DateTimePicker()
        dtp_from = New DateTimePicker()
        PrintDocument1 = New Printing.PrintDocument()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        Label8 = New Label()
        TextBox11 = New TextBox()
        TextBox9 = New TextBox()
        TextBox10 = New TextBox()
        RichTextBox1 = New RichTextBox()
        ListView1 = New ListView()
        Label6 = New Label()
        Label7 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        TextBox4 = New TextBox()
        txtEmpName = New TextBox()
        TextBox1 = New TextBox()
        Label12 = New Label()
        Label13 = New Label()
        Panel1 = New Panel()
        DataGridView1 = New DataGridView()
        TextBox6 = New TextBox()
        PictureBox2 = New PictureBox()
        Label2 = New Label()
        Label15 = New Label()
        Label14 = New Label()
        lblMonth = New Label()
        TextBox5 = New TextBox()
        TextBox3 = New TextBox()
        TextBox2 = New TextBox()
        TextBox14 = New TextBox()
        TextBox15 = New TextBox()
        TextBox12 = New TextBox()
        TextBox13 = New TextBox()
        TextBox8 = New TextBox()
        TextBox7 = New TextBox()
        PageSetupDialog1 = New PageSetupDialog()
        PictureBox1 = New PictureBox()
        GroupBox1.SuspendLayout()
        Panel1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtEmployee
        ' 
        txtEmployee.BorderStyle = BorderStyle.FixedSingle
        txtEmployee.Cursor = Cursors.Hand
        txtEmployee.Font = New Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point)
        txtEmployee.Location = New Point(28, 51)
        txtEmployee.Name = "txtEmployee"
        txtEmployee.ReadOnly = True
        txtEmployee.Size = New Size(247, 27)
        txtEmployee.TabIndex = 0
        txtEmployee.Text = "CLICK HERE TO SEARCH"
        txtEmployee.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(28, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(128, 19)
        Label1.TabIndex = 1
        Label1.Text = "EMPLOYEE NAME"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(38, 588)
        Label3.Name = "Label3"
        Label3.Size = New Size(34, 14)
        Label3.TabIndex = 5
        Label3.Text = "From"
        Label3.Visible = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.DarkSeaGreen
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(28, 235)
        Button1.Name = "Button1"
        Button1.Size = New Size(245, 54)
        Button1.TabIndex = 7
        Button1.Text = "Search"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Khaki
        GroupBox1.Controls.Add(cbYear)
        GroupBox1.Controls.Add(Label16)
        GroupBox1.Controls.Add(CheckBox1)
        GroupBox1.Controls.Add(ComboBox1)
        GroupBox1.Controls.Add(RadioButton3)
        GroupBox1.Controls.Add(RadioButton2)
        GroupBox1.Controls.Add(RadioButton1)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(lblName)
        GroupBox1.Controls.Add(emp_id)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(txtEmployee)
        GroupBox1.FlatStyle = FlatStyle.Flat
        GroupBox1.Location = New Point(12, 203)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(304, 340)
        GroupBox1.TabIndex = 8
        GroupBox1.TabStop = False
        ' 
        ' cbYear
        ' 
        cbYear.FormattingEnabled = True
        cbYear.Items.AddRange(New Object() {"2020", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030"})
        cbYear.Location = New Point(90, 132)
        cbYear.Name = "cbYear"
        cbYear.Size = New Size(103, 22)
        cbYear.TabIndex = 22
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label16.Location = New Point(28, 135)
        Label16.Name = "Label16"
        Label16.Size = New Size(38, 19)
        Label16.TabIndex = 21
        Label16.Text = "Year"
        ' 
        ' CheckBox1
        ' 
        CheckBox1.AutoSize = True
        CheckBox1.Location = New Point(181, 28)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Size(94, 18)
        CheckBox1.TabIndex = 20
        CheckBox1.Text = "Security Unit"
        CheckBox1.UseVisualStyleBackColor = True
        ' 
        ' ComboBox1
        ' 
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER"})
        ComboBox1.Location = New Point(90, 104)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(183, 22)
        ComboBox1.TabIndex = 19
        ' 
        ' RadioButton3
        ' 
        RadioButton3.AutoSize = True
        RadioButton3.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        RadioButton3.Location = New Point(98, 201)
        RadioButton3.Name = "RadioButton3"
        RadioButton3.Size = New Size(109, 20)
        RadioButton3.TabIndex = 18
        RadioButton3.TabStop = True
        RadioButton3.Text = "Whole Month"
        RadioButton3.UseVisualStyleBackColor = True
        ' 
        ' RadioButton2
        ' 
        RadioButton2.AutoSize = True
        RadioButton2.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        RadioButton2.Location = New Point(158, 175)
        RadioButton2.Name = "RadioButton2"
        RadioButton2.Size = New Size(99, 20)
        RadioButton2.TabIndex = 17
        RadioButton2.TabStop = True
        RadioButton2.Text = "Days 16 - 31"
        RadioButton2.UseVisualStyleBackColor = True
        ' 
        ' RadioButton1
        ' 
        RadioButton1.AutoSize = True
        RadioButton1.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        RadioButton1.Location = New Point(41, 175)
        RadioButton1.Name = "RadioButton1"
        RadioButton1.Size = New Size(92, 20)
        RadioButton1.TabIndex = 16
        RadioButton1.TabStop = True
        RadioButton1.Text = "Days 1 - 15"
        RadioButton1.UseVisualStyleBackColor = True
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point)
        Label5.Location = New Point(28, 107)
        Label5.Name = "Label5"
        Label5.Size = New Size(56, 19)
        Label5.TabIndex = 13
        Label5.Text = "Month"
        ' 
        ' lblName
        ' 
        lblName.AutoSize = True
        lblName.Location = New Point(98, 85)
        lblName.Name = "lblName"
        lblName.Size = New Size(95, 14)
        lblName.TabIndex = 9
        lblName.Text = "Employee Name"
        lblName.Visible = False
        ' 
        ' emp_id
        ' 
        emp_id.AutoSize = True
        emp_id.Location = New Point(31, 85)
        emp_id.Name = "emp_id"
        emp_id.Size = New Size(47, 14)
        emp_id.TabIndex = 8
        emp_id.Text = "EMP_ID"
        emp_id.Visible = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(170, 588)
        Label4.Name = "Label4"
        Label4.Size = New Size(19, 14)
        Label4.TabIndex = 12
        Label4.Text = "To"
        Label4.Visible = False
        ' 
        ' dtp_to
        ' 
        dtp_to.CustomFormat = "yyyy-MM-dd"
        dtp_to.Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        dtp_to.Format = DateTimePickerFormat.Custom
        dtp_to.Location = New Point(193, 580)
        dtp_to.Name = "dtp_to"
        dtp_to.Size = New Size(92, 26)
        dtp_to.TabIndex = 11
        dtp_to.Visible = False
        ' 
        ' dtp_from
        ' 
        dtp_from.CustomFormat = "yyyy-MM-dd"
        dtp_from.Font = New Font("Calibri", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        dtp_from.Format = DateTimePickerFormat.Custom
        dtp_from.Location = New Point(74, 580)
        dtp_from.Name = "dtp_from"
        dtp_from.Size = New Size(92, 26)
        dtp_from.TabIndex = 10
        dtp_from.Visible = False
        ' 
        ' PrintDocument1
        ' 
        ' 
        ' PrintPreviewDialog1
        ' 
        PrintPreviewDialog1.AutoScrollMargin = New Size(0, 0)
        PrintPreviewDialog1.AutoScrollMinSize = New Size(0, 0)
        PrintPreviewDialog1.ClientSize = New Size(400, 300)
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.Enabled = True
        PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Icon)
        PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        PrintPreviewDialog1.Visible = False
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.White
        Label8.Font = New Font("Arial", 9.75F, FontStyle.Italic, GraphicsUnit.Point)
        Label8.Location = New Point(20, 1105)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(158, 16)
        Label8.TabIndex = 45
        Label8.Text = "Civil Service Form  No. 48"
        ' 
        ' TextBox11
        ' 
        TextBox11.BackColor = Color.White
        TextBox11.BorderStyle = BorderStyle.None
        TextBox11.Font = New Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox11.Location = New Point(88, 1051)
        TextBox11.Name = "TextBox11"
        TextBox11.ReadOnly = True
        TextBox11.Size = New Size(334, 18)
        TextBox11.TabIndex = 44
        TextBox11.Text = "Regional Director"
        TextBox11.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox9
        ' 
        TextBox9.BackColor = Color.White
        TextBox9.BorderStyle = BorderStyle.None
        TextBox9.Font = New Font("Arial", 9.75F, FontStyle.Italic, GraphicsUnit.Point)
        TextBox9.Location = New Point(88, 1074)
        TextBox9.Name = "TextBox9"
        TextBox9.ReadOnly = True
        TextBox9.Size = New Size(334, 15)
        TextBox9.TabIndex = 43
        TextBox9.Text = "In Charge"
        TextBox9.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox10
        ' 
        TextBox10.BackColor = Color.White
        TextBox10.BorderStyle = BorderStyle.None
        TextBox10.Font = New Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox10.Location = New Point(88, 1035)
        TextBox10.Name = "TextBox10"
        TextBox10.ReadOnly = True
        TextBox10.Size = New Size(334, 19)
        TextBox10.TabIndex = 42
        TextBox10.Text = "ARNEL M. AGABE, CESO III"
        TextBox10.TextAlign = HorizontalAlignment.Center
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BackColor = Color.White
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Font = New Font("Arial", 9.75F, FontStyle.Italic, GraphicsUnit.Point)
        RichTextBox1.Location = New Point(35, 878)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(444, 50)
        RichTextBox1.TabIndex = 38
        RichTextBox1.Text = "I certify on my honor that the above is a true and correct report of the hours of work performed, record of which was made daily at the time of arrival and departure from office."
        ' 
        ' ListView1
        ' 
        ListView1.BackColor = Color.White
        ListView1.BorderStyle = BorderStyle.FixedSingle
        ListView1.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ListView1.FullRowSelect = True
        ListView1.GridLines = True
        ListView1.HeaderStyle = ColumnHeaderStyle.None
        ListView1.Location = New Point(16, 211)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(477, 656)
        ListView1.TabIndex = 37
        ListView1.UseCompatibleStateImageBehavior = False
        ListView1.View = View.Details
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.Location = New Point(301, 151)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(62, 15)
        Label6.TabIndex = 34
        Label6.Text = "Saturdays"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.Location = New Point(301, 135)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(82, 15)
        Label7.TabIndex = 33
        Label7.Text = "Regular Days"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.BackColor = Color.White
        Label9.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.Location = New Point(20, 151)
        Label9.Margin = New Padding(4, 0, 4, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(84, 15)
        Label9.TabIndex = 32
        Label9.Text = "and departure"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.White
        Label10.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point)
        Label10.Location = New Point(20, 137)
        Label10.Margin = New Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(122, 15)
        Label10.TabIndex = 31
        Label10.Text = "Office hours of arrival"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.White
        Label11.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.Location = New Point(20, 116)
        Label11.Margin = New Padding(4, 0, 4, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(96, 15)
        Label11.TabIndex = 30
        Label11.Text = "For the month of"
        ' 
        ' TextBox4
        ' 
        TextBox4.BackColor = Color.White
        TextBox4.BorderStyle = BorderStyle.None
        TextBox4.Enabled = False
        TextBox4.Font = New Font("Arial", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox4.Location = New Point(125, 100)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(264, 13)
        TextBox4.TabIndex = 29
        TextBox4.Text = "(Name)"
        TextBox4.TextAlign = HorizontalAlignment.Center
        ' 
        ' txtEmpName
        ' 
        txtEmpName.BackColor = Color.White
        txtEmpName.BorderStyle = BorderStyle.None
        txtEmpName.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        txtEmpName.Location = New Point(110, 80)
        txtEmpName.Name = "txtEmpName"
        txtEmpName.ReadOnly = True
        txtEmpName.Size = New Size(300, 15)
        txtEmpName.TabIndex = 27
        txtEmpName.Text = "EMPLOYEE NAME HERE"
        txtEmpName.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = Color.White
        TextBox1.BorderStyle = BorderStyle.None
        TextBox1.Font = New Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox1.Location = New Point(115, 34)
        TextBox1.Name = "TextBox1"
        TextBox1.ReadOnly = True
        TextBox1.Size = New Size(294, 22)
        TextBox1.TabIndex = 26
        TextBox1.Text = "DAILY TIME RECORD"
        TextBox1.TextAlign = HorizontalAlignment.Center
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.White
        Label12.Font = New Font("Arial", 9.75F, FontStyle.Italic, GraphicsUnit.Point)
        Label12.Location = New Point(136, 59)
        Label12.Margin = New Padding(4, 0, 4, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(247, 16)
        Label12.TabIndex = 25
        Label12.Text = "=============================="
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.BackColor = Color.White
        Label13.Font = New Font("Arial", 9F, FontStyle.Italic, GraphicsUnit.Point)
        Label13.Location = New Point(16, 12)
        Label13.Margin = New Padding(4, 0, 4, 0)
        Label13.Name = "Label13"
        Label13.Size = New Size(149, 15)
        Label13.TabIndex = 24
        Label13.Text = "Civil Service Form  No. 48"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.White
        Panel1.Controls.Add(DataGridView1)
        Panel1.Controls.Add(TextBox6)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(ListView1)
        Panel1.Controls.Add(Label15)
        Panel1.Controls.Add(Label14)
        Panel1.Controls.Add(lblMonth)
        Panel1.Controls.Add(Label13)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(TextBox11)
        Panel1.Controls.Add(TextBox9)
        Panel1.Controls.Add(Label12)
        Panel1.Controls.Add(TextBox10)
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(txtEmpName)
        Panel1.Controls.Add(TextBox4)
        Panel1.Controls.Add(RichTextBox1)
        Panel1.Controls.Add(Label11)
        Panel1.Controls.Add(Label10)
        Panel1.Controls.Add(Label9)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(TextBox5)
        Panel1.Controls.Add(TextBox3)
        Panel1.Controls.Add(TextBox2)
        Panel1.Controls.Add(TextBox14)
        Panel1.Controls.Add(TextBox15)
        Panel1.Controls.Add(TextBox12)
        Panel1.Controls.Add(TextBox13)
        Panel1.Controls.Add(TextBox8)
        Panel1.Controls.Add(TextBox7)
        Panel1.Location = New Point(336, 11)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(508, 1184)
        Panel1.TabIndex = 46
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        DataGridView1.BackgroundColor = SystemColors.Control
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.ColumnHeadersVisible = False
        DataGridView1.Location = New Point(16, 211)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersVisible = False
        DataGridView1.Size = New Size(477, 656)
        DataGridView1.TabIndex = 48
        ' 
        ' TextBox6
        ' 
        TextBox6.BackColor = Color.LightGray
        TextBox6.BorderStyle = BorderStyle.FixedSingle
        TextBox6.Font = New Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox6.Location = New Point(16, 171)
        TextBox6.Multiline = True
        TextBox6.Name = "TextBox6"
        TextBox6.ReadOnly = True
        TextBox6.Size = New Size(51, 41)
        TextBox6.TabIndex = 62
        TextBox6.Text = vbCrLf & "Days"
        TextBox6.TextAlign = HorizontalAlignment.Center
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.pngaaa_com_4194622
        PictureBox2.Location = New Point(27, 29)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(76, 66)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 48
        PictureBox2.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.White
        Label2.Font = New Font("Arial", 9.75F, FontStyle.Italic, GraphicsUnit.Point)
        Label2.Location = New Point(35, 971)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(264, 16)
        Label2.TabIndex = 61
        Label2.Text = "VERIFIED as to the prescribed office hours:"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.BackColor = Color.White
        Label15.Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label15.Location = New Point(388, 146)
        Label15.Margin = New Padding(4, 0, 4, 0)
        Label15.Name = "Label15"
        Label15.Size = New Size(91, 16)
        Label15.TabIndex = 49
        Label15.Text = "____________"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.BackColor = Color.White
        Label14.Font = New Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label14.Location = New Point(388, 130)
        Label14.Margin = New Padding(4, 0, 4, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(91, 16)
        Label14.TabIndex = 48
        Label14.Text = "____________"
        ' 
        ' lblMonth
        ' 
        lblMonth.AutoSize = True
        lblMonth.BackColor = Color.White
        lblMonth.Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point)
        lblMonth.Location = New Point(115, 116)
        lblMonth.Margin = New Padding(4, 0, 4, 0)
        lblMonth.Name = "lblMonth"
        lblMonth.Size = New Size(87, 15)
        lblMonth.TabIndex = 46
        lblMonth.Text = "MONTH HERE"
        ' 
        ' TextBox5
        ' 
        TextBox5.BackColor = Color.LightGray
        TextBox5.BorderStyle = BorderStyle.FixedSingle
        TextBox5.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox5.Location = New Point(387, 171)
        TextBox5.Name = "TextBox5"
        TextBox5.ReadOnly = True
        TextBox5.Size = New Size(106, 22)
        TextBox5.TabIndex = 52
        TextBox5.Text = "Undertime"
        TextBox5.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox3
        ' 
        TextBox3.BackColor = Color.LightGray
        TextBox3.BorderStyle = BorderStyle.FixedSingle
        TextBox3.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox3.Location = New Point(224, 171)
        TextBox3.Name = "TextBox3"
        TextBox3.ReadOnly = True
        TextBox3.Size = New Size(165, 22)
        TextBox3.TabIndex = 51
        TextBox3.Text = "PM"
        TextBox3.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox2
        ' 
        TextBox2.BackColor = Color.LightGray
        TextBox2.BorderStyle = BorderStyle.FixedSingle
        TextBox2.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox2.Location = New Point(66, 171)
        TextBox2.Name = "TextBox2"
        TextBox2.ReadOnly = True
        TextBox2.Size = New Size(161, 22)
        TextBox2.TabIndex = 50
        TextBox2.Text = "AM"
        TextBox2.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox14
        ' 
        TextBox14.BackColor = Color.LightGray
        TextBox14.BorderStyle = BorderStyle.FixedSingle
        TextBox14.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox14.Location = New Point(438, 191)
        TextBox14.Name = "TextBox14"
        TextBox14.ReadOnly = True
        TextBox14.Size = New Size(55, 21)
        TextBox14.TabIndex = 59
        TextBox14.Text = "Minutes"
        TextBox14.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox15
        ' 
        TextBox15.BackColor = Color.LightGray
        TextBox15.BorderStyle = BorderStyle.FixedSingle
        TextBox15.Font = New Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox15.Location = New Point(387, 191)
        TextBox15.Name = "TextBox15"
        TextBox15.ReadOnly = True
        TextBox15.Size = New Size(54, 21)
        TextBox15.TabIndex = 58
        TextBox15.Text = "Hours"
        TextBox15.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox12
        ' 
        TextBox12.BackColor = Color.LightGray
        TextBox12.BorderStyle = BorderStyle.FixedSingle
        TextBox12.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox12.Location = New Point(304, 190)
        TextBox12.Name = "TextBox12"
        TextBox12.ReadOnly = True
        TextBox12.Size = New Size(85, 22)
        TextBox12.TabIndex = 57
        TextBox12.Text = "Departure"
        TextBox12.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox13
        ' 
        TextBox13.BackColor = Color.LightGray
        TextBox13.BorderStyle = BorderStyle.FixedSingle
        TextBox13.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox13.Location = New Point(224, 190)
        TextBox13.Name = "TextBox13"
        TextBox13.ReadOnly = True
        TextBox13.Size = New Size(84, 22)
        TextBox13.TabIndex = 56
        TextBox13.Text = "Arrival"
        TextBox13.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox8
        ' 
        TextBox8.BackColor = Color.LightGray
        TextBox8.BorderStyle = BorderStyle.FixedSingle
        TextBox8.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox8.Location = New Point(144, 190)
        TextBox8.Name = "TextBox8"
        TextBox8.ReadOnly = True
        TextBox8.Size = New Size(82, 22)
        TextBox8.TabIndex = 55
        TextBox8.Text = "Departure"
        TextBox8.TextAlign = HorizontalAlignment.Center
        ' 
        ' TextBox7
        ' 
        TextBox7.BackColor = Color.LightGray
        TextBox7.BorderStyle = BorderStyle.FixedSingle
        TextBox7.Font = New Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        TextBox7.Location = New Point(66, 190)
        TextBox7.Name = "TextBox7"
        TextBox7.ReadOnly = True
        TextBox7.Size = New Size(81, 22)
        TextBox7.TabIndex = 54
        TextBox7.Text = "Arrival"
        TextBox7.TextAlign = HorizontalAlignment.Center
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.pngaaa_com_4194622
        PictureBox1.Location = New Point(53, 26)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(199, 152)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 47
        PictureBox1.TabStop = False
        ' 
        ' DTRMain
        ' 
        AutoScaleDimensions = New SizeF(6F, 14F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(851, 959)
        Controls.Add(PictureBox1)
        Controls.Add(Panel1)
        Controls.Add(GroupBox1)
        Controls.Add(dtp_to)
        Controls.Add(Label3)
        Controls.Add(Label4)
        Controls.Add(dtp_from)
        Font = New Font("Calibri", 9F, FontStyle.Regular, GraphicsUnit.Point)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        KeyPreview = True
        Name = "DTRMain"
        Text = "DILG DTR Printer 1.0"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtEmployee As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblName As Label
    Friend WithEvents emp_id As Label
    Friend WithEvents dtp_from As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents dtp_to As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents ListView1 As ListView
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents txtEmpName As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblMonth As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents cbYear As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents DataGridView1 As DataGridView
End Class
