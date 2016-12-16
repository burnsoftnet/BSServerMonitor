
Partial Class search
    Inherits System.Web.UI.Page
    Public sHeader As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sHeader As String = Session("SearchedFor")
        If Len(Request.QueryString("LookFor")) > 0 Then sHeader = Request.QueryString("LookFor")

    End Sub
End Class
