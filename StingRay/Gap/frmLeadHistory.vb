Public Class frmLeadHistory
    Private Sub frmLeadHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain

    End Sub

    Public Sub loadLeadHist(leadID As Integer)
        If cbEvents.Checked Or cbChanges.Checked Or cbComments.Checked Or cbCalls.Checked Then
            Dim sqlQuery As String = "SELECT timeStamp, user, eventmain, CAST(eventSub AS CHAR(100)) AS eventSub, CAST(changeFrom AS CHAR(100)) AS changeFrom, CAST(changeTo AS CHAR(100)) AS changeTo, CAST(comment AS CHAR(100)) AS comment FROM ("

            If cbEvents.Checked Then sqlQuery = sqlQuery & "SELECT timeStamp, user, eventMain, eventSub, NULL AS changeFrom, NULL AS changeTo, NULL comment FROM hist_events WHERE leadID = " & leadID & " UNION "

            If cbChanges.Checked Then sqlQuery = sqlQuery & "SELECT timestamp, user, 'Change' As eventMain, field As eventSub, changeFrom, changeTo, comment FROM hist_changes WHERE leadID = " & leadID & " UNION "

            If cbComments.Checked Then sqlQuery = sqlQuery & "SELECT timeStamp, user, 'Comment' AS eventMain, NULL AS eventSub, NULL AS changeFrom, NULL AS changeTo, comment FROM lead_comments WHERE leadID = " & leadID & " UNION "

            If cbCalls.Checked Then sqlQuery = sqlQuery & "SELECT timeStamp, userName as user, IF(answered = 1, 'Answered Call', 'Missed Call') As eventMain, dialledNum AS eventSub, wait AS changeFrom, duration AS changeTo, NULL AS comment FROM queuemetrics " _
                & "LEFT JOIN lead_primary ON RIGHT(dialledNum, 9) = RIGHT(contactNumber, 9) LEFT JOIN sys_users ON RIGHT(sys_users.workNumber, 7) = agentCode WHERE leadID = " & leadID & " UNION "

            sqlQuery = sqlQuery.Substring(0, sqlQuery.Length() - 7) & ") as a ORDER BY timeStamp DESC"
            conn.fillDS(sqlQuery, "history")
            dgHistory.DataSource = conn.ds.Tables("history")
        Else
            conn.ds.Tables("history").Clear()
            dgHistory.DataSource = conn.ds.Tables("history")
        End If
        Me.Show()
    End Sub
End Class