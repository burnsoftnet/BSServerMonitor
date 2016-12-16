Imports BurnSoft
Imports MySql.Data.MySqlClient
Partial Class Controls_View_Device_Details
    Inherits System.Web.UI.UserControl
    Public SID As Long
    Function YNtoBool(ByVal sValue As String) As Boolean
        Dim bAns As Boolean = False
        If LCase(sValue) = "y" Or LCase(sValue) = "yes" Then
            bAns = True
        Else
            bAns = False
        End If
        Return bAns
    End Function
    Function GetCollectorID(ByVal CID As Long) As String
        Dim sAns As String = "MASTER"
        Dim RS As MySqlDataReader
        Dim Obj As New BSDatabase
        RS = Obj.OpenDBForRead("SELECT ServerName from list_collectors where ID=" & CID)
        While RS.Read
            sAns = RS("ServerName")
        End While
        Return sAns
    End Function
    Sub LoadInformation()
        Dim Obj As New BSDatabase
        Dim RS As MySqlDataReader
        Dim SQL As String = "SELECT * from view_servers_all where ID=" & SID
        RS = Obj.OpenDBForRead(SQL)
        Dim isEnabled As Boolean = False
        While RS.Read
            If Not IsDBNull(RS("ServerName")) Then lblDevice.Text = RS("ServerName")
            If Not IsDBNull(RS("DisplayName")) Then lblDisplayName.Text = RS("DisplayName")
            If Not IsDBNull(RS("ServerIPAddress")) Then lblIP.Text = RS("ServerIPAddress")
            If Not IsDBNull(RS("CS")) Then lblLastStatus.Text = RS("CS")
            If Not IsDBNull(RS("DTAdded")) Then lblDateAdd.Text = RS("DTAdded")
            If Not IsDBNull(RS("Cat")) Then lblType.Text = RS("Cat")
            If Not IsDBNull(RS("PingRepeats")) Then lblAttempts.Text = RS("PingRepeats")
            If RS("IsEnabled") = "Enabled" Then isEnabled = True
            chkEnabled.Checked = isEnabled
            chkTrace.Checked = YNtoBool(RS("DoTrace"))
            chkPort.Checked = YNtoBool(RS("DoPort"))
            chkHttp.Checked = YNtoBool(RS("DoHTTP"))
            chkPing.Checked = YNtoBool(RS("DoPing"))
            lblCollector.Text = GetCollectorID(RS("CID"))
        End While
        RS = Nothing
        Call Obj.CloseDB()
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SID = Request.QueryString("ID")
        Dim TABPATH As String = System.Configuration.ConfigurationManager.AppSettings("TABPATH")
        If Not Page.IsPostBack Then
            tabBar.AddTab("Information", TABPATH & "/icon1.gif", "divTab1")
            tabBar.AddTab("Events", TABPATH & "/icon1.gif", "divTab2")
            tabBar.AddTab("Ping Details", TABPATH & "/icon1.gif", "divTab3")
            tabBar.AddTab("Ports", TABPATH & "/icon1.gif", "divTab4")
            tabBar.AddTab("Trace Routes", TABPATH & "/icon1.gif", "divTab5")
            If SID > 0 Then Call LoadInformation()
            SqlDataSource1.SelectCommand = "SELECT DT, shrtEv, lngEv, Sev FROM events_general where SID=" & SID & " ORDER BY DT DESC"
            SqlDataSource2.SelectCommand = "SELECT DTID, (CASE `ls` when 0 then concat(' DOWN ') when 1 then concat(' UP ') end) as ls, `Packets_Sent`, `Packets_Rec`, `Packets_Lost`, `RoundTrip_Min`, `RoundTrip_Max`, `RoundTrip_Avg`, `uptime` FROM `bssm`.`view_ping_timepingstats` where SID=" & SID & " order By DTID DESC limit 0,50"
            SqlDataSource3.SelectCommand = "select Port, protocol,ismonitored,currentstatus from web_view_servers_ports where SID=" & SID & " order by port asc"
            SqlDataSource4.SelectCommand = "SELECT `ID`, `SID`, `hopno`, `ttl`, `rtt`, `ipaddr` FROM `bssm`.`results_trace` where SID=" & SID & " order by hopno asc"
        End If
    End Sub
End Class
