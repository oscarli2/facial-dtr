<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        components = New ComponentModel.Container()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        ToolStrip1 = New ToolStrip()
        ToolStripButton1 = New ToolStripButton()
        ToolStripButton3 = New ToolStripButton()
        ToolStripButton5 = New ToolStripButton()
        ToolStripSeparator1 = New ToolStripSeparator()
        ToolStripButton2 = New ToolStripButton()
        lbl_empInCount = New ToolStripLabel()
        ToolStripLabel1 = New ToolStripLabel()
        StatusStrip1 = New StatusStrip()
        ToolStripStatusLabel1 = New ToolStripStatusLabel()
        Timer1 = New Timer(components)
        Timer2 = New Timer(components)
        ToolStrip1.SuspendLayout()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.AutoSize = False
        ToolStrip1.BackColor = Color.Firebrick
        ToolStrip1.GripStyle = ToolStripGripStyle.Hidden
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripButton1, ToolStripButton3, ToolStripButton5, ToolStripSeparator1, ToolStripButton2, lbl_empInCount, ToolStripLabel1})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(907, 49)
        ToolStrip1.TabIndex = 2
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.AutoSize = False
        ToolStripButton1.BackColor = Color.Firebrick
        ToolStripButton1.Font = New Font("Bahnschrift", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        ToolStripButton1.ForeColor = Color.White
        ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), Image)
        ToolStripButton1.ImageScaling = ToolStripItemImageScaling.None
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(70, 50)
        ToolStripButton1.Text = "Check DTR"
        ToolStripButton1.TextAlign = ContentAlignment.BottomCenter
        ToolStripButton1.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripButton3
        ' 
        ToolStripButton3.AutoSize = False
        ToolStripButton3.BackColor = Color.Firebrick
        ToolStripButton3.Enabled = False
        ToolStripButton3.Font = New Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ToolStripButton3.ForeColor = Color.White
        ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), Image)
        ToolStripButton3.ImageScaling = ToolStripItemImageScaling.None
        ToolStripButton3.ImageTransparentColor = Color.Magenta
        ToolStripButton3.Name = "ToolStripButton3"
        ToolStripButton3.Size = New Size(70, 50)
        ToolStripButton3.Text = "Print"
        ToolStripButton3.TextAlign = ContentAlignment.BottomCenter
        ToolStripButton3.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripButton5
        ' 
        ToolStripButton5.AutoSize = False
        ToolStripButton5.BackColor = Color.Firebrick
        ToolStripButton5.Font = New Font("Bahnschrift", 8.25F, FontStyle.Regular, GraphicsUnit.Point)
        ToolStripButton5.ForeColor = Color.White
        ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), Image)
        ToolStripButton5.ImageScaling = ToolStripItemImageScaling.None
        ToolStripButton5.ImageTransparentColor = Color.Magenta
        ToolStripButton5.Name = "ToolStripButton5"
        ToolStripButton5.Size = New Size(70, 50)
        ToolStripButton5.Text = "All Records"
        ToolStripButton5.TextAlign = ContentAlignment.BottomCenter
        ToolStripButton5.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 49)
        ' 
        ' ToolStripButton2
        ' 
        ToolStripButton2.AutoSize = False
        ToolStripButton2.BackColor = Color.Firebrick
        ToolStripButton2.Font = New Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ToolStripButton2.ForeColor = Color.White
        ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), Image)
        ToolStripButton2.ImageScaling = ToolStripItemImageScaling.None
        ToolStripButton2.ImageTransparentColor = Color.Magenta
        ToolStripButton2.Name = "ToolStripButton2"
        ToolStripButton2.Size = New Size(70, 50)
        ToolStripButton2.Text = "Update"
        ToolStripButton2.TextAlign = ContentAlignment.BottomCenter
        ToolStripButton2.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' lbl_empInCount
        ' 
        lbl_empInCount.Alignment = ToolStripItemAlignment.Right
        lbl_empInCount.Font = New Font("Arial", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        lbl_empInCount.ForeColor = Color.White
        lbl_empInCount.Name = "lbl_empInCount"
        lbl_empInCount.Padding = New Padding(0, 0, 15, 0)
        lbl_empInCount.Size = New Size(37, 46)
        lbl_empInCount.Text = "0"
        ' 
        ' ToolStripLabel1
        ' 
        ToolStripLabel1.Alignment = ToolStripItemAlignment.Right
        ToolStripLabel1.Font = New Font("Bahnschrift SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point)
        ToolStripLabel1.ForeColor = Color.White
        ToolStripLabel1.Name = "ToolStripLabel1"
        ToolStripLabel1.Size = New Size(135, 46)
        ToolStripLabel1.Text = "Total Timed-in as of"
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.Items.AddRange(New ToolStripItem() {ToolStripStatusLabel1})
        StatusStrip1.Location = New Point(0, 511)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(907, 22)
        StatusStrip1.TabIndex = 4
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' ToolStripStatusLabel1
        ' 
        ToolStripStatusLabel1.Font = New Font("Arial Narrow", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        ToolStripStatusLabel1.Size = New Size(126, 17)
        ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        ' 
        ' Timer1
        ' 
        Timer1.Enabled = True
        Timer1.Interval = 10000
        ' 
        ' Timer2
        ' 
        Timer2.Enabled = True
        Timer2.Interval = 1000
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.pngaaa_com_4194622
        BackgroundImageLayout = ImageLayout.Center
        ClientSize = New Size(907, 533)
        Controls.Add(StatusStrip1)
        Controls.Add(ToolStrip1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        IsMdiContainer = True
        Name = "Form1"
        Text = "DILG R8 - DTR"
        WindowState = FormWindowState.Maximized
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents lbl_empInCount As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
End Class
