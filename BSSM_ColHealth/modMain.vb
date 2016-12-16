Imports BSSM_ColHealth.BurnSoft.GlobalClasses
Imports System
Imports System.Data
Imports mysql.Data.MySqlClient
Imports System.Xml
Imports System.Xml.XPath
Imports System.Configuration
Imports System.Windows.Forms
Imports System.Text
Module modMain
    Public RegularInterval As Long
    Public DefaultCollector As Long
    Public xTimesInterval As Long
    Public FORCE_REVERT As Boolean
    Public FORCE_MOVE As Boolean
    Public FORCE_CID_Exists As Boolean
    Public FORCE_CID As Long
    Sub WriteToCollectorEvents(ByVal ShortMsg As String, ByVal LongMsg As String, ByVal ErrType As String)
        Dim SQL As String = "INSERT INTO events_general (SID,shrtEv, lngEv, Sev) VALUES (" & _
                    DefaultCollector & ",'" & ShortMsg & "','" & LongMsg & "','" & ErrType & "')"
        ConnExe(SQL)
    End Sub
    Sub MoveLoad(ByVal CID As Long, Optional ByVal COLNAME As String = "")
        Try
            If ConnectDB() = 0 Then
                Dim SQLTemp As String = ""
                Dim SQL As String = "SELECT ID from list_servers where CID=" & CID
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                Dim SID As Long = 0
                While RS.Read()
                    SID = RS("ID")
                    SQLTemp = "INSERT INTO list_collectors_tempass (CID,SID) VALUES(" & _
                                CID & "," & SID & ")"
                    Call CatchDebug(SQLTemp, "modMain.MoveData")
                    ConnExe(SQLTemp)
                End While
                SQLTemp = "Update list_servers set CID=" & DefaultCollector & " where CID=" & CID
                Call CatchDebug(SQLTemp, "modMain.MoveData")
                ConnExe(SQLTemp)
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Dim sMsg As String = "Collector ID " & CID & " was not responding, so Clients where Moved."
                Call WriteToCollectorEvents("Clients where Moved", sMsg, "WARNING")
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "MoveLoad"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
    Function WasMoved(ByVal CID As Long) As Boolean
        Dim bAns As Boolean = False
        Try
            If ConnectDB() = 0 Then
                Dim SQL As String = "SELECT * from list_collectors_tempass where CID=" & CID
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                bAns = RS.HasRows
                RS.Close()
                RS = Nothing
                CMD = Nothing
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "WasMoved"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return bAns
    End Function
    Sub RevertLoad(ByVal CID As Long)
        Try
            If ConnectDB() = 0 Then
                Dim SQL As String = "SELECT * from list_collectors_tempass where CID=" & CID
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                Dim MySQL As String = ""
                Dim SID As Long = 0
                While RS.Read
                    SID = RS("SID")
                    MySQL = "UPDATE list_servers set CID=" & CID & " where ID=" & SID
                    Call CatchDebug(MySQL, "modMain.RevertLoad")
                    ConnExe(MySQL)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                ConnExe("DELETE from list_collectors_tempass where CID=" & CID)
                Dim sMsg As String = "Collector ID " & CID & " is responding, so Clients where Moved Back."
                Call WriteToCollectorEvents("Clients where Moved Back!", sMsg, "INFO")
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "RevertLoad"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
    Sub GetData()
        Try
            If ConnectDB() = 0 Then
                Dim SQL As String = "SELECT * FROM view_collector_list"
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                Dim CID As Long = 0
                Dim COLNAME As String = ""
                Dim COLSTATUS As String = ""
                Dim COLLUD As String = ""
                Dim COLCL As Long = 0
                Dim lDateDiff As Long = 0
                Call CatchDebug("RegularInterval=" & RegularInterval, "modMain.GetData")
                Call CatchDebug("xTimesInterval" & xTimesInterval, "modMain.GetData")
                Dim MaxDiff As Long = (RegularInterval * xTimesInterval)
                Call CatchDebug("MaxDiff=" & MaxDiff, "modMain.GetData")
                RS = CMD.ExecuteReader
                While RS.Read
                    If Not IsDBNull(RS("id")) Then CID = RS("id")
                    If Not IsDBNull(RS("servername")) Then COLNAME = RS("servername")
                    Call CatchDebug("COLNAME=" & COLNAME, "modMain.GetData")
                    If Not IsDBNull(RS("status")) Then COLSTATUS = RS("status")
                    Call CatchDebug("status=" & COLSTATUS, "modMain.GetData")
                    If Not IsDBNull(RS("lud")) Then COLLUD = RS("lud")
                    Call CatchDebug("lud=" & COLLUD, "modMain.GetData")
                    If Not IsDBNull(RS("cl")) Then COLCL = RS("cl")
                    Call CatchDebug("cl=" & COLCL, "modMain.GetData")
                    lDateDiff = DateDiff(DateInterval.Minute, CDate(COLLUD), Now)
                    Call CatchDebug("lDateDiff=" & lDateDiff, "modMain.GetData")
                    If lDateDiff > maxdiff Then
                        Call CatchDebug(COLNAME & " collector has not responded in the past " & lDateDiff & " minutes.", "modMain.GetData")
                        Console.WriteLine(COLNAME & " collector has not responded in the past " & lDateDiff & " minutes.")
                        If COLCL > 0 Then Call MoveLoad(CID, COLNAME)
                    Else
                        If WasMoved(CID) Then RevertLoad(CID)
                    End If
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "GetData"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
    Sub INIT()
        Dim DidExist As Boolean = False
        GetCommand("forcerevert", "bool", FORCE_REVERT)
        GetCommand("forcemove", "bool", FORCE_MOVE)
        FORCE_CID = CInt(GetCommand("collectorid", "int", FORCE_CID_Exists))
        If Not FORCE_REVERT And Not FORCE_MOVE Then
            xTimesInterval = CLng(GetCommand("xtime", "int", DidExist))
            If Not DidExist Then xTimesInterval = CLng(System.Configuration.ConfigurationManager.AppSettings("xTimesInterval"))
            RegularInterval = CLng(GetCommand("interval", "int", DidExist))
            If Not DidExist Then Call CommandMssing("interval")
        End If
        MyLogFile = System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
        CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
        DEBUG_LOGFILE = System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
        DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
        DefaultCollector = CLng(System.Configuration.ConfigurationManager.AppSettings("DEFAULTCOLLECTOR"))
        Dim Obj As New BSRegistry
        MYCONNSTRING = Obj.GetDBSettings
    End Sub
    Sub ForceIT()
        If FORCE_CID_Exists Then
            If FORCE_REVERT Then
                Call RevertLoad(FORCE_CID)
            End If
            If FORCE_MOVE Then
                Call MoveLoad(FORCE_CID)
            End If
        Else
            Call CommandMssing("collectorid")
        End If
    End Sub
    Sub Main()
        Call CatchDebug("Starting INIT Sub", "modMain.Main")
        Call INIT()
        If Not FORCE_REVERT And Not FORCE_MOVE Then
            Call CatchDebug("Starting GetData Sub", "modMain.Main")
            Call GetData()
        Else
            Call CatchDebug("Starting ForceIT Sub", "modMain.Main")
            Call ForceIT()
        End If
        Call CatchDebug("Application Exiting", "modMain.Main")
    End Sub
    Sub CommandMssing(ByVal sCMD As String)
        Console.WriteLine(sCMD & " parameter is missing, please set!")
        End
    End Sub
End Module
