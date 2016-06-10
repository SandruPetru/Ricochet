Public Class splashLoadGame
    Dim fs As New FullscreenClass
    Private Sub splashLoadGame_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Value = 0
        fs.FullScreen(Me, True)
        ProgressBar1.Location = New Point(25, Me.Bottom - 40 - ProgressBar1.Height)
        ProgressBar1.Size = New Size(Me.Width - 50, 50)
    End Sub
End Class