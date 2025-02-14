Imports System.IO
Imports Microsoft.SqlServer
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Module GlobalModule
    'CONFIG FILE
    Public ConfigFileLocation As String = Application.StartupPath
    Public ConfigFileName As String = "Backup.ini"
    Public ConfigFullPath As String = ConfigFileLocation & "\" & ConfigFileName

    'LOG FILE
    Public LogFileLocation As String = Application.StartupPath
    Public LogFileName As String = "AppError.log"
    Public LogFullPath As String = LogFileLocation & "\" & LogFileName

    Public Sub LogError(ErrorMessage As String, ex As Exception)
        Dim LogFilePath As String = LogFullPath

        Try
            Using writer As New StreamWriter(LogFilePath, True)
                writer.WriteLine("[" & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "] ERROR : " & ErrorMessage)
                writer.WriteLine("Stack Trace: " & ex.StackTrace)
            End Using
        Catch logEx As Exception
            Throw New Exception()
        End Try
    End Sub

    Public Sub AllowOnlyNumbers(ByVal Sender As Object, ByVal e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Module
