Public Class frmView_Report_Device_Errors_Down_List

    Private Sub frmView_Report_Device_Errors_Down_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Report_list_all_serversTableAdapter.FillBy_Warnings(Me.bssmDataSet.Report_list_all_servers)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class