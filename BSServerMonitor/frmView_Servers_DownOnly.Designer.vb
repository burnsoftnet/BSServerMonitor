<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView_Servers_DownOnly
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmView_Servers_DownOnly))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DisplayNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServerIPAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServerNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cat = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PingIPAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UpdateStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DisableServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MarkDeviceAsDeletedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ResetReportedCountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewserversdownonlyBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BssmDataSet = New BSServerMonitor.bssmDataSet
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.View_servers_downonlyTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.view_servers_downonlyTableAdapter
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ViewserversdownonlyBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton4, Me.ToolStripButton3, Me.ToolStripButton2, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(514, 25)
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.DisplayNameDataGridViewTextBoxColumn, Me.ServerIPAddressDataGridViewTextBoxColumn, Me.ServerNameDataGridViewTextBoxColumn, Me.Cat})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.DataSource = Me.ViewserversdownonlyBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(514, 241)
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
        'ServerNameDataGridViewTextBoxColumn
        '
        Me.ServerNameDataGridViewTextBoxColumn.DataPropertyName = "ServerName"
        Me.ServerNameDataGridViewTextBoxColumn.HeaderText = "Server Name"
        Me.ServerNameDataGridViewTextBoxColumn.Name = "ServerNameDataGridViewTextBoxColumn"
        Me.ServerNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'Cat
        '
        Me.Cat.DataPropertyName = "Cat"
        Me.Cat.HeaderText = "Type"
        Me.Cat.Name = "Cat"
        Me.Cat.ReadOnly = True
        Me.Cat.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cat.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PingToolStripMenuItem, Me.PingIPAddressToolStripMenuItem, Me.UpdateStatusToolStripMenuItem, Me.ViewToolStripMenuItem, Me.DisableServerToolStripMenuItem, Me.MarkDeviceAsDeletedToolStripMenuItem, Me.ResetReportedCountToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(199, 158)
        '
        'PingToolStripMenuItem
        '
        Me.PingToolStripMenuItem.Name = "PingToolStripMenuItem"
        Me.PingToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.PingToolStripMenuItem.Text = "&Ping ServerName"
        '
        'PingIPAddressToolStripMenuItem
        '
        Me.PingIPAddressToolStripMenuItem.Name = "PingIPAddressToolStripMenuItem"
        Me.PingIPAddressToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.PingIPAddressToolStripMenuItem.Text = "Pi&ng IP Address"
        '
        'UpdateStatusToolStripMenuItem
        '
        Me.UpdateStatusToolStripMenuItem.Name = "UpdateStatusToolStripMenuItem"
        Me.UpdateStatusToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.UpdateStatusToolStripMenuItem.Text = "&Update Status"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ViewToolStripMenuItem.Text = "View"
        '
        'DisableServerToolStripMenuItem
        '
        Me.DisableServerToolStripMenuItem.Name = "DisableServerToolStripMenuItem"
        Me.DisableServerToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.DisableServerToolStripMenuItem.Text = "Disable Device"
        '
        'MarkDeviceAsDeletedToolStripMenuItem
        '
        Me.MarkDeviceAsDeletedToolStripMenuItem.Name = "MarkDeviceAsDeletedToolStripMenuItem"
        Me.MarkDeviceAsDeletedToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.MarkDeviceAsDeletedToolStripMenuItem.Text = "Mark Device As Deleted"
        '
        'ResetReportedCountToolStripMenuItem
        '
        Me.ResetReportedCountToolStripMenuItem.Name = "ResetReportedCountToolStripMenuItem"
        Me.ResetReportedCountToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.ResetReportedCountToolStripMenuItem.Text = "Reset Reported Count"
        '
        'ViewserversdownonlyBindingSource
        '
        Me.ViewserversdownonlyBindingSource.DataMember = "view_servers_downonly"
        Me.ViewserversdownonlyBindingSource.DataSource = Me.BssmDataSet
        '
        'BssmDataSet
        '
        Me.BssmDataSet.DataSetName = "bssmDataSet"
        Me.BssmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Enabled = True
        Me.tmrRefresh.Interval = 30000
        '
        'View_servers_downonlyTableAdapter
        '
        Me.View_servers_downonlyTableAdapter.ClearBeforeFill = True
        '
        'frmView_Servers_DownOnly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 266)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmView_Servers_DownOnly"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Device List - Down Only"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ViewserversdownonlyBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BssmDataSet As BSServerMonitor.bssmDataSet
    Friend WithEvents ViewserversdownonlyBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents View_servers_downonlyTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.view_servers_downonlyTableAdapter
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PingIPAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents DisableServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DisplayNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServerIPAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServerNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cat As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents MarkDeviceAsDeletedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetReportedCountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
