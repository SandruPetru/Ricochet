Public Class Options
    Dim ovs(10) As Microsoft.VisualBasic.PowerPacks.OvalShape
    Dim validareNume As Boolean = False
    Dim fs As New FullscreenClass
    Private Sub Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        For i As Integer = 0 To 9
            ovs(i).Location = New Point(CInt(Int((fs.ScreenX * Rnd()) + 1)), CInt(Int((fs.ScreenY * Rnd()) + 1)))

        Next
        Dim l As Integer = fs.ScreenY / 8
        fs.FullScreen(Me, True)
        Dim indice As String = My.Settings.ballName.Last
        Dim n As Integer = CInt(indice)
        For i As Integer = 1 To 5
            If (RadioButton1.TabIndex = n) Then
                RadioButton1.Checked = True
            ElseIf RadioButton2.TabIndex = n Then
                RadioButton2.Checked = True
            ElseIf RadioButton3.TabIndex = n Then
                RadioButton3.Checked = True
            ElseIf RadioButton4.TabIndex = n Then
                RadioButton4.Checked = True
            ElseIf RadioButton5.TabIndex = n Then
                RadioButton5.Checked = True
            End If
        Next
        indice = My.Settings.rocketName.Last
        n = CInt(indice)
        For i As Integer = 1 To 4
            If (RadioButton9.TabIndex = n) Then
                RadioButton9.Checked = True
            ElseIf RadioButton6.TabIndex = n Then
                RadioButton6.Checked = True
            ElseIf RadioButton7.TabIndex = n Then
                RadioButton7.Checked = True
            ElseIf RadioButton8.TabIndex = n Then
                RadioButton8.Checked = True
           
            End If
        Next

        TextBox1.Text = My.Settings.numeJucator
        Label3.Location = New Point(30, Me.Height - Me.Height / 3)
        TextBox1.Location = New Point(33 + Label3.Width, Me.Height - Me.Height / 3)
        Timer1.Start()



    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Me.Close()
    End Sub


    Private Sub Label1_MouseMove(sender As Object, e As MouseEventArgs) Handles Label1.MouseMove
        Label1.ForeColor = Color.Red
        Label1.Font = New Font(Label1.Font.Name, 30.0F, Label1.Font.Style, Label1.Font.Unit)



    End Sub
    Private Sub Label2_MouseMove(sender As Object, e As MouseEventArgs) Handles Label2.MouseMove
        Label2.ForeColor = Color.Red
        Label2.Font = New Font(Label2.Font.Name, 30.0F, Label2.Font.Style, Label2.Font.Unit)



    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.Black
        Label1.Font = New Font(Label1.Font.Name, 20.25F, Label1.Font.Style, Label1.Font.Unit)
    End Sub
    Private Sub Label2_MouseLeave(sender As Object, e As EventArgs) Handles Label2.MouseLeave
        Label2.ForeColor = Color.Black
        Label2.Font = New Font(Label1.Font.Name, 20.25F, Label2.Font.Style, Label2.Font.Unit)
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

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If RadioButton1.Checked Then
            My.Settings.ballName = "Ball1"
        ElseIf RadioButton2.Checked Then
            My.Settings.ballName = "Ball2"
        ElseIf RadioButton3.Checked Then
            My.Settings.ballName = "Ball3"
        ElseIf RadioButton4.Checked Then
            My.Settings.ballName = "Ball4"
        ElseIf RadioButton5.Checked Then
            My.Settings.ballName = "Ball5"
        End If
        If RadioButton6.Checked Then
            My.Settings.rocketName = "Rocket2"
        ElseIf RadioButton7.Checked Then
            My.Settings.rocketName = "Rocket3"
        ElseIf RadioButton8.Checked Then
            My.Settings.rocketName = "Rocket4"
        ElseIf RadioButton9.Checked Then
            My.Settings.rocketName = "Rocket1"
        End If
        Dim s As String = TextBox1.Text
        s = s.Replace(" ", "")
        s = s.Replace("`", "")
        s = s.Replace("~", "")
        s = s.Replace("-", "")
        s = s.Replace("+", "")
        s = s.Replace(".", "")
        s = s.Replace(",", "")
        s = s.Replace(";", "")
        If s.Length > 0 Then
            My.Settings.numeJucator = TextBox1.Text
        End If
        Me.Close()
    End Sub

    
End Class