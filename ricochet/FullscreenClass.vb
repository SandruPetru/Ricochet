Public Class FullscreenClass
    Public Declare Function SetWindowPos Lib "user32.dll" Alias "SetWindowPos" (ByVal hWnd As IntPtr, ByVal hWndIntertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As Integer) As Boolean

    Private Declare Function GetSystemMetrics Lib "user32.dll" Alias "GetSystemMetrics" (ByVal Which As Integer) As Integer

    Private Const SM_CXSCREEN As Integer = 0
    Private Const SM_CYSCREEN As Integer = 1
    Public Shared HWND_TOP As IntPtr = IntPtr.Zero
    Public Const SWP_SHOWWINDOW As Integer = 64

    Public ReadOnly Property ScreenX() As Integer
        Get
            Return GetSystemMetrics(SM_CXSCREEN)
        End Get
    End Property

    Public ReadOnly Property ScreenY() As Integer
        Get
            Return GetSystemMetrics(SM_CYSCREEN)
        End Get
    End Property

    Public Sub FullScreen(ByVal frm As Form, ByVal boolTopOptional As Boolean)
        frm.WindowState = FormWindowState.Maximized
        frm.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        ' frm.TopMost = boolTopOptional
        SetWindowPos(frm.Handle, HWND_TOP, 0, 0, ScreenX, ScreenY, SWP_SHOWWINDOW)
    End Sub

End Class
