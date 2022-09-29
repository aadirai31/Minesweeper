<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScoring
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
        Me.lblTime = New System.Windows.Forms.Label()
        Me.lblClicks = New System.Windows.Forms.Label()
        Me.lblMinesDefused = New System.Windows.Forms.Label()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.lblPlayAgain = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblMinesweeper
        '
        Me.lblMinesweeper.AutoSize = True
        Me.lblMinesweeper.Font = New System.Drawing.Font("Segoe UI", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblMinesweeper.ForeColor = System.Drawing.Color.Red
        Me.lblMinesweeper.Location = New System.Drawing.Point(434, 75)
        Me.lblMinesweeper.Name = "lblMinesweeper"
        Me.lblMinesweeper.Size = New System.Drawing.Size(656, 128)
        Me.lblMinesweeper.TabIndex = 1
        Me.lblMinesweeper.Text = "Minesweeper"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblTime.Location = New System.Drawing.Point(448, 260)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(600, 70)
        Me.lblTime.TabIndex = 2
        Me.lblTime.Text = "Game Time: xx seconds"
        '
        'lblClicks
        '
        Me.lblClicks.AutoSize = True
        Me.lblClicks.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblClicks.Location = New System.Drawing.Point(448, 330)
        Me.lblClicks.Name = "lblClicks"
        Me.lblClicks.Size = New System.Drawing.Size(410, 70)
        Me.lblClicks.TabIndex = 3
        Me.lblClicks.Text = "Clicks Taken: xx"
        '
        'lblMinesDefused
        '
        Me.lblMinesDefused.AutoSize = True
        Me.lblMinesDefused.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.lblMinesDefused.Location = New System.Drawing.Point(448, 400)
        Me.lblMinesDefused.Name = "lblMinesDefused"
        Me.lblMinesDefused.Size = New System.Drawing.Size(477, 70)
        Me.lblMinesDefused.TabIndex = 4
        Me.lblMinesDefused.Text = "Mines Defused: xx"
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(518, 213)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(63, 25)
        Me.lblResult.TabIndex = 5
        Me.lblResult.Text = "Label1"
        '
        'lblPlayAgain
        '
        Me.lblPlayAgain.Location = New System.Drawing.Point(434, 521)
        Me.lblPlayAgain.Name = "lblPlayAgain"
        Me.lblPlayAgain.Size = New System.Drawing.Size(309, 91)
        Me.lblPlayAgain.TabIndex = 6
        Me.lblPlayAgain.Text = "Play Again!"
        Me.lblPlayAgain.UseVisualStyleBackColor = True
        '
        'btnHome
        '
        Me.btnHome.Location = New System.Drawing.Point(749, 521)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(309, 91)
        Me.btnHome.TabIndex = 7
        Me.btnHome.Text = "Go Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'frmScoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1501, 877)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.lblPlayAgain)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.lblMinesDefused)
        Me.Controls.Add(Me.lblClicks)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblMinesweeper)
        Me.Name = "frmScoring"
        Me.Text = "Minesweeper"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblMinesweeper As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents lblClicks As Label
    Friend WithEvents lblMinesDefused As Label
    Friend WithEvents lblResult As Label
    Friend WithEvents lblPlayAgain As Button
    Friend WithEvents btnHome As Button
End Class
