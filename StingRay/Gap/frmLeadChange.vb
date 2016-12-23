
Public Class frmLeadChange
    'Dim conn As New clConn("local")
    Dim specificLeads As Boolean = False

    Private Sub frmLeadChange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        dtFrom.Value = CDate(Date.Today.AddDays(-7))
        dtTo.Value = Today

        cbAffinity.DisplayMember = "Key"
        cbAffinity.ValueMember = "Value"
        cbAffinity.DataSource = New BindingSource(dictAffinities, Nothing)
        cbAffinity.SelectedIndex = -1

        cbAgent.DisplayMember = "Key"
        cbAgent.ValueMember = "Value"
        cbAgent.DataSource = New BindingSource(dictAgents, Nothing)
        cbAgent.SelectedIndex = -1


    End Sub

    Public Sub refreshLeads()
        If cbOrder.Text = "" Then cbOrder.Text = "loadedDate"
        If cbOrderDirection.Text = "" Then cbOrderDirection.Text = "ASC"

        Dim selectString As String = "SELECT leadID, loadedDate, CONCAT(COALESCE(firstName,''), ' ', COALESCE(lastName,'')) AS Name, status, outcome, agent, affinityName, source, contactNumber, emailAddress FROM lead_primary" _
                                         & " INNER JOIN affinities ON adminCode = affinityCode"
        Dim whereString As String = " WHERE "
        Dim orderString As String = " ORDER BY " & cbOrder.Text & " " & UCase(cbOrderDirection.Text)

        'Field Searches
        Dim searchFields As New List(Of Control) From {txLeadID, txFirstName, txLastName, txContactNum, txEmailAdd, txIDNum, cbAgent}
        For Each field In searchFields
            If field.Text <> "" Then
                If field.Name = "txLeadID" Then
                    If whereString = " WHERE " Then
                        whereString = whereString & field.Tag & " = '" & Replace(field.Text, "'", "''") & "'"
                    Else
                        whereString = whereString & " AND " & field.Tag & " = '" & Replace(field.Text, "'", "''") & "'"
                    End If
                Else
                    If whereString = " WHERE " Then
                        whereString = whereString & field.Tag & " LIKE '" & Replace(field.Text, "'", "''") & "%'"
                    Else
                        whereString = whereString & " AND " & field.Tag & " LIKE '" & Replace(field.Text, "'", "''") & "%'"
                    End If
                End If
            End If
        Next field

        'Status Searches
        If whereString <> " WHERE " Then whereString = whereString & " AND "

        Select Case CStr(cbAvaliable.CheckState & cbBusy.CheckState & cbStatusOther.CheckState)
            Case "110"
                whereString = whereString & " status IN ('Allocated', 'Busy')"
            Case "100"
                whereString = whereString & " status ='Allocated'"
            Case "010"
                whereString = whereString & " status = 'Busy'"
            Case "001"
                whereString = whereString & " status NOT IN ('Allocated', 'Busy')"
        End Select

        'Affinity Check
        If cbAffinity.Text = "Referal" Then
            whereString = whereString & " AND affinity = 0"
        ElseIf cbAffinity.Text <> "Affinity" Then
            whereString = whereString & " AND affinityName LIKE '" & cbAffinity.Text & "%'"
        End If

        'Date Check
        If cbDates.CheckState Then
            whereString = whereString & " AND DATE(loadedDate) BETWEEN '" & Format(CDate(dtFrom.Value), "yyyy-MM-dd") & "' AND '" & Format(CDate(dtTo.Value), "yyyy-MM-dd") & "'"
        End If

        conn.fillDS(selectString & whereString & orderString, "leadPicks")

        If conn.ds.Tables("leadPicks").Rows.Count = 0 Then
            notify("No leads found for search criteria.")
        Else
            dgPickUp.DataSource = conn.ds.Tables("leadPicks")
            dgPickUp.AutoResizeColumns()
            dgPickUp.AutoResizeRows()
            dgPickUp.Refresh()
            dgPickUp.Focus()
        End If
    End Sub

    Public Sub numKeyPress(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal txBox As Object)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then e.Handled = True
        End If
    End Sub

