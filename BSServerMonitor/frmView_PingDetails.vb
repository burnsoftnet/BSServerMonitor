Public Class frmView_PingDetails
    Public TSID As Long
    Private Sub frmView_PingDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Results_ping_rawTableAdapter.FillBy_TSID(Me.BssmDataSet.results_ping_raw, TSID)
    End Sub
End Class