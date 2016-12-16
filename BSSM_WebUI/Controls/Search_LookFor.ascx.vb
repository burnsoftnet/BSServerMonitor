
Partial Class Controls_Search_LookFor
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sLookFor As String = ""
        If Len(Request.QueryString("LookFor")) > 0 Then sLookFor = Request.QueryString("LookFor")
        txtLookFor.Text = sLookFor
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtLookFor.Text.Length > 0 Then
            Dim sLookFor As String = txtLookFor.Text
            Dim sLookIn As String = ddlLookIn.SelectedValue
            Dim sURL As String = "search_results.aspx?Lookfor=" & sLookFor
            Select Case LCase(sLookIn)
                Case "servername"
                    sURL &= "&LookIn=servername"
                Case "ip"
                    sURL &= "&LookIn=ip"
                Case "display"
                    sURL &= "&LookIn=display"
            End Select
            Response.Redirect(sURL)
        End If
    End Sub
End Class
