<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSide
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSide))
        Me.lbUser = New System.Windows.Forms.Label()
        Me.lbAllocated = New System.Windows.Forms.Label()
        Me.btAllocated = New System.Windows.Forms.Button()
        Me.btScheduled = New System.Windows.Forms.Button()
        Me.lbScheduled = New System.Windows.Forms.Label()
        Me.btQaFails = New System.Windows.Forms.Button()
        Me.lbQaFails = New System.Windows.Forms.Label()
        Me.btBusy = New System.Windows.Forms.Button()
        Me.lbBusy = New System.Windows.Forms.Label()
        Me.btSales = New System.Windows.Forms.Button()
        Me.lbSales = New System.Windows.Forms.Label()
        Me.lbQueue = New System.Windows.Forms.Label()
        Me.btRemoveSelected = New System.Windows.Forms.Button()
        Me.llPickFromQueue = New System.Windows.Forms.LinkLabel()
        Me.pbRefresh = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lbType = New System.Windows.Forms.Label()
        Me.btTransfers = New System.Windows.Forms.Button()
        Me.lbTransfers = New System.Windows.Forms.Label()
        Me.lvQueue = New StingRay.ListViewCustomReorder.ListViewEx()
        Me.leadID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.leadName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        CType(Me.pbRefresh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbUser
        '
        Me.lbUser.BackColor = System.Drawing.Color.Transparent
        Me.lbUser.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbUser.Location = New System.Drawing.Point(-1, 9)
        Me.lbUser.Name = "lbUser"
        Me.lbUser.Size = New System.Drawing.Size(154, 23)
        Me.lbUser.TabIndex = 0
        Me.lbUser.Text = "User"
        Me.lbUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbAllocated
        '
        Me.lbAllocated.Location = New System.Drawing.Point(12, 88)
        Me.lbAllocated.Name = "lbAllocated"
        Me.lbAllocated.Size = New System.Drawing.Size(60, 13)
        Me.lbAllocated.TabIndex = 1
        Me.lbAllocated.Text = "Allocated"
        Me.lbAllocated.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btAllocated
        '
        Me.btAllocated.Location = New System.Drawing.Point(12, 104)
        Me.btAllocated.Name = "btAllocated"
        Me.btAllocated.Size = New System.Drawing.Size(60, 23)
        Me.btAllocated.TabIndex = 5
        Me.btAllocated.Text = "#"
        Me.btAllocated.UseVisualStyleBackColor = True
        '
        'btScheduled
        '
        Me.btScheduled.Location = New System.Drawing.Point(12, 150)
        Me.btScheduled.Name = "btScheduled"
        Me.btScheduled.Size = New System.Drawing.Size(60, 23)
        Me.btScheduled.TabIndex = 9
        Me.btScheduled.Text = "#"
        Me.btScheduled.UseVisualStyleBackColor = True
        '
        'lbScheduled
        '
        Me.lbScheduled.Location = New System.Drawing.Point(12, 134)
        Me.lbScheduled.Name = "lbScheduled"
        Me.lbScheduled.Size = New System.Drawing.Size(60, 13)
        Me.lbScheduled.TabIndex = 8
        Me.lbScheduled.Text = "Scheduled"
        Me.lbScheduled.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btQaFails
        '
        Me.btQaFails.Location = New System.Drawing.Point(78, 150)
        Me.btQaFails.Name = "btQaFails"
        Me.btQaFails.Size = New System.Drawing.Size(60, 23)
        Me.btQaFails.TabIndex = 17
        Me.btQaFails.Text = "#"
        Me.btQaFails.UseVisualStyleBackColor = True
        '
        'lbQaFails
        '
        Me.lbQaFails.Location = New System.Drawing.Point(78, 134)
        Me.lbQaFails.Name = "lbQaFails"
        Me.lbQaFails.Size = New System.Drawing.Size(60, 13)
        Me.lbQaFails.TabIndex = 16
        Me.lbQaFails.Text = "QA Fixes"
        Me.lbQaFails.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btBusy
        '
        Me.btBusy.Location = New System.Drawing.Point(78, 104)
        Me.btBusy.Name = "btBusy"
        Me.btBusy.Size = New System.Drawing.Size(60, 23)
        Me.btBusy.TabIndex = 15
        Me.btBusy.Text = "#"
        Me.btBusy.UseVisualStyleBackColor = True
        '
        'lbBusy
        '
        Me.lbBusy.Location = New System.Drawing.Point(78, 88)
        Me.lbBusy.Name = "lbBusy"
        Me.lbBusy.Size = New System.Drawing.Size(60, 13)
        Me.lbBusy.TabIndex = 14
        Me.lbBusy.Text = "Busy"
        Me.lbBusy.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btSales
        '
        Me.btSales.Location = New System.Drawing.Point(78, 192)
        Me.btSales.Name = "btSales"
        Me.btSales.Size = New System.Drawing.Size(60, 23)
        Me.btSales.TabIndex = 19
        Me.btSales.Text = "#"
        Me.btSales.UseVisualStyleBackColor = True
        '
        'lbSales
        '
        Me.lbSales.Location = New System.Drawing.Point(78, 176)
        Me.lbSales.Name = "lbSales"
        Me.lbSales.Size = New System.Drawing.Size(60, 13)
        Me.lbSales.TabIndex = 18
        Me.lbSales.Text = "Sales"
        Me.lbSales.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lbQueue
        '
        Me.lbQueue.AutoSize = True
        Me.lbQueue.Location = New System.Drawing.Point(12, 226)
        Me.lbQueue.Name = "lbQueue"
        Me.lbQueue.Size = New System.Drawing.Size(39, 13)
        Me.lbQueue.TabIndex = 22
        Me.lbQueue.Text = "Queue"
        Me.lbQueue.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btRemoveSelected
        '
        Me.btRemoveSelected.Location = New System.Drawing.Point(12, 453)
        Me.btRemoveSelected.Name = "btRemoveSelected"
        Me.btRemoveSelected.Size = New System.Drawing.Size(126, 22)
        Me.btRemoveSelected.TabIndex = 24
        Me.btRemoveSelected.Text = "Remove Selected"
        Me.btRemoveSelected.UseVisualStyleBackColor = True
        '
        'llPickFromQueue
        '
        Me.llPickFromQueue.AutoSize = True
        Me.llPickFromQueue.Location = New System.Drawing.Point(109, 226)
        Me.llPickFromQueue.Name = "llPickFromQueue"
        Me.llPickFromQueue.Size = New System.Drawing.Size(29, 13)
        Me.llPickFromQueue.TabIndex = 26
        Me.llPickFromQueue.TabStop = True
        Me.llPickFromQueue.Text = "Start"
        '
        'pbRefresh
        '
        Me.pbRefresh.BackColor = System.Drawing.Color.Transparent
        Me.pbRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbRefresh.Image = CType(resources.GetObject("pbRefresh.Image"), System.Drawing.Image)
        Me.pbRefresh.Location = New System.Drawing.Point(58, 58)
        Me.pbRefresh.Name = "pbRefresh"
        Me.pbRefresh.Size = New System.Drawing.Size(34, 27)
        Me.pbRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbRefresh.TabIndex = 27
        Me.pbRefresh.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.StingRay.My.Resources.Resources.Stingray
        Me.PictureBox1.Location = New System.Drawing.Point(2, -12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(150, 127)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 28
        Me.PictureBox1.TabStop = False
        '
        'lbType
        '
        Me.lbType.BackColor = System.Drawing.Color.Transparent
        Me.lbType.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbType.Location = New System.Drawing.Point(15, 32)
        Me.lbType.Name = "lbType"
        Me.lbType.Size = New System.Drawing.Size(123, 23)
        Me.lbType.TabIndex = 29
        Me.lbType.Text = "Type"
        Me.lbType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btTransfers
        '
        Me.btTransfers.Location = New System.Drawing.Point(12, 192)
        Me.btTransfers.Name = "btTransfers"
        Me.btTransfers.Size = New System.Drawing.Size(60, 23)
        Me.btTransfers.TabIndex = 31
        Me.btTransfers.Text = "#"
        Me.btTransfers.UseVisualStyleBackColor = True
        '
        'lbTransfers
        '
        Me.lbTransfers.Location = New System.Drawing.Point(12, 176)
        Me.lbTransfers.Name = "lbTransfers"
        Me.lbTransfers.Size = New System.Drawing.Size(60, 13)
        Me.lbTransfers.TabIndex = 30
        Me.lbTransfers.Text = "Transfers"
        Me.lbTransfers.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lvQueue
        '
        Me.lvQueue.CheckBoxes = True
        Me.lvQueue.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.leadID, Me.leadName})
        Me.lvQueue.FullRowSelect = True
        Me.lvQueue.Location = New System.Drawing.Point(12, 242)
        Me.lvQueue.MultiSelect = False
        Me.lvQueue.Name = "lvQueue"
        Me.lvQueue.Size = New System.Drawing.Size(126, 205)
        Me.lvQueue.TabIndex = 23
        Me.lvQueue.UseCompatibleStateImageBehavior = False
        Me.lvQueue.View = System.Windows.Forms.View.Details
        '
        'leadID
        '
        Me.leadID.Text = "ID"
        '
        'leadName
        '
        Me.leadName.Text = "Name"
        '
        'frmSide
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(153, 479)
        Me.ControlBox = False
        Me.Controls.Add(Me.btTransfers)
        Me.Controls.Add(Me.lbTransfers)
        Me.Controls.Add(Me.lbType)
        Me.Controls.Add(Me.pbRefresh)
        Me.Controls.Add(Me.llPickFromQueue)
        Me.Controls.Add(Me.btRemoveSelected)
        Me.Controls.Add(Me.lvQueue)
        Me.Controls.Add(Me.lbQueue)
        Me.Controls.Add(Me.btSales)
        Me.Controls.Add(Me.lbSales)
        Me.Controls.Add(Me.btQaFails)
        Me.Controls.Add(Me.lbQaFails)
        Me.Controls.Add(Me.btBusy)
        Me.Controls.Add(Me.lbBusy)
        Me.Controls.Add(Me.btScheduled)
        Me.Controls.Add(Me.lbScheduled)
        Me.Controls.Add(Me.btAllocated)
        Me.Controls.Add(Me.lbAllocated)
        Me.Controls.Add(Me.lbUser)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSide"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "frmSide"
        Me.TopMost = True
        CType(Me.pbRefresh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbUser As System.Windows.Forms.Label
    Friend WithEvents lbAllocated As System.Windows.Forms.Label
    Friend WithEvents btAllocated As System.Windows.Forms.Button
    Friend WithEvents btScheduled As System.Windows.Forms.Button
    Friend WithEvents lbScheduled As System.Windows.Forms.Label
    Friend WithEvents btQaFails As System.Windows.Forms.Button
    Friend WithEvents lbQaFails As System.Windows.Forms.Label
    Friend WithEvents btBusy As System.Windows.Forms.Button
    Friend WithEvents lbBusy As System.Windows.Forms.Label
    Friend WithEvents btSales As System.Windows.Forms.Button
    Friend WithEvents lbSales As System.Windows.Forms.Label
    Friend WithEvents lbQueue As System.Windows.Forms.Label
    Friend WithEvents lvQueue As StingRay.ListViewCustomReorder.ListViewEx
    Friend WithEvents leadID As System.Windows.Forms.ColumnHeader
    Friend WithEvents leadName As System.Windows.Forms.ColumnHeader
    Friend WithEvents btRemoveSelected As System.Windows.Forms.Button
    Friend WithEvents llPickFromQueue As System.Windows.Forms.LinkLabel
    Friend WithEvents pbRefresh As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lbType As System.Windows.Forms.Label
    Friend WithEvents btTransfers As System.Windows.Forms.Button
    Friend WithEvents lbTransfers As System.Windows.Forms.Label
End Class
