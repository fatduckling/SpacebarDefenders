Public Class add_highscores

    Private Sub submitscore()
        Dim hs_name As String = txtbox_input_hs.Text
        If String.IsNullOrEmpty(hs_name) Then
            alert("Please type your name!")
        Else
            My.Settings.highscores.Add(score & "|" & hs_name)
            alert("Thank you for submitting your score " & hs_name) 
            gameGUI.Hide()
            Reset() 
            home.Show()
        End If
    End Sub
    Private Sub lbl_submit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_submit.Click
        
        submitscore()
    End Sub

    Private Sub Panel3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        gameGUI.reset()
    End Sub 
   
    Dim i As Integer = 0
     
     
    Private Sub ptbox_redo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_redo.Click
        gameGUI.reset()
        Me.Close()

    End Sub

   
    Private Sub ptbox_home_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_home.Click
        home.Show()
        Me.Hide()
    End Sub

    Private Sub ptbox_redo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ptbox_redo.MouseDown
        ptbox_redo.BackColor = Color.Gray
    End Sub

    Private Sub ptbox_redo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ptbox_redo.MouseUp
        ptbox_redo.BackColor = Color.Transparent
    End Sub

    

    Private Sub ptbox_settings_MouseDown(ByVal sender As Object, ByVal e As System.EventArgs) Handles ptbox_help.MouseDown
        ptbox_help.BackColor = Color.Gray
    End Sub

    Private Sub ptbox_settings_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ptbox_help.MouseLeave
        ptbox_help.BackColor = Color.Transparent
    End Sub

    Private Sub ptbox_home_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ptbox_home.MouseDown
        ptbox_home.BackColor = Color.Gray
    End Sub

    Private Sub ptbox_home_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ptbox_home.MouseUp
        ptbox_home.BackColor = Color.Transparent
    End Sub

    Private Sub lbl_submit_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl_submit.MouseDown
        lbl_submit.ForeColor = Color.White
    End Sub

    Private Sub lbl_submit_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbl_submit.MouseUp
        lbl_submit.ForeColor = Color.Black
    End Sub

    Private Sub ptbox_trophy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_trophy.Click
        submitscore()
    End Sub

    Private Sub panel_submit_trigger_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles panel_submit_trigger.Click
        submitscore()
    End Sub

    Private Sub panel_submit_trigger_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_submit_trigger.MouseDown
        lbl_submit.ForeColor = Color.White
    End Sub

    Private Sub panel_submit_trigger_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles panel_submit_trigger.MouseUp
        lbl_submit.ForeColor = Color.Black
    End Sub

    Private Sub add_highscores_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        gameGUI.reset()
    End Sub


    Private Sub ptbox_settings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbox_help.Click
        help.Show() 
        Me.Close()
    End Sub

    
End Class