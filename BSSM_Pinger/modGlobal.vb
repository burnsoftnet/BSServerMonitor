Imports MySql.Data.MySqlClient
Imports BurnSoft.FileSystem
Imports System.Configuration
Imports System.Windows.Forms
Module modGlobal
    Public Conn As MySqlConnection
    Public CONSOLEMODE As Boolean
    Public MyLogFile As String
    Public MYCONNSTRING As String
    Public DEBUG As Boolean
    Public DEBUG_LOGFILE As String
    Public Function ConnectDB() As Integer
        Dim iAns As Integer = 0
        Err.Clear()
        Try
            Dim sConnect As String = MYCONNSTRING
            Conn = New MySqlConnection(sConnect)
            Conn.Open()
        Catch ex As Exception
            iAns = Err.Number
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, "modGlobal.ConnectDB")
        End Try
        Return iAns
    End Function
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
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, "modGlobal.ConnExe")
        End Try
    End Sub
    Public Function GetTimeValue(ByVal SQL As String, ByVal strCol As String) As Long
        Dim lAns As Long = 0
        Try
            If ConnectDB() = 0 Then
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    lAns = RS(strCol)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, "modGlobal.GetTimeValue")
        End Try
        Return lAns
    End Function
    Public Function GetMinMs(ByVal TSID As Long) As Long
        Dim lans As Long = 0
        Dim SQL As String = "select Min(MyTime) as mt from results_ping_raw where TSID=" & TSID
        lans = GetTimeValue(SQL, "mt")
        Return lans
    End Function
    Public Function GetMaxMs(ByVal TSID As Long) As Long
        Dim lans As Long = 0
        Dim SQL As String = "select max(MyTime) as mt from results_ping_raw where TSID=" & TSID
        lans = GetTimeValue(SQL, "mt")
        Return lans
    End Function
    Public Function GetAvgMs(ByVal TSID As Long) As Long
        Dim lans As Long = 0
        Dim SQL As String = "select AVG(MyTime) as mt from results_ping_raw where TSID=" & TSID
        lans = GetTimeValue(SQL, "mt")
        Return lans
    End Function
    Public Sub CatchError(ByVal strMsg As String, ByVal strLocation As String)
        Dim DoLog As Boolean = True
        Dim sMsg As String = "::" & strLocation & "::" & strMsg
        If Not DoLog Then
            If CONSOLEMODE Then Console.WriteLine(sMsg)
            Console.ReadLine()
        Else
            Dim Obj As New FileIO
            Obj.LogFile(Application.StartupPath & "\" & MyLogFile, sMsg)
            Obj = Nothing
        End If
    End Sub
    Function GetCommand(ByVal strLookFor As String, ByVal strType As String, ByRef DidExist As Boolean) As String
        Dim sAns As String = ""
        DidExist = False
        Select Case LCase(strType)
            Case "string"
                sAns = ""
            Case "bool"
                sAns = "false"
            Case "int"
                sAns = 0
            Case Else
                sAns = ""
        End Select
        Dim cmdLine() As String = System.Environment.GetCommandLineArgs
        Dim i As Integer = 0
        Dim intCount As Integer = cmdLine.Length
        Dim strValue As String = ""
        If intCount > 1 Then
            For i = 1 To intCount - 1
                strValue = cmdLine(i)
                strValue = Replace(strValue, "/", "")
                strValue = Replace(strValue, "--", "")
                Dim strSplit() As String = Split(strValue, "=")
                Dim intLBound As Integer = LBound(strSplit)
                Dim intUBound As Integer = UBound(strSplit)
                If LCase(strSplit(intLBound)) = LCase(strLookFor) Then
                    If intUBound <> 0 Then
                        sAns = strSplit(intUBound)
                    Else
                        sAns = "true"
                    End If
                    DidExist = True
                    Exit For
                End If
            Next
        End If
        Return LCase(sAns)
    End Function
    Public Sub CatchDebug(ByVal strMsg As String, ByVal strLocation As String)
        If Not DEBUG Then Exit Sub
        Dim DoLog As Boolean = True
        Dim sMsg As String = "::" & strLocation & "::" & strMsg
        If Not DoLog Then
            If CONSOLEMODE Then Console.WriteLine(sMsg)
            Console.ReadLine()
        Else
            Dim Obj As New FileIO
            Obj.LogFile(Application.StartupPath & "\" & DEBUG_LOGFILE, sMsg)
            Obj = Nothing
        End If
    End Sub
    Function EventExists(ByVal SID As Long, ByVal strShrt As String, ByVal strLng As String, ByVal Sev As String) As Boolean
        Dim bAns As Boolean = False
        Try
            If ConnectDB() = 0 Then
                Dim iTime As Long = CLng(System.Configuration.ConfigurationManager.AppSettings("REPEAT_EVT_HRS"))
                Dim SQL As String = "SELECT * from events_general where SID=" & SID & _
                    " and shrtEv='" & strShrt & "' and lngEv='" & strLng & _
                    "' and Sev='" & Sev & "' and DT > adddate(CURRENT_TIMESTAMP, INTERVAL -" & iTime & " HOUR)"
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                bAns = RS.HasRows
                RS.Close()
                RS = Nothing
                CMD = Nothing
            End If
        Catch ex As Exception
            Dim Obj As New FileIO
            Dim sMsg As String = Err.Number & ":" & ex.Message
            Obj.LogFile(Application.StartupPath & "\" & MyLogFile, sMsg)
            Obj = Nothing
        End Try
        Return bAns
    End Function
    Public Function INT_TO_BOOL(ByVal iValue As Integer) As Boolean
        Dim bAns As Boolean = False
        If iValue >= 1 Then bAns = True
        Return bAns
    End Function
End Module
