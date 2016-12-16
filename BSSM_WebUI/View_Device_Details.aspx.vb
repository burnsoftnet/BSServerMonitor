Imports BurnSoft
Imports MySql.Data.MySqlClient

Partial Class View_Device_Details
    Inherits System.Web.UI.Page
    Public DEVICENAME As String
    Function GetDeviceName(ByVal SID As Long) As String
        Dim sAns As String = "DEVICENAME"
        Dim Obj As New BSDatabase
        Dim RS As MySqlDataReader
        RS = Obj.OpenDBForRead("SELECT DisplayName from list_servers where ID=" & SID)
        While RS.Read
            sAns = RS("DisplayName")
        End While
        Return sAns
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            DEVICENAME = GetDeviceName(Request.QueryString("ID"))
        End If
    End Sub
End Class
