Imports BSServerMonitor.BurnSoft.GlobalClasses
Public Class frmAddCollector

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            Dim sName As String = FluffContent(txtName.Text)
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            If Not IsRequired(sName, "Server Name", Me.Text) Then Exit Sub
            If Not Obj.DataExists("SELECT * from list_collectors where ServerName='" & sName & "'") Then
                Dim SQL As String = "INSERT INTO list_collectors (ServerName) VALUES ('" & sName & "')"
                Obj.ConnExe(SQL)
                MsgBox(sName & " was added to the collector list.")
            Else
                MsgBox(sName & " already existed in the database")
            End If
            Obj = Nothing
            Me.Close()
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & "." & "btnAdd_Click")
        End Try
    End Sub
End Class