Imports System.Net
Imports System.IO
Imports System.Text
Imports BurnSoft.Universal

Module modMain
    Public SiteName As String
    Public CompairCode As Boolean
    Public WID As Long
    Public SID As Long
    Public SID_Status As Integer
    Public CollectData As Boolean
    Public DoWordSearch As Boolean
    Public WordSearchValue As String
    Public WordSearchOperand As String
    Public UseAuth As Boolean
    Public UseNTLM As Boolean
    Public UID As String
    Public PWD As String
    Public Domain As String
    Public SID_IS_HOST As Boolean
    Sub INIT()
        Dim mysite As String = ""
        Dim Myprot As String = ""
        Dim ObjOO As New BSOtherObjects
        Dim ObjR As New BSRegistry
        MyLogFile = System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
        CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
        DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
        DEBUG_LOGFILE = System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
        MYCONNSTRING = ObjR.GetDBSettings
        mysite = ObjOO.GetCommand("site", "")
        Myprot = ObjOO.GetCommand("protocol", "")
        CompairCode = ObjOO.GetCommand("compaircode", False)
        SiteName = Myprot & "://" & mysite
        WID = ObjOO.GetCommand("wid", 0)
        SID = ObjOO.GetCommand("sid", 0)
        SID_Status = ObjOO.GetCommand("SID_Status", 1)
        CollectData = ObjOO.GetCommand("GetCode", False)
        DoWordSearch = ObjOO.GetCommand("dowordsearch", False)
        SID_IS_HOST = ObjOO.GetCommand("isonhost", False)
        If DoWordSearch Then
            WordSearchValue = GetStringValueFromDB("select code_wordphrase_txt from website_list where id=" & WID, "code_wordphrase_txt")
            WordSearchOperand = GetStringValueFromDB("select code_wordphrase_oper from website_list where id=" & WID, "code_wordphrase_oper")
        End If
        UseAuth = ObjOO.GetCommand("useauth", False)
        If UseAuth Then
            UseNTLM = ObjOO.GetCommand("ntlm", False)
            If Not UseNTLM Then
                'enable encryption module and have this option either get from the database or encrypt on pass through
                'or have a switch statement for app.config file var.
                'UID = GetStringValueFromDB("SELECT auth_uid from website_list where id=" & WID, "auth_uid")
                'PWD = GetStringValueFromDB("SELECT auth_pwd from website_list where id=" & WID, "auth_pwd")
                'Domain = GetStringValueFromDB("SELECT auth_domain from website_list where id=" & WID, "auth_domain")
                UID = ObjOO.GetCommand("uid", "")
                PWD = ObjOO.GetCommand("pwd", "")
                Domain = ObjOO.GetCommand("domain", "")
            End If
        End If
        ObjOO = Nothing
    End Sub
    Sub AddEvent(ByVal ServerID As Long, ByVal sMsg As String, ByVal lMsg As String, ByVal mSev As String)
        Dim SQL As String = "INSERT INTO events_general(SID,shrtEv,lngEv,Sev) VALUES(" & ServerID & _
                            ",'" & sMsg & "','" & lMsg & "','" & mSev & "')"
        Call ConnExe(SQL)
        Call CatchDebug("SQL STATEMENT: " & SQL, "modMain.AddEvent")
    End Sub
    Sub AddWebEvent(ByVal ServerID As Long, ByVal WebSiteID As Long, ByVal sMsg As String, ByVal lMsg As String, ByVal mSev As String)
        Dim SQL As String = "INSERT INTO events_website(SID,WID,shrtEv,lngEv,Sev) VALUES(" & ServerID & "," & WebSiteID & _
                            ",'" & sMsg & "','" & lMsg & "','" & mSev & "')"
        Call ConnExe(SQL)
        Call CatchDebug("SQL STATEMENT: " & SQL, "modMain.AddWebEvent")
    End Sub
    Sub UpdateServerStatus(ByVal ServerID As Long, ByVal iStatus As Long)
        Dim SQL As String = "update list_servers set cs=" & iStatus & " where id=" & SID
        Call ConnExe(SQL)
        Call CatchDebug("SQL STATEMENT: " & SQL, "modMain.UpdateServerStatus")
    End Sub
    Sub DoWebCheck()
        Try
            'Status  are 0 down, 1 up, 2 warning, 3 disabled
            Dim ObjOO As New BSOtherObjects
            Dim objwr As New BSWebResponse
            Dim iCodeMatch As Integer = 3
            Dim iWordMatch As Integer = 3
            Dim iSeconds As Double = 0
            Dim iStatus As Integer = 1
            Dim sShrt As String = ""
            Dim sLong As String = ""
            Dim Sev As String = ""
            Dim Sev_SRV As String = ""
            If UseAuth Then
                objwr.UseAuthentication = UseAuth
                objwr.UseNTLM = UseNTLM
                If Not UseNTLM Then
                    objwr.UserName = UID
                    objwr.Password = PWD
                    objwr.Domain = Domain
                End If
            End If
            Dim sContext As String = ""
            Dim ErrorMsg As String = ""
            Dim LogMessage As String = ""
            Dim SiteISUP As Boolean = objwr.SiteIsUp(SiteName, sContext, ErrorMsg, iSeconds)
            If SiteISUP Then
                iStatus = 1
                If Len(ErrorMsg) = 0 Then LogMessage = ObjOO.AppendToString("Site is UP!", LogMessage)
                Call CatchDebug(SiteName & " is up", "modMain.DoWebCheck")
                If CompairCode Then
                    Dim OrgCode As String = GetStringValueFromDB("SELECT site_code from website_code where wid=" & WID, "site_code")
                    Dim array1() As Byte = System.Text.Encoding.ASCII.GetBytes(OrgCode)
                    Dim array2() As Byte = System.Text.Encoding.ASCII.GetBytes(sContext)
                    If objwr.ArraysEqual(array1, array2) Then
                        LogMessage = ObjOO.AppendToString("Code Match OK!", LogMessage)
                        Call CatchDebug(SiteName & " page code is the same", "modMain.DoWebCheck")
                        iCodeMatch = 1
                    Else
                        iCodeMatch = 2
                        iStatus = 2
                        LogMessage = ObjOO.AppendToString("CODE MISMATCH!", LogMessage)
                        Call CatchDebug(SiteName & " page code is different!", "modMain.DoWebCheck")
                    End If
                End If

                If DoWordSearch Then
                    Dim sLookfor As String = WordSearchValue
                    Dim sOperand As String = WordSearchOperand
                    Dim FoundData As Boolean = objwr.ContentsExistsRegEx(sContext, "\b(" & sLookfor & ")\b")
                    If WordSearchOperand = "=" Then
                        If FoundData Then
                            iWordMatch = 1
                            LogMessage = ObjOO.AppendToString("WORD FIND: OK!", LogMessage)
                            Call CatchDebug("found word/phrase: " & sLookfor, "modMain.DoWebCheck")
                        Else
                            iWordMatch = 2
                            iStatus = 2
                            LogMessage = ObjOO.AppendToString("WORD FIND: NOT FOUND!", LogMessage)
                            Call CatchDebug("did not find word/phrase: " & sLookfor, "modMain.DoWebCheck")
                        End If
                    ElseIf WordSearchOperand = "<>" Then
                        If Not FoundData Then
                            iWordMatch = 1
                            LogMessage = ObjOO.AppendToString("WORD NOT FOUND: OK!", LogMessage)
                            Call CatchDebug("all is well, didn't find " & sLookfor, "modMain.DoWebCheck")
                        Else
                            iWordMatch = 2
                            iStatus = 2
                            LogMessage = ObjOO.AppendToString("WORD NOT FOUND: FOUND WORD!", LogMessage)
                            Call CatchDebug("something wrong found " & sLookfor, "modMain.DoWebCheck")
                        End If
                    End If
                End If
            Else
                iStatus = 0
                LogMessage = ObjOO.AppendToString(ErrorMsg, LogMessage)
                Call CatchDebug(SiteName & " is down", "modMain.DoWebCheck")
            End If
            Dim SQL As String = "INSERT INTO website_check_results (SID,WID,LS,responsetime,error_msg,code_match,word_match) VALUES(" & _
                                SID & "," & WID & "," & iStatus & "," & iSeconds & ",'" & LogMessage & "'," & iCodeMatch & "," & iWordMatch & ")"
            Call CatchDebug(SQL, "modMain.DoWebCheck")
            ConnExe(SQL)

            Select Case iStatus
                Case 0 'Site is Down
                    sShrt = "SITE DOWN - " & SiteName
                    sLong = "Server Reports up but the Website ( " & SiteName & " ) is unreachable!"
                    Sev = "ERROR"
                    Sev_SRV = "WARNING"
                    If Not WebEventExists(SID, WID, sShrt, sLong, Sev) Then Call AddWebEvent(SID, WID, sShrt, sLong, Sev)
                    If Not EventExists(SID, sShrt, sLong, Sev_SRV) Then Call AddEvent(SID, sShrt, sLong, Sev_SRV)
                    Call UpdateServerStatus(SID, 7)
                Case 1 'everything is ok
                    ' this section shouldn't have anything, since if it is ok, there is nothing we
                    ' need to put in the events section.

                Case 2 ' Site Up, but check failed
                    sShrt = "SITE FUNCTION TEST FAILED - " & SiteName
                    sLong = "Server Reports and the Website ( " & SiteName & " ) is is Up but a test failed!" & LogMessage
                    Sev = "ERROR"
                    Sev_SRV = "WARNING"
                    If Not WebEventExists(SID, WID, sShrt, sLong, Sev) Then Call AddWebEvent(SID, WID, sShrt, sLong, Sev)
                    If Not EventExists(SID, sShrt, sLong, Sev_SRV) Then Call AddEvent(SID, sShrt, sLong, Sev_SRV)
                    Call UpdateServerStatus(SID, 7)
                    If iCodeMatch = 2 And iWordMatch = 1 Or iCodeMatch = 2 And iWordMatch = 3 Then
                        Call UpdateServerStatus(SID, 9)
                    ElseIf iCodeMatch = 2 And iWordMatch = 2 Then
                        Call UpdateServerStatus(SID, 10)
                    ElseIf iCodeMatch = 1 And iWordMatch = 2 Or iCodeMatch = 3 And iWordMatch = 2 Then
                        Call UpdateServerStatus(SID, 8)
                    End If
                Case 3 ' site is disabled
                    'is the site is disabled then it should not even be checking
            End Select

        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, "modMain.DoWebCheck")
        End Try

    End Sub
    Sub Main()
        Call INIT()
        Dim ObjOO As New BSOtherObjects
        Dim HOSTISUP As Boolean = ObjOO.ConvertToBool(SID_Status)
        If HOSTISUP And SID_IS_HOST Then
            Call DoWebCheck()
        ElseIf Not SID_IS_HOST Then
            Call DoWebCheck()
        Else
            Call CatchDebug("Host is down and so are the websites that are on it", "modMain.Main")
        End If
    End Sub

End Module
