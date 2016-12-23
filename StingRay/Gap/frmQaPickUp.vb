Public Class frmQaPickUp
    'Dim conn As New clConn("local")

    Private Sub frmQaPickUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        refreshLeads()
        txLeadID.Focus()

        cbAgent.DisplayMember = "Key"
        cbAgent.ValueMember = "Value"
        cbAgent.DataSource = New BindingSource(modExtra.dictAgents, Nothing)
        cbAgent.SelectedIndex = -1

        cbAffinity.DisplayMember = "Key"
        cbAffinity.ValueMember = "Value"
        cbAffinity.DataSource = New BindingSource(modExtra.dictAffinities, Nothing)
        cbAffinity.SelectedIndex = -1

    End Sub

    Private Sub btSearch_Click(sender As Object, e As EventArgs) Handles btSearch.Click
        refreshLeads()
    End Sub

    Public Sub refreshLeads()
        If cbOrder.Text = "" Then cbOrder.Text = "closedDate"
        If cbOrderDirection.Text = "" Then cbOrderDirection.Text = "ASC"

        Dim sqlString As String
        Dim selectString As String = "SELECT lead_primary.leadID, closedDate, CONCAT(firstName, ' ', lastName) AS Name, agent, status, qaAgent, affinityName, qaStatus, qaManditory, qaManditoryReason, contactNumber, idNumber, appType FROM lead_primary" _
                                         & " INNER JOIN lead_sale_info ON lead_sale_info.leadID = lead_primary.leadID INNER JOIN affinities ON affinities.adminCode = lead_primary.affinityCode"
        Dim whereString As String = " WHERE (qaAgent = '" & frmSide.lbUser.Text & "' OR qaAgent IS NULL) AND lead_primary.campaign = '" & campaign & "' AND status IN ('Sale', 'Busy')"
        Dim orderString As String = " ORDER BY " & cbOrder.Text & " " & UCase(cbOrderDirection.Text)

        'Field Searches
        Dim searchFields As New List(Of WaterMarkTextBox) From {txLeadID, txFirstName, txLastName, txContactNum, txIDNum}
        For Each field In searchFields
            If field.Text <> "" Then whereString = whereString & " AND " & field.Tag & " LIKE '" & Replace(field.Text, "'", "''") & "%'"
        Next field

        Dim statusesCheck As String = ""
        For Each cb As CheckBox In gbStatuses.Controls
            If cb.Checked Then
                If statusesCheck = "" Then
                    statusesCheck += "'" & cb.Text & "'"
                Else
                    statusesCheck += ", '" & cb.Text & "'"
                End If
            End If
        Next
        If statusesCheck <> "" Then
            whereString += " AND qaStatus IN (" & statusesCheck & ")"
        Else
            MsgBox("Please select a status!")
            Exit Sub
        End If


        'Show only Manditory
        If cbManditory.Checked Then whereString = whereString & " AND qaManditory = 1"

        'Agent Check
        If cbAgent.Text <> "" Then
            whereString = whereString & " AND agent LIKE '" & cbAgent.Text & "%'"
        End If

        'Affinity Check
        If cbAffinity.Text <> "" Then
            whereString = whereString & " AND affinityName LIKE '" & cbAffinity.Text & "%'"
        End If

        'Dates Check
        If cbDates.CheckState Then
            whereString = whereString & " AND DATE(closedDate) BETWEEN '" & Format(CDate(dtFrom.Value), "yyyy-MM-dd") & "' AND '" & Format(CDate(dtTo.Value), "yyyy-MM-dd") & "'"
        End If


        sqlString = selectString & whereString & orderString

        conn.fillDS(sqlString, "leadPicks")

        If conn.ds.Tables("leadPicks").Rows.Count = 0 Then
            notify("No leads found for search criteria.")
        Else
            dgPickUp.DataSource = conn.ds.Tables("leadPicks")
            dgPickUp.AutoResizeColumns()
            dgPickUp.AutoResizeRows()
            dgPickUp.Refresh()
            dgPickUp.Focus()
        End If

    End Sub

    Public Sub clearAll()
        Dim searchFields As New List(Of WaterMarkTextBox) From {txLeadID, txFirstName, txLastName, txContactNum, txIDNum}
        For Each field In searchFields
            field.Text = ""
        Next field

        cbManditory.CheckState = False
        cbPending.CheckState = False
        cbFail.CheckState = False
        cbDates.CheckState = False


        cbOrder.Text = "loadedDate"
        cbOrder.Text = "Asc"

    End Sub

