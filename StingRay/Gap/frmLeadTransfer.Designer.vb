<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeadTransfer
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
        Me.lbLeadID = New System.Windows.Forms.Label()
        Me.lbName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbAgent = New System.Windows.Forms.ComboBox()
        Me.txReason = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btTransfer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lbLeadID
        '
        Me.lbLeadID.AutoSize = True
        Me.lbLeadID.Location = New System.Drawing.Point(66, 9)
        Me.lbLeadID.Name = "lbLeadID"
        Me.lbLeadID.Size = New System.Drawing.Size(39, 13)
        Me.lbLeadID.TabIndex = 0
        Me.lbLeadID.Text = "Label1"
        '
        'lbName
        '
        Me.lbName.AutoSize = True
        Me.lbName.Location = New System.Drawing.Point(65, 22)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(39, 13)
        Me.lbName.TabIndex = 1
        Me.lbName.Text = "Label2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Name: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Lead ID:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Agent to transfer to: "
        '
        'cbAgent
        '
        Me.cbAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAgent.FormattingEnabled = True
        Me.cbAgent.Location = New System.Drawing.Point(13, 88)
        Me.cbAgent.Name = "cbAgent"
        Me.cbAgent.Size = New System.Drawing.Size(180, 21)
        Me.cbAgent.TabIndex = 7
        '
        'txReason
        '
        Me.txReason.Location = New System.Drawing.Point(13, 152)
        Me.txReason.Multiline = True
        Me.txReason.Name = "txReason"
        Me.txReason.Size = New System.Drawing.Size(180, 49)
        Me.txReason.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Reason for transfer:"
        '
        'btTransfer
        '
        Me.btTransfer.Location = New System.Drawing.Point(13, 208)
        Me.btTransfer.Name = "btTransfer"
        Me.btTransfer.Size = New System.Drawing.Size(180, 23)
        Me.btTransfer.TabIndex = 10
        Me.btTransfer.Text = "Transfer Lead"
        Me.btTransfer.UseVisualStyleBackColor = True
        '
        'frmLeadTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(203, 239)
        Me.Controls.Add(Me.btTransfer)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txReason)
        Me.Controls.Add(Me.cbAgent)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbName)
        Me.Controls.Add(Me.lbLeadID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmLeadTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLeadTransfer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbLeadID As System.Windows.Forms.Label
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbAgent As System.Windows.Forms.ComboBox
    Friend WithEvents txReason As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btTransfer As System.Windows.Forms.Button
End Class
