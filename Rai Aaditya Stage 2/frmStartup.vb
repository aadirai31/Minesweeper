Public Class frmStartup
    Private Function validatePlayerName(name As String) As Boolean
        'checks if player name between 2 and 10 characters
        If name.Length < 2 Or name.Length > 10 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function getDifficulty() As String
        'retrieves difficulty
        Dim difficulty As String
        If optBeginner.Checked = True Then
            difficulty = "Beginner"
        End If
        If optIntermediate.Checked = True Then
            difficulty = "Intermediate"
        End If
        If optExpert.Checked = True Then
            difficulty = "Expert"
        End If
        If optBeginner.Checked = False And optIntermediate.Checked = False And optExpert.Checked = False Then
            difficulty = "null"
        End If
        Return difficulty
    End Function
    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        Dim validPlayerName As Boolean
        playerName = txtName.Text
        validPlayerName = validatePlayerName(playerName)
        'sets global difficulty variable
        difficulty = getDifficulty()
        If validPlayerName = False Then
            MsgBox("Warning: Player name must be 2-10 characters long")
        End If
        'make sure difficulty has been selected
        If difficulty = "null" Then
            MsgBox("Warning: You have not selected a difficulty")
        End If
        'show game form
        If validPlayerName = True And difficulty <> "null" Then
            Me.Hide()
            frmGame.Show()
        End If
    End Sub
End Class