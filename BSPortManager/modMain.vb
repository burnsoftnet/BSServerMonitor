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
Imports BSPortManager.BurnSoft.GlobalClasses
Module modMain
    Public Throttle As Long
    Public IsThrot As Boolean
    Public PingXTimes As Long
    Public Pids As String
    Public PID As String
    Public DEBUG As Boolean
    Public DEBUG_LOGFILE As String
    Sub Main()
        Call INIT()
        Call DoList()
    End Sub
    Sub INIT()
        Try
            Throttle = CLng(System.Configuration.ConfigurationManager.AppSettings("Throttle"))
            PingXTimes = CLng(System.Configuration.ConfigurationManager.AppSettings("PingXTimes"))
            MyLogFile = System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
            DEBUG_LOGFILE = System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
            CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
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
    Sub RunServer(ByVal ServerName As String, ByVal ServerID As Long, ByVal TryTime As Long, ByVal sIP As String, ByVal iPort As Long)
        Try
            Dim sMsg As String = " - DEBUG - "
            Dim strExec As String = Application.StartupPath & "\bssm_PortScanner.exe /server=" & ServerName & " /sid=" & ServerID & " /try=" & TryTime & " /IP=" & sIP & " /port=" & iPort 'ShortPath()
            sMsg &= strExec
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
    Sub DoList()
        On Error Resume Next
        If ConnectDB() = 0 Then
            Dim SQL As String = "select * from view_active_port_list"
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
            Dim iPort As Long = 0
            While RS.Read
                strServer = RS("ServerName")
                lSID = CLng(RS("id"))
                sIp = RS("ServerIPAddress")
                iPort = RS("port")
                Call RunServer(strServer, lSID, PingXTimes, sIp, iPort)
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
            End While
            RS.Close()
            RS = Nothing
            CMD = Nothing
            Conn.Close()
            Conn = Nothing
        End If
    End Sub
End Module
