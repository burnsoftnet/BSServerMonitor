Public Class frmSearch

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim lookfor As String = txtLookFor.Text
        Dim lookin As String = ComboBox1.Text
        Dim frmNew As New frmSearch_Results
        frmNew.LookFor = lookfor
        frmNew.LookIn = lookin
        frmNew.ExactMatch = CheckBox1.Checked
        frmNew.MdiParent = Me.MdiParent
        frmNew.Show()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class