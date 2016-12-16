<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearch_Results
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearch_Results))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.PingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PingIPAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UpdateStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EnableServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteDeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MarkDeviceAsDeletedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewserversallBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BssmDataSet = New BSServerMonitor.bssmDataSet
        Me.View_servers_allTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.view_servers_allTableAdapter
        Me.DisableDeviceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServerNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServerIPAddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DisplayNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CSDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IsEnabledDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ViewserversallBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.ServerNameDataGridViewTextBoxColumn, Me.ServerIPAddressDataGridViewTextBoxColumn, Me.DisplayNameDataGridViewTextBoxColumn, Me.CatDataGridViewTextBoxColumn, Me.CSDataGridViewTextBoxColumn, Me.IsEnabledDataGridViewTextBoxColumn})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.DataSource = Me.ViewserversallBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(659, 308)
        Me.DataGridView1.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PingToolStripMenuItem, Me.PingIPAddressToolStripMenuItem, Me.UpdateStatusToolStripMenuItem, Me.ViewToolStripMenuItem, Me.EnableServerToolStripMenuItem, Me.DeleteDeviceToolStripMenuItem, Me.MarkDeviceAsDeletedToolStripMenuItem, Me.DisableDeviceToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(199, 180)
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
        'EnableServerToolStripMenuItem
        '
        Me.EnableServerToolStripMenuItem.Name = "EnableServerToolStripMenuItem"
        Me.EnableServerToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.EnableServerToolStripMenuItem.Text = "Enable Device"
        '
        'DeleteDeviceToolStripMenuItem
        '
        Me.DeleteDeviceToolStripMenuItem.Name = "DeleteDeviceToolStripMenuItem"
        Me.DeleteDeviceToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.DeleteDeviceToolStripMenuItem.Text = "Delete Device"
        '
        'MarkDeviceAsDeletedToolStripMenuItem
        '
        Me.MarkDeviceAsDeletedToolStripMenuItem.Name = "MarkDeviceAsDeletedToolStripMenuItem"
        Me.MarkDeviceAsDeletedToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.MarkDeviceAsDeletedToolStripMenuItem.Text = "Mark Device As Deleted"
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
        'DisableDeviceToolStripMenuItem
        '
        Me.DisableDeviceToolStripMenuItem.Name = "DisableDeviceToolStripMenuItem"
        Me.DisableDeviceToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.DisableDeviceToolStripMenuItem.Text = "Disable Device"
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
        Me.ServerNameDataGridViewTextBoxColumn.HeaderText = "ServerName"
        Me.ServerNameDataGridViewTextBoxColumn.Name = "ServerNameDataGridViewTextBoxColumn"
        Me.ServerNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ServerIPAddressDataGridViewTextBoxColumn
        '
        Me.ServerIPAddressDataGridViewTextBoxColumn.DataPropertyName = "ServerIPAddress"
        Me.ServerIPAddressDataGridViewTextBoxColumn.HeaderText = "ServerIPAddress"
        Me.ServerIPAddressDataGridViewTextBoxColumn.Name = "ServerIPAddressDataGridViewTextBoxColumn"
        Me.ServerIPAddressDataGridViewTextBoxColumn.ReadOnly = True
        '
        'DisplayNameDataGridViewTextBoxColumn
        '
        Me.DisplayNameDataGridViewTextBoxColumn.DataPropertyName = "DisplayName"
        Me.DisplayNameDataGridViewTextBoxColumn.HeaderText = "DisplayName"
        Me.DisplayNameDataGridViewTextBoxColumn.Name = "DisplayNameDataGridViewTextBoxColumn"
        Me.DisplayNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CatDataGridViewTextBoxColumn
        '
        Me.CatDataGridViewTextBoxColumn.DataPropertyName = "Cat"
        Me.CatDataGridViewTextBoxColumn.HeaderText = "Cat"
        Me.CatDataGridViewTextBoxColumn.Name = "CatDataGridViewTextBoxColumn"
        Me.CatDataGridViewTextBoxColumn.ReadOnly = True
        '
        'CSDataGridViewTextBoxColumn
        '
        Me.CSDataGridViewTextBoxColumn.DataPropertyName = "CS"
        Me.CSDataGridViewTextBoxColumn.HeaderText = "CS"
        Me.CSDataGridViewTextBoxColumn.Name = "CSDataGridViewTextBoxColumn"
        Me.CSDataGridViewTextBoxColumn.ReadOnly = True
        '
        'IsEnabledDataGridViewTextBoxColumn
        '
        Me.IsEnabledDataGridViewTextBoxColumn.DataPropertyName = "IsEnabled"
        Me.IsEnabledDataGridViewTextBoxColumn.HeaderText = "IsEnabled"
        Me.IsEnabledDataGridViewTextBoxColumn.Name = "IsEnabledDataGridViewTextBoxColumn"
        Me.IsEnabledDataGridViewTextBoxColumn.ReadOnly = True
        '
        'frmSearch_Results
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 308)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSearch_Results"
        Me.Text = "Search Results"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ViewserversallBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BssmDataSet As BSServerMonitor.bssmDataSet
    Friend WithEvents ViewserversallBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents View_servers_allTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.view_servers_allTableAdapter
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PingIPAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnableServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteDeviceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarkDeviceAsDeletedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisableDeviceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServerNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServerIPAddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DisplayNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CatDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CSDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsEnabledDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
