
Partial Class Master_bssm_default
    Inherits System.Web.UI.MasterPage
    Public MyTitle As String
    Public strDateTime As String
    Public Version As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Desided to say fuck it and throw it all in on
        Page.Title = MyTitle
        strDateTime = Now
        Version = System.Configuration.ConfigurationManager.AppSettings("Version")
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim sLookFor As String = txtSearch.Text
        Dim sLookIn As String = rblSearchBy.SelectedValue
        'Session("SearchedFor") = MyRes
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
        'Response.Redirect("search.aspx?LookFor=" & MyRes)
    End Sub
End Class

