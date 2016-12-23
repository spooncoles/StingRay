Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop

Public Class frmSalesTools
    Private Sub frmSalesTools_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        If conn.sendReturn("SELECT viewSalesCount FROM sys_agent_info WHERE userName = '" & frmSide.lbUser.Text & "'") = "True" Then
            cbSalesCount.Checked = True
        Else
            cbSalesCount.Checked = False
        End If
    End Sub

    Private Sub cbSalesCount_CheckedChanged(sender As Object, e As EventArgs) Handles cbSalesCount.CheckedChanged
        If cbSalesCount.Checked Then
            frmSide.btSales.Text = conn.sendReturn("SELECT count(leadID) from lead_primary WHERE status = 'Sale' AND MONTH(closedDate) = MONTH(CURDATE()) AND YEAR(closedDate) = YEAR(CURDATE()) AND agent = '" & frmSide.lbUser.Text & "'")
            If frmSide.btSales.Text = "NULL" Then frmSide.btSales.Text = "0"
        Else
            frmSide.btSales.Text = "###"
        End If
        conn.send("UPDATE sys_agent_info SET recycleAvaliable = " & If(cbSalesCount.Checked, 1, 0) & " WHERE userName = '" & frmSide.lbUser.Text & "'")
    End Sub

    Private Sub llBlankApp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llBlankApp.LinkClicked
        notify("Building...")
        Dim oWord As New Word.Application
        Dim oDoc As Word.Document = oWord.Documents.Open(systemFolder & "SystemMaterial\Personal App Form.docx")
        'oWord.Visible = True

        Dim keywords As New List(Of String) From {"title", "firstName", "lastName", "dateOfBirth", "idNumber", "male", "female", "postal1", "postal2", "postalSuburb", "postalCity", "postalProvince",
             "postalCode", "emailAddress", "contactNumber", "workNumber", "medicalAid", "medicalAidPlan", "medicalDependants", "procedureIn12Months", "policyReplaced", "holderName", "bankName", "branchCode",
             "accountNumber", "accountType", "firstDebitDate", "paymentDay"}

        conn.fillDS("SELECT userName, emailAddress, workNumber FROM sys_users WHERE userName = '" & frmSide.lbUser.Text & "'", "agentInfo")

        Dim rng As Word.Range = oWord.ActiveDocument.Range()
        With rng.Find

            .Text = "<Agent Name>"
            .Replacement.Text = conn.ds.Tables("agentInfo").Rows(0).Item("userName")
            .Execute(Replace:=Word.WdReplace.wdReplaceAll)

            .Text = "<Agent Email>"
            .Replacement.Text = conn.ds.Tables("agentInfo").Rows(0).Item("emailAddress")
            .Execute(Replace:=Word.WdReplace.wdReplaceAll)

            .Text = "<Agent Number>"
            .Replacement.Text = conn.ds.Tables("agentInfo").Rows(0).Item("workNumber")
            .Execute(Replace:=Word.WdReplace.wdReplaceAll)

            For Each keyword As String In keywords
                .Text = "<" & keyword & ">"
                .Replacement.Text = ""
                .Execute(Replace:=Word.WdReplace.wdReplaceAll)
            Next

        End With
        Debug.Print(My.Computer.FileSystem.SpecialDirectories.Temp)
        oDoc.SaveAs(My.Computer.FileSystem.SpecialDirectories.Temp & "\Zestlife Gap App (" & frmSide.lbUser.Text & ").pdf", 17)
        oDoc.Saved = True
        oDoc.Close()
        oWord.Quit()
        releaseObject(oDoc)
        releaseObject(oWord)

        System.Diagnostics.Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp & "\Zestlife Gap App (" & frmSide.lbUser.Text & ").pdf")

    End Sub

    Private Sub llScript_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llScript.LinkClicked
        System.Diagnostics.Process.Start(systemFolder & "SystemMaterial\Script.pdf")
    End Sub

    Private Sub llBrochure_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llBrochure.LinkClicked
        System.Diagnostics.Process.Start(systemFolder & "SystemMaterial\Brochure.pdf")
    End Sub

    Private Sub llDisclosures_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llDisclosures.LinkClicked
        System.Diagnostics.Process.Start(systemFolder & "SystemMaterial\Disclosures.pdf")
    End Sub

    Private Sub llFAQs_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llFAQs.LinkClicked
        System.Diagnostics.Process.Start(systemFolder & "SystemMaterial\Gap FAQ's.pdf")
    End Sub

    Private Sub llPmbExplination_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llPmbExplination.LinkClicked
        System.Diagnostics.Process.Start(systemFolder & "SystemMaterial\PMB Explaination.pdf")
    End Sub
End Class