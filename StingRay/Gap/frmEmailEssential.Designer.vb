<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmailEssential
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btEmail = New System.Windows.Forms.Button()
        Me.btCancel = New System.Windows.Forms.Button()
        Me.cbCallTime = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbLeadID = New System.Windows.Forms.Label()
        Me.txComment = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Send the below lead to the " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Essential Med agent to pitch?"
        '
        'btEmail
        '
        Me.btEmail.Location = New System.Drawing.Point(12, 226)
        Me.btEmail.Name = "btEmail"
        Me.btEmail.Size = New System.Drawing.Size(110, 23)
        Me.btEmail.TabIndex = 1
        Me.btEmail.Text = "Email"
        Me.btEmail.UseVisualStyleBackColor = True
        '
        'btCancel
        '
        Me.btCancel.Location = New System.Drawing.Point(162, 226)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(110, 23)
        Me.btCancel.TabIndex = 2
        Me.btCancel.Text = "Cancel"
        Me.btCancel.UseVisualStyleBackColor = True
        '
        'cbCallTime
        '
        Me.cbCallTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCallTime.FormattingEnabled = True
        Me.cbCallTime.Items.AddRange(New Object() {"Anytime", "Moning", "Noon", "Afternoon"})
        Me.cbCallTime.Location = New System.Drawing.Point(14, 108)
        Me.cbCallTime.Name = "cbCallTime"
        Me.cbCallTime.Size = New System.Drawing.Size(256, 21)
        Me.cbCallTime.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Call back time"
        '
        'lbLeadID
        '
        Me.lbLeadID.AutoSize = True
        Me.lbLeadID.Location = New System.Drawing.Point(16, 62)
        Me.lbLeadID.Name = "lbLeadID"
        Me.lbLeadID.Size = New System.Drawing.Size(82, 13)
        Me.lbLeadID.TabIndex = 6
        Me.lbLeadID.Text = "LeadID = ####"
        '
        'txComment
        '
        Me.txComment.Location = New System.Drawing.Point(13, 158)
        Me.txComment.Multiline = True
        Me.txComment.Name = "txComment"
        Me.txComment.Size = New System.Drawing.Size(254, 56)
        Me.txComment.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Comment"
        '
        'frmEmailEssential
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txComment)
        Me.Controls.Add(Me.lbLeadID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbCallTime)
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.btEmail)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmEmailEssential"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Email Essential"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btEmail As Button
    Friend WithEvents btCancel As Button
    Friend WithEvents cbCallTime As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lbLeadID As Label
    Friend WithEvents txComment As TextBox
    Friend WithEvents Label3 As Label
End Class
