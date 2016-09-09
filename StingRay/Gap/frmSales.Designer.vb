<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSales
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend3 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbYourStats = New System.Windows.Forms.TabPage()
        Me.chAgentSales = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tbTeamStats = New System.Windows.Forms.TabPage()
        Me.chTeamSales = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tbGrid = New System.Windows.Forms.TabPage()
        Me.lbSales = New System.Windows.Forms.Label()
        Me.lbComm = New System.Windows.Forms.Label()
        Me.dgSales = New System.Windows.Forms.DataGridView()
        Me.tbTeamSalesGrid = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbAgents = New System.Windows.Forms.ComboBox()
        Me.lbTotalSales = New System.Windows.Forms.Label()
        Me.dgTeamSales = New System.Windows.Forms.DataGridView()
        Me.tbTargets = New System.Windows.Forms.TabPage()
        Me.chAgentTargets = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btThisMonth = New System.Windows.Forms.Button()
        Me.btThisWeek = New System.Windows.Forms.Button()
        Me.btRefresh = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.tbYourStats.SuspendLayout()
        CType(Me.chAgentSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbTeamStats.SuspendLayout()
        CType(Me.chTeamSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbGrid.SuspendLayout()
        CType(Me.dgSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbTeamSalesGrid.SuspendLayout()
        CType(Me.dgTeamSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbTargets.SuspendLayout()
        CType(Me.chAgentTargets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbYourStats)
        Me.TabControl1.Controls.Add(Me.tbTeamStats)
        Me.TabControl1.Controls.Add(Me.tbGrid)
        Me.TabControl1.Controls.Add(Me.tbTeamSalesGrid)
        Me.TabControl1.Controls.Add(Me.tbTargets)
        Me.TabControl1.Location = New System.Drawing.Point(0, 35)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(813, 455)
        Me.TabControl1.TabIndex = 1
        '
        'tbYourStats
        '
        Me.tbYourStats.Controls.Add(Me.chAgentSales)
        Me.tbYourStats.Location = New System.Drawing.Point(4, 22)
        Me.tbYourStats.Name = "tbYourStats"
        Me.tbYourStats.Padding = New System.Windows.Forms.Padding(3)
        Me.tbYourStats.Size = New System.Drawing.Size(805, 429)
        Me.tbYourStats.TabIndex = 0
        Me.tbYourStats.Text = "Your Stats"
        Me.tbYourStats.UseVisualStyleBackColor = True
        '
        'chAgentSales
        '
        ChartArea1.Name = "ChartArea1"
        Me.chAgentSales.ChartAreas.Add(ChartArea1)
        Me.chAgentSales.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.chAgentSales.Legends.Add(Legend1)
        Me.chAgentSales.Location = New System.Drawing.Point(3, 3)
        Me.chAgentSales.Name = "chAgentSales"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Sales"
        Series2.BorderWidth = 10
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Legend = "Legend1"
        Series2.Name = "Conversion"
        Series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary
        Me.chAgentSales.Series.Add(Series1)
        Me.chAgentSales.Series.Add(Series2)
        Me.chAgentSales.Size = New System.Drawing.Size(799, 423)
        Me.chAgentSales.SuppressExceptions = True
        Me.chAgentSales.TabIndex = 1
        Me.chAgentSales.Text = "Chart1"
        '
        'tbTeamStats
        '
        Me.tbTeamStats.Controls.Add(Me.chTeamSales)
        Me.tbTeamStats.Location = New System.Drawing.Point(4, 22)
        Me.tbTeamStats.Name = "tbTeamStats"
        Me.tbTeamStats.Padding = New System.Windows.Forms.Padding(3)
        Me.tbTeamStats.Size = New System.Drawing.Size(805, 429)
        Me.tbTeamStats.TabIndex = 1
        Me.tbTeamStats.Text = "Team Stats"
        Me.tbTeamStats.UseVisualStyleBackColor = True
        '
        'chTeamSales
        '
        ChartArea2.Name = "ChartArea1"
        Me.chTeamSales.ChartAreas.Add(ChartArea2)
        Me.chTeamSales.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Name = "Legend1"
        Me.chTeamSales.Legends.Add(Legend2)
        Me.chTeamSales.Location = New System.Drawing.Point(3, 3)
        Me.chTeamSales.Name = "chTeamSales"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Sales"
        Series4.BorderWidth = 10
        Series4.ChartArea = "ChartArea1"
        Series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series4.Legend = "Legend1"
        Series4.Name = "Conversion"
        Series4.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary
        Me.chTeamSales.Series.Add(Series3)
        Me.chTeamSales.Series.Add(Series4)
        Me.chTeamSales.Size = New System.Drawing.Size(799, 423)
        Me.chTeamSales.SuppressExceptions = True
        Me.chTeamSales.TabIndex = 2
        Me.chTeamSales.Text = "Chart1"
        '
        'tbGrid
        '
        Me.tbGrid.Controls.Add(Me.lbSales)
        Me.tbGrid.Controls.Add(Me.lbComm)
        Me.tbGrid.Controls.Add(Me.dgSales)
        Me.tbGrid.Location = New System.Drawing.Point(4, 22)
        Me.tbGrid.Name = "tbGrid"
        Me.tbGrid.Padding = New System.Windows.Forms.Padding(3)
        Me.tbGrid.Size = New System.Drawing.Size(805, 429)
        Me.tbGrid.TabIndex = 2
        Me.tbGrid.Text = "Sales Grid"
        Me.tbGrid.UseVisualStyleBackColor = True
        '
        'lbSales
        '
        Me.lbSales.AutoSize = True
        Me.lbSales.Location = New System.Drawing.Point(525, 407)
        Me.lbSales.Name = "lbSales"
        Me.lbSales.Size = New System.Drawing.Size(211, 13)
        Me.lbSales.TabIndex = 2
        Me.lbSales.Text = "Total Sales for selected period = #######"
        '
        'lbComm
        '
        Me.lbComm.AutoSize = True
        Me.lbComm.Location = New System.Drawing.Point(8, 407)
        Me.lbComm.Name = "lbComm"
        Me.lbComm.Size = New System.Drawing.Size(225, 13)
        Me.lbComm.TabIndex = 1
        Me.lbComm.Text = "Total Comm for selected period = R #######"
        '
        'dgSales
        '
        Me.dgSales.AllowUserToAddRows = False
        Me.dgSales.AllowUserToDeleteRows = False
        Me.dgSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSales.Location = New System.Drawing.Point(3, 3)
        Me.dgSales.MultiSelect = False
        Me.dgSales.Name = "dgSales"
        Me.dgSales.ReadOnly = True
        Me.dgSales.RowHeadersVisible = False
        Me.dgSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSales.Size = New System.Drawing.Size(799, 394)
        Me.dgSales.TabIndex = 0
        '
        'tbTeamSalesGrid
        '
        Me.tbTeamSalesGrid.Controls.Add(Me.Label2)
        Me.tbTeamSalesGrid.Controls.Add(Me.cbAgents)
        Me.tbTeamSalesGrid.Controls.Add(Me.lbTotalSales)
        Me.tbTeamSalesGrid.Controls.Add(Me.dgTeamSales)
        Me.tbTeamSalesGrid.Location = New System.Drawing.Point(4, 22)
        Me.tbTeamSalesGrid.Name = "tbTeamSalesGrid"
        Me.tbTeamSalesGrid.Padding = New System.Windows.Forms.Padding(3)
        Me.tbTeamSalesGrid.Size = New System.Drawing.Size(805, 429)
        Me.tbTeamSalesGrid.TabIndex = 3
        Me.tbTeamSalesGrid.Text = "Team Sales Grid"
        Me.tbTeamSalesGrid.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(68, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Agent"
        '
        'cbAgents
        '
        Me.cbAgents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAgents.FormattingEnabled = True
        Me.cbAgents.Location = New System.Drawing.Point(113, 7)
        Me.cbAgents.Name = "cbAgents"
        Me.cbAgents.Size = New System.Drawing.Size(121, 21)
        Me.cbAgents.TabIndex = 55
        '
        'lbTotalSales
        '
        Me.lbTotalSales.AutoSize = True
        Me.lbTotalSales.Location = New System.Drawing.Point(8, 408)
        Me.lbTotalSales.Name = "lbTotalSales"
        Me.lbTotalSales.Size = New System.Drawing.Size(211, 13)
        Me.lbTotalSales.TabIndex = 2
        Me.lbTotalSales.Text = "Total Sales for selected period = #######"
        '
        'dgTeamSales
        '
        Me.dgTeamSales.AllowUserToAddRows = False
        Me.dgTeamSales.AllowUserToDeleteRows = False
        Me.dgTeamSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTeamSales.Location = New System.Drawing.Point(3, 34)
        Me.dgTeamSales.Name = "dgTeamSales"
        Me.dgTeamSales.ReadOnly = True
        Me.dgTeamSales.RowHeadersVisible = False
        Me.dgTeamSales.Size = New System.Drawing.Size(799, 363)
        Me.dgTeamSales.TabIndex = 1
        '
        'tbTargets
        '
        Me.tbTargets.Controls.Add(Me.chAgentTargets)
        Me.tbTargets.Location = New System.Drawing.Point(4, 22)
        Me.tbTargets.Name = "tbTargets"
        Me.tbTargets.Padding = New System.Windows.Forms.Padding(3)
        Me.tbTargets.Size = New System.Drawing.Size(805, 429)
        Me.tbTargets.TabIndex = 4
        Me.tbTargets.Text = "Targets"
        Me.tbTargets.UseVisualStyleBackColor = True
        '
        'chAgentTargets
        '
        ChartArea3.Name = "ChartArea1"
        Me.chAgentTargets.ChartAreas.Add(ChartArea3)
        Legend3.Name = "Legend1"
        Me.chAgentTargets.Legends.Add(Legend3)
        Me.chAgentTargets.Location = New System.Drawing.Point(3, 0)
        Me.chAgentTargets.Name = "chAgentTargets"
        Series5.ChartArea = "ChartArea1"
        Series5.Legend = "Legend1"
        Series5.Name = "Sales"
        Series6.BorderWidth = 10
        Series6.ChartArea = "ChartArea1"
        Series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point
        Series6.Legend = "Legend1"
        Series6.MarkerSize = 10
        Series6.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square
        Series6.Name = "Target"
        Series6.YValuesPerPoint = 4
        Me.chAgentTargets.Series.Add(Series5)
        Me.chAgentTargets.Series.Add(Series6)
        Me.chAgentTargets.Size = New System.Drawing.Size(326, 426)
        Me.chAgentTargets.TabIndex = 2
        Me.chAgentTargets.Text = "Chart1"
        Title1.Name = "Title1"
        Title1.Text = "Your Weekly Target"
        Title1.ToolTip = "Runs from the previous Monday to Sunday"
        Me.chAgentTargets.Titles.Add(Title1)
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(532, 12)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(110, 20)
        Me.dtTo.TabIndex = 49
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(404, 12)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(110, 20)
        Me.dtFrom.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(516, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "to"
        '
        'btThisMonth
        '
        Me.btThisMonth.Location = New System.Drawing.Point(12, 6)
        Me.btThisMonth.Name = "btThisMonth"
        Me.btThisMonth.Size = New System.Drawing.Size(75, 23)
        Me.btThisMonth.TabIndex = 51
        Me.btThisMonth.Text = "This Month"
        Me.btThisMonth.UseVisualStyleBackColor = True
        '
        'btThisWeek
        '
        Me.btThisWeek.Location = New System.Drawing.Point(117, 6)
        Me.btThisWeek.Name = "btThisWeek"
        Me.btThisWeek.Size = New System.Drawing.Size(75, 23)
        Me.btThisWeek.TabIndex = 52
        Me.btThisWeek.Text = "This Week"
        Me.btThisWeek.UseVisualStyleBackColor = True
        '
        'btRefresh
        '
        Me.btRefresh.Location = New System.Drawing.Point(723, 11)
        Me.btRefresh.Name = "btRefresh"
        Me.btRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btRefresh.TabIndex = 53
        Me.btRefresh.Text = "Refresh"
        Me.btRefresh.UseVisualStyleBackColor = True
        '
        'frmSales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 490)
        Me.Controls.Add(Me.btRefresh)
        Me.Controls.Add(Me.btThisWeek)
        Me.Controls.Add(Me.btThisMonth)
        Me.Controls.Add(Me.dtTo)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmSales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales"
        Me.TabControl1.ResumeLayout(False)
        Me.tbYourStats.ResumeLayout(False)
        CType(Me.chAgentSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbTeamStats.ResumeLayout(False)
        CType(Me.chTeamSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbGrid.ResumeLayout(False)
        Me.tbGrid.PerformLayout()
        CType(Me.dgSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbTeamSalesGrid.ResumeLayout(False)
        Me.tbTeamSalesGrid.PerformLayout()
        CType(Me.dgTeamSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbTargets.ResumeLayout(False)
        CType(Me.chAgentTargets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbYourStats As System.Windows.Forms.TabPage
    Friend WithEvents chAgentSales As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents tbTeamStats As System.Windows.Forms.TabPage
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btThisMonth As System.Windows.Forms.Button
    Friend WithEvents btThisWeek As System.Windows.Forms.Button
    Friend WithEvents btRefresh As System.Windows.Forms.Button
    Friend WithEvents chTeamSales As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents tbGrid As System.Windows.Forms.TabPage
    Friend WithEvents dgSales As System.Windows.Forms.DataGridView
    Friend WithEvents tbTeamSalesGrid As System.Windows.Forms.TabPage
    Friend WithEvents dgTeamSales As System.Windows.Forms.DataGridView
    Friend WithEvents tbTargets As System.Windows.Forms.TabPage
    Friend WithEvents chAgentTargets As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents lbComm As System.Windows.Forms.Label
    Friend WithEvents lbTotalSales As System.Windows.Forms.Label
    Friend WithEvents lbSales As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbAgents As System.Windows.Forms.ComboBox
End Class
