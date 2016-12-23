<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQaView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.gbLeadDetails = New System.Windows.Forms.GroupBox()
        Me.dgleadInfo = New System.Windows.Forms.DataGridView()
        Me.tbControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btSave = New System.Windows.Forms.Button()
        Me.btBypass = New System.Windows.Forms.Button()
        Me.gbClientUnderstanding = New System.Windows.Forms.GroupBox()
        Me.RadioButton11 = New System.Windows.Forms.RadioButton()
        Me.RadioButton12 = New System.Windows.Forms.RadioButton()
        Me.RadioButton13 = New System.Windows.Forms.RadioButton()
        Me.RadioButton14 = New System.Windows.Forms.RadioButton()
        Me.RadioButton15 = New System.Windows.Forms.RadioButton()
        Me.gbProductExplination = New System.Windows.Forms.GroupBox()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton7 = New System.Windows.Forms.RadioButton()
        Me.RadioButton8 = New System.Windows.Forms.RadioButton()
        Me.RadioButton9 = New System.Windows.Forms.RadioButton()
        Me.RadioButton10 = New System.Windows.Forms.RadioButton()
        Me.gbTelephoneEtiquette = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.gbAgentFriendliness = New System.Windows.Forms.GroupBox()
        Me.rbFreind5 = New System.Windows.Forms.RadioButton()
        Me.rbFreind4 = New System.Windows.Forms.RadioButton()
        Me.rbFreind3 = New System.Windows.Forms.RadioButton()
        Me.rbFreind2 = New System.Windows.Forms.RadioButton()
        Me.rbFreind1 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txOverallComment = New System.Windows.Forms.TextBox()
        Me.btSendBack = New System.Windows.Forms.Button()
        Me.btPass = New System.Windows.Forms.Button()
        Me.tbHistory = New System.Windows.Forms.TabPage()
        Me.cbCalls = New System.Windows.Forms.CheckBox()
        Me.cbComments = New System.Windows.Forms.CheckBox()
        Me.cbChanges = New System.Windows.Forms.CheckBox()
        Me.cbEvents = New System.Windows.Forms.CheckBox()
        Me.dgHistory = New System.Windows.Forms.DataGridView()
        Me.btCopy = New System.Windows.Forms.Button()
        Me.btTransfer = New System.Windows.Forms.Button()
        Me.gbLeadDetails.SuspendLayout()
        CType(Me.dgleadInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gbClientUnderstanding.SuspendLayout()
        Me.gbProductExplination.SuspendLayout()
        Me.gbTelephoneEtiquette.SuspendLayout()
        Me.gbAgentFriendliness.SuspendLayout()
        Me.tbHistory.SuspendLayout()
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbLeadDetails
        '
        Me.gbLeadDetails.Controls.Add(Me.dgleadInfo)
        Me.gbLeadDetails.Location = New System.Drawing.Point(12, 10)
        Me.gbLeadDetails.Name = "gbLeadDetails"
        Me.gbLeadDetails.Size = New System.Drawing.Size(451, 452)
        Me.gbLeadDetails.TabIndex = 0
        Me.gbLeadDetails.TabStop = False
        Me.gbLeadDetails.Text = "Lead Info"
        '
        'dgleadInfo
        '
        Me.dgleadInfo.AllowUserToAddRows = False
        Me.dgleadInfo.AllowUserToDeleteRows = False
        Me.dgleadInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgleadInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgleadInfo.Location = New System.Drawing.Point(3, 16)
        Me.dgleadInfo.Name = "dgleadInfo"
        Me.dgleadInfo.RowHeadersVisible = False
        Me.dgleadInfo.Size = New System.Drawing.Size(445, 433)
        Me.dgleadInfo.TabIndex = 1
        '
        'tbControl
        '
        Me.tbControl.Controls.Add(Me.TabPage1)
        Me.tbControl.Controls.Add(Me.tbHistory)
        Me.tbControl.Location = New System.Drawing.Point(466, 10)
        Me.tbControl.Name = "tbControl"
        Me.tbControl.SelectedIndex = 0
        Me.tbControl.Size = New System.Drawing.Size(793, 482)
        Me.tbControl.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btTransfer)
        Me.TabPage1.Controls.Add(Me.btSave)
        Me.TabPage1.Controls.Add(Me.btBypass)
        Me.TabPage1.Controls.Add(Me.gbClientUnderstanding)
        Me.TabPage1.Controls.Add(Me.gbProductExplination)
        Me.TabPage1.Controls.Add(Me.gbTelephoneEtiquette)
        Me.TabPage1.Controls.Add(Me.gbAgentFriendliness)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txOverallComment)
        Me.TabPage1.Controls.Add(Me.btSendBack)
        Me.TabPage1.Controls.Add(Me.btPass)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(785, 456)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Final"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btSave
        '
        Me.btSave.Location = New System.Drawing.Point(704, 427)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(75, 23)
        Me.btSave.TabIndex = 10
        Me.btSave.Text = "Save"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'btBypass
        '
        Me.btBypass.Location = New System.Drawing.Point(699, 109)
        Me.btBypass.Name = "btBypass"
        Me.btBypass.Size = New System.Drawing.Size(75, 23)
        Me.btBypass.TabIndex = 9
        Me.btBypass.Text = "Bypass"
        Me.btBypass.UseVisualStyleBackColor = True
        '
        'gbClientUnderstanding
        '
        Me.gbClientUnderstanding.Controls.Add(Me.RadioButton11)
        Me.gbClientUnderstanding.Controls.Add(Me.RadioButton12)
        Me.gbClientUnderstanding.Controls.Add(Me.RadioButton13)
        Me.gbClientUnderstanding.Controls.Add(Me.RadioButton14)
        Me.gbClientUnderstanding.Controls.Add(Me.RadioButton15)
        Me.gbClientUnderstanding.Location = New System.Drawing.Point(384, 259)
        Me.gbClientUnderstanding.Name = "gbClientUnderstanding"
        Me.gbClientUnderstanding.Size = New System.Drawing.Size(122, 138)
        Me.gbClientUnderstanding.TabIndex = 8
        Me.gbClientUnderstanding.TabStop = False
        Me.gbClientUnderstanding.Text = "Client understanding"
        '
        'RadioButton11
        '
        Me.RadioButton11.AutoSize = True
        Me.RadioButton11.Location = New System.Drawing.Point(6, 112)
        Me.RadioButton11.Name = "RadioButton11"
        Me.RadioButton11.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton11.TabIndex = 5
        Me.RadioButton11.TabStop = True
        Me.RadioButton11.Text = "5"
        Me.RadioButton11.UseVisualStyleBackColor = True
        '
        'RadioButton12
        '
        Me.RadioButton12.AutoSize = True
        Me.RadioButton12.Location = New System.Drawing.Point(6, 89)
        Me.RadioButton12.Name = "RadioButton12"
        Me.RadioButton12.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton12.TabIndex = 4
        Me.RadioButton12.TabStop = True
        Me.RadioButton12.Text = "4"
        Me.RadioButton12.UseVisualStyleBackColor = True
        '
        'RadioButton13
        '
        Me.RadioButton13.AutoSize = True
        Me.RadioButton13.Location = New System.Drawing.Point(7, 66)
        Me.RadioButton13.Name = "RadioButton13"
        Me.RadioButton13.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton13.TabIndex = 3
        Me.RadioButton13.TabStop = True
        Me.RadioButton13.Text = "3"
        Me.RadioButton13.UseVisualStyleBackColor = True
        '
        'RadioButton14
        '
        Me.RadioButton14.AutoSize = True
        Me.RadioButton14.Location = New System.Drawing.Point(7, 43)
        Me.RadioButton14.Name = "RadioButton14"
        Me.RadioButton14.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton14.TabIndex = 2
        Me.RadioButton14.TabStop = True
        Me.RadioButton14.Text = "2"
        Me.RadioButton14.UseVisualStyleBackColor = True
        '
        'RadioButton15
        '
        Me.RadioButton15.AutoSize = True
        Me.RadioButton15.Location = New System.Drawing.Point(7, 20)
        Me.RadioButton15.Name = "RadioButton15"
        Me.RadioButton15.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton15.TabIndex = 0
        Me.RadioButton15.TabStop = True
        Me.RadioButton15.Text = "1"
        Me.RadioButton15.UseVisualStyleBackColor = True
        '
        'gbProductExplination
        '
        Me.gbProductExplination.Controls.Add(Me.RadioButton6)
        Me.gbProductExplination.Controls.Add(Me.RadioButton7)
        Me.gbProductExplination.Controls.Add(Me.RadioButton8)
        Me.gbProductExplination.Controls.Add(Me.RadioButton9)
        Me.gbProductExplination.Controls.Add(Me.RadioButton10)
        Me.gbProductExplination.Location = New System.Drawing.Point(260, 259)
        Me.gbProductExplination.Name = "gbProductExplination"
        Me.gbProductExplination.Size = New System.Drawing.Size(118, 138)
        Me.gbProductExplination.TabIndex = 7
        Me.gbProductExplination.TabStop = False
        Me.gbProductExplination.Text = "Product explanation"
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Location = New System.Drawing.Point(6, 112)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton6.TabIndex = 5
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Text = "5"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.Location = New System.Drawing.Point(6, 89)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton7.TabIndex = 4
        Me.RadioButton7.TabStop = True
        Me.RadioButton7.Text = "4"
        Me.RadioButton7.UseVisualStyleBackColor = True
        '
        'RadioButton8
        '
        Me.RadioButton8.AutoSize = True
        Me.RadioButton8.Location = New System.Drawing.Point(7, 66)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton8.TabIndex = 3
        Me.RadioButton8.TabStop = True
        Me.RadioButton8.Text = "3"
        Me.RadioButton8.UseVisualStyleBackColor = True
        '
        'RadioButton9
        '
        Me.RadioButton9.AutoSize = True
        Me.RadioButton9.Location = New System.Drawing.Point(7, 43)
        Me.RadioButton9.Name = "RadioButton9"
        Me.RadioButton9.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton9.TabIndex = 2
        Me.RadioButton9.TabStop = True
        Me.RadioButton9.Text = "2"
        Me.RadioButton9.UseVisualStyleBackColor = True
        '
        'RadioButton10
        '
        Me.RadioButton10.AutoSize = True
        Me.RadioButton10.Location = New System.Drawing.Point(7, 20)
        Me.RadioButton10.Name = "RadioButton10"
        Me.RadioButton10.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton10.TabIndex = 0
        Me.RadioButton10.TabStop = True
        Me.RadioButton10.Text = "1"
        Me.RadioButton10.UseVisualStyleBackColor = True
        '
        'gbTelephoneEtiquette
        '
        Me.gbTelephoneEtiquette.Controls.Add(Me.RadioButton1)
        Me.gbTelephoneEtiquette.Controls.Add(Me.RadioButton2)
        Me.gbTelephoneEtiquette.Controls.Add(Me.RadioButton3)
        Me.gbTelephoneEtiquette.Controls.Add(Me.RadioButton4)
        Me.gbTelephoneEtiquette.Controls.Add(Me.RadioButton5)
        Me.gbTelephoneEtiquette.Location = New System.Drawing.Point(136, 259)
        Me.gbTelephoneEtiquette.Name = "gbTelephoneEtiquette"
        Me.gbTelephoneEtiquette.Size = New System.Drawing.Size(118, 138)
        Me.gbTelephoneEtiquette.TabIndex = 6
        Me.gbTelephoneEtiquette.TabStop = False
        Me.gbTelephoneEtiquette.Text = "Telephone etiquette"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(6, 112)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton1.TabIndex = 5
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "5"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(6, 89)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton2.TabIndex = 4
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "4"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(7, 66)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton3.TabIndex = 3
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "3"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Location = New System.Drawing.Point(7, 43)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton4.TabIndex = 2
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "2"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Location = New System.Drawing.Point(7, 20)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(31, 17)
        Me.RadioButton5.TabIndex = 0
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Text = "1"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'gbAgentFriendliness
        '
        Me.gbAgentFriendliness.Controls.Add(Me.rbFreind5)
        Me.gbAgentFriendliness.Controls.Add(Me.rbFreind4)
        Me.gbAgentFriendliness.Controls.Add(Me.rbFreind3)
        Me.gbAgentFriendliness.Controls.Add(Me.rbFreind2)
        Me.gbAgentFriendliness.Controls.Add(Me.rbFreind1)
        Me.gbAgentFriendliness.Location = New System.Drawing.Point(24, 259)
        Me.gbAgentFriendliness.Name = "gbAgentFriendliness"
        Me.gbAgentFriendliness.Size = New System.Drawing.Size(106, 138)
        Me.gbAgentFriendliness.TabIndex = 4
        Me.gbAgentFriendliness.TabStop = False
        Me.gbAgentFriendliness.Text = "Agent friendliness"
        '
        'rbFreind5
        '
        Me.rbFreind5.AutoSize = True
        Me.rbFreind5.Location = New System.Drawing.Point(6, 112)
        Me.rbFreind5.Name = "rbFreind5"
        Me.rbFreind5.Size = New System.Drawing.Size(31, 17)
        Me.rbFreind5.TabIndex = 5
        Me.rbFreind5.TabStop = True
        Me.rbFreind5.Text = "5"
        Me.rbFreind5.UseVisualStyleBackColor = True
        '
        'rbFreind4
        '
        Me.rbFreind4.AutoSize = True
        Me.rbFreind4.Location = New System.Drawing.Point(6, 89)
        Me.rbFreind4.Name = "rbFreind4"
        Me.rbFreind4.Size = New System.Drawing.Size(31, 17)
        Me.rbFreind4.TabIndex = 4
        Me.rbFreind4.TabStop = True
        Me.rbFreind4.Text = "4"
        Me.rbFreind4.UseVisualStyleBackColor = True
        '
        'rbFreind3
        '
        Me.rbFreind3.AutoSize = True
        Me.rbFreind3.Location = New System.Drawing.Point(7, 66)
        Me.rbFreind3.Name = "rbFreind3"
        Me.rbFreind3.Size = New System.Drawing.Size(31, 17)
        Me.rbFreind3.TabIndex = 3
        Me.rbFreind3.TabStop = True
        Me.rbFreind3.Text = "3"
        Me.rbFreind3.UseVisualStyleBackColor = True
        '
        'rbFreind2
        '
        Me.rbFreind2.AutoSize = True
        Me.rbFreind2.Location = New System.Drawing.Point(7, 43)
        Me.rbFreind2.Name = "rbFreind2"
        Me.rbFreind2.Size = New System.Drawing.Size(31, 17)
        Me.rbFreind2.TabIndex = 2
        Me.rbFreind2.TabStop = True
        Me.rbFreind2.Text = "2"
        Me.rbFreind2.UseVisualStyleBackColor = True
        '
        'rbFreind1
        '
        Me.rbFreind1.AutoSize = True
        Me.rbFreind1.Location = New System.Drawing.Point(7, 20)
        Me.rbFreind1.Name = "rbFreind1"
        Me.rbFreind1.Size = New System.Drawing.Size(31, 17)
        Me.rbFreind1.TabIndex = 0
        Me.rbFreind1.TabStop = True
        Me.rbFreind1.Text = "1"
        Me.rbFreind1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Overall Comment"
        '
        'txOverallComment
        '
        Me.txOverallComment.Location = New System.Drawing.Point(21, 38)
        Me.txOverallComment.Multiline = True
        Me.txOverallComment.Name = "txOverallComment"
        Me.txOverallComment.Size = New System.Drawing.Size(672, 175)
        Me.txOverallComment.TabIndex = 2
        '
        'btSendBack
        '
        Me.btSendBack.Location = New System.Drawing.Point(699, 190)
        Me.btSendBack.Name = "btSendBack"
        Me.btSendBack.Size = New System.Drawing.Size(75, 23)
        Me.btSendBack.TabIndex = 1
        Me.btSendBack.Text = "Send Back"
        Me.btSendBack.UseVisualStyleBackColor = True
        '
        'btPass
        '
        Me.btPass.Location = New System.Drawing.Point(699, 38)
        Me.btPass.Name = "btPass"
        Me.btPass.Size = New System.Drawing.Size(75, 23)
        Me.btPass.TabIndex = 0
        Me.btPass.Text = "Pass"
        Me.btPass.UseVisualStyleBackColor = True
        '
        'tbHistory
        '
        Me.tbHistory.Controls.Add(Me.cbCalls)
        Me.tbHistory.Controls.Add(Me.cbComments)
        Me.tbHistory.Controls.Add(Me.cbChanges)
        Me.tbHistory.Controls.Add(Me.cbEvents)
        Me.tbHistory.Controls.Add(Me.dgHistory)
        Me.tbHistory.Location = New System.Drawing.Point(4, 22)
        Me.tbHistory.Name = "tbHistory"
        Me.tbHistory.Padding = New System.Windows.Forms.Padding(3)
        Me.tbHistory.Size = New System.Drawing.Size(785, 456)
        Me.tbHistory.TabIndex = 1
        Me.tbHistory.Text = "History"
        Me.tbHistory.UseVisualStyleBackColor = True
        '
        'cbCalls
        '
        Me.cbCalls.AutoSize = True
        Me.cbCalls.Location = New System.Drawing.Point(731, 7)
        Me.cbCalls.Name = "cbCalls"
        Me.cbCalls.Size = New System.Drawing.Size(48, 17)
        Me.cbCalls.TabIndex = 9
        Me.cbCalls.Text = "Calls"
        Me.cbCalls.UseVisualStyleBackColor = True
        '
        'cbComments
        '
        Me.cbComments.AutoSize = True
        Me.cbComments.Checked = True
        Me.cbComments.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbComments.Location = New System.Drawing.Point(435, 7)
        Me.cbComments.Name = "cbComments"
        Me.cbComments.Size = New System.Drawing.Size(75, 17)
        Me.cbComments.TabIndex = 8
        Me.cbComments.Text = "Comments"
        Me.cbComments.UseVisualStyleBackColor = True
        '
        'cbChanges
        '
        Me.cbChanges.AutoSize = True
        Me.cbChanges.Checked = True
        Me.cbChanges.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbChanges.Location = New System.Drawing.Point(203, 7)
        Me.cbChanges.Name = "cbChanges"
        Me.cbChanges.Size = New System.Drawing.Size(68, 17)
        Me.cbChanges.TabIndex = 7
        Me.cbChanges.Text = "Changes"
        Me.cbChanges.UseVisualStyleBackColor = True
        '
        'cbEvents
        '
        Me.cbEvents.AutoSize = True
        Me.cbEvents.Checked = True
        Me.cbEvents.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbEvents.Location = New System.Drawing.Point(6, 5)
        Me.cbEvents.Name = "cbEvents"
        Me.cbEvents.Size = New System.Drawing.Size(59, 17)
        Me.cbEvents.TabIndex = 6
        Me.cbEvents.Text = "Events"
        Me.cbEvents.UseVisualStyleBackColor = True
        '
        'dgHistory
        '
        Me.dgHistory.AllowUserToAddRows = False
        Me.dgHistory.AllowUserToDeleteRows = False
        Me.dgHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgHistory.Location = New System.Drawing.Point(6, 28)
        Me.dgHistory.Name = "dgHistory"
        Me.dgHistory.ReadOnly = True
        Me.dgHistory.RowHeadersVisible = False
        Me.dgHistory.Size = New System.Drawing.Size(773, 422)
        Me.dgHistory.TabIndex = 5
        '
        'btCopy
        '
        Me.btCopy.Location = New System.Drawing.Point(385, 464)
        Me.btCopy.Name = "btCopy"
        Me.btCopy.Size = New System.Drawing.Size(75, 23)
        Me.btCopy.TabIndex = 2
        Me.btCopy.Text = "Copy"
        Me.btCopy.UseVisualStyleBackColor = True
        '
        'btTransfer
        '
        Me.btTransfer.Location = New System.Drawing.Point(699, 273)
        Me.btTransfer.Name = "btTransfer"
        Me.btTransfer.Size = New System.Drawing.Size(75, 23)
        Me.btTransfer.TabIndex = 11
        Me.btTransfer.Text = "Transfer"
        Me.btTransfer.UseVisualStyleBackColor = True
        '
        'frmQaView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1271, 499)
        Me.Controls.Add(Me.btCopy)
        Me.Controls.Add(Me.tbControl)
        Me.Controls.Add(Me.gbLeadDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmQaView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmQaView"
        Me.gbLeadDetails.ResumeLayout(False)
        CType(Me.dgleadInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.gbClientUnderstanding.ResumeLayout(False)
        Me.gbClientUnderstanding.PerformLayout()
        Me.gbProductExplination.ResumeLayout(False)
        Me.gbProductExplination.PerformLayout()
        Me.gbTelephoneEtiquette.ResumeLayout(False)
        Me.gbTelephoneEtiquette.PerformLayout()
        Me.gbAgentFriendliness.ResumeLayout(False)
        Me.gbAgentFriendliness.PerformLayout()
        Me.tbHistory.ResumeLayout(False)
        Me.tbHistory.PerformLayout()
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbLeadDetails As System.Windows.Forms.GroupBox
    Friend WithEvents tbControl As System.Windows.Forms.TabControl
    Friend WithEvents dgleadInfo As System.Windows.Forms.DataGridView
    Friend WithEvents btCopy As System.Windows.Forms.Button
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents gbAgentFriendliness As System.Windows.Forms.GroupBox
    Friend WithEvents rbFreind5 As System.Windows.Forms.RadioButton
    Friend WithEvents rbFreind4 As System.Windows.Forms.RadioButton
    Friend WithEvents rbFreind3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbFreind2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbFreind1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txOverallComment As System.Windows.Forms.TextBox
    Friend WithEvents btSendBack As System.Windows.Forms.Button
    Friend WithEvents btPass As System.Windows.Forms.Button
    Friend WithEvents btBypass As System.Windows.Forms.Button
    Friend WithEvents gbClientUnderstanding As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton11 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton12 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton13 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton14 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton15 As System.Windows.Forms.RadioButton
    Friend WithEvents gbProductExplination As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton9 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton10 As System.Windows.Forms.RadioButton
    Friend WithEvents gbTelephoneEtiquette As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents btSave As System.Windows.Forms.Button
    Friend WithEvents tbHistory As System.Windows.Forms.TabPage
    Friend WithEvents cbCalls As System.Windows.Forms.CheckBox
    Friend WithEvents cbComments As System.Windows.Forms.CheckBox
    Friend WithEvents cbChanges As System.Windows.Forms.CheckBox
    Friend WithEvents cbEvents As System.Windows.Forms.CheckBox
    Friend WithEvents dgHistory As System.Windows.Forms.DataGridView
    Friend WithEvents btTransfer As Button
End Class
