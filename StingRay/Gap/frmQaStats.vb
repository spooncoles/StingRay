Public Class frmQaStats
    Private Sub frmQaStats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        dtFrom.Value = CDate(Date.Today.AddDays(-7))
        dtTo.Value = Today
        refreshResults()
    End Sub

    Private Sub refreshResults()
        conn.fillDS("SELECT qaAgent, qaStatus, COUNT(lead_sale_info.leadID) AS leads FROM lead_primary INNER JOIN lead_sale_info ON lead_primary.leadID = lead_sale_info.leadID " _
                    & "WHERE DATE(closedDate) BETWEEN '" & Format(dtFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value, "yyyy-MM-dd") & "' AND status = 'Sale' GROUP BY qaAgent, qaStatus", "qaStats")
        dgStats.DataSource = conn.ds.Tables("qaStats")
        dgStats.AutoResizeColumns()

        conn.fillDS("SELECT qaAgent, SUM(IF(qaStatus = 'Bypass', 1, 0))/COUNT(lead_sale_info.leadID)*100 AS Bypassed, SUM(IF(qaStatus = 'Pass', 1, 0))/COUNT(lead_sale_info.leadID)*100 AS Passed FROM lead_primary INNER JOIN lead_sale_info ON lead_primary.leadID = lead_sale_info.leadID " _
                    & "WHERE DATE(closedDate) BETWEEN '" & Format(dtFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value, "yyyy-MM-dd") & "' AND status = 'Sale' AND qaStatus IN ('Bypass', 'Pass') GROUP BY qaAgent", "qaAgentStats")
        dgAgentStats.DataSource = conn.ds.Tables("qaAgentStats")
        dgAgentStats.AutoResizeColumns()

    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        refreshResults()
    End Sub
End Class