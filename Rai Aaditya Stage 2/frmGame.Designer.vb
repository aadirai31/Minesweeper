<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGame
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGame))
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblHome = New System.Windows.Forms.Label()
        Me.lblTimer = New System.Windows.Forms.Label()
        Me.lblFlagged = New System.Windows.Forms.Label()
        Me.tmrStopwatch = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblName.Name = "lblName"
        '
        'lblHome
        '
        resources.ApplyResources(Me.lblHome, "lblHome")
        Me.lblHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHome.Name = "lblHome"
        '
        'lblTimer
        '
        resources.ApplyResources(Me.lblTimer, "lblTimer")
        Me.lblTimer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTimer.ForeColor = System.Drawing.Color.Red
        Me.lblTimer.Name = "lblTimer"
        '
        'lblFlagged
        '
        resources.ApplyResources(Me.lblFlagged, "lblFlagged")
        Me.lblFlagged.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFlagged.ForeColor = System.Drawing.Color.Red
        Me.lblFlagged.Name = "lblFlagged"
        '
        'tmrStopwatch
        '
        Me.tmrStopwatch.Interval = 1000
        '
        'frmGame
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.lblFlagged)
        Me.Controls.Add(Me.lblTimer)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblHome)
        Me.Name = "frmGame"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents lstOutput As ListView
    Friend WithEvents lblName As Label
    Friend WithEvents lblFlagged As Label
    Friend WithEvents lblTimer As Label
    Friend WithEvents lblHome As Label
    Friend WithEvents tmrStopwatch As Timer
End Class
