Public Class frmView_Servers_All
    Public Sub LoadData()
        Try
            Me.View_servers_allTableAdapter.Fill(Me.BssmDataSet.view_servers_all)
            ToolStripLabel2.Text = DataGridView1.RowCount
        Catch ex As Exception
            Dim sMsg As String = ""
            Select Case Err.Number
                Case 5
                    Dim sSplit() As String = Split(sConn, ";")
                    Dim DBServer As String = sSplit(0)
                    sMsg = "Lost Connection to the Database!" & Chr(10) & ex.Message.ToString & _
                            Chr(10) & "Check Database " & DBServer
                    MsgBox(sMsg)
                    tmrRefresh.Enabled = False
                    ToolStripButton4.Visible = True
                    ToolStripButton3.Visible = False
                    sMsg = "Auto Update has been turned off on " & Me.Name & ", hit the play button to try a connect again."
                    MsgBox(sMsg)
                Case Else
                    MsgBox("Unknown error:" & Err.Number & "::" & ex.Message.ToString)
            End Select
        End Try
    End Sub
    Public Sub CreateViewOnlyMode()
        If READ_ONLY Then
            ' AddItemsToolStripMenuItem1.Enabled = False
            ' ActionsToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub frmView_Servers_All_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CreateViewOnlyMode()
        Call LoadData()
        tmrRefresh.Enabled = False
        ToolStripButton4.Visible = True
        ToolStripButton3.Visible = False
    End Sub
    Private Sub tmrRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefresh.Tick
        Call LoadData()
    End Sub
    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
        Dim frmNew As New frmView_Server_Details
        Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(1).Value
        frmNew.SID = RowID
        frmNew.ServerName = ServerName
        frmNew.MdiParent = Me.MdiParent
        frmNew.Show()
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Call LoadData()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Me.Close()
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        tmrRefresh.Enabled = False
        ToolStripButton4.Visible = True
        ToolStripButton3.Visible = False
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        tmrRefresh.Enabled = True
        ToolStripButton3.Visible = True
        ToolStripButton4.Visible = False
    End Sub
End Class