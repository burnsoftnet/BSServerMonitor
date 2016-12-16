Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Text
Imports Microsoft.Win32
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Threading
Imports System.Net
Imports System
Imports System.Management
Imports System.Windows.Forms
'Imports System.DirectoryServices
Imports System.Xml
Public Class BSOtherObjects
    Public Function StringCompair(ByVal sValue1 As String, ByVal sValue2 As String) As Boolean
        Dim bAns As Boolean = False
        If String.Compare(sValue1, sValue2) = 0 Then
            bAns = True
        End If
        Return bAns
    End Function
    Public Function ContentsExistsRegEx(ByVal sContent As String, ByVal sSearchFor As String) As Boolean
        Dim bAns As Boolean = False
        If (Regex.IsMatch(sContent, sSearchFor, RegexOptions.IgnoreCase)) Then
            bAns = True
        Else
            bAns = False
        End If
        Return bAns
    End Function
    Public Function ArraysEqual(ByVal first As Byte(), ByVal second As Byte()) As Boolean
        If (first Is second) Then
            Return True
        End If

        If (first Is Nothing OrElse second Is Nothing) Then
            Return False
        End If

        For i As Integer = 0 To first.Length - 1
            If (first(i) <> second(i)) Then
                Return False
            End If
        Next
        Return True
    End Function
    Private Declare Sub Sleep Lib "kernel32.dll" (ByVal dwMilliseconds As Long)
    '''<summary>
    ''' Uses the Stopwatch to pause the application for x amount of seconds
    ''' </summary>
    Public Sub Pause(ByVal iSecs As Long, Optional ByVal iIncrement As Long = 100)
        Dim stopwatch As Stopwatch = stopwatch.StartNew
        Thread.Sleep(iSecs * 1000)
        stopwatch.Stop()
    End Sub
    '''<summary>
    ''' More of a place holder for over commands, no code listed in this but has been used for other functions
    ''' </summary>
    Private Sub EventAction(ByVal sender As Object)

    End Sub
    '''<summary>
    ''' Sends an email
    ''' </summary>
    Public Sub SendMail(ByVal sTo As String, ByVal sFrom As String, ByVal sFrom_Name As String, ByVal sSubject As String, ByVal sMessage As String, ByVal MAIL_SERVER_NAME As String, Optional ByVal MAIL_SERVER_PORT As Integer = 25, Optional ByVal USEHTML As Boolean = True, Optional ByVal USEBCC As Boolean = False, Optional ByVal sBCC As String = "", Optional ByRef sErrMsg As String = "")
        'NOTE: This sub will send an email to a person or group of people in HTML Format
        Dim strSendFrom As MailAddress = New MailAddress(sFrom, sFrom_Name)
        Dim Message As MailMessage = New MailMessage
        Dim i As Integer = 0
        Dim strSplit As Array = Split(sTo, ",")
        Dim intBound As Integer = UBound(strSplit)
        Dim Client As New SmtpClient
        Message.From = strSendFrom
        If intBound <> 0 Then
            For i = 0 To intBound
                If Len(strSplit(i)) > 0 Then Message.To.Add(strSplit(i))
            Next
        Else
            Message.To.Add(sTo)
        End If
        If USEBCC Then
            Message.Bcc.Add(sBCC)
        End If
        Try
            Message.IsBodyHtml = USEHTML
            Message.Subject = sSubject
            Message.Body = sMessage
            Client.Host = MAIL_SERVER_NAME
            Client.Port = MAIL_SERVER_PORT
        Catch ex As Exception
            Dim strFrom As String = "ModGlobal"
            Dim strSubFunc As String = "SendMail"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            sErrMsg = sMsg & "::" & strFrom & "." & strSubFunc
        Finally
            Message.Dispose()
            Message = Nothing
            Client = Nothing
        End Try
    End Sub
    '''<summary>
    ''' Parses s tring of information based on the fireld or location that it is at in the string
    ''' </summary>
    Public Function Parse(ByVal sInput As String, ByVal lField As Integer, ByVal sDelimiter As String) As String
        Dim lLen As Long = 0
        Dim lCnt As Long = 0
        Dim lTmp As Long = 0
        Dim sTemp As String = ""
        Dim lPos As Long = 0
        Dim sAns As String = ""

        If lField < 0 Then
            sAns = vbNullString
            Return sAns
            Exit Function
        End If
        sTemp = vbNullString & Trim$(sInput) & sDelimiter
        For lCnt = 1 To lField
            lLen = Len(sTemp)
            lPos = InStr(1, sTemp, sDelimiter)
            lTmp = lLen - lPos
            sTemp = Right$(sTemp, lTmp)
        Next lCnt
        lPos = InStr(1, sTemp, sDelimiter)
        If lPos > 0 Then
            sTemp = Left$(sTemp, lPos - 1)
        End If
        sAns = Trim$(sTemp)
        Return sAns
    End Function
    '''<summary>
    ''' Uses My.User.Name to get the current user that is running the application
    ''' </summary>
    Public Function GetUserName() As String
        Dim sAns As String = ""
        Dim sSplit() = Split(My.User.Name, "\")
        Dim iBound As Integer = UBound(sSplit)
        If iBound >= 1 Then
            sAns = sSplit(iBound)
        Else
            sAns = My.User.Name
        End If
        Return sAns
    End Function
    '''<summary>
    ''' Uses SystemInformation.UserDomainName to get the Domain from the user that is running the applications
    ''' </summary>
    Public Function GetDomainName() As String
        Return SystemInformation.UserDomainName
    End Function
    '''<summary>
    ''' Uses SystemInformation.Network to see if it is network connected
    ''' </summary>
    Public Function IsOnNetWork() As Boolean
        Return SystemInformation.Network
    End Function
    '''<summary>
    ''' Uses SystemInformation.ComputerName to Get the Computer that the application is running on
    ''' </summary>
    Public Function GetComputerName() As String
        Return SystemInformation.ComputerName
    End Function
    '''<summary>
    ''' Uses SystemInformation.UserName to get the users that is running the applications
    ''' </summary>
    Public Function GetUsername2() As String
        Return SystemInformation.UserName
    End Function
    '''<summary>
    ''' Gets the instance of the selected XML node and returns as strind
    ''' </summary>
    Public Function GetXMLNode(ByVal instance As XmlNode) As String
        'NOTE:This will Get the Values that are stored in the XML Note.
        Dim MyAns As String = ""
        On Error Resume Next
        MyAns = instance.InnerText
        Return MyAns
    End Function
    '''<summary>
    ''' Searchs one string for a key word to see if there is a match
    ''' txt is the string of information you want to search
    ''' strSearch is the word/value that you are looking for
    ''' </summary>
    Function Found(ByVal Txt As String, ByVal strSearch As String) As Boolean
        Dim bAns As Boolean = False
        Dim POS As Integer = 0
        POS = InStr(1, Txt, strSearch, vbTextCompare)
        If POS <> 0 Then
            bAns = True
        Else
            bAns = False
        End If
        Return bAns
    End Function
    '''<summary>
    ''' This uses WMI to get the user that is logged on the local machine based on the who is signed on at the time
    ''' This scrolls through all the running processes on the PC to determine who is running the "explorer.exe" process. It then returns the username ready for comparison.
    ''' </summary>
    Public Function GetLoggedonUser() As String
        Dim sAns As String = ""
        Dim strCurrentUser As String = ""
        Dim moReturn As Management.ManagementObjectCollection
        Dim moSearch As Management.ManagementObjectSearcher
        Dim mo As Management.ManagementObject

        moSearch = New Management.ManagementObjectSearcher("Select * from Win32_Process")
        moReturn = moSearch.Get

        For Each mo In moReturn
            Dim arOwner(2) As String
            mo.InvokeMethod("GetOwner", arOwner)
            Dim strOut As String
            strOut = String.Format("{0} Owner {1} Domain {2}", mo("Name"), arOwner(0), arOwner(1))
            If (mo("Name") = "explorer.exe") Then
                sAns = String.Format("{0}", arOwner(0))
            End If
        Next
        Return sAns
    End Function
    '''<summary>
    ''' The Get Command will looks for Command Line Arguments, this on will return as string
    ''' the switch will be something like /mystring="this is fun"
    ''' if it is just /mystring then it will return what is set in the sDefault string.
    ''' </summary>
    Public Function GetCommand(ByVal strLookFor As String, ByVal sDefault As String, Optional ByRef DidExist As Boolean = False, Optional ByRef Switch As String = "/") As String
        Dim sAns As String = ""
        DidExist = False
        Dim cmdLine() As String = System.Environment.GetCommandLineArgs
        Dim i As Integer = 0
        Dim intCount As Integer = cmdLine.Length
        Dim strValue As String = ""
        If intCount > 1 Then
            For i = 1 To intCount - 1
                strValue = cmdLine(i)
                strValue = Replace(strValue, Switch, "")
                Dim strSplit() As String = Split(strValue, "=")
                Dim intLBound As Integer = LBound(strSplit)
                Dim intUBound As Integer = UBound(strSplit)
                If LCase(strSplit(intLBound)) = LCase(strLookFor) Then
                    If intUBound <> 0 Then
                        sAns = strSplit(intUBound)
                    Else
                        sAns = sDefault
                    End If
                    DidExist = True
                    Exit For
                End If
            Next
        End If
        Return LCase(sAns)
    End Function
    '''<summary>
    ''' The Get Command will looks for Command Line Arguments, this on will return as long
    ''' the switch will be something like /mylongvalue=92
    ''' if it is just /mylongvalue it will return the lDefault value
    ''' </summary>
    Public Function GetCommand(ByVal strLookFor As String, ByVal lDefault As Long, Optional ByRef DidExist As Boolean = False, Optional ByRef Switch As String = "/") As Long
        Dim lAns As Long = 0
        DidExist = False
        Dim cmdLine() As String = System.Environment.GetCommandLineArgs
        Dim i As Integer = 0
        Dim intCount As Integer = cmdLine.Length
        Dim strValue As String = ""
        If intCount > 1 Then
            For i = 1 To intCount - 1
                strValue = cmdLine(i)
                strValue = Replace(strValue, Switch, "")
                Dim strSplit() As String = Split(strValue, "=")
                Dim intLBound As Integer = LBound(strSplit)
                Dim intUBound As Integer = UBound(strSplit)
                If LCase(strSplit(intLBound)) = LCase(strLookFor) Then
                    If intUBound <> 0 Then
                        lAns = strSplit(intUBound)
                    Else
                        lAns = lDefault
                    End If
                    DidExist = True
                    Exit For
                End If
            Next
        End If
        Return lAns
    End Function
    '''<summary>
    ''' The Get Command will looks for Command Line Arguments, this on will return as boolean.
    ''' if the command is /swtich it will return as true since it did exist
    ''' you can also use /switch=false
    ''' </summary>
    Public Function GetCommand(ByVal strLookFor As String, ByVal bDefault As Boolean, Optional ByRef DidExist As Boolean = False, Optional ByRef Switch As String = "/") As Boolean
        Dim bAns As Long = bDefault
        DidExist = False
        Dim cmdLine() As String = System.Environment.GetCommandLineArgs
        Dim i As Integer = 0
        Dim intCount As Integer = cmdLine.Length
        Dim strValue As String = ""
        If intCount > 1 Then
            For i = 1 To intCount - 1
                strValue = cmdLine(i)
                strValue = Replace(strValue, Switch, "")
                Dim strSplit() As String = Split(strValue, "=")
                Dim intLBound As Integer = LBound(strSplit)
                Dim intUBound As Integer = UBound(strSplit)
                If LCase(strSplit(intLBound)) = LCase(strLookFor) Then
                    If intUBound <> 0 Then
                        bAns = strSplit(intUBound)
                    Else
                        bAns = True
                    End If
                    DidExist = True
                    Exit For
                End If
            Next
        End If
        Return bAns
    End Function
    '''<summary>
    ''' Usually Stands for Fluffy Content, this is usually good for formating SQL Strings
    ''' taking away the single qoute and putting a single qoute twice to prevent errors
    ''' on SQL commands.
    ''' </summary>
    Public Function FC(ByVal sValue As String, Optional ByVal DefaultValue As String = "") As String
        Dim sAns As String = ""
        sAns = Replace(sValue, "'", "''")
        If DefaultValue.Length > 0 Then If sAns.Length = 0 Then sAns = DefaultValue
        Return sAns
    End Function
    '''<summary>
    '''Converts 1's and 0's to boolean value
    '''</summary>
    Public Function ConvertToBool(ByVal iValue As Integer) As Boolean
        Dim bAns As Boolean = False
        If iValue >= 1 Then bAns = True
        Return bAns
    End Function
    '''<summary>
    '''Converts y,yes,n,no string values to boolean value
    '''</summary>
    Public Function ConvertToBool(ByVal sValue As String) As Boolean
        Dim bAns As Boolean = False
        Select Case LCase(sValue)
            Case "y"
                bAns = True
            Case "yes"
                bAns = True
            Case "n"
                bAns = False
            Case "no"
                bAns = False
        End Select
        Return bAns
    End Function
    Function AppendToString(ByVal sValue As String, ByVal MainValue As String) As String
        Dim sAns As String = MainValue
        Dim NL As String = Chr(10) & Chr(13)
        If Len(sAns) = 0 Then
            sAns = sValue
        Else
            sAns &= NL & sValue
        End If
        Return sAns
    End Function
End Class
