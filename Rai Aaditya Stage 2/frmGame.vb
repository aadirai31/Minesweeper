Public Class frmGame
    'define global file variables
    Dim dimensions As Array
    Dim xLength As Integer
    Dim yLength As Integer
    Dim mines As Integer
    Dim arrGrid(0, 0) As Integer
    Dim recGrid(0, 0) As recMine
    Dim arrMineLocations(0, 0) As Integer
    Dim firstClick As Boolean
    Dim lblArray(0, 0) As Label


    Public Structure recMine
        'record which holds information about mines
        Public minesTouching As Integer
        Public state As String
        Public Mine As Boolean
    End Structure

    'higher level sub - respobsible for generating the playing grid
    Private Sub generateGrid()
        dimensions = gridDimensions(difficulty)
        'sets global dimension variables from grdDimensions function
        xLength = dimensions(0)
        yLength = dimensions(1)
        mines = dimensions(2)
        'redefine variables according to difficulty specifications
        ReDim arrGrid(xLength, yLength)
        ReDim recGrid(xLength, yLength)
        ReDim arrMineLocations(mines, 1)
        'generate playing grid
        arrMineLocations = assignMineLocation(yLength, xLength, mines)
        recGrid = assignGrid(arrMineLocations, arrGrid)
        ReDim lblArray(xLength, yLength)
        'shows playing grid
        showGrid()
        firstClick = True
    End Sub

    'handles click events of grid
    Private Sub gridClick(arrMineLocations As Array, clickedGrid As String, leftClick As Boolean)
        Dim gridLocation(1) As Integer
        Dim arrChar As Array
        Dim isMine As Boolean

        'converts label name to grid index 
        clickedGrid = Strings.Mid(clickedGrid, 4, 5)
        arrChar = Split(clickedGrid, ",")
        gridLocation(0) = CInt(arrChar(0))
        gridLocation(1) = CInt(arrChar(1))

        'check if clicked grid is mine
        For i = 1 To xLength
            For n = 1 To yLength
                For counter = 0 To mines
                    If checkMine(arrMineLocations, counter, gridLocation) = True Then
                        isMine = True
                    End If
                Next counter
            Next n
        Next i

        'cases for different types of clicks on different states of squares
        Select Case leftClick
            'right click cases
            Case False
                Select Case recGrid(gridLocation(0), gridLocation(1)).state
                    'case right click and covered - flags mine and updates UI and variables
                    Case "covered"
                        flagged = flagged + 1
                        recGrid(gridLocation(0), gridLocation(1)).state = "flagged"
                        Dim text As String
                        text = flagged
                        If text <= 9 Then
                            text = "00" & text
                        ElseIf text > 9 And text <= 99 Then
                            text = "0" & text
                        End If
                        Dim label As Label
                        label = Me.Controls.Find(lblArray(gridLocation(0), gridLocation(1)).Name, False).FirstOrDefault()
                        label.Text = "F"
                        label.ForeColor = System.Drawing.Color.Red
                        lblFlagged.Text = text
                    'case right click and flagged - unflags mine and updates UI and variables
                    Case "flagged"
                        flagged = flagged - 1
                        recGrid(gridLocation(0), gridLocation(1)).state = "covered"
                        Dim text As String
                        text = flagged
                        If text <= 9 Then
                            text = "00" & text
                        Else
                            text = "0" & text
                        End If
                        Dim label As Label
                        label = Me.Controls.Find(lblArray(gridLocation(0), gridLocation(1)).Name, False).FirstOrDefault()
                        label.Text = ""
                        label.ForeColor = SystemColors.ControlText
                End Select
            'left click cases
            'case left click and is mine
            Case True And isMine = True And recGrid(gridLocation(0), gridLocation(1)).state = "covered"
                'protects first click
                If firstClick = True Then
                    protectFirstClick(gridLocation, arrMineLocations)
                    showGrid()
                    uncoverGrid(gridLocation)
                    currentScore = currentScore + 1
                Else
                    endGame()
                End If
                firstClick = False
            'case left click and is not mine
            Case True And isMine = False
                uncoverGrid(gridLocation)
                firstClick = False
                currentScore = currentScore + 1
        End Select
        'check win after every click
        checkWin()
    End Sub

    'returns difficulty specifications based on user input
    Private Function gridDimensions(difficulty As String) As Array
        Dim x As Integer
        Dim y As Integer
        Dim mines As Integer
        Dim output(2) As Integer

        If difficulty = "Beginner" Then
            x = 9
            y = 9
            mines = 10
        ElseIf difficulty = "Intermediate" Then
            x = 16
            y = 16
            mines = 40
        ElseIf difficulty = "Expert" Then
            x = 30
            y = 16
            mines = 99
        End If

        output(0) = x
        output(1) = y
        output(2) = mines

        Return output

    End Function

    'randomly generates mine locations
    Private Function assignMineLocation(yLength As Integer, xLength As Integer, mines As Integer) As Array
        Dim low As Integer
        Dim high As Integer
        Dim randNum As Integer
        Dim x As Integer
        Dim y As Integer
        Dim counter As Integer
        Dim repeated As Boolean
        Dim mineLocation(1) As Integer
        Dim arrMineLocations(mines, 1) As Integer
        counter = 0
        'loop until specified number of mines is reached
        Do
            low = 1
            high = yLength * xLength
            'generate random number and find its x and y coordinates
            randNum = RndBetween(low, high)
            x = findX(xLength, randNum)
            y = findY(x, xLength, randNum)
            mineLocation(0) = x
            mineLocation(1) = y

            'check if the generated mine is already a mine
            If counter >= 1 Then
                repeated = checkRepeat(mineLocation, arrMineLocations, counter)
            End If

            If repeated = False Then
                arrMineLocations(counter, 0) = mineLocation(0)
                arrMineLocations(counter, 1) = mineLocation(1)
                counter = counter + 1
            End If

        Loop Until counter >= mines

        Return arrMineLocations

    End Function

    Public Function RndBetween(low As Integer, high As Integer) As Integer
        Randomize()
        Return Int((high - low + 1) * Rnd()) + low
    End Function

    'finds x coordinate of grid
    Private Function findX(xLength As String, randNum As Integer) As Integer
        Dim x As Integer

        x = randNum Mod xLength

        If x = 0 Then
            x = xLength
        End If

        Return x

    End Function

    'finds y coordinate of grid
    Private Function findY(x As Integer, xLength As String, randNum As Integer) As Integer
        Dim y As Integer

        y = ((randNum - x) / xLength) + 1

        Return y

    End Function

    'checks if a mine is already a mine
    Private Function checkRepeat(mineLocation As Array, arrMineLocations As Array, currentLength As Integer) As Boolean
        Dim repeated As Boolean
        Dim i As Integer = 0
        While i < currentLength And repeated = False
            repeated = checkMine(arrMineLocations, i, mineLocation)
            i = i + 1
        End While
        Return repeated
    End Function

    'populates the array of recGrid based on mine locations
    Private Function assignGrid(arrMineLocations As Array, arrGrid As Array) As Array
        Dim touching As Integer
        Dim recGrid(xLength, yLength) As recMine
        For i = 1 To xLength
            For n = 1 To yLength
                Dim isMine As Boolean
                Dim checkGrid(1) As Integer

                checkGrid(0) = i
                checkGrid(1) = n
                isMine = False
                'checks if current grid is mine
                For counter = 0 To mines
                    If checkMine(arrMineLocations, counter, checkGrid) = True Then
                        isMine = True
                    End If
                Next counter
                'set record information for that grid
                touching = checkTouching(checkGrid, arrMineLocations, arrGrid)
                recGrid(i, n).minesTouching = touching
                recGrid(i, n).Mine = isMine
                recGrid(i, n).state = "covered"
            Next n
        Next i

        Return recGrid
    End Function

    'checks if input is a mine based on arrMineLocations
    Private Function checkMine(checkAgainstGrid As Array, counter As Integer, gridLocation As Array) As Boolean
        Dim isMine As Boolean
        If checkAgainstGrid(counter, 0) = gridLocation(0) And checkAgainstGrid(counter, 1) = gridLocation(1) Then
            isMine = True
        End If
        Return isMine
    End Function

    'determines how many mines a grid is touching
    Private Function checkTouching(gridLocation As Array, arrMineLocations As Array, arrGrid As Array) As Integer
        Dim minesTouching As Integer
        minesTouching = 0
        If gridLocation(0) = 1 And gridLocation(1) = 1 Then
            'case for top left corner
            For n = 0 To 2
                'loops through all surrounding squares and checks if it is mine - same process for all below cases, only surrounding squares differ
                Dim yChange As Integer
                Dim xChange As Integer
                Dim checkMineLocation(1) As Integer
                Dim arrChangeLengths As Array

                'finds which squares are around that grid (different for corneres, edges etc)
                arrChangeLengths = checkSurroundingGrids(gridLocation)

                xChange = arrChangeLengths(n, 0)
                yChange = arrChangeLengths(n, 1)


                checkMineLocation(0) = gridLocation(0) + xChange
                checkMineLocation(1) = gridLocation(1) + yChange

                'checks if mine
                For i = 0 To mines
                    If checkMine(arrMineLocations, i, checkMineLocation) = True Then
                        minesTouching = minesTouching + 1
                    End If
                Next i
            Next n
        ElseIf gridLocation(0) = xLength And gridLocation(1) = 1 Then
            'case for top right corner
            For n = 0 To 2
                Dim yChange As Integer
                Dim xChange As Integer
                Dim checkMineLocation(1) As Integer
                Dim arrChangeLengths As Array

                arrChangeLengths = checkSurroundingGrids(gridLocation)

                xChange = arrChangeLengths(n, 0)
                yChange = arrChangeLengths(n, 1)

                checkMineLocation(0) = gridLocation(0) + xChange
                checkMineLocation(1) = gridLocation(1) + yChange

                For i = 0 To mines
                    If checkMine(arrMineLocations, i, checkMineLocation) = True Then
                        minesTouching = minesTouching + 1
                    End If
                Next i
            Next n
        ElseIf gridLocation(0) = 1 And gridLocation(1) = yLength Then
            'case for bottom left corner
            For n = 0 To 2
                Dim yChange As Integer
                Dim xChange As Integer
                Dim checkMineLocation(1) As Integer
                Dim arrChangeLengths As Array

                arrChangeLengths = checkSurroundingGrids(gridLocation)

                xChange = arrChangeLengths(n, 0)
                yChange = arrChangeLengths(n, 1)
                checkMineLocation(0) = gridLocation(0) + xChange
                checkMineLocation(1) = gridLocation(1) + yChange

                For i = 0 To mines
                    If checkMine(arrMineLocations, i, checkMineLocation) = True Then
                        minesTouching = minesTouching + 1
                    End If
                Next i
            Next n
        ElseIf gridLocation(0) = xLength And gridLocation(1) = yLength Then
            'case for bottom right corner
            For n = 0 To 2
                Dim yChange As Integer
                Dim xChange As Integer
                Dim checkMineLocation(1) As Integer
                Dim arrChangeLengths As Array

                arrChangeLengths = checkSurroundingGrids(gridLocation)
                xChange = arrChangeLengths(n, 0)
                yChange = arrChangeLengths(n, 1)
                checkMineLocation(0) = gridLocation(0) + xChange
                checkMineLocation(1) = gridLocation(1) + yChange

                For i = 0 To mines
                    If checkMine(arrMineLocations, i, checkMineLocation) = True Then
                        minesTouching = minesTouching + 1
                    End If
                Next i
            Next n

        ElseIf gridLocation(1) = 1 Then
            'case for top row
            For n = 0 To 4
                Dim yChange As Integer
                Dim xChange As Integer
                Dim checkMineLocation(1) As Integer
                Dim arrChangeLengths As Array
                arrChangeLengths = checkSurroundingGrids(gridLocation)
                xChange = arrChangeLengths(n, 0)
                yChange = arrChangeLengths(n, 1)
                checkMineLocation(0) = gridLocation(0) + xChange
                checkMineLocation(1) = gridLocation(1) + yChange

                For i = 0 To mines
                    If checkMine(arrMineLocations, i, checkMineLocation) = True Then
                        minesTouching = minesTouching + 1
                    End If
                Next i
            Next n
        ElseIf gridLocation(1) = yLength Then
            'case for bottom row 
            For n = 0 To 4
                Dim yChange As Integer
                Dim xChange As Integer
                Dim checkMineLocation(1) As Integer
                Dim arrChangeLengths As Array
                arrChangeLengths = checkSurroundingGrids(gridLocation)
                xChange = arrChangeLengths(n, 0)
                yChange = arrChangeLengths(n, 1)
                checkMineLocation(0) = gridLocation(0) + xChange
                checkMineLocation(1) = gridLocation(1) + yChange

                For i = 0 To mines
                    If checkMine(arrMineLocations, i, checkMineLocation) = True Then
                        minesTouching = minesTouching + 1
                    End If
                Next i
            Next n
        ElseIf gridLocation(0) = 1 Then
            'case for left column
            For n = 0 To 4
                Dim yChange As Integer
                Dim xChange As Integer
                Dim checkMineLocation(1) As Integer
                Dim arrChangeLengths As Array

                arrChangeLengths = checkSurroundingGrids(gridLocation)
                xChange = arrChangeLengths(n, 0)
                yChange = arrChangeLengths(n, 1)
                checkMineLocation(0) = gridLocation(0) + xChange
                checkMineLocation(1) = gridLocation(1) + yChange

                For i = 0 To mines
                    If checkMine(arrMineLocations, i, checkMineLocation) = True Then
                        minesTouching = minesTouching + 1
                    End If
                Next i
            Next n
        ElseIf gridLocation(0) = xLength Then
            'case for right column
            For n = 0 To 4
                Dim yChange As Integer
                Dim xChange As Integer
                Dim checkMineLocation(1) As Integer
                Dim arrChangeLengths As Array

                arrChangeLengths = checkSurroundingGrids(gridLocation)
                xChange = arrChangeLengths(n, 0)
                yChange = arrChangeLengths(n, 1)
                checkMineLocation(0) = gridLocation(0) + xChange
                checkMineLocation(1) = gridLocation(1) + yChange

                For i = 0 To mines
                    If checkMine(arrMineLocations, i, checkMineLocation) = True Then
                        minesTouching = minesTouching + 1
                    End If
                Next i
            Next n
        Else
            For n = 0 To 7
                Dim yChange As Integer
                Dim xChange As Integer
                Dim checkMineLocation(1) As Integer
                Dim arrChangeLengths As Array

                arrChangeLengths = checkSurroundingGrids(gridLocation)
                xChange = arrChangeLengths(n, 0)
                yChange = arrChangeLengths(n, 1)
                checkMineLocation(0) = gridLocation(0) + xChange
                checkMineLocation(1) = gridLocation(1) + yChange

                For i = 0 To mines
                    If checkMine(arrMineLocations, i, checkMineLocation) = True Then
                        minesTouching = minesTouching + 1
                    End If
                Next i
            Next n

        End If

        Return minesTouching
    End Function

    Private Function checkSurroundingGrids(gridLocation As Array) As Array
        'cases for each differnt grid - e.g corners, top/bottom/left/right edge, rest of grid
        'returns the position change to be added to current grid to get surrounding grids
        Select Case gridLocation(0)
            Case = 1 And gridLocation(1) = 1
                'case for top left corner
                Dim output(2, 1) As Integer
                output(0, 0) = 1
                output(0, 1) = 0
                output(1, 0) = 0
                output(1, 1) = 1
                output(2, 0) = 1
                output(2, 1) = 1
                Return output
            Case xLength And gridLocation(1) = 1
                'case for top right corner
                Dim output(2, 1) As Integer
                output(0, 0) = -1
                output(0, 1) = 0
                output(1, 0) = -1
                output(1, 1) = 1
                output(2, 0) = 0
                output(2, 1) = 1
                Return output
            Case = 1 And gridLocation(1) = yLength
                'case for bottom left corner
                Dim output(2, 1) As Integer
                output(0, 0) = 1
                output(0, 1) = 0
                output(1, 0) = 0
                output(1, 1) = -1
                output(2, 0) = 1
                output(2, 1) = -1
                Return output
            Case = xLength And gridLocation(1) = yLength
                'case for bottom right corner
                Dim output(2, 1) As Integer
                output(0, 0) = -1
                output(0, 1) = 0
                output(1, 0) = 0
                output(1, 1) = -1
                output(2, 0) = -1
                output(2, 1) = -1
                Return output
            Case = 1
                'case for left column
                Dim output(4, 1) As Integer
                output(0, 0) = 0
                output(0, 1) = -1
                output(1, 0) = 1
                output(1, 1) = -1
                output(2, 0) = 1
                output(2, 1) = 0
                output(3, 0) = 1
                output(3, 1) = 1
                output(4, 0) = 0
                output(4, 1) = 1
                Return output
            Case = xLength
                'case for right column
                Dim output(4, 1) As Integer
                output(0, 0) = 0
                output(0, 1) = -1
                output(1, 0) = -1
                output(1, 1) = -1
                output(2, 0) = -1
                output(2, 1) = 0
                output(3, 0) = -1
                output(3, 1) = 1
                output(4, 0) = 0
                output(4, 1) = 1
                Return output
            Case Else
                Select Case gridLocation(1)
                    Case = 1
                        'case for top row
                        Dim output(4, 1) As Integer
                        output(0, 0) = -1
                        output(0, 1) = 0
                        output(1, 0) = 1
                        output(1, 1) = 0
                        output(2, 0) = -1
                        output(2, 1) = 1
                        output(3, 0) = 0
                        output(3, 1) = 1
                        output(4, 0) = 1
                        output(4, 1) = 1
                        Return output
                    Case = yLength
                        'case for bottom row 
                        Dim output(4, 1) As Integer
                        output(0, 0) = -1
                        output(0, 1) = 0
                        output(1, 0) = 1
                        output(1, 1) = 0
                        output(2, 0) = -1
                        output(2, 1) = -1
                        output(3, 0) = 0
                        output(3, 1) = -1
                        output(4, 0) = 1
                        output(4, 1) = -1
                        Return output
                    Case Else
                        'case for rest of grid squares
                        Dim output(7, 1) As Integer
                        output(0, 0) = -1
                        output(0, 1) = -1
                        output(1, 0) = 0
                        output(1, 1) = -1
                        output(2, 0) = 1
                        output(2, 1) = -1
                        output(3, 0) = -1
                        output(3, 1) = 0
                        output(4, 0) = 1
                        output(4, 1) = 0
                        output(5, 0) = -1
                        output(5, 1) = 1
                        output(6, 0) = 0
                        output(6, 1) = 1
                        output(7, 0) = 1
                        output(7, 1) = 1
                        Return output
                End Select
        End Select

    End Function

    Private Sub protectFirstClick(clickedGrid As Array, arrMineLocations As Array)
        Dim isMine As Boolean
        Dim checkNewGridMine As Boolean
        Dim newGridLocation(1) As Integer
        Dim mineIndex As Integer
        Dim counter As Integer
        Dim yChange As Integer
        Dim xChange As Integer
        Dim arrMineChangeLength As Array

        'gets the index of the mine in arrMineLocations
        For i = 0 To mines
            If checkMine(arrMineLocations, i, clickedGrid) = True Then
                isMine = True
                mineIndex = i
            End If
        Next i
        counter = 0
        If isMine = True Then
            Do
                'gets a grid from nearby
                arrMineChangeLength = checkSurroundingGrids(clickedGrid)
                xChange = arrMineChangeLength(counter, 0)
                yChange = arrMineChangeLength(counter, 1)
                newGridLocation(0) = clickedGrid(0) + xChange
                newGridLocation(1) = clickedGrid(1) + yChange

                'moves mine to first surrounding square that isnt a mine
                For i = 0 To mines
                    If checkMine(arrMineLocations, i, newGridLocation) = True Then
                        checkNewGridMine = True
                    Else
                        If newGridLocation(0) <= 0 Or newGridLocation(0) > xLength Or newGridLocation(1) <= 0 Or newGridLocation(1) > xLength Then
                            checkNewGridMine = True
                        Else
                            checkNewGridMine = False
                        End If
                    End If
                Next i
                counter = counter + 1
            Loop Until checkNewGridMine = False

            'changes old mine location to new mine location
            arrMineLocations(mineIndex, 0) = newGridLocation(0)
            arrMineLocations(mineIndex, 1) = newGridLocation(1)

            'reassigns grid with new mine locations
            recGrid = assignGrid(arrMineLocations, arrGrid)
        End If
    End Sub

    'uncovers grid squares
    Private Function uncoverGrid(clickedGrid As Array) As String
        Dim currentMineRec As recMine
        currentMineRec = recGrid(clickedGrid(0), clickedGrid(1))
        If currentMineRec.Mine = False Then
            'uncover the clicked grid
            If currentMineRec.state = "covered" Then
                recGrid(clickedGrid(0), clickedGrid(1)).state = "uncovered"
            End If
            'case if clicked grid is a 0 - flutter 
            If currentMineRec.minesTouching = 0 Then
                Dim arrMineChangeLength As Array
                Dim xChange, yChange As Integer
                Dim newGridLocation(1) As Integer
                'checks if surrounding grids are 0
                arrMineChangeLength = checkSurroundingGrids(clickedGrid)
                For i = 0 To (arrMineChangeLength.Length - 2) / 2
                    xChange = arrMineChangeLength(i, 0)
                    yChange = arrMineChangeLength(i, 1)
                    newGridLocation(0) = clickedGrid(0) + xChange
                    newGridLocation(1) = clickedGrid(1) + yChange
                    'if grid is 0 call uncoverGrid and whole function is run again - recursion
                    If recGrid(newGridLocation(0), newGridLocation(1)).minesTouching = 0 And recGrid(newGridLocation(0), newGridLocation(1)).state = "covered" Then
                        uncoverGrid(newGridLocation)
                        'else not 0 set state to uncovered
                    Else
                        recGrid(newGridLocation(0), newGridLocation(1)).state = "uncovered"
                    End If
                Next i

            End If
            'handles the UI of uncovering the grid
            uncoverGridUI()
        End If
    End Function

    Private Sub uncoverGridUI()
        'changes background colour of grids with state uncovered
        'credit to Thomas Fahey for helping me with this code which has also been used in other parts of the program
        For i = 1 To xLength
            For n = 1 To yLength
                If recGrid(i, n).state = "uncovered" Then
                    Dim label As Label
                    label = Me.Controls.Find(lblArray(i, n).Name, False).FirstOrDefault()
                    label.BackColor = SystemColors.ControlLight
                    label.Text = recGrid(i, n).minesTouching
                End If
            Next n
        Next i
    End Sub

    Private Sub endGame()
        'close form and show scoring form
        frmScoring.Show()
        Me.Close()
    End Sub

    'checks if number of uncovered squares is equal to total squares minus mines (if all squares are uncovered)
    Private Sub checkWin()
        Dim uncoveredSquares As Integer
        Dim uncoveredCounter As Integer
        uncoveredSquares = xLength * yLength - mines
        uncoveredCounter = 0
        For i = 1 To xLength
            For n = 1 To yLength
                If recGrid(i, n).state = "uncovered" Then
                    uncoveredCounter = uncoveredCounter + 1
                End If
            Next n
        Next i
        If uncoveredCounter = uncoveredSquares Then
            win = True
            frmScoring.Show()
            Me.Close()
        End If
    End Sub

    'gets left click or right click - passes to grid click function
    Private Sub getTypeClick(sender As Object, e As MouseEventArgs)
        'https://www.youtube.com/watch?v=GF18GHvs_3g
        If e.Button = MouseButtons.Left Then
            gridClick(arrMineLocations, sender.name, True)
        ElseIf e.Button = MouseButtons.Right Then
            gridClick(arrMineLocations, sender.name, False)
        End If
    End Sub

    'initialise global variables and UI
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblName.Text = playerName
        lblName.Left = lblHome.Left - lblName.Width - 10
        lblName.Top = lblHome.Top
        generateGrid()
        tmrStopwatch.Enabled = True
        currentScore = 0
        flagged = 0
        win = False
        timer = 0
    End Sub

    'automatically generate label grid - from Appendix A
    Private Sub showGrid()
        For i = 1 To xLength
            For n = 1 To yLength
                Dim label = New Label
                'data
                label.Name = "lbl" & i & "," & n
                label.Parent = Me
                'presentation
                label.Width = 25
                label.Height = 25
                label.Left = i * 30 + 20
                label.Top = 60 + 30 * n
                label.BackColor = SystemColors.ButtonShadow
                label.BorderStyle = BorderStyle.FixedSingle
                label.TextAlign = ContentAlignment.MiddleCenter
                lblArray(i, n) = label
                'make the labels clickable
                AddHandler label.Click, AddressOf getTypeClick
            Next n
        Next i
    End Sub

    'guidance recieved from https://www.wikihow.com/Add-a-Timer-in-Visual-Basic 
    Private Sub tmrStopwatch_Tick(sender As Object, e As EventArgs) Handles tmrStopwatch.Tick
        Dim timerText As String
        timer = timer + 1
        If timer <= 9 Then
            timerText = "00" & timer
        ElseIf timer > 9 And timer <= 99 Then
            timerText = "0" & timer
        ElseIf timer >= 999 Then
            timerText = "999"
        Else
            timerText = timer
        End If
        lblTimer.Text = timerText
        If lblTimer.Text = 0 Then
            tmrStopwatch.Enabled = False
        End If
    End Sub

    Private Sub lblHome_Click(sender As Object, e As EventArgs) Handles lblHome.Click
        frmStartup.Show()
        Me.Close()
    End Sub
End Class
