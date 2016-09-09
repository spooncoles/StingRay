
Public Class frmNewUser

    Private Sub frmNewUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = frmMain
        dtStarted.Value = Today
        cbCampaign.SelectedIndex = 0
        cbType.SelectedIndex = 0
    End Sub

    Private Sub btLoadLead_Click(sender As Object, e As EventArgs) Handles btLoadLead.Click
        Dim controls As New List(Of Control) From {txName, txEmailAdd, txContactNum, txIdNum, cbCampaign, dtDOB, cbGender, dtStarted}
        For Each control In controls
            Select Case control.Name
                Case "txName", "cbCampaign", "cbGender", "txEmailAdd"
                    If control.Text = "" Then
                        MsgBox("Please enter in " & control.Tag)
                        Exit Sub
                        'ElseIf control.Name = "txName" Then
                        '    If Not ifUserExists(txName.Text) Then
                        '        MsgBox("User not in active directory!" & vbNewLine & "Please ensure user is in formate ""First Last""")
                        '        Exit Sub
                        '    End If
                    ElseIf control.Name = "txEmailAdd" Then
                        If Not validateEmail(txEmailAdd.Text) Then
                            MsgBox("Invalid Email")
                            txEmailAdd.Focus()
                            Exit Sub
                        End If
                    End If
                Case "dtStarted", "dtDOB"
                    Dim dt As DateTimePicker = control
                    If dt.Value() > Today Then
                        MsgBox(control.Tag & " cannot be more than today.")
                        Exit Sub
                    End If
                Case "txContactNum"
                    txContactNum.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
                    If txContactNum.Text = "" Then
                        MsgBox("Please enter in " & control.Tag)
                        Exit Sub
                    Else
                        Dim valid As String = validateContactNumber(txContactNum.Text)
                        If valid <> "Pass" Then
                            MsgBox(valid)
                            control.Focus()
                            Exit Sub
                        End If
                    End If
                    txContactNum.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
                Case "txIdNum"
                    txIdNum.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
                    If control.Text <> "" Then
                        Dim valid As String = validateIdNumber(txIdNum.Text)
                        If valid <> "Pass" Then
                            MsgBox(valid)
                            control.Focus()
                            Exit Sub
                        End If
                    End If
                    txIdNum.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
            End Select
        Next control

        txContactNum.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
        txIdNum.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
        txQueueMetrics.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals

        If MsgBox("Are you sure you want to load the user with the settings given?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            conn.send("INSERT INTO sys_users (userName, emailaddress, contactNumber, idNumber, campaign, active, type, dateOfBirth, gender, dateStarted, queuemetricsCode)" _
                  & " VALUES ('" & txName.Text & "', '" & txEmailAdd.Text & "', '" & txContactNum.Text & "', '" & txIdNum.Text & "', '" & cbCampaign.Text & "', '1'" _
                  & ", '" & cbType.Text & "', '" & Format(dtDOB.Value(), "yyyy-MM-dd") & "', '" & cbGender.Text & "', '" & Format(dtStarted.Value(), "yyyy-MM-dd") & "', '" & txQueueMetrics.Text & "')")

            If MsgBox("New user added. Email details now?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                emailOutlook(txEmailAdd.Text, "Welcome", "Hi," & vbNewLine & "I have added your user to the system." & vbNewLine & "You can now log-in using your normal server details.")
            End If
            Me.Close()
        End If
        
    End Sub
End Class