Imports BSSM_Pinger.BurnSoft.GlobalClasses
Imports System.Net.NetworkInformation
Imports System
Imports System.Data
Imports mysql.Data.MySqlClient
Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Xml.XPath
Imports System.Configuration
Imports System.Windows.Forms
Imports System.Text
Module modMain
    Dim ServerName As String
    Dim ServerID As Long
    Dim sIP As String
    Dim Repeatx As Long
    Dim TSID As Long
    Dim CurStatus As Integer
    Dim IsWarned As Boolean
    Public PING_TIMEOUT As Long
    Public UseTrace As Boolean
    Function GetTSID(ByVal SID As Long) As Long
        'NOTE: GetTSID function will get the latestest greatest Time Stampe ID
        '       for the server that it is currently working.  This way it
        '       can insert the results under the right timestamp.
        Dim lAns As Long = 0
        Try
            If ConnectDB() = 0 Then
                Dim SQL As String = "SELECT max(id) as id from results_timestamp where sid=" & SID
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    If Not IsDBNull(RS("id")) Then lAns = CLng(RS("id"))
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "GetTSID"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return lAns
    End Function
    Function IIPAC(ByVal SID As Long) As Boolean
        'NOTE: IIPAC Function will check to see if the Ignore IP Address Change is set
        '       true on this server, this will help determine if the CS is set to up
        '       or warning.
        Dim bAns As Boolean = False
        Try
            If ConnectDB() = 0 Then
                Dim SQL As String = "SELECT IIPAC from list_servers where id=" & SID
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    bAns = INT_TO_BOOL(RS("IIPAC"))
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "IIPAC"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return bAns
    End Function
    Sub PingThis(ByVal Host As String, ByRef IPAddress As String, ByRef lBytes As Long, ByRef lRTrip As Long, ByRef lTTL As Long, ByRef IsCaptSuccess As Boolean, Optional ByVal Timeout As Long = 1500, Optional ByRef SwitchHost As Boolean = False, Optional ByVal ISIP As Boolean = False)
        Dim instance As New Ping
        Dim Results As PingReply
        Try
            Results = instance.Send(Host, PING_TIMEOUT)

            If Not ISIP Then
                IPAddress = Results.Address.ToString
                SwitchHost = False
            Else
                IPAddress = Host
                SwitchHost = True
            End If
            lBytes = 0
            lRTrip = 0
            lTTL = 0
            IsCaptSuccess = False
            Select Case Results.Status
                Case IPStatus.Success
                    lBytes = Results.Buffer.Length
                    lRTrip = Results.RoundtripTime
                    lTTL = Results.Options.Ttl
                    IsCaptSuccess = True
                    Console.WriteLine("Reply from " & IPAddress & ": Bytes=" & lBytes & _
                    " time=" & lRTrip & "ms TTL=" & lTTL)
                Case IPStatus.TtlExpired
                    Console.WriteLine("TTL Expired in Transit.")
                Case IPStatus.BadDestination
                    Console.WriteLine("Bad Destination.")
                Case Else
                    Console.WriteLine("Request timed out.")
            End Select

            'If Results.Status = IPStatus.Success Then
            ' If Not ISIP Then
            ' IPAddress = Results.Address.ToString
            ' SwitchHost = False
            ' Else
            ' IPAddress = Host
            ' SwitchHost = True
            ' End If
            ' lBytes = Results.Buffer.Length
            ' lRTrip = Results.RoundtripTime
            ' lTTL = Results.Options.Ttl
            ' IsCaptSuccess = True
            ' Console.WriteLine("Reply from " & IPAddress & ": Bytes=" & lBytes & _
            ' " time=" & lRTrip & "ms TTL=" & lTTL)
            ' Else
            ' If Not ISIP Then
            ' IPAddress = Results.Address.ToString
            ' SwitchHost = False
            ' Else
            ' IPAddress = Host
            ' SwitchHost = True
            ' End If
            ' lBytes = 0
            ' lRTrip = 0
            ' lTTL = 0
            ' IsCaptSuccess = False
            ' Console.WriteLine("Request timed out.")
            ' End If
        Catch ex As Exception
            Select Case Err.Number
                Case 5
                    Dim lMsg As String = "Host Name Did not Resolve. Trying IP Address."
                    Dim sMsg As String = "Host Name Did not Resolve."
                    Dim mSev As String = "WARNING"
                    If Not EventExists(ServerID, sMsg, lMsg, mSev) Then Call AddEvent(ServerID, sMsg, lMsg, mSev)
                    Call PingThis(sIP, IPAddress, lBytes, lRTrip, lTTL, IsCaptSuccess, 1500, SwitchHost, True)
                Case 91
                    IPAddress = sIP
                    lBytes = 0
                    lRTrip = 0
                    lTTL = 0
                    IsCaptSuccess = False
                    Console.WriteLine("Request timed out.")
                Case Else
                    Dim strForm As String = "modMain"
                    Dim strSubFunc As String = "PingThis"
                    Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                    sMsg &= Chr(13) & vbTab & "Host: " & Host
                    sMsg &= Chr(13) & vbTab & "IP Address: " & IPAddress
                    sMsg &= Chr(13) & vbTab & "Is Pinging IP: " & ISIP
                    Call CatchError(sMsg, strForm & "." & strSubFunc)
                    IPAddress = sIP
                    lBytes = 0
                    lRTrip = 0
                    lTTL = 0
                    IsCaptSuccess = False
                    Console.WriteLine("Request timed out.")
            End Select
        End Try
        instance = Nothing
        Results = Nothing
    End Sub
    Sub AddEvent(ByVal ServerID As Long, ByVal sMsg As String, ByVal lMsg As String, ByVal mSev As String)
        Dim SQL As String = "INSERT INTO events_general(SID,shrtEv,lngEv,Sev) VALUES(" & ServerID & _
                            ",'" & sMsg & "','" & lMsg & "','" & mSev & "')"
        Call ConnExe(SQL)
        Call CatchDebug("SQL STATEMENT: " & SQL, "modMain.AddEvent")
    End Sub
    Function ISNetDevice(ByVal sIP As String, ByVal IPDevice As String) As Boolean
        'This is used to determine that the IP Address that is returned from the 
        ' Normal Device Ping is not return a device/router that is listed in
        'the trace route results.  
        Dim bAns As Boolean = False
        Try
            If ConnectDB() = 0 Then
                Dim SQL As String = "SELECT * from results_trace where SID=" & _
                                    ServerID & " and ipaddr ='" & sIP & "'"
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                Dim sResults As String = ""
                While RS.Read
                    sResults = RS("ipaddr")
                    If sResults = IPDevice Then
                        bAns = False
                    Else
                        bAns = True
                        Exit While
                    End If
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
        Catch ex As Exception
            Call CatchError(ex.Message.ToString, "modMain.IsNetdevice")
        End Try
        Return bAns
    End Function
    Sub PingTraceDevices(ByVal SID As Long, Optional ByRef DownAt As String = "Not Listed")
        If ConnectDB() = 0 Then
            Dim SQL As String = "SELECT * from results_trace where SID=" & _
                                    SID & " order by hopno asc"
            Dim CMD As New MySqlCommand(SQL, Conn)
            Dim RS As MySqlDataReader
            RS = CMD.ExecuteReader
            Dim DeviceIP As String = ""
            Call CatchDebug("Checking Trace Results for " & SID, "modMain.PingTraceDevices")
            While RS.Read
                DeviceIP = RS("ipaddr")
                If Not DeviceISUp(DeviceIP) Then
                    DownAt = DeviceIP
                    Call CatchDebug(SID & " down at " & DownAt, "modMain.PingTraceDevices")
                    Exit While
                End If
            End While
            RS.Close()
            RS = Nothing
            CMD = Nothing
            Conn.Close()
            Conn = Nothing
        End If
    End Sub
    Function DeviceISUp(ByVal Host As String) As Boolean
        Dim bAns As Boolean = False
        Try
            Dim i As Integer = 0
            Dim SQL As String = ""
            Dim IPAddress As String = ""
            Dim lBytes As Long = 0
            Dim lRTrip As Long = 0
            Dim lTTL As Long = 0
            Dim iRec As Integer = 0
            Dim iLost As Integer = 0
            Dim RoundTrip_Min As Integer = 0
            Dim RoundTrip_Max As Integer = 0
            Dim RoundTrip_Avg As Integer = 0
            Dim Uptime As Double = 0
            Dim IsCaptSuc As Boolean
            Dim SwitchHost As Boolean = False
            Dim ISIP As Boolean = False
            IsWarned = False
            For i = 1 To Repeatx
                SwitchHost = False
                Call PingThis(Host, IPAddress, lBytes, lRTrip, lTTL, IsCaptSuc, 1500, SwitchHost, ISIP)
                If IsCaptSuc Then
                    iRec += 1
                Else
                    iLost += 1
                End If
                If SwitchHost Then
                    Host = sIP
                    ISIP = True
                End If
            Next i
            RoundTrip_Min = GetMinMs(TSID)
            RoundTrip_Max = GetMaxMs(TSID)
            RoundTrip_Avg = GetAvgMs(TSID)
            Uptime = (iRec / Repeatx) * 100

            If Uptime > 25 Then
                bAns = True
            ElseIf Uptime > 0 And Uptime < 25 Then
                bAns = True
            ElseIf Uptime = 0 Then
                bAns = False
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "DeviceISUp"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return bAns
    End Function
    Sub DoPing(ByVal Host As String)
        Dim i As Integer = 0
        Dim SQL As String = ""
        Dim IPAddress As String = ""
        Dim lBytes As Long = 0
        Dim lRTrip As Long = 0
        Dim lTTL As Long = 0
        Dim iRec As Integer = 0
        Dim iLost As Integer = 0
        Dim RoundTrip_Min As Integer = 0
        Dim RoundTrip_Max As Integer = 0
        Dim RoundTrip_Avg As Integer = 0
        Dim Uptime As Double = 0
        Dim IsCaptSuc As Boolean
        Dim SwitchHost As Boolean = False
        Dim ISIP As Boolean = False
        IsWarned = False
        Dim onIIPAC As Boolean = IIPAC(ServerID)
        Try
            For i = 1 To Repeatx
                SwitchHost = False
                Call PingThis(Host, IPAddress, lBytes, lRTrip, lTTL, IsCaptSuc, 1500, SwitchHost, ISIP)
                If IsCaptSuc Then
                    iRec += 1
                Else
                    iLost += 1
                End If
                If SwitchHost Then
                    Host = sIP
                    ISIP = True
                End If
                SQL = "INSERT INTO results_ping_raw(TSID,SIP,MyBytes,MyTime,MyTTL) VALUES(" & _
                        TSID & ",'" & IPAddress & "'," & lBytes & "," & lRTrip & _
                        "," & lTTL & ")"
                Call ConnExe(SQL)
            Next i
            RoundTrip_Min = GetMinMs(TSID)
            RoundTrip_Max = GetMaxMs(TSID)
            RoundTrip_Avg = GetAvgMs(TSID)
            Uptime = (iRec / Repeatx) * 100
            If IPAddress <> sIP And Not onIIPAC Then
                'Insert a warning in the events section that the IP Address has changed.
                Dim lMsg As String = "IP Adress Changed from " & sIP & " to " & _
                        IPAddress
                Dim sMsg As String = "IP Address Changed!"
                Dim mSev As String = "WARNING"
                If Not EventExists(ServerID, sMsg, lMsg, mSev) Then
                    Call AddEvent(ServerID, sMsg, lMsg, mSev)
                End If
                IsWarned = True
            End If
            '================================================================
            'NOTE: CurrentStatus Translation
            '       This marks the number system used for the Current Statu (CS) column
            '       If you add more then the MySQL Views will also need to be updated with the 
            '       changes.
            '
            '       0 = Down or unreachable
            '       1 = UP
            '       2 = IP Change (warning type status)
            '       3 = Disabled
            '       4 = Slow Response (warning type status)
            '       5 = Deleted
            '================================================================
            SQL = "INSERT INTO results_ping_stats (TSID,Packets_Sent,Packets_Rec,Packets_Lost,RoundTrip_Min,RoundTrip_Max,RoundTrip_Avg,uptime) VALUES(" & _
                    TSID & "," & Repeatx & "," & iRec & "," & iLost & "," & RoundTrip_Min & "," & _
                    RoundTrip_Max & "," & RoundTrip_Avg & "," & Uptime & ")"
            Call ConnExe(SQL)
            Call CatchDebug(ServerName & " CurrentStatus " & CurStatus, "modMain.DoPing")
            If Uptime > 25 Then
                If Not IsWarned Then
                    SQL = "UPDATE list_servers set CS=1,IsReported=0 where ID=" & ServerID
                Else
                    SQL = "UPDATE list_servers set CS=2,IsReported=0 where ID=" & ServerID
                End If
                Call ConnExe(SQL)
                If CurStatus = 0 Then Call AddEvent(ServerID, "Device is on the network now.", "Device is on the network now.", "INFO")
                SQL = "UPDATE results_timestamp set ls=1 where ID=" & TSID
                Call ConnExe(SQL)
            ElseIf Uptime > 0 And Uptime < 25 Then
                Call AddEvent(ServerID, "Slow Response", "Slow Response, Response is " & Uptime & "% for TSID " & TSID, "WARNING")
                'Updating the status for the interface 
                SQL = "UPDATE list_servers set CS=4,IsReported=0 where ID=" & ServerID
                Call ConnExe(SQL)
                'Setting the Last Status to Up even if it is slow
                SQL = "UPDATE results_timestamp set ls=1 where ID=" & TSID
                Call ConnExe(SQL)
                If CurStatus = 0 Then Call AddEvent(ServerID, "Device is on the network now.", "Device is on the network now.", "INFO")
            ElseIf Uptime = 0 Then
                If Not IsWarned Then
                    SQL = "UPDATE list_servers set CS=0 where ID=" & ServerID
                Else
                    SQL = "UPDATE list_servers set CS=2 where ID=" & ServerID
                End If
                Call ConnExe(SQL)
                If CurStatus <> 0 Then
                    CatchDebug("Use Tracing: " & UseTrace, "modMain.DoPing")
                    If Not UseTrace Then
                        If Not EventExists(ServerID, "Device is down!", "Device is unreachable!", "ERROR") Then
                            Call AddEvent(ServerID, "Device is down!", "Device is unreachable!", "ERROR")
                        End If
                    Else
                        Dim DownAt As String = ""
                        Dim lmsg As String = ""
                        Call PingTraceDevices(ServerID, DownAt)
                        lmsg = "Device is down. Down at " & DownAt
                        CatchDebug("Tracing Status: " & lmsg, "modMain.DoPing")
                        Call AddEvent(ServerID, "Device is down!", lmsg, "ERROR")
                    End If
                End If
                SQL = "UPDATE results_timestamp set ls=0 where ID=" & TSID
                Call ConnExe(SQL)
                End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "DoPing"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            sMsg &= Chr(13) & "On device " & Host
            If Err.Number <> 57 Then Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
    Sub CommandMssing(ByVal sCMD As String)
        Console.WriteLine(sCMD & " parameter is missing, please set!")
        End
    End Sub
    Sub INIT()
        Dim DidExist As Boolean = False
        '----------Required Parameters------------------
        Repeatx = CLng(GetCommand("try", "int", DidExist))
        If Not DidExist Then Call CommandMssing("try")
        ServerID = CLng(GetCommand("sid", "int", DidExist))
        If Not DidExist Then Call CommandMssing("SID")
        ServerName = GetCommand("server", "string", DidExist)
        If Not DidExist Then Call CommandMssing("Server")
        sIP = GetCommand("ip", "string", DidExist)
        If Not DidExist Then Call CommandMssing("ip")
        '----------End Required Parameters------------------
        'This was setup to ad the option of keeping up with the
        'current status that is listed in the database.  This was done
        'to determine if it need to check it multiple times or not.
        UseTrace = CBool(System.Configuration.ConfigurationManager.AppSettings("USETRACE"))
        CurStatus = Int(GetCommand("status", "int", DidExist))
        If Not DidExist Then CurStatus = 1
        Dim sUseTrace As String = GetCommand("usetrace", "string", DidExist)
        If DidExist Then UseTrace = True
        MyLogFile = System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
        CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
        PING_TIMEOUT = CLng(System.Configuration.ConfigurationManager.AppSettings("PING_TIMEOUT"))
        DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
        DEBUG_LOGFILE = System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
        Dim Obj As New BSRegistry
        MYCONNSTRING = Obj.GetDBSettings
    End Sub
    Sub Main()
        Call INIT()
        Dim Sql As String = "INSERT INTO results_timestamp (SID) VALUES(" & ServerID & ")"
        Call ConnExe(Sql)
        TSID = GetTSID(ServerID)
        Call DoPing(ServerName)
    End Sub
End Module
