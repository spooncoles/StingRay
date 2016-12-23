<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuGap = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFindLead = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuLoadLead = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuLoadReferral = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuIncentives = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMenuAL = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFindLeadAl = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuAdmin = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadLeadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuChangeLeads = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuLoadAfinity = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuTempAdminCode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportSalesFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuNewUser = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindReferralDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuQA = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuQaPickUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuQaAdmin = New System.Windows.Forms.ToolStripMenuItem()
        Me.QANonSaleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QAStatsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotificationIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.mainMenuGap, Me.mainMenuAL, Me.menuAdmin, Me.menuQA})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(944, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.UpdateToolStripMenuItem.Text = "Update"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'mainMenuGap
        '
        Me.mainMenuGap.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuFindLead, Me.menuLoadLead, Me.menuLoadReferral, Me.menuIncentives, Me.SalesToolsToolStripMenuItem})
        Me.mainMenuGap.Name = "mainMenuGap"
        Me.mainMenuGap.Size = New System.Drawing.Size(40, 20)
        Me.mainMenuGap.Text = "Gap"
        '
        'menuFindLead
        '
        Me.menuFindLead.Name = "menuFindLead"
        Me.menuFindLead.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.menuFindLead.Size = New System.Drawing.Size(171, 22)
        Me.menuFindLead.Text = "Find Lead"
        '
        'menuLoadLead
        '
        Me.menuLoadLead.Name = "menuLoadLead"
        Me.menuLoadLead.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.menuLoadLead.Size = New System.Drawing.Size(171, 22)
        Me.menuLoadLead.Text = "Load Lead"
        '
        'menuLoadReferral
        '
        Me.menuLoadReferral.Name = "menuLoadReferral"
        Me.menuLoadReferral.Size = New System.Drawing.Size(171, 22)
        Me.menuLoadReferral.Text = "Load Referral"
        '
        'menuIncentives
        '
        Me.menuIncentives.Name = "menuIncentives"
        Me.menuIncentives.Size = New System.Drawing.Size(171, 22)
        Me.menuIncentives.Text = "Incentives"
        '
        'SalesToolsToolStripMenuItem
        '
        Me.SalesToolsToolStripMenuItem.Name = "SalesToolsToolStripMenuItem"
        Me.SalesToolsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SalesToolsToolStripMenuItem.Text = "Sales Tools"
        '
        'mainMenuAL
        '
        Me.mainMenuAL.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuFindLeadAl})
        Me.mainMenuAL.Name = "mainMenuAL"
        Me.mainMenuAL.Size = New System.Drawing.Size(33, 20)
        Me.mainMenuAL.Text = "AL"
        '
        'menuFindLeadAl
        '
        Me.menuFindLeadAl.Name = "menuFindLeadAl"
        Me.menuFindLeadAl.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.menuFindLeadAl.Size = New System.Drawing.Size(165, 22)
        Me.menuFindLeadAl.Text = "Find Lead"
        '
        'menuAdmin
        '
        Me.menuAdmin.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoadLeadToolStripMenuItem, Me.menuChangeLeads, Me.menuLoadAfinity, Me.menuTempAdminCode, Me.ExportSalesFileToolStripMenuItem, Me.menuNewUser, Me.FindReferralDetailsToolStripMenuItem})
        Me.menuAdmin.Name = "menuAdmin"
        Me.menuAdmin.Size = New System.Drawing.Size(55, 20)
        Me.menuAdmin.Text = "Admin"
        '
        'LoadLeadToolStripMenuItem
        '
        Me.LoadLeadToolStripMenuItem.Name = "LoadLeadToolStripMenuItem"
        Me.LoadLeadToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.LoadLeadToolStripMenuItem.Text = "Load Lead(s)"
        '
        'menuChangeLeads
        '
        Me.menuChangeLeads.Name = "menuChangeLeads"
        Me.menuChangeLeads.Size = New System.Drawing.Size(178, 22)
        Me.menuChangeLeads.Text = "Change Leads"
        '
        'menuLoadAfinity
        '
        Me.menuLoadAfinity.Name = "menuLoadAfinity"
        Me.menuLoadAfinity.Size = New System.Drawing.Size(178, 22)
        Me.menuLoadAfinity.Text = "Load Afinity"
        '
        'menuTempAdminCode
        '
        Me.menuTempAdminCode.Name = "menuTempAdminCode"
        Me.menuTempAdminCode.Size = New System.Drawing.Size(178, 22)
        Me.menuTempAdminCode.Text = "Update Temp Code"
        '
        'ExportSalesFileToolStripMenuItem
        '
        Me.ExportSalesFileToolStripMenuItem.Name = "ExportSalesFileToolStripMenuItem"
        Me.ExportSalesFileToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ExportSalesFileToolStripMenuItem.Text = "Export Sales File"
        '
        'menuNewUser
        '
        Me.menuNewUser.Name = "menuNewUser"
        Me.menuNewUser.Size = New System.Drawing.Size(178, 22)
        Me.menuNewUser.Text = "Load New User"
        '
        'FindReferralDetailsToolStripMenuItem
        '
        Me.FindReferralDetailsToolStripMenuItem.Name = "FindReferralDetailsToolStripMenuItem"
        Me.FindReferralDetailsToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.FindReferralDetailsToolStripMenuItem.Text = "Find Referral Details"
        '
        'menuQA
        '
        Me.menuQA.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuQaPickUp, Me.menuQaAdmin, Me.QANonSaleToolStripMenuItem, Me.QAStatsToolStripMenuItem})
        Me.menuQA.Name = "menuQA"
        Me.menuQA.Size = New System.Drawing.Size(36, 20)
        Me.menuQA.Text = "QA"
        '
        'menuQaPickUp
        '
        Me.menuQaPickUp.Name = "menuQaPickUp"
        Me.menuQaPickUp.Size = New System.Drawing.Size(143, 22)
        Me.menuQaPickUp.Text = "QA Pick-Up"
        '
        'menuQaAdmin
        '
        Me.menuQaAdmin.Name = "menuQaAdmin"
        Me.menuQaAdmin.Size = New System.Drawing.Size(143, 22)
        Me.menuQaAdmin.Text = "QA Admin"
        '
        'QANonSaleToolStripMenuItem
        '
        Me.QANonSaleToolStripMenuItem.Name = "QANonSaleToolStripMenuItem"
        Me.QANonSaleToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.QANonSaleToolStripMenuItem.Text = "QA Non-Sale"
        '
        'QAStatsToolStripMenuItem
        '
        Me.QAStatsToolStripMenuItem.Name = "QAStatsToolStripMenuItem"
        Me.QAStatsToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.QAStatsToolStripMenuItem.Text = "QA Stats"
        '
        'NotificationIcon
        '
        Me.NotificationIcon.Icon = CType(resources.GetObject("NotificationIcon.Icon"), System.Drawing.Icon)
        Me.NotificationIcon.Text = "StingRay"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.StingRay.My.Resources.Resources.Stingray_Back
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(944, 471)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "StingRay"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mainMenuGap As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuFindLead As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuLoadLead As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotificationIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents menuAdmin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuChangeLeads As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportSalesFileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuQA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuQaPickUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuQaAdmin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuNewUser As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuLoadAfinity As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuLoadReferral As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuTempAdminCode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadLeadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuIncentives As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QANonSaleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QAStatsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FindReferralDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalesToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents mainMenuAL As ToolStripMenuItem
    Friend WithEvents menuFindLeadAl As ToolStripMenuItem
End Class
