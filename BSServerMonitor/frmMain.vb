Imports BSServerMonitor.BurnSoft.GlobalClasses
Imports System.Diagnostics
Imports System.Configuration
Public Class frmMain
    Public IServerPingerManagerTimer As Long
    Public xServerPingerManagerTimer As Long
    Public Sub CreateViewOnlyMode()
        If READ_ONLY Then
            AddItemsToolStripMenuItem1.Enabled = False
            ActionsToolStripMenuItem.Enabled = False
            TypeListsToolStripMenuItem.Enabled = False
        End If
    End Sub
    Public Sub LoadData()
        Try
            VIEW_DOWNONLY = CBool(System.Configuration.ConfigurationManager.AppSettings("VIEW_DOWNONLY"))
            VIEW_SERVERDETAILS_PING_LIMIT = CLng(System.Configuration.ConfigurationManager.AppSettings("VIEW_SERVERDETAILS_PING_LIMIT"))
            If VIEW_DOWNONLY Or CBool(System.Configuration.ConfigurationManager.AppSettings("View_Downonly_EOMODE")) Then
                READ_ONLY = True
            Else
                READ_ONLY = False
            End If
            Call CreateViewOnlyMode()
            Dim ObjR As New BSRegistry
            sConn = ObjR.GetDBSettings
            Me.List_serversTableAdapter.FillBy_SideList(Me.BssmDataSet.list_servers)
            ToolStripStatusLabel1.Text = "Last Update: " & LastUpdateTime()
            lblSrvCount.Text = lstServers.Items.Count & " Devices"
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "LoadData")
        End Try
    End Sub
    Sub DefaultStartup()
        If READ_ONLY Then
            frmView_Servers_ErrorsOnly.MdiParent = Me
            frmView_Servers_ErrorsOnly.Show()
            frmView_Servers_DownOnly.MdiParent = Me
            frmView_Servers_DownOnly.Show()
        Else
            frmView_Collectors.MdiParent = Me
            frmView_Collectors.Show()
            frmView_Servers_DownOnly.MdiParent = Me
            frmView_Servers_DownOnly.Show()
            frmView_Servers_Disabled.MdiParent = Me
            frmView_Servers_Disabled.Show()
            frmView_Servers_ErrorsOnly.MdiParent = Me
            frmView_Servers_ErrorsOnly.Show()
        End If
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LoadData()
        Call DefaultStartup()
    End Sub
    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.Height <> 0 Then
            Panel1.Height = Me.Height
            lstServers.Height = Me.Height - 128
            Dim p As New Point
            p = New Point(lblSrvCount.Location.X, lstServers.Height + 65)
            Me.lblSrvCount.Location = p
        End If
    End Sub
    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Application.ExitThread()
    End Sub
    Private Sub AddServerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddServerToolStripMenuItem1.Click
        frmAddServer.MdiParent = Me
        frmAddServer.Show()
    End Sub
    Private Sub AllDownServersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllDownServersToolStripMenuItem.Click
        frmView_Servers_DownOnly.MdiParent = Me
        frmView_Servers_DownOnly.Show()
    End Sub
    Private Sub AllServersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllServersToolStripMenuItem.Click
        frmView_Servers_All.MdiParent = Me
        frmView_Servers_All.Show()
    End Sub
    Sub RunPingManager()
        Try
            Dim myProcess As New Process
            myProcess.StartInfo.FileName = Application.StartupPath & "\BSSM_PingManager.exe"
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            myProcess.Start()
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "RunPingManager")
        End Try
    End Sub
    Private Sub ASAPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ASAPToolStripMenuItem.Click
        Call RunPingManager()
    End Sub
    Private Sub RunOnTimerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunOnTimerToolStripMenuItem1.Click
        Try
            If RunOnTimerToolStripMenuItem1.Checked Then
                IServerPingerManagerTimer = (CLng(InputBox("Please type in the Number of Minutes you wish to run the Ping Manager:", "Run Ping Manager on Timer", 15)) * 60)
                If IServerPingerManagerTimer <> 0 Then
                    Call RunPingManager()
                    tmrServerPingerManager.Enabled = True
                    ToolStripProgressBar1.Visible = True
                    ToolStripProgressBar1.Minimum = 0
                    ToolStripProgressBar1.Maximum = IServerPingerManagerTimer
                    ToolStripProgressBar1.ProgressBar.Refresh()
                End If
            Else
                tmrServerPingerManager.Enabled = False
                ToolStripProgressBar1.Visible = False
            End If
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "RunOnTimerToolStripMenuItem1.Click")
        End Try
    End Sub
    Private Sub tmrServerPingerManager_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrServerPingerManager.Tick
        If xServerPingerManagerTimer >= IServerPingerManagerTimer Then
            Call RunPingManager()
            xServerPingerManagerTimer = 0
        Else
            xServerPingerManagerTimer += 1
        End If
        ToolStripProgressBar1.ProgressBar.Value = xServerPingerManagerTimer
        ToolStripProgressBar1.ProgressBar.Refresh()
    End Sub
    Private Sub lstServers_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstServers.DoubleClick
        Call ViewData()
    End Sub
    Private Sub AllDisabledServersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllDisabledServersToolStripMenuItem.Click
        frmView_Servers_Disabled.MdiParent = Me
        frmView_Servers_Disabled.Show()
    End Sub
    Private Sub InstallAsServiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstallAsServiceToolStripMenuItem.Click
        Try
            Dim myProcess As New Process
            myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
            myProcess.StartInfo.FileName = "ins.bat"
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            myProcess.Start()
            myProcess.WaitForExit()
            MsgBox("Service was installed!")
        Catch ex As Exception
            MsgBox("Unable to Install the Service!")
        End Try
    End Sub
    Private Sub RemoveServiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveServiceToolStripMenuItem.Click
        Try
            Dim myProcess As New Process
            myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
            myProcess.StartInfo.FileName = "uins.bat"
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            myProcess.Start()
            myProcess.WaitForExit()
            MsgBox("Service was removed")
        Catch ex As Exception
            MsgBox("Unable to uninstall Service")
        End Try
    End Sub
    Private Sub AddTypeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddTypeToolStripMenuItem.Click
        frmAddServerType.MdiParent = Me
        frmAddServerType.Show()
    End Sub
    Private Sub DevicesWErrorsWarningsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DevicesWErrorsWarningsToolStripMenuItem.Click
        frmView_Servers_ErrorsOnly.MdiParent = Me
        frmView_Servers_ErrorsOnly.Show()
    End Sub
    Private Sub tmrLUP_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLUP.Tick
        ToolStripStatusLabel1.Text = "Last Update: " & LastUpdateTime()
    End Sub

    Sub ViewData()
        Dim SID As Long = lstServers.SelectedValue
        Dim frmNew As New frmView_Server_Details
        Dim ServerName As String = lstServers.Text
        frmNew.SID = SID
        frmNew.ServerName = ServerName
        frmNew.MdiParent = Me
        frmNew.Show()
    End Sub
    Private Sub PingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PingToolStripMenuItem.Click
        Try
            Dim ServerName As String = lstServers.Text
            Dim myProcess As New Process
            myProcess.StartInfo.FileName = "ping"
            myProcess.StartInfo.Arguments = " -t " & ServerName
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            myProcess.Start()
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "PingToolStripMenuItem_Click")
        End Try
    End Sub
    Private Sub PingIPAddressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PingIPAddressToolStripMenuItem.Click
        Try
            Dim ServerName As String = GetDeviceIP(lstServers.SelectedValue)
            Dim myProcess As New Process
            myProcess.StartInfo.FileName = "ping"
            myProcess.StartInfo.Arguments = " -t " & ServerName
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            myProcess.Start()
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "PingIPAddressToolStripMenuItem_Click")
        End Try
    End Sub
    Private Sub UpdateStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateStatusToolStripMenuItem.Click
        Try
            Dim ServerName As String = lstServers.Text
            Dim ServerID As String = lstServers.SelectedValue
            Dim sIP As String = GetDeviceIP(ServerID)
            Dim myProcess As New Process
            myProcess.StartInfo.FileName = Application.StartupPath & "\BSSM_Pinger.exe"
            myProcess.StartInfo.Arguments = " /server=" & ServerName & " /sid=" & ServerID & " /try=10 /IP=" & sIP
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            myProcess.Start()
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "UpdateStatusToolStripMenuItem_Click")
        End Try
    End Sub
    Private Sub ViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewToolStripMenuItem.Click
        Call ViewData()
    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub AddCollectorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddCollectorToolStripMenuItem.Click
        frmAddCollector.MdiParent = Me
        frmAddCollector.Show()
    End Sub
    Private Sub CollectorListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CollectorListToolStripMenuItem.Click
        frmView_Collectors.MdiParent = Me
        frmView_Collectors.Show()
    End Sub
    Private Sub TypeListsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TypeListsToolStripMenuItem.Click
        View_Types.MdiParent = Me
        View_Types.Show()
    End Sub

    Private Sub ReportAllDevicesToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportAllDevicesToolStripMenuItem.Click
        frmView_Report_Device_List.MdiParent = Me
        frmView_Report_Device_List.Show()
    End Sub

    Private Sub DeleteDevicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteDevicesToolStripMenuItem.Click
        frmView_Report_Device_Deleted_list.MdiParent = Me
        frmView_Report_Device_Deleted_list.Show()
    End Sub

    Private Sub DisabledDevicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisabledDevicesToolStripMenuItem.Click
        frmView_Report_Device_Disabled_List.MdiParent = Me
        frmView_Report_Device_Disabled_List.Show()
    End Sub

    Private Sub DownDevicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownDevicesToolStripMenuItem.Click
        frmView_Report_Device_Down_List.MdiParent = Me
        frmView_Report_Device_Down_List.Show()
    End Sub

    Private Sub WaringsErrorsDevicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WaringsErrorsDevicesToolStripMenuItem.Click
        frmView_Report_Device_Errors_Down_List.MdiParent = Me
        frmView_Report_Device_Errors_Down_List.Show()
    End Sub

    Private Sub UpDevicesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDevicesToolStripMenuItem.Click
        frmView_Report_Device_UP_list.MdiParent = Me
        frmView_Report_Device_UP_list.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim frmnew As New frmAboutBox
        frmnew.MdiParent = Me
        frmnew.Show()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Dim frmNew As New frmSearch
        frmNew.MdiParent = Me
        frmNew.Show()
    End Sub

    Private Sub DisableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisableToolStripMenuItem.Click
        Dim ServerName As String = lstServers.Text
        Dim ServerID As String = lstServers.SelectedValue
        Dim SQL As String = "UPDATE list_servers set IsEnabled=0 where ID=" & ServerID
        Dim Obj As New BSDatabase
        Obj.MYCONNSTRING = sConn
        Obj.ConnExe(SQL)
        MsgBox(ServerName & " has been disabled!")
        Call LoadData()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub MonthlyUptimeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyUptimeToolStripMenuItem.Click
        Dim frmNew As New frmReport_View_Monthly_Uptime
        frmNew.MdiParent = Me
        frmNew.Show()
    End Sub

    Private Sub BurnSoftOpenSourceWebSiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BurnSoftOpenSourceWebSiteToolStripMenuItem.Click
        Dim myProcess As New Process
        myProcess.StartInfo.FileName = "http://www.burnsoft.net/Software_OpenSource.aspx?dir=BurnSoft_Server_Monitor"
        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
        myProcess.Start()
    End Sub

    Private Sub KnowledgeBaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KnowledgeBaseToolStripMenuItem.Click
        Dim myProcess As New Process
        myProcess.StartInfo.FileName = "http://wiki.burnsoft.net"
        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
        myProcess.Start()
    End Sub

    Private Sub lstServers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstServers.SelectedIndexChanged

    End Sub
End Class