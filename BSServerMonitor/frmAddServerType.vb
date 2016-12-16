Imports BSServerMonitor.BurnSoft.GlobalClasses
Public Class frmAddServerType
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim sName As String = FluffContent(txtName.Text)
            Dim sDesc As String = FluffContent(txtDesc.Text)
            Dim SQL As String = "INSERT INTO list_servers_types (`Cat`,`Desc`) VALUES('" & _
                                sName & "','" & sDesc & "')"
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            If Not Obj.DataExists("SELECT * from list_servers_types where Cat='" & sName & "'") Then
                Obj.ConnExe(SQL)
                MsgBox("The Type was added to the database.")
            Else
                MsgBox("This type was not added due to it already existing in the database.")
            End If
            Me.Close()
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, Me.Name & ".btnSave_Click")
        End Try
    End Sub
    Private Sub frmAddServerType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjAF As New BSAutoComplete
        txtName.AutoCompleteCustomSource = ObjAF.Server_Type_Exists
    End Sub
End Class