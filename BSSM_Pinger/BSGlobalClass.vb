Imports System.Net.NetworkInformation
Imports System
Imports System.Data
Imports System.Data.Odbc
Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Xml.XPath
Imports System.Configuration
Imports System.Windows.Forms
Imports System.Text
Imports Microsoft.Win32
Imports MySql.Data.MySqlClient
Namespace BurnSoft.GlobalClasses
    Public Class BSRegistry
        Private _RegPath As String
        Private _DefaultDBName As String
#Region "Registry General Functions and Subs"
        Public Property DefaultRegPath() As String
            Get
                Return "Software\\BurnSoft\\BSSM"
            End Get
            Set(ByVal value As String)
                _RegPath = value
            End Set
        End Property
        Public Property DefaultDBName() As String
            Get
                Return "BSSM.mdb"
            End Get
            Set(ByVal value As String)
                _DefaultDBName = value
            End Set
        End Property
        Public Sub CreateSubKey(ByVal strValue As String)
            Microsoft.Win32.Registry.LocalMachine.CreateSubKey(strValue)
        End Sub
        Public Function RegSubKeyExists(ByVal strValue As String) As Boolean
            Dim bAns As Boolean = False
            Try
                Dim MyReg As RegistryKey
                MyReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(strValue, True)
                If MyReg Is Nothing Then
                    bAns = False
                Else
                    bAns = True
                End If
            Catch ex As Exception
                bAns = False
            End Try
            Return bAns
        End Function
        Public Function GetRegSubKeyValue(ByVal strKey As String, ByVal strValue As String, ByVal strDefault As String) As String
            Dim sAns As String = ""
            Dim strMsg As String = ""
            Dim MyReg As RegistryKey
            Try
                If RegSubKeyExists(strKey) Then
                    MyReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(strKey, True)
                    If Len(MyReg.GetValue(strValue)) > 0 Then
                        sAns = MyReg.GetValue(strValue)
                    Else
                        MyReg.SetValue(strValue, strDefault)
                        sAns = strDefault
                    End If
                Else
                    Call CreateSubKey(strKey)
                    MyReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(strKey, True)
                    MyReg.SetValue(strValue, strDefault)
                    sAns = strDefault
                End If
            Catch ex As Exception
                sAns = strDefault
            End Try
            Return sAns
        End Function
        Public Function SettingsExists() As Boolean
            Dim bAns As Boolean = False
            Dim MyReg As RegistryKey
            Dim strValue As String = DefaultRegPath & "\Settings"
            On Error Resume Next
            MyReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(strValue, True)
            If MyReg Is Nothing Then
                bAns = False
            Else
                bAns = True
            End If
            Return bAns
        End Function
        Public Sub UpDateAppDetails()
            Dim strValue As String = DefaultRegPath
            If Not RegSubKeyExists(strValue) Then Call CreateSubKey(strValue)
            Dim MyReg As RegistryKey
            MyReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(strValue, True)
            MyReg.SetValue("Version", Application.ProductVersion)
            MyReg.SetValue("AppName", Application.ProductName)
            MyReg.SetValue("AppEXE", Application.ExecutablePath())
            MyReg.SetValue("Path", Application.StartupPath)
            MyReg.SetValue("LogPath", MyLogFile)
            MyReg.SetValue("DataBase", Application.StartupPath & "\" & DefaultDBName)
            MyReg.Close()
        End Sub
        Public Function GetLastWorkingDir() As String
            Dim sAns As String = ""
            Dim strValue As String = DefaultRegPath & "\Settings"
            sAns = GetRegSubKeyValue(strValue, "LastWorkingPath", "C:\")
            Return sAns
        End Function
        Public Sub SaveLastWorkingDir(ByVal strPath As String)
            Dim MyReg As RegistryKey
            Dim strValue As String = DefaultRegPath & "\Settings"
            If Not RegSubKeyExists(strValue) Then Call CreateSubKey(strValue)
            MyReg = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(strValue, RegistryKeyPermissionCheck.Default)
            MyReg.SetValue("LastWorkingPath", strPath)
            MyReg.Close()
        End Sub
#End Region
        Public Function GetDBSettings() As String
            Dim sAns As String = ""
            Dim strValue As String = DefaultRegPath & "\Settings"
            sAns = GetRegSubKeyValue(strValue, "DBConn", "")
            Return sAns
        End Function
        Public Sub SaveDBSettings(ByVal sConn As String)
            Dim strValue As String = DefaultRegPath & "\Settings"
            If Not RegSubKeyExists(strValue) Then Call CreateSubKey(strValue)
            Dim MyReg As RegistryKey
            MyReg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(strValue, True)
            MyReg.SetValue("DBConn", sConn)
            MyReg.Close()
        End Sub
    End Class
    Public Class BSFileSystem
        Public Sub LogFile(ByVal strPath As String, ByVal strMessage As String)
            Dim SendMessage As String = DateTime.Now & vbTab & strMessage
            Call AppendToFile(strPath, SendMessage)
        End Sub
        Public Sub DeleteFile(ByVal strPath As String)
            If File.Exists(strPath) Then
                File.Delete(strPath)
            End If
        End Sub
        Public Function FileExists(ByVal strPath As String)
            Return File.Exists(strPath)
        End Function
        Private Sub CreateFile(ByVal strPath As String)
            If File.Exists(strPath) = False Then
                Dim fs As New FileStream(strPath, FileMode.Append, FileAccess.Write, FileShare.Write)
                fs.Close()
            End If
        End Sub
        Private Sub AppendToFile(ByVal strPath As String, ByVal strNewLine As String)
            If File.Exists(strPath) = False Then Call CreateFile(strPath)
            Dim sw As New StreamWriter(strPath, True, Encoding.ASCII)
            sw.WriteLine(strNewLine)
            sw.Close()
        End Sub
        Public Sub OutPutToFile(ByVal strPath As String, ByVal strNewLine As String)
            Call AppendToFile(strPath, strNewLine)
        End Sub
        Public Sub MoveFile(ByVal strFrom As String, ByVal strTo As String)
            If File.Exists(strFrom) Then
                File.Move(strFrom, strTo)
            End If
        End Sub
        Public Sub CopyFile(ByVal strFrom As String, ByVal strTo As String)
            If File.Exists(strFrom) Then
                File.Copy(strFrom, strTo)
            End If
        End Sub
        Public Sub CreateDirectory(ByVal strPath As String)
            If Directory.Exists(strPath) Then
                Directory.CreateDirectory(strPath)
            End If
        End Sub
        Public Function DirectoryExists(ByVal strPath As String) As Boolean
            Return Directory.Exists(strPath)
        End Function
        Public Sub DeleteDirectory(ByVal strPath As String)
            If Directory.Exists(strPath) Then
                Directory.Delete(strPath)
            End If
        End Sub
        Public Sub MoveDirectory(ByVal strFrom As String, ByVal strTo As String)
            If Directory.Exists(strFrom) Then
                Directory.Move(strFrom, strTo)
            End If
        End Sub
        Public Sub RenameFile(ByVal strFrom As String, ByVal strTo As String)
            File.Move(strFrom, strTo)
        End Sub
        Public Function GetPathOfFile(ByVal strFile As String) As String
            Dim sAns As String = ""
            sAns = Path.GetDirectoryName(strFile)
            Return sAns
        End Function
        Public Function GetExtOfFile(ByVal strFile As String) As String
            Dim sAns As String = ""
            sAns = Path.GetExtension(strFile)
            Return sAns
        End Function
        Public Function GetNameOfFile(ByVal strFile As String) As String
            Dim sAns As String = ""
            sAns = Path.GetFileName(strFile)
            Return sAns
        End Function
        Public Function FileHasExtension(ByVal strFile As String) As Boolean
            Dim bAns As Boolean = False
            bAns = Path.HasExtension(strFile)
            Return bAns
        End Function
        Public Function GetNameOfFileWOExt(ByVal strFile As String) As String
            Dim sAns As String = ""
            sAns = Path.GetFileNameWithoutExtension(strFile)
            Return sAns
        End Function
    End Class
    Public Class BSDatabase
        Public Conn As MySqlConnection
        Public MYCONNSTRING As String
        Public Function ConnectDB() As Integer
            Dim iAns As Integer = 0
            Err.Clear()
            Try
                Dim sConnect As String = MYCONNSTRING
                Conn = New MySqlConnection(sConnect)
                If Conn.State = ConnectionState.Closed Or Conn.State = ConnectionState.Broken Then
                    Conn.Open()
                End If
            Catch ex As Exception
                iAns = Err.Number
                Dim strForm As String = "BSGlobalClass.BSDatabase"
                Dim strSubFunc As String = "ConnectDB"
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, strForm & "." & strSubFunc)
            End Try
            Return iAns
        End Function
        Public Sub CloseDB()
            Try
                If IsDBNull(Conn) Then
                    Conn.Close()
                ElseIf Conn.State = ConnectionState.Open And Conn.State <> ConnectionState.Executing Then
                    Conn.Close()
                End If
                Conn = Nothing
            Catch ex As Exception
                Conn = Nothing
            End Try
        End Sub
        Public Sub ConnExe(ByVal SQL As String)
            Try
                If ConnectDB() = 0 Then
                    Dim CMD As New MySqlCommand
                    CMD.CommandText = SQL
                    CMD.Connection = Conn
                    CMD.ExecuteNonQuery()
                    CMD.Connection.Close()
                    CMD = Nothing
                End If
            Catch ex As Exception
                Dim strForm As String = "BSGlobalClass.BSDatabase"
                Dim strSubFunc As String = "ConnExe"
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, strForm & "." & strSubFunc)
            End Try
        End Sub
    End Class
End Namespace