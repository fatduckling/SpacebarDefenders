<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gameGUI
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(gameGUI))
        Me.input = New System.Windows.Forms.TextBox()
        Me.timer_shuffle = New System.Windows.Forms.Timer(Me.components)
        Me.tank = New System.Windows.Forms.PictureBox()
        Me.lbl_score = New System.Windows.Forms.Label()
        Me.waveLbl = New System.Windows.Forms.Label()
        Me.panel_destroy = New System.Windows.Forms.Panel()
        Me.panel_container = New System.Windows.Forms.Panel()
        Me.lbl_wave_clear = New System.Windows.Forms.Label()
        Me.bullet = New System.Windows.Forms.PictureBox()
        Me.ptbox_destroy = New System.Windows.Forms.PictureBox()
        Me.ptbox_tank_destroy = New System.Windows.Forms.PictureBox()
        Me.timer_shoot = New System.Windows.Forms.Timer(Me.components)
        Me.timer_destroy = New System.Windows.Forms.Timer(Me.components)
        Me.timer_global = New System.Windows.Forms.Timer(Me.components)
        CType(Me.tank, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel_container.SuspendLayout()
        CType(Me.bullet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbox_destroy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbox_tank_destroy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'input
        '
        Me.input.Location = New System.Drawing.Point(0, 0)
        Me.input.Name = "input"
        Me.input.Size = New System.Drawing.Size(0, 20)
        Me.input.TabIndex = 0
        '
        'timer_shuffle
        '
        Me.timer_shuffle.Enabled = True
        Me.timer_shuffle.Interval = 25
        Me.timer_shuffle.Tag = "1"
        '
        'tank
        '
        Me.tank.BackColor = System.Drawing.Color.Transparent
        Me.tank.BackgroundImage = CType(resources.GetObject("tank.BackgroundImage"), System.Drawing.Image)
        Me.tank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.tank.Image = Global.TypingStabler1.My.Resources.Resources.barrel
        Me.tank.Location = New System.Drawing.Point(409, 490)
        Me.tank.Margin = New System.Windows.Forms.Padding(0)
        Me.tank.Name = "tank"
        Me.tank.Padding = New System.Windows.Forms.Padding(25, 0, 0, 0)
        Me.tank.Size = New System.Drawing.Size(179, 156)
        Me.tank.TabIndex = 3
        Me.tank.TabStop = False
        '
        'lbl_score
        '
        Me.lbl_score.AutoSize = True
        Me.lbl_score.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.lbl_score.ForeColor = System.Drawing.Color.White
        Me.lbl_score.Location = New System.Drawing.Point(12, 9)
        Me.lbl_score.Name = "lbl_score"
        Me.lbl_score.Size = New System.Drawing.Size(25, 25)
        Me.lbl_score.TabIndex = 1
        Me.lbl_score.Text = "0"
        '
        'waveLbl
        '
        Me.waveLbl.AutoSize = True
        Me.waveLbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.waveLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.waveLbl.ForeColor = System.Drawing.Color.White
        Me.waveLbl.Location = New System.Drawing.Point(747, 10)
        Me.waveLbl.Name = "waveLbl"
        Me.waveLbl.Size = New System.Drawing.Size(0, 25)
        Me.waveLbl.TabIndex = 2
        '
        'panel_destroy
        '
        Me.panel_destroy.BackColor = System.Drawing.Color.Black
        Me.panel_destroy.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.panel_destroy.Location = New System.Drawing.Point(0, 607)
        Me.panel_destroy.Name = "panel_destroy"
        Me.panel_destroy.Size = New System.Drawing.Size(985, 1)
        Me.panel_destroy.TabIndex = 0
        '
        'panel_container
        '
        Me.panel_container.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel_container.BackColor = System.Drawing.Color.Transparent
        Me.panel_container.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.panel_container.Controls.Add(Me.lbl_wave_clear)
        Me.panel_container.Controls.Add(Me.bullet)
        Me.panel_container.Controls.Add(Me.panel_destroy)
        Me.panel_container.Controls.Add(Me.waveLbl)
        Me.panel_container.Controls.Add(Me.lbl_score)
        Me.panel_container.Controls.Add(Me.tank)
        Me.panel_container.Controls.Add(Me.ptbox_destroy)
        Me.panel_container.Controls.Add(Me.ptbox_tank_destroy)
        Me.panel_container.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel_container.Location = New System.Drawing.Point(0, 0)
        Me.panel_container.Name = "panel_container"
        Me.panel_container.Size = New System.Drawing.Size(985, 608)
        Me.panel_container.TabIndex = 1
        '
        'lbl_wave_clear
        '
        Me.lbl_wave_clear.AutoSize = True
        Me.lbl_wave_clear.Font = New System.Drawing.Font("Impact", 99.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wave_clear.Location = New System.Drawing.Point(126, 62)
        Me.lbl_wave_clear.Name = "lbl_wave_clear"
        Me.lbl_wave_clear.Size = New System.Drawing.Size(732, 161)
        Me.lbl_wave_clear.TabIndex = 7
        Me.lbl_wave_clear.Text = "Wave Clear!"
        Me.lbl_wave_clear.Visible = False
        '
        'bullet
        '
        Me.bullet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bullet.BackColor = System.Drawing.Color.Transparent
        Me.bullet.Image = Global.TypingStabler1.My.Resources.Resources.bullet
        Me.bullet.Location = New System.Drawing.Point(-43, -39)
        Me.bullet.Name = "bullet"
        Me.bullet.Size = New System.Drawing.Size(32, 32)
        Me.bullet.TabIndex = 6
        Me.bullet.TabStop = False
        Me.bullet.Visible = False
        '
        'ptbox_destroy
        '
        Me.ptbox_destroy.BackColor = System.Drawing.Color.Transparent
        Me.ptbox_destroy.Image = Global.TypingStabler1.My.Resources.Resources.explosion
        Me.ptbox_destroy.Location = New System.Drawing.Point(0, 0)
        Me.ptbox_destroy.Name = "ptbox_destroy"
        Me.ptbox_destroy.Size = New System.Drawing.Size(0, 0)
        Me.ptbox_destroy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ptbox_destroy.TabIndex = 5
        Me.ptbox_destroy.TabStop = False
        '
        'ptbox_tank_destroy
        '
        Me.ptbox_tank_destroy.BackColor = System.Drawing.Color.Transparent
        Me.ptbox_tank_destroy.Location = New System.Drawing.Point(436, 496)
        Me.ptbox_tank_destroy.Name = "ptbox_tank_destroy"
        Me.ptbox_tank_destroy.Size = New System.Drawing.Size(128, 110)
        Me.ptbox_tank_destroy.TabIndex = 0
        Me.ptbox_tank_destroy.TabStop = False
        Me.ptbox_tank_destroy.Visible = False
        '
        'timer_shoot
        '
        Me.timer_shoot.Interval = 1
        '
        'timer_destroy
        '
        Me.timer_destroy.Interval = 600
        '
        'timer_global
        '
        Me.timer_global.Enabled = True
        Me.timer_global.Interval = 25
        '
        'gameGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(985, 608)
        Me.Controls.Add(Me.input)
        Me.Controls.Add(Me.panel_container)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "gameGUI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Spacebar Defenders"
        CType(Me.tank, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel_container.ResumeLayout(False)
        Me.panel_container.PerformLayout()
        CType(Me.bullet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbox_destroy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbox_tank_destroy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents input As System.Windows.Forms.TextBox
    Friend WithEvents timer_shuffle As System.Windows.Forms.Timer
    Friend WithEvents tank As System.Windows.Forms.PictureBox
    Friend WithEvents lbl_score As System.Windows.Forms.Label
    Friend WithEvents waveLbl As System.Windows.Forms.Label
    Friend WithEvents panel_destroy As System.Windows.Forms.Panel
    Friend WithEvents panel_container As System.Windows.Forms.Panel
    Friend WithEvents timer_shoot As System.Windows.Forms.Timer
    Friend WithEvents timer_destroy As System.Windows.Forms.Timer
    Friend WithEvents ptbox_tank_destroy As System.Windows.Forms.PictureBox
    Friend WithEvents ptbox_destroy As System.Windows.Forms.PictureBox
    Friend WithEvents bullet As System.Windows.Forms.PictureBox
    Friend WithEvents timer_global As System.Windows.Forms.Timer
    Friend WithEvents lbl_wave_clear As System.Windows.Forms.Label

End Class
