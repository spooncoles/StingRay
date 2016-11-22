<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoadLead
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabSource = New System.Windows.Forms.TabPage()
        Me.cbOrder = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btSearch = New System.Windows.Forms.Button()
        Me.dgSelectSource = New System.Windows.Forms.DataGridView()
        Me.rbAffinity = New System.Windows.Forms.RadioButton()
        Me.rbZwinger = New System.Windows.Forms.RadioButton()
        Me.tabDetails = New System.Windows.Forms.TabPage()
        Me.btAddToBatch = New System.Windows.Forms.Button()
        Me.txComment = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btLoad = New System.Windows.Forms.Button()
        Me.cbAgent = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cbSource = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txIdNum = New System.Windows.Forms.MaskedTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lbAffinityName = New System.Windows.Forms.Label()
        Me.lbAffinityCode = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txContactNum = New System.Windows.Forms.MaskedTextBox()
        Me.txEmailAdd = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbTitle = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txLastName = New System.Windows.Forms.TextBox()
        Me.txFirstName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbBatch = New System.Windows.Forms.TabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.dgLeadsToUpload = New System.Windows.Forms.DataGridView()
        Me.title = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.firstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.contactNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Agent = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.affinityName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.source = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.affinityCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.affinityID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leadNewID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dupLeadID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsDgRight = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsEditLead = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteAsDupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btUpload = New System.Windows.Forms.Button()
        Me.btValidate = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btRefreshInBatch = New System.Windows.Forms.Button()
        Me.btAutoAllocate = New System.Windows.Forms.Button()
        Me.btAllocateSelected = New System.Windows.Forms.Button()
        Me.dgAgents = New System.Windows.Forms.DataGridView()
        Me.tbDups = New System.Windows.Forms.TabPage()
        Me.btConfirmSingleDup = New System.Windows.Forms.Button()
        Me.btEmailBusy = New System.Windows.Forms.Button()
        Me.btCheckDups = New System.Windows.Forms.Button()
        Me.btConfirmDups = New System.Windows.Forms.Button()
        Me.dgDups = New System.Windows.Forms.DataGridView()
        Me.tbAPI = New System.Windows.Forms.TabPage()
        Me.btExample = New System.Windows.Forms.Button()
        Me.btLoadToLeadNew = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.rbCopyAll = New System.Windows.Forms.RadioButton()
        Me.rbCopySelected = New System.Windows.Forms.RadioButton()
        Me.btCopy = New System.Windows.Forms.Button()
        Me.btApiCopy = New System.Windows.Forms.Button()
        Me.dgAPI = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.txCampaign = New System.Windows.Forms.TextBox()
        Me.lbCampaign = New System.Windows.Forms.Label()
        Me.txEmailAddSearch = New StingRay.WaterMarkTextBox()
        Me.txIdNumSearch = New StingRay.WaterMarkTextBox()
        Me.txContactNumSearch = New StingRay.WaterMarkTextBox()
        Me.txNameSearch = New StingRay.WaterMarkTextBox()
        Me.tabControl.SuspendLayout()
        Me.tabSource.SuspendLayout()
        CType(Me.dgSelectSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDetails.SuspendLayout()
        Me.tbBatch.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.dgLeadsToUpload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsDgRight.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgAgents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDups.SuspendLayout()
        CType(Me.dgDups, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbAPI.SuspendLayout()
        CType(Me.dgAPI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tabSource)
        Me.tabControl.Controls.Add(Me.tabDetails)
        Me.tabControl.Controls.Add(Me.tbBatch)
        Me.tabControl.Controls.Add(Me.tbDups)
        Me.tabControl.Controls.Add(Me.tbAPI)
        Me.tabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl.Location = New System.Drawing.Point(0, 0)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(859, 464)
        Me.tabControl.TabIndex = 0
        '
        'tabSource
        '
        Me.tabSource.Controls.Add(Me.txEmailAddSearch)
        Me.tabSource.Controls.Add(Me.txIdNumSearch)
        Me.tabSource.Controls.Add(Me.txContactNumSearch)
        Me.tabSource.Controls.Add(Me.txNameSearch)
        Me.tabSource.Controls.Add(Me.cbOrder)
        Me.tabSource.Controls.Add(Me.Label8)
        Me.tabSource.Controls.Add(Me.btSearch)
        Me.tabSource.Controls.Add(Me.dgSelectSource)
        Me.tabSource.Controls.Add(Me.rbAffinity)
        Me.tabSource.Controls.Add(Me.rbZwinger)
        Me.tabSource.Location = New System.Drawing.Point(4, 22)
        Me.tabSource.Name = "tabSource"
        Me.tabSource.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSource.Size = New System.Drawing.Size(851, 438)
        Me.tabSource.TabIndex = 0
        Me.tabSource.Text = "Source"
        Me.tabSource.UseVisualStyleBackColor = True
        '
        'cbOrder
        '
        Me.cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbOrder.FormattingEnabled = True
        Me.cbOrder.Items.AddRange(New Object() {"affinityName", "contactNum", "Vat_ID"})
        Me.cbOrder.Location = New System.Drawing.Point(418, 28)
        Me.cbOrder.Name = "cbOrder"
        Me.cbOrder.Size = New System.Drawing.Size(92, 21)
        Me.cbOrder.TabIndex = 38
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(415, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Sort:"
        '
        'btSearch
        '
        Me.btSearch.Location = New System.Drawing.Point(741, 6)
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(102, 44)
        Me.btSearch.TabIndex = 39
        Me.btSearch.Text = "Search"
        Me.btSearch.UseVisualStyleBackColor = True
        '
        'dgSelectSource
        '
        Me.dgSelectSource.AllowUserToAddRows = False
        Me.dgSelectSource.AllowUserToDeleteRows = False
        Me.dgSelectSource.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSelectSource.Location = New System.Drawing.Point(8, 55)
        Me.dgSelectSource.Name = "dgSelectSource"
        Me.dgSelectSource.ReadOnly = True
        Me.dgSelectSource.RowHeadersVisible = False
        Me.dgSelectSource.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSelectSource.Size = New System.Drawing.Size(835, 375)
        Me.dgSelectSource.TabIndex = 30
        '
        'rbAffinity
        '
        Me.rbAffinity.AutoSize = True
        Me.rbAffinity.Checked = True
        Me.rbAffinity.Location = New System.Drawing.Point(71, 6)
        Me.rbAffinity.Name = "rbAffinity"
        Me.rbAffinity.Size = New System.Drawing.Size(56, 17)
        Me.rbAffinity.TabIndex = 1
        Me.rbAffinity.TabStop = True
        Me.rbAffinity.Text = "Affinity"
        Me.rbAffinity.UseVisualStyleBackColor = True
        '
        'rbZwinger
        '
        Me.rbZwinger.AutoSize = True
        Me.rbZwinger.Location = New System.Drawing.Point(8, 6)
        Me.rbZwinger.Name = "rbZwinger"
        Me.rbZwinger.Size = New System.Drawing.Size(59, 17)
        Me.rbZwinger.TabIndex = 0
        Me.rbZwinger.Text = "Referal"
        Me.rbZwinger.UseVisualStyleBackColor = True
        '
        'tabDetails
        '
        Me.tabDetails.Controls.Add(Me.txCampaign)
        Me.tabDetails.Controls.Add(Me.lbCampaign)
        Me.tabDetails.Controls.Add(Me.btAddToBatch)
        Me.tabDetails.Controls.Add(Me.txComment)
        Me.tabDetails.Controls.Add(Me.Label12)
        Me.tabDetails.Controls.Add(Me.btLoad)
        Me.tabDetails.Controls.Add(Me.cbAgent)
        Me.tabDetails.Controls.Add(Me.Label11)
        Me.tabDetails.Controls.Add(Me.cbSource)
        Me.tabDetails.Controls.Add(Me.Label9)
        Me.tabDetails.Controls.Add(Me.txIdNum)
        Me.tabDetails.Controls.Add(Me.Label10)
        Me.tabDetails.Controls.Add(Me.lbAffinityName)
        Me.tabDetails.Controls.Add(Me.lbAffinityCode)
        Me.tabDetails.Controls.Add(Me.Label7)
        Me.tabDetails.Controls.Add(Me.txContactNum)
        Me.tabDetails.Controls.Add(Me.txEmailAdd)
        Me.tabDetails.Controls.Add(Me.Label6)
        Me.tabDetails.Controls.Add(Me.cbTitle)
        Me.tabDetails.Controls.Add(Me.Label1)
        Me.tabDetails.Controls.Add(Me.txLastName)
        Me.tabDetails.Controls.Add(Me.txFirstName)
        Me.tabDetails.Controls.Add(Me.Label5)
        Me.tabDetails.Controls.Add(Me.Label4)
        Me.tabDetails.Controls.Add(Me.Label3)
        Me.tabDetails.Controls.Add(Me.Label2)
        Me.tabDetails.Location = New System.Drawing.Point(4, 22)
        Me.tabDetails.Name = "tabDetails"
        Me.tabDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDetails.Size = New System.Drawing.Size(851, 438)
        Me.tabDetails.TabIndex = 1
        Me.tabDetails.Text = "Details"
        Me.tabDetails.UseVisualStyleBackColor = True
        '
        'btAddToBatch
        '
        Me.btAddToBatch.Location = New System.Drawing.Point(16, 333)
        Me.btAddToBatch.Name = "btAddToBatch"
        Me.btAddToBatch.Size = New System.Drawing.Size(221, 23)
        Me.btAddToBatch.TabIndex = 30
        Me.btAddToBatch.Text = "Add To Batch"
        Me.btAddToBatch.UseVisualStyleBackColor = True
        Me.btAddToBatch.Visible = False
        '
        'txComment
        '
        Me.txComment.Location = New System.Drawing.Point(89, 254)
        Me.txComment.MaxLength = 100
        Me.txComment.Name = "txComment"
        Me.txComment.Size = New System.Drawing.Size(149, 20)
        Me.txComment.TabIndex = 28
        Me.txComment.Tag = "firstName"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(26, 257)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Comment"
        '
        'btLoad
        '
        Me.btLoad.Location = New System.Drawing.Point(17, 304)
        Me.btLoad.Name = "btLoad"
        Me.btLoad.Size = New System.Drawing.Size(221, 23)
        Me.btLoad.TabIndex = 8
        Me.btLoad.Text = "Load Lead"
        Me.btLoad.UseVisualStyleBackColor = True
        '
        'cbAgent
        '
        Me.cbAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbAgent.FormattingEnabled = True
        Me.cbAgent.Location = New System.Drawing.Point(88, 227)
        Me.cbAgent.Name = "cbAgent"
        Me.cbAgent.Size = New System.Drawing.Size(150, 21)
        Me.cbAgent.TabIndex = 7
        Me.cbAgent.Tag = "agent"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(42, 230)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(35, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Agent"
        '
        'cbSource
        '
        Me.cbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSource.FormattingEnabled = True
        Me.cbSource.Location = New System.Drawing.Point(89, 200)
        Me.cbSource.Name = "cbSource"
        Me.cbSource.Size = New System.Drawing.Size(78, 21)
        Me.cbSource.TabIndex = 6
        Me.cbSource.Tag = "source"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(43, 203)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Source"
        '
        'txIdNum
        '
        Me.txIdNum.Location = New System.Drawing.Point(89, 148)
        Me.txIdNum.Mask = "000000-0000-000"
        Me.txIdNum.Name = "txIdNum"
        Me.txIdNum.Size = New System.Drawing.Size(149, 20)
        Me.txIdNum.TabIndex = 5
        Me.txIdNum.Tag = "idNumber"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 27)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Affinity Name"
        '
        'lbAffinityName
        '
        Me.lbAffinityName.AutoSize = True
        Me.lbAffinityName.Location = New System.Drawing.Point(86, 27)
        Me.lbAffinityName.Name = "lbAffinityName"
        Me.lbAffinityName.Size = New System.Drawing.Size(28, 13)
        Me.lbAffinityName.TabIndex = 22
        Me.lbAffinityName.Text = "###"
        '
        'lbAffinityCode
        '
        Me.lbAffinityCode.AutoSize = True
        Me.lbAffinityCode.Location = New System.Drawing.Point(86, 14)
        Me.lbAffinityCode.Name = "lbAffinityCode"
        Me.lbAffinityCode.Size = New System.Drawing.Size(28, 13)
        Me.lbAffinityCode.TabIndex = 21
        Me.lbAffinityCode.Text = "###"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Affinity Code"
        '
        'txContactNum
        '
        Me.txContactNum.Location = New System.Drawing.Point(89, 122)
        Me.txContactNum.Mask = "(999) 000-0000"
        Me.txContactNum.Name = "txContactNum"
        Me.txContactNum.Size = New System.Drawing.Size(149, 20)
        Me.txContactNum.TabIndex = 4
        Me.txContactNum.Tag = "contactNumber"
        '
        'txEmailAdd
        '
        Me.txEmailAdd.Location = New System.Drawing.Point(89, 174)
        Me.txEmailAdd.MaxLength = 100
        Me.txEmailAdd.Name = "txEmailAdd"
        Me.txEmailAdd.Size = New System.Drawing.Size(149, 20)
        Me.txEmailAdd.TabIndex = 5
        Me.txEmailAdd.Tag = "emailAddress"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 177)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Email Add"
        '
        'cbTitle
        '
        Me.cbTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTitle.FormattingEnabled = True
        Me.cbTitle.Items.AddRange(New Object() {"Mr", "Mrs", "Mst", "Miss", "Dr", "Prof", "Adv"})
        Me.cbTitle.Location = New System.Drawing.Point(89, 43)
        Me.cbTitle.Name = "cbTitle"
        Me.cbTitle.Size = New System.Drawing.Size(78, 21)
        Me.cbTitle.TabIndex = 1
        Me.cbTitle.Tag = "title"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Title"
        '
        'txLastName
        '
        Me.txLastName.Location = New System.Drawing.Point(89, 96)
        Me.txLastName.MaxLength = 100
        Me.txLastName.Name = "txLastName"
        Me.txLastName.Size = New System.Drawing.Size(148, 20)
        Me.txLastName.TabIndex = 3
        Me.txLastName.Tag = "lastName"
        '
        'txFirstName
        '
        Me.txFirstName.Location = New System.Drawing.Point(88, 70)
        Me.txFirstName.MaxLength = 100
        Me.txFirstName.Name = "txFirstName"
        Me.txFirstName.Size = New System.Drawing.Size(149, 20)
        Me.txFirstName.TabIndex = 2
        Me.txFirstName.Tag = "firstName"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 151)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "ID Num"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 125)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Contact Num"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Last Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "First Name"
        '
        'tbBatch
        '
        Me.tbBatch.Controls.Add(Me.TableLayoutPanel3)
        Me.tbBatch.Location = New System.Drawing.Point(4, 22)
        Me.tbBatch.Name = "tbBatch"
        Me.tbBatch.Padding = New System.Windows.Forms.Padding(3)
        Me.tbBatch.Size = New System.Drawing.Size(851, 438)
        Me.tbBatch.TabIndex = 2
        Me.tbBatch.Text = "Batch"
        Me.tbBatch.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Panel1, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(845, 432)
        Me.TableLayoutPanel3.TabIndex = 6
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.dgLeadsToUpload, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(539, 426)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'dgLeadsToUpload
        '
        Me.dgLeadsToUpload.AllowUserToAddRows = False
        Me.dgLeadsToUpload.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgLeadsToUpload.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLeadsToUpload.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLeadsToUpload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLeadsToUpload.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.title, Me.firstName, Me.lastName, Me.contactNum, Me.Email, Me.Agent, Me.affinityName, Me.comment, Me.source, Me.affinityCode, Me.affinityID, Me.leadNewID, Me.dupLeadID})
        Me.dgLeadsToUpload.ContextMenuStrip = Me.cmsDgRight
        Me.dgLeadsToUpload.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgLeadsToUpload.Location = New System.Drawing.Point(3, 38)
        Me.dgLeadsToUpload.Name = "dgLeadsToUpload"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLeadsToUpload.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgLeadsToUpload.RowHeadersVisible = False
        Me.dgLeadsToUpload.RowHeadersWidth = 25
        Me.dgLeadsToUpload.Size = New System.Drawing.Size(533, 385)
        Me.dgLeadsToUpload.TabIndex = 4
        '
        'title
        '
        Me.title.HeaderText = "Title"
        Me.title.Name = "title"
        Me.title.ReadOnly = True
        Me.title.Width = 52
        '
        'firstName
        '
        Me.firstName.HeaderText = "First Name"
        Me.firstName.Name = "firstName"
        Me.firstName.ReadOnly = True
        Me.firstName.Width = 82
        '
        'lastName
        '
        Me.lastName.HeaderText = "Last Name"
        Me.lastName.Name = "lastName"
        Me.lastName.ReadOnly = True
        Me.lastName.Width = 83
        '
        'contactNum
        '
        Me.contactNum.HeaderText = "Contact Number"
        Me.contactNum.Name = "contactNum"
        Me.contactNum.ReadOnly = True
        Me.contactNum.Width = 109
        '
        'Email
        '
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Width = 57
        '
        'Agent
        '
        Me.Agent.HeaderText = "Agent"
        Me.Agent.Name = "Agent"
        Me.Agent.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Agent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Agent.Width = 60
        '
        'affinityName
        '
        Me.affinityName.HeaderText = "affinityName"
        Me.affinityName.Name = "affinityName"
        Me.affinityName.ReadOnly = True
        Me.affinityName.Width = 90
        '
        'comment
        '
        Me.comment.HeaderText = "Comment"
        Me.comment.Name = "comment"
        Me.comment.ReadOnly = True
        Me.comment.Width = 76
        '
        'source
        '
        Me.source.HeaderText = "Source"
        Me.source.Name = "source"
        Me.source.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.source.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.source.Width = 66
        '
        'affinityCode
        '
        Me.affinityCode.HeaderText = "Affinity Code"
        Me.affinityCode.Name = "affinityCode"
        Me.affinityCode.ReadOnly = True
        Me.affinityCode.Width = 91
        '
        'affinityID
        '
        Me.affinityID.HeaderText = "Affinity ID"
        Me.affinityID.Name = "affinityID"
        Me.affinityID.ReadOnly = True
        Me.affinityID.Width = 77
        '
        'leadNewID
        '
        Me.leadNewID.HeaderText = "leadNewID"
        Me.leadNewID.Name = "leadNewID"
        Me.leadNewID.ReadOnly = True
        Me.leadNewID.Visible = False
        Me.leadNewID.Width = 85
        '
        'dupLeadID
        '
        Me.dupLeadID.HeaderText = "dupLeadID"
        Me.dupLeadID.Name = "dupLeadID"
        Me.dupLeadID.ReadOnly = True
        Me.dupLeadID.Visible = False
        Me.dupLeadID.Width = 85
        '
        'cmsDgRight
        '
        Me.cmsDgRight.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsEditLead, Me.cmsDelete, Me.DeleteAsDupToolStripMenuItem})
        Me.cmsDgRight.Name = "cmsDgRight"
        Me.cmsDgRight.Size = New System.Drawing.Size(149, 70)
        '
        'cmsEditLead
        '
        Me.cmsEditLead.Name = "cmsEditLead"
        Me.cmsEditLead.Size = New System.Drawing.Size(148, 22)
        Me.cmsEditLead.Text = "Edit"
        '
        'cmsDelete
        '
        Me.cmsDelete.Name = "cmsDelete"
        Me.cmsDelete.Size = New System.Drawing.Size(148, 22)
        Me.cmsDelete.Text = "Delete"
        '
        'DeleteAsDupToolStripMenuItem
        '
        Me.DeleteAsDupToolStripMenuItem.Name = "DeleteAsDupToolStripMenuItem"
        Me.DeleteAsDupToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.DeleteAsDupToolStripMenuItem.Text = "Delete As Dup"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btUpload, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btValidate, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(533, 29)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'btUpload
        '
        Me.btUpload.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btUpload.Enabled = False
        Me.btUpload.Location = New System.Drawing.Point(269, 3)
        Me.btUpload.Name = "btUpload"
        Me.btUpload.Size = New System.Drawing.Size(261, 23)
        Me.btUpload.TabIndex = 23
        Me.btUpload.Text = "Upload"
        Me.btUpload.UseVisualStyleBackColor = True
        '
        'btValidate
        '
        Me.btValidate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btValidate.Location = New System.Drawing.Point(3, 3)
        Me.btValidate.Name = "btValidate"
        Me.btValidate.Size = New System.Drawing.Size(260, 23)
        Me.btValidate.TabIndex = 22
        Me.btValidate.Text = "Validate"
        Me.btValidate.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btRefreshInBatch)
        Me.Panel1.Controls.Add(Me.btAutoAllocate)
        Me.Panel1.Controls.Add(Me.btAllocateSelected)
        Me.Panel1.Controls.Add(Me.dgAgents)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(548, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(294, 426)
        Me.Panel1.TabIndex = 7
        '
        'btRefreshInBatch
        '
        Me.btRefreshInBatch.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btRefreshInBatch.Location = New System.Drawing.Point(0, 357)
        Me.btRefreshInBatch.Name = "btRefreshInBatch"
        Me.btRefreshInBatch.Size = New System.Drawing.Size(294, 23)
        Me.btRefreshInBatch.TabIndex = 3
        Me.btRefreshInBatch.Text = "Refresh In Batch count"
        Me.btRefreshInBatch.UseVisualStyleBackColor = True
        '
        'btAutoAllocate
        '
        Me.btAutoAllocate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btAutoAllocate.Location = New System.Drawing.Point(0, 380)
        Me.btAutoAllocate.Name = "btAutoAllocate"
        Me.btAutoAllocate.Size = New System.Drawing.Size(294, 23)
        Me.btAutoAllocate.TabIndex = 2
        Me.btAutoAllocate.Text = "Auto Allocate"
        Me.btAutoAllocate.UseVisualStyleBackColor = True
        '
        'btAllocateSelected
        '
        Me.btAllocateSelected.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btAllocateSelected.Location = New System.Drawing.Point(0, 403)
        Me.btAllocateSelected.Name = "btAllocateSelected"
        Me.btAllocateSelected.Size = New System.Drawing.Size(294, 23)
        Me.btAllocateSelected.TabIndex = 1
        Me.btAllocateSelected.Text = "Allocate Evenly"
        Me.btAllocateSelected.UseVisualStyleBackColor = True
        '
        'dgAgents
        '
        Me.dgAgents.AllowUserToAddRows = False
        Me.dgAgents.AllowUserToDeleteRows = False
        Me.dgAgents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgAgents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAgents.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgAgents.Location = New System.Drawing.Point(0, 0)
        Me.dgAgents.Name = "dgAgents"
        Me.dgAgents.ReadOnly = True
        Me.dgAgents.RowHeadersVisible = False
        Me.dgAgents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAgents.Size = New System.Drawing.Size(294, 347)
        Me.dgAgents.TabIndex = 0
        '
        'tbDups
        '
        Me.tbDups.Controls.Add(Me.btConfirmSingleDup)
        Me.tbDups.Controls.Add(Me.btEmailBusy)
        Me.tbDups.Controls.Add(Me.btCheckDups)
        Me.tbDups.Controls.Add(Me.btConfirmDups)
        Me.tbDups.Controls.Add(Me.dgDups)
        Me.tbDups.Location = New System.Drawing.Point(4, 22)
        Me.tbDups.Name = "tbDups"
        Me.tbDups.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDups.Size = New System.Drawing.Size(851, 438)
        Me.tbDups.TabIndex = 3
        Me.tbDups.Text = "Dups"
        Me.tbDups.UseVisualStyleBackColor = True
        '
        'btConfirmSingleDup
        '
        Me.btConfirmSingleDup.Enabled = False
        Me.btConfirmSingleDup.Location = New System.Drawing.Point(413, 6)
        Me.btConfirmSingleDup.Name = "btConfirmSingleDup"
        Me.btConfirmSingleDup.Size = New System.Drawing.Size(118, 23)
        Me.btConfirmSingleDup.TabIndex = 4
        Me.btConfirmSingleDup.Text = "Confirm red as dups"
        Me.btConfirmSingleDup.UseVisualStyleBackColor = True
        '
        'btEmailBusy
        '
        Me.btEmailBusy.Enabled = False
        Me.btEmailBusy.Location = New System.Drawing.Point(289, 7)
        Me.btEmailBusy.Name = "btEmailBusy"
        Me.btEmailBusy.Size = New System.Drawing.Size(118, 23)
        Me.btEmailBusy.TabIndex = 3
        Me.btEmailBusy.Text = "Email Busy's in blue"
        Me.btEmailBusy.UseVisualStyleBackColor = True
        '
        'btCheckDups
        '
        Me.btCheckDups.Location = New System.Drawing.Point(8, 7)
        Me.btCheckDups.Name = "btCheckDups"
        Me.btCheckDups.Size = New System.Drawing.Size(118, 23)
        Me.btCheckDups.TabIndex = 2
        Me.btCheckDups.Text = "Check Dups"
        Me.btCheckDups.UseVisualStyleBackColor = True
        '
        'btConfirmDups
        '
        Me.btConfirmDups.Location = New System.Drawing.Point(725, 7)
        Me.btConfirmDups.Name = "btConfirmDups"
        Me.btConfirmDups.Size = New System.Drawing.Size(118, 23)
        Me.btConfirmDups.TabIndex = 1
        Me.btConfirmDups.Text = "Confirm all as dups"
        Me.btConfirmDups.UseVisualStyleBackColor = True
        '
        'dgDups
        '
        Me.dgDups.AllowUserToAddRows = False
        Me.dgDups.AllowUserToDeleteRows = False
        Me.dgDups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgDups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDups.Location = New System.Drawing.Point(8, 36)
        Me.dgDups.Name = "dgDups"
        Me.dgDups.ReadOnly = True
        Me.dgDups.RowHeadersVisible = False
        Me.dgDups.Size = New System.Drawing.Size(835, 394)
        Me.dgDups.TabIndex = 0
        '
        'tbAPI
        '
        Me.tbAPI.Controls.Add(Me.btExample)
        Me.tbAPI.Controls.Add(Me.btLoadToLeadNew)
        Me.tbAPI.Controls.Add(Me.Label13)
        Me.tbAPI.Controls.Add(Me.rbCopyAll)
        Me.tbAPI.Controls.Add(Me.rbCopySelected)
        Me.tbAPI.Controls.Add(Me.btCopy)
        Me.tbAPI.Controls.Add(Me.btApiCopy)
        Me.tbAPI.Controls.Add(Me.dgAPI)
        Me.tbAPI.Location = New System.Drawing.Point(4, 22)
        Me.tbAPI.Name = "tbAPI"
        Me.tbAPI.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAPI.Size = New System.Drawing.Size(851, 438)
        Me.tbAPI.TabIndex = 4
        Me.tbAPI.Text = "API"
        Me.tbAPI.UseVisualStyleBackColor = True
        '
        'btExample
        '
        Me.btExample.Location = New System.Drawing.Point(322, 6)
        Me.btExample.Name = "btExample"
        Me.btExample.Size = New System.Drawing.Size(170, 23)
        Me.btExample.TabIndex = 20
        Me.btExample.Text = "Excel Example"
        Me.btExample.UseVisualStyleBackColor = True
        '
        'btLoadToLeadNew
        '
        Me.btLoadToLeadNew.Location = New System.Drawing.Point(322, 29)
        Me.btLoadToLeadNew.Name = "btLoadToLeadNew"
        Me.btLoadToLeadNew.Size = New System.Drawing.Size(170, 23)
        Me.btLoadToLeadNew.TabIndex = 19
        Me.btLoadToLeadNew.Text = "Load Excel to Lead New"
        Me.btLoadToLeadNew.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(161, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Local leads that are unallocated:"
        '
        'rbCopyAll
        '
        Me.rbCopyAll.AutoSize = True
        Me.rbCopyAll.Checked = True
        Me.rbCopyAll.Location = New System.Drawing.Point(745, 29)
        Me.rbCopyAll.Name = "rbCopyAll"
        Me.rbCopyAll.Size = New System.Drawing.Size(63, 17)
        Me.rbCopyAll.TabIndex = 4
        Me.rbCopyAll.TabStop = True
        Me.rbCopyAll.Text = "Copy All"
        Me.rbCopyAll.UseVisualStyleBackColor = True
        '
        'rbCopySelected
        '
        Me.rbCopySelected.AutoSize = True
        Me.rbCopySelected.Location = New System.Drawing.Point(745, 6)
        Me.rbCopySelected.Name = "rbCopySelected"
        Me.rbCopySelected.Size = New System.Drawing.Size(94, 17)
        Me.rbCopySelected.TabIndex = 3
        Me.rbCopySelected.Text = "Copy Selected"
        Me.rbCopySelected.UseVisualStyleBackColor = True
        '
        'btCopy
        '
        Me.btCopy.Location = New System.Drawing.Point(617, 6)
        Me.btCopy.Name = "btCopy"
        Me.btCopy.Size = New System.Drawing.Size(122, 40)
        Me.btCopy.TabIndex = 2
        Me.btCopy.Text = "Copy to batch tab"
        Me.btCopy.UseVisualStyleBackColor = True
        '
        'btApiCopy
        '
        Me.btApiCopy.Location = New System.Drawing.Point(6, 6)
        Me.btApiCopy.Name = "btApiCopy"
        Me.btApiCopy.Size = New System.Drawing.Size(122, 23)
        Me.btApiCopy.TabIndex = 1
        Me.btApiCopy.Text = "Copy API leads locally"
        Me.btApiCopy.UseVisualStyleBackColor = True
        '
        'dgAPI
        '
        Me.dgAPI.AllowUserToAddRows = False
        Me.dgAPI.AllowUserToDeleteRows = False
        Me.dgAPI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgAPI.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgAPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAPI.Location = New System.Drawing.Point(3, 58)
        Me.dgAPI.Name = "dgAPI"
        Me.dgAPI.ReadOnly = True
        Me.dgAPI.RowHeadersVisible = False
        Me.dgAPI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAPI.Size = New System.Drawing.Size(836, 372)
        Me.dgAPI.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.DefaultExt = "xlsx"
        Me.OpenFileDialog1.FileName = "leadBatchImporter"
        Me.OpenFileDialog1.Filter = "Excel Files|*.xlsx"
        Me.OpenFileDialog1.Title = "Open Lead Importer"
        '
        'txCampaign
        '
        Me.txCampaign.Location = New System.Drawing.Point(89, 280)
        Me.txCampaign.MaxLength = 100
        Me.txCampaign.Name = "txCampaign"
        Me.txCampaign.Size = New System.Drawing.Size(149, 20)
        Me.txCampaign.TabIndex = 31
        Me.txCampaign.Tag = "firstName"
        Me.txCampaign.Visible = False
        '
        'lbCampaign
        '
        Me.lbCampaign.AutoSize = True
        Me.lbCampaign.Location = New System.Drawing.Point(26, 283)
        Me.lbCampaign.Name = "lbCampaign"
        Me.lbCampaign.Size = New System.Drawing.Size(54, 13)
        Me.lbCampaign.TabIndex = 32
        Me.lbCampaign.Text = "Campaign"
        Me.lbCampaign.Visible = False
        '
        'txEmailAddSearch
        '
        Me.txEmailAddSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txEmailAddSearch.Location = New System.Drawing.Point(309, 28)
        Me.txEmailAddSearch.Name = "txEmailAddSearch"
        Me.txEmailAddSearch.Size = New System.Drawing.Size(103, 20)
        Me.txEmailAddSearch.TabIndex = 37
        Me.txEmailAddSearch.Tag = "emailAdd"
        Me.txEmailAddSearch.WaterMarkColor = System.Drawing.Color.Gray
        Me.txEmailAddSearch.WaterMarkText = "Email Add"
        '
        'txIdNumSearch
        '
        Me.txIdNumSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txIdNumSearch.Location = New System.Drawing.Point(217, 28)
        Me.txIdNumSearch.Name = "txIdNumSearch"
        Me.txIdNumSearch.Size = New System.Drawing.Size(86, 20)
        Me.txIdNumSearch.TabIndex = 36
        Me.txIdNumSearch.Tag = "Vat_ID"
        Me.txIdNumSearch.WaterMarkColor = System.Drawing.Color.Gray
        Me.txIdNumSearch.WaterMarkText = "ID Num"
        '
        'txContactNumSearch
        '
        Me.txContactNumSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txContactNumSearch.Location = New System.Drawing.Point(135, 28)
        Me.txContactNumSearch.Name = "txContactNumSearch"
        Me.txContactNumSearch.Size = New System.Drawing.Size(76, 20)
        Me.txContactNumSearch.TabIndex = 35
        Me.txContactNumSearch.Tag = "contactNum"
        Me.txContactNumSearch.WaterMarkColor = System.Drawing.Color.Gray
        Me.txContactNumSearch.WaterMarkText = "Contact Num"
        '
        'txNameSearch
        '
        Me.txNameSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txNameSearch.Location = New System.Drawing.Point(8, 28)
        Me.txNameSearch.Name = "txNameSearch"
        Me.txNameSearch.Size = New System.Drawing.Size(121, 20)
        Me.txNameSearch.TabIndex = 34
        Me.txNameSearch.Tag = "affinityName"
        Me.txNameSearch.WaterMarkColor = System.Drawing.Color.Gray
        Me.txNameSearch.WaterMarkText = "Name"
        '
        'frmLoadLead
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(859, 464)
        Me.Controls.Add(Me.tabControl)
        Me.Name = "frmLoadLead"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Load a New Lead"
        Me.tabControl.ResumeLayout(False)
        Me.tabSource.ResumeLayout(False)
        Me.tabSource.PerformLayout()
        CType(Me.dgSelectSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDetails.ResumeLayout(False)
        Me.tabDetails.PerformLayout()
        Me.tbBatch.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.dgLeadsToUpload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsDgRight.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgAgents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDups.ResumeLayout(False)
        CType(Me.dgDups, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbAPI.ResumeLayout(False)
        Me.tbAPI.PerformLayout()
        CType(Me.dgAPI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabControl As System.Windows.Forms.TabControl
    Friend WithEvents tabSource As System.Windows.Forms.TabPage
    Friend WithEvents tabDetails As System.Windows.Forms.TabPage
    Friend WithEvents txEmailAdd As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbTitle As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txLastName As System.Windows.Forms.TextBox
    Friend WithEvents txFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbAffinity As System.Windows.Forms.RadioButton
    Friend WithEvents rbZwinger As System.Windows.Forms.RadioButton
    Friend WithEvents txContactNum As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbOrder As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btSearch As System.Windows.Forms.Button
    Friend WithEvents dgSelectSource As System.Windows.Forms.DataGridView
    Friend WithEvents txEmailAddSearch As StingRay.WaterMarkTextBox
    Friend WithEvents txIdNumSearch As StingRay.WaterMarkTextBox
    Friend WithEvents txContactNumSearch As StingRay.WaterMarkTextBox
    Friend WithEvents txNameSearch As StingRay.WaterMarkTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbAffinityName As System.Windows.Forms.Label
    Friend WithEvents lbAffinityCode As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txIdNum As System.Windows.Forms.MaskedTextBox
    Friend WithEvents cbAgent As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cbSource As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btLoad As System.Windows.Forms.Button
    Friend WithEvents txComment As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents tbBatch As System.Windows.Forms.TabPage
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tbDups As System.Windows.Forms.TabPage
    Friend WithEvents btConfirmDups As System.Windows.Forms.Button
    Friend WithEvents dgDups As System.Windows.Forms.DataGridView
    Friend WithEvents tbAPI As TabPage
    Friend WithEvents dgAPI As DataGridView
    Friend WithEvents btApiCopy As Button
    Friend WithEvents rbCopyAll As RadioButton
    Friend WithEvents rbCopySelected As RadioButton
    Friend WithEvents btCopy As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents dgLeadsToUpload As DataGridView
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btAllocateSelected As Button
    Friend WithEvents dgAgents As DataGridView
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents cmsDgRight As ContextMenuStrip
    Friend WithEvents cmsEditLead As ToolStripMenuItem
    Friend WithEvents cmsDelete As ToolStripMenuItem
    Friend WithEvents title As DataGridViewTextBoxColumn
    Friend WithEvents firstName As DataGridViewTextBoxColumn
    Friend WithEvents lastName As DataGridViewTextBoxColumn
    Friend WithEvents contactNum As DataGridViewTextBoxColumn
    Friend WithEvents Email As DataGridViewTextBoxColumn
    Friend WithEvents Agent As DataGridViewComboBoxColumn
    Friend WithEvents affinityName As DataGridViewTextBoxColumn
    Friend WithEvents comment As DataGridViewTextBoxColumn
    Friend WithEvents source As DataGridViewComboBoxColumn
    Friend WithEvents affinityCode As DataGridViewTextBoxColumn
    Friend WithEvents affinityID As DataGridViewTextBoxColumn
    Friend WithEvents leadNewID As DataGridViewTextBoxColumn
    Friend WithEvents dupLeadID As DataGridViewTextBoxColumn
    Friend WithEvents btAddToBatch As Button
    Friend WithEvents DeleteAsDupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btAutoAllocate As Button
    Friend WithEvents btLoadToLeadNew As Button
    Friend WithEvents btRefreshInBatch As Button
    Friend WithEvents btExample As Button
    Friend WithEvents btUpload As Button
    Friend WithEvents btValidate As Button
    Friend WithEvents btCheckDups As Button
    Friend WithEvents btConfirmSingleDup As Button
    Friend WithEvents btEmailBusy As Button
    Friend WithEvents txCampaign As TextBox
    Friend WithEvents lbCampaign As Label
End Class
