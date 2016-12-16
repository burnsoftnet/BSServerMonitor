
Partial Class Master_bssm_refresh
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
        Dim MyRes As String = txtSearch.Text
        Session("SearchedFor") = MyRes
        Response.Redirect("search.aspx")
    End Sub
End Class

