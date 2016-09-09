<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmQANonSale
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgleadInfo = New System.Windows.Forms.DataGridView()
        Me.gbStatus = New System.Windows.Forms.GroupBox()
        Me.cbStatusCaptured = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbStatus = New System.Windows.Forms.ComboBox()
        Me.cbOutcome = New System.Windows.Forms.ComboBox()
        Me.gbTelephoneEtiquette = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.gbFriendliness = New System.Windows.Forms.GroupBox()
        Me.rbFreind5 = New System.Windows.Forms.RadioButton()
        Me.rbFreind4 = New System.Windows.Forms.RadioButton()
        Me.rbFreind3 = New System.Windows.Forms.RadioButton()
        Me.rbFreind2 = New System.Windows.Forms.RadioButton()
        Me.rbFreind1 = New System.Windows.Forms.RadioButton()
        Me.txImprovementComment = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txOverallComment = New System.Windows.Forms.TextBox()
        Me.btSubmit = New System.Windows.Forms.Button()
        CType(Me.dgleadInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbStatus.SuspendLayout()
        Me.gbTelephoneEtiquette.SuspendLayout()
        Me.gbFriendliness.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgleadInfo
        '
        Me.dgleadInfo.AllowUserToAddRows = False
        Me.dgleadInfo.AllowUserToDeleteRows = False
        Me.dgleadInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgleadInfo.Location = New System.Drawing.Point(8, 8)
        Me.dgleadInfo.Name = "dgleadInfo"
        Me.dgleadInfo.RowHeadersVisible = False
        Me.dgleadInfo.Size = New System.Drawing.Size(258, 297)
        Me.dgleadInfo.TabIndex = 2
        '
        'gbStatus
        '
        Me.gbStatus.Controls.Add(Me.cbOutcome)
        Me.gbStatus.Controls.Add(Me.cbStatus)
        Me.gbStatus.Controls.Add(Me.Label2)
        Me.gbStatus.Controls.Add(Me.Label1)
        Me.gbStatus.Controls.Add(Me.cbStatusCaptured)
        Me.gbStatus.Location = New System.Drawing.Point(273, 8)
        Me.gbStatus.Name = "gbStatus"
        Me.gbStatus.Size = New System.Drawing.Size(230, 112)
        Me.gbStatus.TabIndex = 3
        Me.gbStatus.TabStop = False
        Me.gbStatus.Text = "Status"
        '
        'cbStatusCaptured
        '
        Me.cbStatusCaptured.AutoSize = True
        Me.cbStatusCaptured.Location = New System.Drawing.Point(14, 21)
        Me.cbStatusCaptured.Name = "cbStatusCaptured"
        Me.cbStatusCaptured.Size = New System.Drawing.Size(179, 17)
        Me.cbStatusCaptured.TabIndex = 0
        Me.cbStatusCaptured.Text = "The correct status was captured"
        Me.cbStatusCaptured.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Status"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Outcome"
        '
        'cbStatus
        '
        Me.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbStatus.FormattingEnabled = True
        Me.cbStatus.Location = New System.Drawing.Point(67, 52)
        Me.cbStatus.Name = "cbStatus"
        Me.cbStatus.Size = New System.Drawing.Size(157, 21)
        Me.cbStatus.TabIndex = 3
        '
        'cbOutcome
        '
        Me.cbOutcome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOutcome.Enabled = False
        Me.cbOutcome.FormattingEnabled = True
        Me.cbOutcome.Location = New System.Drawing.Point(67, 79)
        Me.cbOutcome.Name = "cbOutcome"
        Me.cbOutcome.Size = New System.Drawing.Size(157, 21)
        Me.cbOutcome.TabIndex = 4
        '
        'gbTelephoneEtiquette
        '
        Me.gbTelephoneEtiquette.Controls.Add(Me.RadioButton1)
        Me.gbTelephoneEtiquette.Controls.Add(Me.RadioButton2)
        Me.gbTelephoneEtiquette.Controls.Add(Me.RadioButton3)
        Me.gbTelephoneEtiquette.Controls.Add(Me.RadioButton4)
        Me.gbTelephoneEtiquette.Controls.Add(Me.RadioButton5)
        Me.gbTelephoneEtiquette.Location = New System.Drawing.Point(385, 126)
        Me.gbTelephoneEtiquette.Name = "gbTelephoneEtiquette"
        Me.gbTelephoneEtiquette.Size = New System.Drawing.Size(118, 138)
        Me.gbTelephoneEtiquette.TabIndex = 8
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
        'gbFriendliness
        '
        Me.gbFriendliness.Controls.Add(Me.rbFreind5)
        Me.gbFriendliness.Controls.Add(Me.rbFreind4)
        Me.gbFriendliness.Controls.Add(Me.rbFreind3)
        Me.gbFriendliness.Controls.Add(Me.rbFreind2)
        Me.gbFriendliness.Controls.Add(Me.rbFreind1)
        Me.gbFriendliness.Location = New System.Drawing.Point(273, 126)
        Me.gbFriendliness.Name = "gbFriendliness"
        Me.gbFriendliness.Size = New System.Drawing.Size(106, 138)
        Me.gbFriendliness.TabIndex = 7
        Me.gbFriendliness.TabStop = False
        Me.gbFriendliness.Text = "Agent friendliness"
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
        'txImprovementComment
        '
        Me.txImprovementComment.Location = New System.Drawing.Point(512, 25)
        Me.txImprovementComment.Multiline = True
        Me.txImprovementComment.Name = "txImprovementComment"
        Me.txImprovementComment.Size = New System.Drawing.Size(272, 91)
        Me.txImprovementComment.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(509, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Improvement Comment"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(509, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Overall Comment"
        '
        'txOverallComment
        '
        Me.txOverallComment.Location = New System.Drawing.Point(512, 142)
        Me.txOverallComment.Multiline = True
        Me.txOverallComment.Name = "txOverallComment"
        Me.txOverallComment.Size = New System.Drawing.Size(272, 91)
        Me.txOverallComment.TabIndex = 11
        '
        'btSubmit
        '
        Me.btSubmit.Location = New System.Drawing.Point(273, 281)
        Me.btSubmit.Name = "btSubmit"
        Me.btSubmit.Size = New System.Drawing.Size(230, 23)
        Me.btSubmit.TabIndex = 13
        Me.btSubmit.Text = "Submit"
        Me.btSubmit.UseVisualStyleBackColor = True
        '
        'frmQANonSale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 310)
        Me.Controls.Add(Me.btSubmit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txOverallComment)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txImprovementComment)
        Me.Controls.Add(Me.gbTelephoneEtiquette)
        Me.Controls.Add(Me.gbFriendliness)
        Me.Controls.Add(Me.gbStatus)
        Me.Controls.Add(Me.dgleadInfo)
        Me.Name = "frmQANonSale"
        Me.Text = "QA Non Sale"
        CType(Me.dgleadInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbStatus.ResumeLayout(False)
        Me.gbStatus.PerformLayout()
        Me.gbTelephoneEtiquette.ResumeLayout(False)
        Me.gbTelephoneEtiquette.PerformLayout()
        Me.gbFriendliness.ResumeLayout(False)
        Me.gbFriendliness.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgleadInfo As DataGridView
    Friend WithEvents gbStatus As GroupBox
    Friend WithEvents cbOutcome As ComboBox
    Friend WithEvents cbStatus As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbStatusCaptured As CheckBox
    Friend WithEvents gbTelephoneEtiquette As GroupBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents gbFriendliness As GroupBox
    Friend WithEvents rbFreind5 As RadioButton
    Friend WithEvents rbFreind4 As RadioButton
    Friend WithEvents rbFreind3 As RadioButton
    Friend WithEvents rbFreind2 As RadioButton
    Friend WithEvents rbFreind1 As RadioButton
    Friend WithEvents txImprovementComment As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txOverallComment As TextBox
    Friend WithEvents btSubmit As Button
End Class
