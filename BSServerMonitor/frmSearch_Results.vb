Imports BSServerMonitor.BurnSoft.GlobalClasses
Public Class frmSearch_Results
    Public LookIn As String
    Public LookFor As String
    Public ExactMatch As Boolean
    Sub LoadData()
        Dim SQLLook As String = ""
        If ExactMatch Then
            SQLLook = LookFor
        Else
            SQLLook = "%" & LookFor & "%"
        End If
        Select Case LCase(LookIn)
            Case "server name"
                If ExactMatch Then
                    Me.View_servers_allTableAdapter.FillBy_SearchServerNameEx(Me.BssmDataSet.view_servers_all, SQLLook)
                Else
                    Me.View_servers_allTableAdapter.FillBy_SearchServerName(Me.BssmDataSet.view_servers_all, SQLLook)
                End If

            Case "ip address"
                If ExactMatch Then
                    Me.View_servers_allTableAdapter.FillBy_SearchServerIPAddressEx(Me.BssmDataSet.view_servers_all, SQLLook)
                Else
                    Me.View_servers_allTableAdapter.FillBy_SearchServerIPAddress(Me.BssmDataSet.view_servers_all, SQLLook)
                End If
            Case "display name"
                If ExactMatch Then
                    Me.View_servers_allTableAdapter.FillBy_SearchDisplayNameEx(Me.BssmDataSet.view_servers_all, SQLLook)
                Else
                    Me.View_servers_allTableAdapter.FillBy_SearchDisplayName(Me.BssmDataSet.view_servers_all, SQLLook)
                End If
            Case Else
                Me.View_servers_allTableAdapter.Fill(Me.BssmDataSet.view_servers_all)
        End Select
    End Sub
    Private Sub frmSearch_Results_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LoadData()
        If READ_ONLY Then
            UpdateStatusToolStripMenuItem.Enabled = False
            EnableServerToolStripMenuItem.Enabled = False
            DeleteDeviceToolStripMenuItem.Enabled = False
            MarkDeviceAsDeletedToolStripMenuItem.Enabled = False
            DisableDeviceToolStripMenuItem.Enabled = False
        End If
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
    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Call ViewData()
    End Sub
    Private Sub PingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PingToolStripMenuItem.Click
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
    End Sub
    Private Sub PingIPAddressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PingIPAddressToolStripMenuItem.Click
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
    End Sub
    Private Sub UpdateStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateStatusToolStripMenuItem.Click
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
    End Sub
    Private Sub ViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ViewToolStripMenuItem.Click
        Call ViewData()
    End Sub
    Private Sub EnableServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnableServerToolStripMenuItem.Click
        Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
        Dim ServerID As String = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
        Dim SQL As String = "UPDATE list_servers set IsEnabled=1 where ID=" & ServerID
        Dim Obj As New BSDatabase
        Obj.MYCONNSTRING = sConn
        Obj.ConnExe(SQL)
        MsgBox(ServerName & " has been enabled!")
        Call LoadData()
    End Sub
    Private Sub DeleteDeviceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteDeviceToolStripMenuItem.Click
        Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
        Dim SID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
        Try
            Dim sMsg As String = MsgBox("Are you sure you wish to delete " & ServerName & "?", MsgBoxStyle.YesNo, Me.Text)
            If sMsg = vbYes Then
                Dim Obj As New BSDatabase
                Obj.MYCONNSTRING = sConn
                Obj.ConnExe("call sp_server_delete(" & SID & ")")
                Call LoadData()
            End If
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "DeleteDeviceToolStripMenuItem.Click")
        End Try
    End Sub
    Private Sub MarkDeviceAsDeletedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarkDeviceAsDeletedToolStripMenuItem.Click
        Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
        Dim ServerID As String = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
        Dim SQL As String = "UPDATE list_servers set IsEnabled=0, CS=5 where ID=" & ServerID
        Dim Obj As New BSDatabase
        Obj.MYCONNSTRING = sConn
        Obj.ConnExe(SQL)
        SQL = "INSERT INTO events_general (SID,shrtEv,lngEv,Sev) VALUES (" & ServerID & _
                            ",'Marked As Deleted','Device was Marked as Deleted','INFO')"
        Obj.ConnExe(SQL)
        MsgBox(ServerName & " Marked as Deleted!")
        Call LoadData()
        Call frmMain.LoadData()
    End Sub
    Private Sub DisableDeviceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisableDeviceToolStripMenuItem.Click
        Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(3).Value
        Dim ServerID As String = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
        Dim SQL As String = "UPDATE list_servers set IsEnabled=0 where ID=" & ServerID
        Dim Obj As New BSDatabase
        Obj.MYCONNSTRING = sConn
        Obj.ConnExe(SQL)
        MsgBox(ServerName & " has been disabled!")
        Call LoadData()
    End Sub

End Class