Public Module globalVars
    Dim label01, label02, label03, label04, label05 As New RichTextBox ', label06, label07, label08, label09, label10
    Public subsets() As Control = {label01, label02, label03, label04, label05} ', label06, label07, label08, label09, label10
    Public rand As New System.Random

    Public tempScore As Integer = 1
    Public Wave As Integer = 1
    Public totalWordsSentInCurrentWave As Integer = 0
    Public maxWordsinVave As Integer = 40
    Public levels_in_first_wave As Integer = 19
    Public waitingForNextWave As Boolean = False
    Public level_wait_time As Integer = 5
    Public lives As Integer = 5
    Public waitedTimeForNextWave As Integer
    Public score As Integer
    Public bullet_angle As Double
    Public bullet_word_idx As Integer
    Public audio As Boolean
    Public Sub alert(ByVal name)
        MessageBox.Show(name)
    End Sub
End Module
 
