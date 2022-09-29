<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStartup
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
        Me.lblMinesweeper = New System.Windows.Forms.Label()
        Me.lblEnterName = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.grpDifficulty = New System.Windows.Forms.GroupBox()
        Me.optExpert = New System.Windows.Forms.RadioButton()
        Me.optBeginner = New System.Windows.Forms.RadioButton()
        Me.optIntermediate = New System.Windows.Forms.RadioButton()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.grpDifficulty.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblMinesweeper
        '
        Me.lblMinesweeper.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMinesweeper.AutoSize = True
        Me.lblMinesweeper.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblMinesweeper.ForeColor = System.Drawing.Color.Red
        Me.lblMinesweeper.Location = New System.Drawing.Point(434, 75)
        Me.lblMinesweeper.Name = "lblMinesweeper"
        Me.lblMinesweeper.Size = New System.Drawing.Size(656, 128)
        Me.lblMinesweeper.TabIndex = 0
        Me.lblMinesweeper.Text = "Minesweeper"
        Me.lblMinesweeper.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblEnterName
        '
        Me.lblEnterName.AutoSize = True
        Me.lblEnterName.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lblEnterName.Location = New System.Drawing.Point(550, 203)
        Me.lblEnterName.Name = "lblEnterName"
        Me.lblEnterName.Size = New System.Drawing.Size(425, 70)
        Me.lblEnterName.TabIndex = 1
        Me.lblEnterName.Text = "Enter Your Name:"
        Me.lblEnterName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(675, 287)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(173, 31)
        Me.txtName.TabIndex = 2
        '
        'grpDifficulty
        '
        Me.grpDifficulty.Controls.Add(Me.optExpert)
        Me.grpDifficulty.Controls.Add(Me.optBeginner)
        Me.grpDifficulty.Controls.Add(Me.optIntermediate)
        Me.grpDifficulty.Location = New System.Drawing.Point(612, 351)
        Me.grpDifficulty.Name = "grpDifficulty"
        Me.grpDifficulty.Size = New System.Drawing.Size(300, 150)
        Me.grpDifficulty.TabIndex = 3
        Me.grpDifficulty.TabStop = False
        '
        'optExpert
        '
        Me.optExpert.AutoSize = True
        Me.optExpert.Location = New System.Drawing.Point(6, 100)
        Me.optExpert.Name = "optExpert"
        Me.optExpert.Size = New System.Drawing.Size(86, 29)
        Me.optExpert.TabIndex = 6
        Me.optExpert.TabStop = True
        Me.optExpert.Text = "Expert"
        Me.optExpert.UseVisualStyleBackColor = True
        '
        'optBeginner
        '
        Me.optBeginner.AutoSize = True
        Me.optBeginner.Location = New System.Drawing.Point(6, 30)
        Me.optBeginner.Name = "optBeginner"
        Me.optBeginner.Size = New System.Drawing.Size(106, 29)
        Me.optBeginner.TabIndex = 4
        Me.optBeginner.TabStop = True
        Me.optBeginner.Text = "Beginner"
        Me.optBeginner.UseVisualStyleBackColor = True
        '
        'optIntermediate
        '
        Me.optIntermediate.AutoSize = True
        Me.optIntermediate.Location = New System.Drawing.Point(6, 65)
        Me.optIntermediate.Name = "optIntermediate"
        Me.optIntermediate.Size = New System.Drawing.Size(128, 29)
        Me.optIntermediate.TabIndex = 5
        Me.optIntermediate.TabStop = True
        Me.optIntermediate.Text = "Intermidate"
        Me.optIntermediate.UseVisualStyleBackColor = True
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(657, 519)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(211, 95)
        Me.btnPlay.TabIndex = 4
        Me.btnPlay.Text = "Play!"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'frmStartup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1501, 877)
        Me.Controls.Add(Me.btnPlay)
        Me.Controls.Add(Me.grpDifficulty)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblEnterName)
        Me.Controls.Add(Me.lblMinesweeper)
        Me.Name = "frmStartup"
        Me.Text = "Minesweeper"
        Me.grpDifficulty.ResumeLayout(False)
        Me.grpDifficulty.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblMinesweeper As Label
    Friend WithEvents lblEnterName As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents optBeginner As RadioButton
    Friend WithEvents optIntermediate As RadioButton
    Friend WithEvents optExpert As RadioButton
    Friend WithEvents btnPlay As Button
    Friend WithEvents grpDifficulty As GroupBox
End Class
