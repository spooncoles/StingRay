Public Class frmQaAdmin

    Private Sub frmQaAdmin_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        For i = 0 To lvQuestions.Items.Count - 1
            conn.send("UPDATE qa_questions SET questionOrder = " & i & " WHERE questionID = " & CInt(lvQuestions.Items(i).SubItems(0).Text))
        Next
    End Sub

    Private Sub frmQaAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn.fillDS("SELECT DISTINCT(section) FROM qa_questions WHERE active = 1", "sections")
        For Each section In conn.ds.Tables("sections").Rows
            cbSection.Items.Add(section.item(0))
        Next
        cbSection.SelectedIndex = 0
    End Sub

    Private Sub cbSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSection.SelectedIndexChanged
        For i = 0 To lvQuestions.Items.Count - 1
            conn.send("UPDATE qa_questions SET questionOrder = " & i & " WHERE questionID = " & CInt(lvQuestions.Items(i).SubItems(0).Text))
        Next
        refreshData()
    End Sub

    Public Sub refreshData()
        conn.fillDS("SELECT questionID, questionOrder, question, allowNA FROM qa_questions WHERE active = 1 AND section = '" & cbSection.Text & "' ORDER BY questionOrder", "sectionQuestions")

        lvQuestions.Items.Clear()
        With conn.ds.Tables("sectionQuestions")
            For Each row In .Rows
                Dim str() As String = {row.Item("questionID"), row.Item("question"), row.Item("allowNA")}
                lvQuestions.Items.Add(New ListViewItem(str))
            Next
        End With
        lvQuestions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Sub

    Private Sub btSectionAdd_Click(sender As Object, e As EventArgs) Handles btSectionAdd.Click
        Dim sectionName As String = InputBox("Please enter section name:", "New Section")
1:
        If MsgBox("Are you sure you want to add the below section:" & vbNewLine & sectionName, MsgBoxStyle.YesNo) = vbNo Then
            sectionName = InputBox("Please enter sectino name:", "New Section", sectionName)
        Else
            cbSection.Items.Add(sectionName)
            conn.recordEvent("Qa section added", sectionName, )
        End If
    End Sub

    Private Sub btNew_Click(sender As Object, e As EventArgs) Handles btNew.Click
        Dim question As String = InputBox("Please enter question:", "New Question")
        If question = "" Then Exit Sub
1:
        If MsgBox("Are you sure you want to add the below question to the """ & cbSection.Text & """ section:" & vbNewLine & question, MsgBoxStyle.YesNo) = vbNo Then
            question = InputBox("Please enter question:", "New Question", question)
        Else
            If MsgBox("Can the user select N/A for this question?" & vbNewLine & question, MsgBoxStyle.YesNo) = vbYes Then
                conn.send("INSERT INTO qa_questions (section, questionOrder, question, allowNA, createdBy, active) " _
                      & "VALUES('" & cbSection.Text & "', 3, '" & question & "', 1, '" & frmSide.lbUser.Text & "', 1)")
            Else
                conn.send("INSERT INTO qa_questions (section, questionOrder, question, allowNA, createdBy, active) " _
                      & "VALUES('" & cbSection.Text & "', 3, '" & question & "', 0, '" & frmSide.lbUser.Text & "', 1)")
            End If
            refreshData()
        End If
    End Sub

    Private Sub btReplace_Click(sender As Object, e As EventArgs) Handles btReplace.Click

        If lvQuestions.CheckedItems.Count <> 1 Then
            MsgBox("You need to select 1 item to change!")
            Exit Sub
        Else
            For Each item As ListViewItem In lvQuestions.CheckedItems
                Dim question As String = InputBox("Please edit the below question:", "New Question", item.SubItems(1).Text)
                If question = "" Then Exit Sub
1:
                If MsgBox("Are you sure you want to replace the question with  the below question to the """ & cbSection.Text & """ section:" & vbNewLine & question, MsgBoxStyle.YesNo) = vbNo Then
                    question = InputBox("Please enter question:", "New Question", question)
                    GoTo 1
                Else
                    conn.send("INSERT INTO qa_questions (section, questionOrder, question, createdBy, active) " _
                              & "VALUES('" & cbSection.Text & "', 3, '" & question & "', '" & frmSide.lbUser.Text & "', 1)")
                    conn.send("UPDATE qa_questions SET active = 0 WHERE questionID = " & item.SubItems(0).Text)
                    conn.recordEvent("Qa question removed", frmSide.lbUser.Text, item.SubItems(0).Text)
                    refreshData()
                End If
            Next
        End If

    End Sub

    Private Sub btMarkAsNA_Click(sender As Object, e As EventArgs)
        For Each item As ListViewItem In lvQuestions.CheckedItems
            item.SubItems(2).Text = True
            item.Checked = False
        Next
    End Sub

    Private Sub btDisallowNA_Click(sender As Object, e As EventArgs)
        For Each item As ListViewItem In lvQuestions.CheckedItems
            item.SubItems(2).Text = False
            item.Checked = False
        Next
    End Sub

End Class