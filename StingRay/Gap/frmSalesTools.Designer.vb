<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesTools
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbAgentSettings = New System.Windows.Forms.TabPage()
        Me.tbComparisons = New System.Windows.Forms.TabPage()
        Me.tbClaims = New System.Windows.Forms.TabPage()
        Me.cbSalesCount = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.llBlankApp = New System.Windows.Forms.LinkLabel()
        Me.llScript = New System.Windows.Forms.LinkLabel()
        Me.llBrochure = New System.Windows.Forms.LinkLabel()
        Me.llDisclosures = New System.Windows.Forms.LinkLabel()
        Me.llFAQs = New System.Windows.Forms.LinkLabel()
        Me.llPmbExplination = New System.Windows.Forms.LinkLabel()
        Me.TabControl1.SuspendLayout()
        Me.tbAgentSettings.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbAgentSettings)
        Me.TabControl1.Controls.Add(Me.tbComparisons)
        Me.TabControl1.Controls.Add(Me.tbClaims)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(902, 533)
        Me.TabControl1.TabIndex = 0
        '
        'tbAgentSettings
        '
        Me.tbAgentSettings.Controls.Add(Me.GroupBox1)
        Me.tbAgentSettings.Controls.Add(Me.cbSalesCount)
        Me.tbAgentSettings.Location = New System.Drawing.Point(4, 22)
        Me.tbAgentSettings.Name = "tbAgentSettings"
        Me.tbAgentSettings.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAgentSettings.Size = New System.Drawing.Size(894, 507)
        Me.tbAgentSettings.TabIndex = 0
        Me.tbAgentSettings.Text = "Agent Settings"
        Me.tbAgentSettings.UseVisualStyleBackColor = True
        '
        'tbComparisons
        '
        Me.tbComparisons.Location = New System.Drawing.Point(4, 22)
        Me.tbComparisons.Name = "tbComparisons"
        Me.tbComparisons.Padding = New System.Windows.Forms.Padding(3)
        Me.tbComparisons.Size = New System.Drawing.Size(894, 507)
        Me.tbComparisons.TabIndex = 1
        Me.tbComparisons.Text = "Comparisons"
        Me.tbComparisons.UseVisualStyleBackColor = True
        '
        'tbClaims
        '
        Me.tbClaims.Location = New System.Drawing.Point(4, 22)
        Me.tbClaims.Name = "tbClaims"
        Me.tbClaims.Padding = New System.Windows.Forms.Padding(3)
        Me.tbClaims.Size = New System.Drawing.Size(894, 507)
        Me.tbClaims.TabIndex = 2
        Me.tbClaims.Text = "Claims"
        Me.tbClaims.UseVisualStyleBackColor = True
        '
        'cbSalesCount
        '
        Me.cbSalesCount.AutoSize = True
        Me.cbSalesCount.Checked = True
        Me.cbSalesCount.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSalesCount.Location = New System.Drawing.Point(20, 23)
        Me.cbSalesCount.Name = "cbSalesCount"
        Me.cbSalesCount.Size = New System.Drawing.Size(109, 17)
        Me.cbSalesCount.TabIndex = 0
        Me.cbSalesCount.Text = "View Sales Count"
        Me.cbSalesCount.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.llPmbExplination)
        Me.GroupBox1.Controls.Add(Me.llFAQs)
        Me.GroupBox1.Controls.Add(Me.llDisclosures)
        Me.GroupBox1.Controls.Add(Me.llBrochure)
        Me.GroupBox1.Controls.Add(Me.llScript)
        Me.GroupBox1.Controls.Add(Me.llBlankApp)
        Me.GroupBox1.Location = New System.Drawing.Point(686, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 493)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Material"
        '
        'llBlankApp
        '
        Me.llBlankApp.AutoSize = True
        Me.llBlankApp.Location = New System.Drawing.Point(6, 35)
        Me.llBlankApp.Name = "llBlankApp"
        Me.llBlankApp.Size = New System.Drawing.Size(82, 13)
        Me.llBlankApp.TabIndex = 2
        Me.llBlankApp.TabStop = True
        Me.llBlankApp.Text = "Blank App Form"
        '
        'llScript
        '
        Me.llScript.AutoSize = True
        Me.llScript.Location = New System.Drawing.Point(6, 61)
        Me.llScript.Name = "llScript"
        Me.llScript.Size = New System.Drawing.Size(34, 13)
        Me.llScript.TabIndex = 3
        Me.llScript.TabStop = True
        Me.llScript.Text = "Script"
        '
        'llBrochure
        '
        Me.llBrochure.AutoSize = True
        Me.llBrochure.Location = New System.Drawing.Point(6, 91)
        Me.llBrochure.Name = "llBrochure"
        Me.llBrochure.Size = New System.Drawing.Size(50, 13)
        Me.llBrochure.TabIndex = 4
        Me.llBrochure.TabStop = True
        Me.llBrochure.Text = "Brochure"
        '
        'llDisclosures
        '
        Me.llDisclosures.AutoSize = True
        Me.llDisclosures.Location = New System.Drawing.Point(6, 124)
        Me.llDisclosures.Name = "llDisclosures"
        Me.llDisclosures.Size = New System.Drawing.Size(61, 13)
        Me.llDisclosures.TabIndex = 5
        Me.llDisclosures.TabStop = True
        Me.llDisclosures.Text = "Disclosures"
        '
        'llFAQs
        '
        Me.llFAQs.AutoSize = True
        Me.llFAQs.Location = New System.Drawing.Point(6, 155)
        Me.llFAQs.Name = "llFAQs"
        Me.llFAQs.Size = New System.Drawing.Size(35, 13)
        Me.llFAQs.TabIndex = 6
        Me.llFAQs.TabStop = True
        Me.llFAQs.Text = "FAQ's"
        '
        'llPmbExplination
        '
        Me.llPmbExplination.AutoSize = True
        Me.llPmbExplination.Location = New System.Drawing.Point(6, 190)
        Me.llPmbExplination.Name = "llPmbExplination"
        Me.llPmbExplination.Size = New System.Drawing.Size(90, 13)
        Me.llPmbExplination.TabIndex = 7
        Me.llPmbExplination.TabStop = True
        Me.llPmbExplination.Text = "PMB Explaination"
        '
        'frmSalesTools
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 533)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmSalesTools"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Tools"
        Me.TabControl1.ResumeLayout(False)
        Me.tbAgentSettings.ResumeLayout(False)
        Me.tbAgentSettings.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tbAgentSettings As TabPage
    Friend WithEvents cbSalesCount As CheckBox
    Friend WithEvents tbComparisons As TabPage
    Friend WithEvents tbClaims As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents llFAQs As LinkLabel
    Friend WithEvents llDisclosures As LinkLabel
    Friend WithEvents llBrochure As LinkLabel
    Friend WithEvents llScript As LinkLabel
    Friend WithEvents llBlankApp As LinkLabel
    Friend WithEvents llPmbExplination As LinkLabel
End Class
