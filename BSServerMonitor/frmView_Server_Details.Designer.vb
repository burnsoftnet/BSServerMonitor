<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView_Server_Details
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
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmView_Server_Details))
        Me.uptime_stats_dailyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BssmDataSet = New BSServerMonitor.bssmDataSet
        Me.uptime_stats_monthlyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.uptime_stats_yearlyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblCollector = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.chkIIPAC = New System.Windows.Forms.CheckBox
        Me.nudPings = New System.Windows.Forms.NumericUpDown
        Me.Label11 = New System.Windows.Forms.Label
        Me.chkHTTP = New System.Windows.Forms.CheckBox
        Me.chkPort = New System.Windows.Forms.CheckBox
        Me.chkTrace = New System.Windows.Forms.CheckBox
        Me.chkPing = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.ListserverstypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtType = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.chkEnabled = New System.Windows.Forms.CheckBox
        Me.txtDA = New System.Windows.Forms.TextBox
        Me.txtLS = New System.Windows.Forms.TextBox
        Me.txtIP = New System.Windows.Forms.TextBox
        Me.txtDisName = New System.Windows.Forms.TextBox
        Me.txtServerName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.IDDataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DTDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShrtEvDataGridViewTextBoxColumn = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.LngEvDataGridViewTextBoxColumn = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.SevDataGridViewTextBoxColumn = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.EventsgeneralBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DTIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PacketsSentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PacketsRecDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PacketsLostDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RoundTripMinDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RoundTripMaxDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RoundTripAvgDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UptimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewpingtimepingstatsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.DataGridView3 = New System.Windows.Forms.DataGridView
        Me.IDDataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PortDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ProtocolDataGridViewTextBoxColumn = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.CurrentStatus = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.IsMonitored = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.ListserversportsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabPage5 = New System.Windows.Forms.TabPage
        Me.DataGridView4 = New System.Windows.Forms.DataGridView
        Me.HopnoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TtlDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RttDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IpaddrDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmsTraceMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ResultstraceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TabPage6 = New System.Windows.Forms.TabPage
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.TabPage7 = New System.Windows.Forms.TabPage
        Me.ReportViewer2 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.TabPage8 = New System.Windows.Forms.TabPage
        Me.ReportViewer3 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.View_ping_timepingstatsTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.view_ping_timepingstatsTableAdapter
        Me.Events_generalTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.events_generalTableAdapter
        Me.List_servers_typesTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.list_servers_typesTableAdapter
        Me.List_servers_portsTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.list_servers_portsTableAdapter
        Me.Results_traceTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.results_traceTableAdapter
        Me.uptime_stats_dailyTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.uptime_stats_dailyTableAdapter
        Me.uptime_stats_monthlyTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.uptime_stats_monthlyTableAdapter
        Me.uptime_stats_yearlyTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.uptime_stats_yearlyTableAdapter
        CType(Me.uptime_stats_dailyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uptime_stats_monthlyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uptime_stats_yearlyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudPings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ListserverstypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EventsgeneralBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewpingtimepingstatsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListserversportsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsTraceMenu.SuspendLayout()
        CType(Me.ResultstraceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'uptime_stats_dailyBindingSource
        '
        Me.uptime_stats_dailyBindingSource.DataMember = "uptime_stats_daily"
        Me.uptime_stats_dailyBindingSource.DataSource = Me.BssmDataSet
        '
        'BssmDataSet
        '
        Me.BssmDataSet.DataSetName = "bssmDataSet"
        Me.BssmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'uptime_stats_monthlyBindingSource
        '
        Me.uptime_stats_monthlyBindingSource.DataMember = "uptime_stats_monthly"
        Me.uptime_stats_monthlyBindingSource.DataSource = Me.BssmDataSet
        '
        'uptime_stats_yearlyBindingSource
        '
        Me.uptime_stats_yearlyBindingSource.DataMember = "uptime_stats_yearly"
        Me.uptime_stats_yearlyBindingSource.DataSource = Me.BssmDataSet
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Controls.Add(Me.TabPage7)
        Me.TabControl1.Controls.Add(Me.TabPage8)
        Me.TabControl1.Location = New System.Drawing.Point(2, 28)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(599, 341)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(591, 315)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Details"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblCollector)
        Me.GroupBox3.Location = New System.Drawing.Point(303, 191)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(206, 46)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Collector"
        '
        'lblCollector
        '
        Me.lblCollector.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCollector.Location = New System.Drawing.Point(9, 16)
        Me.lblCollector.Name = "lblCollector"
        Me.lblCollector.Size = New System.Drawing.Size(191, 23)
        Me.lblCollector.TabIndex = 0
        Me.lblCollector.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.chkIIPAC)
        Me.GroupBox2.Controls.Add(Me.nudPings)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.chkHTTP)
        Me.GroupBox2.Controls.Add(Me.chkPort)
        Me.GroupBox2.Controls.Add(Me.chkTrace)
        Me.GroupBox2.Controls.Add(Me.chkPing)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(303, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(206, 171)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tests"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 143)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(136, 13)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Ignore IP Address Changes"
        '
        'chkIIPAC
        '
        Me.chkIIPAC.AutoSize = True
        Me.chkIIPAC.Location = New System.Drawing.Point(145, 142)
        Me.chkIIPAC.Name = "chkIIPAC"
        Me.chkIIPAC.Size = New System.Drawing.Size(44, 17)
        Me.chkIIPAC.TabIndex = 20
        Me.chkIIPAC.Text = "Yes"
        Me.chkIIPAC.UseVisualStyleBackColor = True
        '
        'nudPings
        '
        Me.nudPings.Enabled = False
        Me.nudPings.Location = New System.Drawing.Point(145, 50)
        Me.nudPings.Name = "nudPings"
        Me.nudPings.ReadOnly = True
        Me.nudPings.Size = New System.Drawing.Size(44, 20)
        Me.nudPings.TabIndex = 19
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 13)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Attempts"
        '
        'chkHTTP
        '
        Me.chkHTTP.AutoSize = True
        Me.chkHTTP.Location = New System.Drawing.Point(145, 123)
        Me.chkHTTP.Name = "chkHTTP"
        Me.chkHTTP.Size = New System.Drawing.Size(44, 17)
        Me.chkHTTP.TabIndex = 17
        Me.chkHTTP.Text = "Yes"
        Me.chkHTTP.UseVisualStyleBackColor = True
        '
        'chkPort
        '
        Me.chkPort.AutoSize = True
        Me.chkPort.Location = New System.Drawing.Point(145, 100)
        Me.chkPort.Name = "chkPort"
        Me.chkPort.Size = New System.Drawing.Size(44, 17)
        Me.chkPort.TabIndex = 16
        Me.chkPort.Text = "Yes"
        Me.chkPort.UseVisualStyleBackColor = True
        '
        'chkTrace
        '
        Me.chkTrace.AutoSize = True
        Me.chkTrace.Location = New System.Drawing.Point(145, 77)
        Me.chkTrace.Name = "chkTrace"
        Me.chkTrace.Size = New System.Drawing.Size(44, 17)
        Me.chkTrace.TabIndex = 15
        Me.chkTrace.Text = "Yes"
        Me.chkTrace.UseVisualStyleBackColor = True
        '
        'chkPing
        '
        Me.chkPing.AutoSize = True
        Me.chkPing.Location = New System.Drawing.Point(145, 28)
        Me.chkPing.Name = "chkPing"
        Me.chkPing.Size = New System.Drawing.Size(44, 17)
        Me.chkPing.TabIndex = 14
        Me.chkPing.Text = "Yes"
        Me.chkPing.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 124)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "HTTP Tests:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Collect Port Info:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Collect Trace Data:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Ping Tests:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.txtType)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.chkEnabled)
        Me.GroupBox1.Controls.Add(Me.txtDA)
        Me.GroupBox1.Controls.Add(Me.txtLS)
        Me.GroupBox1.Controls.Add(Me.txtIP)
        Me.GroupBox1.Controls.Add(Me.txtDisName)
        Me.GroupBox1.Controls.Add(Me.txtServerName)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(282, 217)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Information"
        '
        'ComboBox1
        '
        Me.ComboBox1.DataSource = Me.ListserverstypesBindingSource
        Me.ComboBox1.DisplayMember = "Cat"
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(94, 176)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(154, 21)
        Me.ComboBox1.TabIndex = 20
        Me.ComboBox1.ValueMember = "ID"
        Me.ComboBox1.Visible = False
        '
        'ListserverstypesBindingSource
        '
        Me.ListserverstypesBindingSource.DataMember = "list_servers_types"
        Me.ListserverstypesBindingSource.DataSource = Me.BssmDataSet
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(94, 177)
        Me.txtType.Name = "txtType"
        Me.txtType.ReadOnly = True
        Me.txtType.Size = New System.Drawing.Size(154, 20)
        Me.txtType.TabIndex = 19
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 180)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "Type:"
        '
        'chkEnabled
        '
        Me.chkEnabled.AutoSize = True
        Me.chkEnabled.Location = New System.Drawing.Point(94, 158)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(44, 17)
        Me.chkEnabled.TabIndex = 17
        Me.chkEnabled.Text = "Yes"
        Me.chkEnabled.UseVisualStyleBackColor = True
        '
        'txtDA
        '
        Me.txtDA.Location = New System.Drawing.Point(94, 130)
        Me.txtDA.Name = "txtDA"
        Me.txtDA.ReadOnly = True
        Me.txtDA.Size = New System.Drawing.Size(154, 20)
        Me.txtDA.TabIndex = 16
        '
        'txtLS
        '
        Me.txtLS.Location = New System.Drawing.Point(94, 104)
        Me.txtLS.Name = "txtLS"
        Me.txtLS.ReadOnly = True
        Me.txtLS.Size = New System.Drawing.Size(154, 20)
        Me.txtLS.TabIndex = 15
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(94, 78)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.ReadOnly = True
        Me.txtIP.Size = New System.Drawing.Size(154, 20)
        Me.txtIP.TabIndex = 14
        '
        'txtDisName
        '
        Me.txtDisName.Location = New System.Drawing.Point(94, 52)
        Me.txtDisName.Name = "txtDisName"
        Me.txtDisName.ReadOnly = True
        Me.txtDisName.Size = New System.Drawing.Size(154, 20)
        Me.txtDisName.TabIndex = 13
        '
        'txtServerName
        '
        Me.txtServerName.Location = New System.Drawing.Point(94, 26)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.ReadOnly = True
        Me.txtServerName.Size = New System.Drawing.Size(154, 20)
        Me.txtServerName.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 158)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Enabled:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Date Added:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Last Status:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "IP Address:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Display Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Server Name:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.DataGridView2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(591, 315)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Events"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AutoGenerateColumns = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn1, Me.DTDataGridViewTextBoxColumn, Me.ShrtEvDataGridViewTextBoxColumn, Me.LngEvDataGridViewTextBoxColumn, Me.SevDataGridViewTextBoxColumn})
        Me.DataGridView2.DataSource = Me.EventsgeneralBindingSource
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(591, 315)
        Me.DataGridView2.TabIndex = 0
        '
        'IDDataGridViewTextBoxColumn1
        '
        Me.IDDataGridViewTextBoxColumn1.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn1.FillWeight = 2.0!
        Me.IDDataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn1.MinimumWidth = 2
        Me.IDDataGridViewTextBoxColumn1.Name = "IDDataGridViewTextBoxColumn1"
        Me.IDDataGridViewTextBoxColumn1.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn1.Visible = False
        Me.IDDataGridViewTextBoxColumn1.Width = 2
        '
        'DTDataGridViewTextBoxColumn
        '
        Me.DTDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DTDataGridViewTextBoxColumn.DataPropertyName = "DT"
        Me.DTDataGridViewTextBoxColumn.HeaderText = "Date Time"
        Me.DTDataGridViewTextBoxColumn.Name = "DTDataGridViewTextBoxColumn"
        Me.DTDataGridViewTextBoxColumn.ReadOnly = True
        Me.DTDataGridViewTextBoxColumn.Width = 81
        '
        'ShrtEvDataGridViewTextBoxColumn
        '
        Me.ShrtEvDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ShrtEvDataGridViewTextBoxColumn.DataPropertyName = "shrtEv"
        Me.ShrtEvDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.ShrtEvDataGridViewTextBoxColumn.Name = "ShrtEvDataGridViewTextBoxColumn"
        Me.ShrtEvDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShrtEvDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ShrtEvDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.ShrtEvDataGridViewTextBoxColumn.Width = 85
        '
        'LngEvDataGridViewTextBoxColumn
        '
        Me.LngEvDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LngEvDataGridViewTextBoxColumn.DataPropertyName = "lngEv"
        Me.LngEvDataGridViewTextBoxColumn.HeaderText = "Details"
        Me.LngEvDataGridViewTextBoxColumn.Name = "LngEvDataGridViewTextBoxColumn"
        Me.LngEvDataGridViewTextBoxColumn.ReadOnly = True
        Me.LngEvDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LngEvDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.LngEvDataGridViewTextBoxColumn.Width = 64
        '
        'SevDataGridViewTextBoxColumn
        '
        Me.SevDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.SevDataGridViewTextBoxColumn.DataPropertyName = "Sev"
        Me.SevDataGridViewTextBoxColumn.HeaderText = "Severity"
        Me.SevDataGridViewTextBoxColumn.Name = "SevDataGridViewTextBoxColumn"
        Me.SevDataGridViewTextBoxColumn.ReadOnly = True
        Me.SevDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SevDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.SevDataGridViewTextBoxColumn.Width = 70
        '
        'EventsgeneralBindingSource
        '
        Me.EventsgeneralBindingSource.DataMember = "events_general"
        Me.EventsgeneralBindingSource.DataSource = Me.BssmDataSet
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(591, 315)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Ping Results"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.DTIDDataGridViewTextBoxColumn, Me.LsDataGridViewTextBoxColumn, Me.PacketsSentDataGridViewTextBoxColumn, Me.PacketsRecDataGridViewTextBoxColumn, Me.PacketsLostDataGridViewTextBoxColumn, Me.RoundTripMinDataGridViewTextBoxColumn, Me.RoundTripMaxDataGridViewTextBoxColumn, Me.RoundTripAvgDataGridViewTextBoxColumn, Me.UptimeDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ViewpingtimepingstatsBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(585, 309)
        Me.DataGridView1.TabIndex = 0
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.FillWeight = 1.0!
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.MinimumWidth = 2
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Visible = False
        Me.IDDataGridViewTextBoxColumn.Width = 2
        '
        'DTIDDataGridViewTextBoxColumn
        '
        Me.DTIDDataGridViewTextBoxColumn.DataPropertyName = "DTID"
        Me.DTIDDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DTIDDataGridViewTextBoxColumn.Name = "DTIDDataGridViewTextBoxColumn"
        Me.DTIDDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LsDataGridViewTextBoxColumn
        '
        Me.LsDataGridViewTextBoxColumn.DataPropertyName = "ls"
        Me.LsDataGridViewTextBoxColumn.HeaderText = "Last Status"
        Me.LsDataGridViewTextBoxColumn.Name = "LsDataGridViewTextBoxColumn"
        Me.LsDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PacketsSentDataGridViewTextBoxColumn
        '
        Me.PacketsSentDataGridViewTextBoxColumn.DataPropertyName = "Packets_Sent"
        Me.PacketsSentDataGridViewTextBoxColumn.HeaderText = "Packets Sent"
        Me.PacketsSentDataGridViewTextBoxColumn.Name = "PacketsSentDataGridViewTextBoxColumn"
        Me.PacketsSentDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PacketsRecDataGridViewTextBoxColumn
        '
        Me.PacketsRecDataGridViewTextBoxColumn.DataPropertyName = "Packets_Rec"
        Me.PacketsRecDataGridViewTextBoxColumn.HeaderText = "Packets Recieved"
        Me.PacketsRecDataGridViewTextBoxColumn.Name = "PacketsRecDataGridViewTextBoxColumn"
        Me.PacketsRecDataGridViewTextBoxColumn.ReadOnly = True
        '
        'PacketsLostDataGridViewTextBoxColumn
        '
        Me.PacketsLostDataGridViewTextBoxColumn.DataPropertyName = "Packets_Lost"
        Me.PacketsLostDataGridViewTextBoxColumn.HeaderText = "Packets Lost"
        Me.PacketsLostDataGridViewTextBoxColumn.Name = "PacketsLostDataGridViewTextBoxColumn"
        Me.PacketsLostDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RoundTripMinDataGridViewTextBoxColumn
        '
        Me.RoundTripMinDataGridViewTextBoxColumn.DataPropertyName = "RoundTrip_Min"
        Me.RoundTripMinDataGridViewTextBoxColumn.HeaderText = "RoundTrip Min"
        Me.RoundTripMinDataGridViewTextBoxColumn.Name = "RoundTripMinDataGridViewTextBoxColumn"
        Me.RoundTripMinDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RoundTripMaxDataGridViewTextBoxColumn
        '
        Me.RoundTripMaxDataGridViewTextBoxColumn.DataPropertyName = "RoundTrip_Max"
        Me.RoundTripMaxDataGridViewTextBoxColumn.HeaderText = "RoundTrip Max"
        Me.RoundTripMaxDataGridViewTextBoxColumn.Name = "RoundTripMaxDataGridViewTextBoxColumn"
        Me.RoundTripMaxDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RoundTripAvgDataGridViewTextBoxColumn
        '
        Me.RoundTripAvgDataGridViewTextBoxColumn.DataPropertyName = "RoundTrip_Avg"
        Me.RoundTripAvgDataGridViewTextBoxColumn.HeaderText = "RoundTrip Avg"
        Me.RoundTripAvgDataGridViewTextBoxColumn.Name = "RoundTripAvgDataGridViewTextBoxColumn"
        Me.RoundTripAvgDataGridViewTextBoxColumn.ReadOnly = True
        '
        'UptimeDataGridViewTextBoxColumn
        '
        Me.UptimeDataGridViewTextBoxColumn.DataPropertyName = "uptime"
        Me.UptimeDataGridViewTextBoxColumn.HeaderText = "uptime"
        Me.UptimeDataGridViewTextBoxColumn.Name = "UptimeDataGridViewTextBoxColumn"
        Me.UptimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ViewpingtimepingstatsBindingSource
        '
        Me.ViewpingtimepingstatsBindingSource.DataMember = "view_ping_timepingstats"
        Me.ViewpingtimepingstatsBindingSource.DataSource = Me.BssmDataSet
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.DataGridView3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(591, 315)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Active Ports"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.AutoGenerateColumns = False
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn2, Me.PortDataGridViewTextBoxColumn, Me.ProtocolDataGridViewTextBoxColumn, Me.CurrentStatus, Me.IsMonitored})
        Me.DataGridView3.DataSource = Me.ListserversportsBindingSource
        Me.DataGridView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView3.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView3.Size = New System.Drawing.Size(585, 309)
        Me.DataGridView3.TabIndex = 0
        '
        'IDDataGridViewTextBoxColumn2
        '
        Me.IDDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IDDataGridViewTextBoxColumn2.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn2.FillWeight = 2.0!
        Me.IDDataGridViewTextBoxColumn2.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn2.MinimumWidth = 2
        Me.IDDataGridViewTextBoxColumn2.Name = "IDDataGridViewTextBoxColumn2"
        Me.IDDataGridViewTextBoxColumn2.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn2.Visible = False
        Me.IDDataGridViewTextBoxColumn2.Width = 3
        '
        'PortDataGridViewTextBoxColumn
        '
        Me.PortDataGridViewTextBoxColumn.DataPropertyName = "Port"
        Me.PortDataGridViewTextBoxColumn.HeaderText = "Port"
        Me.PortDataGridViewTextBoxColumn.Name = "PortDataGridViewTextBoxColumn"
        Me.PortDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ProtocolDataGridViewTextBoxColumn
        '
        Me.ProtocolDataGridViewTextBoxColumn.DataPropertyName = "protocol"
        Me.ProtocolDataGridViewTextBoxColumn.HeaderText = "protocol"
        Me.ProtocolDataGridViewTextBoxColumn.Name = "ProtocolDataGridViewTextBoxColumn"
        Me.ProtocolDataGridViewTextBoxColumn.ReadOnly = True
        Me.ProtocolDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProtocolDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'CurrentStatus
        '
        Me.CurrentStatus.DataPropertyName = "CurrentStatus"
        Me.CurrentStatus.HeaderText = "CurrentStatus"
        Me.CurrentStatus.Name = "CurrentStatus"
        Me.CurrentStatus.ReadOnly = True
        Me.CurrentStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'IsMonitored
        '
        Me.IsMonitored.DataPropertyName = "IsMonitored"
        Me.IsMonitored.HeaderText = "IsMonitored"
        Me.IsMonitored.Name = "IsMonitored"
        Me.IsMonitored.ReadOnly = True
        Me.IsMonitored.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'ListserversportsBindingSource
        '
        Me.ListserversportsBindingSource.DataMember = "list_servers_ports"
        Me.ListserversportsBindingSource.DataSource = Me.BssmDataSet
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.DataGridView4)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(591, 315)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Trace Results"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'DataGridView4
        '
        Me.DataGridView4.AllowUserToAddRows = False
        Me.DataGridView4.AllowUserToDeleteRows = False
        Me.DataGridView4.AutoGenerateColumns = False
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HopnoDataGridViewTextBoxColumn, Me.TtlDataGridViewTextBoxColumn, Me.RttDataGridViewTextBoxColumn, Me.IpaddrDataGridViewTextBoxColumn})
        Me.DataGridView4.ContextMenuStrip = Me.cmsTraceMenu
        Me.DataGridView4.DataSource = Me.ResultstraceBindingSource
        Me.DataGridView4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView4.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.ReadOnly = True
        Me.DataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView4.Size = New System.Drawing.Size(591, 315)
        Me.DataGridView4.TabIndex = 0
        '
        'HopnoDataGridViewTextBoxColumn
        '
        Me.HopnoDataGridViewTextBoxColumn.DataPropertyName = "hopno"
        Me.HopnoDataGridViewTextBoxColumn.HeaderText = "Hop No."
        Me.HopnoDataGridViewTextBoxColumn.Name = "HopnoDataGridViewTextBoxColumn"
        Me.HopnoDataGridViewTextBoxColumn.ReadOnly = True
        '
        'TtlDataGridViewTextBoxColumn
        '
        Me.TtlDataGridViewTextBoxColumn.DataPropertyName = "ttl"
        Me.TtlDataGridViewTextBoxColumn.HeaderText = "TTL"
        Me.TtlDataGridViewTextBoxColumn.Name = "TtlDataGridViewTextBoxColumn"
        Me.TtlDataGridViewTextBoxColumn.ReadOnly = True
        '
        'RttDataGridViewTextBoxColumn
        '
        Me.RttDataGridViewTextBoxColumn.DataPropertyName = "rtt"
        Me.RttDataGridViewTextBoxColumn.HeaderText = "RTT"
        Me.RttDataGridViewTextBoxColumn.Name = "RttDataGridViewTextBoxColumn"
        Me.RttDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IpaddrDataGridViewTextBoxColumn
        '
        Me.IpaddrDataGridViewTextBoxColumn.DataPropertyName = "ipaddr"
        Me.IpaddrDataGridViewTextBoxColumn.HeaderText = "IP Address"
        Me.IpaddrDataGridViewTextBoxColumn.Name = "IpaddrDataGridViewTextBoxColumn"
        Me.IpaddrDataGridViewTextBoxColumn.ReadOnly = True
        '
        'cmsTraceMenu
        '
        Me.cmsTraceMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PingToolStripMenuItem})
        Me.cmsTraceMenu.Name = "cmsTraceMenu"
        Me.cmsTraceMenu.Size = New System.Drawing.Size(106, 26)
        '
        'PingToolStripMenuItem
        '
        Me.PingToolStripMenuItem.Name = "PingToolStripMenuItem"
        Me.PingToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.PingToolStripMenuItem.Text = "Ping"
        '
        'ResultstraceBindingSource
        '
        Me.ResultstraceBindingSource.DataMember = "results_trace"
        Me.ResultstraceBindingSource.DataSource = Me.BssmDataSet
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.ReportViewer1)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(591, 315)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Daily Uptime"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource4.Name = "bssmDataSet_uptime_stats_daily"
        ReportDataSource4.Value = Me.uptime_stats_dailyBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "BSServerMonitor.Report_Device_Daily.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(3, 3)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(585, 309)
        Me.ReportViewer1.TabIndex = 0
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.ReportViewer2)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(591, 315)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Monthly Uptime"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'ReportViewer2
        '
        Me.ReportViewer2.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource5.Name = "bssmDataSet_uptime_stats_monthly"
        ReportDataSource5.Value = Me.uptime_stats_monthlyBindingSource
        Me.ReportViewer2.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewer2.LocalReport.ReportEmbeddedResource = "BSServerMonitor.Report_Device_monthly.rdlc"
        Me.ReportViewer2.Location = New System.Drawing.Point(3, 3)
        Me.ReportViewer2.Name = "ReportViewer2"
        Me.ReportViewer2.Size = New System.Drawing.Size(585, 309)
        Me.ReportViewer2.TabIndex = 0
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.ReportViewer3)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Size = New System.Drawing.Size(591, 315)
        Me.TabPage8.TabIndex = 7
        Me.TabPage8.Text = "Yearly Uptime"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'ReportViewer3
        '
        Me.ReportViewer3.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource6.Name = "bssmDataSet_uptime_stats_yearly"
        ReportDataSource6.Value = Me.uptime_stats_yearlyBindingSource
        Me.ReportViewer3.LocalReport.DataSources.Add(ReportDataSource6)
        Me.ReportViewer3.LocalReport.ReportEmbeddedResource = "BSServerMonitor.Report_Device_yearly.rdlc"
        Me.ReportViewer3.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer3.Name = "ReportViewer3"
        Me.ReportViewer3.Size = New System.Drawing.Size(591, 315)
        Me.ReportViewer3.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.ToolStripSeparator3, Me.ToolStripLabel1, Me.ToolStripTextBox1, Me.ToolStripLabel2, Me.ToolStripButton5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(741, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = Global.BSServerMonitor.My.Resources.Resources.Notification_20__20Shutdown_2016_20n_20p
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Close Window"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Edit"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Enabled = False
        Me.ToolStripButton2.Image = Global.BSServerMonitor.My.Resources.Resources.Winxpicons_Disk_2_32x32
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.BSServerMonitor.My.Resources.Resources.DELETE_1
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Delete Server"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(30, 22)
        Me.ToolStripLabel1.Text = "Last "
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripLabel2.Text = "Results"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = Global.BSServerMonitor.My.Resources.Resources.refresh
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Refresh Results"
        '
        'View_ping_timepingstatsTableAdapter
        '
        Me.View_ping_timepingstatsTableAdapter.ClearBeforeFill = True
        '
        'Events_generalTableAdapter
        '
        Me.Events_generalTableAdapter.ClearBeforeFill = True
        '
        'List_servers_typesTableAdapter
        '
        Me.List_servers_typesTableAdapter.ClearBeforeFill = True
        '
        'List_servers_portsTableAdapter
        '
        Me.List_servers_portsTableAdapter.ClearBeforeFill = True
        '
        'Results_traceTableAdapter
        '
        Me.Results_traceTableAdapter.ClearBeforeFill = True
        '
        'uptime_stats_dailyTableAdapter
        '
        Me.uptime_stats_dailyTableAdapter.ClearBeforeFill = True
        '
        'uptime_stats_monthlyTableAdapter
        '
        Me.uptime_stats_monthlyTableAdapter.ClearBeforeFill = True
        '
        'uptime_stats_yearlyTableAdapter
        '
        Me.uptime_stats_yearlyTableAdapter.ClearBeforeFill = True
        '
        'frmView_Server_Details
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(741, 425)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmView_Server_Details"
        Me.Text = "frmView_Server_Details"
        CType(Me.uptime_stats_dailyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uptime_stats_monthlyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uptime_stats_yearlyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudPings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ListserverstypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EventsgeneralBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewpingtimepingstatsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListserversportsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsTraceMenu.ResumeLayout(False)
        CType(Me.ResultstraceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage8.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents txtDA As System.Windows.Forms.TextBox
    Friend WithEvents txtLS As System.Windows.Forms.TextBox
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents txtDisName As System.Windows.Forms.TextBox
    Friend WithEvents txtServerName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkHTTP As System.Windows.Forms.CheckBox
    Friend WithEvents chkPort As System.Windows.Forms.CheckBox
    Friend WithEvents chkTrace As System.Windows.Forms.CheckBox
    Friend WithEvents chkPing As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BssmDataSet As BSServerMonitor.bssmDataSet
    Friend WithEvents ViewpingtimepingstatsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents View_ping_timepingstatsTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.view_ping_timepingstatsTableAdapter
    Friend WithEvents nudPings As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents EventsgeneralBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Events_generalTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.events_generalTableAdapter
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DTIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PacketsSentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PacketsRecDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PacketsLostDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RoundTripMinDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RoundTripMaxDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RoundTripAvgDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UptimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtType As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCollector As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkIIPAC As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ListserverstypesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents List_servers_typesTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.list_servers_typesTableAdapter
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents ListserversportsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents List_servers_portsTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.list_servers_portsTableAdapter
    Friend WithEvents DataGridView4 As System.Windows.Forms.DataGridView
    Friend WithEvents ResultstraceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Results_traceTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.results_traceTableAdapter
    Friend WithEvents IDDataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PortDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProtocolDataGridViewTextBoxColumn As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents CurrentStatus As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents IsMonitored As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents HopnoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TtlDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RttDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IpaddrDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmsTraceMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents uptime_stats_dailyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents uptime_stats_dailyTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.uptime_stats_dailyTableAdapter
    Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
    Friend WithEvents ReportViewer2 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents uptime_stats_monthlyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents uptime_stats_monthlyTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.uptime_stats_monthlyTableAdapter
    Friend WithEvents IDDataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DTDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShrtEvDataGridViewTextBoxColumn As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents LngEvDataGridViewTextBoxColumn As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents SevDataGridViewTextBoxColumn As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents TabPage8 As System.Windows.Forms.TabPage
    Friend WithEvents ReportViewer3 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents uptime_stats_yearlyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents uptime_stats_yearlyTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.uptime_stats_yearlyTableAdapter
End Class
