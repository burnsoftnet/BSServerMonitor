Public Class View_Types
    Public UpdatePending As Boolean
    Sub LoadData()
        Try
            Me.List_servers_typesTableAdapter.Fill(Me.BssmDataSet.list_servers_types)
        Catch ex As Exception
            Dim strForm As String = "View_Types"
            Dim strSubFunc As String = "LoadData"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub

    Private Sub View_Types_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LoadData()
        'Editing and Deleting is done through the DataGrid.
        'Double Click on the field that you wish to edit, 
        '   once you are done click on another field or hit your enter key
        'To Delete a Device, select the Row that you wish to delete and 
        '   hit yor delete key.
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        frmAddServerType.MdiParent = Me.MdiParent
        frmAddServerType.Show()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Call LoadData()
    End Sub

    Private Sub ListserverstypesBindingSource_CurrentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListserverstypesBindingSource.CurrentChanged

    End Sub

    Private Sub ListserverstypesBindingSource_ListChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs) Handles ListserverstypesBindingSource.ListChanged
        Try
            If Me.BssmDataSet.HasChanges Then
                Me.UpdatePending = True
            End If
        Catch ex As Exception
            Dim strForm As String = Me.Name
            Dim strSubFunc As String = "ListserverstypesBindingSource_ListChanged"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub

    Private Sub DataGridView1_RowValidated(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowValidated
        Try
            If Me.UpdatePending Then
                Me.List_servers_typesTableAdapter.Update(Me.BssmDataSet.list_servers_types)
                Me.UpdatePending = False
            End If
        Catch ex As Exception
            Dim strForm As String = Me.Name
            Dim strSubFunc As String = "DataGridView1_RowValidated"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
End Class