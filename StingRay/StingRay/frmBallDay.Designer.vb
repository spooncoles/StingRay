<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBallDay
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbBallValue = New System.Windows.Forms.Label()
        Me.btContinue = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(46, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(265, 39)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Congratulations!"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(78, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(198, 29)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "you've recieved a"
        '
        'lbBallValue
        '
        Me.lbBallValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbBallValue.Location = New System.Drawing.Point(1, 115)
        Me.lbBallValue.Name = "lbBallValue"
        Me.lbBallValue.Size = New System.Drawing.Size(354, 39)
        Me.lbBallValue.TabIndex = 2
        Me.lbBallValue.Text = "BALL VALUE HERE"
        Me.lbBallValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btContinue
        '
        Me.btContinue.Location = New System.Drawing.Point(12, 190)
        Me.btContinue.Name = "btContinue"
        Me.btContinue.Size = New System.Drawing.Size(330, 23)
        Me.btContinue.TabIndex = 3
        Me.btContinue.Text = "Continue"
        Me.btContinue.UseVisualStyleBackColor = True
        '
        'frmBallDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 225)
        Me.Controls.Add(Me.btContinue)
        Me.Controls.Add(Me.lbBallValue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmBallDay"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmBallDay"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbBallValue As System.Windows.Forms.Label
    Friend WithEvents btContinue As System.Windows.Forms.Button
End Class
