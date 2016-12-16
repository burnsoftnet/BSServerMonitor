<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView_Report_Device_UP_list
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmView_Report_Device_UP_list))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.bssmDataSet = New BSServerMonitor.bssmDataSet
        Me.Report_list_all_serversBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Report_list_all_serversTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.Report_list_all_serversTableAdapter
        CType(Me.bssmDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Report_list_all_serversBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "bssmDataSet_Report_list_all_servers"
        ReportDataSource1.Value = Me.Report_list_all_serversBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "BSServerMonitor.Report_Device_UP_list.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(620, 414)
        Me.ReportViewer1.TabIndex = 0
        '
        'bssmDataSet
        '
        Me.bssmDataSet.DataSetName = "bssmDataSet"
        Me.bssmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Report_list_all_serversBindingSource
        '
        Me.Report_list_all_serversBindingSource.DataMember = "Report_list_all_servers"
        Me.Report_list_all_serversBindingSource.DataSource = Me.bssmDataSet
        '
        'Report_list_all_serversTableAdapter
        '
        Me.Report_list_all_serversTableAdapter.ClearBeforeFill = True
        '
        'frmView_Report_Device_UP_list
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 414)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmView_Report_Device_UP_list"
        Me.Text = "Report - Devices that are Up"
        CType(Me.bssmDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Report_list_all_serversBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Report_list_all_serversBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents bssmDataSet As BSServerMonitor.bssmDataSet
    Friend WithEvents Report_list_all_serversTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.Report_list_all_serversTableAdapter
End Class
