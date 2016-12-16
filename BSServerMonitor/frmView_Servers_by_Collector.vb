Public Class frmView_Servers_by_Collector
    Public CID As Long
    Public CollectorName As String
    Public Sub CreateViewOnlyMode()
        If READ_ONLY Then
            'AddItemsToolStripMenuItem1.Enabled = False
            'ActionsToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub frmView_Servers_by_Collector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sTitle As String = "Devices monitored by " & CollectorName
        Me.Text = sTitle
        Call CreateViewOnlyMode()
        Call LoadData()
    End Sub
    Sub LoadData()
        Try
            Me.View_servers_allTableAdapter.FillBy_CID(Me.BssmDataSet.view_servers_all, CID)
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "LoadData")
        End Try
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub
    Sub ViewData()
        Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
        Dim frmNew As New frmView_Server_Details
        Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
        frmNew.SID = RowID
        frmNew.ServerName = ServerName
        frmNew.MdiParent = Me.MdiParent
        frmNew.Show()
    End Sub
    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Call ViewData()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Call LoadData()
    End Sub
End Class