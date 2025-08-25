Imports System.IO
Imports Microsoft.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Imports System.Timers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.Win32

Public Class FormMain
    Private backupTimer As System.Timers.Timer
    Private iniFilePath As String = ConfigFullPath
    Private notifyIcon As NotifyIcon
    Private backupCounter As Integer = 0

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadConfig()
        StartBackupTimer()
        SetupTrayIcon()
        RunOnStartup(True)
    End Sub

    Private Sub StartBackupTimer()
        If backupTimer IsNot Nothing Then
            backupTimer.Stop()
            backupTimer.Dispose()
        End If

        Dim intervalMinutes As Integer = Integer.Parse(TxtFrequency.Text)
        backupTimer = New System.Timers.Timer(intervalMinutes * 60000)
        AddHandler backupTimer.Elapsed, AddressOf PerformBackup
        backupTimer.Start()
    End Sub

    Private Sub PerformBackup(source As Object, e As ElapsedEventArgs)
        If Me.InvokeRequired Then
            Me.Invoke(New Action(Of Object, ElapsedEventArgs)(AddressOf PerformBackup), source, e)
            Return
        End If

        Dim dbType As String = If(CmbDatabaseType.SelectedItem IsNot Nothing, CmbDatabaseType.SelectedItem.ToString(), "MySQL")
        If String.IsNullOrEmpty(dbType) Then
            MessageBox.Show("Database type is not selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim server As String = TxtServer.Text
        Dim user As String = TxtUser.Text
        Dim password As String = TxtPassword.Text
        Dim database As String = TxtDatabase.Text
        Dim backupLocation As String = If(String.IsNullOrWhiteSpace(TxtBackupLocation.Text), Application.StartupPath, TxtBackupLocation.Text)
        Dim backupFile As String = Path.Combine(backupLocation, If(backupCounter Mod 2 = 0, "backup_1.sql", "backup_2.sql"))
        If dbType = "MSSQL" Then
            backupFile = Path.Combine(backupLocation, If(backupCounter Mod 2 = 0, "backup_1.bak", "backup_2.bak"))
        End If
        backupCounter += 1

        Try
            If dbType = "MySQL" Then
                Dim ConnectionString As String = "Data Source = " & server & ";" _
                            & "Database = " & database & ";" _
                            & "User ID = " & user & ";" _
                            & "Password = " & password & ";"

                Using Connection As New MySqlConnection(ConnectionString)
                    Connection.Open()

                    Using Command As New MySqlCommand()
                        Command.Connection = Connection
                        Dim Backup As New MySqlBackup(Command)

                        'CREATE A FILE STREAM TO WRITE THE BACKUP
                        Backup.ExportToFile(backupFile)
                    End Using
                End Using
            ElseIf dbType = "MSSQL" Then
                Dim ConnectionString As String = "Data Source = " & server & ";" _
                            & "Initial Catalog = " & database & ";" _
                            & "User ID = " & user & ";" _
                            & "Password = " & password & ";"

                Dim SqlVersion As String = GetSqlServerVersion(ConnectionString)
                Dim sqlVersionNumber As Integer
                Dim versionParts() As String = SqlVersion.Split(".")

                If versionParts.Length > 0 AndAlso Integer.TryParse(versionParts(0), sqlVersionNumber) Then
                    If (sqlVersionNumber = 8 OrElse sqlVersionNumber = 9) Then
                        'SQL Server 2000 / 2005 - Use System.Data.SqlClient
                        Using Connection As New System.Data.SqlClient.SqlConnection(ConnectionString)
                            Connection.Open()
                            Dim Command As New System.Data.SqlClient.SqlCommand($"BACKUP DATABASE [{database}] TO DISK = N'{backupFile}'", Connection)
                            Command.ExecuteNonQuery()
                        End Using
                    Else
                        'SQL Server 2008+ - Use Microsoft.Data.SqlClient
                        Using Connection As New Microsoft.Data.SqlClient.SqlConnection(ConnectionString)
                            Connection.Open()
                            Dim Command As New Microsoft.Data.SqlClient.SqlCommand($"BACKUP DATABASE [{database}] TO DISK = N'{backupFile}'", Connection)
                            Command.ExecuteNonQuery()
                        End Using
                    End If
                End If
            End If

            WriteLog("Backup completed for " & dbType & " - " & backupFile)
        Catch ex As Exception
            LogError(ex.Message, ex)
            MessageBox.Show("Backup failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadConfig()
        If File.Exists(iniFilePath) Then
            Dim lines() As String = File.ReadAllLines(iniFilePath)
            For Each line In lines
                Dim parts() As String = line.Split("=")
                If parts.Length = 2 Then
                    Select Case parts(0)
                        Case "DbType" : CmbDatabaseType.SelectedItem = parts(1)
                        Case "Server" : TxtServer.Text = parts(1)
                        Case "User" : TxtUser.Text = parts(1)
                        Case "Password" : TxtPassword.Text = parts(1)
                        Case "Database" : TxtDatabase.Text = parts(1)
                        Case "Frequency" : TxtFrequency.Text = parts(1)
                        Case "Backup Location" : TxtBackupLocation.Text = parts(1)
                    End Select
                End If
            Next
        End If
    End Sub

    Private Sub SaveConfig()
        Dim lines As String() = {
            "DbType=" & CmbDatabaseType.SelectedItem.ToString(),
            "Server=" & TxtServer.Text,
            "User=" & TxtUser.Text,
            "Password=" & TxtPassword.Text,
            "Database=" & TxtDatabase.Text,
            "Frequency=" & TxtFrequency.Text,
            "Backup Location=" & TxtBackupLocation.Text
        }
        File.WriteAllLines(iniFilePath, lines)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        SaveConfig()
        StartBackupTimer()
        MessageBox.Show("Settings saved and backup timer restarted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub SetupTrayIcon()
        notifyIcon = New NotifyIcon()
        notifyIcon.Icon = SystemIcons.Information
        notifyIcon.Text = "Database Backup Tool"
        notifyIcon.Visible = True
        AddHandler notifyIcon.DoubleClick, AddressOf RestoreFromTray
    End Sub

    Private Sub RestoreFromTray(sender As Object, e As EventArgs)
        Me.Show()
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub MainForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Hide()
        End If
    End Sub

    ' Run on Windows Startup
    Private Sub RunOnStartup(enable As Boolean)
        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        If enable Then
            key.SetValue("DatabaseBackupTool", Application.ExecutablePath)
        Else
            key.DeleteValue("DatabaseBackupTool", False)
        End If
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles BtnBrowse.Click
        Dim FolderDialog As New FolderBrowserDialog
        FolderDialog.Description = "Select a backup folder"

        If FolderDialog.ShowDialog() = DialogResult.OK Then
            Me.TxtBackupLocation.Text = FolderDialog.SelectedPath
        End If
    End Sub

    Private Function GetSqlServerVersion(ConnectionString As String) As String
        Try
            Using Connection As New System.Data.SqlClient.SqlConnection(ConnectionString)
                Connection.Open()

                WriteLog("MSSQL Version " & Connection.ServerVersion)
                Return Connection.ServerVersion
            End Using
        Catch ex As Exception
            LogError(ex.Message, ex)
            Return ""
        End Try
    End Function
End Class
