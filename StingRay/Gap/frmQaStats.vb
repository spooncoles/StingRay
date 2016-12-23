Public Class frmQaStats
    Private Sub frmQaStats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        dtFrom.Value = CDate(Date.Today.AddDays(-7))
        dtTo.Value = Today
        refreshResults()
    End Sub

    Private Sub refreshResults()
        conn.fillDS("SELECT qaAgent, qaStatus, COUNT(lead_sale_info.leadID) AS Leads FROM lead_sale_info INNER JOIN lead_primary ON lead_primary.leadID = lead_sale_info.leadID " _
                    & "WHERE qaStatus IN ('Pending', 'Sent Back', 'In progress', 'Fixed') AND status IN ('Sale', 'Busy') GROUP BY qaAgent, qaStatus", "qaStats")
        dgStats.DataSource = conn.ds.Tables("qaStats")
        dgStats.AutoResizeColumns()

        conn.fillDS("SELECT qaAgent, CAST(CONCAT(ROUND(SUM(IF(qaStatus = 'Bypass', 1, 0))/COUNT(lead_sale_info.leadID)*100, 2), ' %') AS CHAR) AS Bypassed, CAST(CONCAT(ROUND(SUM(IF(qaStatus = 'Pass', 1, 0))/COUNT(lead_sale_info.leadID)*100, 2), ' %') AS CHAR) AS Passed, " _
                    & "SUM(IF(qaStatus = 'Bypass', 1, 0)) AS `Total Bypass`, SUM(IF(qaStatus = 'Pass', 1, 0)) AS `Total Pass`, SUM(IF(appType = 'Manual', 1, 0)) AS `Manual Apps` FROM lead_primary INNER JOIN lead_sale_info ON lead_primary.leadID = lead_sale_info.leadID " _
                    & "WHERE DATE(closedDate) BETWEEN '" & Format(dtFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value, "yyyy-MM-dd") & "' AND status = 'Sale' AND qaStatus IN ('Bypass', 'Pass') GROUP BY qaAgent", "qaAgentStats")
        dgAgentStats.DataSource = conn.ds.Tables("qaAgentStats")
        dgAgentStats.AutoResizeColumns()

        conn.fillDS("SELECT user, DATE(timeStamp) as Date, COUNT(id) AS Total, SUM(IF(eventMain = 'QA Pass', 1, 0)) AS Passes, SUM(IF(eventMain = 'QA Bypass', 1, 0)) AS Bypasses " _
                    & "FROM hist_events WHERE eventMain IN ('QA Pass', 'QA Bypass') AND DATE(timeStamp) BETWEEN '" & Format(dtFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value, "yyyy-MM-dd") & "' GROUP BY user, DATE(timeStamp) ORDER BY DATE(timeStamp)", "qaAgentDaily")
        dgPerDay.DataSource = conn.ds.Tables("qaAgentDaily")
        dgPerDay.AutoResizeColumns()

        conn.fillDS("SELECT agent, CAST(CONCAT(ROUND(SUM(IF(qaStatus = 'Bypass', 1, 0))/COUNT(lead_sale_info.leadID)*100, 2), ' %') AS CHAR) AS Bypassed, CAST(CONCAT(ROUND(SUM(IF(qaStatus = 'Pass', 1, 0))/COUNT(lead_sale_info.leadID)*100, 2), ' %') AS CHAR) AS Passed, " _
                    & "SUM(IF(qaStatus = 'Bypass', 1, 0)) AS `Total Bypass`, SUM(IF(qaStatus = 'Pass', 1, 0)) AS `Total Pass`, SUM(IF(appType = 'Manual', 1, 0)) AS `Manual Apps` FROM lead_primary INNER JOIN lead_sale_info ON lead_primary.leadID = lead_sale_info.leadID " _
                    & "WHERE DATE(closedDate) BETWEEN '" & Format(dtFrom.Value, "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value, "yyyy-MM-dd") & "' AND status = 'Sale' AND qaStatus IN ('Bypass', 'Pass') GROUP BY agent", "salesAgentStats")
        dgSalesAgents.DataSource = conn.ds.Tables("salesAgentStats")
        dgSalesAgents.AutoResizeColumns()

    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        refreshResults()
    End Sub
End Class