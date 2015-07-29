Public Class home
 
    
    Private Sub rotate(ByVal ptbox As PictureBox, ByVal angle As Integer, ByVal imgOrig As Image)
        'Used to rotate the barrel 
        Dim imgClone As Image = imgOrig.Clone  
        'Create the graphics object to draw onto
        Dim g As Graphics = Graphics.FromImage(imgOrig)
        'Clear the picture and give us a black background
        g.Clear(Color.Transparent)

        'Translate to the center of the image
        g.TranslateTransform(imgClone.Width / 2, imgClone.Height / 2)
        'Rotate about center of image
        g.RotateTransform(angle)
        'Translate back
        g.TranslateTransform(-imgClone.Width / 2, -imgClone.Height / 2)

        'Draw the image
        g.DrawImage(imgClone, New Point(0, 0))
        'Display the results in a PictureBox
        ptbox.Image = imgOrig.Clone

        'clean up
        imgClone.Dispose()
        imgOrig.Dispose()
        g.Dispose()

    End Sub
    
      Private Sub ptbox_settings_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ptbox_settings.MouseEnter
        timer_rotate.Start() ' used to rotate the barrel
        lbl_popover.Visible = True
    End Sub

    Dim i As Integer = 0
    Private Sub timer_rotate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_rotate.Tick
        rotate(ptbox_settings, i, My.Resources.settings_larget) ' will occur every 1 second
        i += 1
    End Sub

    Private Sub ptbox_settings_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ptbox_settings.MouseLeave
        timer_rotate.Stop() ' if mouse leaves the settings button, then it 'll stop rotating
        lbl_popover.Visible = False
        i = 0
    End Sub

    Dim angleToRotate As Double ' used to determine how much to rotate
    Dim xCoordinate As Integer = Cursor.Position.X ' X & Y coordinate of mouse
    Dim yCoordinate As Integer = Cursor.Position.Y

    Private Sub panel_settings_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles panel_settings.Click, ptbox_settings.Click
        'settins button click 
        panel_cat_1.Visible = False
        panel_cat_2.Visible = False
        panel_cat_3.Visible = True
    End Sub


    Private Sub ptbox_text_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ptbox_text.MouseMove, panel_cat_1.MouseMove, panel_cat_2.MouseMove, panel_cat_3.MouseMove
        xCoordinate = Cursor.Position.X ' this will update everytime mouse moves over the form
        yCoordinate = Cursor.Position.Y
        panel_mouse.Location = New Point(xCoordinate - 312, yCoordinate - 155) ' panel_mouse follows mouse to determine collision
        ' detmines relative positon of the panel in relation to the mouse
        '   center with mouse = 377, 670
        If xCoordinate >= 377 And yCoordinate <= 670 Then
            ' first quadrant
            'tan1 is TAN IVNERSE
            angleToRotate = tan1(((Math.Abs(xCoordinate - 377))) / (Math.Abs(yCoordinate - 670)))
        ElseIf xCoordinate <= 377 And yCoordinate <= 670 Then
            'secod quadrant
            angleToRotate = 270 + (tan1(((670 - yCoordinate) / (377 - xCoordinate)))) 'second quadrant
        ElseIf xCoordinate <= 377 And yCoordinate >= 670 Then 
            angleToRotate = 270 + (tan1(((670 - yCoordinate) / (377 - xCoordinate)))) 'second quadrant
            'third quadrant
        Else 
            '4th quadrant
            angleToRotate = 90 + (tan1(((670 - yCoordinate) / (377 - xCoordinate)))) 'second quadrant
        End If
        If firing = False Then ' used to ensure there is only one explosion and 1 bullet at a time
            rotate(tank, angleToRotate, My.Resources.barrel)
        End If

    End Sub


    Private Sub ptbox_text_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles panel_highscores.Click
        'highscores click
        panel_cat_1.Visible = False
        panel_cat_3.Visible = False
        panel_cat_2.Visible = True

        fire()
    End Sub

    Private Sub fire() ' used to ensure there is only one explosion and 1 bullet at a time
        If firing = False Then
            bullet.Location = New Point(95, 520)
            If My.Settings.audio = 1 Then
                ' ensures that audio is not played if user does not want it
                My.Computer.Audio.Play(My.Resources.shoot, AudioPlayMode.Background)
            End If
            timer_shoot.Start()
        End If

    End Sub
    Dim firing As Boolean
    Private Sub timer_shoot_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_shoot.Tick
        bullet.Visible = True
        ' this timer will make the button move to target mouse

        If bullet.Bounds.IntersectsWith(panel_mouse.Bounds) Then ' if bullet hits mouse
            If My.Settings.audio = 1 Then
                My.Computer.Audio.Play(My.Resources.bomb, AudioPlayMode.Background)
            End If
            'fire even
            ptbox_destroy.Image = My.Resources.explosion ' creates explosion effect
            ' ptbox_destroy.BackColor = Color.Transparent
            ptbox_destroy.Size = New Size(64, 48) 
            ptbox_destroy.Location = New Point(panel_mouse.Location.X - 20, panel_mouse.Location.Y)
            timer_destroy.Start()
            bullet.Visible = False
            bullet.Location = New Point(95, 520)
            firing = False
            timer_shoot.Stop()
        ElseIf bullet.Location.Y <= -33 Or bullet.Location.X >= 995 Or bullet.Location.Y >= 615 Or bullet.Location.X <= -32 Then
            'if  bullet goes out of the form, reset it's values
            bullet.Visible = False
            bullet.Location = New Point(95, 520)
            firing = False
            timer_shoot.Stop()
        Else
            ' this will make the bullet move to cursor
            Dim x, y As Integer
            x = Math.Floor(40 * sin(angleToRotate)) ' Rise/run. gradient of X (left RIGHT)
            y = Math.Floor(40 * cos(angleToRotate)) ' Gradient of Y (up down)
            bullet.Location = New Point(bullet.Location.X + x, bullet.Location.Y - y) 'move
            firing = True
        End If
    End Sub


    Dim highScorescount As Integer = My.Settings.highscores.Count ' counts amount of people that submitted their score
    Dim tmpName As String ' temporary storage for name and score
    Dim tmpScore As Integer
    Dim count As Integer = 0 ' used to increment thoughout scores
    Dim highscores As String()() = New String(highScorescount - 1)() {} ' jagged array 
    Private m_SortingColumn As ColumnHeader ' used to sort values for listview 
    Private Sub home_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        My.Settings.Save() ' ensure that when form is closed, that settings of user is saved
    End Sub

    'colors end
    Dim doOnce1 As Boolean = False ' these will ensure that when the form loads, it will initialise the perviou's colors only ONCE.
    Dim doOnce2 As Boolean = False
    Dim doOnce3 As Boolean = False
    Private Sub RemoveAllotherTextColors()
        ' removes text colors
        Dim textColorControls() As PictureBox = {ptbox_text_color1, ptbox_text_color2, ptbox_text_color3, ptbox_text_color4, ptbox_text_color5, ptbox_text_color6, ptbox_text_color7, ptbox_text_color8}
        'stores all PictureBoxes in an array to iterate through them.
        For Each textColors As PictureBox In textColorControls ' for each of these picture boxes
            textColors.BackColor = Color.Transparent ' remove background for all
            If doOnce1 = False Then ' initialise the previous settings
                If textColors.Tag = My.Settings.SelectedTextColor Then
                    textColors.BackColor = Color.Teal
                    doOnce1 = True
                    Exit For
                End If
            End If
        Next
    End Sub
    Public Sub removeAllotherTextBackColors()
        ' removes back colors for all words
        Dim ptboxTextBackColors() As PictureBox = {ptbox_text_back_color1, ptbox_text_back_color2, ptbox_text_back_color3, ptbox_text_back_color4, ptbox_text_back_color5, ptbox_text_back_color6, ptbox_text_back_color7, ptbox_text_back_color8}
        ' same as RemoveAllotherTextColors sub but controls backcolrs of worsd, not forecolors
        For Each textColors As PictureBox In ptboxTextBackColors
            textColors.BackColor = Color.Transparent
            If doOnce2 = False Then
                If textColors.Tag = My.Settings.SelectedTextBackColor Then
                    textColors.BackColor = Color.Teal
                    doOnce2 = True
                    Exit For
                End If
            End If
        Next
    End Sub
    Private Sub removeAllotherBulletColors()
        'controls bullet colors
        Dim ptboxBulletColors() As PictureBox = {ptbox_bullet_color1, ptbox_bullet_color2, ptbox_bullet_color3, ptbox_bullet_color4, ptbox_bullet_color5, ptbox_bullet_color6, ptbox_bullet_color7, ptbox_bullet_color8}
        ' removes bullet colors and initialises user's default one
        For Each textColors As PictureBox In ptboxBulletColors
            textColors.BackColor = Color.Transparent
            If doOnce3 = False Then
                If textColors.Tag = My.Settings.SelectedBulletColor Then
                    textColors.BackColor = Color.Teal
                    doOnce3 = True
                    Exit For
                End If
            End If
        Next
    End Sub
    Dim trkbarValue As Integer = My.Settings.fontSize - 10 ' updates trackbar's position to user's previous settings

    Private Sub home_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        If trkbarValue >= 5 Or trkbarValue < 0 Then
            trkbar_font_size.Value = 12
        Else
            trkbar_font_size.Value = My.Settings.fontSize - 10
        End If 
        RemoveAllotherTextColors() ' initialises all the colors
        removeAllotherTextBackColors()
        removeAllotherBulletColors()
        bullet.BringToFront()
        If My.Settings.audio = 1 Then ' will determien whether user wants audio or not
            chkbox_audio.Checked = True
        Else
            chkbox_audio.Checked = False
        End If
        Me.Tag = 1
        'highscores populate data

        'populate array in highscores
        For Each item As String In My.Settings.highscores
            ' this is used to populate the listbox
            tmpScore = item.Split("|")(0) ' score (this is the SCORE)
            tmpName = item.Split("|")(1) 'name (this is the TmpName)
            highscores(count) = New String() {tmpName, tmpScore} ' JAGGED ARRAY
            count += 1 ' used to increment though count
        Next

        For i As Integer = 0 To highscores.Count ' populates lisview
            lstview_hs.Items.Add(New ListViewItem({highscores(i)(0), highscores(i)(1)}))
        Next

    End Sub


    Private Sub timer_destroy_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer_destroy.Tick
        ' this is happen when the bullet leaves the form
        ptbox_destroy.Visible = False
        ptbox_destroy.Image = My.Resources.null
        ptbox_destroy.BackColor = Color.Transparent
        ptbox_destroy.Size = New Size(0, 0)
        ptbox_destroy.Location = New Point(0, 0)
        ptbox_destroy.Visible = True
        timer_destroy.Stop()
    End Sub

    Private Sub panel_play_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles panel_play.Click
        gameGUI.Show()
        Me.Hide()
    End Sub

    Private Sub panel_play_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles panel_play.MouseEnter
        ptbox_arrow_left.Location = New Point(465, 37) ' arrows used to determine which of the 3 buttons (play, scores and settings) user is picking
    End Sub


    Private Sub panel_highscores_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles panel_highscores.MouseEnter
        ptbox_arrow_left.Location = New Point(463, 109) ' arrows used to determine which of the 3 buttons (play, scores and settings) user is picking

    End Sub


    Private Sub panel_settings_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles panel_settings.MouseEnter
        ptbox_arrow_left.Location = New Point(461, 176) ' arrows used to determine which of the 3 buttons (play, scores and settings) user is picking
    End Sub
    Private Sub ptbox_text_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text.Click
        fire() ' subroutine that shoots!
    End Sub



    Private Sub lstview_hs_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lstview_hs.ColumnClick
        ' This is used to sort the listview - SEE  CLASS sortlistview.vb
        ' Get the new sorting column.  
        Dim new_sorting_column As ColumnHeader = lstview_hs.Columns(e.Column)
        ' Figure out the new sorting order.  
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.  
            sort_order = SortOrder.Ascending
        Else ' See if this is the same column.  
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.  
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.  
                sort_order = SortOrder.Ascending
            End If
            ' Remove the old sort indicator.  
            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If
        ' Display the new sort order.  
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If
        ' Create a comparer.  
        lstview_hs.ListViewItemSorter = New sortListView(e.Column, sort_order)
        ' Sort.  
        lstview_hs.Sort()
    End Sub


    Private Sub ptbox_back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_back.Click, ptbox_back2.Click
        'resets back to main menu
        panel_cat_1.Visible = True ' play
        panel_cat_3.Visible = False ' score
        panel_cat_2.Visible = False ' settings

    End Sub

    Private Sub ptbox_back_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ptbox_back.MouseDown, ptbox_back2.MouseDown
        ptbox_back.Image = My.Resources.black_click ' back button (changes color when mouse down)
        ptbox_back2.Image = My.Resources.black_click
    End Sub

    Private Sub ptbox_back_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ptbox_back.MouseEnter, ptbox_back2.MouseEnter
        lbl_back.Visible = True ' popover effects
        lbl_back2.Visible = True
    End Sub

    Private Sub ptbox_back_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ptbox_back.MouseLeave, ptbox_back2.MouseLeave
        lbl_back.Visible = False 'popover effects end
        lbl_back2.Visible = False
    End Sub

    Private Sub ptbox_back_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ptbox_back.MouseUp, ptbox_back2.MouseUp
        ptbox_back.Image = My.Resources.back
        ptbox_back2.Image = My.Resources.back ' resets back color of back button
    End Sub


    Private Sub ptbox_text_color1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_color1.Click
        RemoveAllotherTextColors() ' used to select new text color and remove all others
        ptbox_text_color1.BackColor = Color.Teal
        My.Settings.SelectedTextColor = 1
    End Sub

    Private Sub ptbox_text_color2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_color2.Click
        RemoveAllotherTextColors() ' used to select new text color and remove all others
        ptbox_text_color2.BackColor = Color.Teal
        My.Settings.SelectedTextColor = 2
    End Sub

    Private Sub ptbox_text_color3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_color3.Click
        RemoveAllotherTextColors() ' used to select new text color and remove all others
        ptbox_text_color3.BackColor = Color.Teal
        My.Settings.SelectedTextColor = 3
    End Sub

    Private Sub ptbox_text_color4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_color4.Click
        RemoveAllotherTextColors() ' used to select new text color and remove all others
        ptbox_text_color4.BackColor = Color.Teal
        My.Settings.SelectedTextColor = 4
    End Sub

    Private Sub ptbox_text_color5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_color5.Click
        RemoveAllotherTextColors() ' used to select new text color and remove all others
        ptbox_text_color5.BackColor = Color.Teal
        My.Settings.SelectedTextColor = 5
    End Sub

    Private Sub ptbox_text_color6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_color6.Click
        RemoveAllotherTextColors() ' used to select new text color and remove all others
        ptbox_text_color6.BackColor = Color.Teal
        My.Settings.SelectedTextColor = 6
    End Sub

    Private Sub ptbox_text_color7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_color7.Click
        RemoveAllotherTextColors() ' used to select new text color and remove all others
        ptbox_text_color7.BackColor = Color.Teal
        My.Settings.SelectedTextColor = 7
    End Sub

    Private Sub ptbox_text_color8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_color8.Click
        RemoveAllotherTextColors() ' used to select new text color and remove all others
        ptbox_text_color8.BackColor = Color.Teal
        My.Settings.SelectedTextColor = 8
    End Sub
    ' 8 colors to choose from   
    Private Sub ptbox_text_back_color1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_back_color1.Click
        removeAllotherTextBackColors() ' used to select new text BACK color and remove all others
        ptbox_text_back_color1.BackColor = Color.Teal
        My.Settings.SelectedTextBackColor = 1
    End Sub

    Private Sub ptbox_text_back_color2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_back_color2.Click
        removeAllotherTextBackColors() ' used to select new text BACK color and remove all others
        ptbox_text_back_color2.BackColor = Color.Teal
        My.Settings.SelectedTextBackColor = 2
    End Sub

    Private Sub ptbox_text_back_color3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_back_color3.Click
        removeAllotherTextBackColors() ' used to select new text BACK color and remove all others
        ptbox_text_back_color3.BackColor = Color.Teal
        My.Settings.SelectedTextBackColor = 3
    End Sub

    Private Sub ptbox_text_back_color4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_back_color4.Click
        removeAllotherTextBackColors() ' used to select new text BACK color and remove all others
        ptbox_text_back_color4.BackColor = Color.Teal
        My.Settings.SelectedTextBackColor = 4
    End Sub

    Private Sub ptbox_text_back_color5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_back_color5.Click
        removeAllotherTextBackColors() ' used to select new text BACK color and remove all others
        ptbox_text_back_color5.BackColor = Color.Teal
        My.Settings.SelectedTextBackColor = 5
    End Sub

    Private Sub ptbox_text_back_color6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_back_color6.Click
        removeAllotherTextBackColors() ' used to select new text BACK color and remove all others
        ptbox_text_back_color6.BackColor = Color.Teal
        My.Settings.SelectedTextBackColor = 6
    End Sub

    Private Sub ptbox_text_back_color7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_back_color7.Click
        removeAllotherTextBackColors() ' used to select new text BACK color and remove all others
        ptbox_text_back_color7.BackColor = Color.Teal
        My.Settings.SelectedTextBackColor = 7
    End Sub

    Private Sub ptbox_text_back_color8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_text_back_color8.Click
        removeAllotherTextBackColors() ' used to select new text BACK color and remove all others
        ptbox_text_back_color8.BackColor = Color.Teal
        My.Settings.SelectedTextBackColor = 8
    End Sub
    ' 8 COLORS TO CHOOSE FROM
    Private Sub ptbox_bullet_color1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_bullet_color1.Click
        removeAllotherBulletColors() ' used to select new text BULLET color and remove all others
        ptbox_bullet_color1.BackColor = Color.Teal
        My.Settings.SelectedBulletColor = 1
    End Sub

    Private Sub ptbox_bullet_color2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_bullet_color2.Click
        removeAllotherBulletColors() ' used to select new text BULLET color and remove all others
        ptbox_bullet_color2.BackColor = Color.Teal
        My.Settings.SelectedBulletColor = 2
    End Sub

    Private Sub ptbox_bullet_color3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_bullet_color3.Click
        removeAllotherBulletColors() ' used to select new text BULLET color and remove all others
        ptbox_bullet_color3.BackColor = Color.Teal
        My.Settings.SelectedBulletColor = 3
    End Sub

    Private Sub ptbox_bullet_color4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_bullet_color4.Click
        removeAllotherBulletColors() ' used to select new text BULLET color and remove all others
        ptbox_bullet_color4.BackColor = Color.Teal
        My.Settings.SelectedBulletColor = 4
    End Sub

    Private Sub ptbox_bullet_color5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_bullet_color5.Click
        removeAllotherBulletColors() ' used to select new text BULLET color and remove all others
        ptbox_bullet_color5.BackColor = Color.Teal
        My.Settings.SelectedBulletColor = 5
    End Sub

    Private Sub ptbox_bullet_color6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_bullet_color6.Click
        removeAllotherBulletColors() ' used to select new text BULLET color and remove all others
        ptbox_bullet_color6.BackColor = Color.Teal
        My.Settings.SelectedBulletColor = 6
    End Sub

    Private Sub ptbox_bullet_color7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_bullet_color7.Click
        removeAllotherBulletColors() ' used to select new text BULLET color and remove all others
        ptbox_bullet_color7.BackColor = Color.Teal
        My.Settings.SelectedBulletColor = 7
    End Sub

    Private Sub ptbox_bullet_color8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_bullet_color8.Click
        removeAllotherBulletColors() ' used to select new text BULLET color and remove all others
        ptbox_bullet_color8.BackColor = Color.Teal
        My.Settings.SelectedBulletColor = 8
    End Sub
    Private Sub trkbar_font_size_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trkbar_font_size.Scroll
        My.Settings.fontSize = trkbar_font_size.Value + 10 ' trackbar value used to change font
    End Sub


    Private Sub chkbox_audio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkbox_audio.CheckedChanged
        If chkbox_audio.Checked Then ' audio (to determine whether user wants audio or not)
            My.Settings.audio = 1
        Else
            My.Settings.audio = 0
        End If
    End Sub
    Private Sub ptbox_help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_help.Click
        help.Show() ' help button
        Me.Hide()
    End Sub

    Private Sub ptbox_help_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ptbox_help.MouseEnter
        ' save resources by using same label for both settigns and help
        lbl_popover.Text = "Help"
        lbl_popover.Location = New Point(870, 526)
        lbl_popover.Visible = True
    End Sub

    Private Sub ptbox_help_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ptbox_help.MouseLeave
        lbl_popover.Text = "Settings"
        lbl_popover.Location = New Point(915, 527)
        lbl_popover.Visible = False

    End Sub
End Class