Imports System.Windows.Forms
Imports System.IO
Imports System.Text
Imports BurnSoft.FileSystem
Module modGlobal
    Public DO_DEBUG As Boolean
    Public DEBUG_LOGFILE As String
    Public CONSOLEMODE As Boolean
    Public MyLogFile As String
    Public USE_EVENT_LOG As Boolean
    Public USE_LOGFILE As Boolean
#Region "Direcotry Related"
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
#End Region
#Region "Error Catching & debugging"
    Public Sub CatchError(ByVal strMsg As String, ByVal strLocation As String)
        Dim DoLog As Boolean = True
        Dim sMsg As String = "::" & strLocation & "::" & strMsg
        If Not DoLog Then
            If CONSOLEMODE Then Console.WriteLine(sMsg)
            Console.ReadLine()
        Else
            Dim Obj As New FileIO
            Obj.LogFile(Application.StartupPath & "\" & MyLogFile, sMsg)
            Obj = Nothing
        End If
    End Sub
    Public Sub CatchDebug(ByVal strMsg As String, ByVal strLocation As String)
        If Not DO_DEBUG Then Exit Sub
        Dim DoLog As Boolean = True
        Dim sMsg As String = "::" & strLocation & "::" & strMsg
        If Not DoLog Then
            If CONSOLEMODE Then Console.WriteLine(sMsg)
            Console.ReadLine()
        Else
            Dim Obj As New FileIO
            Obj.LogFile(Application.StartupPath & "\" & DEBUG_LOGFILE, sMsg)
            Obj = Nothing
        End If
    End Sub
#End Region
#Region "Command Line Switches"
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
#End Region
#Region "Date Checking"
    Public Function IsEndOfMonth(ByVal sdate As Date) As Boolean
        Dim bAns As Boolean = False
        Dim endDay As Long = Now.Day
        Dim thismonth As New Date(sdate.Year, sdate.Month, 1)
        Dim firstdaylastmonth As Date
        Dim lastdaylastmonth As Date

        firstdaylastmonth = thismonth.AddMonths(1)
        lastdaylastmonth = firstdaylastmonth.AddDays(-1)

        If sdate.Day = lastdaylastmonth.Day Then
            bAns = True
        Else
            bAns = False
        End If

        Return bAns
    End Function
    Public Function IsStartOfMonth(ByVal sdate As Date) As Boolean
        Dim bAns As Boolean = False
        Dim endDay As Long = Now.Day
        Dim thismonth As New Date(sdate.Year, sdate.Month, 1)
        Dim firstdaylastmonth As Date
        Dim lastdaylastmonth As Date

        firstdaylastmonth = thismonth.AddMonths(1)
        lastdaylastmonth = firstdaylastmonth.AddDays(-1)

        If sdate.Day = firstdaylastmonth.Day Then
            bAns = True
        Else
            bAns = False
        End If

        Return bAns
    End Function
#End Region
End Module
