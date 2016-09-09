<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoadAffinity
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
        Me.rbAffinity = New System.Windows.Forms.RadioButton()
        Me.rbReferral = New System.Windows.Forms.RadioButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txAdminCode = New System.Windows.Forms.TextBox()
        Me.txAffinityName = New System.Windows.Forms.TextBox()
        Me.txGroup = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbCampaign = New System.Windows.Forms.ComboBox()
        Me.txContactNum = New System.Windows.Forms.MaskedTextBox()
        Me.txEmailAdd = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbVat = New System.Windows.Forms.RadioButton()
        Me.rbID = New System.Windows.Forms.RadioButton()
        Me.txIdNum = New System.Windows.Forms.MaskedTextBox()
        Me.btConfirm = New System.Windows.Forms.Button()
        Me.cbType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txLeadID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbAdminCode = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rbAffinity
        '
        Me.rbAffinity.AutoSize = True
        Me.rbAffinity.Checked = True
        Me.rbAffinity.Location = New System.Drawing.Point(173, 3)
        Me.rbAffinity.Name = "rbAffinity"
        Me.rbAffinity.Size = New System.Drawing.Size(56, 17)
        Me.rbAffinity.TabIndex = 3
        Me.rbAffinity.TabStop = True
        Me.rbAffinity.Text = "Affinity"
        Me.rbAffinity.UseVisualStyleBackColor = True
        '
        'rbReferral
        '
        Me.rbReferral.AutoSize = True
        Me.rbReferral.Location = New System.Drawing.Point(110, 3)
        Me.rbReferral.Name = "rbReferral"
        Me.rbReferral.Size = New System.Drawing.Size(62, 17)
        Me.rbReferral.TabIndex = 2
        Me.rbReferral.Text = "Referral"
        Me.rbReferral.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Affinity Name"
        '
        'txAdminCode
        '
        Me.txAdminCode.Location = New System.Drawing.Point(95, 26)
        Me.txAdminCode.Name = "txAdminCode"
        Me.txAdminCode.Size = New System.Drawing.Size(149, 20)
        Me.txAdminCode.TabIndex = 1
        Me.txAdminCode.Tag = "adminCode"
        '
        'txAffinityName
        '
        Me.txAffinityName.Location = New System.Drawing.Point(95, 52)
        Me.txAffinityName.Name = "txAffinityName"
        Me.txAffinityName.Size = New System.Drawing.Size(149, 20)
        Me.txAffinityName.TabIndex = 2
        Me.txAffinityName.Tag = "affinityName"
        '
        'txGroup
        '
        Me.txGroup.Location = New System.Drawing.Point(95, 237)
        Me.txGroup.Name = "txGroup"
        Me.txGroup.Size = New System.Drawing.Size(149, 20)
        Me.txGroup.TabIndex = 8
        Me.txGroup.Tag = "groupName"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 240)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Group Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Campaign"
        '
        'cbCampaign
        '
        Me.cbCampaign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCampaign.FormattingEnabled = True
        Me.cbCampaign.Items.AddRange(New Object() {"Gap"})
        Me.cbCampaign.Location = New System.Drawing.Point(95, 78)
        Me.cbCampaign.Name = "cbCampaign"
        Me.cbCampaign.Size = New System.Drawing.Size(149, 21)
        Me.cbCampaign.TabIndex = 3
        Me.cbCampaign.Tag = "campaign"
        '
        'txContactNum
        '
        Me.txContactNum.Location = New System.Drawing.Point(95, 105)
        Me.txContactNum.Mask = "(999) 000-0000"
        Me.txContactNum.Name = "txContactNum"
        Me.txContactNum.Size = New System.Drawing.Size(149, 20)
        Me.txContactNum.TabIndex = 4
        Me.txContactNum.Tag = "contactNum"
        '
        'txEmailAdd
        '
        Me.txEmailAdd.Location = New System.Drawing.Point(95, 184)
        Me.txEmailAdd.MaxLength = 100
        Me.txEmailAdd.Name = "txEmailAdd"
        Me.txEmailAdd.Size = New System.Drawing.Size(149, 20)
        Me.txEmailAdd.TabIndex = 6
        Me.txEmailAdd.Tag = "emailAdd"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(35, 187)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Email Add"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Contact Num"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbVat)
        Me.GroupBox1.Controls.Add(Me.rbID)
        Me.GroupBox1.Controls.Add(Me.txIdNum)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 126)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(231, 48)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        '
        'rbVat
        '
        Me.rbVat.AutoSize = True
        Me.rbVat.Location = New System.Drawing.Point(6, 27)
        Me.rbVat.Name = "rbVat"
        Me.rbVat.Size = New System.Drawing.Size(66, 17)
        Me.rbVat.TabIndex = 43
        Me.rbVat.Text = "Vat Num"
        Me.rbVat.UseVisualStyleBackColor = True
        '
        'rbID
        '
        Me.rbID.AutoSize = True
        Me.rbID.Checked = True
        Me.rbID.Location = New System.Drawing.Point(6, 11)
        Me.rbID.Name = "rbID"
        Me.rbID.Size = New System.Drawing.Size(61, 17)
        Me.rbID.TabIndex = 42
        Me.rbID.TabStop = True
        Me.rbID.Text = "ID Num"
        Me.rbID.UseVisualStyleBackColor = True
        '
        'txIdNum
        '
        Me.txIdNum.Location = New System.Drawing.Point(79, 18)
        Me.txIdNum.Mask = "000000-0000-000"
        Me.txIdNum.Name = "txIdNum"
        Me.txIdNum.Size = New System.Drawing.Size(149, 20)
        Me.txIdNum.TabIndex = 5
        Me.txIdNum.Tag = "Vat_ID"
        '
        'btConfirm
        '
        Me.btConfirm.Location = New System.Drawing.Point(6, 290)
        Me.btConfirm.Name = "btConfirm"
        Me.btConfirm.Size = New System.Drawing.Size(239, 35)
        Me.btConfirm.TabIndex = 10
        Me.btConfirm.Text = "Confirm"
        Me.btConfirm.UseVisualStyleBackColor = True
        '
        'cbType
        '
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.FormattingEnabled = True
        Me.cbType.ItemHeight = 13
        Me.cbType.Items.AddRange(New Object() {"Inbound", "Outbound", "Liberty", "Zwing"})
        Me.cbType.Location = New System.Drawing.Point(95, 210)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(149, 21)
        Me.cbType.TabIndex = 44
        Me.cbType.Tag = "type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 213)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Type"
        '
        'txLeadID
        '
        Me.txLeadID.Location = New System.Drawing.Point(95, 263)
        Me.txLeadID.Name = "txLeadID"
        Me.txLeadID.Size = New System.Drawing.Size(149, 20)
        Me.txLeadID.TabIndex = 9
        Me.txLeadID.Tag = "leadIdLink"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(44, 266)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Lead ID"
        '
        'cbAdminCode
        '
        Me.cbAdminCode.AutoSize = True
        Me.cbAdminCode.Checked = True
        Me.cbAdminCode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAdminCode.Location = New System.Drawing.Point(6, 28)
        Me.cbAdminCode.Name = "cbAdminCode"
        Me.cbAdminCode.Size = New System.Drawing.Size(83, 17)
        Me.cbAdminCode.TabIndex = 47
        Me.cbAdminCode.Text = "Admin Code"
        Me.cbAdminCode.UseVisualStyleBackColor = True
        '
        'frmLoadAffinity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(251, 332)
        Me.Controls.Add(Me.cbAdminCode)
        Me.Controls.Add(Me.txLeadID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btConfirm)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txContactNum)
        Me.Controls.Add(Me.txEmailAdd)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbCampaign)
        Me.Controls.Add(Me.txGroup)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txAffinityName)
        Me.Controls.Add(Me.txAdminCode)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.rbAffinity)
        Me.Controls.Add(Me.rbReferral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmLoadAffinity"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Load Affinity"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbAffinity As System.Windows.Forms.RadioButton
    Friend WithEvents rbReferral As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txAdminCode As System.Windows.Forms.TextBox
    Friend WithEvents txAffinityName As System.Windows.Forms.TextBox
    Friend WithEvents txGroup As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbCampaign As System.Windows.Forms.ComboBox
    Friend WithEvents txContactNum As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txEmailAdd As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbVat As System.Windows.Forms.RadioButton
    Friend WithEvents rbID As System.Windows.Forms.RadioButton
    Friend WithEvents txIdNum As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btConfirm As System.Windows.Forms.Button
    Friend WithEvents cbType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txLeadID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbAdminCode As System.Windows.Forms.CheckBox
End Class
