<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQaPickUp
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
        Me.cbOrderDirection = New System.Windows.Forms.ComboBox()
        Me.cbOrder = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btSearch = New System.Windows.Forms.Button()
        Me.cbAgent = New System.Windows.Forms.ComboBox()
        Me.gbStatuses = New System.Windows.Forms.GroupBox()
        Me.cbSentback = New System.Windows.Forms.CheckBox()
        Me.cbInProgress = New System.Windows.Forms.CheckBox()
        Me.cbFixed = New System.Windows.Forms.CheckBox()
        Me.cbBypass = New System.Windows.Forms.CheckBox()
        Me.cbFail = New System.Windows.Forms.CheckBox()
        Me.cbPending = New System.Windows.Forms.CheckBox()
        Me.dgPickUp = New System.Windows.Forms.DataGridView()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.cbDates = New System.Windows.Forms.CheckBox()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btAddQueue = New System.Windows.Forms.Button()
        Me.cbManditory = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbAffinity = New System.Windows.Forms.ComboBox()
        Me.txIDNum = New StingRay.WaterMarkTextBox()
        Me.txContactNum = New StingRay.WaterMarkTextBox()
        Me.txLastName = New StingRay.WaterMarkTextBox()
        Me.txFirstName = New StingRay.WaterMarkTextBox()
        Me.txLeadID = New StingRay.WaterMarkTextBox()
        Me.gbStatuses.SuspendLayout()
        CType(Me.dgPickUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbOrderDirection
        '
        Me.cbOrderDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOrderDirection.FormattingEnabled = True
        Me.cbOrderDirection.Items.AddRange(New Object() {"ASC", "DESC"})
        Me.cbOrderDirection.Location = New System.Drawing.Point(420, 34)
        Me.cbOrderDirection.Name = "cbOrderDirection"
        Me.cbOrderDirection.Size = New System.Drawing.Size(51, 21)
        Me.cbOrderDirection.TabIndex = 30
        '
        'cbOrder
        '
        Me.cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOrder.FormattingEnabled = True
        Me.cbOrder.Items.AddRange(New Object() {"closedDate", "leadID", "firstName", "lastName", "contactNumber", "idNumber", "affinity"})
        Me.cbOrder.Location = New System.Drawing.Point(334, 34)
        Me.cbOrder.Name = "cbOrder"
        Me.cbOrder.Size = New System.Drawing.Size(80, 21)
        Me.cbOrder.TabIndex = 29
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(299, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Sort:"
        '
        'btSearch
        '
        Me.btSearch.Location = New System.Drawing.Point(679, 12)
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(102, 68)
        Me.btSearch.TabIndex = 32
        Me.btSearch.Text = "Search"
        Me.btSearch.UseVisualStyleBackColor = True
        '
        'cbAgent
        '
        Me.cbAgent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAgent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAgent.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbAgent.FormattingEnabled = True
        Me.cbAgent.Location = New System.Drawing.Point(53, 59)
        Me.cbAgent.Name = "cbAgent"
        Me.cbAgent.Size = New System.Drawing.Size(99, 21)
        Me.cbAgent.TabIndex = 26
        '
        'gbStatuses
        '
        Me.gbStatuses.Controls.Add(Me.cbSentback)
        Me.gbStatuses.Controls.Add(Me.cbInProgress)
        Me.gbStatuses.Controls.Add(Me.cbFixed)
        Me.gbStatuses.Controls.Add(Me.cbBypass)
        Me.gbStatuses.Controls.Add(Me.cbFail)
        Me.gbStatuses.Controls.Add(Me.cbPending)
        Me.gbStatuses.Location = New System.Drawing.Point(511, 8)
        Me.gbStatuses.Name = "gbStatuses"
        Me.gbStatuses.Size = New System.Drawing.Size(162, 73)
        Me.gbStatuses.TabIndex = 31
        Me.gbStatuses.TabStop = False
        Me.gbStatuses.Text = "Status"
        '
        'cbSentback
        '
        Me.cbSentback.AutoSize = True
        Me.cbSentback.Location = New System.Drawing.Point(74, 37)
        Me.cbSentback.Name = "cbSentback"
        Me.cbSentback.Size = New System.Drawing.Size(76, 17)
        Me.cbSentback.TabIndex = 25
        Me.cbSentback.Text = "Sent Back"
        Me.cbSentback.UseVisualStyleBackColor = True
        '
        'cbInProgress
        '
        Me.cbInProgress.AutoSize = True
        Me.cbInProgress.Location = New System.Drawing.Point(74, 53)
        Me.cbInProgress.Name = "cbInProgress"
        Me.cbInProgress.Size = New System.Drawing.Size(79, 17)
        Me.cbInProgress.TabIndex = 24
        Me.cbInProgress.Text = "In Progress"
        Me.cbInProgress.UseVisualStyleBackColor = True
        '
        'cbFixed
        '
        Me.cbFixed.AutoSize = True
        Me.cbFixed.Location = New System.Drawing.Point(74, 19)
        Me.cbFixed.Name = "cbFixed"
        Me.cbFixed.Size = New System.Drawing.Size(51, 17)
        Me.cbFixed.TabIndex = 23
        Me.cbFixed.Text = "Fixed"
        Me.cbFixed.UseVisualStyleBackColor = True
        '
        'cbBypass
        '
        Me.cbBypass.AutoSize = True
        Me.cbBypass.Location = New System.Drawing.Point(6, 37)
        Me.cbBypass.Name = "cbBypass"
        Me.cbBypass.Size = New System.Drawing.Size(60, 17)
        Me.cbBypass.TabIndex = 22
        Me.cbBypass.Text = "Bypass"
        Me.cbBypass.UseVisualStyleBackColor = True
        '
        'cbFail
        '
        Me.cbFail.AutoSize = True
        Me.cbFail.Location = New System.Drawing.Point(6, 54)
        Me.cbFail.Name = "cbFail"
        Me.cbFail.Size = New System.Drawing.Size(42, 17)
        Me.cbFail.TabIndex = 20
        Me.cbFail.Text = "Fail"
        Me.cbFail.UseVisualStyleBackColor = True
        '
        'cbPending
        '
        Me.cbPending.AutoSize = True
        Me.cbPending.Checked = True
        Me.cbPending.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbPending.Location = New System.Drawing.Point(6, 19)
        Me.cbPending.Name = "cbPending"
        Me.cbPending.Size = New System.Drawing.Size(65, 17)
        Me.cbPending.TabIndex = 21
        Me.cbPending.Text = "Pending"
        Me.cbPending.UseVisualStyleBackColor = True
        '
        'dgPickUp
        '
        Me.dgPickUp.AllowUserToAddRows = False
        Me.dgPickUp.AllowUserToDeleteRows = False
        Me.dgPickUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPickUp.Location = New System.Drawing.Point(12, 86)
        Me.dgPickUp.Name = "dgPickUp"
        Me.dgPickUp.ReadOnly = True
        Me.dgPickUp.RowHeadersVisible = False
        Me.dgPickUp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPickUp.Size = New System.Drawing.Size(769, 352)
        Me.dgPickUp.TabIndex = 33
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(82, 34)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(88, 20)
        Me.dtFrom.TabIndex = 41
        '
        'cbDates
        '
        Me.cbDates.AutoSize = True
        Me.cbDates.Location = New System.Drawing.Point(12, 36)
        Me.cbDates.Name = "cbDates"
        Me.cbDates.Size = New System.Drawing.Size(73, 17)
        Me.cbDates.TabIndex = 13
        Me.cbDates.Text = "Sale Date"
        Me.cbDates.UseVisualStyleBackColor = True
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(195, 34)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(88, 20)
        Me.dtTo.TabIndex = 42
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(176, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "to"
        '
        'btAddQueue
        '
        Me.btAddQueue.Location = New System.Drawing.Point(403, 57)
        Me.btAddQueue.Name = "btAddQueue"
        Me.btAddQueue.Size = New System.Drawing.Size(102, 24)
        Me.btAddQueue.TabIndex = 49
        Me.btAddQueue.Text = "Add all to queue"
        Me.btAddQueue.UseVisualStyleBackColor = True
        '
        'cbManditory
        '
        Me.cbManditory.AutoSize = True
        Me.cbManditory.Location = New System.Drawing.Point(420, 7)
        Me.cbManditory.Name = "cbManditory"
        Me.cbManditory.Size = New System.Drawing.Size(72, 17)
        Me.cbManditory.TabIndex = 50
        Me.cbManditory.Text = "Manditory"
        Me.cbManditory.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Agent:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(245, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 53
        Me.Label3.Text = "Affinity:"
        '
        'cbAffinity
        '
        Me.cbAffinity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAffinity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAffinity.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbAffinity.FormattingEnabled = True
        Me.cbAffinity.Location = New System.Drawing.Point(289, 60)
        Me.cbAffinity.Name = "cbAffinity"
        Me.cbAffinity.Size = New System.Drawing.Size(99, 21)
        Me.cbAffinity.TabIndex = 52
        '
        'txIDNum
        '
        Me.txIDNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txIDNum.Location = New System.Drawing.Point(302, 7)
        Me.txIDNum.Name = "txIDNum"
        Me.txIDNum.Size = New System.Drawing.Size(86, 20)
        Me.txIDNum.TabIndex = 40
        Me.txIDNum.Tag = "idNumber"
        Me.txIDNum.WaterMarkColor = System.Drawing.Color.Gray
        Me.txIDNum.WaterMarkText = "ID Num"
        '
        'txContactNum
        '
        Me.txContactNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txContactNum.Location = New System.Drawing.Point(220, 7)
        Me.txContactNum.Name = "txContactNum"
        Me.txContactNum.Size = New System.Drawing.Size(76, 20)
        Me.txContactNum.TabIndex = 39
        Me.txContactNum.Tag = "contactNumber"
        Me.txContactNum.WaterMarkColor = System.Drawing.Color.Gray
        Me.txContactNum.WaterMarkText = "Contact Num"
        '
        'txLastName
        '
        Me.txLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txLastName.Location = New System.Drawing.Point(151, 7)
        Me.txLastName.Name = "txLastName"
        Me.txLastName.Size = New System.Drawing.Size(63, 20)
        Me.txLastName.TabIndex = 38
        Me.txLastName.Tag = "lastName"
        Me.txLastName.WaterMarkColor = System.Drawing.Color.Gray
        Me.txLastName.WaterMarkText = "Last Name"
        '
        'txFirstName
        '
        Me.txFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txFirstName.Location = New System.Drawing.Point(73, 7)
        Me.txFirstName.Name = "txFirstName"
        Me.txFirstName.Size = New System.Drawing.Size(72, 20)
        Me.txFirstName.TabIndex = 37
        Me.txFirstName.Tag = "firstName"
        Me.txFirstName.WaterMarkColor = System.Drawing.Color.Gray
        Me.txFirstName.WaterMarkText = "First Name"
        '
        'txLeadID
        '
        Me.txLeadID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txLeadID.Location = New System.Drawing.Point(12, 7)
        Me.txLeadID.Name = "txLeadID"
        Me.txLeadID.Size = New System.Drawing.Size(55, 20)
        Me.txLeadID.TabIndex = 36
        Me.txLeadID.Tag = "lead_primary.leadID"
        Me.txLeadID.WaterMarkColor = System.Drawing.Color.Gray
        Me.txLeadID.WaterMarkText = "Lead ID"
        '
        'frmQaPickUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 445)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbAffinity)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbManditory)
        Me.Controls.Add(Me.btAddQueue)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtTo)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.txIDNum)
        Me.Controls.Add(Me.txContactNum)
        Me.Controls.Add(Me.txLastName)
        Me.Controls.Add(Me.txFirstName)
        Me.Controls.Add(Me.txLeadID)
        Me.Controls.Add(Me.cbOrderDirection)
        Me.Controls.Add(Me.cbOrder)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btSearch)
        Me.Controls.Add(Me.cbAgent)
        Me.Controls.Add(Me.gbStatuses)
        Me.Controls.Add(Me.dgPickUp)
        Me.Controls.Add(Me.cbDates)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmQaPickUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmQaPickUp"
        Me.gbStatuses.ResumeLayout(False)
        Me.gbStatuses.PerformLayout()
        CType(Me.dgPickUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txIDNum As StingRay.WaterMarkTextBox
    Friend WithEvents txContactNum As StingRay.WaterMarkTextBox
    Friend WithEvents txLastName As StingRay.WaterMarkTextBox
    Friend WithEvents txFirstName As StingRay.WaterMarkTextBox
    Friend WithEvents txLeadID As StingRay.WaterMarkTextBox
    Friend WithEvents cbOrderDirection As System.Windows.Forms.ComboBox
    Friend WithEvents cbOrder As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btSearch As System.Windows.Forms.Button
    Friend WithEvents cbAgent As System.Windows.Forms.ComboBox
    Friend WithEvents gbStatuses As System.Windows.Forms.GroupBox
    Friend WithEvents dgPickUp As System.Windows.Forms.DataGridView
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbDates As System.Windows.Forms.CheckBox
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btAddQueue As System.Windows.Forms.Button
    Friend WithEvents cbManditory As System.Windows.Forms.CheckBox
    Friend WithEvents cbBypass As System.Windows.Forms.CheckBox
    Friend WithEvents cbFail As System.Windows.Forms.CheckBox
    Friend WithEvents cbPending As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbAffinity As System.Windows.Forms.ComboBox
    Friend WithEvents cbInProgress As System.Windows.Forms.CheckBox
    Friend WithEvents cbFixed As System.Windows.Forms.CheckBox
    Friend WithEvents cbSentback As System.Windows.Forms.CheckBox
End Class
