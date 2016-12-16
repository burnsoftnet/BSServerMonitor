Imports MySql.Data.MySqlClient
Imports BSServerMonitor.BurnSoft.GlobalClasses
Imports Microsoft.Reporting.WinForms
Public Class frmView_Server_Details
    Public ServerName As String
    Public SID As Long
    Dim iTID As Long
    Public OK_TO_UPDATE As Boolean
    Public IsEditMode As Boolean
    Public Sub LoadData()
        Try
            'Me.Results_traceTableAdapter.FillBy_ServerID(Me.BssmDataSet.results_trace, SID)
            'Me.List_servers_portsTableAdapter.FillBy_ServerID(Me.BssmDataSet.list_servers_ports, SID)
            'Me.Events_generalTableAdapter.FillBy_ServerID(Me.BssmDataSet.events_general, SID)
            'Me.View_ping_timepingstatsTableAdapter.FillBy_ServerID_Limited(Me.BssmDataSet.view_ping_timepingstats, SID, ToolStripTextBox1.Text)
            Me.Text = "Details for " & ServerName
            Dim SQL As String = "SELECT * from list_servers where ID=" & SID
            Dim Obj As New BSDatabase
            Dim ObjGF As New BSGlobalFunctions
            Dim sStatus As String = ""
            Obj.MYCONNSTRING = sConn
            Obj.ConnectDB()
            Dim CMD As New MySqlCommand(SQL, Obj.Conn)
            Dim RS As MySqlDataReader
            RS = CMD.ExecuteReader
            While RS.Read
                txtServerName.Text = RS("ServerName")
                txtDisName.Text = RS("DisplayName")
                txtIP.Text = RS("ServerIPAddress")
                iTID = CLng(RS("TID"))
                txtType.Text = CStr(ObjGF.GetDeviceType(iTID))
                Select Case RS("CS")
                    Case 0
                        sStatus = "DOWN"
                    Case 1
                        sStatus = "UP"
                    Case 2
                        sStatus = "IP CHANGED"
                    Case 3
                        sStatus = "DISABLED"
                    Case 4
                        sStatus = "SLOW"
                    Case 5
                        sStatus = "DELETED"
                    Case Else
                        sStatus = "UNKNOWN"
                End Select
                lblCollector.Text = GetCollectorName(RS("CID"))
                txtLS.Text = sStatus
                txtDA.Text = RS("DTAdded")
                chkEnabled.Checked = INT_TO_BOOL(RS("IsEnabled"))
                chkPing.Checked = INT_TO_BOOL(RS("DoPing"))
                chkTrace.Checked = INT_TO_BOOL(RS("DoTrace"))
                chkPort.Checked = INT_TO_BOOL(RS("DoPort"))
                chkHTTP.Checked = INT_TO_BOOL(RS("DoHTTP"))
                chkIIPAC.Checked = INT_TO_BOOL(RS("IIPAC"))
                nudPings.Value = RS("PingRepeats")
            End While
            RS = Nothing
            CMD = Nothing
            Obj.CloseDB()
            Obj = Nothing
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "LoadData")
            Select Case Err.Number
                Case 5
                    Dim sSplit() As String = Split(sConn, ";")
                    Dim DBServer As String = sSplit(0)
                    sMsg = "Lost Connection to the Database!" & Chr(10) & ex.Message.ToString & _
                            Chr(10) & "Check Database " & DBServer
                    MsgBox(sMsg)
                Case Else
                    MsgBox("Unknown error:" & Err.Number & "::" & ex.Message.ToString)
            End Select
        End Try
        OK_TO_UPDATE = True
    End Sub
    Public Sub CreateViewOnlyMode()
        If READ_ONLY Then
            ToolStripButton1.Enabled = False
            ToolStripButton3.Enabled = False
            chkEnabled.Enabled = False
            chkPing.Enabled = False
            chkTrace.Enabled = False
            chkPort.Enabled = False
            chkHTTP.Enabled = False
            chkIIPAC.Enabled = False
            lblCollector.Enabled = False
        End If
    End Sub
    Sub LoadDailyStats()
        Me.uptime_stats_dailyTableAdapter.FillBy_SID(Me.BssmDataSet.uptime_stats_daily, SID)
        Dim parmList As New Generic.List(Of ReportParameter)
        parmList.Add(New ReportParameter("SID", SID))
        Me.ReportViewer1.LocalReport.SetParameters(parmList)
        Me.ReportViewer1.RefreshReport()
    End Sub
    Sub LoadMOnthlyStats()
        Me.uptime_stats_monthlyTableAdapter.FillBy_SID(Me.BssmDataSet.uptime_stats_monthly, SID)
        Dim parmList As New Generic.List(Of ReportParameter)
        parmList.Add(New ReportParameter("SID", SID))
        Me.ReportViewer2.LocalReport.SetParameters(parmList)
        Me.ReportViewer2.RefreshReport()
    End Sub
    Sub LoadYearlyStats()
        Me.uptime_stats_yearlyTableAdapter.FillBy_SID(Me.BssmDataSet.uptime_stats_yearly, SID)
        Dim parmList As New Generic.List(Of ReportParameter)
        parmList.Add(New ReportParameter("SID", SID))
        Me.ReportViewer3.LocalReport.SetParameters(parmList)
        Me.ReportViewer3.RefreshReport()
    End Sub
    Private Sub frmView_Server_Details_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.List_servers_typesTableAdapter.Fill(Me.BssmDataSet.list_servers_types)
            ToolStripTextBox1.Text = VIEW_SERVERDETAILS_PING_LIMIT
            Call CreateViewOnlyMode()
            Call LoadData()
            'Call LoadDailyStats()
        Catch ex As Exception
            Dim sMsg As String = ""
            Select Case Err.Number
                Case 5
                    Dim sSplit() As String = Split(sConn, ";")
                    Dim DBServer As String = sSplit(0)
                    sMsg = "Lost Connection to the Database!" & Chr(10) & ex.Message.ToString & _
                            Chr(10) & "Check Database " & DBServer
                    MsgBox(sMsg)
                Case Else
                    MsgBox("Unknown error:" & Err.Number & "::" & ex.Message.ToString)
            End Select
        End Try
    End Sub
    Private Sub frmView_Server_Details_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.Width > 0 Then
            TabControl1.Width = Me.Width - 5
            TabControl1.Height = Me.Height - 60
        End If
    End Sub
    Private Sub chkEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnabled.CheckedChanged
        If Not OK_TO_UPDATE Then Exit Sub
        Dim sCol As String = "IsEnabled"
        If chkEnabled.Checked Then
            Call UpdateStatus(SID, 1, sCol)
        Else
            Call UpdateStatus(SID, 0, sCol)
        End If
    End Sub
    Private Sub chkPing_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPing.CheckedChanged
        If Not OK_TO_UPDATE Then Exit Sub
        Dim sCol As String = "DoPing"
        If chkPing.Checked Then
            Call UpdateStatus(SID, 1, sCol)
        Else
            Call UpdateStatus(SID, 0, sCol)
        End If
    End Sub
    Private Sub chkTrace_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTrace.CheckedChanged
        If Not OK_TO_UPDATE Then Exit Sub
        Dim sCol As String = "DoTrace"
        If chkTrace.Checked Then
            Call UpdateStatus(SID, 1, sCol)
        Else
            Call UpdateStatus(SID, 0, sCol)
        End If
    End Sub
    Private Sub chkPort_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPort.CheckedChanged
        If Not OK_TO_UPDATE Then Exit Sub
        Dim sCol As String = "DoPort"
        If chkPort.Checked Then
            Call UpdateStatus(SID, 1, sCol)
        Else
            Call UpdateStatus(SID, 0, sCol)
        End If
    End Sub
    Private Sub chkHTTP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkHTTP.CheckedChanged
        If Not OK_TO_UPDATE Then Exit Sub
        Dim sCol As String = "DoHTTP"
        If chkHTTP.Checked Then
            Call UpdateStatus(SID, 1, sCol)
        Else
            Call UpdateStatus(SID, 0, sCol)
        End If
    End Sub
    Sub StartEditMode()
        IsEditMode = True
        txtServerName.Enabled = True
        txtDisName.Enabled = True
        txtIP.Enabled = True
        ToolStripButton2.Enabled = True
        txtIP.ReadOnly = False
        txtDisName.ReadOnly = False
        txtServerName.ReadOnly = False
        ComboBox1.Visible = True
        ComboBox1.SelectedValue = iTID
        txtType.Visible = False
    End Sub
    Sub EndEditMode()
        txtServerName.Enabled = False
        txtDisName.Enabled = False
        txtIP.Enabled = False
        ToolStripButton2.Enabled = False
        txtIP.ReadOnly = True
        txtDisName.ReadOnly = True
        txtServerName.ReadOnly = True
        ComboBox1.Visible = False
        txtType.Visible = True
        IsEditMode = False
    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            Dim TID As Long = ComboBox1.SelectedValue
            txtType.Text = ComboBox1.SelectedText
            Obj.ConnExe("UPDATE list_servers set ServerName='" & txtServerName.Text & "',DisplayName='" & _
                txtDisName.Text & "',ServerIPAddress='" & txtIP.Text & "', TID=" & TID & " where ID=" & SID)
            Call EndEditMode()
            frmMain.LoadData()
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "ToolStripButton2.Click")
        End Try
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Call StartEditMode()
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Try
            Dim sMsg As String = MsgBox("Are you sure you wish to delete " & ServerName & "?", MsgBoxStyle.YesNo, Me.Text)
            If sMsg = vbYes Then
                Dim Obj As New BSDatabase
                Obj.MYCONNSTRING = sConn
                Obj.ConnExe("call sp_server_delete(" & SID & ")")
                frmMain.LoadData()
                Me.Close()
            End If
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "ToolStripButton3.Click")
        End Try
    End Sub
    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Me.Close()
    End Sub
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim TSID As Long = DataGridView1.SelectedRows.Item(0).Cells.Item(0).Value
        Dim frmNew As New frmView_PingDetails
        frmNew.TSID = TSID
        frmNew.MdiParent = Me.MdiParent
        frmNew.Show()
    End Sub
    Private Sub chkIIPAC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIIPAC.CheckedChanged
        If Not OK_TO_UPDATE Then Exit Sub
        Dim sCol As String = "IIPAC"
        If chkIIPAC.Checked Then
            Call UpdateStatus(SID, 1, sCol)
        Else
            Call UpdateStatus(SID, 0, sCol)
        End If
    End Sub

    Private Sub lblCollector_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCollector.Click
        frmAddToCollector.MdiParent = Me.MdiParent
        frmAddToCollector.SID = SID
        frmAddToCollector.Show()
        Me.Close()
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Me.Cursor = Cursors.WaitCursor
        Me.View_ping_timepingstatsTableAdapter.FillBy_ServerID_Limited(Me.BssmDataSet.view_ping_timepingstats, SID, ToolStripTextBox1.Text)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub PingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PingToolStripMenuItem.Click
        Try
            Dim ServerName As String = DataGridView4.SelectedRows.Item(0).Cells.Item(3).Value
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
    Private Sub frmView_Server_Details_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If Not IsEditMode Then If LCase(e.KeyChar) = "i" Then MsgBox("Server ID= " & SID)
    End Sub

    Private Sub TabControl1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TabControl1.KeyDown
        Select Case (e.KeyValue)
            Case 27
                Me.Close()
                'If Not IsEditMode Then Call StartEditMode()
        End Select
    End Sub

    Private Sub TabControl1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TabControl1.KeyPress
        If Not IsEditMode Then If LCase(e.KeyChar) = "i" Then MsgBox("Server ID= " & SID)
    End Sub
    Private Sub TabControl1_Selected(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlEventArgs) Handles TabControl1.Selected
        Dim TabSelected As String = e.TabPage.Text
        Select Case TabSelected
            Case "Events"
                Me.Cursor = Cursors.WaitCursor
                Me.Events_generalTableAdapter.FillBy_ServerID(Me.BssmDataSet.events_general, SID)
                Me.Cursor = Cursors.Default
                DataGridView2.CurrentCell = Nothing
            Case "Ping Results"
                Me.Cursor = Cursors.WaitCursor
                'Me.View_ping_timepingstatsTableAdapter.Connection.ConnectionTimeout = 120
                Me.View_ping_timepingstatsTableAdapter.FillBy_ServerID_Limited(Me.BssmDataSet.view_ping_timepingstats, SID, ToolStripTextBox1.Text)
                Me.Cursor = Cursors.Default
                DataGridView1.CurrentCell = Nothing
            Case "Active Ports"
                Me.Cursor = Cursors.WaitCursor
                Me.List_servers_portsTableAdapter.FillBy_ServerID(Me.BssmDataSet.list_servers_ports, SID)
                Me.Cursor = Cursors.Default
                DataGridView3.CurrentCell = Nothing
            Case "Trace Results"
                Me.Cursor = Cursors.WaitCursor
                Me.Results_traceTableAdapter.FillBy_ServerID(Me.BssmDataSet.results_trace, SID)
                Me.Cursor = Cursors.Default
                DataGridView4.CurrentCell = Nothing
            Case "Daily Uptime"
                Me.Cursor = Cursors.WaitCursor
                Call LoadDailyStats()
                Me.Cursor = Cursors.Default
            Case "Monthly Uptime"
                Me.Cursor = Cursors.WaitCursor
                Call LoadMOnthlyStats()
                Me.Cursor = Cursors.Default
            Case "Yearly Uptime"
                Me.Cursor = Cursors.WaitCursor
                Call LoadYearlyStats()
                Me.Cursor = Cursors.Default
        End Select
    End Sub

    Private Sub DataGridView2_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        If DataGridView2.Columns(e.ColumnIndex).Name = "SevDataGridViewTextBoxColumn" Then
            Select Case UCase(e.Value)
                Case "WARNING"
                    e.CellStyle.BackColor = Color.Yellow
                    e.FormattingApplied = True
                Case "DOWN"
                    e.CellStyle.BackColor = Color.Red
                    e.FormattingApplied = True
                Case "ERROR"
                    e.CellStyle.BackColor = Color.Red
                    e.FormattingApplied = True
                Case "IP CHANGED"
                    e.CellStyle.BackColor = Color.Yellow
                    e.FormattingApplied = True
            End Select
        End If
    End Sub

    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.Columns(e.ColumnIndex).Name = "LsDataGridViewTextBoxColumn" Then
            Select Case UCase(Trim(e.Value))
                Case "WARNING"
                    e.CellStyle.BackColor = Color.Yellow
                    e.FormattingApplied = True
                Case "DOWN"
                    e.CellStyle.BackColor = Color.Red
                    e.FormattingApplied = True
                Case "ERROR"
                    e.CellStyle.BackColor = Color.Red
                    e.FormattingApplied = True
                Case "IP CHANGED"
                    e.CellStyle.BackColor = Color.Yellow
                    e.FormattingApplied = True
                Case "UP"
                    e.CellStyle.BackColor = Color.Green
                    e.FormattingApplied = True
                Case "SLOW"
                    e.CellStyle.BackColor = Color.Yellow
                    e.FormattingApplied = True
            End Select
        End If
    End Sub
End Class