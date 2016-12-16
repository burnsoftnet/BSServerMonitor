Imports BSServerMonitor.BurnSoft.GlobalClasses
Public Class frmAddToCollector
    Public SID As Long
    Private Sub frmAddToCollector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.List_collectorsTableAdapter.Fill(Me.BssmDataSet.list_collectors)
    End Sub
    Sub ChangeValue(ByVal iSID As Long, ByVal NewID As Long)
        Try
            Dim SQL As String = "UPDATE list_servers set CID=" & NewID & " where ID=" & iSID
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            Obj.ConnExe(SQL)
        Catch ex As Exception
            Call CatchError(" - ERROR - " & Err.Number & " - " & ex.Message.ToString, Me.Name & "." & "ChangeValue")
        End Try
    End Sub

    Private Sub btnMTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMTC.Click
        Call ChangeValue(SID, 0)
        Call frmView_Server_Details.LoadData()
        Me.Close()
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        Dim CID As Long = cmbCol.SelectedValue
        Call ChangeValue(SID, CID)
        'Call frmView_Server_Details.LoadData()
        Me.Close()
    End Sub
End Class