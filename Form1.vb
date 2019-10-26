Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ShowInTaskbar = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Location = New Point(My.Settings.locationx)
        Me.Size = New Size(My.Settings.width)





        borderchanger()


    End Sub


    Public Function borderchanger()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Height = 40

        Dim p As New Drawing2D.GraphicsPath()
        p.StartFigure()
        p.AddArc(New Rectangle(0, 0, 40, 40), 180, 90)
        p.AddLine(40, 0, Me.Width - 40, 0)
        p.AddArc(New Rectangle(Me.Width - 40, 0, 40, 40), -90, 90)
        p.AddLine(Me.Width, 40, Me.Width, Me.Height - 40)
        p.AddArc(New Rectangle(Me.Width - 40, Me.Height - 40, 40, 40), 0, 90)
        p.AddLine(Me.Width - 40, Me.Height, 40, Me.Height)
        p.AddArc(New Rectangle(0, Me.Height - 40, 40, 40), 90, 90)
        p.CloseFigure()
        Me.Region = New Region(p)
        Return (True)
    End Function

 



    

    Dim changing As Boolean
    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged, MyBase.LocationChanged
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        End If
        If changing = True Then
            borderchanger()
            My.Settings.width = Me.Size
            My.Settings.locationx = Me.Location
            Try
                System.Diagnostics.Process.Start(System.IO.Path.GetFullPath("restart.exe"))
            Catch
            End Try
        End If

    End Sub

    Private Sub Form1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.FormBorderStyle = FormBorderStyle.Sizable
        changing = True
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Try
            System.Diagnostics.Process.Start(System.IO.Path.GetFullPath("google.exe"))
        Catch
            Dim Msg, Style, Title, Help, Ctxt
            Msg = "reinstall this app"    ' Define message.
            Style = vbOKOnly + vbCritical + vbDefaultButton2    ' Define buttons.
            Title = "Error"    ' Define title.
            Help = "DEMO.HLP"    ' Define Help file.
            Ctxt = 1000    ' Define topic context. 
            ' Display message.
            MsgBox(Msg, Style, Title)

        End Try
    End Sub

   
  
   
    
    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        Try
            System.Diagnostics.Process.Start(System.IO.Path.GetFullPath("google.exe"))
        Catch
            Dim Msg, Style, Title, Help, Ctxt
            Msg = "reinstall this app"    ' Define message.
            Style = vbOKOnly + vbCritical + vbDefaultButton2    ' Define buttons.
            Title = "Error"    ' Define title.
            Help = "DEMO.HLP"    ' Define Help file.
            Ctxt = 1000    ' Define topic context. 
            ' Display message.
            MsgBox(Msg, Style, Title)

        End Try
    End Sub

    
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        MyBase.OnClosing(e)
        My.Settings.locationx = Me.Location
        My.Settings.width = Me.Size
        My.Settings.Save()
    End Sub
End Class
