<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class add_highscores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(add_highscores))
        Me.lbl_current_hs = New System.Windows.Forms.Label()
        Me.panel_submit_trigger = New System.Windows.Forms.Panel()
        Me.ptbox_trophy = New System.Windows.Forms.PictureBox()
        Me.lbl_submit = New System.Windows.Forms.Label()
        Me.ptbox_redo = New System.Windows.Forms.PictureBox()
        Me.ptbox_help = New System.Windows.Forms.PictureBox()
        Me.ptbox_home = New System.Windows.Forms.PictureBox()
        Me.txtbox_input_hs = New TypingStabler1.TransparentTextBox()
        Me.panel_submit_trigger.SuspendLayout()
        CType(Me.ptbox_trophy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbox_redo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbox_help, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbox_home, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_current_hs
        '
        Me.lbl_current_hs.AutoSize = True
        Me.lbl_current_hs.BackColor = System.Drawing.Color.Transparent
        Me.lbl_current_hs.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_current_hs.Location = New System.Drawing.Point(297, 96)
        Me.lbl_current_hs.Name = "lbl_current_hs"
        Me.lbl_current_hs.Size = New System.Drawing.Size(20, 24)
        Me.lbl_current_hs.TabIndex = 2
        Me.lbl_current_hs.Text = "0"
        '
        'panel_submit_trigger
        '
        Me.panel_submit_trigger.BackColor = System.Drawing.Color.Transparent
        Me.panel_submit_trigger.Controls.Add(Me.ptbox_trophy)
        Me.panel_submit_trigger.Controls.Add(Me.lbl_submit)
        Me.panel_submit_trigger.Cursor = System.Windows.Forms.Cursors.Hand
        Me.panel_submit_trigger.Location = New System.Drawing.Point(157, 182)
        Me.panel_submit_trigger.Name = "panel_submit_trigger"
        Me.panel_submit_trigger.Size = New System.Drawing.Size(163, 33)
        Me.panel_submit_trigger.TabIndex = 4
        '
        'ptbox_trophy
        '
        Me.ptbox_trophy.Image = Global.TypingStabler1.My.Resources.Resources.tick
        Me.ptbox_trophy.Location = New System.Drawing.Point(11, 4)
        Me.ptbox_trophy.Name = "ptbox_trophy"
        Me.ptbox_trophy.Size = New System.Drawing.Size(24, 24)
        Me.ptbox_trophy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ptbox_trophy.TabIndex = 7
        Me.ptbox_trophy.TabStop = False
        '
        'lbl_submit
        '
        Me.lbl_submit.AutoSize = True
        Me.lbl_submit.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_submit.Location = New System.Drawing.Point(31, -2)
        Me.lbl_submit.Name = "lbl_submit"
        Me.lbl_submit.Size = New System.Drawing.Size(117, 37)
        Me.lbl_submit.TabIndex = 0
        Me.lbl_submit.Text = "Submit"
        '
        'ptbox_redo
        '
        Me.ptbox_redo.BackColor = System.Drawing.Color.Transparent
        Me.ptbox_redo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ptbox_redo.Image = CType(resources.GetObject("ptbox_redo.Image"), System.Drawing.Image)
        Me.ptbox_redo.Location = New System.Drawing.Point(364, 182)
        Me.ptbox_redo.Name = "ptbox_redo"
        Me.ptbox_redo.Size = New System.Drawing.Size(35, 33)
        Me.ptbox_redo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.ptbox_redo.TabIndex = 7
        Me.ptbox_redo.TabStop = False
        '
        'ptbox_help
        '
        Me.ptbox_help.BackColor = System.Drawing.Color.Transparent
        Me.ptbox_help.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ptbox_help.Image = Global.TypingStabler1.My.Resources.Resources.help
        Me.ptbox_help.Location = New System.Drawing.Point(403, 182)
        Me.ptbox_help.Name = "ptbox_help"
        Me.ptbox_help.Size = New System.Drawing.Size(33, 33)
        Me.ptbox_help.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.ptbox_help.TabIndex = 8
        Me.ptbox_help.TabStop = False
        '
        'ptbox_home
        '
        Me.ptbox_home.BackColor = System.Drawing.Color.Transparent
        Me.ptbox_home.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ptbox_home.Image = Global.TypingStabler1.My.Resources.Resources.home
        Me.ptbox_home.Location = New System.Drawing.Point(439, 182)
        Me.ptbox_home.Name = "ptbox_home"
        Me.ptbox_home.Size = New System.Drawing.Size(33, 33)
        Me.ptbox_home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.ptbox_home.TabIndex = 9
        Me.ptbox_home.TabStop = False
        '
        'txtbox_input_hs
        '
        Me.txtbox_input_hs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtbox_input_hs.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbox_input_hs.Location = New System.Drawing.Point(239, 135)
        Me.txtbox_input_hs.MaxLength = 15
        Me.txtbox_input_hs.Name = "txtbox_input_hs"
        Me.txtbox_input_hs.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.txtbox_input_hs.Size = New System.Drawing.Size(204, 33)
        Me.txtbox_input_hs.TabIndex = 1
        Me.txtbox_input_hs.Text = ""
        '
        'add_highscores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(476, 219)
        Me.Controls.Add(Me.ptbox_home)
        Me.Controls.Add(Me.ptbox_help)
        Me.Controls.Add(Me.ptbox_redo)
        Me.Controls.Add(Me.panel_submit_trigger)
        Me.Controls.Add(Me.lbl_current_hs)
        Me.Controls.Add(Me.txtbox_input_hs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "add_highscores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Submit score"
        Me.panel_submit_trigger.ResumeLayout(False)
        Me.panel_submit_trigger.PerformLayout()
        CType(Me.ptbox_trophy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbox_redo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbox_help, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbox_home, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtbox_input_hs As TypingStabler1.TransparentTextBox
    Friend WithEvents lbl_current_hs As System.Windows.Forms.Label
    Friend WithEvents panel_submit_trigger As System.Windows.Forms.Panel
    Friend WithEvents lbl_submit As System.Windows.Forms.Label
    Friend WithEvents ptbox_trophy As System.Windows.Forms.PictureBox
    Friend WithEvents ptbox_redo As System.Windows.Forms.PictureBox
    Friend WithEvents ptbox_help As System.Windows.Forms.PictureBox
    Friend WithEvents ptbox_home As System.Windows.Forms.PictureBox
End Class
