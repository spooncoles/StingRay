<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAfterLead
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
        Me.lbHeader = New System.Windows.Forms.Label()
        Me.btNextInQueue = New System.Windows.Forms.Button()
        Me.btFindLead = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btBreak = New System.Windows.Forms.Button()
        Me.lbRescheduleNextHour = New System.Windows.Forms.Label()
        Me.gbNextHour = New System.Windows.Forms.GroupBox()
        Me.btNextHourQueue = New System.Windows.Forms.Button()
        Me.btNextHourView = New System.Windows.Forms.Button()
        Me.gbOverdue = New System.Windows.Forms.GroupBox()
        Me.btOverdueView = New System.Windows.Forms.Button()
        Me.btOverdueQueue = New System.Windows.Forms.Button()
        Me.lbRescheduleOverdue = New System.Windows.Forms.Label()
        Me.gbNextHour.SuspendLayout()
        Me.gbOverdue.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbHeader
        '
        Me.lbHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHeader.Location = New System.Drawing.Point(5, 1)
        Me.lbHeader.Name = "lbHeader"
        Me.lbHeader.Size = New System.Drawing.Size(310, 55)
        Me.lbHeader.TabIndex = 0
        Me.lbHeader.Text = "Thank-you! What would you like to do next?"
        Me.lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btNextInQueue
        '
        Me.btNextInQueue.Location = New System.Drawing.Point(5, 59)
        Me.btNextInQueue.Name = "btNextInQueue"
        Me.btNextInQueue.Size = New System.Drawing.Size(152, 89)
        Me.btNextInQueue.TabIndex = 1
        Me.btNextInQueue.Text = "Next in Queue"
        Me.btNextInQueue.UseVisualStyleBackColor = True
        '
        'btFindLead
        '
        Me.btFindLead.Location = New System.Drawing.Point(163, 59)
        Me.btFindLead.Name = "btFindLead"
        Me.btFindLead.Size = New System.Drawing.Size(152, 89)
        Me.btFindLead.TabIndex = 2
        Me.btFindLead.Text = "Find a Lead"
        Me.btFindLead.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(5, 154)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(152, 89)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Sales Stats"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btBreak
        '
        Me.btBreak.Location = New System.Drawing.Point(163, 154)
        Me.btBreak.Name = "btBreak"
        Me.btBreak.Size = New System.Drawing.Size(152, 89)
        Me.btBreak.TabIndex = 4
        Me.btBreak.Text = "Take a Break"
        Me.btBreak.UseVisualStyleBackColor = True
        '
        'lbRescheduleNextHour
        '
        Me.lbRescheduleNextHour.AutoSize = True
        Me.lbRescheduleNextHour.Location = New System.Drawing.Point(6, 26)
        Me.lbRescheduleNextHour.Name = "lbRescheduleNextHour"
        Me.lbRescheduleNextHour.Size = New System.Drawing.Size(49, 13)
        Me.lbRescheduleNextHour.TabIndex = 5
        Me.lbRescheduleNextHour.Text = "######"
        '
        'gbNextHour
        '
        Me.gbNextHour.Controls.Add(Me.btNextHourQueue)
        Me.gbNextHour.Controls.Add(Me.btNextHourView)
        Me.gbNextHour.Controls.Add(Me.lbRescheduleNextHour)
        Me.gbNextHour.Location = New System.Drawing.Point(8, 249)
        Me.gbNextHour.Name = "gbNextHour"
        Me.gbNextHour.Size = New System.Drawing.Size(307, 60)
        Me.gbNextHour.TabIndex = 7
        Me.gbNextHour.TabStop = False
        Me.gbNextHour.Text = "Reschedules for the next hour:"
        '
        'btNextHourQueue
        '
        Me.btNextHourQueue.Location = New System.Drawing.Point(114, 26)
        Me.btNextHourQueue.Name = "btNextHourQueue"
        Me.btNextHourQueue.Size = New System.Drawing.Size(86, 25)
        Me.btNextHourQueue.TabIndex = 6
        Me.btNextHourQueue.Text = "Add to Queue"
        Me.btNextHourQueue.UseVisualStyleBackColor = True
        '
        'btNextHourView
        '
        Me.btNextHourView.Location = New System.Drawing.Point(215, 26)
        Me.btNextHourView.Name = "btNextHourView"
        Me.btNextHourView.Size = New System.Drawing.Size(86, 25)
        Me.btNextHourView.TabIndex = 9
        Me.btNextHourView.Text = "View Leads"
        Me.btNextHourView.UseVisualStyleBackColor = True
        '
        'gbOverdue
        '
        Me.gbOverdue.Controls.Add(Me.btOverdueView)
        Me.gbOverdue.Controls.Add(Me.btOverdueQueue)
        Me.gbOverdue.Controls.Add(Me.lbRescheduleOverdue)
        Me.gbOverdue.Location = New System.Drawing.Point(8, 315)
        Me.gbOverdue.Name = "gbOverdue"
        Me.gbOverdue.Size = New System.Drawing.Size(307, 60)
        Me.gbOverdue.TabIndex = 8
        Me.gbOverdue.TabStop = False
        Me.gbOverdue.Text = "Reschedules overdue:"
        '
        'btOverdueView
        '
        Me.btOverdueView.Location = New System.Drawing.Point(215, 27)
        Me.btOverdueView.Name = "btOverdueView"
        Me.btOverdueView.Size = New System.Drawing.Size(86, 25)
        Me.btOverdueView.TabIndex = 10
        Me.btOverdueView.Text = "View Leads"
        Me.btOverdueView.UseVisualStyleBackColor = True
        '
        'btOverdueQueue
        '
        Me.btOverdueQueue.Location = New System.Drawing.Point(114, 27)
        Me.btOverdueQueue.Name = "btOverdueQueue"
        Me.btOverdueQueue.Size = New System.Drawing.Size(86, 25)
        Me.btOverdueQueue.TabIndex = 7
        Me.btOverdueQueue.Text = "Add to Queue"
        Me.btOverdueQueue.UseVisualStyleBackColor = True
        '
        'lbRescheduleOverdue
        '
        Me.lbRescheduleOverdue.AutoSize = True
        Me.lbRescheduleOverdue.Location = New System.Drawing.Point(6, 27)
        Me.lbRescheduleOverdue.Name = "lbRescheduleOverdue"
        Me.lbRescheduleOverdue.Size = New System.Drawing.Size(49, 13)
        Me.lbRescheduleOverdue.TabIndex = 5
        Me.lbRescheduleOverdue.Text = "######"
        '
        'frmAfterLead
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 384)
        Me.Controls.Add(Me.gbOverdue)
        Me.Controls.Add(Me.gbNextHour)
        Me.Controls.Add(Me.btBreak)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btFindLead)
        Me.Controls.Add(Me.btNextInQueue)
        Me.Controls.Add(Me.lbHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAfterLead"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAfterLead"
        Me.gbNextHour.ResumeLayout(False)
        Me.gbNextHour.PerformLayout()
        Me.gbOverdue.ResumeLayout(False)
        Me.gbOverdue.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbHeader As System.Windows.Forms.Label
    Friend WithEvents btNextInQueue As System.Windows.Forms.Button
    Friend WithEvents btFindLead As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btBreak As System.Windows.Forms.Button
    Friend WithEvents lbRescheduleNextHour As System.Windows.Forms.Label
    Friend WithEvents gbNextHour As System.Windows.Forms.GroupBox
    Friend WithEvents btNextHourQueue As System.Windows.Forms.Button
    Friend WithEvents btNextHourView As System.Windows.Forms.Button
    Friend WithEvents gbOverdue As System.Windows.Forms.GroupBox
    Friend WithEvents btOverdueView As System.Windows.Forms.Button
    Friend WithEvents btOverdueQueue As System.Windows.Forms.Button
    Friend WithEvents lbRescheduleOverdue As System.Windows.Forms.Label
End Class
