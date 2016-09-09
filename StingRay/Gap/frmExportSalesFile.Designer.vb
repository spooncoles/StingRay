<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportSalesFile
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
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbFileName = New System.Windows.Forms.ComboBox()
        Me.btExport = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(118, 71)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(88, 20)
        Me.dtTo.TabIndex = 83
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(12, 71)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(88, 20)
        Me.dtFrom.TabIndex = 82
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(102, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "to"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Sale Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Sales Files:"
        '
        'cbFileName
        '
        Me.cbFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFileName.FormattingEnabled = True
        Me.cbFileName.Items.AddRange(New Object() {"Gap Sales File", "Group Sales File"})
        Me.cbFileName.Location = New System.Drawing.Point(75, 6)
        Me.cbFileName.Name = "cbFileName"
        Me.cbFileName.Size = New System.Drawing.Size(131, 21)
        Me.cbFileName.TabIndex = 87
        '
        'btExport
        '
        Me.btExport.Location = New System.Drawing.Point(12, 110)
        Me.btExport.Name = "btExport"
        Me.btExport.Size = New System.Drawing.Size(194, 23)
        Me.btExport.TabIndex = 88
        Me.btExport.Text = "Export"
        Me.btExport.UseVisualStyleBackColor = True
        '
        'frmExportSalesFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(225, 149)
        Me.Controls.Add(Me.btExport)
        Me.Controls.Add(Me.cbFileName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtTo)
        Me.Controls.Add(Me.dtFrom)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmExportSalesFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export Sales File"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbFileName As System.Windows.Forms.ComboBox
    Friend WithEvents btExport As System.Windows.Forms.Button
End Class
