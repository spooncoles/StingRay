Public Class frmLeadTransfer
    Dim transType As String
    Private Sub frmLeadTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain

    End Sub

    Public Sub loadLead(leadID As Integer, type As String)
        transType = type
        If type = "Agent" Then
            cbAgent.DisplayMember = "Key"
            cbAgent.ValueMember = "Value"
            cbAgent.DataSource = New BindingSource(dictAgents, Nothing)
            cbAgent.SelectedIndex = -1
        ElseIf type = "QA" Then
            conn.fillDS("SELECT userName FROM sys_users WHERE campaign = 'QA' AND active = 1", "QA Agents")
            cbAgent.DisplayMember = "userName"
            cbAgent.DataSource = conn.ds.Tables("QA Agents")

        End If
        conn.fillDS("SELECT CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name FROM lead_primary WHERE leadID = " & leadID, "leadInfo")
        lbLeadID.Text = leadID
        If Not IsDBNull(conn.ds.Tables("leadInfo").Rows(0).Item(0)) Then lbName.Text = conn.ds.Tables("leadInfo").Rows(0).Item(0)
        Me.Show()
    End Sub

    Private Sub btTransfer_Click(sender As Object, e As EventArgs) Handles btTransfer.Click
        If cbAgent.Text = "" Then
            MsgBox("Please choose an agent")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to transfer lead " & lbLeadID.Text & " to " & cbAgent.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If transType = "QA" Then
                conn.send("UPDATE lead_sale_info SET qaAgent = '" & cbAgent.Text & "' WHERE leadID = " & CInt(lbLeadID.Text))
                conn.recordEvent("Transfer Lead", cbAgent.Text, lbLeadID.Text)
                conn.recordChange("qaAgent", frmSide.lbUser.Text, cbAgent.Text, lbLeadID.Text, txReason.Text)

                notify("Lead Transfered")
                If Application.OpenForms().OfType(Of frmQaView).Any Then
                    frmQaView.Close()
                End If
                emailOutlook(conn.sendReturn("SELECT emailAddress FROM sys_users WHERE userName = '" & cbAgent.Text & "'"), "Lead Transferred", "Hi," & vbNewLine & vbNewLine & "I've transferred lead " & lbLeadID.Text & " to you. Thanks")
            Else
                conn.send("UPDATE lead_primary SET outcome = 'Transfered', agent = '" & cbAgent.Text & "' WHERE leadID = " & CInt(lbLeadID.Text))
                conn.recordEvent("Transfer Lead", cbAgent.Text, lbLeadID.Text)
                conn.recordChange("agent", frmSide.lbUser.Text, cbAgent.Text, lbLeadID.Text, txReason.Text)
                notify("Lead Transfered")
                If Application.OpenForms().OfType(Of frmLeadView).Any Then
                    frmLeadView.allowClose = True
                    frmLeadView.Close()
                    frmAfterLead.Show()
                End If
                modExtra.refreshSideBar()
            End If

            Me.Close()
        End If
    End Sub
End Class