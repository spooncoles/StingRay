Public Class frmLeadPickUp
    'Dim conn As New clConn("local")
    Public rescheduleLeads As Boolean = False
    Public qaFails As Boolean = False
    Public transfers As Boolean = False
    Dim recycled As Boolean = False
    Dim uncontactable As Boolean = False

    Private Sub frmLeadPickUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.MdiParent = frmMain
        dtFrom.Value = CDate(Date.Today.AddDays(-7))
        dtTo.Value = Today

        txLeadID.Focus()

        cbAffinity.DisplayMember = "Key"
        cbAffinity.ValueMember = "Value"
        cbAffinity.DataSource = New BindingSource(dictAffinities, Nothing)
        cbAffinity.SelectedIndex = -1

        If recycleAvaliable Then
            pbRecycled.Visible = True
        End If

        refreshLeads()
        txLeadID.Focus()
    End Sub

    Private Sub btSearch_Click(sender As Object, e As EventArgs) Handles btSearch.Click
        rescheduleLeads = False
        qaFails = False
        recycled = False
        uncontactable = False
        refreshLeads()
    End Sub

    Public Sub refreshLeads()
        If cbOrder.Text = "" Then cbOrder.Text = "loadedDate"
        If cbOrderDirection.Text = "" Then cbOrderDirection.Text = "DESC"
        Dim sqlString As String = ""

        If rescheduleLeads Then
            sqlString = "SELECT lead_primary.leadID, Date(loadedDate) As Loaded, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name, rescheduleDateTime, comment, affinityName" _
                & " FROM zestlife.lead_reschedule INNER JOIN lead_primary ON lead_primary.leadID = lead_reschedule.leadID" _
                & " LEFT JOIN affinities ON adminCode = affinityCode" _
                & " WHERE active = 1 AND DATE(rescheduleDateTime) <= DATE(NOW()) AND status = 'Busy' AND agent = '" & frmSide.lbUser.Text & "' ORDER BY rescheduleDateTime DESC"
        ElseIf qaFails Then
            sqlString = "SELECT lead_sale_info.leadID, DATE(loadedDate) as Loaded, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name, qaStatus, qaAgent, qaOverallComment" _
                & " FROM lead_sale_info INNER JOIN lead_primary ON lead_primary.leadID = lead_sale_info.leadID WHERE qaStatus = 'Sent Back' AND agent = '" & frmSide.lbUser.Text & "'"

        ElseIf transfers Then
            sqlString = "SELECT leadID, DATE(loadedDate) as Loaded, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name, status, outcome " _
                & " FROM lead_primary WHERE status = 'Busy' AND outcome = 'Transfered' AND agent = '" & frmSide.lbUser.Text & "'"
        ElseIf recycled Then
            sqlString = "SELECT lead_primary.leadID, Date(loadedDate) As Loaded, agent, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name, affinityName" _
                & " FROM lead_primary LEFT JOIN affinities ON adminCode = affinityCode" _
                & " WHERE status = 'Recycle' AND affinityName <> 'Lead Source' AND loadedDate > 0 ORDER BY loadedDate DESC"
        Else

            Dim selectString As String = "SELECT leadID, Date(loadedDate) As Loaded, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name, status, outcome, affinityName FROM lead_primary" _
                                         & " LEFT JOIN affinities ON adminCode = affinityCode"
            Dim whereString As String = " WHERE agent = '" & frmSide.lbUser.Text & "'"
            Dim orderString As String = " ORDER BY " & cbOrder.Text & " " & UCase(cbOrderDirection.Text)

            'Field Searches
            Dim searchFields As New List(Of WaterMarkTextBox) From {txLeadID, txFirstName, txLastName, txContactNum, txEmailAdd, txIDNum}
            For Each field In searchFields
                If field.Text <> "" Then
                    If field.Name = "txContactNum" Then
                        If txContactNum.Text.Substring(0, 1) = "0" Then
                            whereString = whereString & " AND contactNumber LIKE '%" & Replace(field.Text.Substring(1, field.Text.Length - 1), "'", "''") & "%'"
                        Else
                            whereString = whereString & " AND contactNumber LIKE '%" & Replace(field.Text, "'", "''") & "%'"
                        End If
                    Else
                        whereString = whereString & " AND " & field.Tag & " LIKE '" & Replace(field.Text, "'", "''") & "%'"
                    End If

                End If
            Next field

            'Status Searches
            Select Case CStr(cbAvaliable.CheckState & cbBusy.CheckState & cbStatusOther.CheckState)
                Case "110"
                    whereString = whereString & " AND status IN ('Allocated', 'Busy')"
                Case "100"
                    whereString = whereString & " AND status ='Allocated'"
                Case "010"
                    whereString = whereString & " AND status = 'Busy'"
                Case "001"
                    whereString = whereString & " AND status NOT IN ('Allocated', 'Busy')"
            End Select

            'Affinity Check
            If cbAffinity.Text = "Referal" Then
                whereString = whereString & " AND affinityCode = 0"
            ElseIf cbAffinity.Text <> "Affinity" And cbAffinity.Text <> "" Then
                whereString = whereString & " AND affinityName LIKE '" & cbAffinity.Text & "%'"
            End If

            'Date Check
            If cbDates.CheckState Then
                whereString = whereString & " AND loadedDate BETWEEN '" & Format(CDate(dtFrom.Value), "yyyy-MM-dd") & "' AND '" & Format(CDate(dtTo.Value), "yyyy-MM-dd") & "'"
            End If

            sqlString = selectString & whereString & orderString
        End If

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

        cbBusy.CheckState = False
        cbStatusOther.CheckState = False
        cbAvaliable.CheckState = False
        qaFails = False
        rescheduleLeads = False
        transfers = False
        cbDates.CheckState = False
        cbOtherSearch.Text = ""
        txOtherValue.Text = ""
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
        'If txContactNum.Text <> "" Then
        '    If txContactNum.Text.Substring(0, 1) = "0" Then txContactNum.Text = txContactNum.Text.Substring(1)
        'End If
    End Sub

    Private Sub txIDNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txIDNum.KeyPress
        If Asc(e.KeyChar) = 13 Then
            refreshLeads()
        Else
            numKeyPress(e, sender)
        End If
    End Sub

