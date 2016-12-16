Imports System.Net.NetworkInformation
Imports System
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Xml.XPath
Imports System.Configuration
Imports System.Windows.Forms
Imports System.Text
Imports System.Diagnostics
Imports BSSM_PingManager.BurnSoft.GlobalClasses
Module modMain
    Public Throttle As Long
    Public IsThrot As Boolean
    Public PingXTimes As Long
    Public Pids As String
    Public PID As String
    Public DEBUG As Boolean
    Public DEBUG_LOGFILE As String
    Public TotalCount As Long
    Public DataLimits As Long
    Public DataPull As String
    Public XMLFILENAME As String
    Public ModDataCollectorID As Long
    Public CID As Long
    Public ISHelp As Boolean
    Public IsVer As Boolean
    Public IsAppSet As Boolean
    Public HasTracing As Boolean
    Public DONOTRUN As Boolean
    Public AppKey As String
    Public AppValue As String
    Public ChangeASet As Boolean
    Public ModDB As Boolean
    Public DUMPLISTONLY As Boolean
    Sub Main()
        DONOTRUN = False
        Dim DidExist As Boolean
        ISHelp = CBool(GetCommand("help", "bool", DidExist))
        If ISHelp Then Call ShowHelp()
        If DidExist Then DONOTRUN = True
        IsVer = CBool(GetCommand("version", "bool", DidExist))
        If IsVer Then Call ShowVer()
        If DidExist Then DONOTRUN = True
        DUMPLISTONLY = CBool(GetCommand("dumplist", "bool", DidExist))
        If DUMPLISTONLY Then Call INIT() : Call DumpXML()
        If DidExist Then DONOTRUN = True
        ModDataCollectorID = CLng(GetCommand("id", "int", DidExist))
        If DidExist Then Call MCID(ModDataCollectorID)
        If DidExist Then DONOTRUN = True
        IsAppSet = CBool(GetCommand("showappsettings", "bool", DidExist))
        If IsAppSet Then Call ShowAppSettings()
        If DidExist Then DONOTRUN = True
        ChangeASet = CBool(GetCommand("mod", "bool", DidExist))
        If ChangeASet Then
            AppKey = GetCommand("key", "string", DidExist)
            If Len(AppKey) = 0 Then Console.WriteLine("Missing Key") : Exit Sub
            AppValue = GetCommand("value", "string", DidExist)
            If Len(AppValue) = 0 Then Console.WriteLine("Missing Value") : Exit Sub
            Call Header()
            Call ChangeAppSettings(AppKey, AppValue)
        End If
        If DidExist Then DONOTRUN = True
        ModDB = CBool(GetCommand("moddb", "bool", DidExist))
        If DidExist Then DONOTRUN = True
        If ModDB Then
            Dim sServer As String = GetCommand("server", "string", DidExist)
            If Len(sServer) = 0 Then Console.WriteLine("Missing Server Name") : Exit Sub
            Dim sDB As String = GetCommand("db", "string", DidExist)
            If Len(sDB) > 0 Then
                Call SetDBServer(sServer)
            Else
                Call SetDBServer(sServer, , , sDB)
            End If
        End If
        If Not DONOTRUN Then
            Call INIT()
            If IsEnabled(CID) Then
                Dim returnValue As Process() = Process.GetProcessesByName("BSSM_PingManager")
                If returnValue.Length <= 1 Then
                    'Set in the app.config, you can have the list pulled from the databse or
                    'have it dump the database to an xml file and read locally.
                    'The XML Option was created due to possible connection timeouts based
                    'on where the Collector is located at.  The Dump will also reduce the 
                    'the amount of time it takes to run through the server list.
                    Select Case UCase(DataPull)
                        Case "DB"
                            TotalCount = GetServerTotal()
                            If DataLimits > TotalCount Then
                                Call DoList()
                            Else
                                Dim iStart As Long = 0
                                Dim Iend As Long = DataLimits
                                Dim i As Long = 0
                                Dim ie As Long = TotalCount
                                For i = 0 To ie
                                    Call DoListLimited(iStart, Iend)
                                    iStart += DataLimits
                                    If DataLimits < TotalCount Then
                                        Iend += DataLimits
                                        TotalCount -= DataLimits
                                    Else
                                        Iend = TotalCount
                                    End If
                                Next i
                            End If
                        Case "XML"
                            Call DumpXML()
                            Call ReadFile()
                    End Select
                    Call ReDoList()
                End If
            Else
                Console.WriteLine("Collector is currently Disabled!")
                Call UpdateStatus()
            End If
        End If
    End Sub
    Sub MCID(ByVal CID As Long)
        Call Header()
        Call ChangeAppSettings("DataCollectorID", CID)
    End Sub
    Public Sub ChangeAppSettings(ByVal sKey As String, ByVal sValue As String)
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Config.AppSettings.Settings.Remove(sKey)
        Config.AppSettings.Settings.Add(sKey, sValue)
        Config.Save(ConfigurationSaveMode.Modified)
        ConfigurationManager.RefreshSection("appSettings")
        Console.WriteLine(sKey & "'s new value is " & System.Configuration.ConfigurationManager.AppSettings(sKey))
    End Sub
    Sub Header()
        Console.WriteLine("BurnSoft Server Monitor Application - Ping Manager")
        Console.WriteLine(My.Application.Info.ProductName & "  " & My.Application.Info.Copyright)
        Console.WriteLine()
    End Sub
    Sub ShowVer()
        Call Header()
        Console.WriteLine(String.Format("Version {0}", Application.ProductVersion.ToString))
    End Sub
    Public Sub SetDBServer(ByVal sServer As String, Optional ByVal UID As String = "bssm", Optional ByVal PWD As String = "bs.server.mon", Optional ByVal sDB As String = "bssm")
        Call Header()
        Dim sConnection As String = ""
        sConnection = "Server=" & sServer & ";user id=" & UID & ";password=" & PWD & ";persist security info=True;database=" & sDB
        Dim Obj As New BSRegistry
        Obj.SaveDBSettings(sConnection)
        Obj = Nothing
        Console.WriteLine("New Settings: " & sConnection)
    End Sub
    Sub ShowHelp()
        Call Header()
        Console.WriteLine("/help            - Displays this information")
        Console.WriteLine("/id=<number>     - Sets the Data Collector ID in the Config file")
        Console.WriteLine("/version         - Displays Current Version")
        Console.WriteLine("/showappsettings - Show the settings for the config file")
        Console.WriteLine("/mod             - Modify Settinss")
        Console.WriteLine("/key=Name        - App Setting Name use with /mod")
        Console.WriteLine("/value=NewValue  - New App Setting Value use with /mod")
        Console.WriteLine("/moddb           - Modify/add Database Settings")
        Console.WriteLine("/server=name     - New Server Setting Value use with /moddb")
        Console.WriteLine("/db=name         - Optional New Database Name Setting Value use with /moddb")
    End Sub
    Sub ShowAppSettings()
        Call Header()
        Dim sValue As String = ""
        sValue = "DataCollectorID"
        Console.WriteLine(sValue & ": " & System.Configuration.ConfigurationManager.AppSettings(sValue))
        sValue = "Throttle"
        Console.WriteLine(sValue & ": " & System.Configuration.ConfigurationManager.AppSettings(sValue))
        sValue = "PingXTimes"
        Console.WriteLine(sValue & ": " & System.Configuration.ConfigurationManager.AppSettings(sValue))
        sValue = "DataLimits"
        Console.WriteLine(sValue & ": " & System.Configuration.ConfigurationManager.AppSettings(sValue))
        sValue = "DataPull"
        Console.WriteLine(sValue & ": " & System.Configuration.ConfigurationManager.AppSettings(sValue))
        sValue = "XMLFILENAME"
        Console.WriteLine(sValue & ": " & System.Configuration.ConfigurationManager.AppSettings(sValue))
        sValue = "DEBUG"
        Console.WriteLine(sValue & ": " & System.Configuration.ConfigurationManager.AppSettings(sValue))
        sValue = "CONSOLE"
        Console.WriteLine(sValue & ": " & System.Configuration.ConfigurationManager.AppSettings(sValue))
        sValue = "LOGFILE"
        Console.WriteLine(sValue & ": " & System.Configuration.ConfigurationManager.AppSettings(sValue))
        sValue = "BUGFILE"
        Console.WriteLine(sValue & ": " & System.Configuration.ConfigurationManager.AppSettings(sValue))
    End Sub
    Sub INIT()
        'Get Values from the app.config file
        Try
            CID = CLng(System.Configuration.ConfigurationManager.AppSettings("DataCollectorID"))
            Throttle = CLng(System.Configuration.ConfigurationManager.AppSettings("Throttle"))
            PingXTimes = CLng(System.Configuration.ConfigurationManager.AppSettings("PingXTimes"))
            MyLogFile = System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
            DEBUG_LOGFILE = System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
            CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
            DataLimits = CLng(System.Configuration.ConfigurationManager.AppSettings("DataLimits"))
            DataPull = System.Configuration.ConfigurationManager.AppSettings("DataPull")
            XMLFILENAME = System.Configuration.ConfigurationManager.AppSettings("XMLFILENAME")
            IsThrot = True
            Pids = ""
            DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
            Dim Obj As New BSRegistry
            MYCONNSTRING = Obj.GetDBSettings

        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "INIT"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
    Sub RunServer(ByVal ServerName As String, ByVal ServerID As Long, ByVal TryTime As Long, ByVal sIP As String, Optional ByVal ls As Integer = 1, Optional ByVal UseTrace As Boolean = False)
        Try
            Dim sMsg As String = " - DEBUG - "
            Dim strExec As String = Application.StartupPath & "\BSSM_Pinger.exe /server=" & ServerName & " /sid=" & ServerID & " /try=" & TryTime & " /IP=" & sIP & " /status=" & ls
            sMsg &= strExec
            If UseTrace Then sMsg &= " /usetrace"
            Call CatchDebug(sMsg, "modMain.RunServer")
            PID = Shell(strExec, AppWinStyle.NormalFocus)
            Pids &= "," & PID
            PID = 0
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "RunServer"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
    Function GetServerTotal() As Long
        Dim lAns As Long = 0
        Try
            If ConnectDB() = 0 Then
                Dim SQL As String = "SELECT count(*) as T from list_servers"
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    lAns = RS("T")
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "GetServerTotal"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return lAns
    End Function
    Sub DoList()
        On Error Resume Next
        If ConnectDB() = 0 Then
            Dim SQL As String = "SELECT * from list_servers where isenabled=1 and DoPing=1 and CID=" & CID & " order by ServerName ASC"
            Dim CMD As New MySqlCommand(SQL, Conn)
            Dim RS As MySqlDataReader
            RS = CMD.ExecuteReader
            Dim x As Integer = 0
            Dim P As Integer = 0
            Dim i As Integer = 0
            Dim strSplit() As String
            Dim PidBound As Long = 0
            Dim CurPid As Long = 0
            Dim strServer As String = ""
            Dim sIp As String
            Dim lSID As Long = 0
            Dim lsCount As Long = 0
            Dim lastServer As String = ""
            Dim lStat As Integer = 0
            While RS.Read
                strServer = RS("ServerName")
                lSID = CLng(RS("id"))
                sIp = RS("ServerIPAddress")
                lStat = RS("cs")
                If LCase(lastServer) <> LCase(strServer) Then
                    Call RunServer(strServer, lSID, PingXTimes, sIp, lStat)
                    If x >= Throttle + 1 Then
                        strSplit = Split(Pids, ",")
                        PidBound = UBound(strSplit)
                        For i = 1 To PidBound
                            If Len(strSplit(i)) > 0 Then
                                CurPid = strSplit(i)
                                If Not System.Diagnostics.Process.GetProcessById(CurPid).HasExited Then
                                    System.Diagnostics.Process.GetProcessById(CurPid).WaitForExit()
                                    Pids = Replace(Pids, CurPid, "")
                                End If
                            End If
                        Next
                        x = 0
                        Pids = ""
                    Else
                        x += 1
                    End If
                    P += 1
                    lastServer = strServer
                    lsCount = 0
                Else
                    lsCount += 1
                    If lsCount = 10 Then
                        Dim strForm As String = "modMain"
                        Dim strSubFunc As String = "DoList"
                        Dim sMsg As String = "Looped on " & strServer & ":" & sIp & ":" & lSID
                        Call CatchError(sMsg, strForm & "." & strSubFunc)
                        Exit While
                    End If
                End If
            End While
            RS.Close()
            RS = Nothing
            CMD = Nothing
            Conn.Close()
            Conn = Nothing
            Call UpdateStatus()
        End If
    End Sub
    Sub UpdateStatus()
        If CID = 0 Then
            Call CatchDebug("UPDATEING LASTRUN FOR MAIN SERVER.", "modMain.ReadFIle")
            Call ConnExe("UPDATE self_lastrun set LastRun=CURRENT_TIMESTAMP")
        Else
            Call CatchDebug("UPDATEING LASTRUN FOR COLLECTOR.", "modMain.ReadFIle")
            Call ConnExe("UPDATE list_collectors set LUD=CURRENT_TIMESTAMP where id=" & CID)
        End If
    End Sub
    Sub DoListLimited(ByVal iStart As Long, ByVal iEnd As Long)
        On Error Resume Next
        If ConnectDB() = 0 Then
            Dim SQL As String = "SELECT * from list_servers where isenabled=1 and DoPing=1 limit " & iStart & "," & iEnd & ";"
            Call CatchDebug(SQL, "modMain.DoListLimited")
            Dim CMD As New MySqlCommand(SQL, Conn)
            Dim RS As MySqlDataReader
            RS = CMD.ExecuteReader
            Dim x As Integer = 0
            Dim P As Integer = 0
            Dim i As Integer = 0
            Dim strSplit() As String
            Dim PidBound As Long = 0
            Dim CurPid As Long = 0
            Dim strServer As String = ""
            Dim sIp As String
            Dim lSID As Long = 0
            Dim lsCount As Long = 0
            Dim lastServer As String = ""
            Dim lStat As Integer = 0
            While RS.Read
                strServer = RS("ServerName")
                lSID = CLng(RS("id"))
                sIp = RS("ServerIPAddress")
                lStat = RS("cs")
                If LCase(lastServer) <> LCase(strServer) Then
                    Call RunServer(strServer, lSID, PingXTimes, sIp, lStat)
                    If x >= Throttle + 1 Then
                        strSplit = Split(Pids, ",")
                        PidBound = UBound(strSplit)
                        For i = 1 To PidBound
                            If Len(strSplit(i)) > 0 Then
                                CurPid = strSplit(i)
                                If Not System.Diagnostics.Process.GetProcessById(CurPid).HasExited Then
                                    System.Diagnostics.Process.GetProcessById(CurPid).WaitForExit()
                                    Pids = Replace(Pids, CurPid, "")
                                End If
                            End If
                        Next
                        x = 0
                        Pids = ""
                    Else
                        x += 1
                    End If
                    P += 1
                    lastServer = strServer
                    lsCount = 0
                Else
                    lsCount += 1
                    If lsCount = 10 Then
                        Dim strForm As String = "modMain"
                        Dim strSubFunc As String = "DoList"
                        Dim sMsg As String = "Looped on " & strServer & ":" & sIp & ":" & lSID
                        Call CatchError(sMsg, strForm & "." & strSubFunc)
                        Exit While
                    End If
                End If
            End While
            RS.Close()
            RS = Nothing
            CMD = Nothing
            Conn.Close()
            Conn = Nothing
            Call ConnExe("UPDATE self_lastrun set LastRun=CURRENT_TIMESTAMP")
        End If
    End Sub
    Sub DumpXML()
        If ConnectDB() = 0 Then
            Dim SQL As String = "SELECT * from list_servers where isenabled=1 and DoPing=1 and CID=" & CID & " order by ServerName ASC"
            Dim CMD As New MySqlCommand
            Dim RS As New MySqlDataAdapter
            Dim DSID As New DataSet
            CMD.Connection = Conn
            CMD.CommandText = SQL
            RS.SelectCommand = CMD
            RS.Fill(DSID, "ServerList")
            DSID.WriteXml(XMLFILENAME)
            RS = Nothing
            CMD = Nothing
            Conn.Close()
            Conn = Nothing
        Else
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "DumpXML"
            Dim sMsg As String = " - DBERROR - Unabled to Connect to the database, using local XML File."
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End If
    End Sub
    Sub ReadFile()
        On Error Resume Next
        Dim doc As New XmlDocument
        doc.Load(XMLFILENAME)
        Dim elemList As XmlNodeList = doc.GetElementsByTagName("ServerList")
        Dim x As Integer = 0
        Dim P As Integer = 0
        Dim il As Integer = 0
        Dim i As Integer = 0
        Dim strSplit() As String
        Dim PidBound As Long = 0
        Dim CurPid As Long = 0
        Dim strServer As String = ""
        Dim sIp As String
        Dim lSID As Long = 0
        Dim lsCount As Long = 0
        Dim lastServer As String = ""
        Dim SQL As String = ""
        Dim lStat As Integer = 0
        Call CatchDebug(elemList.Count & " devices listed in database", "modMain.ReadFIle")
        For il = 0 To elemList.Count - 1
            strServer = GetXMLNode(elemList(il).Item("ServerName"))
            sIp = GetXMLNode(elemList(il).Item("ServerIPAddress"))
            lSID = CLng(GetXMLNode(elemList(il).Item("ID")))
            lStat = CLng(GetXMLNode(elemList(il).Item("CS")))
            HasTracing = INT_TO_BOOL(GetXMLNode(elemList(il).Item("DoTrace")))
            Call RunServer(strServer, lSID, PingXTimes, sIp, lStat, HasTracing)
            If x >= Throttle + 1 Then
                strSplit = Split(Pids, ",")
                PidBound = UBound(strSplit)
                For i = 1 To PidBound
                    If Len(strSplit(i)) > 0 Then
                        CurPid = strSplit(i)
                        If Not System.Diagnostics.Process.GetProcessById(CurPid).HasExited Then
                            System.Diagnostics.Process.GetProcessById(CurPid).WaitForExit()
                            Pids = Replace(Pids, CurPid, "")
                        End If
                    End If
                Next
                x = 0
                Pids = ""
            Else
                x += 1
            End If
            P += 1
        Next il
        Call CatchDebug("CID: " & CID, "modMain.ReadFIle")
        Call UpdateStatus()
    End Sub
    Function WasDownBefore(ByVal SID As Long) As Boolean
        Dim bAns As Boolean = False
        Try
            If ConnectDB() = 0 Then
                Dim SQL As String = "SELECT ls from results_timestamp where SID=" & SID & " order by DTID DESC limit 0, 2"
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                Dim i As Integer = 1
                Dim UpLastPing As Boolean = False
                Dim UpPingBeforeLast As Boolean = False
                Dim LastStat As Integer = 0
                While RS.Read()
                    LastStat = RS("ls")
                    If i = 1 Then If LastStat = 1 Then UpLastPing = True
                    If i = 2 Then If LastStat = 1 Then UpPingBeforeLast = True
                    i += 1
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                If Not UpLastPing Then If UpPingBeforeLast Then bAns = True
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "WasDownBefore"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return bAns
    End Function
    Sub ReDoList()
        On Error Resume Next
        If ConnectDB() = 0 Then
            Dim SQL As String = "SELECT * from list_servers where isenabled=1 and DoPing=1 and CS=0 order by ServerName ASC"
            Dim CMD As New MySqlCommand(SQL, Conn)
            Dim RS As MySqlDataReader
            RS = CMD.ExecuteReader
            Dim x As Integer = 0
            Dim P As Integer = 0
            Dim i As Integer = 0
            Dim strSplit() As String
            Dim PidBound As Long = 0
            Dim CurPid As Long = 0
            Dim strServer As String = ""
            Dim sIp As String
            Dim lSID As Long = 0
            Dim lsCount As Long = 0
            Dim lastServer As String = ""
            Dim lStat As Integer = 0

            While RS.Read
                strServer = RS("ServerName")
                lSID = CLng(RS("id"))
                sIp = RS("ServerIPAddress")
                lStat = RS("cs")
                HasTracing = INT_TO_BOOL(RS("DoTrace"))
                If LCase(lastServer) <> LCase(strServer) Then
                    'Added the wasdownbefore function to keep it from adding multi values
                    'on something that has been down ahile
                    If WasDownBefore(lSID) Then
                        Call RunServer(strServer, lSID, PingXTimes, sIp, lStat, HasTracing)
                        If x >= Throttle + 1 Then
                            strSplit = Split(Pids, ",")
                            PidBound = UBound(strSplit)
                            For i = 1 To PidBound
                                If Len(strSplit(i)) > 0 Then
                                    CurPid = strSplit(i)
                                    If Not System.Diagnostics.Process.GetProcessById(CurPid).HasExited Then
                                        System.Diagnostics.Process.GetProcessById(CurPid).WaitForExit()
                                        Pids = Replace(Pids, CurPid, "")
                                    End If
                                End If
                            Next
                            x = 0
                            Pids = ""
                        Else
                            x += 1
                        End If
                        P += 1
                        lastServer = strServer
                        lsCount = 0
                    End If
                Else
                    lsCount += 1
                    If lsCount = 10 Then
                        Dim strForm As String = "modMain"
                        Dim strSubFunc As String = "ReDoList"
                        Dim sMsg As String = "Looped on " & strServer & ":" & sIp & ":" & lSID
                        Call CatchError(sMsg, strForm & "." & strSubFunc)
                        Exit While
                    End If
                End If
            End While
            RS.Close()
            RS = Nothing
            CMD = Nothing
            Conn.Close()
            Conn = Nothing
        End If
    End Sub
End Module
