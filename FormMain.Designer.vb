<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.CmbDatabaseType = New System.Windows.Forms.ComboBox()
        Me.TxtServer = New System.Windows.Forms.TextBox()
        Me.TxtUser = New System.Windows.Forms.TextBox()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.TxtDatabase = New System.Windows.Forms.TextBox()
        Me.TxtFrequency = New System.Windows.Forms.TextBox()
        Me.TxtBackupLocation = New System.Windows.Forms.TextBox()
        Me.BtnBrowse = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'CmbDatabaseType
        '
        Me.CmbDatabaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbDatabaseType.FormattingEnabled = True
        Me.CmbDatabaseType.Items.AddRange(New Object() {"MySQL", "MSSQL"})
        Me.CmbDatabaseType.Location = New System.Drawing.Point(44, 78)
        Me.CmbDatabaseType.Name = "CmbDatabaseType"
        Me.CmbDatabaseType.Size = New System.Drawing.Size(374, 23)
        Me.CmbDatabaseType.TabIndex = 0
        '
        'TxtServer
        '
        Me.TxtServer.Location = New System.Drawing.Point(44, 131)
        Me.TxtServer.Name = "TxtServer"
        Me.TxtServer.Size = New System.Drawing.Size(374, 23)
        Me.TxtServer.TabIndex = 1
        '
        'TxtUser
        '
        Me.TxtUser.Location = New System.Drawing.Point(45, 182)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.Size = New System.Drawing.Size(374, 23)
        Me.TxtUser.TabIndex = 2
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(44, 237)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.Size = New System.Drawing.Size(374, 23)
        Me.TxtPassword.TabIndex = 3
        '
        'TxtDatabase
        '
        Me.TxtDatabase.Location = New System.Drawing.Point(45, 290)
        Me.TxtDatabase.Name = "TxtDatabase"
        Me.TxtDatabase.Size = New System.Drawing.Size(374, 23)
        Me.TxtDatabase.TabIndex = 4
        '
        'TxtFrequency
        '
        Me.TxtFrequency.Location = New System.Drawing.Point(45, 343)
        Me.TxtFrequency.Name = "TxtFrequency"
        Me.TxtFrequency.Size = New System.Drawing.Size(374, 23)
        Me.TxtFrequency.TabIndex = 5
        Me.TxtFrequency.Text = "60"
        '
        'TxtBackupLocation
        '
        Me.TxtBackupLocation.Location = New System.Drawing.Point(45, 399)
        Me.TxtBackupLocation.Name = "TxtBackupLocation"
        Me.TxtBackupLocation.Size = New System.Drawing.Size(337, 23)
        Me.TxtBackupLocation.TabIndex = 6
        '
        'BtnBrowse
        '
        Me.BtnBrowse.Location = New System.Drawing.Point(384, 398)
        Me.BtnBrowse.Name = "BtnBrowse"
        Me.BtnBrowse.Size = New System.Drawing.Size(35, 25)
        Me.BtnBrowse.TabIndex = 7
        Me.BtnBrowse.Text = "..."
        Me.BtnBrowse.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(339, 454)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(80, 30)
        Me.BtnSave.TabIndex = 8
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "DB Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Server / Data Source"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "DB User"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "DB Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 272)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Database"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(45, 325)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 15)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Backup Frequency"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(45, 379)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 15)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Backup Location"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(364, 347)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 15)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Minutes"
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(455, 508)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnBrowse)
        Me.Controls.Add(Me.TxtBackupLocation)
        Me.Controls.Add(Me.TxtFrequency)
        Me.Controls.Add(Me.TxtDatabase)
        Me.Controls.Add(Me.TxtPassword)
        Me.Controls.Add(Me.TxtUser)
        Me.Controls.Add(Me.TxtServer)
        Me.Controls.Add(Me.CmbDatabaseType)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Backup Database"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CmbDatabaseType As ComboBox
    Friend WithEvents TxtServer As TextBox
    Friend WithEvents TxtUser As TextBox
    Friend WithEvents TxtPassword As TextBox
    Friend WithEvents TxtDatabase As TextBox
    Friend WithEvents TxtFrequency As TextBox
    Friend WithEvents TxtBackupLocation As TextBox
    Friend WithEvents BtnBrowse As Button
    Friend WithEvents BtnSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
