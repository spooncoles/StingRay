<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class frmLogin
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
    Friend WithEvents btOK As System.Windows.Forms.Button
    Friend WithEvents btCancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.btOK = New System.Windows.Forms.Button()
        Me.btCancel = New System.Windows.Forms.Button()
        Me.btExpand = New System.Windows.Forms.Button()
        Me.dgUsers = New System.Windows.Forms.DataGridView()
        Me.txPass = New StingRay.WaterMarkTextBox()
        Me.txUser = New StingRay.WaterMarkTextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.dgUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btOK
        '
        Me.btOK.Location = New System.Drawing.Point(12, 114)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(79, 23)
        Me.btOK.TabIndex = 4
        Me.btOK.Text = "&OK"
        '
        'btCancel
        '
        Me.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btCancel.Location = New System.Drawing.Point(97, 114)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(85, 23)
        Me.btCancel.TabIndex = 5
        Me.btCancel.Text = "&Cancel"
        '
        'btExpand
        '
        Me.btExpand.Location = New System.Drawing.Point(167, 62)
        Me.btExpand.Name = "btExpand"
        Me.btExpand.Size = New System.Drawing.Size(15, 20)
        Me.btExpand.TabIndex = 8
        Me.btExpand.Text = ">"
        Me.btExpand.UseVisualStyleBackColor = True
        '
        'dgUsers
        '
        Me.dgUsers.AllowUserToAddRows = False
        Me.dgUsers.AllowUserToDeleteRows = False
        Me.dgUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgUsers.Location = New System.Drawing.Point(191, 12)
        Me.dgUsers.Name = "dgUsers"
        Me.dgUsers.ReadOnly = True
        Me.dgUsers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgUsers.RowHeadersVisible = False
        Me.dgUsers.Size = New System.Drawing.Size(176, 125)
        Me.dgUsers.TabIndex = 9
        '
        'txPass
        '
        Me.txPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txPass.Location = New System.Drawing.Point(12, 88)
        Me.txPass.Name = "txPass"
        Me.txPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txPass.Size = New System.Drawing.Size(170, 20)
        Me.txPass.TabIndex = 7
        Me.txPass.WaterMarkColor = System.Drawing.Color.Gray
        Me.txPass.WaterMarkText = "Password"
        '
        'txUser
        '
        Me.txUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txUser.Location = New System.Drawing.Point(12, 62)
        Me.txUser.Name = "txUser"
        Me.txUser.Size = New System.Drawing.Size(149, 20)
        Me.txUser.TabIndex = 6
        Me.txUser.WaterMarkColor = System.Drawing.Color.Gray
        Me.txUser.WaterMarkText = "User Name"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.StingRay.My.Resources.Resources.Logo
        Me.PictureBox1.Location = New System.Drawing.Point(12, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(173, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btCancel
        Me.ClientSize = New System.Drawing.Size(379, 148)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.dgUsers)
        Me.Controls.Add(Me.btExpand)
        Me.Controls.Add(Me.txPass)
        Me.Controls.Add(Me.txUser)
        Me.Controls.Add(Me.btCancel)
        Me.Controls.Add(Me.btOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stingray Login"
        CType(Me.dgUsers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txUser As StingRay.WaterMarkTextBox
    Friend WithEvents txPass As StingRay.WaterMarkTextBox
    Friend WithEvents btExpand As System.Windows.Forms.Button
    Friend WithEvents dgUsers As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
