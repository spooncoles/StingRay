<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeadBatchGrid
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txTitle = New System.Windows.Forms.TextBox()
        Me.txFirstName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txLastName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txContactNum = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txEmailAdd = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txComment = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Title:"
        '
        'txTitle
        '
        Me.txTitle.Location = New System.Drawing.Point(92, 7)
        Me.txTitle.Name = "txTitle"
        Me.txTitle.Size = New System.Drawing.Size(180, 20)
        Me.txTitle.TabIndex = 1
        '
        'txFirstName
        '
        Me.txFirstName.Location = New System.Drawing.Point(92, 33)
        Me.txFirstName.Name = "txFirstName"
        Me.txFirstName.Size = New System.Drawing.Size(180, 20)
        Me.txFirstName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "First Name:"
        '
        'txLastName
        '
        Me.txLastName.Location = New System.Drawing.Point(92, 59)
        Me.txLastName.Name = "txLastName"
        Me.txLastName.Size = New System.Drawing.Size(180, 20)
        Me.txLastName.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Last Name:"
        '
        'txContactNum
        '
        Me.txContactNum.Location = New System.Drawing.Point(92, 85)
        Me.txContactNum.Name = "txContactNum"
        Me.txContactNum.Size = New System.Drawing.Size(180, 20)
        Me.txContactNum.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Contact Num:"
        '
        'txEmailAdd
        '
        Me.txEmailAdd.Location = New System.Drawing.Point(92, 111)
        Me.txEmailAdd.Name = "txEmailAdd"
        Me.txEmailAdd.Size = New System.Drawing.Size(180, 20)
        Me.txEmailAdd.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Email Add:"
        '
        'txComment
        '
        Me.txComment.Location = New System.Drawing.Point(92, 137)
        Me.txComment.Name = "txComment"
        Me.txComment.Size = New System.Drawing.Size(180, 20)
        Me.txComment.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Comment:"
        '
        'btSave
        '
        Me.btSave.Location = New System.Drawing.Point(12, 164)
        Me.btSave.Name = "btSave"
        Me.btSave.Size = New System.Drawing.Size(259, 23)
        Me.btSave.TabIndex = 12
        Me.btSave.Text = "Save Edit"
        Me.btSave.UseVisualStyleBackColor = True
        '
        'frmLeadBatchGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 198)
        Me.Controls.Add(Me.btSave)
        Me.Controls.Add(Me.txComment)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txEmailAdd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txContactNum)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txLastName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txFirstName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txTitle)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmLeadBatchGrid"
        Me.Text = "frmLeadBatchGrid"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txTitle As TextBox
    Friend WithEvents txFirstName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txLastName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txContactNum As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txEmailAdd As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txComment As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btSave As Button
End Class
