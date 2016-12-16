<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView_Servers_All
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmView_Servers_All))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ViewserversallBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BssmDataSet = New BSServerMonitor.bssmDataSet
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.View_servers_allTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.view_servers_allTableAdapter
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DisplayNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServerNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServerIPAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CSDataGridViewTextBoxColumn = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.CatDataGridViewTextBoxColumn = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.IsEnabledDataGridViewTextBoxColumn = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.DTAddedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DoPingDataGridViewTextBoxColumn = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.DoTraceDataGridViewTextBoxColumn = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.DoPortDataGridViewTextBoxColumn = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.DoHTTPDataGridViewTextBoxColumn = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewserversallBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton4, Me.ToolStripButton3, Me.ToolStripButton2, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(548, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.BSServerMonitor.My.Resources.Resources.refresh
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Refresh"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = Global.BSServerMonitor.My.Resources.Resources.start
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Start Refresh"
        Me.ToolStripButton4.ToolTipText = "Start Refresh"
        Me.ToolStripButton4.Visible = False
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.BSServerMonitor.My.Resources.Resources.pause1
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Pause Refresh"
        Me.ToolStripButton3.ToolTipText = "Pause Refresh Timer"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.BSServerMonitor.My.Resources.Resources.Notification_20__20Shutdown_2016_20n_20p
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Close"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(101, 22)
        Me.ToolStripLabel1.Text = "Number of Devices:"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(0, 22)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.DisplayNameDataGridViewTextBoxColumn, Me.ServerNameDataGridViewTextBoxColumn, Me.ServerIPAddressDataGridViewTextBoxColumn, Me.CSDataGridViewTextBoxColumn, Me.CatDataGridViewTextBoxColumn, Me.IsEnabledDataGridViewTextBoxColumn, Me.DTAddedDataGridViewTextBoxColumn, Me.DoPingDataGridViewTextBoxColumn, Me.DoTraceDataGridViewTextBoxColumn, Me.DoPortDataGridViewTextBoxColumn, Me.DoHTTPDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ViewserversallBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(548, 301)
        Me.DataGridView1.TabIndex = 2
        '
        'ViewserversallBindingSource
        '
        Me.ViewserversallBindingSource.DataMember = "view_servers_all"
        Me.ViewserversallBindingSource.DataSource = Me.BssmDataSet
        '
        'BssmDataSet
        '
        Me.BssmDataSet.DataSetName = "bssmDataSet"
        Me.BssmDataSet.EnforceConstraints = False
        Me.BssmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Enabled = True
        Me.tmrRefresh.Interval = 30000
        '
        'View_servers_allTableAdapter
        '
        Me.View_servers_allTableAdapter.ClearBeforeFill = True
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Visible = False
        '
        'DisplayNameDataGridViewTextBoxColumn
        '
        Me.DisplayNameDataGridViewTextBoxColumn.DataPropertyName = "DisplayName"
        Me.DisplayNameDataGridViewTextBoxColumn.HeaderText = "Display Name"
        Me.DisplayNameDataGridViewTextBoxColumn.Name = "DisplayNameDataGridViewTextBoxColumn"
        Me.DisplayNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ServerNameDataGridViewTextBoxColumn
        '
        Me.ServerNameDataGridViewTextBoxColumn.DataPropertyName = "ServerName"
        Me.ServerNameDataGridViewTextBoxColumn.HeaderText = "Server Name"
        Me.ServerNameDataGridViewTextBoxColumn.Name = "ServerNameDataGridViewTextBoxColumn"
        Me.ServerNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ServerIPAddressDataGridViewTextBoxColumn
        '
        Me.ServerIPAddressDataGridViewTextBoxColumn.DataPropertyName = "ServerIPAddress"
        Me.ServerIPAddressDataGridViewTextBoxColumn.HeaderText = "IP Address"
        Me.ServerIPAddressDataGridViewTextBoxColumn.Name = "ServerIPAddressDataGridViewTextBoxColumn"
        Me.ServerIPAddressDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CSDataGridViewTextBoxColumn
        '
        Me.CSDataGridViewTextBoxColumn.DataPropertyName = "CS"
        Me.CSDataGridViewTextBoxColumn.HeaderText = "Current Status"
        Me.CSDataGridViewTextBoxColumn.Name = "CSDataGridViewTextBoxColumn"
        Me.CSDataGridViewTextBoxColumn.ReadOnly = True
        Me.CSDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CSDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'CatDataGridViewTextBoxColumn
        '
        Me.CatDataGridViewTextBoxColumn.DataPropertyName = "Cat"
        Me.CatDataGridViewTextBoxColumn.HeaderText = "Type"
        Me.CatDataGridViewTextBoxColumn.Name = "CatDataGridViewTextBoxColumn"
        Me.CatDataGridViewTextBoxColumn.ReadOnly = True
        Me.CatDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CatDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'IsEnabledDataGridViewTextBoxColumn
        '
        Me.IsEnabledDataGridViewTextBoxColumn.DataPropertyName = "IsEnabled"
        Me.IsEnabledDataGridViewTextBoxColumn.HeaderText = "Enabled"
        Me.IsEnabledDataGridViewTextBoxColumn.Name = "IsEnabledDataGridViewTextBoxColumn"
        Me.IsEnabledDataGridViewTextBoxColumn.ReadOnly = True
        Me.IsEnabledDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IsEnabledDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DTAddedDataGridViewTextBoxColumn
        '
        Me.DTAddedDataGridViewTextBoxColumn.DataPropertyName = "DTAdded"
        Me.DTAddedDataGridViewTextBoxColumn.HeaderText = "Date Added"
        Me.DTAddedDataGridViewTextBoxColumn.Name = "DTAddedDataGridViewTextBoxColumn"
        Me.DTAddedDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DoPingDataGridViewTextBoxColumn
        '
        Me.DoPingDataGridViewTextBoxColumn.DataPropertyName = "DoPing"
        Me.DoPingDataGridViewTextBoxColumn.HeaderText = "Ping"
        Me.DoPingDataGridViewTextBoxColumn.Name = "DoPingDataGridViewTextBoxColumn"
        Me.DoPingDataGridViewTextBoxColumn.ReadOnly = True
        Me.DoPingDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DoPingDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DoTraceDataGridViewTextBoxColumn
        '
        Me.DoTraceDataGridViewTextBoxColumn.DataPropertyName = "DoTrace"
        Me.DoTraceDataGridViewTextBoxColumn.HeaderText = "Trace"
        Me.DoTraceDataGridViewTextBoxColumn.Name = "DoTraceDataGridViewTextBoxColumn"
        Me.DoTraceDataGridViewTextBoxColumn.ReadOnly = True
        Me.DoTraceDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DoTraceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DoPortDataGridViewTextBoxColumn
        '
        Me.DoPortDataGridViewTextBoxColumn.DataPropertyName = "DoPort"
        Me.DoPortDataGridViewTextBoxColumn.HeaderText = "Port"
        Me.DoPortDataGridViewTextBoxColumn.Name = "DoPortDataGridViewTextBoxColumn"
        Me.DoPortDataGridViewTextBoxColumn.ReadOnly = True
        Me.DoPortDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DoPortDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DoHTTPDataGridViewTextBoxColumn
        '
        Me.DoHTTPDataGridViewTextBoxColumn.DataPropertyName = "DoHTTP"
        Me.DoHTTPDataGridViewTextBoxColumn.HeaderText = "HTTP"
        Me.DoHTTPDataGridViewTextBoxColumn.Name = "DoHTTPDataGridViewTextBoxColumn"
        Me.DoHTTPDataGridViewTextBoxColumn.ReadOnly = True
        Me.DoHTTPDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DoHTTPDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'frmView_Servers_All
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 326)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmView_Servers_All"
        Me.Text = "View All Devices"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewserversallBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents BssmDataSet As BSServerMonitor.bssmDataSet
    Friend WithEvents ViewserversallBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents View_servers_allTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.view_servers_allTableAdapter
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DisplayNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServerNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServerIPAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CSDataGridViewTextBoxColumn As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents CatDataGridViewTextBoxColumn As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents IsEnabledDataGridViewTextBoxColumn As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DTAddedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DoPingDataGridViewTextBoxColumn As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DoTraceDataGridViewTextBoxColumn As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DoPortDataGridViewTextBoxColumn As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DoHTTPDataGridViewTextBoxColumn As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
End Class
