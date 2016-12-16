<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView_Servers_by_Collector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmView_Servers_by_Collector))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServerNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DisplayNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServerIPAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IsEnabledDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DTAddedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DoPingDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DoTraceDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DoPortDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DoHTTPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViewserversallBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BssmDataSet = New BSServerMonitor.bssmDataSet
        Me.View_servers_allTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.view_servers_allTableAdapter
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewserversallBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 390)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(687, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(687, 25)
        Me.ToolStrip1.TabIndex = 1
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
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.BSServerMonitor.My.Resources.Resources.Notification_20__20Shutdown_2016_20n_20p
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Close Window"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.ServerNameDataGridViewTextBoxColumn, Me.DisplayNameDataGridViewTextBoxColumn, Me.ServerIPAddressDataGridViewTextBoxColumn, Me.CSDataGridViewTextBoxColumn, Me.IsEnabledDataGridViewTextBoxColumn, Me.DTAddedDataGridViewTextBoxColumn, Me.DoPingDataGridViewTextBoxColumn, Me.DoTraceDataGridViewTextBoxColumn, Me.DoPortDataGridViewTextBoxColumn, Me.DoHTTPDataGridViewTextBoxColumn, Me.CatDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ViewserversallBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(687, 365)
        Me.DataGridView1.TabIndex = 2
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Visible = False
        '
        'ServerNameDataGridViewTextBoxColumn
        '
        Me.ServerNameDataGridViewTextBoxColumn.DataPropertyName = "ServerName"
        Me.ServerNameDataGridViewTextBoxColumn.HeaderText = "Server Name"
        Me.ServerNameDataGridViewTextBoxColumn.Name = "ServerNameDataGridViewTextBoxColumn"
        Me.ServerNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DisplayNameDataGridViewTextBoxColumn
        '
        Me.DisplayNameDataGridViewTextBoxColumn.DataPropertyName = "DisplayName"
        Me.DisplayNameDataGridViewTextBoxColumn.HeaderText = "Display Name"
        Me.DisplayNameDataGridViewTextBoxColumn.Name = "DisplayNameDataGridViewTextBoxColumn"
        Me.DisplayNameDataGridViewTextBoxColumn.ReadOnly = True
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
        Me.CSDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.CSDataGridViewTextBoxColumn.Name = "CSDataGridViewTextBoxColumn"
        Me.CSDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IsEnabledDataGridViewTextBoxColumn
        '
        Me.IsEnabledDataGridViewTextBoxColumn.DataPropertyName = "IsEnabled"
        Me.IsEnabledDataGridViewTextBoxColumn.HeaderText = "Enabled"
        Me.IsEnabledDataGridViewTextBoxColumn.Name = "IsEnabledDataGridViewTextBoxColumn"
        Me.IsEnabledDataGridViewTextBoxColumn.ReadOnly = True
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
        Me.DoPingDataGridViewTextBoxColumn.HeaderText = "Ping Test"
        Me.DoPingDataGridViewTextBoxColumn.Name = "DoPingDataGridViewTextBoxColumn"
        Me.DoPingDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DoTraceDataGridViewTextBoxColumn
        '
        Me.DoTraceDataGridViewTextBoxColumn.DataPropertyName = "DoTrace"
        Me.DoTraceDataGridViewTextBoxColumn.HeaderText = "Trace Test"
        Me.DoTraceDataGridViewTextBoxColumn.Name = "DoTraceDataGridViewTextBoxColumn"
        Me.DoTraceDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DoPortDataGridViewTextBoxColumn
        '
        Me.DoPortDataGridViewTextBoxColumn.DataPropertyName = "DoPort"
        Me.DoPortDataGridViewTextBoxColumn.HeaderText = "Port Test"
        Me.DoPortDataGridViewTextBoxColumn.Name = "DoPortDataGridViewTextBoxColumn"
        Me.DoPortDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DoHTTPDataGridViewTextBoxColumn
        '
        Me.DoHTTPDataGridViewTextBoxColumn.DataPropertyName = "DoHTTP"
        Me.DoHTTPDataGridViewTextBoxColumn.HeaderText = "HTTP Test"
        Me.DoHTTPDataGridViewTextBoxColumn.Name = "DoHTTPDataGridViewTextBoxColumn"
        Me.DoHTTPDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CatDataGridViewTextBoxColumn
        '
        Me.CatDataGridViewTextBoxColumn.DataPropertyName = "Cat"
        Me.CatDataGridViewTextBoxColumn.HeaderText = "Category"
        Me.CatDataGridViewTextBoxColumn.Name = "CatDataGridViewTextBoxColumn"
        Me.CatDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ViewserversallBindingSource
        '
        Me.ViewserversallBindingSource.DataMember = "view_servers_all"
        Me.ViewserversallBindingSource.DataSource = Me.BssmDataSet
        '
        'BssmDataSet
        '
        Me.BssmDataSet.DataSetName = "bssmDataSet"
        Me.BssmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'View_servers_allTableAdapter
        '
        Me.View_servers_allTableAdapter.ClearBeforeFill = True
        '
        'frmView_Servers_by_Collector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 412)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmView_Servers_by_Collector"
        Me.Text = "frmView_Servers_by_Collector"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewserversallBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BssmDataSet As BSServerMonitor.bssmDataSet
    Friend WithEvents ViewserversallBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents View_servers_allTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.view_servers_allTableAdapter
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServerNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DisplayNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServerIPAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CSDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsEnabledDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DTAddedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DoPingDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DoTraceDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DoPortDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DoHTTPDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CatDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
