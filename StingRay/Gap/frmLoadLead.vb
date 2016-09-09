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
            cbAgent.DisplayMember = "Key"
            cbAgent.ValueMember = "Value"
            cbAgent.DataSource = New BindingSource(modExtra.dictAgents, Nothing)

            Dim dgComboSource As New DataGridViewComboBoxColumn
            dgComboSource.Name = "Source"
            dgComboSource.HeaderText = "Source"
            For Each source As String In sourcesArray
                dgComboSource.Items.Add(source)
            Next
            'dgLeadsToUpload.Columns.Add(dgComboSource)
            dgLeadsToUpload.Columns.Insert(9, dgComboSource)

            Dim agentColumn As DataGridViewComboBoxColumn = dgLeadsToUpload.Columns("Agent")
            For Each key In dictAgents.Keys
                agentColumn.Items.Add(key.ToString)
            Next
            agentColumn.Items.Add("")

            tabControl.SelectedTab = tbBatch
            conn.fillDS("SELECT agent, SUM(IF(status = 'Busy', 1, 0)) AS 'Busy', SUM(IF(status = 'Allocated', 1, 0)) AS Allocated " _
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
                tabControl.TabPages(1).Enabled = True
                tabControl.SelectedTab = tabDetails
            End If
        End If
    End Sub

    Private Sub dgPickUp_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dgSelectSource.MouseDoubleClick
        If conn.ds.Tables("sourcePicks").Rows.Count <> 0 Then
            lbAffinityCode.Text = dgSelectSource.Item("adminCode", dgSelectSource.CurrentRow.Index).Value.ToString()
            lbAffinityName.Text = dgSelectSource.Item("affinityName", dgSelectSource.CurrentRow.Index).Value.ToString()
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
        cbSource.SelectedIndex = -1

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
        xlApp.Visible = True
        releaseObject(xlWS)
        releaseObject(xlWB)
        releaseObject(xlApp)
    End Sub

    Private Sub btOpenFile_Click(sender As Object, e As EventArgs) Handles btOpenFile.Click

        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            xlApp = CreateObject("Excel.Application")
            xlWB = xlApp.Workbooks.Open(OpenFileDialog1.FileName)
            xlWS = xlWB.Sheets(1)

            Dim dictColumns As New Dictionary(Of Integer, String)
            dictColumns.Add(1, "First Name")
            dictColumns.Add(2, "Last Name")
            dictColumns.Add(3, "Contact Number")
            dictColumns.Add(4, "Email")
            dictColumns.Add(5, "Agent")
            dictColumns.Add(6, "Comment")
            dictColumns.Add(7, "AffinityCode")
            dictColumns.Add(8, "SMS")
            dictColumns.Add(9, "VIP")
            dictColumns.Add(10, "Source")
            dictColumns.Add(12, "AffinityID")

            For i = 1 To 10
                If xlWS.Cells(1, i).Value() <> dictColumns.Item(i) Then
                    fixIssue("Column " & i & " should read """ & dictColumns.Item(i) & """ and not """ & xlWS.Cells(1, i).Value() & """. Please fix.", 1, i)
                    Exit Sub
                End If
            Next

            Dim lastrow As Integer
            lastrow = xlWS.Cells(xlWS.Rows.Count, "A").End(Excel.XlDirection.xlUp).Row

            For i = 2 To lastrow
                'GHIJ
                If xlWS.Cells(i, "H").Value <> "True" And xlWS.Cells(i, "H").Value <> "False" Then
                    fixIssue("SMS column should read either TRUE or FALSE. Please fix.", i, 7)
                    Exit Sub
                ElseIf xlWS.Cells(i, "I").Value <> "True" And xlWS.Cells(i, "I").Value <> "False" Then
                    fixIssue("VIP column should read either TRUE or FALSE. Please fix.", i, 8)
                    Exit Sub
                ElseIf Not sourcesArray.Contains(xlWS.Cells(i, "J").Value) Then
                    fixIssue("Source in row " & i & " is not valid. please check.", i, 10)
                    Exit Sub

                End If

                If dictAffinities.ContainsValue(xlWS.Cells(i, "G").Value) Then
                    Dim pair As KeyValuePair(Of String, String)
                    Dim affName As String = ""
                    For Each pair In dictAffinities
                        If CStr(pair.Value) = CStr(xlWS.Cells(i, "G").Value) Then
                            affName = pair.Key
                        End If
                    Next
                    dgLeadsToUpload.Rows.Add(New String() {xlWS.Cells(i, "A").Value _
                                                      , xlWS.Cells(i, "B").Value _
                                                      , xlWS.Cells(i, "C").Value _
                                                      , xlWS.Cells(i, "D").Value _
                                                      , xlWS.Cells(i, "E").Value _
                                                      , xlWS.Cells(i, "F").Value _
                                                      , xlWS.Cells(i, "G").Value _
                                                      , xlWS.Cells(i, "H").Value _
                                                      , xlWS.Cells(i, "I").Value _
                                                      , xlWS.Cells(i, "J").Value _
                                                      , xlWS.Cells(i, "K").Value _
                                                      , affName})
                Else
                    dgLeadsToUpload.Rows.Add(New String() {xlWS.Cells(i, "A").Value _
                                                      , xlWS.Cells(i, "B").Value _
                                                      , xlWS.Cells(i, "C").Value _
                                                      , xlWS.Cells(i, "D").Value _
                                                      , xlWS.Cells(i, "E").Value _
                                                      , xlWS.Cells(i, "F").Value _
                                                      , xlWS.Cells(i, "G").Value _
                                                      , xlWS.Cells(i, "H").Value _
                                                      , xlWS.Cells(i, "I").Value _
                                                      , xlWS.Cells(i, "J").Value _
                                                      , xlWS.Cells(i, "K").Value _
                                                      , "Aff Name not found"})
                End If

            Next

            dgLeadsToUpload.AutoResizeColumns()

            xlWB.Close()
            releaseObject(xlWS)
            releaseObject(xlWB)
            releaseObject(xlApp)

            btUpload.Enabled = False
            dgLeadsToUpload.Enabled = True
            btValidate.Text = "Validate"

        End If

    End Sub

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
        Dim dupsFound As Integer = 0
        Dim contactNum As String
        Dim dupLeads As New ArrayList
        Dim dictContact As New Dictionary(Of String, Integer)
        Dim dictEmail As New Dictionary(Of String, Integer)

        If btValidate.Text = "Validate" Then
            With dgLeadsToUpload

                'Validation
                For i = 0 To .Rows.Count - 2
                    If i <= dgLeadsToUpload.Rows.Count - 1 Then

                        If .Rows(i).Cells("Agent").Value = Nothing Then
                            MsgBox("Please enter an agent at row " & i)
                            Exit Sub
                        Else
                            If Not dictAgents.ContainsKey(.Rows(i).Cells("Agent").Value) Then
                                MsgBox("Can't find agent in active agents for row " & i)
                                Exit Sub
                            End If
                        End If

                        If .Rows(i).Cells("affinityCode").Value = Nothing Then
                            MsgBox("Please enter an affinity at row " & i)
                            Exit Sub
                        Else
                            If Not dictAffinities.ContainsValue(.Rows(i).Cells("affinityCode").Value) Then
                                If conn.sendReturn("SELECT adminCode from affinities WHERE adminCode = '" & .Rows(i).Cells("affinityCode").Value & "'") = "NULL" Then
                                    MsgBox("Can't find affinity/referal in affinities for row " & i & ". Check code.")
                                    Exit Sub
                                End If
                            End If
                        End If

                        contactNum = .Rows(i).Cells("contactNum").Value
                        If contactNum <> "" And contactNum <> "0" Then
                            If validateContactNumber(contactNum) <> "Pass" Then
                                MsgBox("Contact Number not valid in row " & i)
                                Exit Sub
                            ElseIf contactNum.Length > 11 Then
                                MsgBox("Contact Number greater than 11 characters in row " & i)
                                Exit Sub
                            End If

                            If dictContact.ContainsKey(.Rows(i).Cells("contactNum").Value) Then
                                MsgBox("Duplicate contact num in grid for below rows" & vbNewLine _
                                       & contactNum & " at row " & dictContact.Item(contactNum.ToString) & vbNewLine _
                                       & contactNum & " at row " & i & vbNewLine & vbNewLine & "Please fix.")
                                Exit Sub
                            Else
                                dictContact.Add(contactNum, i)
                            End If

                        End If

                        If .Rows(i).Cells("email").Value <> "" Then
                            If Not validateEmail(.Rows(i).Cells("email").Value) Then
                                MsgBox("Email not valid in row " & i + 1)
                                Exit Sub
                            End If

                            If dictEmail.ContainsKey(.Rows(i).Cells("email").Value) Then
                                MsgBox("Duplicate email in grid for below rows" & vbNewLine _
                                       & .Rows(i).Cells("email").Value & " at row " & dictEmail.Item(.Rows(i).Cells("email").Value) & vbNewLine _
                                       & .Rows(i).Cells("email").Value & " at row " & i & vbNewLine & vbNewLine & "Please fix.")
                                Exit Sub
                            Else
                                dictEmail.Add(.Rows(i).Cells("email").Value, i)
                            End If

                        End If

                    End If
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
                If ((frmMain.Width - (Me.Width + frmLeadChange.Width)) / 2) > frmSide.Width + 20 Then
                    Me.Location = New Point(((frmMain.Width - (Me.Width + frmLeadChange.Width)) / 2), (frmMain.Height / 2) - (Me.Height / 2) - 20)
                Else
                    Me.Location = New Point(frmSide.Width + 20, (frmMain.Height / 2) - (Me.Height / 2) - 20)
                End If

                frmLeadChange.Location = New Point(Me.Location.X + Me.Width + 10, (frmMain.Height / 2) - (Me.Height / 2) - 20)

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

                If row.Index <> dgLeadsToUpload.Rows.Count - 1 Then

                    If Not IsDBNull(row.Cells("contactNum").Value) Then
                        If Not IsNothing(row.Cells("contactNum").Value) Then
                            If (row.Cells("contactNum").Value.ToString.Substring(0, 2) = "27") And row.Cells("contactNum").Value.ToString.Length = 11 Then
                                contactNumberUpload = "0" & row.Cells("contactNum").Value.Substring(2, 9)
                            Else
                                contactNumberUpload = row.Cells("contactNum").Value.ToString()
                            End If
                        Else
                            contactNumberUpload = ""
                        End If
                    Else
                        contactNumberUpload = ""
                    End If

                    leadID = CInt(conn.sendReturn("INSERT INTO lead_primary(agent, status, affinityCode, firstName, lastName, contactNumber, emailAddress,source, loadedBy) " _
                              & "VALUES('" & row.Cells("Agent").Value & "', 'Allocated', '" & row.Cells("affinityCode").Value & "', " _
                              & "'" & row.Cells("firstName").Value & "', '" & row.Cells("lastName").Value & "', '" & contactNumberUpload & "', '" & row.Cells("Email").Value & "', '" & row.Cells("source").Value & "', " _
                              & "'" & frmSide.lbUser.Text & "'); SELECT LAST_INSERT_ID();"))
                    ' If(row.Cells("affinityID").Value <> "", "", "NULL")
                    If row.Cells("affinityID").Value <> "" And row.Cells("leadNewID").Value = "" Then
                        'conn.send("UPDATE lead_primary SET supplierID = '" & row.Cells("affinityID").Value & "' WHERE leadID = " & leadID)
                        conn.send("INSERT INTO lead_new (firstName, lastName, contactNumber, emailAdd, comment, supplier, supplierID, source, zestLeadID) " _
                      & "VALUES ('" & row.Cells("firstName").Value & "', '" & row.Cells("lastName").Value & "', '" & contactNumberUpload & "', '" & row.Cells("Email").Value & "'" _
                      & ", '" & Replace(row.Cells("comment").Value, "'", "''") & "', '" & row.Cells("affinityCode").Value & "', '" & row.Cells("affinityID").Value & "', '" & row.Cells("source").Value & "', " & leadID & ")")
                    ElseIf row.Cells("leadNewID").Value <> "" Then
                        conn.send("UPDATE lead_new SET actionTaken = 'Allocated', zestLeadID = " & leadID & " WHERE id = " & row.Cells("leadNewID").Value)
                    End If

                    If row.Cells("comment").Value <> "" Then
                        conn.send("INSERT INTO lead_comments (leadID, user, comment) " _
                                  & "VALUES(" & leadID & ", '" & frmSide.lbUser.Text & "', '" & Replace(row.Cells("comment").Value, "'", "''") & "')")
                    End If

                End If
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
            dgDups.Columns.Add("zestDupLeadID", "zestDupLeadID")
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
                    'conn.send("UPDATE lead_primary SET supplierID = '" & row.Cells("affinityID").Value & "' WHERE leadID = " & leadID)
                    conn.send("INSERT INTO lead_new (firstName, lastName, contactNumber, emailAdd, comment, supplier, supplierID, source, zestLeadID, actionTaken) " _
                          & "VALUES ('" & row.Cells("firstName").Value & "', '" & row.Cells("lastName").Value & "', '" & row.Cells("contactNum").Value & "', '" & row.Cells("Email").Value & "'" _
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
        Dim apiLeads As Object = conAPI.sendReturn("SELECT COUNT(id) FROM lead_new WHERE zestLeadNewID IS NULL")
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
        Dim newID As Integer
        conAPI.fillDS("SELECT id, title, firstName, lastName, contactNumber, emailAdd, comment, source, adminCode, supplierID, supplierCampaign FROM lead_new WHERE zestLeadNewID IS NULL", "apiLeads")
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
            newID = conn.sendReturn("INSERT INTO lead_new (title, firstName, lastName, contactNumber, emailAdd, comment, supplier, supplierID, supplierCampaign, source) " _
                                    & "VALUES ('" & apiRow.Item("title") & "', '" & apiRow.Item("firstName") & "', '" & apiRow.Item("lastName") & "', '" & contactNumberAPI & "', '" _
                                    & apiRow.Item("emailAdd") & "', '" & apiRow.Item("comment") & "', '" & apiRow.Item("adminCode") & "', '" & apiRow.Item("supplierID") & "', '" & apiRow.Item("supplierCampaign") & "', '" & apiRow.Item("source") & "'); SELECT LAST_INSERT_ID();")
            If CStr(newID) <> "NULL" Then
                conAPI.send("UPDATE lead_new SET zestLeadNewID = '" & newID & "' WHERE id = " & apiRow.Item("id"))
            End If
        Next apiRow

        conn.fillDS("SELECT id, title, firstName, lastName, contactNumber, lead_new.emailAdd, comment, source, affinityName, supplier, supplierID FROM zestlife.lead_new " _
                    & "LEFT JOIN affinities ON supplier = adminCode WHERE zestleadID IS NULL", "newLeads")
        dgAPI.DataSource = conn.ds.Tables("newLeads")
        dgAPI.AutoResizeColumns()
        dgAPI.AutoResizeRows()
        tbAPI.Text = "API (" & apiCount() & ")"
    End Sub

    Private Sub btCopy_Click(sender As Object, e As EventArgs) Handles btCopy.Click
        If dgAPI.Rows.Count <> 0 Then
            If rbCopyAll.Checked Then
                For Each row As DataGridViewRow In dgAPI.Rows
                    dgLeadsToUpload.Rows.Add(New String() {row.Cells("firstName").Value _
                                                          , row.Cells("lastName").Value _
                                                          , row.Cells("contactNumber").Value _
                                                          , row.Cells("emailAdd").Value _
                                                          , "" _
                                                          , row.Cells("comment").Value _
                                                          , row.Cells("supplier").Value _
                                                          , "FALSE" _
                                                          , "FALSE" _
                                                          , row.Cells("source").Value _
                                                          , row.Cells("supplierID").Value _
                                                          , row.Cells("affinityName").Value _
                                                          , row.Cells("id").Value})
                Next
            ElseIf rbCopySelected.Checked Then
                For Each row As DataGridViewRow In dgAPI.SelectedRows
                    dgLeadsToUpload.Rows.Add(New String() {row.Cells("firstName").Value _
                                                          , row.Cells("lastName").Value _
                                                          , row.Cells("contactNumber").Value _
                                                          , row.Cells("emailAdd").Value _
                                                          , "" _
                                                          , row.Cells("comment").Value _
                                                          , row.Cells("supplier").Value _
                                                          , "FALSE" _
                                                          , "FALSE" _
                                                          , row.Cells("source").Value _
                                                          , row.Cells("supplierID").Value _
                                                          , row.Cells("affinityName").Value _
                                                          , row.Cells("id").Value})
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
        conn.fillDS("SELECT id, title, firstName, lastName, contactNumber, lead_new.emailAdd, comment, source, affinityName, supplier, supplierID FROM zestlife.lead_new " _
                    & "LEFT JOIN affinities ON supplier = adminCode WHERE zestleadID IS NULL", "newLeads")
        dgAPI.DataSource = conn.ds.Tables("newLeads")
        dgAPI.AutoResizeColumns()
        dgAPI.AutoResizeRows()
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
            agents(i) = row.Cells("Agent").Value
            i += 1
        Next

        i = 0

        For Each row As DataGridViewRow In dgLeadsToUpload.Rows
            If row.Index <> dgLeadsToUpload.Rows.Count - 1 Then
                If row.Cells("Agent").Value = "" Then
                    row.Cells("Agent").Value = agents(i)
                    If i = dgAgents.SelectedRows.Count - 1 Then
                        i = 0
                    Else
                        i += 1
                    End If
                End If
            End If
        Next
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

End Class