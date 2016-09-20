Public Class frmLeadBatchGrid
    Public rowIndex As Integer

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        With frmLoadLead.dgLeadsToUpload.Rows(rowIndex)
            .Cells("title").Value = txTitle.Text
            .Cells("firstName").Value = txFirstName.Text
            .Cells("lastName").Value = txLastName.Text
            .Cells("contactNum").Value = txContactNum.Text
            .Cells("Email").Value = txEmailAdd.Text
            .Cells("comment").Value = txComment.Text
            .DefaultCellStyle.BackColor = Color.White
        End With
        Me.Close()

    End Sub
    Public Sub loadLead(rowIndexPassed As Integer)
        frmLoadLead.Hide()
        rowIndex = rowIndexPassed
        With frmLoadLead.dgLeadsToUpload.Rows(rowIndex)
            txTitle.Text = .Cells("title").Value
            txFirstName.Text = .Cells("firstName").Value
            txLastName.Text = .Cells("lastName").Value
            txContactNum.Text = .Cells("contactNum").Value
            txEmailAdd.Text = .Cells("Email").Value
            txComment.Text = .Cells("comment").Value
        End With
        Me.Show()

    End Sub

    Private Sub frmLeadBatchGrid_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        frmLoadLead.Show()
    End Sub
End Class