Imports BSServerMonitor.BurnSoft.GlobalClasses
Public Class frmView_Servers_DownOnly
    Public Sub LoadData()
        Try
            Me.View_servers_downonlyTableAdapter.Fill(Me.BssmDataSet.view_servers_downonly)
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
        DataGridView1.CurrentCell = Nothing
    End Sub
    Public Sub CreateViewOnlyMode()
        If READ_ONLY Then
            'ContextMenuStrip1.Enabled = False
            UpdateStatusToolStripMenuItem.Enabled = False
            DisableServerToolStripMenuItem.Enabled = False
            MarkDeviceAsDeletedToolStripMenuItem.Enabled = False
            ResetReportedCountToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub frmView_Servers_DownOnly_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call CreateViewOnlyMode()
        Call LoadData()
    End Sub
    Private Sub tmrRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrRefresh.Tick
        Call LoadData()
    End Sub
    Sub ViewData()
        If DataGridView1.SelectedRows.Count = 1 Then
            Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
            Dim frmNew As New frmView_Server_Details
            Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
            frmNew.SID = RowID
            frmNew.ServerName = ServerName
            frmNew.MdiParent = Me.MdiParent
            frmNew.Show()
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
                Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(2).Value
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
                Dim sIP As String = DataGridView1.SelectedRows.Item(0).Cells.Item(2).Value
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
    Sub UpdateDatabaseMenu(ByVal SQL As String)
        Dim Obj As New BSDatabase
        Obj.MYCONNSTRING = sConn
        Obj.ConnExe(SQL)
        Obj.CloseDB()
        Obj = Nothing
    End Sub
    Private Sub DisableServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisableServerToolStripMenuItem.Click
        Dim RowCount As Long = DataGridView1.SelectedRows.Count
        Dim ServerName As String = ""
        Dim ServerID As String = ""
        Dim SQL As String = ""
        Dim i As Long = 0
        If RowCount = 1 Then
            ServerName = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
            ServerID = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
            SQL = "UPDATE list_servers set IsEnabled=0 where ID=" & ServerID
            Call UpdateDatabaseMenu(SQL)
            MsgBox(ServerName & " has been disabled!")
            Call LoadData()
        ElseIf RowCount > 1 Then
            For i = 0 To DataGridView1.SelectedRows.Count - 1
                If DataGridView1.SelectedRows.Item(i).Selected Then
                    ServerName = DataGridView1.SelectedRows.Item(i).Cells.Item(3).Value
                    ServerID = DataGridView1.SelectedRows.Item(i).Cells.Item(0).Value
                    SQL = "UPDATE list_servers set IsEnabled=0 where ID=" & ServerID
                    Call UpdateDatabaseMenu(SQL)
                End If
            Next
            Call LoadData()
        End If
        'Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
        'Dim ServerID As String = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
        'Dim SQL As String = "UPDATE list_servers set IsEnabled=0 where ID=" & ServerID
        'Dim Obj As New BSDatabase
        'Obj.MYCONNSTRING = sConn
        'Obj.ConnExe(SQL)
        'MsgBox(ServerName & " has been disabled!")
        'Call LoadData()
    End Sub

    Private Sub MarkDeviceAsDeletedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkDeviceAsDeletedToolStripMenuItem.Click
        Dim RowCount As Long = DataGridView1.SelectedRows.Count
        Dim ServerName As String = ""
        Dim ServerID As String = ""
        Dim SQL As String = ""
        Dim i As Long = 0
        If RowCount = 1 Then
            ServerName = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
            ServerID = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
            SQL = "UPDATE list_servers set IsEnabled=0, CS=5 where ID=" & ServerID
            Call UpdateDatabaseMenu(SQL)
            SQL = "INSERT INTO events_general (SID,shrtEv,lngEv,Sev) VALUES (" & ServerID & _
                            ",'Marked As Deleted','Device was Marked as Deleted','INFO')"
            Call UpdateDatabaseMenu(SQL)
            MsgBox(ServerName & " Marked as Deleted!")
            Call LoadData()
            Call frmMain.LoadData()
        ElseIf RowCount > 1 Then
            For i = 0 To DataGridView1.SelectedRows.Count - 1
                If DataGridView1.SelectedRows.Item(i).Selected Then
                    ServerName = DataGridView1.SelectedRows.Item(i).Cells.Item(3).Value
                    ServerID = DataGridView1.SelectedRows.Item(i).Cells.Item(0).Value
                    SQL = "UPDATE list_servers set IsEnabled=0, CS=5 where ID=" & ServerID
                    Call UpdateDatabaseMenu(SQL)
                    SQL = "INSERT INTO events_general (SID,shrtEv,lngEv,Sev) VALUES (" & ServerID & _
                            ",'Marked As Deleted','Device was Marked as Deleted','INFO')"
                    Call UpdateDatabaseMenu(SQL)
                End If
            Next
            Call LoadData()
            Call frmMain.LoadData()
        End If
        'Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
        'Dim ServerID As String = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
        'Dim SQL As String = "UPDATE list_servers set IsEnabled=0, CS=5 where ID=" & ServerID
        'Dim Obj As New BSDatabase
        'Obj.MYCONNSTRING = sConn
        'Obj.ConnExe(SQL)
        'SQL = "INSERT INTO events_general (SID,shrtEv,lngEv,Sev) VALUES (" & ServerID & _
        '                    ",'Marked As Deleted','Device was Marked as Deleted','INFO')"
        'Obj.ConnExe(SQL)
        'MsgBox(ServerName & " Marked as Deleted!")
        'Call LoadData()
        'Call frmMain.LoadData()
    End Sub

    Private Sub ResetReportedCountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetReportedCountToolStripMenuItem.Click
        Dim RowCount As Long = DataGridView1.SelectedRows.Count
        Dim ServerName As String = ""
        Dim ServerID As String = ""
        Dim SQL As String = ""
        Dim i As Long = 0
        If RowCount = 1 Then
            ServerName = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
            ServerID = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
            SQL = "UPDATE list_servers set IsReported=0 where ID=" & ServerID
            Call UpdateDatabaseMenu(SQL)
            SQL = "INSERT INTO events_general (SID,shrtEv,lngEv,Sev) VALUES (" & ServerID & _
                            ",'Reset Reported Count','Device Reported Status was set to False','INFO')"
            Call UpdateDatabaseMenu(SQL)
            MsgBox(ServerName & " Reset Reported Count is complete!")
            Call LoadData()
            Call frmMain.LoadData()
        ElseIf RowCount > 1 Then
            For i = 0 To DataGridView1.SelectedRows.Count - 1
                If DataGridView1.SelectedRows.Item(i).Selected Then
                    ServerName = DataGridView1.SelectedRows.Item(i).Cells.Item(3).Value
                    ServerID = DataGridView1.SelectedRows.Item(i).Cells.Item(0).Value
                    SQL = "UPDATE list_servers set IsReported=0 where ID=" & ServerID
                    Call UpdateDatabaseMenu(SQL)
                    SQL = "INSERT INTO events_general (SID,shrtEv,lngEv,Sev) VALUES (" & ServerID & _
                            ",'Reset Reported Count','Device Reported Status was set to False','INFO')"
                    Call UpdateDatabaseMenu(SQL)
                End If
            Next
            Call LoadData()
            Call frmMain.LoadData()
        End If

        ' Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
        ' Dim ServerID As String = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
        ' Dim SQL As String = "UPDATE list_servers set IsReported=0 where ID=" & ServerID
        ' Dim Obj As New BSDatabase
        ' Obj.MYCONNSTRING = sConn
        ' Obj.ConnExe(SQL)
        ' SQL = "INSERT INTO events_general (SID,shrtEv,lngEv,Sev) VALUES (" & ServerID & _
        '                     ",'Reset Reported Count','Device Reported Status was set to False','INFO')"
        ' Obj.ConnExe(SQL)
        ' MsgBox(ServerName & " Reset Reported Count is complete!")
        ' Call LoadData()
        ' Call frmMain.LoadData()
    End Sub
End Class