Public Class frmLoadAffinity

    Private Sub frmLoadAffinity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        cbCampaign.SelectedIndex = 0

        If frmSide.lbType.Text = "Agent" Then
            rbReferral.Checked = True
            rbAffinity.Enabled = False
            cbType.Text = "Zwing"
            cbType.Enabled = False
            txGroup.Enabled = False
        End If

        Dim mtbs As New List(Of MaskedTextBox) From {txContactNum, txIdNum}
        For Each mtb In mtbs
            AddHandler mtb.MouseClick, AddressOf mtb_MouseClick
        Next mtb
    End Sub

    Public Sub populateReferal(leadID As Integer)
        conn.fillDS("SELECT leadID, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name, contactNumber, idNumber, emailAddress FROM lead_primary WHERE leadID = " & leadID, "leadDetails")
        With conn.ds.Tables("leadDetails").Rows(0)
            If Not IsDBNull(.Item("Name")) Then txAffinityName.Text = .Item("Name")
            If Not IsDBNull(.Item("contactNumber")) Then txContactNum.Text = .Item("contactNumber")
            If Not IsDBNull(.Item("idNumber")) Then txIdNum.Text = .Item("idNumber")
            If Not IsDBNull(.Item("emailAddress")) Then txEmailAdd.Text = .Item("emailAddress")
            txLeadID.Text = leadID
        End With
        Me.Show()
    End Sub

    Private Sub rbVat_CheckedChanged(sender As Object, e As EventArgs) Handles rbVat.CheckedChanged
        txIdNum.Mask = "0000000000"
    End Sub

    Private Sub rbID_CheckedChanged(sender As Object, e As EventArgs) Handles rbID.CheckedChanged
        txIdNum.Mask = "000000-0000-000"
    End Sub

    Private Sub cbAdminCode_CheckedChanged(sender As Object, e As EventArgs) Handles cbAdminCode.CheckedChanged
        If cbAdminCode.Checked Then
            txAdminCode.Enabled = True
        Else
            txAdminCode.Enabled = False
        End If
    End Sub

    Private Sub btConfirm_Click(sender As Object, e As EventArgs) Handles btConfirm.Click

        Dim maskedText As MaskedTextBox = Nothing
        Dim wanted As String = ""
        Dim insertColumns As String = ""
        Dim insertValues As String = ""
        Dim adminCode As String = ""
        Dim validateResponse As String = ""
        Dim deDup As String = "SELECT adminCode, affinityName, contactNum, Vat_ID, emailAdd FROM affinities WHERE "

        Dim controls As New List(Of Control) From {txAdminCode, txAffinityName, cbCampaign, txContactNum, txIdNum, txEmailAdd, cbType, txGroup, txLeadID}
        For Each control In controls
            If TypeOf control Is MaskedTextBox Then
                maskedText = control
                maskedText.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
            End If

            Select Case control.Name
                Case "txAdminCode"
                    If cbAdminCode.Checked And txAdminCode.Text = "" Then
                        MsgBox("If you do not have an admin code yet, please uncheck the admin code box and request admin code from finance.")
                        Exit Sub
                    ElseIf Not cbAdminCode.Checked Then
                        adminCode = "TEMP" & conn.sendReturn("SELECT REPLACE(adminCode, 'TEMP', '') + 1 FROM affinities WHERE LEFT(adminCode, 4) = 'TEMP' ORDER BY CAST(REPLACE(adminCode, 'TEMP', '') AS UNSIGNED) DESC LIMIT 1")
                    ElseIf cbAdminCode.Checked And txAdminCode.Text <> "" Then
                        adminCode = control.Text
                    End If

                Case "txAffinityName"
                    If control.Text = "" Then
                        MsgBox("Please fill out an Affinity Name")
                        Exit Sub
                    Else
                        deDup += " affinityName = '" & txAffinityName.Text & "' OR"
                        'Dim foundAdminCode As String = conn.sendReturn("SELECT adminCode FROM affinities WHERE affinityName = '" & txAffinityName.Text & "'")
                        'If foundAdminCode <> "NULL" Then
                        '    MsgBox("Affinity named " & txAffinityName.Text & " already exists under admincode " & foundAdminCode & ". Please choose another name.")
                        '    Exit Sub
                        'Else
                        insertColumns = insertColumns & ", " & control.Tag
                        insertValues = insertValues & ", '" & control.Text & "'"
                        'End If
                    End If

                Case "cbCampaign", "cbType"
                    If control.Text = "" Then
                        MsgBox("Please fill out " & control.Tag)
                        Exit Sub
                    Else
                        insertColumns = insertColumns & ", " & control.Tag
                        insertValues = insertValues & ", '" & control.Text & "'"
                    End If

                Case "txContactNum", "txIdNum", "txEmailAdd"
                    If control.Text = "" Then
                        MsgBox("Please fill out " & control.Tag)
                        Exit Sub
                    Else
                        If control.Name = "txContactNum" Then
                            validateResponse = validateContactNumber(txContactNum.Text)
                            deDup += " contactNum = '" & txContactNum.Text & "' OR"
                        ElseIf control.Name = "txIdNum" And rbID.Checked Then
                            validateResponse = validateIdNumber(txIdNum.Text)
                            deDup += " Vat_ID = '" & txIdNum.Text & "' OR"
                        ElseIf control.Name = "txIdNum" And rbVat.Checked Then
                            validateResponse = validateVatNumber(txIdNum.Text)
                            deDup += " Vat_ID = '" & txIdNum.Text & "' OR"
                        ElseIf control.Name = "txEmailAdd" Then
                            validateResponse = If(validateEmail(txEmailAdd.Text), "Pass", "Email not valid.")
                            deDup += " emailAdd = '" & txEmailAdd.Text & "' OR"
                        End If

                        If validateResponse <> "Pass" And control.Name <> "txGroup" Then
                            MsgBox(validateResponse)
                            Exit Sub
                        Else
                            insertColumns = insertColumns & ", " & control.Tag
                            insertValues = insertValues & ", '" & control.Text & "'"
                        End If
                    End If

                Case "txGroup"
                    If control.Text <> "" Then
                        insertColumns = insertColumns & ", " & control.Tag
                        insertValues = insertValues & ", '" & control.Text & "'"
                    End If

                Case "txLeadID"
                    If txLeadID.Text = "" And rbAffinity.Checked Then
                        wanted = wanted & control.Name & vbNewLine
                    ElseIf txLeadID.Text <> "" Then
                        If conn.sendReturn("SELECT leadID FROM lead_primary WHERE leadID = '" & txLeadID.Text & "'") = "NULL" Then
                            MsgBox("This lead ID does not exist in our database. Please check and re-confirm.")
                            txLeadID.Focus()
                            Exit Sub
                        Else
                            insertColumns = insertColumns & ", " & control.Tag
                            insertValues = insertValues & ", '" & control.Text & "'"
                        End If
                    End If
            End Select

            If TypeOf control Is MaskedTextBox Then maskedText.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
        Next control

        deDup = deDup.Substring(0, deDup.Length - 3)
        'adminCode, affinityName, contactNum, Vat_ID, emailAdd
        conn.fillDS(deDup, "duplicates")
        If conn.ds.Tables("duplicates").Rows.Count <> 0 Then
            With conn.ds.Tables("duplicates").Rows(0)
                If MsgBox("A affinty/referal exists with the following: " & vbNewLine _
                          & vbNewLine & "adminCode: " & .Item("adminCode") _
                          & vbNewLine & "affinityName: " & .Item("affinityName") _
                          & vbNewLine & "contactNum: " & If(Not IsDBNull(.Item("contactNum")), .Item("contactNum"), "") _
                          & vbNewLine & "Vat_ID: " & If(Not IsDBNull(.Item("Vat_ID")), .Item("Vat_ID"), "") _
                          & vbNewLine & "emailAdd: " & If(Not IsDBNull(.Item("emailAdd")), .Item("emailAdd"), "") _
                          & vbNewLine & vbNewLine & "Would you like to load a lead with this affinity/referal?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                Else
                    adminCode = .Item("adminCode")
                    If adminCode <> "" Then
                        frmLoadLead.Show()
                        frmLoadLead.lbAffinityCode.Text = adminCode
                        frmLoadLead.lbAffinityName.Text = txAffinityName.Text
                        frmLoadLead.tabControl.TabPages(1).Enabled = True
                        frmLoadLead.tabControl.SelectedTab = frmLoadLead.tabControl.TabPages(1)
                        frmLoadLead.cbTitle.Focus()
                        Me.Close()
                        Exit Sub
                    End If
                End If
            End With
        End If

        'If wanted <> "" Then
        '    If MsgBox("Are you sure you don't want to fill in the following: " & vbNewLine & wanted, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '        Exit Sub
        '    End If
        'End If

        If MsgBox("Are you sure you want to load the affinity/referal?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            conn.send("INSERT INTO affinities (loadedBy, adminCode" & insertColumns & ") " _
                  & "VALUES('" & frmSide.lbUser.Text & "', '" & adminCode & "'" & insertValues & ")")

            notify("Affinity/Referal loaded. Thank-you.")
            If MsgBox("Would you like to load a lead on this referal/affinity?", MsgBoxStyle.YesNo, "Referal Loaded") = vbYes Then
                If adminCode <> "" Then
                    frmLoadLead.Show()
                    frmLoadLead.lbAffinityCode.Text = adminCode
                    frmLoadLead.lbAffinityName.Text = txAffinityName.Text
                    frmLoadLead.tabControl.TabPages(1).Enabled = True
                    frmLoadLead.tabControl.SelectedTab = frmLoadLead.tabControl.TabPages(1)
                    frmLoadLead.cbTitle.Focus()
                End If
            End If
            Me.Close()
        End If
    End Sub

    Private Sub mtb_MouseClick(sender As Object, e As MouseEventArgs)
        sender.Select(sender.MaskedTextProvider.LastAssignedPosition + 1, 0)
    End Sub

End Class