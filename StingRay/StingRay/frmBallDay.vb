Public Class frmBallDay

    Private Sub frmBallDay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        Dim MyMin As Integer = 1, MyMax As Integer = 100, Seed As Integer
        Dim Generator As System.Random = New System.Random()

        Seed = Generator.Next(MyMin, MyMax + 1)
        Dim ballValue As Integer = 0
        Select Case Seed
            Case Is <= 85
                ballValue = 30
            Case Is <= 95
                ballValue = 60
            Case Else
                ballValue = 120
        End Select

        If Format(Today, "dddd") = "Saturday" Or Format(Today, "yyyy-MM-dd") = "2016-06-16" Then
            ballValue = ballValue * 2
            MsgBox("Double Ball Day!")
        End If

        lbBallValue.Text = "R " & ballValue & " Ball"
        conn.send("UPDATE lead_sale_info SET `ballValue`='" & ballValue & "' WHERE leadID='" & frmLeadView.lbLeadID.Text & "'")


    End Sub

    Private Sub frmBallDay_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        frmAfterLead.Show()
        Me.Close()
    End Sub

    Private Sub btContinue_Click(sender As Object, e As EventArgs) Handles btContinue.Click
        frmAfterLead.Show()
        Me.Close()
    End Sub
End Class