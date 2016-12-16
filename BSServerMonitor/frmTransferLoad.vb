Imports BSServerMonitor.BurnSoft.GlobalClasses
Public Class frmTransferLoad
    Public ServerName As String
    Public SID As Long
    Private Sub frmTransferLoad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txtFrom.Text = ServerName
            Me.View_collector_listTableAdapter.Fill(Me.BssmDataSet.view_collector_list)
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "frmTransferLoad_Load")
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
        Try
            Dim NID As Long = cmbTo.SelectedValue
            Dim NName As String = cmbTo.Text
            Dim sMsg As String = "Clients where moved to " & NName
            Dim SQL As String = "UPDATE list_servers set CID=" & NID & " where CID=" & SID
            Dim obj As New BSDatabase
            obj.MYCONNSTRING = sConn
            obj.ConnExe(SQL)
            MsgBox(sMsg)
            Me.Close()
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "btnTransfer_Click")
        End Try
    End Sub
End Class