Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.IO
Imports System.Text
Imports System.Threading
Public Class game
    Dim fs As New FullscreenClass
    Public m(21, 25) As Integer
    Public b(21, 25) As PictureBox
    Dim l As New ShapeContainer
    Dim c As New ShapeContainer

    Dim ver As Boolean = False
    Dim im1 As Image



    Dim c1 As New ShapeContainer
    Dim block2(300) As RectangleShape
    Dim ind As Integer = 0

    Dim mBlockselect As Integer
    Dim colo() As Color = New Color() {Color.Red, Color.Aqua, Color.Blue, Color.Brown, Color.Gainsboro, Color.Goldenrod}

    Dim dirx As Double = -1
    Dim diry As Double = -1
    Dim start As Boolean = False
    Dim speed As Integer = 3

    Dim bmp As Image
    Dim im2 As New PictureBox
    'Dim pic As New PictureBox
    Dim XYball As New Point

    Dim nrlovituri As Integer = 0
    Dim vieti As Integer = 3
    Dim nrblock As Integer
    Dim scor As Integer = 0


    Private Sub game_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fs.FullScreen(Me, True)

        splashLoadGame.Visible = True
        ' Me.Cursor.Dispose()
        'Cursor.Hide()

        ' bmp = ricochet.My.Resources.Resources.SpikeBall
        ' bmp.Size = New Size(20, 20)

        For i As Integer = 0 To 20
            For j As Integer = 0 To 25
                m(i, j) = ricochet.start.m(i, j)

            Next
            splashLoadGame.ProgressBar1.Value += 8
        Next
        ricochet.start.Close()

        splashLoadGame.ProgressBar1.Value = 200


        Panel1.BackColor = Color.FromArgb(30, 70, 100)
        Panel1.Size = New Size(fs.ScreenX - (50 * 21 + 102), fs.ScreenY)
        Panel1.Location = New Point(50 * 21 + 102, 0)

        Label1.Location = New Point(20, Panel1.Height - 2 * Label1.Height)





        Panel2.Location = New Point(50, 30)
        Panel2.Size = New Size(50 * 21 + 2, fs.ScreenY)



        c1.Parent = Panel2
        c.Parent = Panel1







        l.Parent = Me
        LineShape1.Parent = l
        LineShape1.BorderWidth = 50
        LineShape1.X1 = 24
        LineShape1.Y1 = -1
        LineShape1.X2 = 24
        LineShape1.Y2 = fs.ScreenY

        LineShape2.Parent = l
        LineShape2.BorderWidth = 30
        LineShape2.X1 = 0
        LineShape2.Y1 = 14
        LineShape2.X2 = fs.ScreenX - 2 * (fs.ScreenX / 10) + 50
        LineShape2.Y2 = 14

        LineShape3.Parent = l
        LineShape3.BorderWidth = 50
        LineShape3.X1 = 50 * 21 + 2 + 74
        LineShape3.Y1 = -1
        LineShape3.X2 = 50 * 21 + 2 + 74
        LineShape3.Y2 = fs.ScreenY






        RectangleShape1.Parent = c1
        RectangleShape1.Location = New Point(Panel2.Width / 2, Panel2.Height - 2 * RectangleShape1.Height)
        RectangleShape1.Show()
        ball1.Parent = c1
        ball1.Location = New Point(RectangleShape1.Location.X - RectangleShape1.Width / 2, RectangleShape1.Location.Y - ball1.Height)
        ball1.Visible = True

        '-------------load background image -------------
        '-----
        Dim indice As String
        indice = My.Settings.ballName.Last
        Dim n As Integer = CInt(indice)
        Select Case n
            Case 1
                ball1.BackgroundImage = My.Resources.Ball1
            Case 2
                ball1.BackgroundImage = My.Resources.Ball2
            Case 3
                ball1.BackgroundImage = My.Resources.Ball3
            Case 4
                ball1.BackgroundImage = My.Resources.Ball4
            Case 5
                ball1.BackgroundImage = My.Resources.Ball5
        End Select

        indice = My.Settings.rocketName.Last
        n = CInt(indice)
        Select Case n
            Case 1
                RectangleShape1.BackgroundImage = My.Resources.Rocket1
            Case 2
                RectangleShape1.BackgroundImage = My.Resources.Rocket2
            Case 3
                RectangleShape1.BackgroundImage = My.Resources.Rocket3
            Case 4
                RectangleShape1.BackgroundImage = My.Resources.Rocket4
        End Select
            '---------------------------------------


            Initialize()
            splashLoadGame.ProgressBar1.Value += 50
            LoadGame()
            splashLoadGame.ProgressBar1.Value += 50
            ' AddHandler pic.MouseMove, AddressOf Panel2_MouseMove
            '  AddHandler pic.Click, AddressOf Panel2_Click
            For i As Integer = 0 To 20
                For j As Integer = 0 To 25
                    AddHandler b(i, j).Paint, AddressOf ric
                    '  b(i, j).DoDragDrop(ball, DragDropEffects.All)
                    AddHandler b(i, j).Click, AddressOf Panel2_Click
                    AddHandler b(i, j).MouseMove, AddressOf Panel2_MouseMove
                    splashLoadGame.ProgressBar1.Value += 1
                Next
                splashLoadGame.ProgressBar1.Value += 5
            Next

            AddHandler RectangleShape1.MouseMove, AddressOf Panel2_MouseMove

            splashLoadGame.ProgressBar1.Value = 1000
        splashLoadGame.Visible = False
        splashLoadGame.ProgressBar1.Value = 0
        Label5.Text = "JOC PIERDUT"
        Label5.Visible = False
        Label5.Location = New Point(Panel2.Width / 4, Panel2.Height / 3)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        Me.Close()

    End Sub

    Private Sub Panel2_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel2.MouseMove
        RectangleShape1.Location = New Point(MousePosition.X - Panel2.Location.X - RectangleShape1.Width / 2, RectangleShape1.Location.Y)

        If start = False And vieti > 0 And nrblock > 0 Then
            ball1.Location = New Point(RectangleShape1.Location.X + RectangleShape1.Width / 2 - ball1.Width / 2, RectangleShape1.Location.Y - ball1.Height - 1)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
       
        If start = False Then
            Return
       
        End If
        If ball1.Top < 0 Then
            diry = -diry
            nrlovituri += 1
            ball1.Left += (speed * dirx)
            ball1.Top += (speed * diry)

        End If
        If ball1.Left < 0 Then
            dirx = -dirx
            nrlovituri += 1
            ball1.Left += (speed * dirx)
            ball1.Top += (speed * diry)

        End If
        If ball1.Right > Panel2.Width Then
            dirx = -dirx
            nrlovituri += 1
            ball1.Left += (speed * dirx)
            ball1.Top += (speed * diry)

        End If
        If ball1.Bottom + speed >= RectangleShape1.Top And ball1.Top - speed < RectangleShape1.Top And ball1.Right > RectangleShape1.Left And ball1.Left < RectangleShape1.Right Then
            ' diry = -1
            Dim lr As Integer = RectangleShape1.Width / 7
            Dim cb As Integer = ball1.Left + (ball1.Width / 2)
            nrlovituri += 1
            If cb < RectangleShape1.Left + lr Then
                dirx = -2 / 3
                diry = -1 / 3
            ElseIf cb < RectangleShape1.Left + 2 * lr Then
                dirx = -1 / 2
                diry = -1 / 2
            ElseIf cb < RectangleShape1.Left + 3 * lr Then
                dirx = -1 / 3
                diry = -2 / 3
            ElseIf cb > RectangleShape1.Left + 6 * lr Then
                dirx = 2 / 3
                diry = -1 / 3
            ElseIf cb > RectangleShape1.Left + 5 * lr Then
                dirx = 1 / 2
                diry = -1 / 2
            ElseIf cb > RectangleShape1.Left + 4 * lr Then
                dirx = 1 / 3
                diry = -2 / 3
            Else
                dirx = 0
                diry = -1
            End If
        End If
        ' End If
        If ball1.Top > Panel2.Height Then
            start = False
            Timer1.Stop()
            vieti -= 1
            If vieti <= 0 Then
                Label5.Visible = True
            Timer2.Start()
            End If
        ElseIf nrblock = 0 Then
            Label5.Text = "JOC CASTIGAT"
            Label5.Visible = True
            Timer2.Start()
        End If

        If (nrlovituri > 20) Then
            speed += 1
            nrlovituri = 0
        End If
       

            '  verificaBlock()
            ball1.Left += (speed * dirx)
            ball1.Top += (speed * diry)
            Label2.Text = "VIETI: " & vieti
        Label3.Text = "BLOCURI: " & nrblock
        Label4.Text = "VITEZA: " & speed
        Label6.Text = "SCOR: " & scor
    End Sub



    Private Sub Panel2_Click(sender As Object, e As EventArgs) Handles Panel2.Click
        If start = False And vieti > 0 Then
            speed = 3
            dirx = 0
            diry = -1
            start = True
            Timer1.Start()

        End If
        ' speed += 1
    End Sub


    Private Sub Initialize()
        For i As Integer = 0 To 20
            For j As Integer = 0 To 25
                '  m(i, j) = 0
                b(i, j) = New PictureBox
                b(i, j).Parent = c1
                b(i, j).Left = i * 50 + 2
                b(i, j).Top = j * 20 + 1
                b(i, j).Width = 46
                b(i, j).Height = 18
                b(i, j).SizeMode = PictureBoxSizeMode.StretchImage
                'b(i, j).CornerRadius = 0
                b(i, j).BackColor = Color.Transparent
                'b(i, j).BackStyle = BackStyle.Opaque
                b(i, j).Visible = False


            Next
        Next
    End Sub


    Private Sub LoadGame()


        Dim rez As Integer
        For i As Integer = 0 To 20
            For j As Integer = 0 To 25
                rez = m(i, j)
                If rez > 0 Then
                    b(i, j).Visible = True
                    nrblock += 1
                    b(i, j).Tag = rez
                    Select Case rez
                        Case 1
                            b(i, j).Image = ricochet.My.Resources.Block_a1
                        Case 2
                            b(i, j).Image = ricochet.My.Resources.Block_a2
                        Case 3
                            b(i, j).Image = ricochet.My.Resources.Block_a3
                        Case 4
                            b(i, j).Image = ricochet.My.Resources.Block_a4
                        Case 5
                            b(i, j).Image = ricochet.My.Resources.Block_a5
                        Case 6
                            b(i, j).Image = ricochet.My.Resources.Block_a6
                    End Select
                    '  b(i, j).Visible = True
                    ' b(i, j).CornerRadius = 10

                    'b(i, j).Image = ricochet.My.Resources.Block_b1
                    'BackColor = colo(m(i, j) - 1)
                    ' b(i, j).BackColor = colo(m(i, j) - 1)

                    ' b(i, j).BackStyle = PowerPacks.BackStyle.Opaque


                Else
                    '  b(i, j).CornerRadius = 0
                    b(i, j).BackColor = Color.Transparent

                End If



            Next
        Next
    End Sub
    Sub getXYball()
        XYball.X = ball1.Location.X + ball1.Width / 2
        XYball.Y = ball1.Location.Y + ball1.Height / 2
    End Sub

    Sub verificaBlock()

        Try
            If ball1.Location.Y / 20 < 26 Then
                If dirx = 0 And diry < 0 Then
                    If m(((ball1.Left - 25) / 50), ((ball1.Top - 10) / 20)) > 0 Then
                        diry = -diry
                    End If

                ElseIf dirx = 0 And diry > 0 Then
                    If m((ball1.Left / 50), ((ball1.Bottom + 10) / 20) > 0) Then
                        diry = -diry
                    End If

                ElseIf dirx > 0 And diry < 0 Then
                    If (m(((ball1.Right - 25) / 50), ((ball1.Top - 10) / 20)) > 0) Then
                        If ((ball1.Right - 25) Mod 50) < 10 Then
                            dirx = -dirx
                        Else
                            diry = -diry
                        End If

                    End If
                ElseIf dirx > 0 And diry > 0 Then
                    If (m(((ball1.Right - 25) / 50), ((ball1.Bottom + 10) / 20)) > 0) Then
                        If ((ball1.Right - 25) Mod 50) < 10 Then
                            dirx = -dirx
                        Else
                            diry = -diry
                        End If
                    End If
                ElseIf dirx < 0 And diry < 0 Then
                    If (m(((ball1.Left + 25) / 50), ((ball1.Top - 10) / 20)) > 0) Then
                        If ((ball1.Right - 25) Mod 50) > 40 Then
                            dirx = -dirx
                        Else
                            diry = -diry
                        End If
                    End If
                ElseIf dirx < 0 And diry > 0 Then
                    If (m(((ball1.Left + 25) / 50), ((ball1.Bottom + 10) / 20)) > 0) Then
                        If ((ball1.Right - 25) Mod 50) > 40 Then
                            dirx = -dirx
                        Else
                            diry = -diry
                        End If
                    End If

                End If


            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub rein(sender As Object, e As EventArgs)
        If ver = False Then

            Dim im As PictureBox = sender
            'im2 = im
            If (diry < 0 And im.Bottom + speed > ball1.Top) Or (diry > 0 And im.Top - speed < ball1.Bottom) Then
                im.Image = My.Resources.background
                ' im.Visible = False
                im2 = im
                ver = True
                ' Label5.Text = Label5.Text & " +"
                ' Timer2.Start()

                '  dirx = -dirx
                diry = -diry
                ball1.Left += 2 * (speed * dirx)
                ball1.Top += 2 * (speed * diry)

                '  im2 = im
            ElseIf (dirx > 0 And im.Left - speed < ball1.Right) Or (dirx < 0 And im.Right + speed > ball1.Left) Then

                im.Image = My.Resources.background
                ' im.Visible = False
                im2 = im

                ver = True
                dirx = -dirx
                ball1.Left += 2 * (speed * dirx)
                ball1.Top += 2 * (speed * diry)
                ' im2 = im
            End If
            If (start = True) Then



            End If
            Timer2.Start()
            ' ball.Location = New Point(RectangleShape1.Location.X + RectangleShape1.Width / 2, RectangleShape1.Location.Y - ball.Height)
        Else

            ' ver = False
            '  Timer2.Stop()

        End If
        'im2.Image = My.Resources.background
        ' im2.Visible = False

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If vieti <= 0 Then
            If Label5.ForeColor = Color.Black Then
                Label5.ForeColor = Color.Red
            Else
                Label5.ForeColor = Color.Black
            End If

            '  Return

        Else

            ver = False

            Timer2.Stop()
            If im2.Tag = 0 Then
                im2.Visible = False
            End If

            End If
    End Sub

    Sub ric(sender As Object, e As EventArgs)
        If ver = False Then
            Dim im As PictureBox = sender
            If (diry < 0 And im.Bottom + speed > ball1.Top) Then
                'loveste din jos
                nrlovituri += 1
                If dirx = 0 Then
                    ' completare loveste jos
                    diry = -diry

                    ball1.Left += 2 * (speed * dirx)
                    ball1.Top += 2 * (speed * diry)

                    im2 = im
                    ver = True
                    im.Tag -= 1
                    scor += 1

                    If im.Tag = 0 Then
                        im.Image = My.Resources.background
                        nrblock -= 1
                        scor += 4
                    End If
                ElseIf dirx > 0 Then
                    ' loveste din stanga jos 
                    If (im.Bottom + speed < ball1.Bottom) And (im.Left - speed > ball1.Left) Then
                        ' completare loveste din stanga jos in colt stanga jos
                        dirx = -dirx
                        diry = -diry

                        ball1.Left += 2 * (speed * dirx)
                        ball1.Top += 2 * (speed * diry)

                        im2 = im
                        ver = True
                        im.Tag -= 1
                        scor += 1
                        If im.Tag = 0 Then
                            im.Image = My.Resources.background
                            nrblock -= 1
                            scor += 4
                        End If
                    ElseIf (im.Bottom + speed < ball1.Bottom) And (im.Left - speed < ball1.Left) Then
                        ' completare loveste din stanga jos in partea de jos
                        diry = -diry

                        ball1.Left += 2 * (speed * dirx)
                        ball1.Top += 2 * (speed * diry)

                        im2 = im
                        ver = True
                        im.Tag -= 1
                        scor += 1
                        If im.Tag = 0 Then
                            im.Image = My.Resources.background
                            nrblock -= 1
                            scor += 4
                        End If
                    ElseIf (im.Bottom + speed > ball1.Bottom) And (im.Left - speed > ball1.Left) Then
                        ' completare loveste din stanga jos in partea stanga
                        dirx = -dirx

                        ball1.Left += 2 * (speed * dirx)
                        ball1.Top += 2 * (speed * diry)

                        im2 = im
                        ver = True
                        im.Tag -= 1
                        scor += 1
                        If im.Tag = 0 Then
                            im.Image = My.Resources.background
                            nrblock -= 1
                            scor += 4
                        End If
                    End If
                ElseIf dirx < 0 Then
                    ' loveste din dreapta jos
                    If (im.Bottom + speed < ball1.Bottom) And (im.Right + speed < ball1.Right) Then
                        'completare loveste din dreapta jos in colt dreapta jos
                        dirx = -dirx
                        diry = -diry

                        ball1.Left += 2 * (speed * dirx)
                        ball1.Top += 2 * (speed * diry)

                        im2 = im
                        ver = True
                        im.Tag -= 1
                        scor += 1
                        If im.Tag = 0 Then
                            im.Image = My.Resources.background
                            nrblock -= 1
                            scor += 4
                        End If
                    ElseIf (im.Bottom + speed < ball1.Bottom) And (im.Right + speed > ball1.Right) Then
                        'completare loveste din dreapta jos in partea de jos
                        diry = -diry

                        ball1.Left += 2 * (speed * dirx)
                        ball1.Top += 2 * (speed * diry)

                        im2 = im
                        ver = True
                        im.Tag -= 1
                        scor += 1
                        If im.Tag = 0 Then
                            im.Image = My.Resources.background
                            nrblock -= 1
                            scor += 4
                        End If
                    ElseIf (im.Bottom + speed > ball1.Bottom) And (im.Right + speed < ball1.Right) Then
                        'completare loveste din dreapta jos in partea dreapta
                        dirx = -dirx

                        ball1.Left += 2 * (speed * dirx)
                        ball1.Top += 2 * (speed * diry)

                        im2 = im
                        ver = True
                        im.Tag -= 1
                        scor += 1
                        If im.Tag = 0 Then
                            im.Image = My.Resources.background
                            nrblock -= 1
                            scor += 4
                        End If
                    End If


                End If


            ElseIf (diry > 0 And im.Top - speed < ball1.Bottom) Then
                ' completare loveste din sus
                nrlovituri += 1
                If dirx = 0 Then
                    'completare loveste sus
                    diry = -diry

                    ball1.Left += 2 * (speed * dirx)
                    ball1.Top += 2 * (speed * diry)

                    im2 = im
                    ver = True
                    im.Tag -= 1
                    scor += 1
                    If im.Tag = 0 Then
                        im.Image = My.Resources.background
                        nrblock -= 1
                        scor += 4
                    End If
                ElseIf dirx > 0 Then
                    'completare loveste din stanga sus
                    If (im.Top - speed > ball1.Top) And (im.Left - speed > ball1.Left) Then
                        'compleare loveste din stanga sus in colt stanga sus
                        dirx = -dirx
                        diry = -diry

                        ball1.Left += 2 * (speed * dirx)
                        ball1.Top += 2 * (speed * diry)

                        im2 = im
                        ver = True
                        im.Tag -= 1
                        scor += 1
                        If im.Tag = 0 Then
                            im.Image = My.Resources.background
                            nrblock -= 1
                            scor += 4
                        End If
                    ElseIf (im.Top - speed > ball1.Top) And (im.Left - speed < ball1.Left) Then
                        'completare loveste din stanga sus in partea de sus
                        diry = -diry

                        ball1.Left += 2 * (speed * dirx)
                        ball1.Top += 2 * (speed * diry)

                        im2 = im
                        ver = True
                        im.Tag -= 1
                        scor += 1
                        If im.Tag = 0 Then
                            im.Image = My.Resources.background
                            nrblock -= 1
                            scor += 4
                        End If
                    ElseIf (im.Top - speed < ball1.Top) And (im.Left - speed > ball1.Left) Then
                        'completare loveste din stanga sus in partea stanga
                        dirx = -dirx

                        ball1.Left += 2 * (speed * dirx)
                        ball1.Top += 2 * (speed * diry)

                        im2 = im
                        ver = True
                        im.Tag -= 1
                        scor += 1
                        If im.Tag = 0 Then
                            im.Image = My.Resources.background
                            nrblock -= 1
                            scor += 4
                        End If
                    End If
                ElseIf dirx < 0 Then
                    'loveste din dreapta sus
                    If (im.Top - speed > ball1.Top) And (im.Right + speed < ball1.Right) Then
                        'completare loveste din dreapta sus in colt dreapta sus
                        dirx = -dirx
                        diry = -diry

                        ball1.Left += 2 * (speed * dirx)
                        ball1.Top += 2 * (speed * diry)

                        im2 = im
                        ver = True
                        im.Tag -= 1
                        scor += 1
                        If im.Tag = 0 Then
                            im.Image = My.Resources.background
                            nrblock -= 1
                            scor += 4
                        End If
                    ElseIf (im.Top - speed > ball1.Top) And (im.Right + speed > ball1.Right) Then
                        'completare loveste din dreapta sus in partea de sus
                        diry = -diry

                        ball1.Left += 2 * (speed * dirx)
                        ball1.Top += 2 * (speed * diry)

                        im2 = im
                        ver = True
                        im.Tag -= 1
                        scor += 1
                        If im.Tag = 0 Then
                            im.Image = My.Resources.background
                            nrblock -= 1
                            scor += 4
                        End If
                    ElseIf (im.Top - speed > ball1.Top) And (im.Right + speed < ball1.Right) Then
                        'completare loveste din dreapte sus in partea dreapta
                        dirx = -dirx

                        ball1.Left += 2 * (speed * dirx)
                        ball1.Top += 2 * (speed * diry)

                        im2 = im
                        ver = True
                        im.Tag -= 1
                        scor += 1
                        If im.Tag = 0 Then
                            im.Image = My.Resources.background
                            nrblock -= 1
                            scor += 4
                        End If
                    End If
                End If


            End If
            Timer2.Start()
        End If

    End Sub

End Class