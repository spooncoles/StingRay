<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIncentives
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbIncentive = New System.Windows.Forms.TabPage()
        Me.btExport = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tbIncentive.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbIncentive)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(232, 65)
        Me.TabControl1.TabIndex = 0
        '
        'tbIncentive
        '
        Me.tbIncentive.Controls.Add(Me.btExport)
        Me.tbIncentive.Location = New System.Drawing.Point(4, 22)
        Me.tbIncentive.Name = "tbIncentive"
        Me.tbIncentive.Padding = New System.Windows.Forms.Padding(3)
        Me.tbIncentive.Size = New System.Drawing.Size(224, 39)
        Me.tbIncentive.TabIndex = 0
        Me.tbIncentive.Text = "Incentive Export"
        Me.tbIncentive.UseVisualStyleBackColor = True
        '
        'btExport
        '
        Me.btExport.Location = New System.Drawing.Point(8, 6)
        Me.btExport.Name = "btExport"
        Me.btExport.Size = New System.Drawing.Size(203, 23)
        Me.btExport.TabIndex = 0
        Me.btExport.Text = "Export Latest Incentive"
        Me.btExport.UseVisualStyleBackColor = True
        '
        'frmIncentives
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(232, 65)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmIncentives"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Incentives"
        Me.TabControl1.ResumeLayout(False)
        Me.tbIncentive.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbIncentive As System.Windows.Forms.TabPage
    Friend WithEvents btExport As System.Windows.Forms.Button
End Class
