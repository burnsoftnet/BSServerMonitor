<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView_PingDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmView_PingDetails))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.IDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SIPDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MyBytesDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MyTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MyTTLDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ResultspingrawBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BssmDataSet = New BSServerMonitor.bssmDataSet
        Me.Results_ping_rawTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.results_ping_rawTableAdapter
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResultspingrawBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDDataGridViewTextBoxColumn, Me.SIPDataGridViewTextBoxColumn, Me.MyBytesDataGridViewTextBoxColumn, Me.MyTimeDataGridViewTextBoxColumn, Me.MyTTLDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.ResultspingrawBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(597, 288)
        Me.DataGridView1.TabIndex = 0
        '
        'IDDataGridViewTextBoxColumn
        '
        Me.IDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        Me.IDDataGridViewTextBoxColumn.HeaderText = "ID"
        Me.IDDataGridViewTextBoxColumn.Name = "IDDataGridViewTextBoxColumn"
        Me.IDDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDDataGridViewTextBoxColumn.Visible = False
        '
        'SIPDataGridViewTextBoxColumn
        '
        Me.SIPDataGridViewTextBoxColumn.DataPropertyName = "SIP"
        Me.SIPDataGridViewTextBoxColumn.HeaderText = "SIP"
        Me.SIPDataGridViewTextBoxColumn.Name = "SIPDataGridViewTextBoxColumn"
        Me.SIPDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MyBytesDataGridViewTextBoxColumn
        '
        Me.MyBytesDataGridViewTextBoxColumn.DataPropertyName = "MyBytes"
        Me.MyBytesDataGridViewTextBoxColumn.HeaderText = "MyBytes"
        Me.MyBytesDataGridViewTextBoxColumn.Name = "MyBytesDataGridViewTextBoxColumn"
        Me.MyBytesDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MyTimeDataGridViewTextBoxColumn
        '
        Me.MyTimeDataGridViewTextBoxColumn.DataPropertyName = "MyTime"
        Me.MyTimeDataGridViewTextBoxColumn.HeaderText = "MyTime"
        Me.MyTimeDataGridViewTextBoxColumn.Name = "MyTimeDataGridViewTextBoxColumn"
        Me.MyTimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'MyTTLDataGridViewTextBoxColumn
        '
        Me.MyTTLDataGridViewTextBoxColumn.DataPropertyName = "MyTTL"
        Me.MyTTLDataGridViewTextBoxColumn.HeaderText = "MyTTL"
        Me.MyTTLDataGridViewTextBoxColumn.Name = "MyTTLDataGridViewTextBoxColumn"
        Me.MyTTLDataGridViewTextBoxColumn.ReadOnly = True
        '
        'ResultspingrawBindingSource
        '
        Me.ResultspingrawBindingSource.DataMember = "results_ping_raw"
        Me.ResultspingrawBindingSource.DataSource = Me.BssmDataSet
        '
        'BssmDataSet
        '
        Me.BssmDataSet.DataSetName = "bssmDataSet"
        Me.BssmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Results_ping_rawTableAdapter
        '
        Me.Results_ping_rawTableAdapter.ClearBeforeFill = True
        '
        'frmView_PingDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 288)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmView_PingDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ping Details"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResultspingrawBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BssmDataSet As BSServerMonitor.bssmDataSet
    Friend WithEvents ResultspingrawBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Results_ping_rawTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.results_ping_rawTableAdapter
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SIPDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MyBytesDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MyTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MyTTLDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
