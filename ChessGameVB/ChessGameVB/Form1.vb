Imports System.Drawing

Public Class Form1
    Dim G As Graphics
    Dim BBG As Graphics
    Dim BB As Bitmap
    Dim r As Rectangle

    Dim tSec As Integer = TimeOfDay.Second
    Dim tTicks As Integer = 0
    Dim MaxTicks As Integer = 0

    Dim IsRunning As Boolean = True

    Dim XCor, YCor As Single

    Dim Tilesize As Integer = 80

    Dim WidthMap As Integer = 720
    Dim HeightMap As Integer = 720

    Dim XcorClick, YCorClick As Integer

    Dim Map(7, 7) As Short

    Dim PeiceMap(7, 7) As String

    Dim CurrentPeice As String
    Dim CurrentPeiceColor As String
    Dim Paths As List(Of Point)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Show()
        Me.Focus()

        Static Black As Boolean = True
        Static White As Boolean = False

        PeiceMap(0, 0) = "BR"
        PeiceMap(1, 0) = "BN"
        PeiceMap(2, 0) = "BB"
        PeiceMap(3, 0) = "BQ"
        PeiceMap(4, 0) = "BK"
        PeiceMap(5, 0) = "BB"
        PeiceMap(6, 0) = "BN"
        PeiceMap(7, 0) = "BR"



        For i As Integer = 0 To 7
            PeiceMap(i, 1) = "BP"
        Next

        For i As Integer = 0 To 7
            PeiceMap(i, 6) = "WP"
        Next

        PeiceMap(0, 7) = "WR"
        PeiceMap(1, 7) = "WN"
        PeiceMap(2, 7) = "WB"
        PeiceMap(3, 7) = "WQ"
        PeiceMap(4, 7) = "WK"
        PeiceMap(5, 7) = "WB"
        PeiceMap(6, 7) = "WN"
        PeiceMap(7, 7) = "WR"

        For x As Integer = 0 To 7
            If White = True Then
                Black = True
                White = False
            ElseIf Black = True Then
                White = True
                Black = False
            End If
            For y As Integer = 0 To 7
                If White = True Then
                    Map(x, y) = 1
                    White = False
                    Black = True
                ElseIf Black = True Then
                    Map(x, y) = 2
                    White = True
                    Black = False
                End If
            Next
        Next

        ' INITIALIZE GRAPHICS OBJECTS
        G = Me.CreateGraphics
        BB = New Bitmap(WidthMap, HeightMap)

        StartGameLoop()
    End Sub

    Private Sub StartGameLoop()
        Do While IsRunning = True
            ' KEEP APP RESPONSIVE
            Application.DoEvents()

            '1.) Check user input
            '2.) Run AI
            '3.) Update Object Data (Object Positions, Status, etc.)
            '4.) Check Triggers and Conditions
            '5.) Draw Graphics
            DrawGraphics()
            '6.) Playing Sound Effects & Music

            ' UPDATE TICK COUNTER
            TickCounter()
        Loop
    End Sub

    Dim Trigger As Boolean = False

    Private Sub DrawGraphics()
        Me.SuspendLayout()
        For X = 0 To 7
            For Y = 0 To 7
                r = New Rectangle(X * Tilesize, Y * Tilesize, Tilesize, Tilesize)
                Select Case Map(X, Y)
                    Case 1
                        G.FillRectangle(Brushes.White, r)
                    Case 2
                        G.FillRectangle(Brushes.Gray, r)
                    Case Else
                        MsgBox("FATAL ERROR")
                End Select
                G.DrawRectangle(Pens.Black, r)
                Select Case PeiceMap(X, Y)
                    Case "BR"
                        G.DrawImageUnscaledAndClipped(My.Resources.BRookTrans, r)
                    Case "BN"
                        G.DrawImageUnscaledAndClipped(My.Resources.BKnightTrans, r)
                    Case "BB"
                        G.DrawImageUnscaledAndClipped(My.Resources.BBishopTrans, r)
                    Case "BQ"
                        G.DrawImageUnscaledAndClipped(My.Resources.BQuenTrans, r)
                    Case "BK"
                        G.DrawImageUnscaledAndClipped(My.Resources.BKingTrans, r)
                    Case "BB"
                        G.DrawImageUnscaledAndClipped(My.Resources.BBishopTrans, r)
                    Case "BN"
                        G.DrawImageUnscaledAndClipped(My.Resources.BKnightTrans, r)
                    Case "BR"
                        G.DrawImageUnscaledAndClipped(My.Resources.BRookTrans, r)
                    Case "BP"
                        G.DrawImageUnscaledAndClipped(My.Resources.BPawnTrans, r)
                    Case "WR"
                        G.DrawImageUnscaledAndClipped(My.Resources.WRookTrans, r)
                    Case "WN"
                        G.DrawImageUnscaledAndClipped(My.Resources.WKnightTrans, r)
                    Case "WB"
                        G.DrawImageUnscaledAndClipped(My.Resources.WBishopTrans, r)
                    Case "WQ"
                        G.DrawImageUnscaledAndClipped(My.Resources.WQueenTrans, r)
                    Case "WK"
                        G.DrawImageUnscaledAndClipped(My.Resources.WKingTrans, r)
                    Case "WB"
                        G.DrawImageUnscaledAndClipped(My.Resources.WBishopTrans, r)
                    Case "WN"
                        G.DrawImageUnscaledAndClipped(My.Resources.WKnightTrans, r)
                    Case "WR"
                        G.DrawImageUnscaledAndClipped(My.Resources.WRookTrans, r)
                    Case "WP"
                        G.DrawImageUnscaledAndClipped(My.Resources.WPawnTrans, r)

                End Select
            Next
        Next

        If Trigger = True Then
            'G.FillRectangle(brushes.LawnGreen, XcorClick * Tilesize, YCorClick * Tilesize, Tilesize, Tilesize)
        End If
        G.DrawRectangle(Pens.Red, XCor * Tilesize, YCor * Tilesize, Tilesize, Tilesize)

        G.DrawString("Ticks: " & tTicks & vbCrLf & _
                     "TPS: " & MaxTicks, Me.Font, Brushes.Black, 650, 0)
        Me.ResumeLayout()
        G = Graphics.FromImage(BB)

        BBG = Me.CreateGraphics
        BBG.DrawImage(BB, 0, 0, WidthMap, HeightMap)

        G.Clear(Color.Wheat)
    End Sub

    Private Sub TickCounter()
        If tSec = TimeOfDay.Second And IsRunning = True Then
            tTicks = tTicks + 1
        Else
            MaxTicks = tTicks
            tTicks = 0
            tSec = TimeOfDay.Second
        End If
    End Sub

    Private Sub Form1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Static Clicked As Boolean = True

        Static StartX As Integer
        Static StartY As Integer

        XcorClick = Math.Floor(e.X / Tilesize)
        YCorClick = Math.Floor(e.Y / Tilesize)

        If Clicked = True Then
            CurrentPeice = PeiceMap(XcorClick, YCorClick)
            PeiceMap(XcorClick, YCorClick) = Nothing
            If CurrentPeice.Contains("P") Then
                If CurrentPeice.Contains("B") Then
                    CurrentPeiceColor = "B"
                End If
                If CurrentPeice.Contains("W") Then
                    CurrentPeiceColor = "W"
                End If
            End If
            StartX = XcorClick
            StartY = YCorClick
            Clicked = False
        ElseIf Clicked = False Then
            If AlgoPawn(StartX, StartY, XcorClick, YCorClick) = True Then
                PeiceMap(XcorClick, YCorClick) = CurrentPeice
                Clicked = True
                StartX = Nothing
                StartY = Nothing
            Else
                Clicked = False
            End If

        End If



        Trigger = True
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        XCor = Math.Floor(e.X / Tilesize)
        YCor = Math.Floor(e.Y / Tilesize)
        'Me.Text = Me.Size.ToString
    End Sub

    Function AlgoPawn(ByRef StartingX As Integer, ByRef StartingY As Integer, ByRef Clickedx As Integer, ByRef Clickedy As Integer) As Boolean
        Dim NP1 As Integer
        Dim NP2 As Integer
        Dim Passed As Boolean

        If CurrentPeiceColor = "B" Then
            NP1 = StartingY + 1
            NP2 = StartingY + 2
            If Clickedy = NP1 Or Clickedy = NP2 And Clickedx = StartingX Then
                Passed = True
            Else
                Passed = False
            End If
        ElseIf CurrentPeiceColor = "W" Then
            NP1 = StartingY - 1
            NP2 = StartingY - 2
            If Clickedy = NP1 Or Clickedy = NP2 And Clickedx = StartingX Then
                Passed = True
            Else
                Passed = False
            End If
        End If


        Return Passed
    End Function

    Function AlgoBishop(ByRef StartingX As Integer, ByRef StartingY As Integer, ByRef Clickedx As Integer, ByRef Clickedy As Integer) As Boolean
        Dim Passed As Boolean

        Dim Positions(13, 13) As Integer

        Static XCorClickBishop, YCorClickBishop


        If CurrentPeiceColor = "B" Then
            Dim in1 As Integer = 1
            For i As Integer = 1 To 13
                For i2 As Integer = 1 To 13
                    If in1 = 1 Then

                        XCorClickBishop = XCor + 1
                        YCorClickBishop = YCor + 1
                        in1 += 1
                    Else
                        XCorClickBishop += 1
                        YCorClickBishop += 1
                    End If

                    Positions(Math.Abs(XCorClickBishop), Math.Abs(YCorClickBishop)) = 1
                Next
            Next

            For i As Integer = 1 To 13
                For i2 As Integer = 1 To 13
                    If Positions(Clickedx, Clickedy) = 1 Then
                        Passed = True
                    Else
                        Passed = False
                    End If
                Next
            Next


        ElseIf CurrentPeiceColor = "W" Then
            Dim in1 As Integer = 1
            For i As Integer = 1 To 13
                For i2 As Integer = 1 To 13
                    If in1 = 1 Then

                        XCorClickBishop = XCor + 1
                        YCorClickBishop = YCor + 1
                        in1 += 1
                    Else
                        XCorClickBishop += 1
                        YCorClickBishop += 1
                    End If

                    Positions(Math.Abs(XCorClickBishop), Math.Abs(YCorClickBishop)) = 1
                Next

            Next

            For i As Integer = 1 To 13
                For i2 As Integer = 1 To 13
                    If Positions(Clickedx, Clickedy) = 1 Then
                        Passed = True
                    Else
                        Passed = False
                    End If
                Next
            Next

        End If


       

        Return Passed
    End Function

End Class
