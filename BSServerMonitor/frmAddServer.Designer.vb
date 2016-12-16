<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddServer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddServer))
        Me.chkEnabled = New System.Windows.Forms.CheckBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.lblDName = New System.Windows.Forms.Label
        Me.txtDName = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtIP = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.ListserverstypesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BssmDataSet = New BSServerMonitor.bssmDataSet
        Me.List_servers_typesTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.list_servers_typesTableAdapter
        Me.chkAutoAss = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbCollector = New System.Windows.Forms.ComboBox
        Me.ListcollectorsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.List_collectorsTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.list_collectorsTableAdapter
        CType(Me.ListserverstypesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ListcollectorsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkEnabled
        '
        Me.chkEnabled.AutoSize = True
        Me.chkEnabled.Checked = True
        Me.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEnabled.Location = New System.Drawing.Point(15, 107)
        Me.chkEnabled.Name = "chkEnabled"
        Me.chkEnabled.Size = New System.Drawing.Size(93, 17)
        Me.chkEnabled.TabIndex = 15
        Me.chkEnabled.Text = "Enable Server"
        Me.chkEnabled.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(172, 220)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 14
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(16, 220)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 13
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'lblDName
        '
        Me.lblDName.AutoSize = True
        Me.lblDName.Location = New System.Drawing.Point(12, 58)
        Me.lblDName.Name = "lblDName"
        Me.lblDName.Size = New System.Drawing.Size(75, 13)
        Me.lblDName.TabIndex = 12
        Me.lblDName.Text = "Display Name:"
        '
        'txtDName
        '
        Me.txtDName.Location = New System.Drawing.Point(90, 55)
        Me.txtDName.Name = "txtDName"
        Me.txtDName.Size = New System.Drawing.Size(153, 20)
        Me.txtDName.TabIndex = 11
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(90, 6)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(153, 20)
        Me.txtName.TabIndex = 10
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(15, 32)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(228, 17)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "Server Name is Same as the Display Name"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Server Name:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Server IP:"
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(90, 81)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(153, 20)
        Me.txtIP.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Device Type:"
        '
        'cmbType
        '
        Me.cmbType.DataSource = Me.ListserverstypesBindingSource
        Me.cmbType.DisplayMember = "Cat"
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(90, 128)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(153, 21)
        Me.cmbType.TabIndex = 19
        Me.cmbType.ValueMember = "ID"
        '
        'ListserverstypesBindingSource
        '
        Me.ListserverstypesBindingSource.DataMember = "list_servers_types"
        Me.ListserverstypesBindingSource.DataSource = Me.BssmDataSet
        '
        'BssmDataSet
        '
        Me.BssmDataSet.DataSetName = "bssmDataSet"
        Me.BssmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'List_servers_typesTableAdapter
        '
        Me.List_servers_typesTableAdapter.ClearBeforeFill = True
        '
        'chkAutoAss
        '
        Me.chkAutoAss.AutoSize = True
        Me.chkAutoAss.Checked = True
        Me.chkAutoAss.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoAss.Location = New System.Drawing.Point(15, 155)
        Me.chkAutoAss.Name = "chkAutoAss"
        Me.chkAutoAss.Size = New System.Drawing.Size(138, 17)
        Me.chkAutoAss.TabIndex = 20
        Me.chkAutoAss.Text = "Auto Assign to Collector"
        Me.chkAutoAss.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Collector:"
        '
        'cmbCollector
        '
        Me.cmbCollector.DataSource = Me.ListcollectorsBindingSource
        Me.cmbCollector.DisplayMember = "ServerName"
        Me.cmbCollector.FormattingEnabled = True
        Me.cmbCollector.Location = New System.Drawing.Point(90, 176)
        Me.cmbCollector.Name = "cmbCollector"
        Me.cmbCollector.Size = New System.Drawing.Size(153, 21)
        Me.cmbCollector.TabIndex = 22
        Me.cmbCollector.ValueMember = "ID"
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
        'frmAddServer
        '
        Me.AcceptButton = Me.btnAdd
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(256, 255)
        Me.Controls.Add(Me.cmbCollector)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkAutoAss)
        Me.Controls.Add(Me.cmbType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkEnabled)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblDName)
        Me.Controls.Add(Me.txtDName)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddServer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Device"
        CType(Me.ListserverstypesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BssmDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ListcollectorsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkEnabled As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lblDName As System.Windows.Forms.Label
    Friend WithEvents txtDName As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtIP As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents BssmDataSet As BSServerMonitor.bssmDataSet
    Friend WithEvents ListserverstypesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents List_servers_typesTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.list_servers_typesTableAdapter
    Friend WithEvents chkAutoAss As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCollector As System.Windows.Forms.ComboBox
    Friend WithEvents ListcollectorsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents List_collectorsTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.list_collectorsTableAdapter
End Class
