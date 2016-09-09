<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQaFaults
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
        Me.lbQaAgent = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txOverAllComment = New System.Windows.Forms.TextBox()
        Me.dgFaults = New System.Windows.Forms.DataGridView()
        Me.btAcceptFail = New System.Windows.Forms.Button()
        CType(Me.dgFaults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Overall Comment:"
        '
        'lbQaAgent
        '
        Me.lbQaAgent.AutoSize = True
        Me.lbQaAgent.Location = New System.Drawing.Point(15, 15)
        Me.lbQaAgent.Name = "lbQaAgent"
        Me.lbQaAgent.Size = New System.Drawing.Size(93, 13)
        Me.lbQaAgent.TabIndex = 1
        Me.lbQaAgent.Text = "QA Agent = ####"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 240)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Failed Questions:"
        '
        'txOverAllComment
        '
        Me.txOverAllComment.Enabled = False
        Me.txOverAllComment.Location = New System.Drawing.Point(13, 54)
        Me.txOverAllComment.Multiline = True
        Me.txOverAllComment.Name = "txOverAllComment"
        Me.txOverAllComment.Size = New System.Drawing.Size(289, 173)
        Me.txOverAllComment.TabIndex = 3
        '
        'dgFaults
        '
        Me.dgFaults.AllowUserToAddRows = False
        Me.dgFaults.AllowUserToDeleteRows = False
        Me.dgFaults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgFaults.Location = New System.Drawing.Point(13, 257)
        Me.dgFaults.Name = "dgFaults"
        Me.dgFaults.ReadOnly = True
        Me.dgFaults.RowHeadersVisible = False
        Me.dgFaults.Size = New System.Drawing.Size(289, 294)
        Me.dgFaults.TabIndex = 4
        '
        'btAcceptFail
        '
        Me.btAcceptFail.Location = New System.Drawing.Point(227, 14)
        Me.btAcceptFail.Name = "btAcceptFail"
        Me.btAcceptFail.Size = New System.Drawing.Size(74, 23)
        Me.btAcceptFail.TabIndex = 5
        Me.btAcceptFail.Text = "Accept Fail"
        Me.btAcceptFail.UseVisualStyleBackColor = True
        '
        'frmQaFaults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 563)
        Me.ControlBox = False
        Me.Controls.Add(Me.btAcceptFail)
        Me.Controls.Add(Me.dgFaults)
        Me.Controls.Add(Me.txOverAllComment)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbQaAgent)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "frmQaFaults"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmQaFaults"
        CType(Me.dgFaults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbQaAgent As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txOverAllComment As System.Windows.Forms.TextBox
    Friend WithEvents dgFaults As System.Windows.Forms.DataGridView
    Friend WithEvents btAcceptFail As System.Windows.Forms.Button
End Class
