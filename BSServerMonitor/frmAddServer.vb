Imports System.Net.NetworkInformation
Imports MySql.Data.MySqlClient
Imports BSServerMonitor.BurnSoft.GlobalClasses
Public Class frmAddServer

    Private Sub frmAddServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'BssmDataSet.list_collectors' table. You can move, or remove it, as needed.
        Me.List_collectorsTableAdapter.Fill(Me.BssmDataSet.list_collectors)
        Me.List_servers_typesTableAdapter.Fill(Me.BssmDataSet.list_servers_types)
        lblDName.Visible = False
        txtDName.Visible = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Not CheckBox1.Checked Then
            lblDName.Visible = True
            txtDName.Visible = True
        Else
            lblDName.Visible = False
            txtDName.Visible = False
        End If
    End Sub
    Public Function ServerExists(ByVal strName As String, ByVal strIP As String, ByVal strDisplayName As String, Optional ByRef sMsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            If Obj.ConnectDB() = 0 Then
                Dim SQL As String = "SELECT * from list_servers where Servername like '%" & _
                                    strName & "%' and cs <> 5 or ServerIPAddress = '" & strIP & _
                                    "' and cs <> 5 or DisplayName like '%" & strDisplayName & "%' and cs <> 5"
                Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                Dim RS As MySqlDataReader
                Dim NL As String = Chr(10) & Chr(13)
                RS = CMD.ExecuteReader
                If RS.HasRows Then
                    bAns = True
                    While RS.Read
                        sMsg &= "Server Already Exists with the following Parameters:" & NL
                        sMsg &= "Server Name: " & RS("ServerName") & NL
                        sMsg &= "IP Address: " & RS("ServerIPAddress") & NL
                        sMsg &= "Display Name: " & RS("DisplayName")
                        sMsg &= NL & "Do you still wish to add this machine to the database?"
                    End While
                End If
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
        Catch ex As Exception
            Dim ssMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(ssMsg, Me.Name & ".ServerExists")
        End Try
        Return bAns
    End Function
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Dim TypeID As Long = cmbType.SelectedValue
            Dim strName As String = Trim(txtName.Text)
            Dim strDName As String = Trim(txtDName.Text)
            If CheckBox1.Checked Then strDName = strName
            Dim strIP As String = ""
            Dim instance As New Ping
            Dim Results As PingReply
            Dim IsEnabled As Integer = 0
            Dim CID As Long = 0
            If chkAutoAss.Checked Then
                Dim ObjGS As New BSGlobalFunctions
                CID = ObjGS.GetLowestCollector
            Else
                CID = cmbCollector.SelectedValue
            End If
            If chkEnabled.Checked Then IsEnabled = 1
            If chkEnabled.Checked Then
                Results = instance.Send(strName, 1500)
                strIP = Results.Address.ToString
            Else
                strIP = txtIP.Text
            End If
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            Dim SQL As String = "INSERT INTO list_servers(ServerName,ServerIPAddress,DisplayName,IsEnabled, TID,CID) VALUES('" & _
                                    strName & "','" & strIP & "','" & strDName & "'," & IsEnabled & "," & TypeID & "," & CID & ")"
            Dim sMsg As String = ""
            If ServerExists(strName, strIP, strDName, sMsg) Then
                Dim sAns As String = MsgBox(sMsg, MsgBoxStyle.YesNo, Me.Text)
                If sAns = vbYes Then
                    Call Obj.ConnExe(SQL)
                    MsgBox(strName & " was added to the database!")
                Else
                    MsgBox(strName & " was not added to the database!")
                End If
            Else
                Call Obj.ConnExe(SQL)
                MsgBox(strName & " was added to the database!")
            End If
            Call frmMain.LoadData()
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & ".btnAdd_Click")
            MsgBox(sMsg)
        End Try
        txtName.Text = ""
        txtDName.Text = ""
        txtIP.Text = ""
        chkEnabled.Checked = True
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub chkAutoAss_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoAss.CheckedChanged
        If chkAutoAss.Checked Then
            cmbCollector.Enabled = False
        Else
            cmbCollector.Enabled = True
        End If
    End Sub
End Class