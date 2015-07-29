Imports System.Runtime.InteropServices

Class TransparentTextBox
    Inherits RichTextBox

    Public Sub New()
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Me.ScrollBars = RichTextBoxScrollBars.None
    End Sub

    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)> _
    Private Shared Function LoadLibrary(ByVal lpFileName As String) As IntPtr
    End Function

    Protected Overloads Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            Dim prams As CreateParams = MyBase.CreateParams
            If LoadLibrary("msftedit.dll") <> IntPtr.Zero Then
                prams.ExStyle = prams.ExStyle Or &H20 ' transparent
                prams.ClassName = "RICHEDIT50W"
            End If
            Return prams
        End Get
    End Property
End Class