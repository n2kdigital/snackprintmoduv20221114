<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.bnExit = New System.Windows.Forms.Button()
        Me.txtprintername = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtodbc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtuser = New System.Windows.Forms.TextBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnStar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtdb = New System.Windows.Forms.TextBox()
        Me.txtbar = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtrubrique = New System.Windows.Forms.TextBox()
        Me.txtbar2 = New System.Windows.Forms.TextBox()
        Me.txtbar3 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'bnExit
        '
        Me.bnExit.Location = New System.Drawing.Point(11, 435)
        Me.bnExit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.bnExit.Name = "bnExit"
        Me.bnExit.Size = New System.Drawing.Size(116, 34)
        Me.bnExit.TabIndex = 0
        Me.bnExit.Text = "Fermer"
        Me.bnExit.UseVisualStyleBackColor = True
        '
        'txtprintername
        '
        Me.txtprintername.Enabled = False
        Me.txtprintername.Location = New System.Drawing.Point(150, 58)
        Me.txtprintername.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtprintername.Name = "txtprintername"
        Me.txtprintername.Size = New System.Drawing.Size(253, 26)
        Me.txtprintername.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 58)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 20)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Nom Imprimante"
        '
        'txtodbc
        '
        Me.txtodbc.Enabled = False
        Me.txtodbc.Location = New System.Drawing.Point(148, 98)
        Me.txtodbc.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtodbc.Name = "txtodbc"
        Me.txtodbc.Size = New System.Drawing.Size(252, 26)
        Me.txtodbc.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 104)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "ODBC config"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'txtuser
        '
        Me.txtuser.Enabled = False
        Me.txtuser.Location = New System.Drawing.Point(148, 208)
        Me.txtuser.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtuser.Name = "txtuser"
        Me.txtuser.Size = New System.Drawing.Size(252, 26)
        Me.txtuser.TabIndex = 6
        '
        'txtpassword
        '
        Me.txtpassword.Enabled = False
        Me.txtpassword.Location = New System.Drawing.Point(150, 248)
        Me.txtpassword.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(250, 26)
        Me.txtpassword.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 208)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "User"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 248)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Password"
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Location = New System.Drawing.Point(286, 435)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(112, 35)
        Me.btnStop.TabIndex = 10
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnStar
        '
        Me.btnStar.Location = New System.Drawing.Point(146, 434)
        Me.btnStar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnStar.Name = "btnStar"
        Me.btnStar.Size = New System.Drawing.Size(112, 35)
        Me.btnStar.TabIndex = 11
        Me.btnStar.Text = "Start"
        Me.btnStar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 154)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "DataBase"
        '
        'txtdb
        '
        Me.txtdb.Enabled = False
        Me.txtdb.Location = New System.Drawing.Point(150, 154)
        Me.txtdb.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtdb.Name = "txtdb"
        Me.txtdb.Size = New System.Drawing.Size(248, 26)
        Me.txtdb.TabIndex = 13
        '
        'txtbar
        '
        Me.txtbar.Enabled = False
        Me.txtbar.Location = New System.Drawing.Point(153, 20)
        Me.txtbar.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbar.Name = "txtbar"
        Me.txtbar.Size = New System.Drawing.Size(78, 26)
        Me.txtbar.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 21)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 20)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Bar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(145, 384)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(165, 20)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Version 20201013 1.7"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 300)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(308, 20)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Rubrique à imprimer: Cmd;Con;Fac;Liq;Cui"
        '
        'txtrubrique
        '
        Me.txtrubrique.Enabled = False
        Me.txtrubrique.Location = New System.Drawing.Point(30, 330)
        Me.txtrubrique.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtrubrique.Name = "txtrubrique"
        Me.txtrubrique.Size = New System.Drawing.Size(373, 26)
        Me.txtrubrique.TabIndex = 17
        Me.txtrubrique.Text = "Cmd;Con;Fac;Liq;Cui"
        '
        'txtbar2
        '
        Me.txtbar2.Enabled = False
        Me.txtbar2.Location = New System.Drawing.Point(241, 21)
        Me.txtbar2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbar2.Name = "txtbar2"
        Me.txtbar2.Size = New System.Drawing.Size(78, 26)
        Me.txtbar2.TabIndex = 19
        '
        'txtbar3
        '
        Me.txtbar3.Enabled = False
        Me.txtbar3.Location = New System.Drawing.Point(325, 20)
        Me.txtbar3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtbar3.Name = "txtbar3"
        Me.txtbar3.Size = New System.Drawing.Size(78, 26)
        Me.txtbar3.TabIndex = 20
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 486)
        Me.Controls.Add(Me.txtbar3)
        Me.Controls.Add(Me.txtbar2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtrubrique)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtbar)
        Me.Controls.Add(Me.txtdb)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnStar)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtuser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtodbc)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtprintername)
        Me.Controls.Add(Me.bnExit)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bnExit As System.Windows.Forms.Button
    Friend WithEvents txtprintername As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtodbc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents txtuser As System.Windows.Forms.TextBox
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnStar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtdb As System.Windows.Forms.TextBox
    Friend WithEvents txtbar As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtrubrique As TextBox
    Friend WithEvents txtbar2 As TextBox
    Friend WithEvents txtbar3 As TextBox
End Class
