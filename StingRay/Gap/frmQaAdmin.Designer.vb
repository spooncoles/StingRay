<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQaAdmin
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
        Me.cbSection = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btNew = New System.Windows.Forms.Button()
        Me.btSectionAdd = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btDisallowNA = New System.Windows.Forms.Button()
        Me.btMarkAsNA = New System.Windows.Forms.Button()
        Me.btReplace = New System.Windows.Forms.Button()
        Me.lvQuestions = New StingRay.ListViewCustomReorder.ListViewEx()
        Me.questionNum = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.question = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.allowNA = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbSection
        '
        Me.cbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSection.FormattingEnabled = True
        Me.cbSection.Location = New System.Drawing.Point(61, 6)
        Me.cbSection.Name = "cbSection"
        Me.cbSection.Size = New System.Drawing.Size(121, 21)
        Me.cbSection.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Section"
        '
        'btNew
        '
        Me.btNew.Location = New System.Drawing.Point(592, 37)
        Me.btNew.Name = "btNew"
        Me.btNew.Size = New System.Drawing.Size(103, 23)
        Me.btNew.TabIndex = 3
        Me.btNew.Text = "New"
        Me.btNew.UseVisualStyleBackColor = True
        '
        'btSectionAdd
        '
        Me.btSectionAdd.Location = New System.Drawing.Point(188, 6)
        Me.btSectionAdd.Name = "btSectionAdd"
        Me.btSectionAdd.Size = New System.Drawing.Size(27, 23)
        Me.btSectionAdd.TabIndex = 5
        Me.btSectionAdd.Text = "+"
        Me.btSectionAdd.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btDisallowNA)
        Me.GroupBox1.Controls.Add(Me.btMarkAsNA)
        Me.GroupBox1.Controls.Add(Me.btReplace)
        Me.GroupBox1.Location = New System.Drawing.Point(592, 93)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(105, 106)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Checked Items:"
        '
        'btDisallowNA
        '
        Me.btDisallowNA.Location = New System.Drawing.Point(1, 76)
        Me.btDisallowNA.Name = "btDisallowNA"
        Me.btDisallowNA.Size = New System.Drawing.Size(103, 23)
        Me.btDisallowNA.TabIndex = 14
        Me.btDisallowNA.Text = "Disallow N/A"
        Me.btDisallowNA.UseVisualStyleBackColor = True
        '
        'btMarkAsNA
        '
        Me.btMarkAsNA.Location = New System.Drawing.Point(1, 47)
        Me.btMarkAsNA.Name = "btMarkAsNA"
        Me.btMarkAsNA.Size = New System.Drawing.Size(103, 23)
        Me.btMarkAsNA.TabIndex = 13
        Me.btMarkAsNA.Text = "Allow N/A"
        Me.btMarkAsNA.UseVisualStyleBackColor = True
        '
        'btReplace
        '
        Me.btReplace.Location = New System.Drawing.Point(1, 18)
        Me.btReplace.Name = "btReplace"
        Me.btReplace.Size = New System.Drawing.Size(103, 23)
        Me.btReplace.TabIndex = 12
        Me.btReplace.Text = "Replace"
        Me.btReplace.UseVisualStyleBackColor = True
        '
        'lvQuestions
        '
        Me.lvQuestions.CheckBoxes = True
        Me.lvQuestions.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.questionNum, Me.question, Me.allowNA})
        Me.lvQuestions.FullRowSelect = True
        Me.lvQuestions.GridLines = True
        Me.lvQuestions.Location = New System.Drawing.Point(12, 33)
        Me.lvQuestions.MultiSelect = False
        Me.lvQuestions.Name = "lvQuestions"
        Me.lvQuestions.Size = New System.Drawing.Size(574, 255)
        Me.lvQuestions.TabIndex = 9
        Me.lvQuestions.UseCompatibleStateImageBehavior = False
        Me.lvQuestions.View = System.Windows.Forms.View.Details
        '
        'questionNum
        '
        Me.questionNum.Text = "questionNum"
        '
        'question
        '
        Me.question.Text = "question"
        '
        'allowNA
        '
        Me.allowNA.Text = "allowNA"
        '
        'frmQaAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 301)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lvQuestions)
        Me.Controls.Add(Me.btSectionAdd)
        Me.Controls.Add(Me.btNew)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbSection)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmQaAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmQaAdmin"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbSection As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btNew As System.Windows.Forms.Button
    Friend WithEvents btSectionAdd As System.Windows.Forms.Button
    Friend WithEvents lvQuestions As StingRay.ListViewCustomReorder.ListViewEx
    Friend WithEvents questionNum As System.Windows.Forms.ColumnHeader
    Friend WithEvents question As System.Windows.Forms.ColumnHeader
    Friend WithEvents allowNA As System.Windows.Forms.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btDisallowNA As System.Windows.Forms.Button
    Friend WithEvents btMarkAsNA As System.Windows.Forms.Button
    Friend WithEvents btReplace As System.Windows.Forms.Button
End Class
