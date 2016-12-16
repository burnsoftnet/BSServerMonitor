Imports BSSM_nmap.BurnSoft.GlobalClasses
Imports System
Imports System.Data
Imports mysql.Data.MySqlClient
Imports System.Xml
Imports System.Xml.XPath
Imports System.Configuration
Imports System.Windows.Forms
Imports System.Text
Imports BurnSoft.FileSystem
Module modMain
    Public sMODE As String
    Public Throttle As Long
    Public IsThrot As Boolean
    Public PingXTimes As Long
    Public Pids As String
    Public PID As String
    Public XMLFILENAME As String
    Public PROCESSDATAONLY As Boolean
    Public GATHERDATAONLY As Boolean
    Public CID As Long

    Sub KillTrace(ByVal SID As Long)
        Dim SQL As String = "DELETE from results_trace where SID=" & SID
        ConnExe(SQL)
    End Sub
    Sub ReadHops(ByVal sFile As String, Optional ByVal SID As Long = 0)
        Try
            Call KillTrace(SID)
            'TODO Think about compairing data and not deleting it
            'Optional now that you are only scanning devices that are up
            'Still would be a nice option to do an informational alert stating that the route changed
            Dim doc As XmlDocument = New XmlDocument()
            Dim ns As XmlNamespaceManager
            Dim nodes As XmlNodeList
            doc.Load(sFile)
            ns = New XmlNamespaceManager(doc.NameTable)
            nodes = doc.SelectNodes("/nmaprun/host/trace/hop", ns)
            Dim iHop As Integer = 0
            Dim ttl As Long = 0
            Dim rtt As Long = 0
            Dim ipAddr As String = ""
            Dim SQL As String = ""
            For Each node As XmlNode In nodes
                iHop += 1
                ttl = CLng(node.Attributes("ttl").InnerText)
                rtt = CLng(node.Attributes("rtt").InnerText)
                ipAddr = node.Attributes("ipaddr").InnerText
                SQL = "INSERT INTO results_trace (SID,hopno,ttl,rtt,ipaddr) VALUES(" & _
                    SID & "," & iHop & "," & ttl & "," & rtt & ",'" & ipAddr & "')"
                ConnExe(SQL)
            Next
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "ReadHops"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
    Function PortExists(ByVal SID As Long, ByVal Port As Long, ByVal Prot As String) As Boolean
        Dim bAns As Boolean = False
        Try
            If ConnectDB() = 0 Then
                Dim SQL As String = "SELECT * from list_servers_ports where SID=" & SID & _
                                        " and port=" & Port & " and protocol='" & Prot & "'"
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim rs As MySqlDataReader
                rs = CMD.ExecuteReader
                bAns = rs.HasRows
                rs.Close()
                rs = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "PortExists"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return bAns
    End Function
    Function PortExistsInListing(ByVal Port As Long, ByVal Prot As String) As Boolean
        Dim bAns As Boolean = False
        Try
            If ConnectDB() = 0 Then
                Dim SQL As String = "SELECT * from port_listings where " & _
                                        "port=" & Port & " and protocol='" & Prot & "'"
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim rs As MySqlDataReader
                rs = CMD.ExecuteReader
                bAns = rs.HasRows
                rs.Close()
                rs = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "PortExistsInListing"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return bAns
    End Function
    Sub ReadPorts(ByVal sFile As String, Optional ByVal SID As Long = 0)
        Try
            Dim doc As XmlDocument = New XmlDocument()
            Dim ns As XmlNamespaceManager
            Dim nodes As XmlNodeList
            doc.Load(sFile)
            ns = New XmlNamespaceManager(doc.NameTable)
            nodes = doc.SelectNodes("/nmaprun/host/ports/port", ns)
            Dim Port As Long = 0
            Dim protocol As String = ""
            Dim AppName As String = ""
            Dim SQL As String = ""
            For Each node As XmlNode In nodes
                Port = CLng(node.Attributes("portid").InnerText)
                protocol = node.Attributes("protocol").InnerText

                If Not PortExists(SID, Port, protocol) Then
                    SQL = "INSERT INTO list_servers_ports (SID,port,protocol) VALUES(" & _
                        SID & "," & Port & ",'" & protocol & "')"
                    ConnExe(SQL)
                End If
                If Not PortExistsInListing(Port, protocol) Then
                    SQL = "INSERT INTO port_listings (port,protocol) VALUES(" & _
                            Port & ",'" & protocol & "')"
                    ConnExe(SQL)
                End If
            Next
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "ReadPorts"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
    Sub RunServer(ByVal ServerName As String)
        Try
            Dim sMsg As String = " - DEBUG - "
            Dim myProcess As New Process
            Dim NMAP_APP As String = System.Configuration.ConfigurationManager.AppSettings("NMAP_APPNAME")
            Dim NMAP_PARAppName As String = "NMAP_" & sMODE
            Dim NMAP_PAR As String = System.Configuration.ConfigurationManager.AppSettings(NMAP_PARAppName)
            Dim sExecPar As String = " -oX " & DATAFOLDER & ServerName & ".xml"
            Dim sArg As String = NMAP_PAR & " " & ServerName & " " & sExecPar
            sMsg &= Application.StartupPath & "\" & NMAP_APP & " " & sArg
            Call CatchDebug(sMsg, "modMain.RunServer")
            myProcess.StartInfo.FileName = NMAP_APP
            myProcess.StartInfo.Arguments = sArg
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            myProcess.Start()
            Pids &= "," & myProcess.Id
            Call CatchDebug("CURRENT PIDS:" & Pids, "modMain.RunServer")
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "RunServer"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
    Sub INIT()
        Dim sHolder As String = ""
        Dim DidExist As Boolean = False
        Dim ObjFS As New FSInfo
        Dim Obj As New BSRegistry
        sHolder = GetCommand("processdata", "bool", DidExist)
        PROCESSDATAONLY = DidExist
        DidExist = False
        sHolder = GetCommand("gatherdata", "bool", DidExist)
        GATHERDATAONLY = DidExist
        MyLogFile = System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
        CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
        DEBUG_LOGFILE = System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
        DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
        sMODE = System.Configuration.ConfigurationManager.AppSettings("MODE")
        DATAFOLDER = ObjFS.GetShortPathName(Application.StartupPath & "\" & System.Configuration.ConfigurationManager.AppSettings("DATAFOLDER"))
        Throttle = CLng(System.Configuration.ConfigurationManager.AppSettings("Throttle"))
        COLLECTIONMODE = System.Configuration.ConfigurationManager.AppSettings("COLLECTIONMODE")
        CID = System.Configuration.ConfigurationManager.AppSettings("DataCollectorID")
        XMLFILENAME = System.Configuration.ConfigurationManager.AppSettings("XMLFILENAME")
        IsThrot = True
        Pids = ""
        MYCONNSTRING = Obj.GetDBSettings
        Obj = Nothing
        ObjFS = Nothing
    End Sub
    Function GetXMLNode(ByVal instance As XmlNode) As String
        Dim MyAns As String = ""
        Try
            MyAns = instance.InnerText
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "GetXMLNode"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return MyAns
    End Function
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
        Dim lStat As Integer = 0
        Dim iTrace As Integer = 0
        Dim bTrace As Boolean = False
        Dim iPort As Integer = 0
        Dim bPort As Boolean = False
        Dim bRunApp As Boolean = False
        Call CatchDebug(elemList.Count & " devices listed in database", "modMain.ReadFIle")
        For il = 0 To elemList.Count - 1
            bTrace = False
            bPort = False
            strServer = GetXMLNode(elemList(il).Item("ServerName"))
            sIp = GetXMLNode(elemList(il).Item("ServerIPAddress"))
            lSID = CLng(GetXMLNode(elemList(il).Item("ID")))
            iTrace = CInt(GetXMLNode(elemList(il).Item("DoTrace")))
            If iTrace = 1 Then bTrace = True
            iPort = CInt(GetXMLNode(elemList(il).Item("DoPort")))
            If iPort = 1 Then bPort = True
            If bTrace Or bPort Then
                bRunApp = True
            ElseIf Not bTrace Or Not bPort Then
                bRunApp = False
            End If
            If bRunApp Then
                Call RunServer(strServer)
                If x >= Throttle + 1 Then
                    strSplit = Split(Pids, ",")
                    PidBound = UBound(strSplit)
                    For i = 1 To PidBound
                        If Len(strSplit(i)) > 0 Then
                            CurPid = CInt(strSplit(i))
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
            End If
            P += 1
        Next il
    End Sub
    Sub ProcessResults()
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
        Dim SID As Long = 0
        Dim lsCount As Long = 0
        Dim lastServer As String = ""
        Dim lStat As Integer = 0
        Dim iTrace As Integer = 0
        Dim bTrace As Boolean = False
        Dim iPort As Integer = 0
        Dim bPort As Boolean = False
        Dim sFile As String = ""
        Call CatchDebug(elemList.Count & " devices listed in database", "modMain.ReadFIle")
        For il = 0 To elemList.Count - 1
            bTrace = False
            bPort = False
            strServer = GetXMLNode(elemList(il).Item("ServerName"))
            SID = CLng(GetXMLNode(elemList(il).Item("ID")))
            sFile = DATAFOLDER & strServer & ".xml"
            iTrace = CInt(GetXMLNode(elemList(il).Item("DoTrace")))
            If iTrace = 1 Then bTrace = True
            iPort = CInt(GetXMLNode(elemList(il).Item("DoPort")))
            If iPort = 1 Then bPort = True
            Select Case UCase(sMODE)
                Case "FULL"
                    If bTrace Then Call ReadHops(sFile, SID)
                    If bPort Then Call ReadPorts(sFile, SID)
                Case "TRACE"
                    If bTrace Then Call ReadHops(sFile, SID)
                Case "PORT"
                    If bPort Then Call ReadPorts(sFile, SID)
                Case Else
                    If bTrace Then Call ReadHops(sFile, SID)
                    If bPort Then Call ReadPorts(sFile, SID)
            End Select
        Next il
    End Sub
    Sub DumpXMLALL()
        If ConnectDB() = 0 Then
            Dim SQL As String = "SELECT * from list_servers where cs=1 and isenabled=1 order by ServerName ASC"
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
    Sub DumpXML()
        If ConnectDB() = 0 Then
            Dim SQL As String = "SELECT * from list_servers where cs=1 and isenabled=1 and CID=" & CID & " order by ServerName ASC"
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
    Sub Main()
        Call CatchDebug("Starting INIT Sub", "modMain.Main")
        Call INIT()
        Select Case UCase(COLLECTIONMODE)
            Case "MEONLY"
                Call DumpXMLALL()
            Case "BYCOLLECTOR"
                Call DumpXML()
            Case Else
                Call DumpXML()
        End Select

        If Not PROCESSDATAONLY And Not GATHERDATAONLY Then
            Call CatchDebug("Gathering and Processing Data", "modMain.Main")
            Call ReadFile()
            Call ProcessResults()
        ElseIf GATHERDATAONLY Then
            Call CatchDebug("Gathering Data Only", "modMain.Main")
            Call ReadFile()
        ElseIf PROCESSDATAONLY Then
            Call CatchDebug("Processing Data Only", "modMain.Main")
            Call ProcessResults()

        End If
        Call CatchDebug("Application Exiting", "modMain.Main")
    End Sub
End Module
