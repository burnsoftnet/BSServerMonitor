Imports MySql.Data.MySqlClient
Imports BSSM_Setup.BurnSoft.GlobalClasses
Imports System.Configuration
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath
Module modGlobal
    Public Conn As MySqlConnection
    Public CONSOLEMODE As Boolean
    Public MyLogFile As String
    Public MYCONNSTRING As String
    Public DEBUG_LOGFILE As String
    Public DEBUG As Boolean
    Public Function ConnectDB() As Integer
        Dim iAns As Integer = 0
        Err.Clear()
        Try
            Dim sConnect As String = MYCONNSTRING
            Conn = New MySqlConnection(sConnect)
            Conn.Open()
        Catch ex As Exception
            iAns = Err.Number
            Dim strForm As String = "modGlobal"
            Dim strSubFunc As String = "ConnectDB"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
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
            Dim strForm As String = "modGlobal"
            Dim strSubFunc As String = "ConnExe"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
    Public Function GetTimeValue(ByVal SQL As String, ByVal strCol As String) As Long
        Dim lAns As Long = 0
        Try
            If ConnectDB() = 0 Then
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    lAns = RS(strCol)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
        Catch ex As Exception
            Dim strForm As String = "modGlobal"
            Dim strSubFunc As String = "GetTimeValue"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return lAns
    End Function
    Public Function ShortPath() As String
        Dim strPath As String
        Dim strSplit() As String
        Dim IntBound As Integer
        Dim sAns As String = ""
        Dim i As Integer

        strPath = Replace(Application.StartupPath, " ", "")

        strSplit = Split(strPath, "\")
        IntBound = UBound(strSplit)
        If IntBound > 0 Then
            For i = 0 To IntBound
                If Len(strSplit(i)) > 8 Then
                    sAns &= Left(Trim(strSplit(i)), 6) & "~2" & "\"
                Else
                    sAns &= strSplit(i) & "\"
                End If
            Next
        End If
        Return sAns
        Exit Function
    End Function
    Public Sub CatchError(ByVal strMsg As String, ByVal strLocation As String)
        Dim DoLog As Boolean = True
        Dim sMsg As String = "::" & strLocation & "::" & strMsg
        If Not DoLog Then
            If CONSOLEMODE Then Console.WriteLine(sMsg)
            Console.ReadLine()
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
            Console.ReadLine()
        Else
            Dim Obj As New BSFileSystem
            Obj.LogFile(Application.StartupPath & "\" & DEBUG_LOGFILE, sMsg)
            Obj = Nothing
        End If
    End Sub
    Function GetCommand(ByVal strLookFor As String, ByVal strType As String, ByRef DidExist As Boolean) As String
        Dim sAns As String = ""
        DidExist = False
        Select Case LCase(strType)
            Case "string"
                sAns = ""
            Case "bool"
                sAns = "false"
            Case "int"
                sAns = 0
            Case Else
                sAns = ""
        End Select
        Dim cmdLine() As String = System.Environment.GetCommandLineArgs
        Dim i As Integer = 0
        Dim intCount As Integer = cmdLine.Length
        Dim strValue As String = ""
        If intCount > 1 Then
            For i = 1 To intCount - 1
                strValue = cmdLine(i)
                strValue = Replace(strValue, "/", "")
                strValue = Replace(strValue, "--", "")
                Dim strSplit() As String = Split(strValue, "=")
                Dim intLBound As Integer = LBound(strSplit)
                Dim intUBound As Integer = UBound(strSplit)
                If LCase(strSplit(intLBound)) = LCase(strLookFor) Then
                    If intUBound <> 0 Then
                        sAns = strSplit(intUBound)
                    Else
                        sAns = "true"
                    End If
                    DidExist = True
                    Exit For
                End If
            Next
        End If
        Return LCase(sAns)
    End Function
    Public Function GetXMLNode(ByVal instance As XmlNode) As String
        Dim MyAns As String = ""
        Try
            MyAns = instance.InnerText
        Catch ex As Exception
            Dim strForm As String = "modBlobal"
            Dim strSubFunc As String = "GetXMLNode"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return MyAns
    End Function
    Function FC(ByVal sValue As String) As String
        Dim sAns As String = "N/A"
        If Len(sValue) > 0 Then
            sAns = Replace(sValue, "'", "''")
        End If
        Return sAns
    End Function
    Function IsEnabled(ByVal CID As Long) As Boolean
        Dim bAns As Boolean = False
        Try
            If CID <> 0 Then
                If ConnectDB() = 0 Then
                    Dim SQL As String = "SELECT * from list_collectors where ID=" & CID
                    Dim CMD As New MySqlCommand(SQL, Conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read
                        If RS("IsEnabled") = 1 Then
                            bAns = True
                        Else
                            bAns = False
                        End If
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Conn.Close()
                    Conn = Nothing
                End If
            Else
                bAns = True
            End If
        Catch ex As Exception
            Dim strForm As String = "modBlobal"
            Dim strSubFunc As String = "IsEnabled"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return bAns
    End Function
    Public Function INT_TO_BOOL(ByVal iValue As Integer) As Boolean
        Dim bAns As Boolean = False
        If iValue >= 1 Then bAns = True
        Return bAns
    End Function
End Module
