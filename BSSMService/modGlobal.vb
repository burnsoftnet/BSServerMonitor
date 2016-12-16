Imports System.Windows.Forms
Imports BSSMService.BurnSoft.GlobalClasses
Imports mysql.Data.MySqlClient
Module modGlobal
    Public DO_DEBUG As Boolean
    Public DO_HEALTH_CHECK As Boolean
    Dim sConn As String
    Public Function ShortPath() As String
        Dim strSplit() As String
        Dim IntBound As Integer
        Dim sAns As String = ""
        Dim i As Integer
        Dim sPath As String = Application.StartupPath
        Dim strPath As String = Replace(sPath, " ", "")

        strSplit = Split(strPath, "\")
        IntBound = UBound(strSplit)
        If IntBound > 0 Then
            For i = 0 To IntBound
                If Len(strSplit(i)) > 8 Then
                    sAns &= Left(Trim(strSplit(i)), 6) & System.Configuration.ConfigurationManager.AppSettings("SHORTPATH") & "\"
                Else
                    sAns &= strSplit(i) & "\"
                End If
            Next
        End If
        Return sAns
        Exit Function
    End Function
    Public Function LastUpdateTime() As String
        Dim sAns As String = ""
        Try
            Dim Obj As New BSDatabase
            Obj.MYCONNSTRING = sConn
            If Obj.ConnectDB = 0 Then
                Dim SQL As String = "SELECT * from self_lastrun"
                Dim CMD As New MySqlCommand(SQL, Obj.Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    sAns = RS("LastRun")
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Obj.CloseDB()
            End If
        Catch ex As Exception
            Dim strForm As String = "GlobalVars"
            Dim strSubFunc As String = "LastUpdateTime"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            'Call MyNewService.CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return sAns
    End Function
    Function IsWorking(ByVal TIMER_INTERVAL As Long) As Boolean
        Dim bAns As Boolean = False
        Try
            Dim ObjR As New BSRegistry
            sConn = ObjR.GetDBSettings
            Dim LastTime As String = LastUpdateTime()
            Dim CurrentTime As String = Now
            Dim MaxTime As Long = (TIMER_INTERVAL * 2)
            Dim tDiff As Long = DateDiff(DateInterval.Minute, CDate(LastTime), CDate(CurrentTime))
            If tDiff < MaxTime Then bAns = True
        Catch ex As Exception
            Dim strForm As String = "GlobalVars"
            Dim strSubFunc As String = "IsWorking"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            'Call MyNewService.CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Return bAns
    End Function
End Module
