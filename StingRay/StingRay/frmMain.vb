Imports System.ComponentModel

Public Class frmMain

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLeadView).Any Then
            MsgBox("You cannot exit while still in a lead!")
        Else
            If frmSide.lbType.Text = "Agent" Then
                If frmSide.lvQueue.Items.Count > 0 Then
                    If MsgBox("There are leads in Queue." & vbNewLine & "Do you want to save these for next time?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        saveQueue(frmSide.lbUser.Text)
                    Else
                        conn.send("UPDATE sys_agent_info SET previousQueue = NULL WHERE userName = '" & frmSide.lbUser.Text & "'")
                    End If
                End If
            End If
            conn.recordEvent("Logout")
            Application.Exit()
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        frmSide.MdiParent = Me
        'frmLeadPickUp.MdiParent = Me
        'frmLoadLead.MdiParent = Me
        frmQaView.MdiParent = Me
        frmQaAdmin.MdiParent = Me
        frmExportSalesFile.MdiParent = Me
        frmSide.Show()

        If frmSide.lbType.Text = "Admin" Then
            'frmLeadTransfer.loadLead(7117)
        End If


    End Sub

    Private Sub menuFindLead_Click(sender As Object, e As EventArgs) Handles menuFindLead.Click
        If Application.OpenForms().OfType(Of frmLeadView).Any Then
            MsgBox("You cannot search for a lead if you are viewing a lead.")
        Else
            frmLeadPickUp.Show()
        End If
    End Sub

    Private Sub menuLoadLead_Click(sender As Object, e As EventArgs) Handles menuLoadLead.Click
        Console.Write(menuLoadLead.ShortcutKeys)

        frmLoadLead.Show()
    End Sub

    Private Sub menuQaPickUp_Click(sender As Object, e As EventArgs) Handles menuQaPickUp.Click
        frmQaPickUp.Show()
    End Sub

    Private Sub menuQaAdmin_Click(sender As Object, e As EventArgs) Handles menuQaAdmin.Click
        frmQaAdmin.Show()
    End Sub

    Private Sub menuChangeLeads_Click(sender As Object, e As EventArgs) Handles menuChangeLeads.Click
        frmLeadChange.Show()
    End Sub

    Private Sub ExportSalesFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportSalesFileToolStripMenuItem.Click
        frmExportSalesFile.Show()
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If ((Me.Height / 2) - (frmSide.Height / 2) - 20) > 1 Then
            frmSide.Location = New Point(10, (Me.Height / 2) - (frmSide.Height / 2) - 20)
        Else
            frmSide.Location = New Point(10, 10)
        End If
        Me.Refresh()
    End Sub

    Private Sub menuNewUser_Click(sender As Object, e As EventArgs) Handles menuNewUser.Click
        frmNewUser.Show()
    End Sub

    Private Sub LoadAfinityToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles menuLoadAfinity.Click
        frmLoadAffinity.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles menuLoadReferral.Click
        frmLoadAffinity.rbReferral.Checked = True
        frmLoadAffinity.rbAffinity.Enabled = False
        frmLoadAffinity.Show()
    End Sub

    Private Sub menuTempAdminCode_Click(sender As Object, e As EventArgs) Handles menuTempAdminCode.Click
        frmChangeTempAffinity.Show()
    End Sub

    Private Sub LoadLeadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadLeadToolStripMenuItem.Click
        frmLoadLead.Show()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        If Application.OpenForms().OfType(Of frmLeadView).Any Then
            MsgBox("You cannot update while still in a lead!")
        Else
            Process.Start("""\\zactfp03\zestlife_home\Zestlife Call Centre\ZestSystem\Application\StingrayUpdate.vbs""")
        End If
    End Sub

    Private Sub IncentivesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles menuIncentives.Click
        frmIncentives.Show()
    End Sub

    Private Sub QANonSaleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QANonSaleToolStripMenuItem.Click
        frmQANonSale.pickUpNonSale()

    End Sub

    Private Sub QAStatsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QAStatsToolStripMenuItem.Click
        frmQaStats.Show()
    End Sub

    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If Application.OpenForms().OfType(Of frmLeadView).Any Then
            MsgBox("You cannot exit while still in a lead!")
            e.Cancel = True
        Else
            If frmSide.lbType.Text = "Agent" Then
                If frmSide.lvQueue.Items.Count > 0 Then
                    If MsgBox("There are leads in Queue." & vbNewLine & "Do you want to save these for next time?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        saveQueue(frmSide.lbUser.Text)
                    Else
                        conn.send("UPDATE sys_agent_info SET previousQueue = NULL WHERE userName = '" & frmSide.lbUser.Text & "'")
                    End If
                End If
            End If
            conn.recordEvent("Logout")
            'Application.Exit()
        End If
    End Sub

    Private Sub FindReferralDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindReferralDetailsToolStripMenuItem.Click
        frmReferralLookUp.Show()
    End Sub
End Class
