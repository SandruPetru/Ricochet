Imports System.IO
Imports System.Diagnostics

Public Class Form1
    Dim ovs(10) As Microsoft.VisualBasic.PowerPacks.OvalShape

    Dim fs As New FullscreenClass



    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Randomize()




        ovs(0) = OvalShape1
        ovs(1) = OvalShape2
        ovs(2) = OvalShape3
        ovs(3) = OvalShape4
        ovs(4) = OvalShape5
        ovs(5) = OvalShape6
        ovs(6) = OvalShape7
        ovs(7) = OvalShape8
        ovs(8) = OvalShape9
        ovs(9) = OvalShape10
        For i As Integer = 0 To 4
            ovs(i).Location = New Point(CInt(Int(((fs.ScreenX / 2) * Rnd()) + 1)), CInt(Int((fs.ScreenY * Rnd()) + 1)))

        Next
        For i As Integer = 5 To 9
            ovs(i).Location = New Point(CInt(Int(((fs.ScreenX / 2) * Rnd()) + (fs.ScreenX / 2))), CInt(Int((fs.ScreenY * Rnd()) + 1)))

        Next
        Dim l As Integer = fs.ScreenY / 8
        fs.FullScreen(Me, True)
        Label1.Location = New Point(fs.ScreenX / 2 - Label1.Width / 2, l)
        Label4.Location = New Point(fs.ScreenX / 2 - Label4.Width / 2, 2 * l)
        Label2.Location = New Point(fs.ScreenX / 2 - Label2.Width / 2, 3 * l)
        Label3.Location = New Point(fs.ScreenX / 2 - Label3.Width / 2, 6 * l)
        Label5.Location = New Point(2 * Label5.Width, 6 * l)
        Label6.Location = New Point(fs.ScreenX - 2 * Label5.Width - Label6.Width, 6 * l)
        Timer1.Start()




    End Sub


    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        start.Visible = True

    End Sub


    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        Label1.ForeColor = Color.Red
        Label1.Font = New Font(Label1.Font.Name, 30.0F, Label1.Font.Style, Label1.Font.Unit)



    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.Black
        Label1.Font = New Font(Label1.Font.Name, 20.25F, Label1.Font.Style, Label1.Font.Unit)
    End Sub



    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Options.Visible = True
    End Sub


    Private Sub Label2_MouseMove(sender As Object, e As MouseEventArgs) Handles Label2.MouseMove
        Label2.ForeColor = Color.Red
        Label2.Font = New Font(Label2.Font.Name, 30.0F, Label2.Font.Style, Label2.Font.Unit)



    End Sub

    Private Sub Label2_MouseLeave(sender As Object, e As EventArgs) Handles Label2.MouseLeave
        Label2.ForeColor = Color.Black
        Label2.Font = New Font(Label2.Font.Name, 20.25F, Label2.Font.Style, Label2.Font.Unit)
    End Sub




    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
    End Sub


    Private Sub Label3_MouseMove(sender As Object, e As MouseEventArgs) Handles Label3.MouseMove
        Label3.ForeColor = Color.Red
        Label3.Font = New Font(Label3.Font.Name, 30.0F, Label3.Font.Style, Label3.Font.Unit)



    End Sub

    Private Sub Label3_MouseLeave(sender As Object, e As EventArgs) Handles Label3.MouseLeave
        Label3.ForeColor = Color.Black
        Label3.Font = New Font(Label3.Font.Name, 20.25F, Label3.Font.Style, Label3.Font.Unit)
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Create.Visible = True
    End Sub


    Private Sub Label4_MouseMove(sender As Object, e As MouseEventArgs) Handles Label4.MouseMove
        Label4.ForeColor = Color.Red
        Label4.Font = New Font(Label4.Font.Name, 30.0F, Label4.Font.Style, Label4.Font.Unit)



    End Sub

    Private Sub Label4_MouseLeave(sender As Object, e As EventArgs) Handles Label4.MouseLeave
        Label4.ForeColor = Color.Black
        Label4.Font = New Font(Label4.Font.Name, 20.25F, Label4.Font.Style, Label4.Font.Unit)

    End Sub
    Private Sub Label5_MouseMove(sender As Object, e As MouseEventArgs) Handles Label5.MouseMove
        Label5.ForeColor = Color.Red
        Label5.Font = New Font(Label5.Font.Name, 30.0F, Label5.Font.Style, Label5.Font.Unit)



    End Sub

    Private Sub Label5_MouseLeave(sender As Object, e As EventArgs) Handles Label5.MouseLeave
        Label5.ForeColor = Color.Black
        Label5.Font = New Font(Label5.Font.Name, 20.25F, Label5.Font.Style, Label5.Font.Unit)
    End Sub

    Private Sub Label6_MouseMove(sender As Object, e As MouseEventArgs) Handles Label6.MouseMove
        Label6.ForeColor = Color.Red
        Label6.Font = New Font(Label6.Font.Name, 30.0F, Label6.Font.Style, Label6.Font.Unit)



    End Sub

    Private Sub Label6_MouseLeave(sender As Object, e As EventArgs) Handles Label6.MouseLeave
        Label6.ForeColor = Color.Black
        Label6.Font = New Font(Label6.Font.Name, 20.25F, Label6.Font.Style, Label6.Font.Unit)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        OvalShape1.Location = New Point(OvalShape1.Location.X - CInt(Int((20 * Rnd()) - 10)), OvalShape1.Location.Y - CInt(Int((10 * Rnd()) + 1)))
        For i As Integer = 0 To 9
            If ovs(i).Location.Y < 1 Then
                ovs(i).Location = New Point(ovs(i).Location.X - CInt(Int((20 * Rnd()) - 10)), fs.ScreenY)
            End If
            ovs(i).Location = New Point(ovs(i).Location.X - CInt(Int((20 * Rnd()) - 10)), ovs(i).Location.Y - CInt(Int((10 * Rnd()) + 1)))
        Next
    End Sub
    Sub LoadCursorFromMemory()
        Dim cur As Cursor '= New Cursor(New IO.MemoryStream(My.Resources.cur1028))
        If Not cur Is Nothing Then
            Me.Cursor = cur
        Else
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim pdf As Byte() = My.Resources.MANUAL__DE__UTILIZARE

        Using tmp As New FileStream("Manual.pdf", FileMode.Create)

            tmp.Write(pdf, 0, pdf.Length)

        End Using

        Process.Start("Manual.pdf")



    End Sub
End Class

