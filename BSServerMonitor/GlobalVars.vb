Imports System.Data.Odbc
Imports MySql.Data.MySqlClient
Imports BSServerMonitor.BurnSoft.GlobalClasses
Imports BurnSoft.FileSystem
Module GlobalVars
    Public MyLogFile As String
    Public sConn As String
    Public VIEW_SERVERDETAILS_PING_LIMIT As Long
    Public VIEW_DOWNONLY As Boolean
    Public READ_ONLY
    Public Function UnFluffContent(ByVal strContent As String) As String
        Dim sAns As String = ""
        sAns = Trim(Replace(strContent, "''", "'"))
        If Len(sAns) = 0 Then
            sAns = ""
        End If
        Return sAns
    End Function
    Public Function FluffContent(ByVal strContent As String) As String
        Dim sAns As String = ""
        sAns = Trim(Replace(strContent, "'", "''"))
        If Len(sAns) = 0 Then
            sAns = "   "
        End If
        Return sAns
    End Function
    Public Function FluffContent(ByVal strContent As String, ByVal lDefault As Double) As Double
        Dim sAns As Double = 0
        If Len(strContent) = 0 Then
            sAns = lDefault
        Else
            sAns = CDbl(strContent)
        End If
        Return sAns
    End Function
    Public Function IsRequired(ByVal strValue As String, ByVal strField As String, ByVal StrTitle As String) As Boolean
        Dim bAns As Boolean = False
        If Len(Trim(strValue)) = 0 Then
            bAns = False
        Else
            bAns = True
        End If
        If bAns = False Then MsgBox("Please put in a value for " & strField & "!", MsgBoxStyle.Critical, StrTitle)
        Return bAns
    End Function
    Public Function IsRequired(ByVal lValue As Long, ByVal lDefault As Long, ByVal strField As String, ByVal StrTitle As String) As Boolean
        Dim bAns As Boolean = False
        If lValue = lDefault Then
            bAns = False
        Else
            bAns = True
        End If
        If bAns = False Then MsgBox("Please put in a value for " & strField & "!", MsgBoxStyle.Critical, StrTitle)
        Return bAns
    End Function
    Public Function IsRequired(ByVal lValue As Double, ByVal lDefault As Double, ByVal strField As String, ByVal StrTitle As String) As Boolean
        Dim bAns As Boolean = False
        If lValue = lDefault Then
            bAns = False
        Else
            bAns = True
        End If
        If bAns = False Then MsgBox("Please put in a value for " & strField & "!", MsgBoxStyle.Critical, StrTitle)
        Return bAns
    End Function
    Public Function ShortPath() As String
        Dim strPath As String
        Dim strSplit() As String
        Dim IntBound As Integer
        Dim sAns As String = ""
        Dim i As Integer

        strPath = Replace(Application.StartupPath, " ", "")

        strSplit = Split(strPath, "\")
        IntBound = UBound(strSplit)
        If IntBound > 0 Then
            For i = 0 To IntBound
                If Len(strSplit(i)) > 8 Then
                    sAns &= Left(Trim(strSplit(i)), 6) & "~1" & "\"
                Else
                    sAns &= strSplit(i) & "\"
                End If
            Next
        End If
        Return sAns
        Exit Function
    End Function
    Public Sub CatchError(ByVal strMsg As String, ByVal strLocation As String)
        Dim DoLog As Boolean = True
        Dim sMsg As String = "::" & strLocation & "::" & strMsg
        Dim Obj As New FileIO
        Obj.LogFile(MyLogFile, sMsg)
        Obj = Nothing
    End Sub
    Public Sub CatchDebug(ByVal strMsg As String, ByVal strLocation As String)
        'If Not DEBUG Then Exit Sub
        Dim DoLog As Boolean = True
        Dim sMsg As String = "::" & strLocation & "::" & strMsg
        Dim Obj As New FileIO
        Obj.LogFile(ShortPath() & "\buggerme.log", sMsg)
        Obj = Nothing
    End Sub
    Public Function INT_TO_BOOL(ByVal iValue As Integer) As Boolean
        Dim bAns As Boolean = False
        If iValue >= 1 Then bAns = True
        Return bAns
    End Function
    Public Sub UpdateStatus(ByVal SID As Long, ByVal iValue As Integer, ByVal sCol As String)
        Dim cStat As Integer = 3
        Select Case iValue
            Case 1
                cStat = 1
            Case 0
                cStat = 3
        End Select
        Dim obj As New BSDatabase
        obj.MYCONNSTRING = sConn
        Dim SQL As String = "Update list_servers set " & sCol & "=" & iValue & ", CS=" & cStat & " where ID=" & SID
        obj.ConnExe(SQL)
        obj = Nothing
    End Sub
    Public Function LastUpdateTime() As String
        Dim sAns As String = ""
        Try
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            If Obj.ConnectDB = 0 Then
                Dim SQL As String = "SELECT * from self_lastrun"
                Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    sAns = RS("LastRun")
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
        Catch ex As Exception
            Dim strForm As String = "GlobalVars"
            Dim strSubFunc As String = "LastUpdateTime"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return sAns
    End Function
    Public Function GetDeviceIP(ByVal SID As Long) As String
        Dim sAns As String = ""
        Try
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            If Obj.ConnectDB = 0 Then
                Dim SQL As String = "select ServerIPAddress from list_servers where ID=" & SID
                Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    sAns = RS("ServerIPAddress")
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
        Catch ex As Exception
            Dim strForm As String = "GlobalVars"
            Dim strSubFunc As String = "GetDeviceIP"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return sAns
    End Function
    Public Function GetCollectorName(ByVal CID As Long) As String
        Dim sAns As String = "UNKNOWN/NOT LISTED"
        Try
            If CID <> 0 Then
                Dim Obj As New BSDatabase
                Obj.MYCONNSTRING = sConn
                If Obj.ConnectDB = 0 Then
                    Dim SQL As String = "select * from list_collectors where ID=" & CID
                    Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read
                        sAns = UCase(RS("ServerName"))
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                End If
            Else
                sAns = "DEFAULT"
            End If
        Catch ex As Exception
            Dim strForm As String = "GlobalVars"
            Dim strSubFunc As String = "GetCollectorName"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return sAns
    End Function
End Module
