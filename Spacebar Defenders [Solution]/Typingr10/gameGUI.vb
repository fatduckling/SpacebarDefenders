Imports System.ComponentModel 

Public Class gameGUI
    Inherits System.Windows.Forms.Form
    Public typingword As Boolean = False
    Dim count As Integer = 0
    Public last As Integer
    Public matches(subsets.Length) As Boolean ' used to check whether user's input matches the word
    ' matches' is used through the word's tag.
    Public readText1 As String()
    Dim last_x As Integer  ' last X coordinate

    
    Dim y As Integer '  y posoition of the word
    Private Sub shuffle(ByVal rtBox As RichTextBox, ByVal textWord As String, ByVal tag As Integer)
        Dim spotx() As Integer = {10, 130, 250, 610, 730, 850} ' this is the x coordinate of the labels
        Dim randPos As Integer  ' 3,2 etc ' used to determine x coordinate
        'the beginning of the array has the offsets for increasing word lengths 
        'position 0 has the start of length 2 words
        'position 1 has the start of length 3 words... until position 25 which has the first word
        'there are gaps between word lengths as there are no words of length 24 for example

        Dim word_start = CInt(readText1(Wave - 1)) ' this is used to choose a random word
        Dim word_end = CInt(readText1(Wave + 3)) ' this is used to choose a random word
        ' x & y are the location of the word



        Dim x As Integer ' x position of the word
        Dim overlap_y As Boolean = True ' used to determine if words overlap (top down)
        Dim overlap_x As Boolean = True ' used to determine if words overlap (top down)

        rtBox.SelectionAlignment = HorizontalAlignment.Center
        rtBox.Text = readText1(rand.Next(word_start, word_end)) 'choose random word of permitted length

        rtBox.Tag = tag ' label's tag
        rtBox.ReadOnly = True ' make it look like a textbox

        ' choosign color start
        Select Case My.Settings.SelectedTextColor
            Case 1
                rtBox.ForeColor = Color.Blue
            Case 2
                rtBox.ForeColor = Color.Gray
            Case 3
                rtBox.ForeColor = Color.Green
            Case 4
                rtBox.ForeColor = Color.Pink
            Case 5
                rtBox.ForeColor = Color.Red
            Case 6
                rtBox.ForeColor = Color.Yellow
            Case 7
                rtBox.ForeColor = Color.Black
            Case Else
                rtBox.ForeColor = Color.White
        End Select


        Select Case My.Settings.SelectedTextBackColor
            Case 1
                rtBox.BackColor = Color.Blue
            Case 2
                rtBox.BackColor = Color.Gray
            Case 3
                rtBox.BackColor = Color.Green
            Case 4
                rtBox.BackColor = Color.Pink
            Case 5
                rtBox.BackColor = Color.Red
            Case 6
                rtBox.BackColor = Color.Yellow
            Case 7
                rtBox.BackColor = Color.Black
            Case Else
                rtBox.BackColor = Color.White
        End Select

        Select Case My.Settings.SelectedBulletColor
            Case 1
                bullet.Image = My.Resources.blue
            Case 2
                bullet.Image = My.Resources.gray
            Case 3
                bullet.Image = My.Resources.green
            Case 4
                bullet.Image = My.Resources.pink
            Case 5
                bullet.Image = My.Resources.red
            Case 6
                bullet.Image = My.Resources.yellow
            Case 7
                bullet.Image = My.Resources.bullet
            Case Else
                bullet.Image = My.Resources.white


        End Select

        'Verdana, 15.75pt

        ' choosign color end


        rtBox.BorderStyle = BorderStyle.None ' no border
        rtBox.ScrollBars = RichTextBoxScrollBars.None 'no scrollbars
        rtBox.Size = New Size(CInt(Math.Round((10 * (rtBox.Text.Length)) + 40)), 50)

        'make sure that the previous x is not the chosen one (used to flow the words throughout the form)
        x = spotx(randPos) ' x coordinate for label. it is, eg 12, etc
        If last_x = x Then
            If randPos = 4 Then
                randPos = -1
            End If
            ' this will ensure that the next x coordinate of the label will not be same as the previous one
            x = spotx(randPos + 1) ' x coordinate for label. it is, eg 12, etc
        End If
        'ensures that y coordinate of the words dont stack up on top of each other
        While overlap_y = True
            y = rand.Next(-1000, -10) ' y coordinate of label, randomly generated
            For Each word As richtextbox In subsets
                If tag <> word.Tag Then
                    If Math.Abs(word.Location.Y - y) < 70 Then
                        'this will check whether the word's Y label is overlapping or not
                        overlap_y = True
                        Exit For
                    Else
                        overlap_y = False
                    End If
                End If
            Next
        End While
        While overlap_x = True
            x = spotx(rand.Next(0, spotx.Length))
            For Each word As richtextbox In subsets
                If tag <> word.Tag Then
                    If (Math.Abs(word.Location.Y - y) < 600) And (word.Location.X = x) Then
                        'this will check whether the word's Y label is overlapping or not
                        overlap_x = True
                        Exit For
                    Else
                        overlap_x = False
                    End If
                End If
            Next
        End While

        last_x = x ' storing the last X coordinate to compare it with the next word
        rtBox.Location = New Point(x, y) ' location of lbl
        last = randPos

        rtBox.Visible = True
        rtBox.SelectionStart = 0 ' used to remove the bold of labels
        rtBox.SelectionLength = rtBox.Text.Length
        rtBox.SelectionFont = New Font(rtBox.Font, FontStyle.Regular)
        rtBox.SelectionAlignment = HorizontalAlignment.Center
        rtBox.Font = New Font("Verdana", My.Settings.fontSize, FontStyle.Regular)
        panel_container.Controls.Add(rtBox) ' adds words to container 
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        My.Settings.Save()
        home.Close()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.audio = 1 Then ' determines whether audio should be used
            audio = True
        Else
            audio = False
        End If
        Dim readText = My.Resources.wordsEn.Split(CChar(vbCrLf)) ' contains every english word
        Dim i As Integer = 0
        'read text is an array of every single english word (its in my resources)
        readText1 = readText.ToArray 'place array into global memory
        ' tag id's is used to ensure that the overlap detection detection works on the first pass
        For Each word As RichTextBox In subsets ' for each of the letter, we are assigning it with a new word
            word.Tag = i ' giving unique tag 
            i += 1 'increments i
        Next
        'generate the first words
        i = 0 ' reset i 
        For Each word As RichTextBox In subsets ' for each of the letter, we are assigning it with a new word
            ' shuffling the word in random form
            shuffle(word, readText1(i), i) ' reques word back of form
            i += 1 ' increments i
        Next

        For i = 0 To subsets.Length - 1
            matches(i) = False 'clear matches for typed words ; all matched words are false
        Next
        timer_shuffle.Start() ' starts the timer (used to make word move down)
        input.Select() ' input is a text box. it selects it (used to determine what user is typing)
        waveLbl.Text = "Wave: " & Wave

    End Sub
    Dim arrayNum As Integer
    Dim all_count As Integer ' used to know what position of letter user is typing
    Private Sub input_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles input.KeyPress
        'everytime user types a new letter, this will execute!
        Dim unboldWord As RichTextBox ' unbold word is a richtextbox
        Dim keypress = e.KeyChar ' what user types TEST  alert( keypress) 
        Dim one_match_found As Boolean = False  'check if we still have words on the screen we are currently matching
        For i As Integer = 0 To subsets.Length - 1
            ' this incremennts thourhg all the words, to check whether user is still in the progress of typing a word
            If matches(i) Then
                ' if any of dthe matches' tags words are true, then user is typing a word, so one_match_found = true
                one_match_found = True
            End If
        Next
        If one_match_found = False Then ' user is not typing a word
            all_count = 1 ' the last matching word fell off the bottom
        End If
        one_match_found = False

        'check each word
        For Each word As RichTextBox In subsets
            'for each of the words
            If word.Bounds.IntersectsWith(panel_container.Bounds) Then 'if it is visible from user's perspective
                'panel container covers entire form, so it'll only trigger if word is in the the panel
                If word.Text.Length > all_count Then

                    If keypress = word.Text.Substring(all_count, 1) Then 'matched first letter
                        If (all_count = 1) Then
                            matches(word.Tag) = True 'we all ways match the first letter
                        End If
                        shoot(word, (word.Location.X + (word.Size.Width / 2)), word.Location.Y + (word.Size.Height / 2), False) 'locates turret
                        If matches(word.Tag) Then 'we can only match if the beginning of the word is already matched
                            one_match_found = True 'we've got at least one letter matched
                            matches(word.Tag) = True
                            'this bolds the first letter
                            word.SelectionStart = 0
                            word.SelectionLength = all_count + 1
                            word.SelectionFont = New Font(word.Font, FontStyle.Bold)
                            ' from 0 to allcount +1, (first character) is bold

                            If all_count = word.Text.Length - 1 Then ' (end of the word, user typed it correctly)
                                shoot(word, (word.Location.X + (word.Size.Width / 2)), word.Location.Y + (word.Size.Height / 2), True) 'locates turret and fires
                                'we have matched a whole word - increase score and unbold everything
                                all_count = 1 ' reset all count
                                typingword = False ' reset whether user is typing a word

                                'requeue the word. 
                                score += 1
                                tempScore += 1
                                add_highscores.lbl_current_hs.Text = score
                                lbl_score.Text = score
                                If tempScore > Wave + levels_in_first_wave Then
                                    ' this is used to give user a break after each wave
                                    timer_shuffle.Stop() 'stopping timer so the other words don't continue to fall
                                    '   alert(New String("You have completed wave " + wave.ToString + ", prepare for the next!")) '*** http://www.functionx.com/vb/functions/msgbox.htm for customisation ***
                                    timer_shuffle.Start() ' start timer 
                                    Wave += 1
                                    waveLbl.Text = "Wave " & Wave
                                    waitingForNextWave = True ' we are now waiting for next wave
                                    waitedTimeForNextWave = 0 ' timer used to determine how long user has to wait.
                                    tempScore = 1
                                    transform(0)
                                End If
                                one_match_found = False ' reset typing a word
                                For i = 0 To subsets.Length - 1
                                    ' this is used to unbold every other word.
                                    unboldWord = CType(subsets(i), RichTextBox)
                                    If matches(i) Then 'unbold all other matching words
                                        unboldWord.SelectionStart = 0
                                        unboldWord.SelectionLength = word.Text.Length
                                        unboldWord.SelectionFont = New Font(word.Font, FontStyle.Regular)
                                        unboldWord.Font = New Font("Verdana", My.Settings.fontSize, FontStyle.Regular)
                                        matches(i) = False
                                    End If
                                    If waitingForNextWave = True Then
                                        unboldWord.Text = "" 'clear current words for new wave
                                    End If
                                Next
                                Exit For
                            End If
                        End If
                    ElseIf all_count > 1 Then 'we've got an incorrect letter and remove the match but keep other words
                        matches(word.Tag) = False
                        'unbold the word
                        word.SelectionStart = 0
                        word.SelectionLength = word.Text.Length
                        word.SelectionFont = New Font(word.Font, FontStyle.Regular)
                        word.Font = New Font("Verdana", My.Settings.fontSize, FontStyle.Regular)
                    End If ' all count > 1
                End If ' word.Text.Length > all_count
            End If ' word intersects with panel container
        Next
        If one_match_found = True Then
            all_count += 1 ' increment all count to get the next letter of the word
        End If
        input.Text = String.Empty ' everytime user types a letter, resets text box.
    End Sub
    Dim exploding As Boolean = False
    Private Sub shoot(ByVal word As RichTextBox, ByVal xCoordinate As Integer, ByVal yCoordinate As Integer, ByVal fire As Boolean)
        If xCoordinate >= 494 And yCoordinate <= 526 Then
            ' first quadrant
            angleToRotate = 90 - tan1((526 - yCoordinate) / (xCoordinate - 494))
        ElseIf xCoordinate <= 494 And yCoordinate <= 526 Then
            'secod quadrant
            angleToRotate = 270 + (tan1(((526 - yCoordinate) / (494 - xCoordinate)))) 'second quadrant
        ElseIf xCoordinate <= 494 And yCoordinate >= 526 Then
            angleToRotate = 270 + (tan1(((526 - yCoordinate) / (494 - xCoordinate)))) 'second quadrant
            'third quadrant
        Else
            '4th quadrant
            angleToRotate = 90 + (tan1(((526 - yCoordinate) / (494 - xCoordinate)))) 'second quadrant

        End If
        transform(angleToRotate)
        If fire Then ' if it is given the instruction to fire
            bullet.Location = New Point(494 - 16, 526 - 16) ' center the bullet from the `
            bullet_angle = angleToRotate 'used to position the bullet
            bullet_word_idx = word.Tag
            timer_shoot.Start()
            If audio Then
                ' ensures that audio is not played if user does not want it
                My.Computer.Audio.Play(My.Resources.shoot, AudioPlayMode.Background)
            End If

        Else
            If audio Then
                My.Computer.Audio.Play(My.Resources.trigger, AudioPlayMode.Background)
            End If

        End If


    End Sub
    Public Sub transform(ByVal angle As Double)
        'Load up an image from disk
        Dim imgOrig As Image = My.Resources.barrel
        'Make a copy
        Dim imgClone As Image = imgOrig.Clone
        'Create the graphics object to draw onto
        Dim g As Graphics = Graphics.FromImage(imgOrig)
        'Clear the picture and give us a black background
        g.Clear(Color.Transparent)

        'Translate to the cesnter of the image
        g.TranslateTransform(imgClone.Width / 2, imgClone.Height / 2)
        'Rotate about center of image
        g.RotateTransform(angle)
        'Translate back
        g.TranslateTransform(-imgClone.Width / 2, -imgClone.Height / 2)

        'Draw the image
        g.DrawImage(imgClone, New Point(0, 0))
        'Display the results in a PictureBox
        tank.Image = imgOrig.Clone

        'clean up
        imgClone.Dispose()
        imgOrig.Dispose()
        g.Dispose()
    End Sub
    Private Sub timer_shuffle_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_shuffle.Tick
        If waitingForNextWave = True Then 'wait out for next wave
            For Each word As RichTextBox In subsets
                word.Visible = False ' gives user 5 seconds waiting rest. 
                lbl_wave_clear.Visible = True ' shows that wave is clear 
            Next
            If waitedTimeForNextWave * timer_shuffle.Interval >= 1000 * level_wait_time Then 'wait for level_wait_time seconds for each wave
                waitingForNextWave = False
                waitedTimeForNextWave = 0
                For Each word As RichTextBox In subsets
                    shuffle(word, readText1(word.Tag), word.Tag) 'init new wave
                Next
            End If
            waitedTimeForNextWave += 1
        Else ' if user is NOT waiting for next wave (is progressing in the current wave)
            lbl_wave_clear.Visible = False ' hides the label wave clear
            For Each word As RichTextBox In subsets
                '   word.Text = word.Location.X & " " & word.Location.Y
                word.Visible = True

                If word.Bounds.IntersectsWith(panel_destroy.Bounds) Then
                    If lives = 0 Then ' user has no more lives
                        'you lose
                        timer_shuffle.Stop()
                        add_highscores.Show()
                    Else
                        ' word hits the bottom of the form
                        lives -= 1 ' lose 1 life & generate explosion
                        ptbox_destroy.Image = My.Resources.groundExplosion
                        ptbox_destroy.BackColor = Color.Transparent
                        ptbox_destroy.Size = New Size(200, 240)
                        ptbox_destroy.BringToFront()
                        ptbox_destroy.Location = New Point(word.Location.X - 30, word.Location.Y - 180)
                        If audio Then
                            My.Computer.Audio.Play(My.Resources.bomb, AudioPlayMode.Background)
                        End If
                        timer_destroy.Start() ' after 600 ms, the ground explosion will disappear
                    End If
                    shuffle(word, readText1(word.Tag), word.Tag)
                    matches(word.Tag) = False

                End If 
                word.Location = New Point(word.Location.X, word.Location.Y + 2 + Math.Floor(Wave * 0.3))
            Next
        End If
    End Sub
   
    Private Sub panel_container_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles panel_container.Click
        input.Select()
    End Sub
    Dim angleToRotate As Double




    Dim highScorescount As Double = My.Settings.highscores.Count - 1
    Dim highscores(highScorescount) As Integer
    Dim swapped As Boolean = True
    Dim pass As Integer = 0
    Dim comparison As Integer = 0

    Private Sub Panel1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        alert(Cursor.Position.X & " " & Cursor.Position.Y)
    End Sub

    Private Sub timer_tank_destroy_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_destroy.Tick

        ptbox_destroy.Visible = False
        ptbox_destroy.Image = My.Resources.null
        ptbox_destroy.BackColor = Color.Transparent
        ptbox_destroy.Size = New Size(0, 0)
        ptbox_destroy.Location = New Point(0, 0)
        ptbox_destroy.Visible = True
        timer_destroy.Stop()
    End Sub
    Dim unboldWord As RichTextBox
    Private Sub timer_shoot_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer_shoot.Tick
        bullet.Visible = True
        ' action to shoot the word

        If bullet.Bounds.IntersectsWith(subsets(bullet_word_idx).Bounds) Then
            'bullet_word_idx is the index of the word currently being shot; its used to see if the bullet collides with the correct word
            'explosion effect 
            If exploding Then
                timer_destroy.Stop()
                ' ensures that there is only one explosion at atime - 
                'performane issue
            End If
            ptbox_destroy.Image = My.Resources.explosion ' creates explosion with word
            ptbox_destroy.BackColor = Color.Transparent
            ptbox_destroy.Size = New Size(64, 48)
            ptbox_destroy.Location = New Point(subsets(bullet_word_idx).Location.X, subsets(bullet_word_idx).Location.Y)
            timer_destroy.Start() 'wait 800ms and then destroy the explosion
            shuffle(subsets(bullet_word_idx), readText1(CInt(subsets(bullet_word_idx).Tag)), CInt(subsets(bullet_word_idx).Tag)) ' shuffle the word again
            exploding = True
            timer_shoot.Stop()
            bullet.Visible = False
            For i = 0 To subsets.Length - 1
                ' this is used to unbold every other word.
                unboldWord = CType(subsets(i), RichTextBox)
                If matches(i) Then 'unbold all other matching words
                    unboldWord.SelectionStart = 0
                    unboldWord.SelectionLength = subsets(i).Text.Length
                    unboldWord.SelectionFont = New Font(subsets(i).Font, FontStyle.Regular)
                    unboldWord.Font = New Font("Verdana", My.Settings.fontSize, FontStyle.Regular)
                    matches(i) = False
                End If
            Next
            If audio Then
                My.Computer.Audio.Play(My.Resources.explosion1, AudioPlayMode.Background)
            End If

        Else
            Dim x, y As Integer ' this will move the bullet closer to the word until colison
            x = Math.Floor(40 * sin(bullet_angle))
            y = Math.Floor(40 * cos(bullet_angle))
            bullet.Location = New Point(bullet.Location.X + x, bullet.Location.Y - y)

        End If
    End Sub

     
    Public Sub reset() ' this is called everytime user wants to start a new game
        Dim i As Integer = 0
        For Each word As RichTextBox In subsets
            shuffle(word, word.Tag, word.Tag)
            unboldWord = CType(subsets(i), RichTextBox)
            If matches(i) Then 'unbold all other matching words
                unboldWord.SelectionStart = 0
                unboldWord.SelectionLength = subsets(i).Text.Length
                unboldWord.SelectionFont = New Font(subsets(i).Font, FontStyle.Regular)
                unboldWord.Font = New Font("Verdana", My.Settings.fontSize, FontStyle.Regular)
                matches(i) = False
            End If
            matches(i) = False
            Wave = 1
            lives = 5
            tempScore = 0
            score = 0
            lbl_score.Text = score
            waveLbl.Text = "Wave " & Wave
            timer_shuffle.Start()

            ' this is used to unbold every other word.


            i += 1
        Next
    End Sub

   

    
   
End Class
