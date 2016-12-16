Imports BSServerMonitor.BurnSoft.GlobalClasses
Imports mysql.Data.MySqlClient
Public Class frmEditCollector
    Public CID As Long
    Sub LoadData()
        Try
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            If Obj.ConnectDB = 0 Then
                Dim SQL As String = "SELECT * FROM view_collector_list where ID=" & CID
                Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                Dim sActive As String = ""
                While RS.Read
                    If Not IsDBNull(RS("ID")) Then txtCollectorID.Text = RS("ID")
                    If Not IsDBNull(RS("ServerName")) Then txtName.Text = RS("ServerName")
                    If Not IsDBNull(RS("Status")) Then sActive = RS("Status")
                    If LCase(sActive) = LCase("Enabled") Then
                        chkActive.Checked = True
                    Else
                        chkActive.Checked = False
                    End If
                    If Not IsDBNull(RS("CL")) Then txtClientLoad.Text = RS("CL")
                    If Not IsDBNull(RS("LUD")) Then txtLUD.Text = RS("LUD")
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "LoadData")
        End Try
    End Sub
    Sub SaveData()
        Try
            Dim sName As String = FluffContent(txtName.Text)
            Dim ColID As Long = CLng(txtCollectorID.Text)
            Dim IsEnabled As Boolean = chkActive.Checked
            Dim iEnabled As Integer = 0
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            If IsEnabled Then iEnabled = 1
            Dim SQL As String = "Update list_collectors set ServerName='" & _
                                sName & "',IsEnabled=" & iEnabled & _
                                " where ID=" & ColID
            If Not IsRequired(sName, "Collector Name", Me.Text) Then Exit Sub
            Obj.ConnExe(SQL)
            Obj = Nothing
            Call frmView_Collectors.LoadData()
            Me.Close()
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "SaveData")
        End Try
    End Sub
    Private Sub frmEditCollector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LoadData()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Call SaveData()
    End Sub
End Class