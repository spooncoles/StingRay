<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangeTempAffinity
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
        Me.dgTempAffinities = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txNewAdminCode = New System.Windows.Forms.TextBox()
        Me.btConfirm = New System.Windows.Forms.Button()
        Me.cbSalesOnly = New System.Windows.Forms.CheckBox()
        CType(Me.dgTempAffinities, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgTempAffinities
        '
        Me.dgTempAffinities.AllowUserToAddRows = False
        Me.dgTempAffinities.AllowUserToDeleteRows = False
        Me.dgTempAffinities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTempAffinities.Location = New System.Drawing.Point(13, 13)
        Me.dgTempAffinities.MultiSelect = False
        Me.dgTempAffinities.Name = "dgTempAffinities"
        Me.dgTempAffinities.ReadOnly = True
        Me.dgTempAffinities.RowHeadersVisible = False
        Me.dgTempAffinities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTempAffinities.Size = New System.Drawing.Size(320, 373)
        Me.dgTempAffinities.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(339, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Change code to:"
        '
        'txNewAdminCode
        '
        Me.txNewAdminCode.Location = New System.Drawing.Point(342, 30)
        Me.txNewAdminCode.MaxLength = 20
        Me.txNewAdminCode.Name = "txNewAdminCode"
        Me.txNewAdminCode.Size = New System.Drawing.Size(100, 20)
        Me.txNewAdminCode.TabIndex = 2
        '
        'btConfirm
        '
        Me.btConfirm.Location = New System.Drawing.Point(342, 362)
        Me.btConfirm.Name = "btConfirm"
        Me.btConfirm.Size = New System.Drawing.Size(100, 23)
        Me.btConfirm.TabIndex = 3
        Me.btConfirm.Text = "Confirm Change"
        Me.btConfirm.UseVisualStyleBackColor = True
        '
        'cbSalesOnly
        '
        Me.cbSalesOnly.AutoSize = True
        Me.cbSalesOnly.Checked = True
        Me.cbSalesOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSalesOnly.Location = New System.Drawing.Point(342, 142)
        Me.cbSalesOnly.Name = "cbSalesOnly"
        Me.cbSalesOnly.Size = New System.Drawing.Size(76, 17)
        Me.cbSalesOnly.TabIndex = 4
        Me.cbSalesOnly.Text = "Sales Only"
        Me.cbSalesOnly.UseVisualStyleBackColor = True
        '
        'frmChangeTempAffinity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 397)
        Me.Controls.Add(Me.cbSalesOnly)
        Me.Controls.Add(Me.btConfirm)
        Me.Controls.Add(Me.txNewAdminCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgTempAffinities)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmChangeTempAffinity"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Temp Affinity"
        CType(Me.dgTempAffinities, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgTempAffinities As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txNewAdminCode As System.Windows.Forms.TextBox
    Friend WithEvents btConfirm As System.Windows.Forms.Button
    Friend WithEvents cbSalesOnly As System.Windows.Forms.CheckBox
End Class
