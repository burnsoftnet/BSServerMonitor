Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions
Public Class BSWebResponse
    Private _UseAuth As Boolean
    Private _Domain As String
    Private _UserName As String
    Private _Password As String
    Private _NTLM As Boolean
    Public Property UseAuthentication() As Boolean
        Get
            Return _UseAuth
        End Get
        Set(ByVal value As Boolean)
            _UseAuth = value
        End Set
    End Property
    Public Property UseNTLM() As Boolean
        Get
            Return _NTLM
        End Get
        Set(ByVal value As Boolean)
            _NTLM = value
        End Set
    End Property
    Public Property Domain() As String
        Get
            Return _Domain
        End Get
        Set(ByVal value As String)
            _Domain = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return _Password
        End Get
        Set(ByVal value As String)
            _Password = value
        End Set
    End Property
    ''' <summary>
    '''  Checks to see if the site is up, if there is an error connecting to it, or 500,401, etc then it will
    '''  return false and give the error message that was given, other wise it will return the contents of that
    '''  webpage and return it in the sHttpContext string, along with the lenght of time it took to get that page
    '''  in the iSecondsResponse 
    ''' </summary>
    ''' <remarks>
    '''  uses the following properties:
    '''  UseAuthentication, UseNTLM, UserName, Password And or Domain
    ''' </remarks>
    Public Function SiteIsUp(ByVal sURL As String, Optional ByRef sHttpContext As String = "", Optional ByRef ErrorMsg As String = "", Optional ByRef iSecondsResponse As Double = 0) As Boolean
        Dim bAns As Boolean = False
        Dim iSeconds_Start As Double = Timer
        Dim iSeconds_Stop As Double = 0
        Try
            Dim request As WebRequest = WebRequest.Create(sURL)
            If _UseAuth Then
                If Not _NTLM Then
                    Dim myCache As New CredentialCache
                    Dim myCred As NetworkCredential
                    If Len(_Domain) > 0 Then
                        myCred = New NetworkCredential(_UserName, _Password, _Domain)
                    Else
                        myCred = New NetworkCredential(_UserName, _Password)
                    End If
                    myCache.Add(New Uri(sURL), "Basic", myCred)
                    request.Credentials = myCache
                Else
                    request.Credentials = CredentialCache.DefaultCredentials
                End If
            End If
            Dim response As WebResponse = request.GetResponse()
            Dim sr As StreamReader = New StreamReader(response.GetResponseStream())
            iSeconds_Stop = Timer
            iSecondsResponse = iSeconds_Stop - iSeconds_Start
            sHttpContext = sr.ReadToEnd
            sr.Close()
            response.Close()
            response = Nothing
            request = Nothing
            bAns = True
        Catch ex As Exception
            ErrorMsg = ex.Message.ToString
        End Try
        Return bAns
    End Function
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
    Public Sub New()
        _UseAuth = False
        _Domain = ""
        _UserName = ""
        _Password = ""
        _NTLM = False
    End Sub
End Class
