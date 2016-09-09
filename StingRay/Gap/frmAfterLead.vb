Public Class frmAfterLead
    Dim agent As String = frmSide.lbUser.Text
    Private Sub frmAfterLead_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        'Dim agent As String = frmSide.lbUser.Text


        Dim nextHour As String = conn.sendReturn("SELECT COUNT(id) FROM zestlife.lead_reschedule INNER JOIN lead_primary ON lead_primary.leadID = lead_reschedule.leadID" _
                                   & " WHERE active = 1 AND (rescheduleDateTime BETWEEN NOW() AND DATE_ADD(NOW(), INTERVAL 1 HOUR)) AND status = 'Busy' AND agent = '" & agent & "'")

        Dim overdue As String = conn.sendReturn("SELECT COUNT(id) FROM zestlife.lead_reschedule INNER JOIN lead_primary ON lead_primary.leadID = lead_reschedule.leadID" _
                                   & " WHERE active = 1 AND rescheduleDateTime <= NOW() AND status = 'Busy' AND agent = '" & agent & "'")

        If nextHour <> "NULL" And nextHour <> "0" Then
            lbRescheduleNextHour.Text = nextHour
        Else
            btNextHourQueue.Enabled = False
            btNextHourView.Enabled = False
            lbRescheduleNextHour.Text = "0"
            gbNextHour.Visible = False
        End If

        If overdue <> "NULL" And overdue <> "0" Then
            lbRescheduleOverdue.Text = overdue
        Else
            btOverdueQueue.Enabled = False
            btOverdueView.Enabled = False
            lbRescheduleOverdue.Text = "0"
            gbOverdue.Visible = False
        End If

    End Sub

    Private Sub btBreak_Click(sender As Object, e As EventArgs) Handles btBreak.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btFindLead.Click
        frmLeadPickUp.Show()
        Me.Close()
    End Sub

    Private Sub btNextInQueue_Click(sender As Object, e As EventArgs) Handles btNextInQueue.Click
        frmSide.nextInQueue(frmLeadView)
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmSales.Show()
        Me.Close()
    End Sub

    Private Sub btNextHourQueue_Click(sender As Object, e As EventArgs) Handles btNextHourQueue.Click
        conn.fillDS("SELECT lead_primary.leadID, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name FROM zestlife.lead_reschedule INNER JOIN lead_primary ON lead_primary.leadID = lead_reschedule.leadID" _
                                   & " WHERE active = 1 AND (rescheduleDateTime BETWEEN NOW() AND DATE_ADD(NOW(), INTERVAL 1 HOUR)) AND status = 'Busy' AND agent = '" & agent & "'", "nextHourQueue")
        For Each row As DataRow In conn.ds.Tables("nextHourQueue").Rows
            frmSide.addToQueue(row.Item("leadID"), row.Item("Name"))
        Next

        If MsgBox("Leads added to queue, pick now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            frmSide.nextInQueue(frmLeadView)
            Me.Close()
        End If
    End Sub

    Private Sub btOverdueQueue_Click(sender As Object, e As EventArgs) Handles btOverdueQueue.Click
        conn.fillDS("SELECT lead_primary.leadID, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name FROM zestlife.lead_reschedule INNER JOIN lead_primary ON lead_primary.leadID = lead_reschedule.leadID" _
                           & " WHERE active = 1 AND rescheduleDateTime <= NOW() AND status = 'Busy' AND agent = '" & agent & "'", "overdueQueue")
        For Each row As DataRow In conn.ds.Tables("overdueQueue").Rows
            frmSide.addToQueue(row.Item("leadID"), row.Item("Name"))
        Next

        If MsgBox("Leads added to queue, pick now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            frmSide.nextInQueue(frmLeadView)
            Me.Close()
        End If
    End Sub

    Private Sub btNextHourView_Click(sender As Object, e As EventArgs) Handles btNextHourView.Click
        MsgBox("Functionality still being built")
    End Sub

    Private Sub btOverdueView_Click(sender As Object, e As EventArgs) Handles btOverdueView.Click
        MsgBox("Functionality still being built")
    End Sub
End Class