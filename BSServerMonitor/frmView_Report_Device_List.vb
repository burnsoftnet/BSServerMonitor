Public Class frmView_Report_Device_List

    Private Sub frmView_Report_Device_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Report_list_all_serversTableAdapter.FillBy(Me.bssmDataSet.Report_list_all_servers)
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "Load")
            MsgBox("Error Occured while attempting to build report" & Chr(10) & "Please see error log for more details.")
        End Try
    End Sub
End Class