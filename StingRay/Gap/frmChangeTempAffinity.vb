Public Class frmChangeTempAffinity

    Private Sub frmChangeTempAffinity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        refreshTempCodes()
    End Sub

    Private Sub btConfirm_Click(sender As Object, e As EventArgs) Handles btConfirm.Click
        If conn.sendReturn("SELECT adminCode FROM affinities WHERE adminCode = '" & txNewAdminCode.Text & "'") = "NULL" Then
            If MsgBox("Are you sure you want to change the select affinity code " & dgTempAffinities.SelectedRows(0).Cells("adminCode").Value & " to the admin code: " & txNewAdminCode.Text, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                conn.send("UPDATE affinities SET adminCode = '" & txNewAdminCode.Text & "' WHERE adminCode = '" & dgTempAffinities.SelectedRows(0).Cells("adminCode").Value & "'")
                conn.send("UPDATE lead_primary SET affinityCode = '" & txNewAdminCode.Text & "' WHERE affinityCode = '" & dgTempAffinities.SelectedRows(0).Cells("adminCode").Value & "'")
                conn.send("UPDATE lead_new SET supplier = '" & txNewAdminCode.Text & "' WHERE supplier = '" & dgTempAffinities.SelectedRows(0).Cells("adminCode").Value & "'")
                notify("Temp admin code changed.")
                refreshTempCodes()
                txNewAdminCode.Clear()
            End If
        Else
            MsgBox("Admin code already exists! Please check with system admin.")
            txNewAdminCode.Focus()
        End If
    End Sub

    Private Sub cbSalesOnly_CheckedChanged(sender As Object, e As EventArgs) Handles cbSalesOnly.CheckedChanged
        refreshTempCodes()
    End Sub

    Public Sub refreshTempCodes()
        If cbSalesOnly.Checked Then
            conn.fillDS("SELECT adminCode, affinityName, affinity FROM affinities INNER JOIN lead_primary ON adminCode = affinityCode WHERE status = 'Sale' AND LEFT(adminCode, 4) = 'TEMP' AND affinity = 0 GROUP BY adminCode ORDER BY affinityName", "tempAffinities")
        Else
            conn.fillDS("SELECT adminCode, affinityName, affinity FROM affinities WHERE LEFT(adminCode, 4) = 'TEMP' AND affinity = 0 ORDER BY affinityName", "tempAffinities")
        End If

        dgTempAffinities.DataSource = conn.ds.Tables("tempAffinities")
    End Sub

    Private Sub txAdminCode_KeyUp(sender As Object, e As KeyEventArgs) Handles txAdminCode.KeyUp
        If cbSalesOnly.Checked Then
            conn.fillDS("SELECT adminCode, affinityName, affinity FROM affinities INNER JOIN lead_primary ON adminCode = affinityCode WHERE adminCode LIKE '" & txAdminCode.Text & "%' AND status = 'Sale' AND LEFT(adminCode, 4) = 'TEMP' AND affinity = 0 GROUP BY adminCode ORDER BY affinityName", "tempAffinities")
        Else
            conn.fillDS("SELECT adminCode, affinityName, affinity FROM affinities WHERE adminCode LIKE '" & txAdminCode.Text & "%' AND LEFT(adminCode, 4) = 'TEMP' AND affinity = 0 ORDER BY affinityName", "tempAffinities")
        End If
        dgTempAffinities.DataSource = conn.ds.Tables("tempAffinities")
    End Sub

    Private Sub txAffName_KeyUp(sender As Object, e As KeyEventArgs) Handles txAffName.KeyUp
        If cbSalesOnly.Checked Then
            conn.fillDS("SELECT adminCode, affinityName, affinity FROM affinities INNER JOIN lead_primary ON adminCode = affinityCode WHERE affinityName LIKE '" & txAffName.Text & "%' AND status = 'Sale' AND LEFT(adminCode, 4) = 'TEMP' AND affinity = 0 GROUP BY adminCode ORDER BY affinityName", "tempAffinities")
        Else
            conn.fillDS("SELECT adminCode, affinityName, affinity FROM affinities WHERE affinityName LIKE '" & txAffName.Text & "%' AND LEFT(adminCode, 4) = 'TEMP' AND affinity = 0 ORDER BY affinityName", "tempAffinities")
        End If
        dgTempAffinities.DataSource = conn.ds.Tables("tempAffinities")
    End Sub

End Class