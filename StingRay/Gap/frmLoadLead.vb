Imports System.ComponentModel
Imports Microsoft.Office.Interop

Public Class frmLoadLead
    Dim xlApp As Excel.Application
    Dim xlWB As Excel.Workbook
    Dim xlWS As Excel.Worksheet
    Dim dtDups As New DataTable


    Private Sub frmLoadLead_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain

        cbSource.DataSource = sourcesArray

        If cbOrder.Text = "" Then cbOrder.Text = "affinityName"

        tabControl.TabPages(1).Enabled = False
        If frmSide.lbType.Text.Contains("Admin") Then

            btAddToBatch.Visible = True
            lbCampaign.Visible = True
            txCampaign.Visible = True

            cbAgent.DisplayMember = "Key"
            cbAgent.ValueMember = "Value"
            cbAgent.DataSource = New BindingSource(modExtra.dictAgents, Nothing)

            Dim dgComboSource As DataGridViewComboBoxColumn = dgLeadsToUpload.Columns("Source")
            'dgComboSource.Name = "Source"
            'dgComboSource.HeaderText = "Source"
            For Each source As String In sourcesArray
                dgComboSource.Items.Add(source)
            Next
            'dgLeadsToUpload.Columns.Add(dgComboSource)
            'dgLeadsToUpload.Columns.Insert(9, dgComboSource)

            Dim agentColumn As DataGridViewComboBoxColumn = dgLeadsToUpload.Columns("Agent")
            For Each key In dictAgents.Keys
                agentColumn.Items.Add(key.ToString)
            Next
            agentColumn.Items.Add("")

            tabControl.SelectedTab = tbBatch
            conn.fillDS("SELECT agent, SUM(IF(status = 'Busy', 1, 0)) AS 'Busy', SUM(IF(status = 'Allocated', 1, 0)) AS Allocated, 0 AS inBatch " _
                        & "FROM lead_primary INNER JOIN sys_users ON agent = userName " _
                        & "WHERE active = 1 AND type = 'Agent' AND status IN ('Allocated', 'Busy') GROUP BY agent", "agentOutstanding")
            dgAgents.DataSource = conn.ds.Tables("agentOutstanding")
            dgAgents.AutoResizeColumns()

            Dim conAPI As New clConn("Dedi")
            If conAPI.conSQL.State = ConnectionState.Open Then
                tbAPI.Text = "API (" & apiCount() & ")"
            Else
                MsgBox("Cannot connect to API right now.")
            End If

        Else
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            cbAgent.Items.Add(frmSide.lbUser.Text)
            cbAgent.SelectedIndex = 0
            cbAgent.Enabled = False
            rbZwinger.Checked = True
            'rbAffinity.Enabled = False
        End If

        Dim mtbs As New List(Of MaskedTextBox) From {txContactNum, txIdNum}
        For Each mtb In mtbs
            AddHandler mtb.MouseClick, AddressOf mtb_MouseClick
        Next mtb

        txNameSearch.Focus()

    End Sub

    Private Sub btSearch_Click(sender As Object, e As EventArgs) Handles btSearch.Click
        searchProviders()
    End Sub

    Private Sub searchProviders()
        Dim selectString As String = "SELECT adminCode, affinityName, type, contactNum, emailAdd FROM affinities"
        Dim whereString As String = " WHERE affinity = '" & CInt(rbAffinity.Checked) * -1 & "'"
        Dim orderString As String = " ORDER BY " & cbOrder.Text & " ASC"

        'Field Searches
        Dim searchFields As New List(Of WaterMarkTextBox) From {txNameSearch, txContactNumSearch, txIdNumSearch, txEmailAddSearch}
        For Each field In searchFields
            If field.Text <> "" Then whereString = whereString & " AND " & field.Tag & " LIKE '%" & Replace(field.Text, "'", "''") & "%'"
        Next field

        conn.fillDS(selectString & whereString & orderString, "sourcePicks")


        If conn.ds.Tables("sourcePicks").Rows.Count = 0 Then
            notify("No afinities found for search criteria.")
        End If
        dgSelectSource.DataSource = conn.ds.Tables("sourcePicks")
        dgSelectSource.AutoResizeColumns()
        dgSelectSource.AutoResizeRows()
        dgSelectSource.Refresh()
        dgSelectSource.Focus()

    End Sub

