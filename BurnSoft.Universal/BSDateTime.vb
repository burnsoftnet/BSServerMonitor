Public Class BSDateTime
    '''<summary>
    ''' Checks to see if the data that is passed is greater than or less then the current time
    ''' if not current then it is true
    ''' </summary>
    Public Function ISDatePastNow(ByVal sDate As String, Optional ByRef sErrMsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim dd As Long = DateDiff(DateInterval.Day, CDate(sDate), Now)
            If dd = 0 Then
                bAns = False
            ElseIf dd > 0 Then
                bAns = True
            ElseIf dd < 0 Then
                bAns = False
            End If
        Catch ex As Exception
            Dim strFrom As String = "modMain"
            Dim strSubFunc As String = "ISDatePastNow"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            sErrMsg = sMsg & "::" & strFrom & "." & strSubFunc
        End Try
        Return bAns
    End Function
    '''<summary>
    ''' Checks to see if the data that is passed is greater than or less then the current time
    ''' if not current then it is false
    ''' </summary>
    Public Function ISDateNow(ByVal sDate As String, Optional ByRef sErrMsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim dd As Long = DateDiff(DateInterval.Day, CDate(sDate), Now)
            If dd = 0 Then
                bAns = True
            ElseIf dd > 0 Then
                bAns = False
            ElseIf dd < 0 Then
                bAns = False
            End If
        Catch ex As Exception
            Dim strFrom As String = "modMain"
            Dim strSubFunc As String = "ISDateNow"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            sErrMsg = sMsg & "::" & strFrom & "." & strSubFunc
        End Try
        Return bAns
    End Function
    '''<summary>
    '''Checks to see if the data that is passed is greater than or less then the current time
    ''' if not current then it is true
    ''' </summary>
    Public Function ISDateBeforeNow(ByVal sDate As String, Optional ByRef sErrMsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim dd As Long = DateDiff(DateInterval.Day, CDate(sDate), Now)
            If dd = 0 Then
                bAns = False
            ElseIf dd > 0 Then
                bAns = False
            ElseIf dd < 0 Then
                bAns = True
            End If
        Catch ex As Exception
            Dim strFrom As String = "modMain"
            Dim strSubFunc As String = "ISDateBeforeNow"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            sErrMsg = sMsg & "::" & strFrom & "." & strSubFunc
        End Try
        Return bAns
    End Function
    '''<summary>
    ''' Format the date
    ''' IE: 5/5/04 will turn into 05/05/2004
    ''' Extract the elements
    ''' </summary>
    Public Function FormatDate(ByVal sDate As String) As String
        Dim sAns As String = ""
        Dim sArray As Object
        Dim iDateLoop As Integer
        Dim ObjM As New BSOtherObjects

        sArray = Split(sDate, "/", -1, vbTextCompare)
        For iDateLoop = 0 To 1
            If Len(sArray(iDateLoop)) = 1 Then
                sAns = sAns & "0" & sArray(iDateLoop) & "/"
            Else
                sAns = sAns + sArray(iDateLoop) & "/"
            End If
        Next iDateLoop
        sAns = sAns + ObjM.Parse(sArray(2), 0, " ")
        Return sAns
    End Function
    '''<summary>
    ''' Checks to see if the value is a valid date format
    ''' </summary>
    Public Function isValidDate(ByVal sDate As String) As Boolean
        If Len(sDate) < 10 Then
            Return False
            Exit Function
        End If
        On Error GoTo Trouble
        Dim x As String
        x = Err.Description

        Err.Clear()

        If Not Mid(sDate, 3, 1) = "/" Then
            Return False
            Exit Function
        End If
        If Not Mid(sDate, 6, 1) = "/" Then
            Return False
            Exit Function
        End If

        Dim strDate As String
        Dim datDate As Date

        strDate = sDate

        datDate = CDate(strDate)
        Return True
        Exit Function

Trouble:
        Return False

    End Function
    '''<summary>
    ''' convert the number of weeks into days
    ''' </summary>
    Public Function ConvertWeekToDays(ByVal iWeek As Long) As Long
        Dim lAns As Long = 0
        If iWeek = 1 Or iWeek = 0 Then
            lAns = 7
        Else
            lAns = 7 * iWeek
        End If
        Return lAns
    End Function
    '''<summary>
    ''' convert english to dateinterval
    ''' </summary>
    ''' <remarks>
    ''' sValue can be: day, hous, minute, or month
    ''' </remarks>
    Public Function ConvertType(ByVal sValue As String) As DateInterval
        Dim lAns As DateInterval = DateInterval.Hour
        Select Case LCase(sValue)
            Case "day"
                lAns = DateInterval.Day
            Case "hour"
                lAns = DateInterval.Hour
            Case "minute"
                lAns = DateInterval.Minute
            Case "month"
                lAns = DateInterval.Month
        End Select
        Return lAns
    End Function
    '''<summary>
    ''' Formats the date into an SQL Friendly date, used for SQL Commands
    ''' </summary>
    Public Function SQLFormatDate(ByVal myDate As String) As String
        myDate = FormatDateTime(myDate, DateFormat.ShortDate)
        Dim strSplit As Array = Split(myDate, "/")
        Dim stryear As String = strSplit(2)
        Dim strmonth As String = strSplit(0)
        Dim strday As String = strSplit(1)
        If Len(strmonth) = 1 Then strmonth = "0" & strmonth
        If Len(strday) = 1 Then strday = "0" & strday
        Dim sAns As String = stryear & "-" & strmonth & "-" & strday
        Return sAns
    End Function
End Class
