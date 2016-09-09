Public Class frmLeadTransfer

    Private Sub frmLeadTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain

        cbAgent.DisplayMember = "Key"
        cbAgent.ValueMember = "Value"
        cbAgent.DataSource = New BindingSource(dictAgents, Nothing)
        cbAgent.SelectedIndex = -1
    End Sub

    Public Sub loadLead(leadID As Integer)
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
            conn.send("UPDATE lead_primary SET outcome = 'Transfered', agent = '" & cbAgent.Text & "' WHERE leadID = " & CInt(lbLeadID.Text))
            conn.recordEvent("Transfer Lead", cbAgent.Text, lbLeadID.Text)
            conn.recordChange(cbAgent.Text, frmSide.lbUser.Text, cbAgent.Text, lbLeadID.Text, txReason.Text)
            notify("Lead Transfered")
            If Application.OpenForms().OfType(Of frmLeadView).Any Then
                frmLeadView.allowClose = True
                frmLeadView.Close()
            End If
            frmAfterLead.Show()
            modExtra.refreshSideBar()
            Me.Close()
        End If
    End Sub
End Class