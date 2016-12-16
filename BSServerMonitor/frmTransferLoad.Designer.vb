<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferLoad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransferLoad))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFrom = New System.Windows.Forms.TextBox
        Me.cmbTo = New System.Windows.Forms.ComboBox
        Me.BssmDataSet = New BSServerMonitor.bssmDataSet
        Me.ViewcollectorlistBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.View_collector_listTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.view_collector_listTableAdapter
        Me.btnTransfer = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewcollectorlistBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Transfer From:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Transfer To:"
        '
        'txtFrom
        '
        Me.txtFrom.Location = New System.Drawing.Point(94, 10)
        Me.txtFrom.Name = "txtFrom"
        Me.txtFrom.ReadOnly = True
        Me.txtFrom.Size = New System.Drawing.Size(173, 20)
        Me.txtFrom.TabIndex = 2
        '
        'cmbTo
        '
        Me.cmbTo.DataSource = Me.ViewcollectorlistBindingSource
        Me.cmbTo.DisplayMember = "ServerName"
        Me.cmbTo.FormattingEnabled = True
        Me.cmbTo.Location = New System.Drawing.Point(94, 37)
        Me.cmbTo.Name = "cmbTo"
        Me.cmbTo.Size = New System.Drawing.Size(173, 21)
        Me.cmbTo.TabIndex = 3
        Me.cmbTo.ValueMember = "ID"
        '
        'BssmDataSet
        '
        Me.BssmDataSet.DataSetName = "bssmDataSet"
        Me.BssmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ViewcollectorlistBindingSource
        '
        Me.ViewcollectorlistBindingSource.DataMember = "view_collector_list"
        Me.ViewcollectorlistBindingSource.DataSource = Me.BssmDataSet
        '
        'View_collector_listTableAdapter
        '
        Me.View_collector_listTableAdapter.ClearBeforeFill = True
        '
        'btnTransfer
        '
        Me.btnTransfer.Location = New System.Drawing.Point(19, 81)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(75, 23)
        Me.btnTransfer.TabIndex = 4
        Me.btnTransfer.Text = "Transfer"
        Me.btnTransfer.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(192, 81)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmTransferLoad
        '
        Me.AcceptButton = Me.btnTransfer
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(292, 124)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnTransfer)
        Me.Controls.Add(Me.cmbTo)
        Me.Controls.Add(Me.txtFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransferLoad"
        Me.Text = "Transfer Clients to Another Collector"
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewcollectorlistBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFrom As System.Windows.Forms.TextBox
    Friend WithEvents cmbTo As System.Windows.Forms.ComboBox
    Friend WithEvents BssmDataSet As BSServerMonitor.bssmDataSet
    Friend WithEvents ViewcollectorlistBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents View_collector_listTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.view_collector_listTableAdapter
    Friend WithEvents btnTransfer As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
