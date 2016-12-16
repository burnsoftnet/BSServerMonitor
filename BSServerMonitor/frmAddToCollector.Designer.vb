<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddToCollector
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddToCollector))
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnMTC = New System.Windows.Forms.Button
        Me.btnMove = New System.Windows.Forms.Button
        Me.cmbCol = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.BssmDataSet = New BSServerMonitor.bssmDataSet
        Me.ListcollectorsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.List_collectorsTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.list_collectorsTableAdapter
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListcollectorsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(280, 48)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select the new Collector that you wish to move this server to:"
        '
        'btnMTC
        '
        Me.btnMTC.Location = New System.Drawing.Point(134, 81)
        Me.btnMTC.Name = "btnMTC"
        Me.btnMTC.Size = New System.Drawing.Size(140, 23)
        Me.btnMTC.TabIndex = 8
        Me.btnMTC.Text = "Move to Central Server"
        Me.btnMTC.UseVisualStyleBackColor = True
        '
        'btnMove
        '
        Me.btnMove.Location = New System.Drawing.Point(15, 82)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(75, 23)
        Me.btnMove.TabIndex = 7
        Me.btnMove.Text = "Move"
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'cmbCol
        '
        Me.cmbCol.DataSource = Me.ListcollectorsBindingSource
        Me.cmbCol.DisplayMember = "ServerName"
        Me.cmbCol.FormattingEnabled = True
        Me.cmbCol.Location = New System.Drawing.Point(69, 41)
        Me.cmbCol.Name = "cmbCol"
        Me.cmbCol.Size = New System.Drawing.Size(205, 21)
        Me.cmbCol.TabIndex = 6
        Me.cmbCol.ValueMember = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Collector:"
        '
        'BssmDataSet
        '
        Me.BssmDataSet.DataSetName = "bssmDataSet"
        Me.BssmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ListcollectorsBindingSource
        '
        Me.ListcollectorsBindingSource.DataMember = "list_collectors"
        Me.ListcollectorsBindingSource.DataSource = Me.BssmDataSet
        '
        'List_collectorsTableAdapter
        '
        Me.List_collectorsTableAdapter.ClearBeforeFill = True
        '
        'frmAddToCollector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 121)
        Me.Controls.Add(Me.btnMTC)
        Me.Controls.Add(Me.btnMove)
        Me.Controls.Add(Me.cmbCol)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddToCollector"
        Me.Text = "Add to/Change Collector"
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListcollectorsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnMTC As System.Windows.Forms.Button
    Friend WithEvents btnMove As System.Windows.Forms.Button
    Friend WithEvents cmbCol As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BssmDataSet As BSServerMonitor.bssmDataSet
    Friend WithEvents ListcollectorsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents List_collectorsTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.list_collectorsTableAdapter
End Class
