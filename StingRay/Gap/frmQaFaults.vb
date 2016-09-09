Public Class frmQaFaults
    Dim mainLeadID As Integer = 0

    Private Sub frmQaFaults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        Me.Location = New Point(frmMain.Width - Me.Width - 30, (frmMain.Height / 2) - (Me.Height / 2) - 20)
    End Sub

    Public Sub loadLead(leadID As Integer)
        mainLeadID = leadID
        conn.fillDS("SELECT qaAgent, qaOverAllComment FROM lead_sale_info WHERE leadID = " & leadID, "qaStats")
        With conn.ds.Tables("qaStats")
            If .Rows.Count <> 0 Then
                Me.Text = "QA Faults for lead " & leadID
                If Not IsDBNull(.Rows(0).Item("qaAgent")) Then lbQaAgent.Text = "QA Agent = " & .Rows(0).Item("qaAgent")
                If Not IsDBNull(.Rows(0).Item("qaOverAllComment")) Then txOverAllComment.Text = .Rows(0).Item("qaOverAllComment")

                conn.fillDS("SELECT question, qaComment FROM qa_lead_stats INNER JOIN qa_questions ON qa_lead_stats.qaQuestionID = qa_questions.questionID " _
                        & "WHERE pass_fail_NA = 'N' AND leadID = " & leadID, "QaFaults")
                dgFaults.DataSource = conn.ds.Tables("QaFaults")
                Me.Show()
                dgFaults.AutoResizeColumns()
            End If
        End With
    End Sub

    Private Sub btAcceptFail_Click(sender As Object, e As EventArgs) Handles btAcceptFail.Click
        If MsgBox("Are you sure you want to QA fail this lead?", MsgBoxStyle.YesNo, "Fail Lead?") = vbYes Then
            If System.Windows.Forms.Application.OpenForms().OfType(Of frmLeadView).Any Then frmLeadView.Close()
            conn.send("UPDATE lead_sale_info SET qaStatus = 'Fail' WHERE leadID = " & mainLeadID)
            notify("Lead QA Failed. Sorry...")
            Me.Close()
        End If
    End Sub
End Class