#End Region

#Region "CheckBoxes"
    Private Sub cbStatusOther_CheckedChanged(sender As Object, e As EventArgs) Handles cbStatusOther.CheckedChanged
        If cbStatusOther.Checked Then
            cbAvaliable.Checked = False
            cbBusy.Checked = False
        End If
    End Sub

    Private Sub cbAvaliable_CheckedChanged(sender As Object, e As EventArgs) Handles cbAvaliable.CheckedChanged
        If cbAvaliable.Checked Then cbStatusOther.Checked = False
    End Sub

    Private Sub cbBusy_CheckedChanged(sender As Object, e As EventArgs) Handles cbBusy.CheckedChanged
        If cbBusy.Checked Then cbStatusOther.Checked = False
    End Sub
#End Region

    Public Sub numKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal txBox As Object)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then e.Handled = True
        End If
    End Sub

    Private Sub dgPickUp_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgPickUp.CellDoubleClick
        If conn.ds.Tables("leadPicks").Rows.Count <> 0 Then
            frmLeadView.loadLead(dgPickUp.Item("leadID", dgPickUp.CurrentRow.Index).Value.ToString())
            Me.Close()
        End If
    End Sub

    Private Sub dgPickUp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgPickUp.KeyDown
        If e.KeyCode = Keys.Enter Then
            If conn.ds.Tables("leadPicks").Rows.Count <> 0 Then
                frmLeadView.loadLead(dgPickUp.Item("leadID", dgPickUp.CurrentRow.Index).Value.ToString())
                Me.Close()
            End If
        End If
    End Sub

    Private Sub cbAffinity_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cbAffinity.Text = "Affinity" Then
            cbAffinity.ForeColor = Color.Gray
        Else
            cbAffinity.ForeColor = Color.Black
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
                frmSide.nextInQueue(frmLeadView)
                Me.Close()
            End If

        Else
            notify("No leads to add to queue.")
        End If
    End Sub

    Private Sub cbAffinity_SelectionChangeCommitted(sender As Object, e As EventArgs)
        If cbAffinity.Text = "Affinity" Then
            cbAffinity.ForeColor = Color.Gray
        Else
            cbAffinity.ForeColor = Color.Black
        End If
    End Sub

    Private Sub cbDates_CheckedChanged(sender As Object, e As EventArgs) Handles cbDates.CheckedChanged
        If cbDates.CheckState Then
            dtFrom.Enabled = True
            dtTo.Enabled = True
        Else
            dtFrom.Enabled = False
            dtTo.Enabled = False
        End If
    End Sub

    Private Sub btLoadReferal_Click(sender As Object, e As EventArgs) Handles btLoadReferal.Click
        If dgPickUp.SelectedRows.Count = 1 Then
            For Each row In dgPickUp.SelectedRows
                frmLoadAffinity.populateReferal(CInt(row.Cells("leadID").Value()))
            Next
        Else
            MsgBox("Please select 1 lead")
        End If
    End Sub

    Private Sub pbRecycled_Click(sender As Object, e As EventArgs) Handles pbRecycled.Click
        recycled = True
        refreshLeads()
    End Sub

End Class