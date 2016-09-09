Public Class frmQANonSale
    Dim dtLeadInfo As New DataTable
    Private Sub frmQANonSale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim statuses = From row In dtStatuses.AsEnumerable()
                       Select row.Field(Of String)("Status") Distinct
        For Each status In statuses
            If status <> "Busy" Then cbStatus.Items.Add(status)
        Next

    End Sub

    Public Sub pickUpNonSale()
        Me.Show()

        If Not dtLeadInfo Is Nothing Then
            If Not dtLeadInfo.Columns.Contains("Field") Then
                dtLeadInfo.Columns.Add("Field", GetType(String))
            End If

            If Not dtLeadInfo.Columns.Contains("Value") Then
                dtLeadInfo.Columns.Add("Value", GetType(String))
            End If

        End If

        conn.fillDS("SELECT lead_primary.leadID, agent, contactNumber, cellNumber, workNumber, homeNumber, emailAddress, status, outcome FROM lead_primary LEFT JOIN qa_non_sales ON lead_primary.leadID = qa_non_sales.leadID " _
                    & "WHERE Status NOT IN ('Sale', 'Busy', 'Allocated') AND outcome <> 'No contact (>5 attempts)' " _
                    & "AND MONTH(closedDate) = MONTH(NOW()) AND YEAR(closedDate) = YEAR(NOW())  AND qa_non_sales.leadID IS NULL ORDER BY RAND() LIMIT 1", "qaLeadInfo")
        With conn.ds.Tables("qaLeadInfo")
            If .Rows.Count <> 0 Then
                For Each column In .Columns
                    dtLeadInfo.Rows.Add(column.ColumnName, .Rows(0).Item(column.ColumnName))
                Next column
            End If
        End With

        dgleadInfo.DataSource = dtLeadInfo
        dgleadInfo.Columns("Field").ReadOnly = True
        dgleadInfo.Columns("Value").ReadOnly = True
        dgleadInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

    End Sub

    Private Sub cbStatusCaptured_CheckedChanged(sender As Object, e As EventArgs) Handles cbStatusCaptured.CheckedChanged
        If cbStatusCaptured.Checked Then
            cbStatus.Enabled = False
            cbOutcome.Enabled = False
        Else
            cbStatus.Enabled = True
            If cbStatus.Text <> "" Then cbOutcome.Enabled = True
        End If
    End Sub

    Private Sub cbStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbStatus.SelectedIndexChanged
        cbOutcome.Items.Clear()
        Dim result() As DataRow = dtStatuses.Select("status = '" & cbStatus.Text & "'")
        For Each row As DataRow In result
            cbOutcome.Items.Add(row(1))
        Next
        cbOutcome.Enabled = True
    End Sub

    Private Sub btSubmit_Click(sender As Object, e As EventArgs) Handles btSubmit.Click
        Dim ratings As New List(Of GroupBox) From {gbFriendliness, gbTelephoneEtiquette}
        Dim insertColumns As String = "INSERT INTO qa_non_sales (leadID, user"
        Dim insertValues As String = " VALUES (" & conn.ds.Tables("qaLeadInfo").Rows(0).Item("leadID") & ", '" & frmSide.lbUser.Text & "'"

        If cbStatusCaptured.Checked Then
            insertColumns += ", isStatusCorrect"
            insertValues += ", 1"
        Else
            insertColumns += ", isStatusCorrect, correctedStatus, correctedOutcome"
            insertValues += ", 0, '" & cbStatus.Text & "', '" & cbOutcome.Text & "'"
        End If


        For Each gb In ratings
            For Each rb As RadioButton In gb.Controls
                If rb.Checked Then
                    gb.Tag = rb.Text
                End If
            Next rb
            If gb.Tag <> "" Then
                insertColumns += ", " & Replace(gb.Name, "gb", "rating")
                insertValues += ", '" & gb.Tag & "'"
            End If
        Next gb


        If txImprovementComment.Text <> "" Then
            insertColumns += ", improvementComment"
            insertValues += ", '" & txImprovementComment.Text & "'"
        End If

        If txOverallComment.text <> "" Then
            insertColumns += ", overallComment"
            insertValues += ", '" & txImprovementComment.Text & "'"
        End If

        conn.send(insertColumns & ")" & insertValues & ")")
        notify("Non Sale QA Submitted")
        Me.Close()


    End Sub
End Class