Public Class frmMessage
    Inherits System.Windows.Forms.Form

    Dim m_strLabelMessage As String
    Dim m_strTextMessage As String
    Friend WithEvents pnlMessage As System.Windows.Forms.Panel
    Friend WithEvents pnlMessage2 As System.Windows.Forms.Panel
    Dim m_enMessageIcon As MessageBoxIcon
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal strLabelMessage As String, ByVal strTextMessage As String, ByVal enMessageIcon As MessageBoxIcon)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        m_strLabelMessage = strLabelMessage
        m_strTextMessage = strTextMessage
        m_enMessageIcon = enMessageIcon

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtMessage As System.Windows.Forms.TextBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMessage))
        Me.txtMessage = New System.Windows.Forms.TextBox()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.pnlMessage = New System.Windows.Forms.Panel()
        Me.pnlMessage2 = New System.Windows.Forms.Panel()
        Me.pnlMessage.SuspendLayout()
        Me.pnlMessage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtMessage
        '
        Me.txtMessage.BackColor = System.Drawing.Color.White
        Me.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessage.Location = New System.Drawing.Point(0, 0)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ReadOnly = True
        Me.txtMessage.Size = New System.Drawing.Size(568, 166)
        Me.txtMessage.TabIndex = 0
        '
        'lblMessage
        '
        Me.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Red
        Me.lblMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(568, 198)
        Me.lblMessage.TabIndex = 1
        '
        'pnlMessage
        '
        Me.pnlMessage.Controls.Add(Me.txtMessage)
        Me.pnlMessage.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMessage.Location = New System.Drawing.Point(0, 0)
        Me.pnlMessage.Name = "pnlMessage"
        Me.pnlMessage.Size = New System.Drawing.Size(568, 166)
        Me.pnlMessage.TabIndex = 2
        '
        'pnlMessage2
        '
        Me.pnlMessage2.Controls.Add(Me.lblMessage)
        Me.pnlMessage2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMessage2.Location = New System.Drawing.Point(0, 166)
        Me.pnlMessage2.Name = "pnlMessage2"
        Me.pnlMessage2.Size = New System.Drawing.Size(568, 198)
        Me.pnlMessage2.TabIndex = 3
        '
        'frmMessage
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 364)
        Me.Controls.Add(Me.pnlMessage2)
        Me.Controls.Add(Me.pnlMessage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMessage"
        Me.Text = "Message Form"
        Me.pnlMessage.ResumeLayout(False)
        Me.pnlMessage.PerformLayout()
        Me.pnlMessage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub frmMessage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblMessage.Text = m_strLabelMessage
        txtMessage.Text = m_strTextMessage
    End Sub
End Class
