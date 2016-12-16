Public Class frmReport_View_Monthly_Uptime

    Private Sub frmReport_View_Monthly_Uptime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'bssmDataSet.view_monthly_gen_friendlydates' table. You can move, or remove it, as needed.
        Me.view_monthly_gen_friendlydatesTableAdapter.Fill(Me.bssmDataSet.view_monthly_gen_friendlydates)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class