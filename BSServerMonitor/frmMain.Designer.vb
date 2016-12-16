<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AddItemsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AddServerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AddTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddCollectorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AllServersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AllDownServersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AllDisabledServersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DevicesWErrorsWarningsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.CollectorListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TypeListsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RunServerPingerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ASAPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InstallAsServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RunOnTimerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.RemoveServiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportAllDevicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UpDevicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DisabledDevicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteDevicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WaringsErrorsDevicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DownDevicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MonthlyUptimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.WindowsMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.NewWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ArrangeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BurnSoftOpenSourceWebSiteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.KnowledgeBaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CommandsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RunServerPingerManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.KeepOnTopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RunOnDemandToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RunOnTimerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ServerDownListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblSrvCount = New System.Windows.Forms.Label
        Me.lstServers = New System.Windows.Forms.ListBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PingIPAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UpdateStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DisableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ListserversBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BssmDataSet = New BSServerMonitor.bssmDataSet
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tmrServerPingerManager = New System.Windows.Forms.Timer(Me.components)
        Me.List_serversTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.list_serversTableAdapter
        Me.tmrLUP = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ListserversBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1, Me.AddItemsToolStripMenuItem1, Me.ViewToolStripMenuItem1, Me.SearchToolStripMenuItem, Me.ActionsToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.WindowsMenu, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(157, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(525, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem1.Text = "&File"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Image = Global.BSServerMonitor.My.Resources.Resources.Notification_20__20Shutdown_2016_20n_20p
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(103, 22)
        Me.ExitToolStripMenuItem1.Text = "E&xit"
        '
        'AddItemsToolStripMenuItem1
        '
        Me.AddItemsToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddServerToolStripMenuItem1, Me.AddTypeToolStripMenuItem, Me.AddCollectorToolStripMenuItem})
        Me.AddItemsToolStripMenuItem1.Name = "AddItemsToolStripMenuItem1"
        Me.AddItemsToolStripMenuItem1.Size = New System.Drawing.Size(68, 20)
        Me.AddItemsToolStripMenuItem1.Text = "&Add Items"
        '
        'AddServerToolStripMenuItem1
        '
        Me.AddServerToolStripMenuItem1.Image = Global.BSServerMonitor.My.Resources.Resources.add_16_x_161
        Me.AddServerToolStripMenuItem1.Name = "AddServerToolStripMenuItem1"
        Me.AddServerToolStripMenuItem1.Size = New System.Drawing.Size(149, 22)
        Me.AddServerToolStripMenuItem1.Text = "Add &Device"
        '
        'AddTypeToolStripMenuItem
        '
        Me.AddTypeToolStripMenuItem.Name = "AddTypeToolStripMenuItem"
        Me.AddTypeToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.AddTypeToolStripMenuItem.Text = "Add Type"
        '
        'AddCollectorToolStripMenuItem
        '
        Me.AddCollectorToolStripMenuItem.Name = "AddCollectorToolStripMenuItem"
        Me.AddCollectorToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.AddCollectorToolStripMenuItem.Text = "Add Collector"
        '
        'ViewToolStripMenuItem1
        '
        Me.ViewToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AllServersToolStripMenuItem, Me.AllDownServersToolStripMenuItem, Me.AllDisabledServersToolStripMenuItem, Me.DevicesWErrorsWarningsToolStripMenuItem, Me.ToolStripSeparator1, Me.CollectorListToolStripMenuItem, Me.TypeListsToolStripMenuItem})
        Me.ViewToolStripMenuItem1.Name = "ViewToolStripMenuItem1"
        Me.ViewToolStripMenuItem1.Size = New System.Drawing.Size(41, 20)
        Me.ViewToolStripMenuItem1.Text = "&View"
        '
        'AllServersToolStripMenuItem
        '
        Me.AllServersToolStripMenuItem.Name = "AllServersToolStripMenuItem"
        Me.AllServersToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.AllServersToolStripMenuItem.Text = "All Devices"
        '
        'AllDownServersToolStripMenuItem
        '
        Me.AllDownServersToolStripMenuItem.Name = "AllDownServersToolStripMenuItem"
        Me.AllDownServersToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.AllDownServersToolStripMenuItem.Text = "All Down Devices"
        '
        'AllDisabledServersToolStripMenuItem
        '
        Me.AllDisabledServersToolStripMenuItem.Name = "AllDisabledServersToolStripMenuItem"
        Me.AllDisabledServersToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.AllDisabledServersToolStripMenuItem.Text = "All Disabled Devices"
        '
        'DevicesWErrorsWarningsToolStripMenuItem
        '
        Me.DevicesWErrorsWarningsToolStripMenuItem.Name = "DevicesWErrorsWarningsToolStripMenuItem"
        Me.DevicesWErrorsWarningsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.DevicesWErrorsWarningsToolStripMenuItem.Text = "Devices w/ Errors && Warnings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(224, 6)
        '
        'CollectorListToolStripMenuItem
        '
        Me.CollectorListToolStripMenuItem.Name = "CollectorListToolStripMenuItem"
        Me.CollectorListToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.CollectorListToolStripMenuItem.Text = "Collector List"
        '
        'TypeListsToolStripMenuItem
        '
        Me.TypeListsToolStripMenuItem.Name = "TypeListsToolStripMenuItem"
        Me.TypeListsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.TypeListsToolStripMenuItem.Text = "Type Lists"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.SearchToolStripMenuItem.Text = "Search"
        '
        'ActionsToolStripMenuItem
        '
        Me.ActionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RunServerPingerToolStripMenuItem})
        Me.ActionsToolStripMenuItem.Name = "ActionsToolStripMenuItem"
        Me.ActionsToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ActionsToolStripMenuItem.Text = "Actions"
        '
        'RunServerPingerToolStripMenuItem
        '
        Me.RunServerPingerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ASAPToolStripMenuItem, Me.InstallAsServiceToolStripMenuItem, Me.RunOnTimerToolStripMenuItem1, Me.RemoveServiceToolStripMenuItem})
        Me.RunServerPingerToolStripMenuItem.Name = "RunServerPingerToolStripMenuItem"
        Me.RunServerPingerToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.RunServerPingerToolStripMenuItem.Text = "Run Server Pinger"
        '
        'ASAPToolStripMenuItem
        '
        Me.ASAPToolStripMenuItem.Name = "ASAPToolStripMenuItem"
        Me.ASAPToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ASAPToolStripMenuItem.Text = "ASAP"
        '
        'InstallAsServiceToolStripMenuItem
        '
        Me.InstallAsServiceToolStripMenuItem.Name = "InstallAsServiceToolStripMenuItem"
        Me.InstallAsServiceToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.InstallAsServiceToolStripMenuItem.Text = "Install as Service"
        '
        'RunOnTimerToolStripMenuItem1
        '
        Me.RunOnTimerToolStripMenuItem1.CheckOnClick = True
        Me.RunOnTimerToolStripMenuItem1.Name = "RunOnTimerToolStripMenuItem1"
        Me.RunOnTimerToolStripMenuItem1.Size = New System.Drawing.Size(166, 22)
        Me.RunOnTimerToolStripMenuItem1.Text = "Run on Timer"
        '
        'RemoveServiceToolStripMenuItem
        '
        Me.RemoveServiceToolStripMenuItem.Name = "RemoveServiceToolStripMenuItem"
        Me.RemoveServiceToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.RemoveServiceToolStripMenuItem.Text = "Remove Service"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportAllDevicesToolStripMenuItem, Me.UpDevicesToolStripMenuItem, Me.DisabledDevicesToolStripMenuItem, Me.DeleteDevicesToolStripMenuItem, Me.WaringsErrorsDevicesToolStripMenuItem, Me.DownDevicesToolStripMenuItem, Me.MonthlyUptimeToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ReportAllDevicesToolStripMenuItem
        '
        Me.ReportAllDevicesToolStripMenuItem.Name = "ReportAllDevicesToolStripMenuItem"
        Me.ReportAllDevicesToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ReportAllDevicesToolStripMenuItem.Text = "All Devices"
        '
        'UpDevicesToolStripMenuItem
        '
        Me.UpDevicesToolStripMenuItem.Name = "UpDevicesToolStripMenuItem"
        Me.UpDevicesToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.UpDevicesToolStripMenuItem.Text = "Up Devices"
        '
        'DisabledDevicesToolStripMenuItem
        '
        Me.DisabledDevicesToolStripMenuItem.Name = "DisabledDevicesToolStripMenuItem"
        Me.DisabledDevicesToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.DisabledDevicesToolStripMenuItem.Text = "Disabled Devices"
        '
        'DeleteDevicesToolStripMenuItem
        '
        Me.DeleteDevicesToolStripMenuItem.Name = "DeleteDevicesToolStripMenuItem"
        Me.DeleteDevicesToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.DeleteDevicesToolStripMenuItem.Text = "Delete Devices"
        '
        'WaringsErrorsDevicesToolStripMenuItem
        '
        Me.WaringsErrorsDevicesToolStripMenuItem.Name = "WaringsErrorsDevicesToolStripMenuItem"
        Me.WaringsErrorsDevicesToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.WaringsErrorsDevicesToolStripMenuItem.Text = "Warings & Errors Devices"
        '
        'DownDevicesToolStripMenuItem
        '
        Me.DownDevicesToolStripMenuItem.Name = "DownDevicesToolStripMenuItem"
        Me.DownDevicesToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.DownDevicesToolStripMenuItem.Text = "Down Devices"
        '
        'MonthlyUptimeToolStripMenuItem
        '
        Me.MonthlyUptimeToolStripMenuItem.Name = "MonthlyUptimeToolStripMenuItem"
        Me.MonthlyUptimeToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.MonthlyUptimeToolStripMenuItem.Text = "Monthly Uptime"
        '
        'WindowsMenu
        '
        Me.WindowsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewWindowToolStripMenuItem, Me.CascadeToolStripMenuItem, Me.TileVerticalToolStripMenuItem, Me.TileHorizontalToolStripMenuItem, Me.CloseAllToolStripMenuItem, Me.ArrangeIconsToolStripMenuItem})
        Me.WindowsMenu.Name = "WindowsMenu"
        Me.WindowsMenu.Size = New System.Drawing.Size(62, 20)
        Me.WindowsMenu.Text = "&Windows"
        '
        'NewWindowToolStripMenuItem
        '
        Me.NewWindowToolStripMenuItem.Name = "NewWindowToolStripMenuItem"
        Me.NewWindowToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.NewWindowToolStripMenuItem.Text = "&New Window"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.CascadeToolStripMenuItem.Text = "&Cascade"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.TileVerticalToolStripMenuItem.Text = "Tile &Vertical"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.CloseAllToolStripMenuItem.Text = "C&lose All"
        '
        'ArrangeIconsToolStripMenuItem
        '
        Me.ArrangeIconsToolStripMenuItem.Name = "ArrangeIconsToolStripMenuItem"
        Me.ArrangeIconsToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ArrangeIconsToolStripMenuItem.Text = "&Arrange Icons"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.BurnSoftOpenSourceWebSiteToolStripMenuItem, Me.KnowledgeBaseToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'BurnSoftOpenSourceWebSiteToolStripMenuItem
        '
        Me.BurnSoftOpenSourceWebSiteToolStripMenuItem.Name = "BurnSoftOpenSourceWebSiteToolStripMenuItem"
        Me.BurnSoftOpenSourceWebSiteToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.BurnSoftOpenSourceWebSiteToolStripMenuItem.Text = "BurnSoft Open Source WebSite"
        '
        'KnowledgeBaseToolStripMenuItem
        '
        Me.KnowledgeBaseToolStripMenuItem.Name = "KnowledgeBaseToolStripMenuItem"
        Me.KnowledgeBaseToolStripMenuItem.Size = New System.Drawing.Size(235, 22)
        Me.KnowledgeBaseToolStripMenuItem.Text = "&Knowledge Base"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(157, 518)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(525, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar1.Visible = False
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(69, 17)
        Me.ToolStripStatusLabel1.Text = "Last Update:"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'AddItemsToolStripMenuItem
        '
        Me.AddItemsToolStripMenuItem.Name = "AddItemsToolStripMenuItem"
        Me.AddItemsToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.AddItemsToolStripMenuItem.Text = "&Add Items"
        '
        'AddServerToolStripMenuItem
        '
        Me.AddServerToolStripMenuItem.Name = "AddServerToolStripMenuItem"
        Me.AddServerToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddServerToolStripMenuItem.Text = "A&dd Server"
        '
        'CommandsToolStripMenuItem
        '
        Me.CommandsToolStripMenuItem.Name = "CommandsToolStripMenuItem"
        Me.CommandsToolStripMenuItem.Size = New System.Drawing.Size(71, 20)
        Me.CommandsToolStripMenuItem.Text = "C&ommands"
        '
        'RunServerPingerManagerToolStripMenuItem
        '
        Me.RunServerPingerManagerToolStripMenuItem.Name = "RunServerPingerManagerToolStripMenuItem"
        Me.RunServerPingerManagerToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.RunServerPingerManagerToolStripMenuItem.Text = "&Run Server Pinger Manager"
        '
        'KeepOnTopToolStripMenuItem
        '
        Me.KeepOnTopToolStripMenuItem.Name = "KeepOnTopToolStripMenuItem"
        Me.KeepOnTopToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.KeepOnTopToolStripMenuItem.Text = "&Keep on Top"
        '
        'RunOnDemandToolStripMenuItem
        '
        Me.RunOnDemandToolStripMenuItem.Name = "RunOnDemandToolStripMenuItem"
        Me.RunOnDemandToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.RunOnDemandToolStripMenuItem.Text = "R&un On Demand"
        '
        'RunOnTimerToolStripMenuItem
        '
        Me.RunOnTimerToolStripMenuItem.Name = "RunOnTimerToolStripMenuItem"
        Me.RunOnTimerToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.RunOnTimerToolStripMenuItem.Text = "Ru&n on Timer"
        '
        'DatabaseToolStripMenuItem
        '
        Me.DatabaseToolStripMenuItem.Name = "DatabaseToolStripMenuItem"
        Me.DatabaseToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.DatabaseToolStripMenuItem.Text = "&Database"
        '
        'DeleteDataToolStripMenuItem
        '
        Me.DeleteDataToolStripMenuItem.Name = "DeleteDataToolStripMenuItem"
        Me.DeleteDataToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteDataToolStripMenuItem.Text = "D&elete Data"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'ServerDownListToolStripMenuItem
        '
        Me.ServerDownListToolStripMenuItem.Name = "ServerDownListToolStripMenuItem"
        Me.ServerDownListToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.ServerDownListToolStripMenuItem.Text = "Server Down &List"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblSrvCount)
        Me.Panel1.Controls.Add(Me.lstServers)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(157, 540)
        Me.Panel1.TabIndex = 7
        '
        'lblSrvCount
        '
        Me.lblSrvCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSrvCount.Location = New System.Drawing.Point(12, 491)
        Me.lblSrvCount.Name = "lblSrvCount"
        Me.lblSrvCount.Size = New System.Drawing.Size(130, 23)
        Me.lblSrvCount.TabIndex = 7
        Me.lblSrvCount.Text = "# Servers"
        Me.lblSrvCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lstServers
        '
        Me.lstServers.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lstServers.DataSource = Me.ListserversBindingSource
        Me.lstServers.DisplayMember = "DisplayName"
        Me.lstServers.FormattingEnabled = True
        Me.lstServers.Location = New System.Drawing.Point(12, 57)
        Me.lstServers.Name = "lstServers"
        Me.lstServers.Size = New System.Drawing.Size(130, 420)
        Me.lstServers.TabIndex = 6
        Me.lstServers.ValueMember = "ID"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PingToolStripMenuItem, Me.PingIPAddressToolStripMenuItem, Me.UpdateStatusToolStripMenuItem, Me.ToolStripMenuItem1, Me.DisableToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(168, 114)
        '
        'PingToolStripMenuItem
        '
        Me.PingToolStripMenuItem.Name = "PingToolStripMenuItem"
        Me.PingToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.PingToolStripMenuItem.Text = "&Ping ServerName"
        '
        'PingIPAddressToolStripMenuItem
        '
        Me.PingIPAddressToolStripMenuItem.Name = "PingIPAddressToolStripMenuItem"
        Me.PingIPAddressToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.PingIPAddressToolStripMenuItem.Text = "Pi&ng IP Address"
        '
        'UpdateStatusToolStripMenuItem
        '
        Me.UpdateStatusToolStripMenuItem.Name = "UpdateStatusToolStripMenuItem"
        Me.UpdateStatusToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.UpdateStatusToolStripMenuItem.Text = "&Update Status"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.ToolStripMenuItem1.Text = "View"
        '
        'DisableToolStripMenuItem
        '
        Me.DisableToolStripMenuItem.Name = "DisableToolStripMenuItem"
        Me.DisableToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.DisableToolStripMenuItem.Text = "Disable"
        '
        'ListserversBindingSource
        '
        Me.ListserversBindingSource.DataMember = "list_servers"
        Me.ListserversBindingSource.DataSource = Me.BssmDataSet
        '
        'BssmDataSet
        '
        Me.BssmDataSet.DataSetName = "bssmDataSet"
        Me.BssmDataSet.EnforceConstraints = False
        Me.BssmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Location = New System.Drawing.Point(157, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(525, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tmrServerPingerManager
        '
        Me.tmrServerPingerManager.Interval = 1000
        '
        'List_serversTableAdapter
        '
        Me.List_serversTableAdapter.ClearBeforeFill = True
        '
        'tmrLUP
        '
        Me.tmrLUP.Enabled = True
        Me.tmrLUP.Interval = 30000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 540)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.Text = "Server Monitor Open Source Project"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ListserversBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CommandsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunServerPingerManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunOnDemandToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunOnTimerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KeepOnTopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DatabaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServerDownListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddItemsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddServerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllServersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllDownServersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lstServers As System.Windows.Forms.ListBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ActionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunServerPingerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ASAPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InstallAsServiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunOnTimerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrServerPingerManager As System.Windows.Forms.Timer
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents AllDisabledServersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RemoveServiceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddTypeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DevicesWErrorsWarningsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BssmDataSet As BSServerMonitor.bssmDataSet
    Friend WithEvents ListserversBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents List_serversTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.list_serversTableAdapter
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmrLUP As System.Windows.Forms.Timer
    Friend WithEvents lblSrvCount As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PingIPAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowsMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ArrangeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddCollectorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CollectorListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TypeListsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportAllDevicesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpDevicesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisabledDevicesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteDevicesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WaringsErrorsDevicesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownDevicesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisableToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonthlyUptimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BurnSoftOpenSourceWebSiteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KnowledgeBaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
