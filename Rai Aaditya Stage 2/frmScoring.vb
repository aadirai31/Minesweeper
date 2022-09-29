Public Class frmScoring
    Private Sub frmScoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'shows different text for different results
        If win = True Then
            lblResult.Text = "Congratulations " & playerName & "! You won!"
            lblClicks.Text = "Clicks Taken: " & currentScore
            lblTime.Text = "Game Time: " & timer & " seconds"
            lblMinesDefused.Text = "Mines Defused: " & flagged
        Else
            lblResult.Text = "Better luck next time " & playerName & ". You clicked a mine!"
            lblClicks.Text = ""
            lblTime.Text = ""
            lblMinesDefused.Text = ""
        End If
    End Sub

    Private Sub lblPlayAgain_Click(sender As Object, e As EventArgs) Handles lblPlayAgain.Click
        frmGame.Show()
        Me.Close()
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        frmStartup.Show()
        Me.Close()
    End Sub
End Class