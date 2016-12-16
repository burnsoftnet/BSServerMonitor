<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport_View_Monthly_Uptime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReport_View_Monthly_Uptime))
        Me.view_monthly_gen_friendlydatesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.bssmDataSet = New BSServerMonitor.bssmDataSet
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.view_monthly_gen_friendlydatesTableAdapter = New BSServerMonitor.bssmDataSetTableAdapters.view_monthly_gen_friendlydatesTableAdapter
        CType(Me.view_monthly_gen_friendlydatesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bssmDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'view_monthly_gen_friendlydatesBindingSource
        '
        Me.view_monthly_gen_friendlydatesBindingSource.DataMember = "view_monthly_gen_friendlydates"
        Me.view_monthly_gen_friendlydatesBindingSource.DataSource = Me.bssmDataSet
        '
        'bssmDataSet
        '
        Me.bssmDataSet.DataSetName = "bssmDataSet"
        Me.bssmDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "bssmDataSet_view_monthly_gen_friendlydates"
        ReportDataSource1.Value = Me.view_monthly_gen_friendlydatesBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "BSServerMonitor.Report_Monthly_General.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(721, 461)
        Me.ReportViewer1.TabIndex = 0
        '
        'view_monthly_gen_friendlydatesTableAdapter
        '
        Me.view_monthly_gen_friendlydatesTableAdapter.ClearBeforeFill = True
        '
        'frmReport_View_Monthly_Uptime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 461)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReport_View_Monthly_Uptime"
        Me.Text = "Monthly Overall Stats Last 6 Months"
        CType(Me.view_monthly_gen_friendlydatesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bssmDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents view_monthly_gen_friendlydatesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents bssmDataSet As BSServerMonitor.bssmDataSet
    Friend WithEvents view_monthly_gen_friendlydatesTableAdapter As BSServerMonitor.bssmDataSetTableAdapters.view_monthly_gen_friendlydatesTableAdapter
End Class