#Region "Single Upload"

    Private Sub txNameSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txNameSearch.KeyPress
        If Asc(e.KeyChar) = 13 Then searchProviders()
    End Sub

    Private Sub txContactNumSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txContactNumSearch.KeyPress
        If Asc(e.KeyChar) = 13 Then searchProviders()
    End Sub

    Private Sub txIdNumSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txIdNumSearch.KeyPress
        If Asc(e.KeyChar) = 13 Then searchProviders()
    End Sub

    Private Sub txEmailAddSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txEmailAddSearch.KeyPress
        If Asc(e.KeyChar) = 13 Then searchProviders()
    End Sub

    Private Sub dgPickUp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgSelectSource.KeyDown
        If e.KeyCode = Keys.Enter Then
            If conn.ds.Tables("sourcePicks").Rows.Count <> 0 Then
                lbAffinityCode.Text = dgSelectSource.Item("adminCode", dgSelectSource.CurrentRow.Index).Value.ToString()
                lbAffinityName.Text = dgSelectSource.Item("affinityName", dgSelectSource.CurrentRow.Index).Value.ToString()
                Dim defaultSource As String = conn.sendReturn("SELECT defaultSource FROM affinities WHERE adminCode = '" & lbAffinityCode.Text & "'")
                If defaultSource <> "NULL" Then
                    If cbSource.Items.Contains(defaultSource) Then cbSource.Text = defaultSource
                End If

                tabControl.TabPages(1).Enabled = True
                    tabControl.SelectedTab = tabDetails
                End If
            End If
    End Sub

    Private Sub dgPickUp_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgSelectSource.MouseDoubleClick
        If conn.ds.Tables("sourcePicks").Rows.Count <> 0 Then
            lbAffinityCode.Text = dgSelectSource.Item("adminCode", dgSelectSource.CurrentRow.Index).Value.ToString()
            lbAffinityName.Text = dgSelectSource.Item("affinityName", dgSelectSource.CurrentRow.Index).Value.ToString()

            Dim defaultSource As String = conn.sendReturn("SELECT defaultSource FROM affinities WHERE adminCode = '" & lbAffinityCode.Text & "'")
            If defaultSource <> "NULL" Then
                If cbSource.Items.Contains(defaultSource) Then cbSource.Text = defaultSource
            End If

            tabControl.TabPages(1).Enabled = True
            tabControl.SelectedTab = tabDetails
        End If
    End Sub

    Private Sub btLoad_Click(sender As Object, e As EventArgs) Handles btLoad.Click

        Dim needed As String = ""
        Dim warning As String = ""
        Dim controls As New List(Of Control) From {txFirstName, txLastName, txContactNum, txIdNum, txEmailAdd, cbSource, cbAgent}
        For Each control In controls
            Select Case control.Name
                Case "cbTitle", "txFirstName", "txLastName", "cbAgent"
                    If control.Text = "" Then
                        If needed <> "" Then
                            needed = needed & vbNewLine & Replace(Replace(control.Name, "cb", ""), "tx", "")
                        Else
                            needed = "Please complete the following:" & vbNewLine & Replace(Replace(control.Name, "cb", ""), "tx", "")
                        End If
                    End If
                Case "cbSource"
                    If control.Text = "" Then
                        warning = addToWarning(warning, control)
                    End If
                Case "txContactNum"
                    Dim maskedText As MaskedTextBox = control
                    maskedText.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
                    If maskedText.Text = "" Then
                        warning = addToWarning(warning, control)
                    Else
                        Dim valid As String = validateContactNumber(control.Text)
                        If valid <> "Pass" Then
                            MsgBox(valid)
                            control.Focus()
                            Exit Sub
                        Else
                            Dim dupID As String = conn.sendReturn("SELECT leadID FROM lead_primary WHERE RIGHT(contactNumber, 9) = '" & txContactNum.Text.Substring(txContactNum.Text.Length - 9) & "'")
                            If dupID <> "NULL" Then
                                dupMsg(CInt(dupID), "contact number")
                                Exit Sub
                            End If
                        End If
                    End If
                    maskedText.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
                Case "txIdNum"
                    Dim maskedText As MaskedTextBox = control
                    maskedText.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
                    If maskedText.Text = "" Then
                        warning = addToWarning(warning, control)
                    Else
                        Dim valid As String = validateIdNumber(control.Text)
                        If valid <> "Pass" Then
                            MsgBox(valid)
                            control.Focus()
                            Exit Sub
                        Else
                            Dim dupID As String = conn.sendReturn("SELECT leadID FROM lead_primary WHERE idNumber = '" & control.Text & "'")
                            If dupID <> "NULL" Then
                                dupMsg(CInt(dupID), "ID Number")
                                Exit Sub
                            End If
                        End If
                    End If
                    maskedText.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
                Case "txEmailAdd"
                    If control.Text = "" Then
                        warning = addToWarning(warning, control)
                    Else
                        If modValidate.validateEmail(control.Text) Then
                            Dim dupID As String = conn.sendReturn("SELECT leadID FROM lead_primary WHERE emailAddress = '" & control.Text & "'")
                            If dupID <> "NULL" Then
                                dupMsg(CInt(dupID), "email address")
                                Exit Sub
                            End If
                        Else
                            MsgBox("Not a valid email. Please check.")
                            Exit Sub
                        End If
                    End If
            End Select
        Next control

        If needed <> "" Then
            MsgBox(needed)
        ElseIf warning <> "" Then
            If MsgBox(warning, MsgBoxStyle.YesNo, "Continue?") = MsgBoxResult.Yes Then
                loadLead()
            End If
        Else
            loadLead()
        End If
    End Sub

    Private Sub loadLead()
        Dim maskedText As MaskedTextBox = Nothing
        Dim insertColumns As String = "status, affinityCode, loadedBy"
        Dim insertValues As String = "'Allocated', '" & lbAffinityCode.Text & "', '" & frmSide.lbUser.Text & "'"

        Dim controls As New List(Of Control) From {cbTitle, txFirstName, txLastName, txContactNum, txIdNum, txEmailAdd, cbSource, cbAgent}

        For Each control In controls
            If TypeOf control Is MaskedTextBox Then
                maskedText = control
                maskedText.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
            End If

            Select Case control.Name
                Case "txFirstName", "txLastName", "cbSource", "cbAgent"
                    If Replace(Replace(Replace(Replace(control.Text, " ", ""), "(", ""), ")", ""), "-", "") <> "" Then
                        insertColumns = insertColumns & ", " & control.Tag
                        insertValues = insertValues & ", '" & Trim(control.Text) & "'"
                    End If
                Case Else
                    If Replace(Replace(Replace(Replace(control.Text, " ", ""), "(", ""), ")", ""), "-", "") <> "" Then
                        insertColumns = insertColumns & ", " & control.Tag
                        insertValues = insertValues & ", '" & Replace(Replace(Replace(Replace(control.Text, " ", ""), "(", ""), ")", ""), "-", "") & "'"
                    End If
            End Select
            If TypeOf control Is MaskedTextBox Then maskedText.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
        Next control


        Dim leadID As Integer = conn.sendReturn("INSERT INTO lead_primary (" & insertColumns & ")  VALUES (" & insertValues & "); SELECT LAST_INSERT_ID();")
        If txComment.Text <> "" Then conn.send("INSERT INTO lead_comments (leadID, user, comment) VALUES (" & leadID & ", '" & frmSide.lbUser.Text & "', '" & Replace(txComment.Text, "'", "''") & "')")
        conn.recordEvent("Lead Loaded", , leadID)
        If frmSide.lbUser.Text = cbAgent.Text Then
            If MsgBox("Lead " & leadID & " loaded. Pick-up now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                frmLeadView.loadLead(leadID)
            ElseIf MsgBox("Load another with same affinity?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                clearFields()
            Else
                Me.Close()
            End If
        ElseIf MsgBox("Lead " & leadID & " loaded. Load another with same affinity?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            clearFields()
        Else
            Me.Close()
        End If

    End Sub

    Public Function addToWarning(warning As String, controlText As Control) As String
        If warning <> "" Then
            Return warning & vbNewLine & Replace(Replace(controlText.Name, "cb", ""), "tx", "")
        Else
            Return "Are you sure you don't want to fill out the following:" & vbNewLine & Replace(Replace(controlText.Name, "cb", ""), "tx", "")
        End If
    End Function

    Public Sub clearFields()

        cbTitle.SelectedIndex = -1
        'cbSource.SelectedIndex = -1

        Dim textControls As New List(Of Control) From {txFirstName, txLastName, txContactNum, txIdNum, txEmailAdd, txComment}
        For Each control In textControls
            control.Text = ""
        Next control
    End Sub

#End Region

    Private Sub btExample_Click(sender As Object, e As EventArgs) Handles btExample.Click
        IO.File.Copy(systemFolder & "SystemMaterial\LeadLoadExample.xlsx", IO.Path.GetTempPath & "LeadLoadExample.xlsx", True)
        xlApp = CreateObject("Excel.Application")
        xlWB = xlApp.Workbooks.Add(IO.Path.GetTempPath & "LeadLoadExample.xlsx")
        xlWS = xlWB.Sheets(1)
        xlApp.ActiveWindow.WindowState = Excel.XlWindowState.xlMaximized
        xlWB.RefreshAll()
        xlApp.Visible = True
        releaseObject(xlWS)
        releaseObject(xlWB)
        releaseObject(xlApp)
    End Sub

#Region "Excel to Batch"
    'Private Sub btOpenFile_Click(sender As Object, e As EventArgs)
    '    If MsgBox("Are you sure you do not want these to be loaded to the new leads table?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '            xlApp = CreateObject("Excel.Application")
    '            xlWB = xlApp.Workbooks.Open(OpenFileDialog1.FileName)
    '            xlWS = xlWB.Sheets(1)

    '            Dim dictColumns As New Dictionary(Of Integer, String)
    '            dictColumns.Add(1, "Title")
    '            dictColumns.Add(2, "First Name")
    '            dictColumns.Add(3, "Last Name")
    '            dictColumns.Add(4, "Contact Number")
    '            dictColumns.Add(5, "Email")
    '            dictColumns.Add(6, "Agent")
    '            dictColumns.Add(7, "AffinityName")
    '            dictColumns.Add(8, "Comment")
    '            dictColumns.Add(9, "Source")
    '            dictColumns.Add(10, "AffinityCode")
    '            dictColumns.Add(11, "AffinityID")

    '            For i = 1 To 10
    '                If xlWS.Cells(1, i).Value() <> dictColumns.Item(i) Then
    '                    fixIssue("Column " & i & " should read """ & dictColumns.Item(i) & """ and not """ & xlWS.Cells(1, i).Value() & """. Please fix.", 1, i)
    '                    Exit Sub
    '                End If
    '            Next

    '            Dim lastrow As Integer
    '            lastrow = xlWS.Cells(xlWS.Rows.Count, "J").End(Excel.XlDirection.xlUp).Row

    '            For i = 2 To lastrow
    '                'Source Check
    '                If Not sourcesArray.Contains(xlWS.Cells(i, "I").Value) Then
    '                    fixIssue("Source in row " & i & " is not valid. please check.", i, 10)
    '                    Exit Sub
    '                End If

    '                If dictAffinities.ContainsValue(xlWS.Cells(i, "J").Value) Then
    '                    Dim pair As KeyValuePair(Of String, String)
    '                    Dim affName As String = ""
    '                    For Each pair In dictAffinities
    '                        If CStr(pair.Value) = CStr(xlWS.Cells(i, "J").Value) Then
    '                            affName = pair.Key
    '                        End If
    '                    Next
    '                    dgLeadsToUpload.Rows.Add(New String() {xlWS.Cells(i, "A").Value _
    '                                                      , xlWS.Cells(i, "B").Value _
    '                                                      , xlWS.Cells(i, "C").Value _
    '                                                      , xlWS.Cells(i, "D").Value _
    '                                                      , xlWS.Cells(i, "E").Value _
    '                                                      , xlWS.Cells(i, "F").Value _
    '                                                      , affName _
    '                                                      , xlWS.Cells(i, "H").Value _
    '                                                      , xlWS.Cells(i, "I").Value _
    '                                                      , xlWS.Cells(i, "J").Value _
    '                                                      , xlWS.Cells(i, "K").Value})
    '                Else
    '                    dgLeadsToUpload.Rows.Add(New String() {xlWS.Cells(i, "A").Value _
    '                                                      , xlWS.Cells(i, "B").Value _
    '                                                      , xlWS.Cells(i, "C").Value _
    '                                                      , xlWS.Cells(i, "D").Value _
    '                                                      , xlWS.Cells(i, "E").Value _
    '                                                      , xlWS.Cells(i, "F").Value _
    '                                                      , "Aff Name not found" _
    '                                                      , xlWS.Cells(i, "H").Value _
    '                                                      , xlWS.Cells(i, "I").Value _
    '                                                      , xlWS.Cells(i, "J").Value _
    '                                                      , xlWS.Cells(i, "K").Value _
    '                                                      , "" _
    '                                                      , ""})
    '                End If

    '            Next

    '            dgLeadsToUpload.AutoResizeColumns()

    '            xlWB.Saved = True
    '            xlWB.Close()
    '            releaseObject(xlWS)
    '            releaseObject(xlWB)
    '            releaseObject(xlApp)

    '            btUpload.Enabled = False
    '            dgLeadsToUpload.Enabled = True
    '            btValidate.Text = "Validate"
    '            recalcAgentAllocated()
    '        End If
    '    End If

    'End Sub
#End Region

    Sub fixIssue(msg As String, r As Integer, c As Integer)
        MsgBox(msg)
        xlApp.Visible = True
        xlWS.Cells(r, c).select()
        releaseObject(xlWS)
        releaseObject(xlWB)
        releaseObject(xlApp)
        dgLeadsToUpload.Rows.Clear()
    End Sub

    Private Sub btValidate_Click(sender As Object, e As EventArgs) Handles btValidate.Click
        cmsDgRight.Enabled = True
        Dim dupsFound As Integer = 0
        Dim contactNum As String
        Dim dupLeads As New ArrayList
        Dim dictContact As New Dictionary(Of String, Integer)
        Dim dictEmail As New Dictionary(Of String, Integer)

        If btValidate.Text = "Validate" Then
            With dgLeadsToUpload

                'Validation
                For i = 0 To .Rows.Count - 1

                    If (.Rows(i).Cells("Agent").Value = Nothing) Or (.Rows(i).Cells("Agent").Value = "") Then
                        MsgBox("Please enter an agent at row " & i)
                        .Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                        Exit Sub
                    Else
                        If Not dictAgents.ContainsKey(.Rows(i).Cells("Agent").Value) Then
                            MsgBox("Can't find agent in active agents for row " & i)
                            .Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                            Exit Sub
                        End If
                    End If

                    If (.Rows(i).Cells("affinityCode").Value = Nothing) Or (.Rows(i).Cells("affinityCode").Value = "") Then
                        MsgBox("Please enter an affinity at row " & i)
                        .Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                        Exit Sub
                    Else
                        If Not dictAffinities.ContainsValue(.Rows(i).Cells("affinityCode").Value) Then
                            If conn.sendReturn("SELECT adminCode from affinities WHERE adminCode = '" & .Rows(i).Cells("affinityCode").Value & "'") = "NULL" Then
                                MsgBox("Can't find affinity/referal in affinities for row " & i & ". Check code.")
                                .Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                                Exit Sub
                            End If
                        End If
                    End If

                    'Contact Number validate and batch de-dup
                    contactNum = .Rows(i).Cells("contactNum").Value
                    If contactNum <> "" And contactNum <> "0" Then
                        If validateContactNumber(contactNum) <> "Pass" Then
                            MsgBox("Contact Number not valid in row " & i)
                            .Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                            Exit Sub
                        ElseIf contactNum.Length > 11 Then
                            MsgBox("Contact Number greater than 11 characters in highlighted row " & i)
                            .Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                            Exit Sub
                        End If

                        If dictContact.ContainsKey(.Rows(i).Cells("contactNum").Value) Then
                            MsgBox("Duplicate contact num in grid for below highlighted rows" & vbNewLine _
                                       & contactNum & " at row " & dictContact.Item(contactNum.ToString) & vbNewLine _
                                       & contactNum & " at row " & i & vbNewLine & vbNewLine & "Please fix.")
                            .Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                            .Rows(dictContact.Item(contactNum.ToString)).DefaultCellStyle.BackColor = Color.LightPink
                            Exit Sub
                        Else
                            dictContact.Add(contactNum, i)
                        End If
                    End If

                    'Email validate and batch de-dup
                    If .Rows(i).Cells("email").Value <> "" Then
                        If Not validateEmail(.Rows(i).Cells("email").Value) Then
                            MsgBox("Email not valid in row " & i + 1)
                            .Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                            Exit Sub
                        End If

                        If dictEmail.ContainsKey(.Rows(i).Cells("email").Value) Then
                            MsgBox("Duplicate email in grid for below rows" & vbNewLine _
                                       & .Rows(i).Cells("email").Value & " at row " & dictEmail.Item(.Rows(i).Cells("email").Value) & vbNewLine _
                                       & .Rows(i).Cells("email").Value & " at row " & i & vbNewLine & vbNewLine & "Please fix.")
                            .Rows(i).DefaultCellStyle.BackColor = Color.LightPink
                            .Rows(dictEmail.Item(.Rows(i).Cells("email").Value)).DefaultCellStyle.BackColor = Color.LightPink
                            Exit Sub
                        Else
                            dictEmail.Add(.Rows(i).Cells("email").Value, i)
                        End If
                    End If
                    .Rows(i).DefaultCellStyle.BackColor = Color.White
                Next i

                'De-Dup
                For i = 0 To .Rows.Count - 1
                    If i <= dgLeadsToUpload.Rows.Count - 1 Then
                        contactNum = .Rows(i).Cells("contactNum").Value
                        If contactNum <> "" And contactNum <> "0" Then

                            Dim dupID As String = conn.sendReturn("SELECT leadID FROM lead_primary WHERE RIGHT(contactNumber, 9) = '" & contactNum.Substring(contactNum.Length - 9) & "'")
                            If dupID <> "NULL" Then
                                dgLeadsToUpload.Rows(i).Cells("dupLeadID").Value = dupID
                                insertDup(i)
                                dupLeads.Add(CInt(dupID))
                                dgLeadsToUpload.Rows.Remove(.Rows(i))
                                dupsFound += 1
                                i -= 1
                                Continue For
                            End If
                        End If

                        If .Rows(i).Cells("email").Value <> "" Then
                            Dim dupID As String = conn.sendReturn("SELECT leadID FROM lead_primary WHERE emailAddress = '" & .Rows(i).Cells("email").Value & "'")
                            If dupID <> "NULL" Then
                                dgLeadsToUpload.Rows(i).Cells("dupLeadID").Value = dupID
                                insertDup(i)
                                dupLeads.Add(CInt(dupID))
                                dgLeadsToUpload.Rows.Remove(.Rows(i))
                                dupsFound += 1
                                i -= 1
                                Continue For
                            End If
                        End If
                    End If
                Next i
            End With


            If dupsFound <> 0 Then
                MsgBox(dupsFound & " duplicate(s) found and removed. Please check dup tab!", MsgBoxStyle.Critical, "Dup(s) Found!")
                frmLeadChange.loadSpecificLeads(dupLeads)
                dgDups.AutoResizeColumns()

                'Resize forms
                If ((frmMain.Width - (Me.Width + frmLeadChange.Width)) / 2) > frmSide.Width + 20 Then
                    Me.Location = New Point(((frmMain.Width - (Me.Width + frmLeadChange.Width)) / 2), (frmMain.Height / 2) - (Me.Height / 2) - 20)
                Else
                    'Me.Location = New Point(frmSide.Width + 20, (frmMain.Height / 2) - (Me.Height / 2) - 20)
                    Me.Location = New Point(10, (frmMain.Height / 2) - (Me.Height / 2) - 20)
                End If

                frmLeadChange.Location = New Point(Me.Location.X + Me.Width + 5, (frmMain.Height / 2) - (Me.Height / 2) - 20)

            End If

            cmsDgRight.Enabled = False
            btUpload.Enabled = True
            dgLeadsToUpload.Enabled = False
            btValidate.Text = "Enable Editing"


        ElseIf btValidate.Text = "Enable Editing" Then
            cmsDgRight.Enabled = True
            btUpload.Enabled = False
            dgLeadsToUpload.Enabled = True
            btValidate.Text = "Validate"
        End If

    End Sub

    Private Sub btUpload_Click(sender As Object, e As EventArgs) Handles btUpload.Click

        If MsgBox("Are you sure you want to upload these leads?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim contactNumberUpload As String = ""
            Dim leadID As Integer = 0
            For Each row As DataGridViewRow In dgLeadsToUpload.Rows

                'If row.Index <> dgLeadsToUpload.Rows.Count Then

                If Not IsDBNull(row.Cells("contactNum").Value) Then
                        If (Not IsNothing(row.Cells("contactNum").Value)) And (row.Cells("contactNum").Value <> "") Then
                            If (row.Cells("contactNum").Value.ToString.Substring(0, 2) = "27") And row.Cells("contactNum").Value.ToString.Length = 11 Then
                                contactNumberUpload = "'0" & row.Cells("contactNum").Value.Substring(2, 9) & "'"
                            Else
                                contactNumberUpload = "'" & row.Cells("contactNum").Value.ToString() & "'"
                            End If
                        Else
                            contactNumberUpload = "NULL"
                        End If
                    Else
                        contactNumberUpload = "NULL"
                    End If

                    Dim titleUpload As String = If(row.Cells("title").Value = "", "NULL", "'" & row.Cells("title").Value & "'")
                Dim firstnameUpload As String = If(row.Cells("firstName").Value = "", "NULL", "'" & Replace(row.Cells("firstName").Value, "'", "") & "'")
                Dim lastNameUpload As String = If(row.Cells("lastName").Value = "", "NULL", "'" & Replace(row.Cells("lastName").Value, "'", "''") & "'")
                Dim emailUpload As String = If(row.Cells("Email").Value = "", "NULL", "'" & row.Cells("Email").Value & "'")

                leadID = CInt(conn.sendReturn("INSERT INTO lead_primary(agent, status, affinityCode, title, firstName, lastName, contactNumber, emailAddress, source, loadedBy) " _
                              & "VALUES('" & row.Cells("Agent").Value & "', 'Allocated', '" & row.Cells("affinityCode").Value & "', " _
                              & titleUpload & ", " & firstnameUpload & ", " & lastNameUpload & ", " & contactNumberUpload & ", " & emailUpload & ", '" & row.Cells("source").Value & "', " _
                              & "'" & frmSide.lbUser.Text & "'); SELECT LAST_INSERT_ID();"))
                    If row.Cells("affinityID").Value <> "" And row.Cells("leadNewID").Value = "" Then
                        conn.send("INSERT INTO lead_new (title, firstName, lastName, contactNumber, emailAdd, comment, supplier, supplierID, source, zestLeadID, actionTaken) " _
                                & "VALUES (" & titleUpload & ", " & firstnameUpload & ", " & lastNameUpload & ", " & contactNumberUpload & ", " & emailUpload _
                                & ", '" & Replace(row.Cells("comment").Value, "'", "''") & "', '" & row.Cells("affinityCode").Value & "', '" & row.Cells("affinityID").Value & "', '" & row.Cells("source").Value & "', " & leadID & ", 'Allocated')")
                    ElseIf row.Cells("leadNewID").Value <> "" Then
                        conn.send("UPDATE lead_new SET actionTaken = 'Allocated', zestLeadID = " & leadID & " WHERE id = " & row.Cells("leadNewID").Value)
                    End If

                    If row.Cells("comment").Value <> "" Then
                        conn.send("INSERT INTO lead_comments (leadID, user, comment) " _
                                  & "VALUES(" & leadID & ", '" & frmSide.lbUser.Text & "', '" & Replace(row.Cells("comment").Value, "'", "''") & "')")
                    End If

                'End If
            Next row
            notify("Leads uploaded.")
            dgLeadsToUpload.Rows.Clear()
            'Me.Close()
        End If
    End Sub

    Public Sub insertDup(dataGridIndex As Integer)

        'conn.fillDS("SELECT leadID, firstName, lastName, contactNumber, emailAddress, loadedDate, status, outcome FROM lead_primary WHERE leadID = " & leadID, "leadInfo")
        If dgDups.Columns.Count = 0 Then
            For Each column As DataGridViewColumn In dgLeadsToUpload.Columns
                dgDups.Columns.Add(CType(column.Clone(), DataGridViewColumn))
            Next
            'Dim dupCol As New DataGridViewTextBoxColumn
            'dupCol.HeaderText = "zestDupLeadID"
            'dupCol.Name = "zestDupLeadID"
            ''dupCol.Visible = False

            'dgDups.Columns.Add(dupCol)
            ''dgDups.Columns.Add("zestDupLeadID", "zestDupLeadID")
        End If

        Dim targetRow = CType(dgLeadsToUpload.Rows(dataGridIndex).Clone(), DataGridViewRow)
        For Each cell As DataGridViewCell In dgLeadsToUpload.Rows(dataGridIndex).Cells
            targetRow.Cells(cell.ColumnIndex).Value = cell.Value
        Next

        dgDups.Rows.Add(targetRow)
    End Sub

    Private Sub frmLoadLead_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If frmSide.lbType.Text = "Agent" Then
            tabControl.TabPages.Remove(tabControl.TabPages(2))
            tabControl.TabPages.Remove(tabControl.TabPages(2))
            tabControl.TabPages.Remove(tabControl.TabPages(2))
        End If
    End Sub

    Private Sub btConfirmDups_Click(sender As Object, e As EventArgs) Handles btConfirmDups.Click
        If MsgBox("Are you sure you want to mark all below as duplicates?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            For Each row As DataGridViewRow In dgDups.Rows
                If row.Cells("affinityID").Value <> "" And row.Cells("leadNewID").Value = "" Then
                    Dim titleUpload As String = If(row.Cells("title").Value = "", "NULL", "'" & row.Cells("title").Value & "'")
                    Dim firstnameUpload As String = If(row.Cells("firstName").Value = "", "NULL", "'" & row.Cells("firstName").Value & "'")
                    Dim lastNameUpload As String = If(row.Cells("lastName").Value = "", "NULL", "'" & row.Cells("lastName").Value & "'")
                    Dim emailUpload As String = If(row.Cells("firstName").Value = "", "NULL", "'" & row.Cells("firstName").Value & "'")

                    Dim contactNumberUpload As String = ""
                    If Not IsDBNull(row.Cells("contactNum").Value) Then
                        If Not IsNothing(row.Cells("contactNum").Value) Then
                            If (row.Cells("contactNum").Value.ToString.Substring(0, 2) = "27") And row.Cells("contactNum").Value.ToString.Length = 11 Then
                                contactNumberUpload = "'0" & row.Cells("contactNum").Value.Substring(2, 9) & "'"
                            Else
                                contactNumberUpload = "'" & row.Cells("contactNum").Value.ToString() & "'"
                            End If
                        Else
                            contactNumberUpload = "NULL"
                        End If
                    Else
                        contactNumberUpload = "NULL"
                    End If

                    conn.send("INSERT INTO lead_new (title, firstName, lastName, contactNumber, emailAdd, comment, supplier, supplierID, source, zestLeadID, actionTaken) " _
                                & "VALUES (" & titleUpload & ", " & firstnameUpload & ", " & lastNameUpload & ", " & contactNumberUpload & ", " & emailUpload _
                                & ", '" & Replace(row.Cells("comment").Value, "'", "''") & "', '" & row.Cells("affinityCode").Value & "', '" & row.Cells("affinityID").Value & "', '" & row.Cells("source").Value & "', " & row.Cells("dupLeadID").Value & ", 'Duplicate')")

                ElseIf row.Cells("leadNewID").Value <> "" Then
                    conn.send("UPDATE lead_new SET actionTaken = 'Duplicate', zestLeadID = " & row.Cells("dupLeadID").Value & " WHERE id = " & row.Cells("leadNewID").Value)
                End If
                'dgDups.Rows.Remove(row)
            Next
            dgDups.Rows.Clear()
        End If
    End Sub

    Sub dupMsg(leadID As Integer, reason As String)
        If frmSide.lbType.Text.Contains("Admin") Then
            If MsgBox("Dup lead - " & leadID & " - exists for " & reason & ". Show in lead change form?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                Dim leads As New ArrayList
                leads.Add(leadID)
                frmLeadChange.loadSpecificLeads(leads)
            End If
        Else
            MsgBox("Dup lead - " & leadID & " - exists for " & reason & ". Please contact lead admin.")
        End If
    End Sub

    Private Sub mtb_MouseClick(sender As Object, e As MouseEventArgs)
        sender.Select(sender.MaskedTextProvider.LastAssignedPosition + 1, 0)
    End Sub

    Private Sub frmLoadLead_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If dgLeadsToUpload.Rows.Count > 1 Then
            If MsgBox("There are still leads in the batch tab. Are you sure you want to close?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Public Function apiCount() As Integer
        Dim conAPI As New clConn("Dedi")
        Dim apiLeads As Object = conAPI.sendReturn("SELECT COUNT(id) FROM lead_new WHERE zestLeadNewID IS NULL AND supplierID <> '123456'")
        If apiLeads <> "NULL" Then
            Return CInt(apiLeads)
        Else
            Return 0
        End If
    End Function

    Private Sub btApiCopy_Click(sender As Object, e As EventArgs) Handles btApiCopy.Click
        Dim conAPI As New clConn("Dedi")
        If conAPI.conSQL.State = ConnectionState.Closed Then
            MsgBox("Cannot connect to API right now.")
            Exit Sub
        End If
        Dim contactNumberAPI As String = ""
        Dim email As String = ""
        Dim source As String = ""
        Dim comment As String = ""
        Dim newID As Integer
        conAPI.fillDS("SELECT id, title, firstName, lastName, contactNumber, emailAdd, comment, source, adminCode, supplierID, supplierCampaign FROM lead_new WHERE zestLeadNewID IS NULL AND supplierID <> '123456'", "apiLeads")
        For Each apiRow As DataRow In conAPI.ds.Tables("apiLeads").Rows
            If Not IsDBNull(apiRow.Item("contactNumber")) Then
                If (apiRow.Item("contactNumber").ToString.Substring(0, 2) = "27") And apiRow.Item("contactNumber").ToString.Length = 11 Then
                    contactNumberAPI = "0" & apiRow.Item("contactNumber").Substring(2, 9)
                Else
                    contactNumberAPI = apiRow.Item("contactNumber").ToString()
                End If
            Else
                contactNumberAPI = ""
            End If

            If IsDBNull(apiRow.Item("emailAdd")) Then
                email = ""
            Else
                If apiRow.Item("emailAdd") = "email@test.com" Then
                    email = ""
                Else
                    email = apiRow.Item("emailAdd")
                End If
            End If

            If IsDBNull(apiRow.Item("comment")) Then
                comment = ""
            Else
                If apiRow.Item("comment") = "None" Or apiRow.Item("comment") = "3WayMarketing" Then
                    comment = ""
                Else
                    comment = apiRow.Item("comment")
                End If
            End If

            If email.Length >= 12 Then
                If email.Substring(email.Length - 12) = "@noemail.com" Then
                    email = ""
                End If
            End If


            If Not sourcesArray.Contains(apiRow.Item("source")) Then
                source = conn.sendReturn("SELECT defaultSource FROM affinities WHERE adminCode = '" & apiRow.Item("adminCode") & "'")
            Else
                source = apiRow.Item("source")
            End If

            newID = conn.sendReturn("INSERT INTO lead_new (title, firstName, lastName, contactNumber, emailAdd, comment, supplier, supplierID, supplierCampaign, source, loadedFrom) " _
                                    & "VALUES ('" & apiRow.Item("title") & "', '" & Replace(apiRow.Item("firstName"), "'", "''") & "', '" & Replace(apiRow.Item("lastName"), "'", "''") & "', '" & contactNumberAPI & "', '" _
                                    & email & "', '" & comment & "', '" & apiRow.Item("adminCode") & "', '" & apiRow.Item("supplierID") & "', '" & apiRow.Item("supplierCampaign") & "', '" & source & "', 'API'); SELECT LAST_INSERT_ID();")
            If CStr(newID) <> "NULL" Then
                conAPI.send("UPDATE lead_new SET zestLeadNewID = '" & newID & "' WHERE id = " & apiRow.Item("id"))
            End If
        Next apiRow

        refreshLeadsNew()

    End Sub

    Private Sub btCopy_Click(sender As Object, e As EventArgs) Handles btCopy.Click
        If dgAPI.Rows.Count <> 0 Then
            If rbCopyAll.Checked Then
                For Each row As DataGridViewRow In dgAPI.Rows

                    dgLeadsToUpload.Rows.Add(New String() {row.Cells("title").Value _
                                                          , row.Cells("firstName").Value _
                                                          , row.Cells("lastName").Value _
                                                          , Trim(row.Cells("contactNumber").Value) _
                                                          , Trim(row.Cells("emailAdd").Value) _
                                                          , "" _
                                                          , row.Cells("affinityName").Value _
                                                          , row.Cells("comment").Value _
                                                          , row.Cells("source").Value _
                                                          , row.Cells("supplier").Value _
                                                          , row.Cells("supplierID").Value _
                                                          , row.Cells("id").Value _
                                                          , ""})
                Next
            ElseIf rbCopySelected.Checked Then
                For Each row As DataGridViewRow In dgAPI.Rows
                    If row.Selected Then
                        dgLeadsToUpload.Rows.Add(New String() {row.Cells("title").Value _
                                                          , row.Cells("firstName").Value _
                                                          , row.Cells("lastName").Value _
                                                          , Trim(row.Cells("contactNumber").Value) _
                                                          , Trim(row.Cells("emailAdd").Value) _
                                                          , "" _
                                                          , row.Cells("affinityName").Value _
                                                          , row.Cells("comment").Value _
                                                          , row.Cells("source").Value _
                                                          , row.Cells("supplier").Value _
                                                          , row.Cells("supplierID").Value _
                                                          , row.Cells("id").Value _
                                                          , ""})
                    End If
                Next
            End If
            tabControl.SelectTab(tbBatch)
            btUpload.Enabled = False
            dgLeadsToUpload.Enabled = True
            btValidate.Text = "Validate"
        Else
            MsgBox("No leads to move over.")
        End If
    End Sub

    Private Sub tbAPI_Enter(sender As Object, e As EventArgs) Handles tbAPI.Enter
        refreshLeadsNew()
    End Sub

    Public Sub removeAndUpdateDup(dupID As Integer)
        For Each row As DataGridViewRow In dgDups.Rows
            If row.Cells("dupLeadID").Value = dupID Then
                If row.Cells("leadNewID").Value <> "" Then
                    conn.send("UPDATE lead_new SET actionTaken = 'Dup re-allocated', zestLeadID = " & dupID & " WHERE id = " & row.Cells("leadNewID").Value)
                End If
                dgDups.Rows.Remove(row)
            End If
        Next
    End Sub

    Private Sub btAllocateSelected_Click(sender As Object, e As EventArgs) Handles btAllocateSelected.Click

        Dim agents(dgAgents.SelectedRows.Count) As String
        Dim i As Integer = 0
        For Each row As DataGridViewRow In dgAgents.SelectedRows
            Dim recieveLeads As String = conn.sendReturn("SELECT recieveLeads FROm sys_agent_info WHERE userName = '" & row.Cells("Agent").Value & "'")
            If recieveLeads = "1" Or recieveLeads = "True" Then
                agents(i) = row.Cells("Agent").Value
                i += 1
            End If
        Next

        If i <> 0 Then

            ReDim Preserve agents(i - 1)
            i = 0

            For Each row As DataGridViewRow In dgLeadsToUpload.Rows
                If row.Cells("Agent").Value = "" Then
                    row.Cells("Agent").Value = agents(i)
                    If i = agents.Length - 1 Then
                        i = 0
                    Else
                        i += 1
                    End If
                End If
            Next
        Else
            MsgBox("None of the selected leads have opted for leads.")
        End If



        recalcAgentAllocated()
    End Sub

    Private Sub cmsDelete_Click(sender As Object, e As EventArgs) Handles cmsDelete.Click
        If MsgBox("Are you sure you want to delete the selected row?", MsgBoxStyle.YesNo) = vbYes Then
            For Each row As DataGridViewRow In dgLeadsToUpload.SelectedRows
                dgLeadsToUpload.Rows.Remove(row)
            Next
        End If
    End Sub

    Private Sub dgLeadsToUpload_MouseDown(sender As Object, e As MouseEventArgs) Handles dgLeadsToUpload.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim ht As DataGridView.HitTestInfo
            ht = Me.dgLeadsToUpload.HitTest(e.X, e.Y)
            If ht.Type = DataGridViewHitTestType.Cell Then
                dgLeadsToUpload.ClearSelection()
                dgLeadsToUpload.Rows(ht.RowIndex).Selected = True
            End If
        End If
    End Sub

    Private Sub cmsEditLead_Click(sender As Object, e As EventArgs) Handles cmsEditLead.Click
        If dgLeadsToUpload.SelectedRows.Count = 1 Then
            For Each row As DataGridViewRow In dgLeadsToUpload.SelectedRows
                frmLeadBatchGrid.loadLead(row.Index)
            Next
        End If
    End Sub

    Private Sub btAddToBatch_Click(sender As Object, e As EventArgs) Handles btAddToBatch.Click
        txContactNum.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
        conn.send("INSERT INTO lead_new (title, firstName, lastName, contactNumber, emailAdd, comment, supplier, source, supplierCampaign, loadedFrom) " _
                                & "VALUES ('" & cbTitle.Text & "', '" & txFirstName.Text & "', '" & txLastName.Text & "', '" & txContactNum.Text & "', '" _
                                & txEmailAdd.Text & "', '" & Replace(txComment.Text, "'", "''") & "', '" & lbAffinityCode.Text & "', '" & cbSource.Text & "', '" & txCampaign.Text & "', '" & frmSide.lbUser.Text & "')")
        txContactNum.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
        clearFields()
        notify("Lead added to batch table.")
        'tabControl.SelectedTab = tbBatch
    End Sub

    Private Sub DeleteAsDupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteAsDupToolStripMenuItem.Click
        If MsgBox("Are you sure you want to delete and mark as a duplicate the selected row?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            For Each row As DataGridViewRow In dgLeadsToUpload.SelectedRows
                If row.Cells("affinityID").Value <> "" And row.Cells("leadNewID").Value = "" Then
                    Dim titleUpload As String = If(row.Cells("title").Value = "", "NULL", "'" & row.Cells("title").Value & "'")
                    Dim firstnameUpload As String = If(row.Cells("firstName").Value = "", "NULL", "'" & row.Cells("firstName").Value & "'")
                    Dim lastNameUpload As String = If(row.Cells("lastName").Value = "", "NULL", "'" & row.Cells("lastName").Value & "'")
                    Dim emailUpload As String = If(row.Cells("firstName").Value = "", "NULL", "'" & row.Cells("firstName").Value & "'")
                    Dim dupID As String = If(row.Cells("dupLeadID").Value = "", "0", "'" & row.Cells("dupLeadID").Value & "'")

                    Dim contactNumberUpload As String = ""
                    If Not IsDBNull(row.Cells("contactNum").Value) Then
                        If Not IsNothing(row.Cells("contactNum").Value) Then
                            If (row.Cells("contactNum").Value.ToString.Substring(0, 2) = "27") And row.Cells("contactNum").Value.ToString.Length = 11 Then
                                contactNumberUpload = "'0" & row.Cells("contactNum").Value.Substring(2, 9) & "'"
                            Else
                                contactNumberUpload = "'" & row.Cells("contactNum").Value.ToString() & "'"
                            End If
                        Else
                            contactNumberUpload = "NULL"
                        End If
                    Else
                        contactNumberUpload = "NULL"
                    End If

                    conn.send("INSERT INTO lead_new (title, firstName, lastName, contactNumber, emailAdd, comment, supplier, supplierID, source, zestLeadID, actionTaken, loadedFrom) " _
                            & "VALUES (" & titleUpload & ", " & firstnameUpload & ", " & lastNameUpload & ", " & contactNumberUpload & ", " & emailUpload _
                            & ", '" & Replace(row.Cells("comment").Value, "'", "''") & "', '" & row.Cells("affinityCode").Value & "', '" & row.Cells("affinityID").Value & "', '" & row.Cells("source").Value & "', " & dupID & ", 'Marked As Dup by " & frmSide.lbUser.Text & "', '" & frmSide.lbUser.Text & "')")

                ElseIf row.Cells("leadNewID").Value <> "" Then
                    conn.send("UPDATE lead_new SET actionTaken = 'Marked As Dup by " & frmSide.lbUser.Text & "', zestLeadID = 0 WHERE id = " & row.Cells("leadNewID").Value)
                End If
                dgLeadsToUpload.Rows.Remove(row)
            Next

        End If
    End Sub

    Private Sub recalcAgentAllocated()
        For Each rowAgent As DataGridViewRow In dgAgents.Rows
            rowAgent.Cells("inBatch").Value = 0
            For Each rowLead As DataGridViewRow In dgLeadsToUpload.Rows
                If rowLead.Cells("agent").Value = rowAgent.Cells("agent").Value Then
                    rowAgent.Cells("inBatch").Value += 1
                End If
            Next rowLead
        Next rowAgent
    End Sub

    Private Sub btAutoAllocate_Click(sender As Object, e As EventArgs) Handles btAutoAllocate.Click
        Dim agents As String = ""
        'Dim inboundList As New List(Of Integer)

        If dgAgents.SelectedRows.Count <= 1 Then
            For Each row As DataGridViewRow In dgAgents.Rows
                agents += "'" & row.Cells("Agent").Value & "', "
            Next
        Else
            For Each row As DataGridViewRow In dgAgents.SelectedRows
                agents += "'" & row.Cells("Agent").Value & "', "
            Next
        End If

        agents = agents.Substring(0, agents.Length - 2)
        recalcAgentAllocated()

        conn.fillDS("SELECT lead_primary.agent, SUM(IF(status = 'Sale', 1, 0))/loaded as convRate, loadedToday, 0 AS avaliableToday, 0 AS inBatch, 0 as allocated FROM lead_primary " _
                    & "INNER JOIN (SELECT user FROM hist_events WHERE DATE(timeStamp) = CURDATE() GROUP BY user) AS b ON user = lead_primary.agent INNER JOIN affinities on affinityCode = adminCode " _
                    & "INNER JOIN (SELECT username FROM sys_agent_info WHERE recieveLeads = 1) as d ON lead_primary.agent = userName " _
                    & "LEFT JOIN (SELECT agent, COUNT(leadID) as loadedToday FROM lead_primary INNER JOIN affinities on affinityCode = adminCode " _
                    & "WHERE type = 'Outbound' AND DATE(loadedDate) = DATE(CURDATE()) GROUP BY agent) as a ON lead_primary.agent = a.agent " _
                    & "LEFT JOIN (SELECT agent, COUNT(leadID) AS loaded FROM lead_primary INNER JOIN affinities on affinityCode = adminCode WHERE type = 'Outbound' AND DATE(loadedDate) BETWEEN DATE_SUB(curdate(), INTERVAL 2 WEEK) AND DATE_SUB(curdate(), INTERVAL 1 DAY) GROUP BY  agent) as c on lead_primary.agent = c.agent " _
                    & "WHERE type = 'Outbound' AND DATE(closedDate) BETWEEN DATE_SUB(curdate(), INTERVAL 2 WEEK) AND DATE_SUB(curdate(), INTERVAL 1 DAY) " _
                    & "AND lead_primary.agent IN (" & agents & ") AND lead_primary.agent <> 'Admin' " _
                    & "GROUP BY lead_primary.agent  ORDER BY convRate DESC", "agentConv")
        If conn.ds.Tables("agentConv").Rows.Count = 0 Then
            MsgBox("No agent's avaliable today")
            Exit Sub
        End If


        For Each rowConv As DataRow In conn.ds.Tables("agentConv").Rows
            If Not IsDBNull(rowConv.Item("convRate")) Then
                If rowConv.Item("convRate") < 0.08 Then
                    rowConv.Item("avaliableToday") = 15
                ElseIf rowConv.Item("convRate") >= 0.08 And rowConv.Item("convRate") < 0.1 Then
                    rowConv.Item("avaliableToday") = 20
                ElseIf rowConv.Item("convRate") >= 0.1 Then
                    rowConv.Item("avaliableToday") = 35
                End If
            Else
                rowConv.Item("avaliableToday") = 0
            End If

            If IsDBNull(rowConv.Item("loadedToday")) Then
                rowConv.Item("loadedToday") = 0
            End If

            For Each row As DataGridViewRow In dgAgents.Rows
                If rowConv.Item("agent") = row.Cells("agent").Value Then
                    rowConv.Item("inBatch") = row.Cells("inBatch").Value
                    rowConv.Item("allocated") = row.Cells("allocated").Value
                End If
            Next

        Next rowConv


        Dim count As Integer = 0
        Dim i As Integer = 0
        With conn.ds.Tables("agentConv")
            For Each rowLead As DataGridViewRow In dgLeadsToUpload.Rows
                If rowLead.Cells("Agent").Value = "" Then
1:
                    'Debug.Print(.Rows(i).Item("agent"))
                    'Debug.Print(.Rows(i).Item("avaliableToday"))
                    'Debug.Print(.Rows(i).Item("loadedToday") + .Rows(i).Item("inBatch"))
                    If dictAffType.ContainsKey(rowLead.Cells("affinityCode").Value) Then

                        If (.Rows(i).Item("loadedToday") + .Rows(i).Item("inBatch") < .Rows(i).Item("avaliableToday")) And (.Rows(i).Item("allocated") + .Rows(i).Item("inBatch") < 15) And (.Rows(i).Item("inBatch") < 5) Then
                            rowLead.Cells("Agent").Value = .Rows(i).Item("Agent")
                            .Rows(i).Item("inBatch") += 1
                            If i = .Rows.Count - 1 Then
                                i = 0
                            Else
                                i += 1
                            End If
                            count = 0
                        Else
                            If count <= .Rows.Count Then
                                If i = .Rows.Count - 1 Then
                                    i = 0
                                Else
                                    i += 1
                                End If
                                count += 1
                                GoTo 1
                            Else
                                GoTo 2
                            End If

                        End If
                    End If
                End If
            Next rowLead
        End With
2:
        'Inbound allocation
        conn.fillDS("SELECT userName as agent, IF(inbounds IS NULL, 0, inbounds) as inbounds FROM sys_users " _
                    & "LEFT JOIN (SELECT agent, COUNT(leadID) AS inbounds FROM lead_primary INNER JOIN affinities ON adminCode = affinityCode " _
                    & "WHERE type = 'Inbound' AND MONTH(loadedDate) = MONTH(CURDATE()) AND YEAR(loadedDate) = YEAR(CURDATE()) AND agent <> 'Admin' " _
                    & "GROUP BY agent) as a on agent = userName INNER JOIN (SELECT user FROM hist_events WHERE DATE(timeStamp) = CURDATE() GROUP BY user) AS b ON user = userName " _
                    & "WHERE campaign = 'Gap' AND active = 1 AND sys_users.type = 'Agent' AND userName NOT IN ('Admin', 'Dean Coles', 'Xoliswa Baptista', 'Vuyokazi Sonwabo') ORDER BY inbounds ASC", "agentInbounds")

        If conn.ds.Tables("agentInbounds").Rows.Count = 0 Then
            MsgBox("No agent's to allocate inbound lead(s). These will be removed to upload in the next batch.")
            GoTo 3
        End If
        Dim inboundCount As Integer = 0
        For Each rowLead As DataGridViewRow In dgLeadsToUpload.Rows
            If rowLead.Cells("Agent").Value = "" Then
                If Not dictAffType.ContainsKey(rowLead.Cells("affinityCode").Value) Then
                    rowLead.Cells("agent").Value = conn.ds.Tables("agentInbounds").Rows(inboundCount).Item("agent")
                    If inboundCount >= conn.ds.Tables("agentInbounds").Rows.Count - 1 Then
                        inboundCount = 0
                    Else
                        inboundCount += 1
                    End If
                End If
            End If
        Next
3:
        'Check if there's left over rows
        Dim remainingRows As Integer = 0
        For Each rowLead As DataGridViewRow In dgLeadsToUpload.Rows
            If rowLead.Cells("Agent").Value = "" Then
                remainingRows += 1
            End If
        Next rowLead

        If remainingRows <> 0 Then
            If MsgBox("There are " & remainingRows & " leads not allocated." & vbNewLine & "Would you like to remove these leads?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                For a = 0 To dgLeadsToUpload.Rows.Count - 1
                    If a >= dgLeadsToUpload.Rows.Count Then
                        Exit For
                    ElseIf (dgLeadsToUpload.Rows(a).Cells("Agent").Value = "") And (dgLeadsToUpload.Rows(a).Cells("leadNewID").Value <> "") Then
                        dgLeadsToUpload.Rows.Remove(dgLeadsToUpload.Rows(a))
                        a -= 1
                    End If
                Next a
            End If
        End If

        recalcAgentAllocated()
        notify("Auto Allocation Complete")
    End Sub

    Private Sub btLoadToLeadNew_Click(sender As Object, e As EventArgs) Handles btLoadToLeadNew.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            xlApp = CreateObject("Excel.Application")
            xlWB = xlApp.Workbooks.Open(OpenFileDialog1.FileName)
            xlWS = xlWB.Sheets(1)

            Dim dictColumns As New Dictionary(Of Integer, String)
            dictColumns.Add(1, "Title")
            dictColumns.Add(2, "First Name")
            dictColumns.Add(3, "Last Name")
            dictColumns.Add(4, "Contact Number")
            dictColumns.Add(5, "Email")
            dictColumns.Add(6, "Agent")
            dictColumns.Add(7, "AffinityName")
            dictColumns.Add(8, "Comment")
            dictColumns.Add(9, "Source")
            dictColumns.Add(10, "AffinityCode")
            dictColumns.Add(11, "AffinityID")

            For i = 1 To 10
                If xlWS.Cells(1, i).Value() <> dictColumns.Item(i) Then
                    fixIssue("Column " & i & " should read """ & dictColumns.Item(i) & """ and not """ & xlWS.Cells(1, i).Value() & """. Please fix.", 1, i)
                    Exit Sub
                End If
            Next

            Dim lastrow As Integer
            lastrow = xlWS.Cells(xlWS.Rows.Count, "J").End(Excel.XlDirection.xlUp).Row

            For i = 2 To lastrow
                'Source Check
                If Not sourcesArray.Contains(xlWS.Cells(i, "I").Value) Then
                    fixIssue("Source in row " & i & " is not valid. please check.", i, 10)
                    Exit Sub
                End If

                If xlWS.Cells(i, "J").Value.ToString() = "" Then
                    fixIssue("No affinity in row " & i & ". please check.", i, 10)
                    Exit Sub
                End If

            Next i

            For i = 2 To lastrow
                conn.send("INSERT INTO lead_new (title, firstName, lastName, contactNumber, emailAdd, comment, supplier, supplierID, source, loadedFrom) " _
                                & "VALUES ('" & xlWS.Cells(i, "A").Value & "', '" & xlWS.Cells(i, "B").Value & "', '" & xlWS.Cells(i, "C").Value & "', '" & xlWS.Cells(i, "D").Value & "', '" _
                                & xlWS.Cells(i, "E").Value & "', '" & xlWS.Cells(i, "H").Value & "', '" & xlWS.Cells(i, "J").Value & "', '" & xlWS.Cells(i, "K").Value & "', '" & xlWS.Cells(i, "I").Value & "', '" & frmSide.lbUser.Text & "')")
            Next i

            xlWB.Saved = True
            xlWB.Close()
            releaseObject(xlWS)
            releaseObject(xlWB)
            releaseObject(xlApp)

            refreshLeadsNew()
        End If

    End Sub

    Private Sub refreshLeadsNew()
        conn.fillDS("SELECT id, title, firstName, lastName, contactNumber, lead_new.emailAdd, comment, source, affinityName, supplier, IF(supplierID IS NULL, '', supplierID) AS supplierID, loadedFrom FROM zestlife.lead_new " _
            & "LEFT JOIN affinities ON supplier = adminCode WHERE zestleadID IS NULL ORDER BY lead_new.timestamp ASC", "newLeads")
        dgAPI.DataSource = conn.ds.Tables("newLeads")

        tbAPI.Text = "API (" & apiCount() & ")"
    End Sub

    Private Sub btRefreshInBatch_Click(sender As Object, e As EventArgs) Handles btRefreshInBatch.Click
        recalcAgentAllocated()
    End Sub

    Private Sub btCheckDups_Click(sender As Object, e As EventArgs) Handles btCheckDups.Click
        If Application.OpenForms().OfType(Of frmLeadChange).Any Then
            For Each rowNew As DataGridViewRow In dgDups.Rows
                For Each rowDup As DataGridViewRow In frmLeadChange.dgPickUp.Rows
                    If rowNew.Cells("dupLeadID").Value = rowDup.Cells("leadID").Value Then
                        If rowDup.Cells("Status").Value = "Busy" Or rowDup.Cells("Status").Value = "Allocated" Then
                            rowNew.DefaultCellStyle.BackColor = Color.LightBlue
                            rowDup.DefaultCellStyle.BackColor = Color.LightBlue
                            btEmailBusy.Enabled = True

                        ElseIf (rowDup.Cells("Outcome").Value = "Client is too old") Or ((rowDup.Cells("Outcome").Value = "No medical aid") And ((DateDiff(DateInterval.Month, rowDup.Cells("loadedDate").Value, Now())) <= 3)) Then
                            rowNew.DefaultCellStyle.BackColor = Color.LightPink
                            rowDup.DefaultCellStyle.BackColor = Color.LightPink
                            btConfirmSingleDup.Enabled = True

                        ElseIf (rowDup.Cells("Status").Value = "Sale") Then
                            rowNew.DefaultCellStyle.BackColor = Color.Orange
                            rowDup.DefaultCellStyle.BackColor = Color.Orange

                        Else
                            rowNew.DefaultCellStyle.BackColor = Color.LightGreen
                            rowDup.DefaultCellStyle.BackColor = Color.LightGreen
                        End If
                    End If
                Next rowDup
            Next rowNew
        Else
            MsgBox("Change leads not avaliable.")
        End If
    End Sub

    Private Sub btConfirmSingleDup_Click(sender As Object, e As EventArgs) Handles btConfirmSingleDup.Click
1:
        For Each rowNew As DataGridViewRow In dgDups.Rows
            If rowNew.DefaultCellStyle.BackColor = Color.LightPink And rowNew.Cells("leadNewID").Value <> "" Then
                If Application.OpenForms().OfType(Of frmLeadChange).Any Then
                    For Each rowDup As DataGridViewRow In frmLeadChange.dgPickUp.Rows
                        If rowNew.Cells("dupLeadID").Value = rowDup.Cells("leadID").Value Then
                            frmLeadChange.dgPickUp.Rows.Remove(rowDup)
                        End If
                    Next rowDup
                End If
                conn.send("UPDATE lead_new SET actionTaken = 'Duplicate', zestLeadID = " & rowNew.Cells("dupLeadID").Value & " WHERE id = " & rowNew.Cells("leadNewID").Value)
                dgDups.Rows.Remove(rowNew)
                GoTo 1
            End If
        Next rowNew
    End Sub

    Private Sub btEmailBusy_Click(sender As Object, e As EventArgs) Handles btEmailBusy.Click
        Dim agentEmail As String
1:
        If Application.OpenForms().OfType(Of frmLeadChange).Any Then
            For Each rowNew As DataGridViewRow In dgDups.Rows
                If rowNew.DefaultCellStyle.BackColor = Color.LightBlue Then
                    For Each rowDup As DataGridViewRow In frmLeadChange.dgPickUp.Rows
                        If rowNew.Cells("dupLeadID").Value = rowDup.Cells("leadID").Value Then
                            agentEmail = conn.sendReturn("SELECT emailAddress FROM sys_users WHERE userName = '" & rowDup.Cells("agent").Value & "'")
                            emailOutlook(agentEmail, "Dup Enquiry", "Hi," & vbNewLine & vbNewLine & "Lead " & rowDup.Cells("leadID").Value & " has re-enquired about Gap Cover with the following:" & vbNewLine _
                                & "First Name: " & rowNew.Cells("firstName").Value & vbNewLine _
                                & "Last Name: " & rowNew.Cells("lastName").Value & vbNewLine _
                                & "Contact Number: " & rowNew.Cells("contactNum").Value & vbNewLine _
                                & "Email: " & rowNew.Cells("Email").Value & vbNewLine _
                                & "Affinity: " & rowNew.Cells("affinityName").Value & vbNewLine _
                                & "Comment: " & rowNew.Cells("comment").Value & vbNewLine _
                                & vbNewLine _
                                & "Please call him/her again.")
                            conn.send("UPDATE lead_new SET actionTaken = 'Duplicate', zestLeadID = " & rowNew.Cells("dupLeadID").Value & " WHERE id = " & rowNew.Cells("leadNewID").Value)
                            dgDups.Rows.Remove(rowNew)
                            frmLeadChange.dgPickUp.Rows.Remove(rowDup)
                            GoTo 1
                        End If
                    Next rowDup
                End If
            Next rowNew
        Else
            MsgBox("Change leads not avaliable.")
        End If
    End Sub

End Class