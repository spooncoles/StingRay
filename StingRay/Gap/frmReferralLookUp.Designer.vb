<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReferralLookUp
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
        Me.btSearch = New System.Windows.Forms.Button()
        Me.dgReferralDetails = New System.Windows.Forms.DataGridView()
        Me.txEmailAdd = New StingRay.WaterMarkTextBox()
        Me.txIDNum = New StingRay.WaterMarkTextBox()
        Me.txContactNum = New StingRay.WaterMarkTextBox()
        Me.txName = New StingRay.WaterMarkTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgReferralDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btSearch
        '
        Me.btSearch.Location = New System.Drawing.Point(557, 4)
        Me.btSearch.Name = "btSearch"
        Me.btSearch.Size = New System.Drawing.Size(80, 27)
        Me.btSearch.TabIndex = 51
        Me.btSearch.Text = "Search"
        Me.btSearch.UseVisualStyleBackColor = True
        '
        'dgReferralDetails
        '
        Me.dgReferralDetails.AllowUserToAddRows = False
        Me.dgReferralDetails.AllowUserToDeleteRows = False
        Me.dgReferralDetails.AllowUserToResizeColumns = False
        Me.dgReferralDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgReferralDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReferralDetails.Location = New System.Drawing.Point(12, 37)
        Me.dgReferralDetails.Name = "dgReferralDetails"
        Me.dgReferralDetails.ReadOnly = True
        Me.dgReferralDetails.RowHeadersVisible = False
        Me.dgReferralDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgReferralDetails.Size = New System.Drawing.Size(707, 353)
        Me.dgReferralDetails.TabIndex = 52
        '
        'txEmailAdd
        '
        Me.txEmailAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txEmailAdd.Location = New System.Drawing.Point(268, 4)
        Me.txEmailAdd.Name = "txEmailAdd"
        Me.txEmailAdd.Size = New System.Drawing.Size(131, 20)
        Me.txEmailAdd.TabIndex = 56
        Me.txEmailAdd.Tag = "emailAdd"
        Me.txEmailAdd.WaterMarkColor = System.Drawing.Color.Gray
        Me.txEmailAdd.WaterMarkText = "Email"
        '
        'txIDNum
        '
        Me.txIDNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txIDNum.Location = New System.Drawing.Point(405, 4)
        Me.txIDNum.Name = "txIDNum"
        Me.txIDNum.Size = New System.Drawing.Size(146, 20)
        Me.txIDNum.TabIndex = 55
        Me.txIDNum.Tag = "Vat_ID"
        Me.txIDNum.WaterMarkColor = System.Drawing.Color.Gray
        Me.txIDNum.WaterMarkText = "ID Num"
        '
        'txContactNum
        '
        Me.txContactNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txContactNum.Location = New System.Drawing.Point(151, 4)
        Me.txContactNum.Name = "txContactNum"
        Me.txContactNum.Size = New System.Drawing.Size(111, 20)
        Me.txContactNum.TabIndex = 54
        Me.txContactNum.Tag = "contactNum"
        Me.txContactNum.WaterMarkColor = System.Drawing.Color.Gray
        Me.txContactNum.WaterMarkText = "Contact Num"
        '
        'txName
        '
        Me.txName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txName.Location = New System.Drawing.Point(12, 4)
        Me.txName.Name = "txName"
        Me.txName.Size = New System.Drawing.Size(133, 20)
        Me.txName.TabIndex = 53
        Me.txName.Tag = "affinityName"
        Me.txName.WaterMarkColor = System.Drawing.Color.Gray
        Me.txName.WaterMarkText = "Name"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(661, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(58, 27)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "Export"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmReferralLookUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 401)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txEmailAdd)
        Me.Controls.Add(Me.txIDNum)
        Me.Controls.Add(Me.txContactNum)
        Me.Controls.Add(Me.txName)
        Me.Controls.Add(Me.btSearch)
        Me.Controls.Add(Me.dgReferralDetails)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmReferralLookUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmReferralLookUp"
        CType(Me.dgReferralDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txEmailAdd As WaterMarkTextBox
    Friend WithEvents txIDNum As WaterMarkTextBox
    Friend WithEvents txContactNum As WaterMarkTextBox
    Friend WithEvents txName As WaterMarkTextBox
    Friend WithEvents btSearch As Button
    Friend WithEvents dgReferralDetails As DataGridView
    Friend WithEvents Button1 As Button
End Class
