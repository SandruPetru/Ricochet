Imports System.IO
Imports System.Text
Public Class Save
    Dim colo() As Color = New Color() {Color.Red, Color.Aqua, Color.Blue, Color.Brown, Color.Gainsboro, Color.Goldenrod}
    Private Sub Save_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        '    Me.Size = New Size(Create.Width / 2, Create.Height / 2)
        Me.Location = New Point(Create.Width / 2 - Me.Width / 2, Create.Height / 6)
        Me.TopMost = True
        TextBox1.Text = "new level " & ListBox1.Items.Count


        Dim dir As String = System.IO.Directory.GetCurrentDirectory
        For Each File As String In My.Computer.FileSystem.GetFiles(dir)
            If File.Substring(File.LastIndexOf("."), 4).CompareTo(".lvl") = 0 Then
                ListBox1.Items.Add(File.Substring(File.LastIndexOf("\") + 1, File.Length - (File.LastIndexOf("\") + 1) - 4))
            End If
        Next




    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Me.Close()
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim name As String
        name = TextBox1.Text
        name = name & ".lvl"
        Dim fs As FileStream = File.Create(name)

        Dim s As Byte()
        ' Dim info As Byte() = New UTF8Encoding(True).GetBytes("This is some text in the file.")
        For i As Integer = 0 To 20
            For j As Integer = 0 To 25
                s = New UTF8Encoding(True).GetBytes(Create.m(i, j) & " ")
                fs.Write(s, 0, s.Length)
            Next
            s = New UTF8Encoding(True).GetBytes(vbNewLine)
            fs.Write(s, 0, s.Length)

        Next
        'fs.Write(info, 0, info.Length)
        fs.Close()
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim name As String
        name = TextBox1.Text
        name = name & ".lvl"
        Dim k As Integer = 0
        '  Dim fs As FileStream = File.OpenRead(name)
        Dim s As String = File.ReadAllText(name)
        TextBox1.Text = s
        For i As Integer = 0 To 20
            For j As Integer = 0 To 25
                Create.m(i, j) = Val(s(k))
                k = k + 2
                ' s = New UTF8Encoding(True).GetBytes(Create.m(i, j) & " ")
                ' fs.Write(s, 0, s.Length)
            Next
            ' s = New UTF8Encoding(True).GetBytes(vbNewLine)
            ' fs.Write(s, 0, s.Length)
            k = k + 2
        Next
        LoadGame()

    End Sub

    Private Sub ListBox1_Click(sender As Object, e As EventArgs) Handles ListBox1.Click

        TextBox1.Text = ListBox1.SelectedItem.ToString.Substring(0, ListBox1.SelectedItem.ToString.Length)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Dim dir As String = System.IO.Directory.GetCurrentDirectory
        My.Computer.FileSystem.DeleteFile(dir & "\" & ListBox1.SelectedItem.ToString.Substring(0, ListBox1.SelectedItem.ToString.LastIndexOf(".")) & ".lvl")
        Dim ind As Integer = ListBox1.SelectedIndex
        ListBox1.SelectedItem = Nothing
        ' ListBox1.ClearSelected()
        ListBox1.Items.RemoveAt(ind)
        'ListBox1.Refresh()
    End Sub

    Private Sub LoadGame()
        For i As Integer = 0 To 20
            For j As Integer = 0 To 25

                If Create.m(i, j) > 0 Then

                    Create.b(i, j).CornerRadius = 10
                    Create.b(i, j).BackColor = colo(Create.m(i, j) - 1)

                Else
                    Create.b(i, j).CornerRadius = 0
                    Create.b(i, j).BackColor = Color.Transparent
                End If



            Next
        Next
    End Sub
End Class