#Region "TextBoxes"

    Private Sub txLeadID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txLeadID.KeyPress
        If Asc(e.KeyChar) = 13 Then refreshLeads()
    End Sub

    Private Sub txFirstName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txFirstName.KeyPress
        If Asc(e.KeyChar) = 13 Then refreshLeads()
    End Sub

    Private Sub txLastName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txLastName.KeyPress
        If Asc(e.KeyChar) = 13 Then refreshLeads()
    End Sub

    Private Sub txContactNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txContactNum.KeyPress
        If Asc(e.KeyChar) = 13 Then
            refreshLeads()
        Else
            numKeyPress(e, sender)
        End If
        If txContactNum.Text <> "" Then
            If txContactNum.Text.Substring(0, 1) = "0" Then txContactNum.Text = txContactNum.Text.Substring(1)
        End If
    End Sub

    Private Sub txIDNum_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txIDNum.KeyPress
        If Asc(e.KeyChar) = 13 Then
            refreshLeads()
        Else
            numKeyPress(e, sender)
        End If
    End Sub

#End Region

#Region "CheckBoxes"
    Private Sub cbStatusOther_CheckedChanged(sender As Object, e As EventArgs) Handles cbStatusOther.CheckedChanged
        If cbStatusOther.Checked Then
            cbAvaliable.Checked = False
            cbBusy.Checked = False
        End If
    End Sub

    Private Sub cbAvaliable_CheckedChanged(sender As Object, e As EventArgs) Handles cbAvaliable.CheckedChanged
        If cbAvaliable.Checked Then cbStatusOther.Checked = False
    End Sub

    Private Sub cbBusy_CheckedChanged(sender As Object, e As EventArgs) Handles cbBusy.CheckedChanged
        If cbBusy.Checked Then cbStatusOther.Checked = False
    End Sub
