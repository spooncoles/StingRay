<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeadHistory
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
        Me.cbCalls = New System.Windows.Forms.CheckBox()
        Me.cbComments = New System.Windows.Forms.CheckBox()
        Me.cbChanges = New System.Windows.Forms.CheckBox()
        Me.cbEvents = New System.Windows.Forms.CheckBox()
        Me.dgHistory = New System.Windows.Forms.DataGridView()
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbCalls
        '
        Me.cbCalls.AutoSize = True
        Me.cbCalls.Location = New System.Drawing.Point(632, 11)
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
        Me.cbComments.Location = New System.Drawing.Point(441, 11)
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
        Me.cbChanges.Location = New System.Drawing.Point(209, 11)
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
        Me.cbEvents.Location = New System.Drawing.Point(12, 9)
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
        Me.dgHistory.Location = New System.Drawing.Point(12, 32)
        Me.dgHistory.Name = "dgHistory"
        Me.dgHistory.ReadOnly = True
        Me.dgHistory.RowHeadersVisible = False
        Me.dgHistory.Size = New System.Drawing.Size(668, 336)
        Me.dgHistory.TabIndex = 5
        '
        'frmLeadHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 380)
        Me.Controls.Add(Me.cbCalls)
        Me.Controls.Add(Me.cbComments)
        Me.Controls.Add(Me.cbChanges)
        Me.Controls.Add(Me.cbEvents)
        Me.Controls.Add(Me.dgHistory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmLeadHistory"
        Me.Text = "Lead History"
        CType(Me.dgHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbCalls As CheckBox
    Friend WithEvents cbComments As CheckBox
    Friend WithEvents cbChanges As CheckBox
    Friend WithEvents cbEvents As CheckBox
    Friend WithEvents dgHistory As DataGridView
End Class
