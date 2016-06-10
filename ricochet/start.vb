Imports System.IO
Imports Microsoft.VisualBasic.PowerPacks
Imports System.Text
Public Class start
    Dim sname As String
    Public m(21, 25) As Integer

    Dim colo() As Color = New Color() {Color.Red, Color.Aqua, Color.Blue, Color.Brown, Color.Gainsboro, Color.Goldenrod}
    Private Sub Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        '    Me.Size = New Size(Create.Width / 2, Create.Height / 2)
        Me.Location = New Point(Create.Width / 2, Create.Height / 6)
        Me.TopMost = True



        Dim dir As String = System.IO.Directory.GetCurrentDirectory
        For Each File As String In My.Computer.FileSystem.GetFiles(dir)
            If File.Substring(File.LastIndexOf("."), 4).CompareTo(".lvl") = 0 Then
                ListBox1.Items.Add(File.Substring(File.LastIndexOf("\") + 1, File.Length - (File.LastIndexOf("\") + 1)))
            End If
        Next




    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
    End Sub


    Private Sub ListBox1_Click(sender As Object, e As EventArgs) Handles ListBox1.Click

        sname = ListBox1.SelectedItem.ToString.Substring(0, ListBox1.SelectedItem.ToString.LastIndexOf("."))

    End Sub



    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click


        sname = sname & ".lvl"
        Dim k As Integer = 0
        '  Dim fs As FileStream = File.OpenRead(name)
        Dim s As String = File.ReadAllText(sname)

        For i As Integer = 0 To 20
            For j As Integer = 0 To 25
                m(i, j) = Val(s(k))
                k = k + 2

                ' s = New UTF8Encoding(True).GetBytes(Create.m(i, j) & " ")
                ' fs.Write(s, 0, s.Length)
            Next
            ' s = New UTF8Encoding(True).GetBytes(vbNewLine)
            ' fs.Write(s, 0, s.Length)
            k = k + 2
        Next


        game.Visible = True


    End Sub









    
End Class