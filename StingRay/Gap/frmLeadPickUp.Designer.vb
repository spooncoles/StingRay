<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLeadPickUp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLeadPickUp))
        Me.dgPickUp = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbStatusOther = New System.Windows.Forms.CheckBox()
        Me.cbBusy = New System.Windows.Forms.CheckBox()
        Me.cbAvaliable = New System.Windows.Forms.CheckBox()
        Me.btSearch = New System.Windows.Forms.Button()
        Me.txOtherValue = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbOtherSearch = New System.Windows.Forms.ComboBox()
        Me.cbOrder = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbOrderDirection = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.cbDates = New System.Windows.Forms.CheckBox()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.btAddQueue = New System.Windows.Forms.Button()
        Me.cbAffinity = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btLoadReferal = New System.Windows.Forms.Button()
        Me.pbRecycled = New System.Windows.Forms.PictureBox()
        Me.txEmailAdd = New StingRay.WaterMarkTextBox()
        Me.txIDNum = New StingRay.WaterMarkTextBox()
        Me.txContactNum = New StingRay.WaterMarkTextBox()
        Me.txLastName = New StingRay.WaterMarkTextBox()
        Me.txFirstName = New StingRay.WaterMarkTextBox()
        Me.txLeadID = New StingRay.WaterMarkTextBox()
        CType(Me.dgPickUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.pbRecycled, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgPickUp
        '
        Me.dgPickUp.AllowUserToAddRows = False
        Me.dgPickUp.AllowUserToDeleteRows = False
        Me.dgPickUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgPickUp.Location = New System.Drawing.Point(12, 84)
        Me.dgPickUp.Name = "dgPickUp"
        Me.dgPickUp.ReadOnly = True
        Me.dgPickUp.RowHeadersVisible = False
        Me.dgPickUp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPickUp.Size = New System.Drawing.Size(707, 353)
        Me.dgPickUp.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbStatusOther)
        Me.GroupBox1.Controls.Add(Me.cbBusy)
        Me.GroupBox1.Controls.Add(Me.cbAvaliable)
        Me.GroupBox1.Location = New System.Drawing.Point(533, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(78, 72)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
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
        'btSearch
        '
        Me.btSearch.Location = New System.Drawing.Point(617, 6)
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(102, 27)
        Me.btSearch.TabIndex = 11
        Me.btSearch.Text = "Search"
        Me.btSearch.UseVisualStyleBackColor = True
        '
        'txOtherValue
        '
        Me.txOtherValue.Location = New System.Drawing.Point(151, 57)
        Me.txOtherValue.Name = "txOtherValue"
        Me.txOtherValue.Size = New System.Drawing.Size(120, 20)
        Me.txOtherValue.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Other:"
        '
        'cbOtherSearch
        '
        Me.cbOtherSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOtherSearch.FormattingEnabled = True
        Me.cbOtherSearch.Location = New System.Drawing.Point(46, 57)
        Me.cbOtherSearch.Name = "cbOtherSearch"
        Me.cbOtherSearch.Size = New System.Drawing.Size(99, 21)
        Me.cbOtherSearch.TabIndex = 6
        '
        'cbOrder
        '
        Me.cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOrder.FormattingEnabled = True
        Me.cbOrder.Items.AddRange(New Object() {"loadedDate", "leadID", "firstName", "lastName", "contactNumber", "idNumber", "affinity"})
        Me.cbOrder.Location = New System.Drawing.Point(356, 56)
        Me.cbOrder.Name = "cbOrder"
        Me.cbOrder.Size = New System.Drawing.Size(80, 21)
        Me.cbOrder.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(321, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Sort:"
        '
        'cbOrderDirection
        '
        Me.cbOrderDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOrderDirection.FormattingEnabled = True
        Me.cbOrderDirection.Items.AddRange(New Object() {"ASC", "DESC"})
        Me.cbOrderDirection.Location = New System.Drawing.Point(442, 56)
        Me.cbOrderDirection.Name = "cbOrderDirection"
        Me.cbOrderDirection.Size = New System.Drawing.Size(51, 21)
        Me.cbOrderDirection.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(389, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "to"
        '
        'dtTo
        '
        Me.dtTo.Enabled = False
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(405, 30)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(88, 20)
        Me.dtTo.TabIndex = 46
        '
        'cbDates
        '
        Me.cbDates.AutoSize = True
        Me.cbDates.Location = New System.Drawing.Point(215, 32)
        Me.cbDates.Name = "cbDates"
        Me.cbDates.Size = New System.Drawing.Size(88, 17)
        Me.cbDates.TabIndex = 44
        Me.cbDates.Text = "Loaded Date"
        Me.cbDates.UseVisualStyleBackColor = True
        '
        'dtFrom
        '
        Me.dtFrom.Enabled = False
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(299, 30)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(88, 20)
        Me.dtFrom.TabIndex = 45
        '
        'btAddQueue
        '
        Me.btAddQueue.Location = New System.Drawing.Point(617, 56)
        Me.btAddQueue.Name = "btAddQueue"
        Me.btAddQueue.Size = New System.Drawing.Size(102, 22)
        Me.btAddQueue.TabIndex = 48
        Me.btAddQueue.Text = "Add all to queue"
        Me.btAddQueue.UseVisualStyleBackColor = True
        '
        'cbAffinity
        '
        Me.cbAffinity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbAffinity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbAffinity.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cbAffinity.FormattingEnabled = True
        Me.cbAffinity.Location = New System.Drawing.Point(55, 30)
        Me.cbAffinity.Name = "cbAffinity"
        Me.cbAffinity.Size = New System.Drawing.Size(90, 21)
        Me.cbAffinity.TabIndex = 49
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Affinity:"
        '
        'btLoadReferal
        '
        Me.btLoadReferal.Location = New System.Drawing.Point(617, 33)
        Me.btLoadReferal.Name = "btLoadReferal"
        Me.btLoadReferal.Size = New System.Drawing.Size(102, 22)
        Me.btLoadReferal.TabIndex = 52
        Me.btLoadReferal.Text = "Load as Zwinger"
        Me.btLoadReferal.UseVisualStyleBackColor = True
        '
        'pbRecycled
        '
        Me.pbRecycled.BackColor = System.Drawing.Color.Transparent
        Me.pbRecycled.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbRecycled.Image = CType(resources.GetObject("pbRecycled.Image"), System.Drawing.Image)
        Me.pbRecycled.Location = New System.Drawing.Point(499, 51)
        Me.pbRecycled.Name = "pbRecycled"
        Me.pbRecycled.Size = New System.Drawing.Size(34, 27)
        Me.pbRecycled.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbRecycled.TabIndex = 54
        Me.pbRecycled.TabStop = False
        Me.pbRecycled.Visible = False
        '
        'txEmailAdd
        '
        Me.txEmailAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txEmailAdd.Location = New System.Drawing.Point(302, 6)
        Me.txEmailAdd.Name = "txEmailAdd"
        Me.txEmailAdd.Size = New System.Drawing.Size(97, 20)
        Me.txEmailAdd.TabIndex = 50
        Me.txEmailAdd.Tag = "emailAddress"
        Me.txEmailAdd.WaterMarkColor = System.Drawing.Color.Gray
        Me.txEmailAdd.WaterMarkText = "Email"
        '
        'txIDNum
        '
        Me.txIDNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txIDNum.Location = New System.Drawing.Point(405, 6)
        Me.txIDNum.Name = "txIDNum"
        Me.txIDNum.Size = New System.Drawing.Size(86, 20)
        Me.txIDNum.TabIndex = 23
        Me.txIDNum.Tag = "idNumber"
        Me.txIDNum.WaterMarkColor = System.Drawing.Color.Gray
        Me.txIDNum.WaterMarkText = "ID Num"
        '
        'txContactNum
        '
        Me.txContactNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txContactNum.Location = New System.Drawing.Point(220, 6)
        Me.txContactNum.Name = "txContactNum"
        Me.txContactNum.Size = New System.Drawing.Size(76, 20)
        Me.txContactNum.TabIndex = 22
        Me.txContactNum.Tag = "contactNumber"
        Me.txContactNum.WaterMarkColor = System.Drawing.Color.Gray
        Me.txContactNum.WaterMarkText = "Contact Num"
        '
        'txLastName
        '
        Me.txLastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txLastName.Location = New System.Drawing.Point(151, 6)
        Me.txLastName.Name = "txLastName"
        Me.txLastName.Size = New System.Drawing.Size(63, 20)
        Me.txLastName.TabIndex = 21
        Me.txLastName.Tag = "lastName"
        Me.txLastName.WaterMarkColor = System.Drawing.Color.Gray
        Me.txLastName.WaterMarkText = "Last Name"
        '
        'txFirstName
        '
        Me.txFirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txFirstName.Location = New System.Drawing.Point(73, 6)
        Me.txFirstName.Name = "txFirstName"
        Me.txFirstName.Size = New System.Drawing.Size(72, 20)
        Me.txFirstName.TabIndex = 20
        Me.txFirstName.Tag = "firstName"
        Me.txFirstName.WaterMarkColor = System.Drawing.Color.Gray
        Me.txFirstName.WaterMarkText = "First Name"
        '
        'txLeadID
        '
        Me.txLeadID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txLeadID.Location = New System.Drawing.Point(12, 6)
        Me.txLeadID.Name = "txLeadID"
        Me.txLeadID.Size = New System.Drawing.Size(55, 20)
        Me.txLeadID.TabIndex = 19
        Me.txLeadID.Tag = "LeadID"
        Me.txLeadID.WaterMarkColor = System.Drawing.Color.Gray
        Me.txLeadID.WaterMarkText = "Lead ID"
        '
        'frmLeadPickUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 449)
        Me.Controls.Add(Me.pbRecycled)
        Me.Controls.Add(Me.btLoadReferal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txEmailAdd)
        Me.Controls.Add(Me.cbAffinity)
        Me.Controls.Add(Me.btAddQueue)
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
        Me.Controls.Add(Me.cbOtherSearch)
        Me.Controls.Add(Me.txOtherValue)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btSearch)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgPickUp)
        Me.Controls.Add(Me.cbDates)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmLeadPickUp"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pick-Up a Lead"
        CType(Me.dgPickUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.pbRecycled, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgPickUp As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbStatusOther As System.Windows.Forms.CheckBox
    Friend WithEvents cbBusy As System.Windows.Forms.CheckBox
    Friend WithEvents cbAvaliable As System.Windows.Forms.CheckBox
    Friend WithEvents btSearch As System.Windows.Forms.Button
    Friend WithEvents txOtherValue As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbOtherSearch As System.Windows.Forms.ComboBox
    Friend WithEvents cbOrder As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbOrderDirection As System.Windows.Forms.ComboBox
    Friend WithEvents txLeadID As StingRay.WaterMarkTextBox
    Friend WithEvents txFirstName As StingRay.WaterMarkTextBox
    Friend WithEvents txLastName As StingRay.WaterMarkTextBox
    Friend WithEvents txContactNum As StingRay.WaterMarkTextBox
    Friend WithEvents txIDNum As StingRay.WaterMarkTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbDates As System.Windows.Forms.CheckBox
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btAddQueue As System.Windows.Forms.Button
    Friend WithEvents cbAffinity As System.Windows.Forms.ComboBox
    Friend WithEvents txEmailAdd As StingRay.WaterMarkTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btLoadReferal As System.Windows.Forms.Button
    Friend WithEvents pbRecycled As PictureBox
End Class
