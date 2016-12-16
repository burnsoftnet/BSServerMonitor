Public Class frmView_Report_Device_Deleted_list

    Private Sub frmView_Report_Device_Deleted_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Report_list_all_serversTableAdapter.FillBy_Deleted(Me.bssmDataSet.Report_list_all_servers)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class