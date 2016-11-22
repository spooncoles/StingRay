Public Class frmSide

    Private Sub frmSide_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(10, (frmMain.Height / 2) - (Me.Height / 2) - 20)

        lvQueue.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

        Dim controls As New List(Of Control) From {lbUser, lbType, pbRefresh}
        For Each a In controls
            a.Parent = PictureBox1
            a.Width = PictureBox1.Width
            a.BackColor = Color.Transparent
        Next
        lbUser.Location = New Point(0, 25)
        lbType.Location = New Point(0, 45)
        pbRefresh.Location = New Point(0, 70)

    End Sub

    Public Sub nextInQueue(frm As Form)
        If lvQueue.Items.Count <> 0 Then
            If frm.Name = "frmQaView" Then
                frmQaView.loadLead(lvQueue.Items(0).SubItems(0).Text)
                lvQueue.Items(0).Remove()
            ElseIf frm.Name = "frmLeadView" Then
                frmLeadView.loadLead(lvQueue.Items(0).SubItems(0).Text)
                lvQueue.Items(0).Remove()
            End If
        Else
            MsgBox("No more in queue!")
        End If
    End Sub

    Public Sub addToQueue(leadID As String, leadName As String)
        For Each item In lvQueue.Items
            If item.SubItems(0).Text() = leadID Then
                MsgBox("Lead " & leadID & " is already in queue!")
                Exit Sub
            End If
        Next
        Dim str() As String = {leadID, leadName}
        lvQueue.Items.Add(New ListViewItem(str))
        lvQueue.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub btAllocated_Click(sender As Object, e As EventArgs) Handles btAllocated.Click
        If btAllocated.Text <> "0" Then
            frmLeadPickUp.clearAll()
            frmLeadPickUp.cbAvaliable.Checked = True
            If Application.OpenForms().OfType(Of frmLeadPickUp).Any Then frmLeadPickUp.refreshLeads()
            If Application.OpenForms().OfType(Of frmLeadView).Any Then
                MsgBox("You cannot search for a lead if you are viewing a lead.")
            Else
                frmLeadPickUp.Show()
            End If
        Else
            MsgBox("No 'Allocated' Leads")
        End If
    End Sub

    Private Sub btBusy_Click(sender As Object, e As EventArgs) Handles btBusy.Click
        If btBusy.Text <> "0" Then
            frmLeadPickUp.clearAll()
            frmLeadPickUp.cbBusy.Checked = True
            If Application.OpenForms().OfType(Of frmLeadPickUp).Any Then frmLeadPickUp.refreshLeads()
            If Application.OpenForms().OfType(Of frmLeadView).Any Then
                MsgBox("You cannot search for a lead if you are viewing a lead.")
            Else
                frmLeadPickUp.Show()
            End If

        Else
            MsgBox("No 'Busy' Leads")
        End If
    End Sub

    Private Sub btScheduled_Click(sender As Object, e As EventArgs) Handles btScheduled.Click
        If btScheduled.Text <> "0" Then
            frmLeadPickUp.clearAll()
            frmLeadPickUp.rescheduleLeads = True
            If Application.OpenForms().OfType(Of frmLeadPickUp).Any Then frmLeadPickUp.refreshLeads()
            If Application.OpenForms().OfType(Of frmLeadView).Any Then
                MsgBox("You cannot search for a lead if you are viewing a lead.")
            Else
                frmLeadPickUp.Show()
            End If
        Else
            MsgBox("No reschedules for today or earlier")
        End If
    End Sub

    Private Sub btQaFails_Click(sender As Object, e As EventArgs) Handles btQaFails.Click
        If btQaFails.Text <> "0" Then
            frmLeadPickUp.clearAll()
            frmLeadPickUp.qaFails = True
            If Application.OpenForms().OfType(Of frmLeadPickUp).Any Then frmLeadPickUp.refreshLeads()
            If Application.OpenForms().OfType(Of frmLeadView).Any Then
                MsgBox("You cannot search for a lead if you are viewing a lead.")
            Else
                frmLeadPickUp.Show()
            End If
        Else
            MsgBox("No QA Fails to check")
        End If
    End Sub

    Private Sub btRemoveSelected_Click(sender As Object, e As EventArgs) Handles btRemoveSelected.Click
        For Each i As ListViewItem In lvQueue.CheckedItems
            lvQueue.Items.Remove(i)
        Next
    End Sub

    Private Sub btSales_Click(sender As Object, e As EventArgs) Handles btSales.Click
        frmSales.Show()
    End Sub

    Private Sub llPickFromQueue_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llPickFromQueue.LinkClicked
        If lbType.Text = "Agent" Or lbType.Text = "Admin" Then
            nextInQueue(frmLeadView)
        ElseIf lbType.Text = "QA Agent" Then
            nextInQueue(frmQaView)
        End If
    End Sub

    Private Sub pbRefresh_Click(sender As Object, e As EventArgs) Handles pbRefresh.Click
        refreshSideBar()
        notify("Side bar refreshed")
    End Sub

    Private Sub btTransfers_Click(sender As Object, e As EventArgs) Handles btTransfers.Click
        If btTransfers.Text <> "0" Then
            frmLeadPickUp.clearAll()
            frmLeadPickUp.transfers = True
            If Application.OpenForms().OfType(Of frmLeadPickUp).Any Then frmLeadPickUp.refreshLeads()
            If Application.OpenForms().OfType(Of frmLeadView).Any Then
                MsgBox("You cannot search for a lead if you are viewing a lead.")
            Else
                frmLeadPickUp.Show()
            End If
        Else
            MsgBox("No transfers avaliable")
        End If
    End Sub

    Public Sub removeLead(leadID As String)
        For Each item In lvQueue.Items
            If item.SubItems(0).Text() = leadID Then
                lvQueue.Items.Remove(item)
            End If
        Next
    End Sub

    Private Sub cbRecieveLeads_CheckedChanged(sender As Object, e As EventArgs) Handles cbRecieveLeads.CheckedChanged
        If cbRecieveLeads.Checked Then
            conn.send("UPDATE sys_agent_info SET recieveLeads = 1 WHERE userName = '" & lbUser.Text & "'")
            cbRecieveLeads.ForeColor = Color.Black
        Else
            conn.send("UPDATE sys_agent_info SET recieveLeads = 0 WHERE userName = '" & lbUser.Text & "'")
            cbRecieveLeads.ForeColor = Color.Red
        End If
    End Sub
End Class