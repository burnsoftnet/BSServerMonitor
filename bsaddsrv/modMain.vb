Imports bsaddsrv.BurnSoft.GlobalClasses
Imports System.Diagnostics
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Net.NetworkInformation
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms

Module modMain
    Public DEBUG As Boolean
    Public DEBUG_LOGFILE As String
    Public MaxDays As Long
    Public SP_ADDSRV As String
    Public SRV_NAME As String
    Public SRV_DISPLAYNAME As String
    Public SRV_IP As String
    Public SRV_TYPE As String
    Public SRV_ENABLED As Boolean
    Public SRV_YESTOALL As Boolean
    Public SRV_COLLECTORID As Long
    Public sConn As String
    Public ISHelp As Boolean
    Public IsVer As Boolean
    Public IsAppSet As Boolean
    Public DONOTRUN As Boolean
    Public AppKey As String
    Public AppValue As String
    Public ChangeASet As Boolean
    Public ModDB As Boolean
    Public DODELETE As Boolean
    Public DODELETE_SID As Long
    Public DOSEARCH As Boolean
    Public DOSEARCH_NAME As String
    Sub INIT_lite()
        MyLogFile = System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
        DEBUG_LOGFILE = System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
        CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
        DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
        Dim ObjR As New BSRegistry
        sConn = ObjR.GetDBSettings
    End Sub
    Sub INIT()
        Try
            Dim DidExist As Boolean = False
            Dim instance As New Ping
            Dim Results As PingReply
            SRV_NAME = GetCommand("server", "string", DidExist)
            SRV_DISPLAYNAME = GetCommand("display", "string", DidExist)
            If Not DidExist Then SRV_DISPLAYNAME = SRV_NAME
            SRV_TYPE = GetCommand("type", "string", DidExist)
            If Not DidExist Then SRV_TYPE = "server"
            SRV_ENABLED = CBool(GetCommand("enabled", "bool", DidExist))
            If Not DidExist Then SRV_ENABLED = True
            SRV_IP = GetCommand("ip", "string", DidExist)
            If SRV_ENABLED Then
                Results = instance.Send(SRV_NAME, 1500)
                SRV_IP = Results.Address.ToString
            End If
            SRV_YESTOALL = CBool(GetCommand("y", "bool", DidExist))
            If Not DidExist Then SRV_YESTOALL = False
            SRV_COLLECTORID = CLng(GetCommand("cid", "int", DidExist))
            If Not DidExist Then
                Dim objgs As New BSGlobalFunctions
                SRV_COLLECTORID = objgs.GetLowestCollector
            End If
        Catch ex As Exception
            Dim ssMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(ssMsg, "frmAdd.INIT")
            Console.WriteLine("Missing Server name")
            Application.ExitThread()
        End Try
    End Sub
    Sub DeleteMe()
        Dim SQL As String = "UPDATE list_servers set IsEnabled=0, CS=5 where ID=" & DODELETE_SID
        Dim Obj As New BSDatabase
        Obj.MYCONNSTRING = sConn
        Obj.ConnExe(SQL)
        Console.WriteLine(DODELETE_SID & " was marked as deleted.")
    End Sub
    Sub ProccessData()
        Dim sMsg As String = ""
        If Len(SRV_NAME) > 0 Then
            Console.WriteLine("Attempting to process the following information:")
            Console.WriteLine("Device Name: " & SRV_NAME)
            Console.WriteLine("Display Name: " & SRV_DISPLAYNAME)
            Console.WriteLine("IP Address: " & SRV_IP)
            Console.WriteLine("Device is Enabled: " & SRV_ENABLED)
            Console.WriteLine("Device Type: " & SRV_TYPE)
            Console.WriteLine("Collector ID: " & SRV_COLLECTORID)
            Console.WriteLine()
            Dim ObjGF As New BSGlobalFunctions
            Dim IsEnabled As Integer = 0
            Dim TypeID As Long = ObjGF.GetDeviceType(SRV_TYPE)
            If SRV_ENABLED Then IsEnabled = 1
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            Dim SQL As String = "INSERT INTO list_servers(ServerName,ServerIPAddress,DisplayName,IsEnabled, TID,CID) VALUES('" & _
                                    SRV_NAME & "','" & SRV_IP & "','" & SRV_DISPLAYNAME & "'," & IsEnabled & "," & TypeID & "," & SRV_COLLECTORID & ")"
            If ServerExists(SRV_NAME, SRV_IP, SRV_DISPLAYNAME, sMsg) And Not SRV_YESTOALL Then
                Call CatchDebug(sMsg, "modMain.ProcessData")
                Console.WriteLine(sMsg & " (y/n)")
                Dim sAns As String = LCase(Console.ReadLine)
                If sAns = "y" Then
                    Call Obj.ConnExe(SQL)
                    Console.WriteLine(SRV_NAME & " was added to the database!")
                    Call CatchDebug(SRV_NAME & " was added to the database!", "modMain.ProcessData")
                Else
                    Console.WriteLine(SRV_NAME & " was not added to the database!")
                    Call CatchDebug(SRV_NAME & " was not added to the database!", "modMain.ProcessData")
                End If
            Else
                Call Obj.ConnExe(SQL)
                Console.WriteLine(SRV_NAME & " was added to the database!")
                Call CatchDebug(SRV_NAME & " was added to the database!", "modMain.ProcessData")
            End If
        End If
    End Sub
    Sub SearchDB()
        Dim SQL As String = "select `ID`, `ServerName`, `ServerIPAddress`,`DisplayName` from list_servers where Servername like '%" & DOSEARCH_NAME & "%' or serveripaddress like '%" & DOSEARCH_NAME & "%' or displayname like '%" & DOSEARCH_NAME & "%'"
        Dim Obj As New BSDatabase
        Obj.MYCONNSTRING = sConn
        If Obj.ConnectDB = 0 Then
            Dim CMD As New MySqlCommand(SQL, Obj.Conn)
            Dim RS As MySqlDataReader
            RS = CMD.ExecuteReader
            Console.WriteLine("ID   Server Name     IP Address      Display Name")
            Console.WriteLine("===  ==============  =============   =============")
            While RS.Read()
                Console.WriteLine(RS("id") & vbTab & RS("ServerName") & vbTab & RS("ServerIPAddress") & vbTab & RS("Displayname"))
            End While
            RS.Close()
            RS = Nothing
            CMD = Nothing
            Obj.CloseDB()
            Obj = Nothing
        Else
            Console.WriteLine("Unable to connect to database")
        End If
    End Sub
    Sub Main()
        DONOTRUN = False
        Dim DidExist As Boolean = False
        ISHelp = CBool(GetCommand("help", "bool", DidExist))
        If ISHelp Then Call ShowHelp()
        If DidExist Then DONOTRUN = True
        IsVer = CBool(GetCommand("version", "bool", DidExist))
        If IsVer Then Call ShowVer()
        If DidExist Then DONOTRUN = True
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
        DODELETE_SID = CLng(GetCommand("delete", "int", DODELETE))
        DOSEARCH_NAME = GetCommand("search", "string", DOSEARCH)
        If DOSEARCH Then DONOTRUN = True
        If DODELETE Then DONOTRUN = True
        Call INIT_lite()
        If DODELETE Then Call DeleteMe()
        If DOSEARCH Then Call SearchDB()

        If ModDB Then
            Dim sServer As String = GetSetting("server", "string", DidExist)
            If Len(sServer) = 0 Then Console.WriteLine("Missing Server Name") : Exit Sub
            Dim sDB As String = GetSetting("db", "string", DidExist)
            If Len(sDB) > 0 Then
                Call SetDBServer(sServer)
            Else
                Call SetDBServer(sServer, , , sDB)
            End If
        End If
        If Not DONOTRUN Then
            Call Header()
            Console.WriteLine("Attempting to Add Server.")
            Call INIT()
            Call ProccessData()
        End If
    End Sub
    Public Function ServerExists(ByVal strName As String, ByVal strIP As String, ByVal strDisplayName As String, Optional ByRef sMsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            If Obj.ConnectDB() = 0 Then
                Dim SQL As String = "SELECT * from list_servers where Servername like '%" & _
                                    strName & "%' and cs <> 5 or ServerIPAddress = '" & strIP & _
                                    "' and cs <> 5 or DisplayName like '%" & strDisplayName & "%' and cs <> 5"
                Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                Dim RS As MySqlDataReader
                Dim NL As String = Chr(10) & Chr(13)
                RS = CMD.ExecuteReader
                If RS.HasRows Then
                    bAns = True
                    While RS.Read
                        sMsg &= "Server Already Exists with the following Parameters:" & NL
                        sMsg &= "Server Name: " & RS("ServerName") & NL
                        sMsg &= "IP Address: " & RS("ServerIPAddress") & NL
                        sMsg &= "Display Name: " & RS("DisplayName")
                        sMsg &= NL & "Do you still wish to add this machine to the database?"
                    End While
                End If
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
        Catch ex As Exception
            Dim ssMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(ssMsg, "frmAdd.ServerExists")
        End Try
        Return bAns
    End Function
    Sub ChangeAppSettings(ByVal sKey As String, ByVal sValue As String)
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Config.AppSettings.Settings.Remove(sKey)
        Config.AppSettings.Settings.Add(sKey, sValue)
        Config.Save(ConfigurationSaveMode.Modified)
        ConfigurationManager.RefreshSection("appSettings")
        Console.WriteLine(sKey & "'s new value is " & System.Configuration.ConfigurationManager.AppSettings(sKey))
    End Sub
    Sub Header()
        Console.WriteLine("BurnSoft Server Monitor Application - BurnSoft Add Server Command Line Utility")
        Console.WriteLine(My.Application.Info.ProductName & "  " & My.Application.Info.Copyright)
        Console.WriteLine()
    End Sub
    Sub ShowVer()
        Call Header()
        Console.WriteLine(String.Format("Version {0}", Application.ProductVersion.ToString))
    End Sub
    Sub SetDBServer(ByVal sServer As String, Optional ByVal UID As String = "bssm", Optional ByVal PWD As String = "bs.server.mon", Optional ByVal sDB As String = "bssm")
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
        Console.WriteLine("/help                - Displays this information")
        Console.WriteLine("/version             - Displays Current Version")
        Console.WriteLine("/showappsettings     - Show the settings for the config file")
        Console.WriteLine("/mod                 - Modify Settinss")
        Console.WriteLine("/key=Name            - App Setting Name use with /mod")
        Console.WriteLine("/value=NewValue      - New App Setting Value use with /mod")
        Console.WriteLine("/moddb               - Modify/add Database Settings")
        Console.WriteLine("/server=name         - New Server Setting Value use with /moddb")
        Console.WriteLine("/db=name             - Optional New Database Name Setting Value use with /moddb")
        Console.WriteLine("/server=<name/IP>    - REQUIRED need the server name or IP address that is going to be pinged")
        Console.WriteLine("/display=<name/IP>   - OPTIONAL, The Name you want to be displayed in the list, common name")
        Console.WriteLine("/type=<typename>     - OPTIONAL, label the server, router, time clock, printer, etc, see type list in UI")
        Console.WriteLine("/enabled             - OPTIONAL, Mark this server as enabled on the database, default is disabled.")
        Console.WriteLine("/ip=<IPADDRESS>      - OPTIONAL, the IP address that is assigned to the device.")
        Console.WriteLine("/CID=<COLLECTORID>   - OPTIONAL, Send to Collector Based on the Collector ID, otherwise it will go to master or balanced servers.")
        Console.WriteLine("/delete=<SID>        - Marks Server as deleted by Server ID")
        Console.WriteLine("/search=<name,ip>    - Search the Database to get the sid")
        Console.WriteLine("")
    End Sub
    Sub ShowAppSettings()
        Call Header()
        Dim sValue As String = ""
        sValue = "SP_ADDSRV"
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
End Module
