Imports MySql.Data.MySqlClient
Imports System.Data
Public Class BSDatabase
    Private _DatabaseServer As String
    Private _DatabaseName As String
    Private _UserName As String
    Private _Password As String
    Public Conn As MySqlConnection
    Public MYCONNSTRING As String
    Public Property DatabaseServer() As String
        Get
            Return _DatabaseServer
        End Get
        Set(ByVal value As String)
            _DatabaseServer = value
        End Set
    End Property
    Public Property DatabaseName() As String
        Get
            Return _DatabaseName
        End Get
        Set(ByVal value As String)
            _DatabaseName = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return (_UserName)
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property
    Public Sub New()
        _UserName = ""
        _DatabaseServer = ""
        _DatabaseName = ""
        _Password = ""
    End Sub
    Public Function ConnectDB(Optional ByRef ErrorMsg As String = "") As Integer
        Dim iAns As Integer = 0
        Err.Clear()
        Try
            Dim sConnect As String = MYCONNSTRING
            If Len(sConnect) = 0 Then
                sConnect = "Server=" & DatabaseServer & ";user id=" & UserName & ";password=" & Password & ";persist security info=True;database=" & DatabaseName
            End If
            Conn = New MySqlConnection(sConnect)
            If Conn.State = ConnectionState.Closed Or Conn.State = ConnectionState.Broken Then
                Conn.Open()
            End If
        Catch ex As Exception
            iAns = Err.Number
            Dim strForm As String = "BSGlobalClass.BSDatabase"
            Dim strSubFunc As String = "ConnectDB"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            ErrorMsg = strForm & "." & strSubFunc & vbTab & sMsg
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
    Public Sub ConnExe(ByVal SQL As String, Optional ByRef ErrorMsg As String = "")
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
            ErrorMsg = strForm & "." & strSubFunc & vbTab & sMsg
        End Try
    End Sub
End Class