#Region "TextBoxes"

    Private Sub txLeadID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txLeadID.KeyPress
        If Asc(e.KeyChar) = 13 Then refreshLeads()
    End Sub

    Private Sub txFirstName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txFirstName.KeyPress
        If Asc(e.KeyChar) = 13 Then refreshLeads()
    End Sub

    Private Sub txLastName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txLastName.KeyPress
        If Asc(e.KeyChar) = 13 Then refreshLeads()
    End Sub

    Private Sub txContactNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txContactNum.KeyPress
        If Asc(e.KeyChar) = 13 Then
            refreshLeads()
        Else
            numKeyPress(e, sender)
        End If
        If txContactNum.Text <> "" Then
            If txContactNum.Text.Substring(0, 1) = "0" Then txContactNum.Text = txContactNum.Text.Substring(1)
        End If
    End Sub

    Private Sub txIDNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txIDNum.KeyPress
        If Asc(e.KeyChar) = 13 Then
            refreshLeads()
        Else
            numKeyPress(e, sender)
        End If
    End Sub

#End Region

    Public Sub numKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal txBox As Object)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then e.Handled = True
        End If
    End Sub

    Private Sub dgPickUp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgPickUp.KeyDown
        If e.KeyCode = Keys.Enter Then
            If conn.ds.Tables("leadPicks").Rows.Count <> 0 Then
                If dgPickUp.Item("status", dgPickUp.CurrentRow.Index).Value.ToString = "Sale" Then
                    frmQaView.loadLead(dgPickUp.Item("leadID", dgPickUp.CurrentRow.Index).Value.ToString)
                Else
                    MsgBox("Lead in busy status. Please ask agent to re-submit sale.")
                End If
            End If
        End If
    End Sub

    Private Sub dgPickUp_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgPickUp.MouseDoubleClick
        If conn.ds.Tables("leadPicks").Rows.Count <> 0 Then
            If dgPickUp.Item("status", dgPickUp.CurrentRow.Index).Value.ToString = "Sale" Then
                frmQaView.loadLead(dgPickUp.Item("leadID", dgPickUp.CurrentRow.Index).Value.ToString)
            Else
                MsgBox("Lead in busy status. Please ask agent to re-submit sale.")
            End If
        End If
    End Sub

    Private Sub btAddQueue_Click(sender As Object, e As EventArgs) Handles btAddQueue.Click

        If conn.ds.Tables("leadPicks").Rows.Count <> 0 Then
            If dgPickUp.SelectedRows.Count = 1 Then
                If MsgBox("Would you like to add only the selected lead or all leads?", vbYesNo) = MsgBoxResult.Yes Then
                    For Each row In dgPickUp.SelectedRows
                        frmSide.addToQueue(row.Cells("leadID").Value(), row.Cells("Name").Value())
                    Next
                Else
                    For Each row In dgPickUp.Rows
                        frmSide.addToQueue(row.Cells("leadID").Value(), row.Cells("Name").Value())
                    Next
                End If
            Else
                For Each row In dgPickUp.SelectedRows
                    frmSide.addToQueue(row.Cells("leadID").Value(), row.Cells("Name").Value())
                Next
            End If

            If MsgBox("Lead(s) added to queue, pick-up now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                frmSide.nextInQueue(frmQaView)
                Me.Close()
            End If

        Else
            notify("No leads to add to queue.")
        End If
    End Sub

End Class