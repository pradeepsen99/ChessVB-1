<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EntranceForm
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MainTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MainLogo1 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.ChessGameVB.My.Resources.Resources.chessstuffs_blogspot__4_
        Me.PictureBox1.Location = New System.Drawing.Point(12, 113)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(506, 319)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'MainTimer
        '
        Me.MainTimer.Enabled = True
        Me.MainTimer.Interval = 700
        '
        'MainLogo1
        '
        Me.MainLogo1.BackColor = System.Drawing.Color.Black
        Me.MainLogo1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.MainLogo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 42.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainLogo1.ForeColor = System.Drawing.Color.Lime
        Me.MainLogo1.Location = New System.Drawing.Point(15, 9)
        Me.MainLogo1.Name = "MainLogo1"
        Me.MainLogo1.Size = New System.Drawing.Size(506, 76)
        Me.MainLogo1.TabIndex = 2
        Me.MainLogo1.Text = "Chess Game 2014"
        '
        'EntranceForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(533, 444)
        Me.Controls.Add(Me.MainLogo1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "EntranceForm"
        Me.Text = "EntranceForm"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents MainTimer As System.Windows.Forms.Timer
    Friend WithEvents MainLogo1 As System.Windows.Forms.Label
End Class
