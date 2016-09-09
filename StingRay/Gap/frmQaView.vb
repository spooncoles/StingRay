Public Class frmQaView
    Dim dtLeadInfo As New DataTable
    Dim manualApp As Boolean = False

    Private Sub frmQaView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgleadInfo.AutoResizeColumns()
        dgleadInfo.AutoResizeRows()
        Me.MdiParent = frmMain
        createTabs()

        AddHandler cbEvents.CheckedChanged, AddressOf refreshHistory
        AddHandler cbChanges.CheckedChanged, AddressOf refreshHistory
        AddHandler cbComments.CheckedChanged, AddressOf refreshHistory
        AddHandler cbCalls.CheckedChanged, AddressOf refreshHistory


    End Sub

    Sub createTabs()
        conn.fillDS("SELECT DISTINCT(section) FROM qa_questions WHERE active = 1", "sections")
        For Each section In conn.ds.Tables("sections").Rows
            Dim currentTab As New TabPage
            currentTab.Name = section.item(0)
            currentTab.Text = section.item(0)
            'tbControl.TabPages.Add(currentTab)


            tbControl.TabPages.Insert(tbControl.TabCount - 2, currentTab)
            conn.fillDS("SELECT questionID AS id, question, allowNA, pass_fail_NA FROM qa_questions " _
                        & "LEFT JOIN (SELECT qaQuestionID, pass_fail_NA FROM qa_lead_stats WHERE leadID = " & gbLeadDetails.Tag & ") AS  a ON qa_questions.questionID = a.qaQuestionID " _
                        & "WHERE active = 1 AND section = '" & section.item(0) & "' ORDER BY questionOrder", section.item(0))
            If conn.ds.Tables(section.item(0)).Columns.Count <> 6 Then
                Dim colYes As New Data.DataColumn("Yes", GetType(Boolean))
                colYes.DefaultValue = False
                conn.ds.Tables(section.item(0)).Columns.Add(colYes)
                colYes.SetOrdinal(1)

                Dim colNo As New Data.DataColumn("No", GetType(Boolean))
                colNo.DefaultValue = False
                conn.ds.Tables(section.item(0)).Columns.Add(colNo)
                colNo.SetOrdinal(2)

                Dim colNA As New Data.DataColumn("N/A", GetType(Boolean))
                If manualApp Then
                    If section.item(0) = "Primary details" Or section.item(0) = "Banking details" Then
                        colNA.DefaultValue = False
                    Else
                        colNA.DefaultValue = True
                    End If
                Else
                    colNA.DefaultValue = False
                End If
                
                conn.ds.Tables(section.item(0)).Columns.Add(colNA)
                colNA.SetOrdinal(3)
            End If

            Dim dvg As New DataGridView
            dvg.Dock = DockStyle.Fill
            dvg.Parent = currentTab
            dvg.RowHeadersVisible = False
            dvg.AllowUserToAddRows = False
            dvg.DataSource = conn.ds.Tables(section.item(0))
            dvg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            dvg.Parent.BackColor = Color.Black

            currentTab.Controls.Add(dvg)

            dvg.Columns("allowNA").Visible = False
            dvg.Columns("pass_fail_NA").Visible = False
            dvg.Columns("id").ReadOnly = True
            dvg.Columns("question").ReadOnly = True

            For Each row In dvg.Rows
                If Not IsDBNull(row.cells("pass_fail_NA").Value()) Then
                    Select Case row.cells("pass_fail_NA").Value()
                        Case "Y"
                            row.cells("Yes").Value() = True
                        Case "N"
                            row.cells("No").Value() = True
                        Case "NA"
                            row.cells("N/A").Value() = True
                    End Select
                End If
            Next row

            AddHandler dvg.CellContentClick, AddressOf Me.dvg_CellContentClick
            'AddHandler dvg.CellLeave, AddressOf Me.dvg_CellLeave

        Next section

        tbControl.SelectedIndex = 0

    End Sub

    Sub dvg_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex <> -1 Then
            With sender.rows(e.RowIndex)
                Select Case sender.Columns(e.ColumnIndex).HeaderText
                    Case "Yes"
                        .cells("No").value() = False
                        .cells("N/A").value() = False
                    Case "No"
                        .cells("Yes").value() = False
                        .cells("N/A").value() = False
                    Case "N/A"
                        .cells("Yes").value() = False
                        .cells("No").value() = False
                End Select
            End With
        End If
        
    End Sub

    Public Sub loadLead(ByRef leadID As Integer)

        If Not dtLeadInfo Is Nothing Then
            If Not dtLeadInfo.Columns.Contains("Field") Then
                dtLeadInfo.Columns.Add("Field", GetType(String))
            End If

            If Not dtLeadInfo.Columns.Contains("Value") Then
                dtLeadInfo.Columns.Add("Value", GetType(String))
            End If

            If Not dtLeadInfo.Columns.Contains("Copy") Then
                dtLeadInfo.Columns.Add("Copy", GetType(Boolean))
            End If

            dgleadInfo.DataSource = dtLeadInfo
            dgleadInfo.Columns("Field").ReadOnly = True
            dgleadInfo.Columns("Value").ReadOnly = True
            dgleadInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
        End If

        gbLeadDetails.Text = "Lead ID = " & CStr(leadID)
        gbLeadDetails.Tag = CStr(leadID)

        Dim sql As String = "SELECT agent, title, firstName, lastName, loadedDate, closedDate, affinityname, idNumber, emailAddress, contactNumber, cellNumber, homeNumber, workNumber, CAST(dateOfBirth AS CHAR(100)) AS DOB," _
                            & " gender, appType, medicalAid, medicalAidPlan, medicalDependants, holderName, accountNumber, accountType, bankName, branchCode, paymentDay, CAST(firstDebitDate AS CHAR(100)) AS debitDate, paymentType, annualHousehold, employeeNum, description AS Product, cost," _
                            & " postal1, postal2, postalSuburb, postalCity, postalProvince, postalCode, physicalIsPostal, physical1, physical2, physicalSuburb, physicalCity, physicalProvince, physicalCode" _
                            & " FROM zestlife.lead_primary INNER JOIN lead_sale_info ON lead_primary.leadID = lead_sale_info.leadID INNER JOIN affinities ON adminCode = affinityCode INNER JOIN sys_products ON productTaken = productID LEFT JOIN lead_banking ON lead_primary.leadID = lead_banking.leadID INNER JOIN lead_address ON lead_primary.leadID = lead_address.leadID" _
        & " WHERE lead_primary.leadID = " & CStr(leadID)
        conn.fillDS(sql, "leadInfo")

        With conn.ds.Tables("leadInfo")
            If .Rows.Count <> 0 Then
                For Each column In .Columns
                    dtLeadInfo.Rows.Add(column.ColumnName, .Rows(0).Item(column.ColumnName), False)
                Next column
            End If
            If .Rows(0).Item("appType") = "Manual" Then
                manualApp = True
            End If
        End With

        conn.fillDS("SELECT qaOverallComment FROM lead_sale_info WHERE leadID = " & CStr(leadID), "comment")
        If conn.ds.Tables("comment").Rows.Count <> 0 Then
            If Not IsDBNull(conn.ds.Tables("comment").Rows(0).Item("qaOverallComment")) Then txOverallComment.Text = conn.ds.Tables("comment").Rows(0).Item("qaOverallComment")
        End If

        Me.Show()
        frmQaPickUp.Close()
        conn.send("UPDATE lead_sale_info SET qaAgent = '" & frmSide.lbUser.Text & "' WHERE leadID = " & leadID)
        conn.recordEvent("QA Pick Up", , leadID)

        Dim colWidth As Integer = 0
        For Each col As DataGridViewColumn In dgleadInfo.Columns
            colWidth += col.Width
        Next col

        gbLeadDetails.Width = colWidth + 10
        btCopy.Location = New Point(gbLeadDetails.Location.X + gbLeadDetails.Width - btCopy.Width, btCopy.Location.Y)
        tbControl.Location = New Point(gbLeadDetails.Location.X + gbLeadDetails.Width + 5, 10)
        Me.Size = New Size(tbControl.Location.X + tbControl.Width + 20, Me.Height)
        'Me.CenterToScreen()

    End Sub

    Private Sub btCopy_Click(sender As Object, e As EventArgs) Handles btCopy.Click
        Dim result() As DataRow = dtLeadInfo.Select("Copy = True")
        Dim copyText As String = "Info for lead " & gbLeadDetails.Tag & ":"
        For Each row In result
            copyText = copyText & vbNewLine & vbTab & row.Item("Field") & ": " & row.Item("Value")
        Next row
        Clipboard.SetText(copyText)
        notify("Copied to clipboard.")
    End Sub

    Sub saveQaDetails(type As String)

        If txOverallComment.Text = "" Then
            If MsgBox("Are you sure you do not want to comment?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        'Ratings
        Dim rated As Boolean
        Dim unrated As String = ""
        Dim unratedCount = 0
        Dim ratings As New List(Of GroupBox) From {gbAgentFriendliness, gbTelephoneEtiquette, gbProductExplination, gbClientUnderstanding}
        For Each gb In ratings
            rated = False
            For Each rb As RadioButton In gb.Controls
                If rb.Checked Then
                    rated = True
                    gb.Tag = rb.Text
                End If
            Next rb
            If rated = False Then
                unrated += gb.Text & vbNewLine
                unratedCount += 1
            End If
        Next gb

        If unratedCount <> 0 Then
            If MsgBox("Are you sure you do not want to rate the below: " & vbNewLine & unrated, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If



        conn.fillDS("SELECT id, qaQuestionID, leadID FROM qa_lead_stats WHERE leadID = " & gbLeadDetails.Tag, "questions")

        Dim dict As New Dictionary(Of String, String)
        For Each row As DataRow In conn.ds.Tables("questions").Rows
            dict.Add(row.Item("qaQuestionID").ToString() & row.Item("leadID").ToString(), row.Item("id").ToString())
        Next

        Dim answer As String = ""
        For Each tabpage In tbControl.TabPages
            If tabpage.text <> "Final" And tabpage.text <> "History" Then
                For Each dvg In tabpage.Controls
                    If (dvg.GetType() Is GetType(DataGridView)) Then
                        For Each row In dvg.Rows
                            If Not ((Not row.Cells("Yes").value()) And (Not row.Cells("No").value()) And (Not row.Cells("N/A").value())) Then

                                If row.Cells("Yes").Value() Then answer = "Y"
                                If row.Cells("No").Value() Then answer = "N"
                                If row.Cells("N/A").Value() Then answer = "NA"

                                If dict.ContainsKey(row.cells("id").value() & gbLeadDetails.Tag) Then
                                    conn.send("UPDATE qa_lead_stats SET pass_fail_NA = '" & answer & "' WHERE id = " & CInt(dict.Item(row.cells("id").value() & gbLeadDetails.Tag)))
                                Else
                                    conn.send("INSERT INTO qa_lead_stats (leadID, qaQuestionID, pass_fail_NA) " _
                                              & "VALUES('" & gbLeadDetails.Tag & "', '" & row.cells("id").value() & "', '" & answer & "')")
                                End If
                            End If
                        Next row
                    End If
                Next dvg
            End If
        Next tabpage

        Dim ratingsUpdate As String = ""
        For Each gb In ratings
            If gb.Tag <> "" Then
                ratingsUpdate += ", " & Replace(gb.Name, "gb", "qaRating") & " = '" & gb.Tag & "'"
            End If
        Next gb

        If txOverallComment.Text <> "" Then
            conn.send("UPDATE lead_sale_info SET qaStatus = '" & type & "', qaOverallComment = '" & txOverallComment.Text & "'" & ratingsUpdate & " WHERE leadID = " & gbLeadDetails.Tag)
        Else
            conn.send("UPDATE lead_sale_info SET qaStatus = '" & type & "'" & ratingsUpdate & " WHERE leadID = " & gbLeadDetails.Tag)
        End If

        conn.recordEvent("QA " & type, , gbLeadDetails.Tag)

        Me.Hide()
        If MsgBox("Thank-you. Would you like to pick up the next lead in your queue?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            frmSide.nextInQueue(Me)
            Me.Close()
        Else
            Me.Close()
        End If
    End Sub

    Sub validatePass()

        Dim uncomplete As String = ""
        Dim notNA As String = ""

        For Each tabpage In tbControl.TabPages
            If tabpage.text <> "Final" And tabpage.text <> "History" Then
                For Each dvg In tabpage.Controls
                    If (dvg.GetType() Is GetType(DataGridView)) Then
                        For Each row In dvg.Rows
                            If row.Cells("allowNA").value() Then
                                Console.Write(row.Cells("N/A").value())
                            End If
                            If (Not row.Cells("Yes").value()) And (Not row.Cells("No").value()) And (Not row.Cells("N/A").value()) Then
                                tabpage.Select()
                                row.Cells("question").Style.ForeColor = Color.Red
                                uncomplete = Replace(uncomplete, vbNewLine & tabpage.Text, "") & vbNewLine & tabpage.Text
                            ElseIf row.Cells("N/A").value() And Not row.Cells("allowNA").value() Then
                                tabpage.Select()
                                row.Cells("question").Style.ForeColor = Color.Blue
                                notNA = Replace(notNA, vbNewLine & tabpage.Text, "") & vbNewLine & tabpage.Text
                            Else
                                row.Cells("question").Style.ForeColor = Color.Black
                            End If
                        Next row
                    End If
                Next dvg
            End If
        Next tabpage
        If uncomplete <> "" Then
            MsgBox("There are questions that are not complete in the " & uncomplete & vbNewLine & " tab(s). Please check red text in each tab.")
            Exit Sub
        ElseIf notNA <> "" Then
            MsgBox("There are questions that cannot be N/A in the " & notNA & vbNewLine & " tab(s). Please check blue text in each tab.")
            Exit Sub
        End If

        saveQaDetails("Pass")

    End Sub

    Private Sub btBypass_Click(sender As Object, e As EventArgs) Handles btBypass.Click
        If MsgBox("Are you sure you want to Bypass this lead?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            saveQaDetails("Bypass")
        End If
    End Sub

    Private Sub btSendBack_Click(sender As Object, e As EventArgs) Handles btSendBack.Click
        saveQaDetails("Sent Back")
    End Sub

    Private Sub btPass_Click(sender As Object, e As EventArgs) Handles btPass.Click
        validatePass()
    End Sub

    Private Sub btSave_Click(sender As Object, e As EventArgs) Handles btSave.Click
        saveQaDetails("In progress")
    End Sub

    Private Sub refreshHistory()
        If cbEvents.Checked Or cbChanges.Checked Or cbComments.Checked Or cbCalls.Checked Then
            Dim sqlQuery As String = "SELECT timeStamp, user, eventmain, eventSub, CAST(changeFrom AS CHAR(100)) AS changeFrom, CAST(changeTo AS CHAR(100)) AS changeTo, CAST(comment AS CHAR(100)) AS comment FROM ("

            If cbEvents.Checked Then sqlQuery = sqlQuery & "SELECT timeStamp, user, eventMain, eventSub, NULL AS changeFrom, NULL AS changeTo, NULL comment FROM hist_events WHERE leadID = " & gbLeadDetails.Tag & " UNION "

            If cbChanges.Checked Then sqlQuery = sqlQuery & "SELECT timestamp, user, 'Change' As eventMain, field As eventSub, changeFrom, changeTo, comment FROM hist_changes WHERE leadID = " & gbLeadDetails.Tag & " UNION "

            If cbComments.Checked Then sqlQuery = sqlQuery & "SELECT timeStamp, user, 'Comment' AS eventMain, NULL AS eventSub, NULL AS changeFrom, NULL AS changeTo, comment FROM lead_comments WHERE leadID = " & gbLeadDetails.Tag & " UNION "

            If cbCalls.Checked Then sqlQuery = sqlQuery & "SELECT timeStamp, userName as user, IF(answered = 1, 'Answered Call', 'Missed Call') As eventMain, dialledNum AS eventSub, wait AS changeFrom, duration AS changeTo, NULL AS comment FROM queuemetrics " _
                & "LEFT JOIN lead_primary ON RIGHT(dialledNum, 9) = RIGHT(contactNumber, 9) LEFT JOIN sys_users ON RIGHT(sys_users.workNumber, 7) = agentCode WHERE leadID = " & gbLeadDetails.Tag & " UNION "

            sqlQuery = sqlQuery.Substring(0, sqlQuery.Length() - 7) & ") as a ORDER BY timeStamp DESC"
            conn.fillDS(sqlQuery, "history")
            dgHistory.DataSource = conn.ds.Tables("history")
        Else
            conn.ds.Tables("history").Clear()
            dgHistory.DataSource = conn.ds.Tables("history")
        End If
    End Sub

    Private Sub tbHistory_Enter(sender As Object, e As EventArgs) Handles tbHistory.Enter
        refreshHistory()
    End Sub
End Class