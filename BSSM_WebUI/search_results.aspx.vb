
Partial Class search_results
    Inherits System.Web.UI.Page
    Public sHeader As String
    Public LookIn As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        sHeader = Request.QueryString("LookFor")
        LookIn = Request.QueryString("LookIn")
        Dim sSQL As String = "SELECT Servername,ServerIPAddress,CS,DisplayName,cat  FROM web_view_servers_all"
        Select Case LCase(LookIn)
            Case "servername"
                sSQL &= " where servername like '%" & sHeader & "%'"
            Case "ip"
                sSQL &= " where ServerIPAddress like '%" & sHeader & "%'"
            Case "display"
                sSQL &= " where DisplayName like '%" & sHeader & "%'"
        End Select
        'Response.Write(sSQL)
        SqlDataSource1.SelectCommand = sSQL
    End Sub
End Class
