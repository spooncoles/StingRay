<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQaStats
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
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgStats = New System.Windows.Forms.DataGridView()
        Me.dgAgentStats = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btRefresh = New System.Windows.Forms.Button()
        CType(Me.dgStats, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAgentStats, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(179, 12)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(88, 20)
        Me.dtTo.TabIndex = 82
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(73, 12)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(88, 20)
        Me.dtFrom.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(163, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "to"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "Sale Date"
        '
        'dgStats
        '
        Me.dgStats.AllowUserToAddRows = False
        Me.dgStats.AllowUserToDeleteRows = False
        Me.dgStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgStats.Location = New System.Drawing.Point(3, 68)
        Me.dgStats.Name = "dgStats"
        Me.dgStats.ReadOnly = True
        Me.dgStats.RowHeadersVisible = False
        Me.dgStats.Size = New System.Drawing.Size(376, 409)
        Me.dgStats.TabIndex = 85
        '
        'dgAgentStats
        '
        Me.dgAgentStats.AllowUserToAddRows = False
        Me.dgAgentStats.AllowUserToDeleteRows = False
        Me.dgAgentStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAgentStats.Location = New System.Drawing.Point(385, 68)
        Me.dgAgentStats.Name = "dgAgentStats"
        Me.dgAgentStats.ReadOnly = True
        Me.dgAgentStats.RowHeadersVisible = False
        Me.dgAgentStats.Size = New System.Drawing.Size(327, 409)
        Me.dgAgentStats.TabIndex = 86
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(0, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 13)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "QA Stats between above range"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(385, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(185, 13)
        Me.Label4.TabIndex = 88
        Me.Label4.Text = "Per agent stats between above range"
        '
        'btRefresh
        '
        Me.btRefresh.Location = New System.Drawing.Point(273, 10)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btRefresh.TabIndex = 89
        Me.btRefresh.Text = "Refresh"
        Me.btRefresh.UseVisualStyleBackColor = True
        '
        'frmQaStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 489)
        Me.Controls.Add(Me.btRefresh)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgAgentStats)
        Me.Controls.Add(Me.dgStats)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtTo)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmQaStats"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmQaStats"
        CType(Me.dgStats, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAgentStats, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgStats As DataGridView
    Friend WithEvents dgAgentStats As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btRefresh As Button
End Class
