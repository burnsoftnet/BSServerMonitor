Imports BSServerMonitor.BurnSoft.GlobalClasses
Public Class frmMoveToCollector
    Public CurCID As Long
    Public ServerName As String
    Private Sub frmMoveToCollector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.List_collectorsTableAdapter.Fill(Me.BssmDataSet.list_collectors)
        Me.Text = "Off load " & ServerName & " clients."
        Dim sMsg As String = "Select the new Collector that you wish to move the clients to or Select Move to Central Server to move to the main server."
    End Sub
    Sub ChangeValue(ByVal oldID As Long, ByVal NewID As Long)
        Try
            Dim SQL As String = "UPDATE list_servers set CID=" & NewID & " where CID=" & oldID
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            Obj.ConnExe(SQL)
        Catch ex As Exception
            Call CatchError(" - ERROR - " & Err.Number & " - " & ex.Message.ToString, Me.Name & "." & "ChangeValue")
        End Try
    End Sub
    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        Dim CID As Long = cmbCol.SelectedValue
        Call ChangeValue(CurCID, CID)
        Me.Close()
    End Sub

    Private Sub btnMTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMTC.Click
        Call ChangeValue(CurCID, 0)
        Me.Close()
    End Sub
End Class