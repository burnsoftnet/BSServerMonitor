Imports System.Net.NetworkInformation
Imports System
Imports System.Data
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
                Conn.Open()
            Catch ex As Exception
                iAns = Err.Number
                Dim strForm As String = "BSGlobalClass.BSDatabase"
                Dim strSubFunc As String = "ConnectDB"
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, strForm & "." & strSubFunc)
            End Try
            Return iAns
        End Function
        Public Sub ConnExe(ByVal SQL As String)
            Try
                If ConnectDB() = 0 Then
                    Call CatchDebug(SQL, "BSGlobalClass.BSDatabase.ConnExe")
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
                sMsg &= Chr(13) & SQL
                Call CatchError(sMsg, strForm & "." & strSubFunc)
            End Try
        End Sub
        Public Sub CloseDB()
            Conn.Close()
            Conn = Nothing
        End Sub
    End Class
    Public Class BSGlobalFunctions
        Public Function GetDeviceType(ByVal TID As Long) As String
            Dim sAns As String = ""
            Try
                Dim Obj As New BSDatabase
                Obj.MYCONNSTRING = sConn
                If Obj.ConnectDB = 0 Then
                    Dim SQL As String = "SELECT * from list_servers_types where ID=" & TID
                    Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read()
                        sAns = RS("Cat")
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Obj.CloseDB()
                End If
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, "BSGlobalFunctions.GetDeviceType(String)")
            End Try
            Return sAns
        End Function
        Public Function GetDeviceType(ByVal Cat As String) As Long
            Dim iAns As Long = 0
            Try
                Dim Obj As New BSDatabase
                Obj.MYCONNSTRING = sConn
                If Obj.ConnectDB = 0 Then
                    Dim SQL As String = "SELECT * from list_servers_types where Cat='" & Cat & "'"
                    Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read()
                        iAns = RS("ID")
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Obj.CloseDB()
                End If
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, "BSGlobalFunctions.GetDeviceType(Long)")
            End Try
            Return iAns
        End Function
        Public Function GetLowestCollector() As Long
            Dim lAns As Long = 0
            Try
                Dim Obj As New BSDatabase
                Obj.MYCONNSTRING = sConn
                Dim SQL As String = "select ID from view_collector_list where isbalanced=1 and Status='Enabled' order by cl asc limit 0,1"
                If Obj.ConnectDB = 0 Then
                    Dim CMD As New MySqlCommand(Sql, Obj.Conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read
                        lAns = RS("ID")
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Obj.CloseDB()
                End If
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, "BSGlobalFunctions.GetLowestCollector(Long)")
            End Try
            Return lAns
        End Function
    End Class
End Namespace
