Imports BSServerMonitor.BurnSoft.GlobalClasses
Imports MySql.Data.MySqlClient
Public Class frmView_Collectors
    Dim IsEnabled As Boolean
    Function GetMasterCount() As Long
        Dim lAns As Long = 0
        Try
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            If Obj.ConnectDB() = 0 Then
                Dim SQL As String = "SELECT COUNT(*) as Total from list_servers where CID=0"
                Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    lAns = RS("Total")
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "GetMasterCount")
        End Try
        Return lAns
    End Function
    Sub LoadData()
        Try
            Dim iMaster As Integer = 0
            iMaster = GetMasterCount()
            lblMasterServerCount.Text = iMaster
            Me.View_collector_listTableAdapter.Fill(Me.BssmDataSet.view_collector_list)
            Call FormatCells()
        Catch ex As Exception
            Dim sMsg As String = ""
            Select Case Err.Number
                Case 5
                    Dim sSplit() As String = Split(sConn, ";")
                    Dim DBServer As String = sSplit(0)
                    sMsg = "Lost Connection to the Database!" & Chr(10) & ex.Message.ToString & _
                            Chr(10) & "Check Database " & DBServer
                    MsgBox(sMsg)
                    Timer1.Enabled = False
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
            ToolStripButton1.Enabled = False
            ContextMenuStrip1.Enabled = False
        End If
    End Sub
    Private Sub frmView_Collectors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call CreateViewOnlyMode()
            Call LoadData()
            Timer1.Enabled = True
            ToolStripButton3.Visible = False
            ToolStripButton4.Visible = True
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "Load")
        End Try
    End Sub
    Private Sub EnabledToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnabledToolStripMenuItem.Click
        'This will enabled a collector
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
                Dim SQL As String = "Update list_collectors set IsEnabled=1 where ID=" & RowID
                Dim Obj As New BSDatabase
                Obj.MYCONNSTRING = sConn
                Obj.ConnExe(SQL)
                Obj = Nothing
                Call LoadData()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "EnabledToolStripMenuItem_Click")
            End Try
        End If
    End Sub
    Private Sub DisabledToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisabledToolStripMenuItem.Click
        'This will disable a collector
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
                Dim SQL As String = "Update list_collectors set IsEnabled=0 where ID=" & RowID
                Dim Obj As New BSDatabase
                Obj.MYCONNSTRING = sConn
                Obj.ConnExe(SQL)
                Obj = Nothing
                Call LoadData()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "DisabledToolStripMenuItem_Click")
            End Try
        End If
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        'This will delete a collector.  Warning this will make the clients that the collector has 
        'becuase unused.
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
                Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(1).Value
                Dim SQL As String = "Delete from list_collectors where ID=" & RowID
                Dim sMsg As String = MsgBox("Are you sure you wish to delete " & ServerName & "?", MsgBoxStyle.YesNo, Me.Text)
                If sMsg = vbYes Then
                    Dim Obj As New BSDatabase
                    Obj.MYCONNSTRING = sConn
                    Obj.ConnExe(SQL)
                    Obj = Nothing
                    Call LoadData()
                End If
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "DeleteToolStripMenuItem_Click")
            End Try
        End If
    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            frmEditCollector.MdiParent = Me.MdiParent
            Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
            frmEditCollector.CID = RowID
            frmEditCollector.Show()
        End If
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        frmAddCollector.MdiParent = Me.MdiParent
        frmAddCollector.Show()
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Call LoadData()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call LoadData()
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        ToolStripButton3.Visible = False
        ToolStripButton4.Visible = True
        Timer1.Enabled = True
    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        ToolStripButton3.Visible = True
        ToolStripButton4.Visible = False
        Timer1.Enabled = False
    End Sub
    Private Sub MoveClientLoadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim frmNew As New frmMoveToCollector
                Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
                Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(1).Value
                frmNew.CurCID = RowID
                frmNew.ServerName = ServerName
                frmNew.MdiParent = Me.MdiParent
                frmNew.Show()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "MoveClientLoadToolStripMenuItem_Click")
            End Try
        End If
    End Sub

    Private Sub MoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim lMaster As Long = CLng(lblMasterServerCount.Text)
                Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
                Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(1).Value
                Dim SQL As String = "UPDATE list_servers set CID=" & RowID & " where CID=0"
                Dim Obj As New BSDatabase
                Obj.MYCONNSTRING = sConn
                Obj.ConnExe(SQL)
                MsgBox("All Clients have been moved from the master server to " & ServerName)
                Call LoadData()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "MoToolStripMenuItem_Click")
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
                Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(1).Value
                Dim frmNew As New frmView_Servers_by_Collector
                frmNew.CID = RowID
                frmNew.CollectorName = ServerName
                frmNew.MdiParent = Me.MdiParent
                frmNew.Show()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "DataGridView1_CellContentClick")
            End Try
        End If
    End Sub

    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripLabel1.Click
        Try
            Dim ServerName As String = "Master Server"
            Dim frmNew As New frmView_Servers_by_Collector
            frmNew.CID = 0
            frmNew.CollectorName = ServerName
            frmNew.MdiParent = Me.MdiParent
            frmNew.Show()
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "DataGridView1_CellContentClick")
        End Try
    End Sub
    Sub FormatCells()
        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            If DataGridView1.Rows(i).Cells("StatusDataGridViewTextBoxColumn").Value = "Enabled" Then
                Dim eVal As DateTime = CDate(DataGridView1.Rows(i).Cells("LUDDataGridViewTextBoxColumn").Value)
                Dim iDiff As Long = DateDiff(DateInterval.Minute, eVal, Now)
                If iDiff > 15 And iDiff < 30 Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                ElseIf iDiff > 30 Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.Red
                End If
            End If
        Next

    End Sub

    Private Sub MoveLoadToAnotherServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveLoadToAnotherServerToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
            Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(1).Value
            Dim frmNew As New frmTransferLoad
            frmNew.SID = RowID
            frmNew.ServerName = ServerName
            frmNew.MdiParent = Me.MdiParent
            frmNew.Show()
        End If
    End Sub

    Private Sub TerminalServerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TerminalServerToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(1).Value
                Dim myProcess As New Process
                myProcess.StartInfo.FileName = "mstsc.exe"
                myProcess.StartInfo.Arguments = " /v:" & ServerName & " /w:1024 /h:768"
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                myProcess.Start()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "TerminalServerToolStripMenuItem_Click")
            End Try
        End If
    End Sub

    Private Sub RestartBSSMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartBSSMToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(1).Value
                Dim myProcess As New Process
                myProcess.StartInfo.FileName = Application.StartupPath & "\tools\psservice.exe"
                myProcess.StartInfo.Arguments = " \\" & ServerName & " restart bssm"
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                myProcess.Start()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "RestartBSSMToolStripMenuItem_Click")
            End Try
        End If
    End Sub

    Private Sub StopBSSMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StopBSSMToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(1).Value
                Dim myProcess As New Process
                myProcess.StartInfo.FileName = Application.StartupPath & "\tools\psservice.exe"
                myProcess.StartInfo.Arguments = " \\" & ServerName & " stop bsm"
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                myProcess.Start()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "StopBSSMToolStripMenuItem_Click")
            End Try
        End If
    End Sub

    Private Sub StartBSSMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartBSSMToolStripMenuItem.Click
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim ServerName As String = DataGridView1.SelectedRows.Item(0).Cells.Item(1).Value
                Dim myProcess As New Process
                myProcess.StartInfo.FileName = Application.StartupPath & "\tools\psservice.exe"
                myProcess.StartInfo.Arguments = " \\" & ServerName & " start bsm"
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                myProcess.Start()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "StartBSSMToolStripMenuItem_Click")
            End Try
        End If
    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub EnabledToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnabledToolStripMenuItem1.Click
        'This will enabled load balancing on a collector
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
                Dim SQL As String = "Update list_collectors set IsBalanced=1 where ID=" & RowID
                Dim Obj As New BSDatabase
                Obj.MYCONNSTRING = sConn
                Obj.ConnExe(SQL)
                Obj = Nothing
                Call LoadData()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "EnabledToolStripMenuItem1_Click")
            End Try
        End If
    End Sub

    Private Sub DisabledToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisabledToolStripMenuItem1.Click
        'This will Disable load balancing on a collector
        If DataGridView1.SelectedRows.Count = 1 Then
            Try
                Dim RowID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
                Dim SQL As String = "Update list_collectors set IsBalanced=0 where ID=" & RowID
                Dim Obj As New BSDatabase
                Obj.MYCONNSTRING = sConn
                Obj.ConnExe(SQL)
                Obj = Nothing
                Call LoadData()
            Catch ex As Exception
                Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
                Call CatchError(sMsg, Me.Name & "." & "DisabledToolStripMenuItem1_Click")
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class