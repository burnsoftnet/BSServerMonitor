Public Class frmView_Servers_ErrorsOnly
    Sub LoadData()
        Try
            Me.View_servers_errorsonlyTableAdapter.Fill(Me.BssmDataSet.view_servers_errorsonly)
            ToolStripLabel2.Text = DataGridView1.RowCount
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & ".LoadData")
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
        DataGridView1.CurrentCell = Nothing
    End Sub
    Public Sub CreateViewOnlyMode()
        If READ_ONLY Then
            UpdateStatusToolStripMenuItem.Enabled = False
            'ActionsToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub frmView_Servers_ErrorsOnly_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CreateViewOnlyMode()
        Call LoadData()
        tmrRefresh.Enabled = True
        ToolStripButton4.Visible = False
        ToolStripButton3.Visible = True
    End Sub
    Private Sub tmrRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefresh.Tick
        Call LoadData()
    End Sub
    Sub ViewData()
        If DataGridView1.SelectedRows.Count = 1 Then
            Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
            Dim frmNew As New frmView_Server_Details
            Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(2).Value
            frmNew.SID = RowID
            frmNew.ServerName = ServerName
            frmNew.MdiParent = Me.MdiParent
            frmNew.Show()
        End If
    End Sub

    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.Columns(e.ColumnIndex).Name = "CSDataGridViewTextBoxColumn" Then
            Select Case UCase(Trim(e.Value))
                Case "WARNING"
                    e.CellStyle.BackColor = Color.Yellow
                    e.FormattingApplied = True
                Case "SLOW"
                    e.CellStyle.BackColor = Color.Yellow
                    e.FormattingApplied = True
                Case "DOWN"
                    e.CellStyle.BackColor = Color.Red
                    e.FormattingApplied = True
                Case "IP CHANGED"
                    e.CellStyle.BackColor = Color.Yellow
                    e.FormattingApplied = True
                Case "PORT DOWN"
                    e.CellStyle.BackColor = Color.Yellow
                    e.FormattingApplied = True
                Case "WEBSITE DOWN"
                    e.CellStyle.BackColor = Color.Yellow
                    e.FormattingApplied = True
                Case "WEB SEARCH FAILED"
                    e.CellStyle.BackColor = Color.Yellow
                    e.FormattingApplied = True
                Case "WEB CODE FAILED"
                    e.CellStyle.BackColor = Color.Yellow
                    e.FormattingApplied = True
                Case "WEB TESTS FAILED"
                    e.CellStyle.BackColor = Color.Yellow
                    e.FormattingApplied = True
            End Select
        End If
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Call ViewData()
    End Sub
    Private Sub PingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PingToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
                Dim myProcess As New Process
                myProcess.StartInfo.FileName = "ping"
                myProcess.StartInfo.Arguments = " -t " & ServerName
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                myProcess.Start()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "PingToolStripMenuItem_Click")
            End Try
        End If
    End Sub
    Private Sub PingIPAddressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PingIPAddressToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(4).Value
                Dim myProcess As New Process
                myProcess.StartInfo.FileName = "ping"
                myProcess.StartInfo.Arguments = " -t " & ServerName
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                myProcess.Start()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "PingIPAddressToolStripMenuItem_Click")
            End Try
        End If
    End Sub
    Private Sub UpdateStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateStatusToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
                Dim ServerID As String = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
                Dim sIP As String = DataGridView1.SelectedRows.Item(0).Cells.Item(4).Value
                Dim myProcess As New Process
                myProcess.StartInfo.FileName = Application.StartupPath & "\BSSM_Pinger.exe"
                myProcess.StartInfo.Arguments = " /server=" & ServerName & " /sid=" & ServerID & " /try=10 /IP=" & sIP
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                myProcess.Start()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "UpdateStatusToolStripMenuItem_Click")
            End Try
        End If
    End Sub
    Private Sub ViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewToolStripMenuItem.Click
        Call ViewData()
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

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class