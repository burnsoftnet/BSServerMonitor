<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView_Collectors
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmView_Collectors))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.lblMasterServerCount = New System.Windows.Forms.ToolStripLabel
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServerNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LUDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Balanced = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EnabledToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DisabledToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MoveLoadToAnotherServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ManageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RestartBSSMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TerminalServerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StopBSSMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StartBSSMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BalanceOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EnabledToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.DisabledToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewcollectorlistBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BssmDataSet = New BSServerMonitor.bssmDataSet
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.View_collector_listTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.view_collector_listTableAdapter
        Me.ToolStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.ViewcollectorlistBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripLabel1, Me.lblMasterServerCount})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(578, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.BSServerMonitor.My.Resources.Resources.add_16_x_161
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Add Collector"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.BSServerMonitor.My.Resources.Resources.refresh
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Refresh"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.BSServerMonitor.My.Resources.Resources.start
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Auto Refresh"
        Me.ToolStripButton3.Visible = False
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = Global.BSServerMonitor.My.Resources.Resources.pause1
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "pause"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(146, 22)
        Me.ToolStripLabel1.Text = "Master Server Device Count:"
        '
        'lblMasterServerCount
        '
        Me.lblMasterServerCount.Name = "lblMasterServerCount"
        Me.lblMasterServerCount.Size = New System.Drawing.Size(0, 22)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.ServerNameDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.CL, Me.LUDDataGridViewTextBoxColumn, Me.Balanced})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.DataSource = Me.ViewcollectorlistBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 25)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(578, 241)
        Me.DataGridView1.TabIndex = 1
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.FillWeight = 50.0!
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Width = 43
        '
        'ServerNameDataGridViewTextBoxColumn
        '
        Me.ServerNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ServerNameDataGridViewTextBoxColumn.DataPropertyName = "ServerName"
        Me.ServerNameDataGridViewTextBoxColumn.FillWeight = 150.0!
        Me.ServerNameDataGridViewTextBoxColumn.HeaderText = "Server Name"
        Me.ServerNameDataGridViewTextBoxColumn.Name = "ServerNameDataGridViewTextBoxColumn"
        Me.ServerNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.ServerNameDataGridViewTextBoxColumn.Width = 94
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        Me.StatusDataGridViewTextBoxColumn.ReadOnly = True
        Me.StatusDataGridViewTextBoxColumn.Width = 62
        '
        'CL
        '
        Me.CL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CL.DataPropertyName = "CL"
        Me.CL.HeaderText = "Client Load"
        Me.CL.Name = "CL"
        Me.CL.ReadOnly = True
        Me.CL.Width = 85
        '
        'LUDDataGridViewTextBoxColumn
        '
        Me.LUDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LUDDataGridViewTextBoxColumn.DataPropertyName = "LUD"
        Me.LUDDataGridViewTextBoxColumn.HeaderText = "Last Update"
        Me.LUDDataGridViewTextBoxColumn.Name = "LUDDataGridViewTextBoxColumn"
        Me.LUDDataGridViewTextBoxColumn.ReadOnly = True
        Me.LUDDataGridViewTextBoxColumn.Width = 90
        '
        'Balanced
        '
        Me.Balanced.DataPropertyName = "Balanced"
        Me.Balanced.HeaderText = "Balanced"
        Me.Balanced.Name = "Balanced"
        Me.Balanced.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnabledToolStripMenuItem, Me.DisabledToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.MoToolStripMenuItem, Me.MoveLoadToAnotherServerToolStripMenuItem, Me.ManageToolStripMenuItem, Me.BalanceOptionsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(228, 180)
        '
        'EnabledToolStripMenuItem
        '
        Me.EnabledToolStripMenuItem.Name = "EnabledToolStripMenuItem"
        Me.EnabledToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.EnabledToolStripMenuItem.Text = "Enabled"
        '
        'DisabledToolStripMenuItem
        '
        Me.DisabledToolStripMenuItem.Name = "DisabledToolStripMenuItem"
        Me.DisabledToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.DisabledToolStripMenuItem.Text = "Disabled"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'MoToolStripMenuItem
        '
        Me.MoToolStripMenuItem.Name = "MoToolStripMenuItem"
        Me.MoToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.MoToolStripMenuItem.Text = "Move Master Load All"
        '
        'MoveLoadToAnotherServerToolStripMenuItem
        '
        Me.MoveLoadToAnotherServerToolStripMenuItem.Name = "MoveLoadToAnotherServerToolStripMenuItem"
        Me.MoveLoadToAnotherServerToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.MoveLoadToAnotherServerToolStripMenuItem.Text = "Move Load to Another Server"
        '
        'ManageToolStripMenuItem
        '
        Me.ManageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RestartBSSMToolStripMenuItem, Me.TerminalServerToolStripMenuItem, Me.StopBSSMToolStripMenuItem, Me.StartBSSMToolStripMenuItem})
        Me.ManageToolStripMenuItem.Name = "ManageToolStripMenuItem"
        Me.ManageToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ManageToolStripMenuItem.Text = "Manage"
        '
        'RestartBSSMToolStripMenuItem
        '
        Me.RestartBSSMToolStripMenuItem.Name = "RestartBSSMToolStripMenuItem"
        Me.RestartBSSMToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.RestartBSSMToolStripMenuItem.Text = "Restart BSSM"
        '
        'TerminalServerToolStripMenuItem
        '
        Me.TerminalServerToolStripMenuItem.Name = "TerminalServerToolStripMenuItem"
        Me.TerminalServerToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.TerminalServerToolStripMenuItem.Text = "Terminal Server"
        '
        'StopBSSMToolStripMenuItem
        '
        Me.StopBSSMToolStripMenuItem.Name = "StopBSSMToolStripMenuItem"
        Me.StopBSSMToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.StopBSSMToolStripMenuItem.Text = "Stop BSSM"
        '
        'StartBSSMToolStripMenuItem
        '
        Me.StartBSSMToolStripMenuItem.Name = "StartBSSMToolStripMenuItem"
        Me.StartBSSMToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.StartBSSMToolStripMenuItem.Text = "Start BSSM"
        '
        'BalanceOptionsToolStripMenuItem
        '
        Me.BalanceOptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnabledToolStripMenuItem1, Me.DisabledToolStripMenuItem1})
        Me.BalanceOptionsToolStripMenuItem.Name = "BalanceOptionsToolStripMenuItem"
        Me.BalanceOptionsToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.BalanceOptionsToolStripMenuItem.Text = "Balance Options"
        '
        'EnabledToolStripMenuItem1
        '
        Me.EnabledToolStripMenuItem1.Name = "EnabledToolStripMenuItem1"
        Me.EnabledToolStripMenuItem1.Size = New System.Drawing.Size(125, 22)
        Me.EnabledToolStripMenuItem1.Text = "Enabled"
        '
        'DisabledToolStripMenuItem1
        '
        Me.DisabledToolStripMenuItem1.Name = "DisabledToolStripMenuItem1"
        Me.DisabledToolStripMenuItem1.Size = New System.Drawing.Size(125, 22)
        Me.DisabledToolStripMenuItem1.Text = "Disabled"
        '
        'ViewcollectorlistBindingSource
        '
        Me.ViewcollectorlistBindingSource.DataMember = "view_collector_list"
        Me.ViewcollectorlistBindingSource.DataSource = Me.BssmDataSet
        '
        'BssmDataSet
        '
        Me.BssmDataSet.DataSetName = "bssmDataSet"
        Me.BssmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Timer1
        '
        Me.Timer1.Interval = 60000
        '
        'View_collector_listTableAdapter
        '
        Me.View_collector_listTableAdapter.ClearBeforeFill = True
        '
        'frmView_Collectors
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(578, 266)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmView_Collectors"
        Me.Text = "Collector List"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.ViewcollectorlistBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EnabledToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisabledToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BssmDataSet As BSServerMonitor.bssmDataSet
    Friend WithEvents ViewcollectorlistBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents View_collector_listTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.view_collector_listTableAdapter
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents lblMasterServerCount As System.Windows.Forms.ToolStripLabel
    Friend WithEvents MoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MoveLoadToAnotherServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestartBSSMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TerminalServerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StopBSSMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartBSSMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServerNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LUDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Balanced As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BalanceOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnabledToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisabledToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
End Class
