Imports MySql.Data.MySqlClient
Imports BurnSoft.Universal
Imports System.Configuration
Imports System.Windows.Forms
Module modGlobal
    Public Conn As MySqlConnection
    Public CONSOLEMODE As Boolean
    Public MyLogFile As String
    Public MYCONNSTRING As String
    Public DEBUG As Boolean
    Public DEBUG_LOGFILE As String
    Public Function ConnectDB() As Integer
        Dim iAns As Integer = 0
        Err.Clear()
        Try
            Dim sConnect As String = MYCONNSTRING
            Conn = New MySqlConnection(sConnect)
            Conn.Open()
        Catch ex As Exception
            iAns = Err.Number
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, "modGlobal.ConnectDB")
        End Try
        Return iAns
    End Function
    Public Sub ConnExe(ByVal SQL As String)
        Try
            If ConnectDB() = 0 Then
                Dim CMD As New MySqlCommand
                CMD.CommandText = SQL
                CMD.Connection = Conn
                CMD.ExecuteNonQuery()
                CMD.Connection.Close()
                CMD = Nothing
            End If
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, "modGlobal.ConnExe")
        End Try
    End Sub
    Public Function GetStringValueFromDB(ByVal SQL As String, ByVal strCol As String) As String
        Dim sAns As String = ""
        Try
            If ConnectDB() = 0 Then
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    sAns = RS(strCol)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
        Catch ex As Exception
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, "modGlobal.GetStringValueFromDB")
        End Try
        Return sAns
    End Function
    Public Sub CatchError(ByVal strMsg As String, ByVal strLocation As String)
        Dim DoLog As Boolean = True
        Dim sMsg As String = "::" & strLocation & "::" & strMsg
        If Not DoLog Then
            If CONSOLEMODE Then
                Console.WriteLine(sMsg)
                Console.WriteLine("Please hit enter to continue.")
                Console.ReadLine()
            End If
        Else
            Dim Obj As New BSFileSystem
            Obj.LogFile(Application.StartupPath & "\" & MyLogFile, sMsg)
            Obj = Nothing
        End If
    End Sub
    Public Sub CatchDebug(ByVal strMsg As String, ByVal strLocation As String)
        If Not DEBUG Then Exit Sub
        Dim DoLog As Boolean = True
        Dim sMsg As String = "::" & strLocation & "::" & strMsg
        If Not DoLog Then
            If CONSOLEMODE Then Console.WriteLine(sMsg)
            'Console.ReadLine()
        Else
            Dim Obj As New BSFileSystem
            Obj.LogFile(Application.StartupPath & "\" & DEBUG_LOGFILE, sMsg)
            Obj = Nothing
        End If
    End Sub
End Module
