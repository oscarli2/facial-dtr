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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        ToolStrip1 = New ToolStrip()
        ToolStripButton1 = New ToolStripButton()
        ToolStripButton3 = New ToolStripButton()
        ToolStripButton2 = New ToolStripButton()
        ToolStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.BackColor = Color.Firebrick
        ToolStrip1.GripStyle = ToolStripGripStyle.Hidden
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripButton1, ToolStripButton3, ToolStripButton2})
        ToolStrip1.Location = New Point(0, 0)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(907, 53)
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
        ToolStripButton1.ImageAlign = ContentAlignment.BottomCenter
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
        ToolStripButton3.Font = New Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ToolStripButton3.ForeColor = Color.White
        ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), Image)
        ToolStripButton3.ImageAlign = ContentAlignment.BottomCenter
        ToolStripButton3.ImageScaling = ToolStripItemImageScaling.None
        ToolStripButton3.ImageTransparentColor = Color.Magenta
        ToolStripButton3.Name = "ToolStripButton3"
        ToolStripButton3.Size = New Size(70, 50)
        ToolStripButton3.Text = "Print"
        ToolStripButton3.TextAlign = ContentAlignment.BottomCenter
        ToolStripButton3.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' ToolStripButton2
        ' 
        ToolStripButton2.AutoSize = False
        ToolStripButton2.BackColor = Color.Firebrick
        ToolStripButton2.Font = New Font("Bahnschrift", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ToolStripButton2.ForeColor = Color.White
        ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), Image)
        ToolStripButton2.ImageAlign = ContentAlignment.BottomCenter
        ToolStripButton2.ImageScaling = ToolStripItemImageScaling.None
        ToolStripButton2.ImageTransparentColor = Color.Magenta
        ToolStripButton2.Name = "ToolStripButton2"
        ToolStripButton2.Size = New Size(70, 50)
        ToolStripButton2.Text = "Update"
        ToolStripButton2.TextAlign = ContentAlignment.BottomCenter
        ToolStripButton2.TextImageRelation = TextImageRelation.ImageAboveText
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.pngaaa_com_4194622
        BackgroundImageLayout = ImageLayout.Center
        ClientSize = New Size(907, 533)
        Controls.Add(ToolStrip1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        IsMdiContainer = True
        Name = "Form1"
        Text = "DILG R8 - DTR"
        WindowState = FormWindowState.Maximized
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton3 As ToolStripButton
End Class
