Public Class EntranceForm

    Private Sub MainTimer_Tick(sender As System.Object, e As System.EventArgs) Handles MainTimer.Tick
        Static int1 As Integer = 1

        If int1 = 1 Then
            MainLogo1.Text = "Chess Game 2014"
            int1 += 1
        Else
            MainLogo1.Text = "CLICK ME"
            int1 = 1
        End If

    End Sub

    Private Sub MainLogo1_Click(sender As Object, e As System.EventArgs) Handles MainLogo1.Click
        MainTimer.Stop()
        MainLogo1.Text = "Chess Game 2014"
        Form1.Show()
        Me.Hide()
    End Sub
End Class