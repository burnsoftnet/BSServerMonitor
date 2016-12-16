Imports BurnSoft.Network
Imports bssm_PortScanner.BurnSoft.GlobalClasses
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
    Dim PortID As Long
    Dim sIP As String
    Dim Repeatx As Long
    Dim TSID As Long
    Dim PORT As Long
    Dim IsWarned As Boolean
    Public PORT_TIMEOUT As Long
    Function GetTPID(ByVal PID As Long) As Long
        Dim lAns As Long = 0
        Try
            If ConnectDB() = 0 Then
                Dim SQL As String = "SELECT max(id) as id from results_port_test where pid=" & PID
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
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, "modMain.GetTPID")
        End Try
        Return lAns
    End Function
    Sub INIT()
        Dim DidExist As Boolean = False
        Repeatx = CLng(GetCommand("try", "int", DidExist))
        PortID = CLng(GetCommand("pid", "int", DidExist))
        ServerName = GetCommand("server", "string", DidExist)
        sIP = GetCommand("ip", "string", DidExist)
        PORT = CLng(GetCommand("port", "int", DidExist))
        MyLogFile = System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
        CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
        PORT_TIMEOUT = CLng(System.Configuration.ConfigurationManager.AppSettings("PORT_TIMEOUT"))
        Dim Obj As New BSRegistry
        MYCONNSTRING = Obj.GetDBSettings
    End Sub
    Sub Main()
        Call INIT()
        ' Dim Sql As String = "INSERT INTO results_timestamp (SID) VALUES(" & ServerID & ")"
        ' Call ConnExe(Sql)
        ' TSID = GetTSID(ServerID)
        Call DoScan()
    End Sub
    Sub InsertResults(ByVal PID As Long, ByVal iSent As Long, ByVal iRecv As Long, ByVal dUp As Double, ByVal iStat As Long)
        Dim SQL As String = "INSERT INTO results_port_test (PID,iSent,iRec,uptime,cs) VALUES(" & _
            PID & "," & iSent & "," & iRecv & "," & dUp & "," & iStat & ")"
        Call ConnExe(SQL)
        SQL = "UPDATE list_servers_ports set CS=" & iStat & " where ID=" & PID
        Call ConnExe(SQL)
    End Sub
    Sub DoScan()
        Try
            Dim Obj As Ports
            Dim IsUp As Boolean = False
            Dim sMsg As String = ""
            Dim shost As String = ServerName
            Dim sErr As String = ""
            Dim i As Long = 0
            Dim iRec As Integer = 0
            Dim iLost As Integer = 0
            Dim oMain As Object = Nothing
            Dim Uptime As Double = 0
            For i = 1 To Repeatx
                Obj = New Ports(shost, PORT)
                Obj.CheckTCP = True
                Obj.checkPort(IsUp, shost, oMain, sErr)
                If IsUp Then
                    iRec += 1
                Else
                    iLost += 1
                End If
            Next i
            'TODO: Finish Port Checker App in data insertion
            Uptime = (iRec / Repeatx) * 100
            If Uptime > 25 Then
                Call InsertResults(PortID, Repeatx, iRec, Uptime, 1)
            ElseIf Uptime > 0 And Uptime < 25 Then
                Call InsertResults(PortID, Repeatx, iRec, Uptime, 2)
            ElseIf Uptime = 0 Then
                Call InsertResults(PortID, Repeatx, iRec, Uptime, 0)
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "DoScan"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
End Module
