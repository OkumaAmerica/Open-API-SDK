<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.tbNo2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.tbNo1 = New System.Windows.Forms.TextBox()
        Me.btnWrite = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnRefresh
        '
        Me.btnRefresh.BackgroundImage = Global.VB_MC.My.Resources.Resources.Data_Synchronize
        Me.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRefresh.Location = New System.Drawing.Point(18, 126)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(72, 72)
        Me.btnRefresh.TabIndex = 41
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'tbNo2
        '
        Me.tbNo2.Location = New System.Drawing.Point(113, 87)
        Me.tbNo2.Name = "tbNo2"
        Me.tbNo2.Size = New System.Drawing.Size(100, 20)
        Me.tbNo2.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Location = New System.Drawing.Point(72, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "NO. 2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Location = New System.Drawing.Point(72, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "NO. 1"
        '
        'btnExit
        '
        Me.btnExit.BackgroundImage = Global.VB_MC.My.Resources.Resources.Fire_Exit
        Me.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(227, 126)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(72, 72)
        Me.btnExit.TabIndex = 38
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'tbNo1
        '
        Me.tbNo1.Location = New System.Drawing.Point(113, 60)
        Me.tbNo1.Name = "tbNo1"
        Me.tbNo1.Size = New System.Drawing.Size(100, 20)
        Me.tbNo1.TabIndex = 35
        '
        'btnWrite
        '
        Me.btnWrite.BackgroundImage = Global.VB_MC.My.Resources.Resources.Data_Edit
        Me.btnWrite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnWrite.Location = New System.Drawing.Point(124, 126)
        Me.btnWrite.Name = "btnWrite"
        Me.btnWrite.Size = New System.Drawing.Size(72, 72)
        Me.btnWrite.TabIndex = 37
        Me.btnWrite.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BackgroundImage = Global.VB_MC.My.Resources.Resources.Background
        Me.ClientSize = New System.Drawing.Size(320, 210)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.tbNo2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.tbNo1)
        Me.Controls.Add(Me.btnWrite)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CV Example"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents tbNo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents tbNo1 As System.Windows.Forms.TextBox
    Private WithEvents btnWrite As System.Windows.Forms.Button

End Class
