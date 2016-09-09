<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeadChange
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
        Me.cbOtherSearch = New System.Windows.Forms.ComboBox()
        Me.txOtherValue = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btSearch = New System.Windows.Forms.Button()
        Me.cbStatusOther = New System.Windows.Forms.CheckBox()
        Me.cbBusy = New System.Windows.Forms.CheckBox()
        Me.cbAvaliable = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgPickUp = New System.Windows.Forms.DataGridView()
        Me.gbChanges = New System.Windows.Forms.GroupBox()
        Me.btComment = New System.Windows.Forms.Button()
        Me.btHistory = New System.Windows.Forms.Button()
        Me.btAddChange = New System.Windows.Forms.Button()
        Me.lvChanges = New System.Windows.Forms.ListView()
        Me.Change = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ChangeTo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btConfirmChanges = New System.Windows.Forms.Button()
        Me.lbChangeTo = New System.Windows.Forms.Label()
        Me.cbChangeTo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbFieldChange = New System.Windows.Forms.ComboBox()
        Me.txContactNumChange = New System.Windows.Forms.MaskedTextBox()
        Me.txEmailAddChange = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbAffinity = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbAgent = New System.Windows.Forms.ComboBox()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.cbDates = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txEmailAdd = New StingRay.WaterMarkTextBox()
        Me.txIDNum = New StingRay.WaterMarkTextBox()
        Me.txContactNum = New StingRay.WaterMarkTextBox()
        Me.txLastName = New StingRay.WaterMarkTextBox()
        Me.txFirstName = New StingRay.WaterMarkTextBox()
        Me.txLeadID = New StingRay.WaterMarkTextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgPickUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbChanges.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbOrderDirection
        '
        Me.cbOrderDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOrderDirection.FormattingEnabled = True
        Me.cbOrderDirection.Items.AddRange(New Object() {"ASC", "DESC"})
        Me.cbOrderDirection.Location = New System.Drawing.Point(441, 87)
        Me.cbOrderDirection.Name = "cbOrderDirection"
        Me.cbOrderDirection.Size = New System.Drawing.Size(51, 21)
        Me.cbOrderDirection.TabIndex = 54
        '
        'cbOrder
        '
        Me.cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOrder.FormattingEnabled = True
        Me.cbOrder.Items.AddRange(New Object() {"loadedDate", "leadID", "firstName", "lastName", "contactNumber", "idNumber", "affinity"})
        Me.cbOrder.Location = New System.Drawing.Point(355, 87)
        Me.cbOrder.Name = "cbOrder"
        Me.cbOrder.Size = New System.Drawing.Size(80, 21)
        Me.cbOrder.TabIndex = 53
        '
        'cbOtherSearch
        '
        Me.cbOtherSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOtherSearch.FormattingEnabled = True
        Me.cbOtherSearch.Location = New System.Drawing.Point(45, 88)
        Me.cbOtherSearch.Name = "cbOtherSearch"
        Me.cbOtherSearch.Size = New System.Drawing.Size(99, 21)
        Me.cbOtherSearch.TabIndex = 51
        '
        'txOtherValue
        '
        Me.txOtherValue.Location = New System.Drawing.Point(150, 88)
        Me.txOtherValue.Name = "txOtherValue"
        Me.txOtherValue.Size = New System.Drawing.Size(120, 20)
        Me.txOtherValue.TabIndex = 52
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 58
        Me.Label7.Text = "Other:"
        '
        'btSearch
        '
        Me.btSearch.Location = New System.Drawing.Point(583, 10)
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(102, 98)
        Me.btSearch.TabIndex = 56
        Me.btSearch.Text = "Search"
        Me.btSearch.UseVisualStyleBackColor = True
        '
        'cbStatusOther
        '
        Me.cbStatusOther.AutoSize = True
        Me.cbStatusOther.Location = New System.Drawing.Point(6, 53)
        Me.cbStatusOther.Name = "cbStatusOther"
        Me.cbStatusOther.Size = New System.Drawing.Size(52, 17)
        Me.cbStatusOther.TabIndex = 12
        Me.cbStatusOther.Text = "Other"
        Me.cbStatusOther.UseVisualStyleBackColor = True
        '
        'cbBusy
        '
        Me.cbBusy.AutoSize = True
        Me.cbBusy.Checked = True
        Me.cbBusy.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbBusy.Location = New System.Drawing.Point(6, 36)
        Me.cbBusy.Name = "cbBusy"
        Me.cbBusy.Size = New System.Drawing.Size(49, 17)
        Me.cbBusy.TabIndex = 11
        Me.cbBusy.Text = "Busy"
        Me.cbBusy.UseVisualStyleBackColor = True
        '
        'cbAvaliable
        '
        Me.cbAvaliable.AutoSize = True
        Me.cbAvaliable.Checked = True
        Me.cbAvaliable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAvaliable.Location = New System.Drawing.Point(6, 19)
        Me.cbAvaliable.Name = "cbAvaliable"
        Me.cbAvaliable.Size = New System.Drawing.Size(69, 17)
        Me.cbAvaliable.TabIndex = 10
        Me.cbAvaliable.Text = "Avaliable"
        Me.cbAvaliable.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(320, 90)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 59
        Me.Label8.Text = "Sort:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbStatusOther)
        Me.GroupBox1.Controls.Add(Me.cbBusy)
        Me.GroupBox1.Controls.Add(Me.cbAvaliable)
        Me.GroupBox1.Location = New System.Drawing.Point(499, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(78, 98)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'dgPickUp
        '
        Me.dgPickUp.AllowUserToAddRows = False
        Me.dgPickUp.AllowUserToDeleteRows = False
        Me.dgPickUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPickUp.Location = New System.Drawing.Point(12, 119)
        Me.dgPickUp.Name = "dgPickUp"
        Me.dgPickUp.ReadOnly = True
        Me.dgPickUp.RowHeadersVisible = False
        Me.dgPickUp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPickUp.Size = New System.Drawing.Size(673, 353)
        Me.dgPickUp.TabIndex = 57
        '
        'gbChanges
        '
        Me.gbChanges.Controls.Add(Me.btComment)
        Me.gbChanges.Controls.Add(Me.btHistory)
        Me.gbChanges.Controls.Add(Me.btAddChange)
        Me.gbChanges.Controls.Add(Me.lvChanges)
        Me.gbChanges.Controls.Add(Me.btConfirmChanges)
        Me.gbChanges.Controls.Add(Me.lbChangeTo)
        Me.gbChanges.Controls.Add(Me.cbChangeTo)
        Me.gbChanges.Controls.Add(Me.Label2)
        Me.gbChanges.Controls.Add(Me.cbFieldChange)
        Me.gbChanges.Controls.Add(Me.txContactNumChange)
        Me.gbChanges.Controls.Add(Me.txEmailAddChange)
        Me.gbChanges.Location = New System.Drawing.Point(691, 10)
        Me.gbChanges.Name = "gbChanges"
        Me.gbChanges.Size = New System.Drawing.Size(185, 462)
        Me.gbChanges.TabIndex = 71
        Me.gbChanges.TabStop = False
        Me.gbChanges.Text = "Changes to be made"
        '
        'btComment
        '
        Me.btComment.Location = New System.Drawing.Point(7, 413)
        Me.btComment.Name = "btComment"
        Me.btComment.Size = New System.Drawing.Size(173, 21)
        Me.btComment.TabIndex = 10
        Me.btComment.Text = "Add Comment"
        Me.btComment.UseVisualStyleBackColor = True
        '
        'btHistory
        '
        Me.btHistory.Location = New System.Drawing.Point(7, 433)
        Me.btHistory.Name = "btHistory"
        Me.btHistory.Size = New System.Drawing.Size(173, 21)
        Me.btHistory.TabIndex = 9
        Me.btHistory.Text = "View History"
        Me.btHistory.UseVisualStyleBackColor = True
        '
        'btAddChange
        '
        Me.btAddChange.Location = New System.Drawing.Point(5, 136)
        Me.btAddChange.Name = "btAddChange"
        Me.btAddChange.Size = New System.Drawing.Size(173, 21)
        Me.btAddChange.TabIndex = 6
        Me.btAddChange.Text = "Add Change"
        Me.btAddChange.UseVisualStyleBackColor = True
        '
        'lvChanges
        '
        Me.lvChanges.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Change, Me.ChangeTo})
        Me.lvChanges.FullRowSelect = True
        Me.lvChanges.GridLines = True
        Me.lvChanges.Location = New System.Drawing.Point(7, 163)
        Me.lvChanges.MultiSelect = False
        Me.lvChanges.Name = "lvChanges"
        Me.lvChanges.Size = New System.Drawing.Size(171, 223)
        Me.lvChanges.TabIndex = 5
        Me.lvChanges.UseCompatibleStateImageBehavior = False
        Me.lvChanges.View = System.Windows.Forms.View.Details
        '
        'Change
        '
        Me.Change.Text = "Change"
        Me.Change.Width = 79
        '
        'ChangeTo
        '
        Me.ChangeTo.Text = "To"
        Me.ChangeTo.Width = 85
        '
        'btConfirmChanges
        '
        Me.btConfirmChanges.Location = New System.Drawing.Point(6, 388)
        Me.btConfirmChanges.Name = "btConfirmChanges"
        Me.btConfirmChanges.Size = New System.Drawing.Size(173, 21)
        Me.btConfirmChanges.TabIndex = 4
        Me.btConfirmChanges.Text = "Confirm Changes"
        Me.btConfirmChanges.UseVisualStyleBackColor = True
        '
        'lbChangeTo
        '
        Me.lbChangeTo.AutoSize = True
        Me.lbChangeTo.Location = New System.Drawing.Point(2, 77)
        Me.lbChangeTo.Name = "lbChangeTo"
        Me.lbChangeTo.Size = New System.Drawing.Size(87, 13)
        Me.lbChangeTo.TabIndex = 3
        Me.lbChangeTo.Text = "Change leads to:"
        Me.lbChangeTo.Visible = False
        '
        'cbChangeTo
        '
        Me.cbChangeTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbChangeTo.FormattingEnabled = True
        Me.cbChangeTo.Items.AddRange(New Object() {"Agent", "Affinity", "Status", "Source"})
        Me.cbChangeTo.Location = New System.Drawing.Point(6, 93)
        Me.cbChangeTo.Name = "cbChangeTo"
        Me.cbChangeTo.Size = New System.Drawing.Size(173, 21)
        Me.cbChangeTo.TabIndex = 2
        Me.cbChangeTo.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Field to change"
        '
        'cbFieldChange
        '
        Me.cbFieldChange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFieldChange.FormattingEnabled = True
        Me.cbFieldChange.Items.AddRange(New Object() {"Agent", "Affinity", "Status", "Source", "EmailAddress", "ContactNumber", "firstName", "lastName"})
        Me.cbFieldChange.Location = New System.Drawing.Point(5, 47)
        Me.cbFieldChange.Name = "cbFieldChange"
        Me.cbFieldChange.Size = New System.Drawing.Size(173, 21)
        Me.cbFieldChange.TabIndex = 0
        '
        'txContactNumChange
        '
        Me.txContactNumChange.Location = New System.Drawing.Point(6, 93)
        Me.txContactNumChange.Mask = "(999) 000-0000"
        Me.txContactNumChange.Name = "txContactNumChange"
        Me.txContactNumChange.Size = New System.Drawing.Size(173, 20)
        Me.txContactNumChange.TabIndex = 7
        Me.txContactNumChange.Tag = "contactNumber"
        Me.txContactNumChange.Visible = False
        '
        'txEmailAddChange
        '
        Me.txEmailAddChange.Location = New System.Drawing.Point(6, 94)
        Me.txEmailAddChange.MaxLength = 100
        Me.txEmailAddChange.Name = "txEmailAddChange"
        Me.txEmailAddChange.Size = New System.Drawing.Size(173, 20)
        Me.txEmailAddChange.TabIndex = 8
        Me.txEmailAddChange.Tag = "emailAddress"
        Me.txEmailAddChange.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Affinity:"
        '
        'cbAffinity
        '
        Me.cbAffinity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAffinity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAffinity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbAffinity.FormattingEnabled = True
        Me.cbAffinity.Location = New System.Drawing.Point(54, 38)
        Me.cbAffinity.Name = "cbAffinity"
        Me.cbAffinity.Size = New System.Drawing.Size(90, 21)
        Me.cbAffinity.TabIndex = 73
        Me.cbAffinity.Tag = "affinity"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(150, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Agent:"
        '
        'cbAgent
        '
        Me.cbAgent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAgent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAgent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbAgent.FormattingEnabled = True
        Me.cbAgent.Location = New System.Drawing.Point(193, 38)
        Me.cbAgent.Name = "cbAgent"
        Me.cbAgent.Size = New System.Drawing.Size(90, 21)
        Me.cbAgent.TabIndex = 75
        Me.cbAgent.Tag = "agent"
        '
        'dtTo
        '
        Me.dtTo.Enabled = False
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(404, 63)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(88, 20)
        Me.dtTo.TabIndex = 79
        '
        'dtFrom
        '
        Me.dtFrom.Enabled = False
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(298, 63)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(88, 20)
        Me.dtFrom.TabIndex = 78
        '
        'cbDates
        '
        Me.cbDates.AutoSize = True
        Me.cbDates.Location = New System.Drawing.Point(214, 65)
        Me.cbDates.Name = "cbDates"
        Me.cbDates.Size = New System.Drawing.Size(88, 17)
        Me.cbDates.TabIndex = 77
        Me.cbDates.Text = "Loaded Date"
        Me.cbDates.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(388, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "to"
        '
        'txEmailAdd
        '
        Me.txEmailAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txEmailAdd.Location = New System.Drawing.Point(302, 10)
        Me.txEmailAdd.Name = "txEmailAdd"
        Me.txEmailAdd.Size = New System.Drawing.Size(97, 20)
        Me.txEmailAdd.TabIndex = 72
        Me.txEmailAdd.Tag = "emailAddress"
        Me.txEmailAdd.WaterMarkColor = System.Drawing.Color.Gray
        Me.txEmailAdd.WaterMarkText = "Email"
        '
        'txIDNum
        '
        Me.txIDNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txIDNum.Location = New System.Drawing.Point(407, 10)
        Me.txIDNum.Name = "txIDNum"
        Me.txIDNum.Size = New System.Drawing.Size(86, 20)
        Me.txIDNum.TabIndex = 64
        Me.txIDNum.Tag = "idNumber"
        Me.txIDNum.WaterMarkColor = System.Drawing.Color.Gray
        Me.txIDNum.WaterMarkText = "ID Num"
        '
        'txContactNum
        '
        Me.txContactNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txContactNum.Location = New System.Drawing.Point(220, 10)
        Me.txContactNum.Name = "txContactNum"
        Me.txContactNum.Size = New System.Drawing.Size(76, 20)
        Me.txContactNum.TabIndex = 63
        Me.txContactNum.Tag = "contactNumber"
        Me.txContactNum.WaterMarkColor = System.Drawing.Color.Gray
        Me.txContactNum.WaterMarkText = "Contact Num"
        '
        'txLastName
        '
        Me.txLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txLastName.Location = New System.Drawing.Point(151, 10)
        Me.txLastName.Name = "txLastName"
        Me.txLastName.Size = New System.Drawing.Size(63, 20)
        Me.txLastName.TabIndex = 62
        Me.txLastName.Tag = "lastName"
        Me.txLastName.WaterMarkColor = System.Drawing.Color.Gray
        Me.txLastName.WaterMarkText = "Last Name"
        '
        'txFirstName
        '
        Me.txFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txFirstName.Location = New System.Drawing.Point(73, 10)
        Me.txFirstName.Name = "txFirstName"
        Me.txFirstName.Size = New System.Drawing.Size(72, 20)
        Me.txFirstName.TabIndex = 61
        Me.txFirstName.Tag = "firstName"
        Me.txFirstName.WaterMarkColor = System.Drawing.Color.Gray
        Me.txFirstName.WaterMarkText = "First Name"
        '
        'txLeadID
        '
        Me.txLeadID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txLeadID.Location = New System.Drawing.Point(12, 10)
        Me.txLeadID.Name = "txLeadID"
        Me.txLeadID.Size = New System.Drawing.Size(55, 20)
        Me.txLeadID.TabIndex = 60
        Me.txLeadID.Tag = "LeadID"
        Me.txLeadID.WaterMarkColor = System.Drawing.Color.Gray
        Me.txLeadID.WaterMarkText = "Lead ID"
        '
        'frmLeadChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 484)
        Me.Controls.Add(Me.dtTo)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.cbDates)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbAgent)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbAffinity)
        Me.Controls.Add(Me.txEmailAdd)
        Me.Controls.Add(Me.gbChanges)
        Me.Controls.Add(Me.txIDNum)
        Me.Controls.Add(Me.txContactNum)
        Me.Controls.Add(Me.txLastName)
        Me.Controls.Add(Me.txFirstName)
        Me.Controls.Add(Me.txLeadID)
        Me.Controls.Add(Me.cbOrderDirection)
        Me.Controls.Add(Me.cbOrder)
        Me.Controls.Add(Me.cbOtherSearch)
        Me.Controls.Add(Me.txOtherValue)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btSearch)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgPickUp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmLeadChange"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lead Changes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgPickUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbChanges.ResumeLayout(False)
        Me.gbChanges.PerformLayout()
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
    Friend WithEvents cbOtherSearch As System.Windows.Forms.ComboBox
    Friend WithEvents txOtherValue As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btSearch As System.Windows.Forms.Button
    Friend WithEvents cbStatusOther As System.Windows.Forms.CheckBox
    Friend WithEvents cbBusy As System.Windows.Forms.CheckBox
    Friend WithEvents cbAvaliable As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgPickUp As System.Windows.Forms.DataGridView
    Friend WithEvents gbChanges As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbFieldChange As System.Windows.Forms.ComboBox
    Friend WithEvents lbChangeTo As System.Windows.Forms.Label
    Friend WithEvents cbChangeTo As System.Windows.Forms.ComboBox
    Friend WithEvents btConfirmChanges As System.Windows.Forms.Button
    Friend WithEvents btAddChange As System.Windows.Forms.Button
    Friend WithEvents lvChanges As System.Windows.Forms.ListView
    Friend WithEvents Change As System.Windows.Forms.ColumnHeader
    Friend WithEvents ChangeTo As System.Windows.Forms.ColumnHeader
    Friend WithEvents txEmailAdd As StingRay.WaterMarkTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbAffinity As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbAgent As System.Windows.Forms.ComboBox
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbDates As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txContactNumChange As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txEmailAddChange As System.Windows.Forms.TextBox
    Friend WithEvents btHistory As Button
    Friend WithEvents btComment As Button
End Class
