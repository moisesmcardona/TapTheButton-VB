Public Class Form1
    Private Tap As Long = 0
    Private TimeLabelUpdate As Integer = 30
    Private StartCount As Integer = 0
    Private Sub UpdateScore()
        If My.Settings.HighScore < Tap Then
            My.Settings.HighScore = Tap
            My.Settings.Save()
            Label5.Text = "High Score: " & My.Settings.HighScore
            Label5.Visible = True
        End If
    End Sub
    Private Sub LoadScore()
        If My.Settings.HighScore = 0 = False Then
            Label5.Text = "High Score: " & My.Settings.HighScore
            Label5.Visible = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If StartCount = 0 Then
            Tap = 0
            If Label4.Text = "Time's Up" Then Label4.Text = "Time: 30"
            Label1.Text = "Taps: 0"
            Label1.Update()
            Timer1.Interval = 1000
            Timer1.Enabled = True
            Timer1.Start()
            Dim AudioStream As System.IO.Stream = My.Resources.Start
            My.Computer.Audio.Play(AudioStream, AudioPlayMode.Background)
            StartCount = 1
        End If
        Tap = Tap + 1
        Label1.Text = "Taps: " & Tap
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadScore()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TimeLabelUpdate = TimeLabelUpdate - 1
        Label4.Text = "Time: " & TimeLabelUpdate
        If Label4.Text = "Time: 0" Then
            StartCount = 0
            Label4.Text = "Time's Up"
            TimeLabelUpdate = 30
            Timer1.Stop()
            Button1.Enabled = False
            Dim StopStream As System.IO.Stream = My.Resources._Stop
            My.Computer.Audio.Play(StopStream, AudioPlayMode.Background)
            UpdateScore()
        End If
        If TimeLabelUpdate <= 10 Then
            If Label4.ForeColor = Color.Black Then Label4.ForeColor = Color.Red Else Label4.ForeColor = Color.Black
        End If
        Dim WarningStream As System.IO.Stream = My.Resources.Warning
        Dim FiveSecondsCountdownStream As System.IO.Stream = My.Resources.FiveSecondCountdown
        If TimeLabelUpdate = 15 Then My.Computer.Audio.Play(WarningStream, AudioPlayMode.Background)
        If TimeLabelUpdate = 6 Then My.Computer.Audio.Play(FiveSecondsCountdownStream, AudioPlayMode.Background)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button1.Enabled = True
        If Label4.Text = "Time's Up" Then Label4.Text = "Time: 30"
    End Sub
End Class
