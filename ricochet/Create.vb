Imports Microsoft.VisualBasic.PowerPacks
Imports System
Imports System.IO
Imports System.Text
Public Class Create
    Dim fs As New FullscreenClass
    Public m(21, 25) As Integer
    Public b(21, 25) As RectangleShape
    Dim l As New ShapeContainer
    Dim c As New ShapeContainer
    Dim lbl(6) As Label
    Dim block1(6) As RectangleShape
    Dim mBlock1(6) As Integer
    Dim c1 As New ShapeContainer
    Dim block2(300) As RectangleShape
    Dim ind As Integer = 0
    Dim blockselect As RectangleShape
    Dim mBlockselect As Integer
    Dim colo() As Color = New Color() {Color.Red, Color.Aqua, Color.Blue, Color.Brown, Color.Gainsboro, Color.Goldenrod}
    Dim xx, yy As Integer


    Private Sub Create_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fs.FullScreen(Me, True)
        Panel1.BackColor = Color.FromArgb(30, 70, 100)
        Panel1.Size = New Size(fs.ScreenX - (50 * 21 + 102), fs.ScreenY)
        Panel1.Location = New Point(50 * 21 + 102, 0)

        Label1.Location = New Point(0, Panel1.Height - 2 * Label1.Height)

        Label2.Location = New Point(0, (Panel1.Height - 2 * Label1.Height) - 1.5 * Label1.Height)
        Label3.Location = New Point(0, (Panel1.Height - 2 * Label1.Height) - 1.5 * Label1.Height - 1.5 * Label2.Height)
       


        Panel2.Location = New Point(50, 30)
        Panel2.Size = New Size(50 * 21 + 2, fs.ScreenY)



        c1.Parent = Panel2
        c.Parent = Panel1
        For i As Integer = 0 To 5
            mBlock1(i) = i + 1
            block1(i) = New RectangleShape
            block1(i).Left = 0
            block1(i).Parent = c
            block1(i).Top = 50 + i * 50
            block1(i).Width = 100
            block1(i).Height = 50
            block1(i).BackgroundImageLayout = ImageLayout.Stretch
            block1(i).BackStyle = BackStyle.Transparent
            
            block1(i).BackgroundImage = My.Resources.Block_a1
            block1(i).BackColor = colo(i)
            lbl(i) = New Label
            lbl(i).Parent = c
            lbl(i).Left = block1(i).Right + 5
            lbl(i).Top = block1(i).Top + 8
            lbl(i).Font = New Font(lbl(i).Font.Name, lbl(i).Font.Size + 10)
            lbl(i).Text = "X " + (i + 1).ToString
            lbl(i).Visible = True
        Next
        
        block1(0).BackgroundImage = My.Resources.Block_a1
        block1(1).BackgroundImage = My.Resources.Block_a2
        block1(2).BackgroundImage = My.Resources.Block_a3
        block1(3).BackgroundImage = My.Resources.Block_a4
        block1(4).BackgroundImage = My.Resources.Block_a5
        block1(5).BackgroundImage = My.Resources.Block_a6


        blockselect = New RectangleShape
        blockselect.Parent = c
        blockselect.Left = 0
        blockselect.Top = 400
        blockselect.Width = 100
        blockselect.Height = 50


        For i As Integer = 0 To 5
            AddHandler block1(i).Click, AddressOf Block1_Click
        Next

       
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
        Initialize()
        For i As Integer = 0 To 20
            For j As Integer = 0 To 25
                AddHandler b(i, j).Click, AddressOf mBlock_Click

            Next
        Next



    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        '   Dim name As String
        '   name = TextBox1.Text
        '   name = name & ".txt"
        '   Dim fs As FileStream = File.Create(name)
        '  Dim s As Byte()
        ' Dim info As Byte() = New UTF8Encoding(True).GetBytes("This is some text in the file.")
        '     For i As Integer = 0 To 21
        'For j As Integer = 0 To 25
        's = New UTF8Encoding(True).GetBytes(m(i, j) & " ")
        '   fs.Write(s, 0, s.Length)
        '    Next
        '  s = New UTF8Encoding(True).GetBytes(vbNewLine)
        '  fs.Write(s, 0, s.Length)

        '   Next
        ' fs.Write(info, 0, info.Length)
        '   fs.Close()
        Save.Visible = True
    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        For i As Integer = 0 To 20
            For j As Integer = 0 To 25
                m(i, j) = 0
                b(i, j).BackgroundImage = Nothing
                b(i, j).CornerRadius = 0
                b(i, j).BackColor = Color.Transparent
                b(i, j).BackStyle = BackStyle.Opaque

            Next
        Next
    End Sub
    Private Sub Block1_Click(sender As Object, e As EventArgs)

        Dim x As Integer
        x = MousePosition.Y
        Select Case x
            Case 50 To 99
                mBlockselect = 1
                blockselect.BackgroundImageLayout = ImageLayout.Stretch
                blockselect.BackgroundImage = My.Resources.Block_a1
                'blockselect.BackColor = block1(0).BackColor
                blockselect.BackStyle = BackStyle.Opaque
            Case 100 To 149
                mBlockselect = 2
                'blockselect.BackColor = block1(1).BackColor
                blockselect.BackgroundImageLayout = ImageLayout.Stretch
                blockselect.BackgroundImage = My.Resources.Block_a2
                blockselect.BackStyle = BackStyle.Opaque
            Case 150 To 199
                mBlockselect = 3
                blockselect.BackgroundImageLayout = ImageLayout.Stretch
                blockselect.BackgroundImage = My.Resources.Block_a3
                'blockselect.BackColor = block1(2).BackColor
                blockselect.BackStyle = BackStyle.Opaque
            Case 200 To 249
                mBlockselect = 4
                blockselect.BackgroundImageLayout = ImageLayout.Stretch
                blockselect.BackgroundImage = My.Resources.Block_a4
                'blockselect.BackColor = block1(3).BackColor
                blockselect.BackStyle = BackStyle.Opaque
            Case 250 To 299
                mBlockselect = 5
                blockselect.BackgroundImageLayout = ImageLayout.Stretch
                blockselect.BackgroundImage = My.Resources.Block_a5
                'blockselect.BackColor = block1(4).BackColor
                blockselect.BackStyle = BackStyle.Opaque
            Case 300 To 349
                mBlockselect = 6
                blockselect.BackgroundImageLayout = ImageLayout.Stretch
                blockselect.BackgroundImage = My.Resources.Block_a6
                ' blockselect.BackColor = block1(5).BackColor
                blockselect.BackStyle = BackStyle.Opaque
            Case Else
                blockselect.BackStyle = BackStyle.Transparent
        End Select

    End Sub

    Private Sub DrawRectangle()
        Dim canvas As New Microsoft.VisualBasic.PowerPacks.ShapeContainer
        Dim rect1 As New Microsoft.VisualBasic.PowerPacks.RectangleShape
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the RectangleShape.
        rect1.Parent = canvas
        ' Set the location and size of the rectangle.
        rect1.Left = 10
        rect1.Top = 10
        rect1.Width = 300
        rect1.Height = 100
    End Sub

    Private Sub mBlock_Click(sender As Object, e As EventArgs)
        xx = (MousePosition.X - 75) / 50
        yy = (MousePosition.Y - 40) / 20

        Dim a As System.Windows.Forms.MouseEventArgs
        a = e
        '  xx = CInt((MousePosition.X - 25) / 50)
        ' xx = xx * 50 - 50
        ' block2(ind) = New RectangleShape
        ' block2(ind).Parent = c1
        ' block2(ind).Left = xx
        ' xx = CInt((MousePosition.Y - 25) / 20)
        ' xx = xx * 20

        ' block2(ind).Top = xx
        ' block2(ind).Width = 50
        'block2(ind).Height = 20
        ' block2(ind).CornerRadius = 10
        ' block2(ind).BackStyle = BackStyle.Opaque
        ' block2(ind).BackColor = blockselect.BackColor
        ' ind += 1
        If a.Button = Windows.Forms.MouseButtons.Left Then
            '   xx = (MousePosition.X - 75) / 50
            '  yy = (MousePosition.Y - 40) / 20
            '  b(xx, yy).BackColor = blockselect.BackColor
            b(xx, yy).BackgroundImageLayout = ImageLayout.Stretch
            b(xx, yy).BackgroundImage = blockselect.BackgroundImage
            b(xx, yy).CornerRadius = 10
            m(xx, yy) = mBlockselect
        Else
            '   xx = (MousePosition.X - 75) / 50
            '  yy = (MousePosition.Y - 40) / 20
            b(xx, yy).BackgroundImage = Nothing
            b(xx, yy).BackColor = Color.Transparent
            b(xx, yy).CornerRadius = 0
            m(xx, yy) = 0
        End If

    End Sub

    Private Sub Initialize()
        For i As Integer = 0 To 20
            For j As Integer = 0 To 25
                m(i, j) = 0
                b(i, j) = New RectangleShape
                b(i, j).Parent = c1
                b(i, j).Left = i * 50
                b(i, j).Top = j * 20
                b(i, j).Width = 50
                b(i, j).Height = 20
                b(i, j).CornerRadius = 0
                b(i, j).BackColor = Color.Transparent
                b(i, j).BackStyle = BackStyle.Opaque

            Next
        Next
    End Sub

    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        Label1.ForeColor = Color.Red
        Label1.Font = New Font(Label1.Font.Name, 30.0F, Label1.Font.Style, Label1.Font.Unit)



    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.Black
        Label1.Font = New Font(Label1.Font.Name, 20.25F, Label1.Font.Style, Label1.Font.Unit)
    End Sub

    Private Sub Label2_MouseMove(sender As Object, e As MouseEventArgs) Handles Label2.MouseMove
        Label2.ForeColor = Color.Red
        Label2.Font = New Font(Label2.Font.Name, 30.0F, Label2.Font.Style, Label2.Font.Unit)



    End Sub

    Private Sub Label2_MouseLeave(sender As Object, e As EventArgs) Handles Label2.MouseLeave
        Label2.ForeColor = Color.Black
        Label2.Font = New Font(Label2.Font.Name, 20.25F, Label2.Font.Style, Label2.Font.Unit)
    End Sub

    Private Sub Label3_MouseMove(sender As Object, e As MouseEventArgs) Handles Label3.MouseMove
        Label3.ForeColor = Color.Red
        Label3.Font = New Font(Label3.Font.Name, 30.0F, Label3.Font.Style, Label3.Font.Unit)



    End Sub

    Private Sub Label3_MouseLeave(sender As Object, e As EventArgs) Handles Label3.MouseLeave
        Label3.ForeColor = Color.Black
        Label3.Font = New Font(Label3.Font.Name, 20.25F, Label3.Font.Style, Label3.Font.Unit)
    End Sub
End Class