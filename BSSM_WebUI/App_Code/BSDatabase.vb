Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient
Namespace BurnSoft
    Public Class BSDatabase
        Public Conn As MySqlConnection
        Public Function ConnectDB() As Integer
            Dim ians As Integer = 0
            Dim sConnect As String = System.Configuration.ConfigurationManager.ConnectionStrings("bssmConnectionString").ToString
            Err.Clear()
            Try
                Conn = New MySqlConnection(sConnect)
                Conn.Open()
            Catch ex As Exception
                ians = Err.Number
            End Try
            Return ians
        End Function
        Public Function OpenDBForRead(ByVal SQL As String) As MySqlDataReader
            ConnectDB()
            Dim CMD As New MySqlCommand(SQL, Conn)
            Return CMD.ExecuteReader
        End Function
        Public Sub CloseDB()
            If Conn.State = Data.ConnectionState.Open Then
                Conn.Close()
            End If
            Conn = Nothing
        End Sub
    End Class
End Namespace
