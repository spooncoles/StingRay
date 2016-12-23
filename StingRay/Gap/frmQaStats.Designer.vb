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
        Me.btRefresh = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbGeneral = New System.Windows.Forms.TabPage()
        Me.tbPerDay = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgAgentStats = New System.Windows.Forms.DataGridView()
        Me.dgStats = New System.Windows.Forms.DataGridView()
        Me.dgPerDay = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbSales = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgSalesAgents = New System.Windows.Forms.DataGridView()
        Me.TabControl1.SuspendLayout()
        Me.tbGeneral.SuspendLayout()
        Me.tbPerDay.SuspendLayout()
        CType(Me.dgAgentStats, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgStats, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgPerDay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSales.SuspendLayout()
        CType(Me.dgSalesAgents, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'btRefresh
        '
        Me.btRefresh.Location = New System.Drawing.Point(273, 10)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btRefresh.TabIndex = 89
        Me.btRefresh.Text = "Refresh"
        Me.btRefresh.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbGeneral)
        Me.TabControl1.Controls.Add(Me.tbPerDay)
        Me.TabControl1.Controls.Add(Me.tbSales)
        Me.TabControl1.Location = New System.Drawing.Point(12, 38)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(798, 539)
        Me.TabControl1.TabIndex = 90
        '
        'tbGeneral
        '
        Me.tbGeneral.Controls.Add(Me.Label4)
        Me.tbGeneral.Controls.Add(Me.Label3)
        Me.tbGeneral.Controls.Add(Me.dgAgentStats)
        Me.tbGeneral.Controls.Add(Me.dgStats)
        Me.tbGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tbGeneral.Name = "tbGeneral"
        Me.tbGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tbGeneral.Size = New System.Drawing.Size(790, 513)
        Me.tbGeneral.TabIndex = 0
        Me.tbGeneral.Text = "General"
        Me.tbGeneral.UseVisualStyleBackColor = True
        '
        'tbPerDay
        '
        Me.tbPerDay.Controls.Add(Me.Label5)
        Me.tbPerDay.Controls.Add(Me.dgPerDay)
        Me.tbPerDay.Location = New System.Drawing.Point(4, 22)
        Me.tbPerDay.Name = "tbPerDay"
        Me.tbPerDay.Padding = New System.Windows.Forms.Padding(3)
        Me.tbPerDay.Size = New System.Drawing.Size(790, 513)
        Me.tbPerDay.TabIndex = 1
        Me.tbPerDay.Text = "Per Day"
        Me.tbPerDay.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(267, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(185, 13)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Per agent stats between above range"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Outstanding"
        '
        'dgAgentStats
        '
        Me.dgAgentStats.AllowUserToAddRows = False
        Me.dgAgentStats.AllowUserToDeleteRows = False
        Me.dgAgentStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgAgentStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAgentStats.Location = New System.Drawing.Point(270, 19)
        Me.dgAgentStats.Name = "dgAgentStats"
        Me.dgAgentStats.ReadOnly = True
        Me.dgAgentStats.RowHeadersVisible = False
        Me.dgAgentStats.Size = New System.Drawing.Size(514, 488)
        Me.dgAgentStats.TabIndex = 90
        '
        'dgStats
        '
        Me.dgStats.AllowUserToAddRows = False
        Me.dgStats.AllowUserToDeleteRows = False
        Me.dgStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgStats.Location = New System.Drawing.Point(6, 19)
        Me.dgStats.Name = "dgStats"
        Me.dgStats.ReadOnly = True
        Me.dgStats.RowHeadersVisible = False
        Me.dgStats.Size = New System.Drawing.Size(254, 488)
        Me.dgStats.TabIndex = 89
        '
        'dgPerDay
        '
        Me.dgPerDay.AllowUserToAddRows = False
        Me.dgPerDay.AllowUserToDeleteRows = False
        Me.dgPerDay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPerDay.Location = New System.Drawing.Point(6, 22)
        Me.dgPerDay.Name = "dgPerDay"
        Me.dgPerDay.ReadOnly = True
        Me.dgPerDay.Size = New System.Drawing.Size(778, 485)
        Me.dgPerDay.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(199, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Pass/Bypass per day in the above range"
        '
        'tbSales
        '
        Me.tbSales.Controls.Add(Me.dgSalesAgents)
        Me.tbSales.Controls.Add(Me.Label6)
        Me.tbSales.Location = New System.Drawing.Point(4, 22)
        Me.tbSales.Name = "tbSales"
        Me.tbSales.Padding = New System.Windows.Forms.Padding(3)
        Me.tbSales.Size = New System.Drawing.Size(790, 513)
        Me.tbSales.TabIndex = 2
        Me.tbSales.Text = "Sales"
        Me.tbSales.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(167, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Agent Stats For above date range"
        '
        'dgSalesAgents
        '
        Me.dgSalesAgents.AllowUserToAddRows = False
        Me.dgSalesAgents.AllowUserToDeleteRows = False
        Me.dgSalesAgents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgSalesAgents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSalesAgents.Location = New System.Drawing.Point(10, 21)
        Me.dgSalesAgents.Name = "dgSalesAgents"
        Me.dgSalesAgents.ReadOnly = True
        Me.dgSalesAgents.Size = New System.Drawing.Size(774, 477)
        Me.dgSalesAgents.TabIndex = 1
        '
        'frmQaStats
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 585)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btRefresh)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtTo)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmQaStats"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmQaStats"
        Me.TabControl1.ResumeLayout(False)
        Me.tbGeneral.ResumeLayout(False)
        Me.tbGeneral.PerformLayout()
        Me.tbPerDay.ResumeLayout(False)
        Me.tbPerDay.PerformLayout()
        CType(Me.dgAgentStats, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgStats, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgPerDay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSales.ResumeLayout(False)
        Me.tbSales.PerformLayout()
        CType(Me.dgSalesAgents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btRefresh As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tbGeneral As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgAgentStats As DataGridView
    Friend WithEvents dgStats As DataGridView
    Friend WithEvents tbPerDay As TabPage
    Friend WithEvents Label5 As Label
    Friend WithEvents dgPerDay As DataGridView
    Friend WithEvents tbSales As TabPage
    Friend WithEvents dgSalesAgents As DataGridView
    Friend WithEvents Label6 As Label
End Class
