<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewUser
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
        Me.txIdNum = New System.Windows.Forms.MaskedTextBox()
        Me.txContactNum = New System.Windows.Forms.MaskedTextBox()
        Me.txEmailAdd = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCampaign = New System.Windows.Forms.ComboBox()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtDOB = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbGender = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtStarted = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txQueueMetrics = New System.Windows.Forms.MaskedTextBox()
        Me.btLoadLead = New System.Windows.Forms.Button()
        Me.formToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'txIdNum
        '
        Me.txIdNum.Location = New System.Drawing.Point(109, 90)
        Me.txIdNum.Mask = "000000-0000-000"
        Me.txIdNum.Name = "txIdNum"
        Me.txIdNum.Size = New System.Drawing.Size(149, 20)
        Me.txIdNum.TabIndex = 4
        Me.txIdNum.Tag = "ID  Number"
        '
        'txContactNum
        '
        Me.txContactNum.Location = New System.Drawing.Point(109, 64)
        Me.txContactNum.Mask = "(999) 000-0000"
        Me.txContactNum.Name = "txContactNum"
        Me.txContactNum.Size = New System.Drawing.Size(149, 20)
        Me.txContactNum.TabIndex = 3
        Me.txContactNum.Tag = "Contact Number"
        Me.formToolTip.SetToolTip(Me.txContactNum, "Cell number or work number")
        '
        'txEmailAdd
        '
        Me.txEmailAdd.Location = New System.Drawing.Point(109, 38)
        Me.txEmailAdd.MaxLength = 100
        Me.txEmailAdd.Name = "txEmailAdd"
        Me.txEmailAdd.Size = New System.Drawing.Size(149, 20)
        Me.txEmailAdd.TabIndex = 2
        Me.txEmailAdd.Tag = "Email Address"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(49, 41)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Email Add"
        '
        'txName
        '
        Me.txName.Location = New System.Drawing.Point(109, 12)
        Me.txName.MaxLength = 100
        Me.txName.Name = "txName"
        Me.txName.Size = New System.Drawing.Size(149, 20)
        Me.txName.TabIndex = 1
        Me.txName.Tag = "Name"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(60, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "ID Num"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Contact Num"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(68, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Name"
        '
        'cbCampaign
        '
        Me.cbCampaign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCampaign.FormattingEnabled = True
        Me.cbCampaign.Items.AddRange(New Object() {"Gap"})
        Me.cbCampaign.Location = New System.Drawing.Point(109, 117)
        Me.cbCampaign.Name = "cbCampaign"
        Me.cbCampaign.Size = New System.Drawing.Size(149, 21)
        Me.cbCampaign.TabIndex = 5
        Me.cbCampaign.Tag = "Campaign"
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.FormattingEnabled = True
        Me.cbType.Items.AddRange(New Object() {"Agent", "QA Agent", "Lead Admin"})
        Me.cbType.Location = New System.Drawing.Point(109, 144)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(149, 21)
        Me.cbType.TabIndex = 6
        Me.cbType.Tag = "Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Campaign"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(72, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Type"
        '
        'dtDOB
        '
        Me.dtDOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDOB.Location = New System.Drawing.Point(109, 171)
        Me.dtDOB.Name = "dtDOB"
        Me.dtDOB.Size = New System.Drawing.Size(149, 20)
        Me.dtDOB.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(73, 177)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 84
        Me.Label7.Text = "DOB"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(61, 200)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 86
        Me.Label8.Text = "Gender"
        '
        'cbGender
        '
        Me.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbGender.FormattingEnabled = True
        Me.cbGender.Items.AddRange(New Object() {"F", "M"})
        Me.cbGender.Location = New System.Drawing.Point(109, 197)
        Me.cbGender.Name = "cbGender"
        Me.cbGender.Size = New System.Drawing.Size(149, 21)
        Me.cbGender.TabIndex = 8
        Me.cbGender.Tag = "Gender"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(36, 230)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 88
        Me.Label9.Text = "Date Started"
        '
        'dtStarted
        '
        Me.dtStarted.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStarted.Location = New System.Drawing.Point(109, 224)
        Me.dtStarted.Name = "dtStarted"
        Me.dtStarted.Size = New System.Drawing.Size(149, 20)
        Me.dtStarted.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(2, 253)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 13)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "QueueMetrics Code"
        '
        'txQueueMetrics
        '
        Me.txQueueMetrics.Location = New System.Drawing.Point(109, 250)
        Me.txQueueMetrics.Mask = "0000"
        Me.txQueueMetrics.Name = "txQueueMetrics"
        Me.txQueueMetrics.Size = New System.Drawing.Size(149, 20)
        Me.txQueueMetrics.TabIndex = 10
        Me.txQueueMetrics.Tag = "QueueMetrics Code"
        '
        'btLoadLead
        '
        Me.btLoadLead.Location = New System.Drawing.Point(5, 294)
        Me.btLoadLead.Name = "btLoadLead"
        Me.btLoadLead.Size = New System.Drawing.Size(253, 23)
        Me.btLoadLead.TabIndex = 11
        Me.btLoadLead.Text = "Load New User"
        Me.btLoadLead.UseVisualStyleBackColor = True
        '
        'frmNewUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(267, 326)
        Me.Controls.Add(Me.btLoadLead)
        Me.Controls.Add(Me.txQueueMetrics)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtStarted)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbGender)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtDOB)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbType)
        Me.Controls.Add(Me.cbCampaign)
        Me.Controls.Add(Me.txIdNum)
        Me.Controls.Add(Me.txContactNum)
        Me.Controls.Add(Me.txEmailAdd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmNewUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Load New User"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txIdNum As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txContactNum As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txEmailAdd As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbCampaign As System.Windows.Forms.ComboBox
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents formToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents dtDOB As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbGender As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtStarted As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txQueueMetrics As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btLoadLead As System.Windows.Forms.Button
End Class
