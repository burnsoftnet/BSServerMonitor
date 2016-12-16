Imports BurnSoft.Universal
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
Module modMain
    Public XMLFILENAME As String
    Public CID As Long
    Public PID As Long
    Public Pids As String
    Public Throttle As Long
    Sub INIT()
        Dim ObjR As New BSRegistry
        CID = CLng(System.Configuration.ConfigurationManager.AppSettings("DataCollectorID"))
        MyLogFile = System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
        CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
        DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
        DEBUG_LOGFILE = System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
        XMLFILENAME = System.Configuration.ConfigurationManager.AppSettings("XMLFILENAME")
        Throttle = CLng(System.Configuration.ConfigurationManager.AppSettings("Throttle"))
        MYCONNSTRING = ObjR.GetDBSettings
        ObjR = Nothing
    End Sub
    Sub Main()
        Call INIT()
        Call DumpXML()
        Call ReadFile()
    End Sub
    Sub DumpXML()
        If ConnectDB() = 0 Then
            Dim SQL As String = "SELECT * from view_website_list_all where deviceenabled=1 and webenabled=1 and CID=" & CID & " order by displayname ASC"
            Dim CMD As New MySqlCommand
            Dim RS As New MySqlDataAdapter
            Dim DSID As New DataSet
            CMD.Connection = Conn
            CMD.CommandText = SQL
            RS.SelectCommand = CMD
            RS.Fill(DSID, "WebList")
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
        Dim objOO As New BSOtherObjects
        Dim ObjE As New BSEncryption.SHA
        Dim doc As New XmlDocument
        doc.Load(XMLFILENAME)
        Dim elemList As XmlNodeList = doc.GetElementsByTagName("WebList")
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

        Dim webname As String
        Dim website_name As String
        Dim website_prot As String
        Dim DisplayName As String
        Dim DeviceStatus As Long
        Dim CID As Long
        Dim ID As Long
        Dim SID As Long
        Dim CS As Long
        Dim WID As Long
        Dim code_collect As Integer
        Dim code_compair As Integer
        Dim doCompair As Boolean
        Dim doCollect As Boolean
        Dim code_wordphrase As Integer
        Dim code_wordphrase_oper As String
        Dim code_wordphrase_txt As String
        Dim iuse_auth As Integer
        Dim iauth_ntlm As Integer
        Dim use_auth As Boolean
        Dim auth_ntlm As Boolean
        Dim webenabled As Long
        Dim CurrentStatus As Long
        Dim isid_is_host As Integer = 0
        Dim sid_is_host As Boolean
        Dim sParm As String
        Dim idowordsearch As Integer
        Dim dowordsearch As Boolean
        Dim UID As String
        Dim PWD As String
        Dim Domain As String

        Call CatchDebug(elemList.Count & " devices listed in database", "modMain.ReadFIle")
        For il = 0 To elemList.Count - 1
            webname = objOO.GetXMLNode(elemList(il).Item("website_name"))
            strsplit = Split(webname, "://")
            If UBound(strsplit) = 1 Then
                website_prot = strsplit(0)
                website_name = strsplit(1)
            Else
                website_prot = "http"
                website_name = webname
            End If

            DisplayName = objOO.GetXMLNode(elemList(il).Item("displayname"))
            code_compair = objOO.GetXMLNode(elemList(il).Item("code_compair"))
            doCompair = objOO.ConvertToBool(code_compair)
            code_collect = objOO.GetXMLNode(elemList(il).Item("code_collect"))
            doCollect = objOO.ConvertToBool(code_collect)
            isid_is_host = objOO.GetXMLNode(elemList(il).Item("sid_is_host"))
            sid_is_host = objOO.ConvertToBool(isid_is_host)
            WID = objOO.GetXMLNode(elemList(il).Item("id"))
            CID = objOO.GetXMLNode(elemList(il).Item("CID"))
            SID = objOO.GetXMLNode(elemList(il).Item("SID"))
            CS = objOO.GetXMLNode(elemList(il).Item("CS"))
            DeviceStatus = objOO.GetXMLNode(elemList(il).Item("DeviceStatus"))
            idowordsearch = objOO.GetXMLNode(elemList(il).Item("dowordsearch"))
            dowordsearch = objOO.ConvertToBool(idowordsearch)
            iuse_auth = objOO.GetXMLNode(elemList(il).Item("use_auth"))
            use_auth = objOO.ConvertToBool(iuse_auth)
            iauth_ntlm = objOO.GetXMLNode(elemList(il).Item("auth_ntlm"))
            auth_ntlm = objOO.ConvertToBool(iauth_ntlm)

            sParm = "/site=" & website_name & " /protocol=" & website_prot & _
                    " /wid=" & WID & " /SID=" & SID & " /SID_Status=" & DeviceStatus
            If doCompair Then sParm &= " /compaircode"
            If doCollect Then sParm &= " /GetCode"
            If sid_is_host Then sParm &= " /isonhost"
            If dowordsearch Then sParm &= " /dowordsearch"
            If use_auth Then sParm &= " /useauth"
            If auth_ntlm Then sParm &= " /ntlm"
            If use_auth And Not auth_ntlm Then
                UID = Trim(ObjE.DecryptSHA(objOO.GetXMLNode(elemList(il).Item("auth_uid"))))
                PWD = Trim(ObjE.DecryptSHA(objOO.GetXMLNode(elemList(il).Item("auth_pwd"))))
                Domain = Trim(ObjE.DecryptSHA(objOO.GetXMLNode(elemList(il).Item("auth_domain"))))
                If Len(UID) > 0 Then sParm &= "/uid=" & UID
                If Len(PWD) > 0 Then sParm &= "/pwd=" & PWD
                If Len(Domain) > 0 Then sParm &= "/domain=" & Domain
            End If

            Call RunServer(sParm)
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
                'Call CatchDebug("CID: " & CID, "modMain.ReadFIle")
                'Call UpdateStatus()
    End Sub
    Sub RunServer(ByVal sParm As String)
        Try
            Dim sMsg As String = " - DEBUG - "
            Dim strExec As String = Application.StartupPath & "\BSSM_webtest.exe " & sParm
            sMsg &= strExec
            'If UseTrace Then sMsg &= " /usetrace"
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
End Module
