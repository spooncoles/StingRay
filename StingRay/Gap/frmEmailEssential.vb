Public Class frmEmailEssential
    Dim leadID As Integer = 0
    Dim leadName As String = ""
    Dim leadContact As String = ""

    Private Sub frmEmailEssential_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
    End Sub
    Public Sub loadLead(tempLeadID As Integer, tempName As String, tempContact As String)
        lbLeadID.Text = "LeadID = " & tempLeadID
        leadID = tempLeadID
        leadName = tempName
        leadContact = tempContact
        Me.Show()
    End Sub

    Private Sub btEmail_Click(sender As Object, e As EventArgs) Handles btEmail.Click
        Dim emailText As String = "Hi," & vbNewLine & vbNewLine _
            & "See below lead interested in Essential Med" & vbNewLine & vbNewLine _
            & "ZestleadID: " & leadID & vbNewLine _
            & leadName & vbNewLine _
            & "Contact: " & leadContact & vbNewLine _
            & "Call Time: " & cbCallTime.Text & vbNewLine _
            & "Comment: " & txComment.Text

        emailOutlook("rep1@essentialmed.co.za", "Zestlife Lead", emailText)
        conn.recordEvent("Sent Essential Lead", "CallTime:" & cbCallTime.Text & "/Comment:" & txComment.Text, leadID)
        frmAfterLead.Show()
        Me.Close()
    End Sub

    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        conn.recordEvent("Canceled Essential Lead", , leadID)
        frmAfterLead.Show()
        Me.Close()
    End Sub
End Class