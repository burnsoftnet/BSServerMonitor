Imports System
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.Win32
Public Class BSRegistry
    Private _RegPath As String
    Public Property DefaultRegPath() As String
        Get
            If Len(_RegPath) = 0 Then _RegPath = "Software\\BurnSoft\\BSSM"
            Return _RegPath
        End Get
        Set(ByVal value As String)
            _RegPath = value
        End Set
    End Property
    Function Enum_Resgistry_Entries(ByVal sKey As String) As Collection
        Dim colKey As New Microsoft.VisualBasic.Collection()

        Dim Key As RegistryKey = Registry.LocalMachine.OpenSubKey(sKey, False)
        Dim SubKeyNames() As String = Key.GetSubKeyNames()
        Dim Index As Integer
        Dim SubKey As RegistryKey
        Dim KeyValue As String = ""
        colKey.Clear()
        For Index = 0 To Key.SubKeyCount - 1
            SubKey = Registry.LocalMachine.OpenSubKey(sKey + "\" + SubKeyNames(Index), False)
            KeyValue = CType(SubKey.GetValue("DisplayName", ""), String)
            colKey.Add(KeyValue)
        Next
        Return colKey
    End Function
    Function Enum_Resgistry_Entries_WithValue(ByVal sKey As String, ByVal sValue As String) As Collection
        Dim colKey As New Microsoft.VisualBasic.Collection()

        Dim Key As RegistryKey = Registry.LocalMachine.OpenSubKey(sKey, False)
        Dim SubKeyNames() As String = Key.GetSubKeyNames()
        Dim Index As Integer
        Dim SubKey As RegistryKey
        Dim KeyValue As String = ""
        colKey.Clear()
        For Index = 0 To Key.SubKeyCount - 1
            SubKey = Registry.LocalMachine.OpenSubKey(sKey + "\" + SubKeyNames(Index), False)
            If Not SubKey.GetValue(sValue, "") Is "" Then
                KeyValue = CType(SubKey.GetValue("DisplayName", ""), String)
                colKey.Add(KeyValue)
            End If
        Next
        Return colKey
    End Function
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
    Public Function GetViewSettings(ByVal sKey As String, Optional ByVal sDefault As String = "") As String
        Dim sAns As String = ""
        Dim strValue As String = DefaultRegPath & "\Settings"
        sAns = GetRegSubKeyValue(strValue, sKey, sDefault)
        Return sAns
    End Function
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