#End Region

    Private Sub btSearch_Click(sender As Object, e As EventArgs) Handles btSearch.Click
        refreshLeads()
    End Sub

    Private Sub cbFieldChange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbFieldChange.SelectedIndexChanged
        If cbFieldChange.Text = "Agent" Or cbFieldChange.Text = "Affinity" Then
            cbChangeTo.DataSource = Nothing
            cbChangeTo.DisplayMember = "Key"
            cbChangeTo.ValueMember = "Value"
        End If

        Select Case cbFieldChange.Text
            Case "Agent"
                cbChangeTo.DataSource = New BindingSource(modExtra.dictAgents, Nothing)
                visibleChangeTo(True, False, False)
            Case "Affinity"
                cbChangeTo.DataSource = New BindingSource(modExtra.dictAffinities, Nothing)
                visibleChangeTo(True, False, False)
            Case "Status"
                Dim statuses() As String = {"Allocated", "Busy"}
                cbChangeTo.DataSource = statuses
                visibleChangeTo(True, False, False)
            Case "Source"
                cbChangeTo.DataSource = modExtra.sourcesArray
                visibleChangeTo(True, False, False)
            Case "ContactNumber"
                visibleChangeTo(False, True, False)
            Case "EmailAddress", "firstName", "lastName", "Comment"
                visibleChangeTo(False, False, True)
            Case ""
                visibleChangeTo(False, False, False)
        End Select

    End Sub

    Public Sub visibleChangeTo(combo As Boolean, contactNum As Boolean, email As Boolean)
        cbChangeTo.Visible = combo
        txContactNumChange.Visible = contactNum
        txEmailAddChange.Visible = email

        lbChangeTo.Visible = combo Or contactNum Or email

    End Sub

    Private Sub btAddChange_Click(sender As Object, e As EventArgs) Handles btAddChange.Click
        If lbChangeTo.Visible Then
            If cbChangeTo.Text = "Referal" Then
                MsgBox("You can't change to a referal yet. Please speak to the adminstrator.")
                cbChangeTo.Text = ""
                Exit Sub
            End If

            For Each item In lvChanges.Items
                If (item.Text = cbFieldChange.Text) Or (item.text = "AffinityCode" And cbFieldChange.Text = "Affinity") Then
                    If MsgBox("Do you want to replace current change field with this selection?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        item.Remove()
                    Else
                        Exit Sub
                    End If
                End If
            Next

            Dim changeTo As String = ""
            Select Case cbFieldChange.Text
                Case "firstName", "lastName", "Comment"
                    changeTo = txEmailAddChange.Text
                Case "EmailAddress"
                    If validateEmail(txEmailAddChange.Text) Then
                        changeTo = txEmailAddChange.Text
                    Else
                        MsgBox("Not a valid email. Please check.")
                        Exit Sub
                    End If
                Case "ContactNumber"
                    txContactNumChange.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
                    Dim validate As String = validateContactNumber(txContactNumChange.Text)
                    If validate = "Pass" Then
                        changeTo = txContactNumChange.Text
                    Else
                        MsgBox(validate)
                        Exit Sub
                    End If
                    txContactNumChange.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
                Case Else
                    changeTo = cbChangeTo.Text
            End Select

            If changeTo <> "" Then
                Dim str() As String = {cbFieldChange.Text, changeTo}
                lvChanges.Items.Add(New ListViewItem(str))
            Else
                MsgBox("Please enter a value to change to.")
            End If

        End If
    End Sub

    Private Sub btConfirmChanges_Click(sender As Object, e As EventArgs) Handles btConfirmChanges.Click
        If lvChanges.Items.Count <> 0 Then
            Dim singleChange As Boolean = False
            Dim changeLoadedDate As Boolean = False
            Dim comment As String = ""
            Dim changeString = "UPDATE lead_primary SET "
            For Each item In lvChanges.Items
                Select Case item.Text
                    Case "emailAddress", "contactNumber", "firstName", "lastName", "Comment"
                        singleChange = True
                End Select

                If item.Text = "Affinity" Then
                    changeString = changeString & "affinityCode = '" & modExtra.dictAffinities.Item(item.subItems(1).Text) & "'"
                ElseIf item.Text = "Status" And item.subItems(1).Text = "Allocated" Then
                    changeLoadedDate = True
                    changeString = changeString & "Status = 'Allocated', Outcome = NULL"
                ElseIf item.Text = "Comment" Then
                    comment = item.subItems(1).Text
                Else
                    changeString = changeString & item.Text & " = '" & item.subItems(1).Text & "'"
                End If

                If (item.Index <> lvChanges.Items.Count - 1) And (item.Text <> "Comment") Then
                    changeString = changeString & ", "
                ElseIf (item.Index = lvChanges.Items.Count - 1) And (item.Text = "Comment") Then
                    changeString = changeString.Substring(0, changeString.Length - 2)
                End If
            Next item

            If changeLoadedDate Then
                changeString = changeString & ", loadedDate = '" & Format(Now(), "yyyy-MM-dd HH:mm:ss") & "'"
            End If
            changeString = changeString & " WHERE leadID = "

            If dgPickUp.SelectedRows.Count = 0 Then
                MsgBox("You have not selected any rows to change! Please search for the leads and select the ones you want to change.")
                Exit Sub
            ElseIf dgPickUp.SelectedRows.Count = 1 Then
                If MsgBox("Are you sure you want to change the selected lead?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            ElseIf dgPickUp.SelectedRows.Count > 1 Then
                If singleChange Then
                    MsgBox("You cannot change multiple leads if you are changing the contact number, email address, first name, last name or comment!")
                    Exit Sub
                End If
                If MsgBox("Are you sure you want to change the selected " & dgPickUp.SelectedRows.Count & " leads?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            End If

            For Each row In dgPickUp.SelectedRows
                For Each item In lvChanges.Items
                    If item.Text = "Affinity" Then
                        conn.recordChange(item.Text, conn.sendReturn("SELECT affinityCode FROM lead_primary WHERE leadID = " & row.Cells("leadID").Value), modExtra.dictAffinities.Item(item.subItems(1).Text), row.Cells("leadID").Value)
                    ElseIf item.Text <> "Comment" Then
                        conn.recordChange(item.Text, conn.sendReturn("SELECT " & item.Text & " FROM lead_primary WHERE leadID = " & row.Cells("leadID").Value), item.subItems(1).Text, row.Cells("leadID").Value)
                    End If
                    If changeLoadedDate Then
                        conn.recordChange("loadedDate", Format(CDate(conn.sendReturn("SELECT loadedDate FROM lead_primary WHERE leadID = " & row.Cells("leadID").Value)), "yyyy-MM-dd HH:mm:ss"), Format(Now(), "yyyy-MM-dd HH:mm:ss"), row.Cells("leadID").Value)
                    End If
                Next item
                If changeString <> "UPDATE lead_primary SET  WHERE leadID = " Then
                    conn.send(changeString & row.Cells("leadID").Value)
                End If

                If comment <> "" Then
                    conn.send("INSERT INTO lead_comments (leadID, user, comment) VALUES ('" & row.Cells("leadID").Value & "', '" & frmSide.lbUser.Text & "', '" & Replace(comment, "'", "''") & "')")
                    comment = ""
                End If
                If specificLeads Then
                    If Application.OpenForms().OfType(Of frmLoadLead).Any Then
                        frmLoadLead.removeAndUpdateDup(row.Cells("leadID").Value)
                    End If
                    dgPickUp.Rows.Remove(row)
                End If
            Next row

            'MsgBox(dgPickUp.SelectedRows.Count & " leads changed. Thank-you.")
            If MsgBox(dgPickUp.SelectedRows.Count & " leads changed. Thank-you." & vbNewLine & "Would you like to clear the contents of changes?", MsgBoxStyle.YesNo, "Clear Contents") = MsgBoxResult.Yes Then
                lvChanges.Items.Clear()
            End If

            If Not specificLeads Then
                refreshLeads()
            End If
        Else
                MsgBox("No changes selected!")
        End If

    End Sub

    Private Sub cbDates_CheckedChanged_1(sender As Object, e As EventArgs) Handles cbDates.CheckedChanged
        If cbDates.CheckState Then
            dtFrom.Enabled = True
            dtTo.Enabled = True
        Else
            dtFrom.Enabled = False
            dtTo.Enabled = False
        End If
    End Sub

    Public Sub loadSpecificLeads(arrLeads As ArrayList)
        btCopyChanges.Visible = True
        Dim selectString As String = "SELECT leadID, loadedDate, CONCAT(firstName, ' ', lastName) AS Name, status, IF(outcome IS NULL, '', outcome) AS outcome, agent, affinityName, contactNumber, emailAddress, source FROM lead_primary" _
                                         & " INNER JOIN affinities ON adminCode = affinityCode WHERE leadID IN ("
        Dim orderString As String = " ORDER BY FIELD(leadID"
        For Each lead In arrLeads
            selectString += "'" & lead & "', "
            orderString += "," & lead
        Next
        selectString = selectString.Substring(0, selectString.Length - 2) & ")" & orderString & ")"

        conn.fillDS(selectString, "leadPicks")

        If conn.ds.Tables("leadPicks").Rows.Count = 0 Then
            notify("No leads found for search criteria.")
        Else
            Me.Show()
            dgPickUp.DataSource = conn.ds.Tables("leadPicks")
            dgPickUp.AutoResizeColumns()
            dgPickUp.AutoResizeRows()
            dgPickUp.Refresh()
            dgPickUp.Focus()
        End If

        specificLeads = True

    End Sub

    Private Sub btHistory_Click(sender As Object, e As EventArgs) Handles btHistory.Click
        If dgPickUp.Rows.Count <> 0 Then
            If dgPickUp.SelectedRows.Count = 1 Then
                frmLeadHistory.loadLeadHist(dgPickUp.SelectedRows(0).Cells("leadID").Value)
            Else
                MsgBox("Please only select 1 lead")
            End If
        Else
            MsgBox("No lead selected")
        End If
    End Sub

    Private Sub btComment_Click(sender As Object, e As EventArgs) Handles btComment.Click
        Dim comment As String = InputBox("Please enter the comment below:", "Add Comment")
        If comment = "" Then
            notify("No comment added")
        ElseIf dgPickUp.Rows.Count <> 0 Then
            If dgPickUp.SelectedRows.Count = 1 Then
                conn.send("INSERT INTO lead_comments (leadID, user, comment) " _
                          & "VALUES(" & dgPickUp.SelectedRows(0).Cells("leadID").Value & ", '" & frmSide.lbUser.Text & "', '" & Replace(comment, "'", "''") & "')")
                notify("Comment added")
            Else
                MsgBox("Please only select 1 lead")
            End If
        Else
            MsgBox("No lead selected")
        End If
    End Sub

    Private Sub btCopyChanges_Click(sender As Object, e As EventArgs) Handles btCopyChanges.Click
        For Each item In lvChanges.Items
            item.Remove()
        Next

        If dgPickUp.SelectedRows.Count <> 1 Then
            MsgBox("Please select only one record to copy.")
            Exit Sub
        End If

        Dim dupID As String = ""
        Dim rowChanges As DataGridViewRow = dgPickUp.SelectedRows(0)
        dupID = rowChanges.Cells("leadID").Value

        If dupID = "" Then
            MsgBox("No DupID to link back.")
            Exit Sub
        End If

        conn.fillDS("SELECT title, firstName, lastName, contactNumber AS contactNum, emailAddress AS Email, Agent, affinityCode, Source FROM lead_primary WHERE leadID = " & dupID, "dupInfo")
        Dim rowChange As DataRow = conn.ds.Tables("dupInfo").Rows(0)
        Dim columns() As String = {"title", "firstName", "lastName", "contactNum", "Email", "Agent", "affinityCode", "Source"}

        If Application.OpenForms().OfType(Of frmLoadLead).Any Then
            For Each rowDup As DataGridViewRow In frmLoadLead.dgDups.Rows
                If rowDup.Cells("dupLeadID").Value = dupID Then
                    For Each column In columns

                        If IsDBNull(rowDup.Cells(column).Value) Then rowDup.Cells(column).Value = ""
                        If IsDBNull(rowChange.Item(column)) Then rowChange.Item(column) = ""

                        If rowDup.Cells(column).Value <> rowChange.Item(column) Then
                            Select Case column
                                Case "Email"
                                    lvChanges.Items.Add(New ListViewItem({"EmailAddress", rowDup.Cells(column).Value}))
                                Case "contactNum"
                                    lvChanges.Items.Add(New ListViewItem({"ContactNumber", rowDup.Cells(column).Value}))
                                Case "firstName", "lastName"
                                    If rowDup.Cells(column).Value <> "" Then
                                        lvChanges.Items.Add(New ListViewItem({column, rowDup.Cells(column).Value}))
                                    End If
                                Case Else
                                    lvChanges.Items.Add(New ListViewItem({column, rowDup.Cells(column).Value}))
                            End Select
                        End If

                    Next column
                    If rowDup.Cells("Comment").Value <> "" Then
                        lvChanges.Items.Add(New ListViewItem({"Comment", rowDup.Cells("Comment").Value}))
                    End If
                    lvChanges.Items.Add(New ListViewItem({"Status", "Allocated"}))

                End If
            Next rowDup
        End If

    End Sub
End Class