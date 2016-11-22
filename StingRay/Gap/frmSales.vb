Public Class frmSales
    Dim onLoadEvent As Boolean = False

    Private Sub frmSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        dtFrom.Value = DateSerial(Today.Year, Today.Month, 1)
        dtTo.Value = Today

        If Not teamLeader Then
            TabControl1.TabPages.RemoveAt(3)
        Else
            cbAgents.Items.Add("All")
            For Each agent In dictAgents.Keys
                cbAgents.Items.Add(agent.ToString)
            Next
            cbAgents.SelectedIndex = 0
        End If

        refreshCharts()



        onLoadEvent = True

        'Targets
        With chAgentTargets
            conn.fillDS("SELECT COUNT(leadID) AS Sales, targetSalesPW AS Target FROM lead_primary INNER JOIN sys_agent_info ON lead_primary.agent = sys_agent_info.userName" _
                    & " WHERE status = 'Sale' AND DATE(closedDate) BETWEEN DATE_SUB(DATE_SUB(CURDATE(), INTERVAL WEEKDAY(CURDATE()) DAY), INTERVAL 1 WEEK) AND DATE_SUB(DATE(NOW()), INTERVAL DAYOFWEEK(NOW())-1 DAY) AND agent = '" & frmSide.lbUser.Text & "'", "agentTargetSales")
            .Series("Sales").Points.Clear()
            .Series("Target").Points.Clear()
            .DataSource = conn.ds.Tables("agentTargetSales")
            .Series("Sales").XValueMember = 0
            .Series("Sales").YValueMembers = "Sales"
            .Series("Target").XValueMember = 0
            .Series("Target").YValueMembers = "Target"
        End With

    End Sub

    Private Sub refreshCharts()
        'Agent Sales
        With chAgentSales
            conn.fillDS("SELECT DATE(closedDate) AS Date, SUM(IF(status = 'Sale', 1, 0)) AS Sales, SUM(IF(status = 'Sale', 1, 0))/SUM(IF(status <> 'Busy', 1, 0)) AS Conversion FROM lead_primary" _
                    & " WHERE DATE(closedDate) BETWEEN '" & Format(dtFrom.Value(), "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value(), "yyyy-MM-dd") & "' AND agent = '" & frmSide.lbUser.Text & "' GROUP BY DATE(closedDate)", "agentMonthSales")
            .Series("Sales").Points.Clear()
            .Series("Conversion").Points.Clear()
            .DataSource = conn.ds.Tables("agentMonthSales")
            .Series("Sales").XValueMember = "Date"
            .Series("Sales").YValueMembers = "Sales"
            .Series("Conversion").XValueMember = "Date"
            .Series("Conversion").YValueMembers = "Conversion"
        End With

        'Team Sales
        With chTeamSales

            conn.fillDS("SELECT DATE(closedDate) AS Date, SUM(IF(status = 'Sale', 1, 0)) AS Sales, SUM(IF(status = 'Sale', 1, 0))/SUM(IF(status <> 'Busy', 1, 0)) AS Conversion FROM lead_primary" _
                    & " WHERE DATE(closedDate) BETWEEN '" & Format(dtFrom.Value(), "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value(), "yyyy-MM-dd") & "' GROUP BY DATE(closedDate)", "teamMonthSales")
            .Series("Sales").Points.Clear()
            .Series("Conversion").Points.Clear()
            .DataSource = conn.ds.Tables("teamMonthSales")
            .Series("Sales").XValueMember = "Date"
            .Series("Sales").YValueMembers = "Sales"
            .Series("Conversion").XValueMember = "Date"
            .Series("Conversion").YValueMembers = "Conversion"
        End With

        'Sales Grid
        TabControl1.SelectTab(2)
        conn.fillDS("SELECT lead_primary.leadID, loadedDate, closedDate, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name, affinityName, qaStatus, ballValue, IF(productYear = '2017', IF(DATEDIFF(closedDate, loadedDate) > 180, ROUND((cost * (commPerc2017 + 0.1)), 2), ROUND((cost * commPerc2017), 2)), IF(DATEDIFF(closedDate, loadedDate) > 180, ROUND((cost * (commPerc + 0.1)), 2), ROUND((cost * commPerc), 2))) AS Comm, productTaken " _
                    & "FROM zestlife.lead_primary INNER JOIN lead_sale_info ON lead_primary.leadID = lead_sale_info.leadID " _
                    & "INNER JOIN affinities ON lead_primary.affinityCode = affinities.adminCode " _
                    & "INNER JOIN sys_comm ON sys_comm.name = IF(sys_comm.type = 1, affinities.type, affinities.groupName) " _
                    & "INNER JOIN sys_products ON sys_products.productID = productTaken " _
                    & "WHERE status = 'Sale' AND DATE(closedDate) BETWEEN '" & Format(dtFrom.Value(), "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value(), "yyyy-MM-dd") & "' AND agent = '" & frmSide.lbUser.Text & "' ORDER BY closedDate", "gridSales")
        dgSales.DataSource = conn.ds.Tables("gridSales")
        dgSales.AutoResizeColumns()
        dgSales.Refresh()


        Dim commCalc As Double = 0.0
        For Each row As DataGridViewRow In dgSales.Rows
            commCalc += CDbl(row.Cells("Comm").Value)
        Next row
        If commCalc <> 0.0 Then
            lbComm.Text = "Total comm for selected period = R " & Format(commCalc, "##,###.00")
        Else
            lbComm.Text = "No comm for selected period."
        End If

        lbSales.Text = "Total Sales for selected period = " & dgSales.Rows.Count


        'Team Sales Grid
        If teamLeader Then
            If cbAgents.Text = "All" Then
                conn.fillDS("SELECT lead_primary.leadID, agent, loadedDate, closedDate, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name, qaStatus, ballValue " _
                        & "FROM zestlife.lead_primary INNER JOIN lead_sale_info ON lead_primary.leadID = lead_sale_info.leadID" _
                        & " WHERE status = 'Sale' AND DATE(closedDate) BETWEEN '" & Format(dtFrom.Value(), "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value(), "yyyy-MM-dd") & "'", "gridTeamSales")
            Else
                conn.fillDS("SELECT lead_primary.leadID, agent, loadedDate, closedDate, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name, qaStatus, ballValue " _
                        & "FROM zestlife.lead_primary INNER JOIN lead_sale_info ON lead_primary.leadID = lead_sale_info.leadID" _
                        & " WHERE status = 'Sale' AND DATE(closedDate) BETWEEN '" & Format(dtFrom.Value(), "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value(), "yyyy-MM-dd") & "' " _
                        & "AND agent = '" & cbAgents.Text & "'  ORDER BY closedDate", "gridTeamSales")
            End If
            dgTeamSales.DataSource = conn.ds.Tables("gridTeamSales")
            dgTeamSales.Refresh()
            lbTotalSales.Text = "Total Sales for selected period = " & dgTeamSales.Rows.Count
        End If
        dgSales.AutoResizeColumns()

        'Outbound Stats
        conn.fillDS("SELECT lead_primary.agent, leadsRecieved, SUM(IF(status = 'Sale', 1, 0)) AS Sales, (SUM(IF(status = 'Sale', 1, 0))/leadsRecieved)*100 as convRate, IF(loadedToday IS NULL, 0, loadedToday) AS loadedToday, 0 AS avaliableToday, DATE_SUB(curdate(), INTERVAL 2 WEEK) AS dateFrom, DATE_SUB(curdate(), INTERVAL 1 DAY) AS dateTo FROM lead_primary " _
                    & "INNER JOIN affinities on affinityCode = adminCode LEFT JOIN (SELECT agent, COUNT(leadID) as loadedToday FROM lead_primary INNER JOIN affinities on affinityCode = adminCode " _
                    & "WHERE type = 'Outbound' AND DATE(loadedDate) = DATE(CURDATE()) AND lead_primary.agent = '" & frmSide.lbUser.Text & "') as a ON lead_primary.agent = a.agent " _
                    & "LEFT JOIN (SELECT agent, COUNT(leadID) as leadsRecieved FROM lead_primary INNER JOIN affinities on affinityCode = adminCode WHERE type = 'Outbound' AND DATE(loadedDate) BETWEEN DATE_SUB(curdate(), INTERVAL 2 WEEK) AND DATE_SUB(curdate(), INTERVAL 1 DAY) AND agent = '" & frmSide.lbUser.Text & "') as c ON lead_primary.agent = c.agent " _
                    & "WHERE type = 'Outbound' AND DATE(closedDate) BETWEEN DATE_SUB(curdate(), INTERVAL 2 WEEK) AND DATE_SUB(curdate(), INTERVAL 1 DAY) AND lead_primary.agent = '" & frmSide.lbUser.Text & "'", "outboundStats")
        dgAgentOutboundStats.DataSource = conn.ds.Tables("outboundStats")
        With conn.ds.Tables("outboundStats").Rows(0)
            If .Item("convRate") < 8 Then
                .Item("avaliableToday") = 15
            ElseIf .Item("convRate") >= 8 And .Item("convRate") < 10 Then
                .Item("avaliableToday") = 20
            ElseIf .Item("convRate") >= 10 Then
                .Item("avaliableToday") = 35
            End If
        End With

        'Top 5 Outbound
        conn.fillDS("SELECT affinityName FROM lead_primary INNER JOIN affinities ON adminCode = affinityCode " _
                    & "WHERE type = 'Outbound' AND MONTH(loadedDate) = MONTH(CURDATE()) AND YEAR(loadedDate) = YEAR(CURDATE()) " _
                    & "GROUP BY affinityName ORDER BY COUNT(leadID) DESC LIMIT 5", "outboundTop5")
        dgTop5Outbound.DataSource = conn.ds.Tables("outboundTop5")

    End Sub

    Private Sub btRefresh_Click(sender As Object, e As EventArgs) Handles btRefresh.Click
        refreshCharts()

    End Sub

    Private Sub dtFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtFrom.ValueChanged
        If onLoadEvent Then
            'refreshCharts()
            btThisMonth.FlatStyle = FlatStyle.Standard
            btThisWeek.FlatStyle = FlatStyle.Standard
        End If
        
    End Sub

    Private Sub dtTo_ValueChanged(sender As Object, e As EventArgs) Handles dtTo.ValueChanged
        If onLoadEvent Then
            'refreshCharts()
            btThisMonth.FlatStyle = FlatStyle.Standard
            btThisWeek.FlatStyle = FlatStyle.Standard
        End If
    End Sub

    Private Sub btThisMonth_Click(sender As Object, e As EventArgs) Handles btThisMonth.Click
        dtFrom.Value = DateSerial(Today.Year, Today.Month, 1)
        dtTo.Value = Today
        btThisMonth.FlatStyle = FlatStyle.Flat
        btThisWeek.FlatStyle = FlatStyle.Standard
    End Sub

    Private Sub btThisWeek_Click(sender As Object, e As EventArgs) Handles btThisWeek.Click
        dtFrom.Value = Today.AddDays(-(Today.DayOfWeek - DayOfWeek.Monday))
        dtTo.Value = Today
        btThisMonth.FlatStyle = FlatStyle.Standard
        btThisWeek.FlatStyle = FlatStyle.Flat
    End Sub

    Private Sub cbAgents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAgents.SelectedIndexChanged
        If onLoadEvent Then
            'Team Sales Grid
            If teamLeader Then
                If cbAgents.Text = "All" Then
                    conn.fillDS("SELECT lead_primary.leadID, agent, loadedDate, closedDate, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name, qaStatus, ballValue " _
                        & "FROM zestlife.lead_primary INNER JOIN lead_sale_info ON lead_primary.leadID = lead_sale_info.leadID" _
                        & " WHERE status = 'Sale' AND DATE(closedDate) BETWEEN '" & Format(dtFrom.Value(), "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value(), "yyyy-MM-dd") & "'", "gridTeamSales")
                Else
                    conn.fillDS("SELECT lead_primary.leadID, agent, loadedDate, closedDate, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name, qaStatus, ballValue " _
                        & "FROM zestlife.lead_primary INNER JOIN lead_sale_info ON lead_primary.leadID = lead_sale_info.leadID" _
                        & " WHERE status = 'Sale' AND DATE(closedDate) BETWEEN '" & Format(dtFrom.Value(), "yyyy-MM-dd") & "' AND '" & Format(dtTo.Value(), "yyyy-MM-dd") & "' " _
                        & "AND agent = '" & cbAgents.Text & "'  ORDER BY closedDate", "gridTeamSales")
                End If
                dgTeamSales.DataSource = conn.ds.Tables("gridTeamSales")
                dgTeamSales.Refresh()
                lbTotalSales.Text = "Total Sales for selected period = " & dgTeamSales.Rows.Count
            End If
            dgSales.AutoResizeColumns()
        End If

    End Sub

    Private Sub tbEndNov_Enter(sender As Object, e As EventArgs) Handles tbEndNov.Enter
        conn.fillDS("SELECT COUNT(lead_primary.leadID) as Sales, SUM(IF(productYear = '2017', IF(DATEDIFF(closedDate, loadedDate) > 180, ROUND((cost * ((1-commPerc2017) + 0.1)), 2), ROUND((cost * (1-commPerc2017)), 2)), IF(DATEDIFF(closedDate, loadedDate) > 180, ROUND((cost * ((1-commPerc) + 0.1)), 2), ROUND((cost * (1-commPerc)), 2)))) AS Comm " _
                    & "FROM zestlife.lead_primary INNER JOIN lead_sale_info ON lead_primary.leadID = lead_sale_info.leadID " _
                    & "INNER JOIN affinities ON lead_primary.affinityCode = affinities.adminCode " _
                    & "INNER JOIN sys_comm ON sys_comm.name = IF(sys_comm.type = 1, affinities.type, affinities.groupName) " _
                    & "INNER JOIN sys_products ON sys_products.productID = productTaken " _
                    & "WHERE status = 'Sale' AND DATE(closedDate) BETWEEN '2016-11-21' AND '2016-11-30' AND agent = '" & frmSide.lbUser.Text & "' ORDER BY closedDate", "endNov")

        lbEndNovSales.Text = "Sales: " & conn.ds.Tables("endNov").Rows(0).Item("Sales")
        lbDecExtra.Text = "Dec extra earnings: " & conn.ds.Tables("endNov").Rows(0).Item("Comm")
    End Sub

End Class