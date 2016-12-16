Imports System
Imports System.Windows.Forms
Imports System.DirectoryServices
Imports System.DirectoryServices.AccountManagement
Imports System.IO
Imports System.Text
Imports Microsoft.Win32
Imports System.Threading
Imports System.Net
Imports System.Security
Imports System.Security.Principal
Imports System.Text.StringBuilder
Imports System.Globalization
Public Class BSActiveDirectory
    Private _ADSIString As String
    Private _DOMAIN_NAME As String
    Private _DOMAIN_USER As String
    Private _DOMAIN_USER_PASSWORD As String
    Private _LDAP_STRING As String
    Private _LDAP_DOMAIN_NAME As String
    Private _SEARCH_FILTER_PAGESIZE As Long
    Public UseShareRunDir As Boolean
    Private Const ADS_NAME_INITTYPE_GC = 3  'Used for AD Table Translation
    Private Const ADS_NAME_TYPE_1779 = 1    'Used for AD Table Translation
    Private Const ADS_NAME_TYPE_NT4 = 3     'Used for AD Table Translation
    Private _APPLICATION_LAUNCH_PATH As String
#Region "Enumerations"
    Private Enum ADSIObject
        ADSI_Class = 1
        ADSI_Computer = 2
        ADSI_Domain = 3
        ADSI_FileService = 4
        ADSI_FileShare = 5
        ADSI_FPNWFileService = 6
        ADSI_FPNWFileShare = 7
        ADSI_FPNWResource = 8
        ADSI_FPNWResourcesCollection = 9
        ADSI_FPNWSession = 10
        ADSI_FPNWSessionsCollection = 11
        ADSI_Group = 12
        ADSI_GroupCollection = 13
        ADSI_LocalGroup = 14
        ADSI_LocalgroupCollection = 15
        ADSI_Namespace = 16
        ADSI_PrintJob = 17
        ADSI_Service = 18
        ADSI_User = 19
        ADSI_PrintJobsCollection = 20
        ADSI_PrintQueue = 21
        ADSI_Property = 22
    End Enum

    Public Enum ADAccountOptions
        UF_TEMP_DUPLICATE_ACCOUNT = 256
        UF_NORMAL_ACCOUNT = 512
        UF_INTERDOMAIN_TRUST_ACCOUNT = 2048
        UF_WORKSTATION_TRUST_ACCOUNT = 4096
        UF_SERVER_TRUST_ACCOUNT = 8192
        UF_DONT_EXPIRE_PASSWD = 65536
        UF_SCRIPT = 1
        UF_ACCOUNTDISABLE = 2
        UF_HOMEDIR_REQUIRED = 8
        UF_LOCKOUT = 16
        UF_PASSWD_NOTREQD = 32
        UF_PASSWD_CANT_CHANGE = 64
        UF_ACCOUNT_LOCKOUT = 16
        UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 128
    End Enum

    Public Enum LoginResult
        LOGIN_OK = 0
        LOGIN_USER_DOESNT_EXIST
        LOGIN_USER_ACCOUNT_INACTIVE
    End Enum

    Public Enum GroupSecurityType
        UNI_GROUP = 0
        LOCAL_GROUP = 1
        GLOBAL_GROUP = 2
    End Enum

    '''<summary>
    ''' Public Enumerations for USER OR COMPUTER
    ''' </summary>
    Public Enum AD_AccountType
        USER
        COMPUTER
    End Enum
#End Region
#Region "Properties"
    Public Property SEARCH_FILTER_PAGESIZE() As Long
        Get
            If _SEARCH_FILTER_PAGESIZE = 0 Then _SEARCH_FILTER_PAGESIZE = 30000
            Return _SEARCH_FILTER_PAGESIZE
        End Get
        Set(ByVal value As Long)
            _SEARCH_FILTER_PAGESIZE = value
        End Set
    End Property
    Public Property LDAP_STRING() As String
        Get
            Return _LDAP_STRING
        End Get
        Set(ByVal value As String)
            _LDAP_STRING = value
        End Set
    End Property
    Public Property LDAP_DOMAIN_NAME() As String
        Get
            Return _LDAP_DOMAIN_NAME
        End Get
        Set(ByVal value As String)
            _LDAP_DOMAIN_NAME = value
        End Set
    End Property
    Public Property DOMAIN_USER() As String
        Get
            Return _DOMAIN_USER
        End Get
        Set(ByVal value As String)
            _DOMAIN_USER = value
        End Set
    End Property
    Public Property DOMAIN_USER_PASSWORD() As String
        Get
            Return _DOMAIN_USER_PASSWORD
        End Get
        Set(ByVal value As String)
            _DOMAIN_USER_PASSWORD = value
        End Set
    End Property
    Public Property ADSIString() As String
        Get
            Return _ADSIString
        End Get
        Set(ByVal value As String)
            _ADSIString = value
        End Set
    End Property
    Public Property DOMAIN_NAME() As String
        Get
            Return _DOMAIN_NAME
        End Get
        Set(ByVal value As String)
            _DOMAIN_NAME = value
        End Set
    End Property
    Public Property APPLICATION_LAUNCH_PATH() As String
        Get
            Return _APPLICATION_LAUNCH_PATH
        End Get
        Set(ByVal value As String)
            _APPLICATION_LAUNCH_PATH = value
        End Set
    End Property
#End Region
#Region "Computer Related Functions"
    '''<summary>
    ''' Uses DirectoryServices to get the last time the Computer logged onto the domain
    ''' </summary>
    '''     ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Public Function DSC_GetComputerAccountLastLogon(ByVal ComputerName As String, Optional ByRef ErrMsg As String = "") As String
        Dim sAns As String = Today.Date
        Try
            Dim ctx As System.DirectoryServices.AccountManagement.PrincipalContext
            If AuthenticationIsSet() Then
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, DOMAIN_NAME, DOMAIN_USER, DOMAIN_USER_PASSWORD)
            Else
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            End If

            Dim Computer As System.DirectoryServices.AccountManagement.ComputerPrincipal = System.DirectoryServices.AccountManagement.ComputerPrincipal.FindByIdentity(ctx, ComputerName)
            If Computer IsNot Nothing Then
                sAns = Computer.LastLogon
            End If
        Catch ex As Exception
            ErrMsg = "ERROR GetComputerAccountLastLogon - " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to see if the Computer account is enabled
    ''' </summary>
    '''     ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Public Function DSC_IsComputerEnabled(ByVal ComputerName As String, Optional ByRef Errmsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim ctx As System.DirectoryServices.AccountManagement.PrincipalContext
            If AuthenticationIsSet() Then
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, DOMAIN_NAME, DOMAIN_USER, DOMAIN_USER_PASSWORD)
            Else
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            End If

            Dim Computer As System.DirectoryServices.AccountManagement.ComputerPrincipal = System.DirectoryServices.AccountManagement.ComputerPrincipal.FindByIdentity(ctx, ComputerName)
            If Computer IsNot Nothing Then
                bAns = Computer.Enabled
            End If
        Catch ex As Exception
            Errmsg = "ERROR DSC_IsComputerEnabled - " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return bAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to Enabled a computer Account
    ''' </summary>
    '''     ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Public Sub DSC_SetComputerAccountToEnable(ByVal ComputerName As String, Optional ByRef ErrMsg As String = "")
        Try
            Dim ctx As System.DirectoryServices.AccountManagement.PrincipalContext
            If AuthenticationIsSet() Then
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, DOMAIN_NAME, DOMAIN_USER, DOMAIN_USER_PASSWORD)
            Else
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            End If

            Dim Computer As System.DirectoryServices.AccountManagement.ComputerPrincipal = System.DirectoryServices.AccountManagement.ComputerPrincipal.FindByIdentity(ctx, ComputerName)
            If Computer IsNot Nothing Then
                Computer.Enabled = True
                Computer.Save()
            End If
        Catch ex As Exception
            ErrMsg = "ERROR SetComputerAccountToEnable - " & ex.Message.ToString & "::" & Err.Number
        End Try
    End Sub
    '''<summary>
    ''' Uses DirectoryServices to disable a computer account
    ''' </summary>
    '''     ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Public Sub DSC_SetComputerAccountToDisabled(ByVal ComputerName As String, Optional ByRef ErrMsg As String = "")
        Try

            Dim ctx As System.DirectoryServices.AccountManagement.PrincipalContext
            If AuthenticationIsSet() Then
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, DOMAIN_NAME, DOMAIN_USER, DOMAIN_USER_PASSWORD)
            Else
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            End If
            Dim Computer As System.DirectoryServices.AccountManagement.ComputerPrincipal = System.DirectoryServices.AccountManagement.ComputerPrincipal.FindByIdentity(ctx, ComputerName)
            If Computer IsNot Nothing Then
                Computer.Enabled = False
                Computer.Save()
            End If
        Catch ex As Exception
            ErrMsg = "ERROR DSC_SetComputerAccoutToDisabled = " & ex.Message.ToString & "::" & Err.Number
        End Try
    End Sub
    '''<summary>
    ''' Uses DirectoryServices to see if a computer account it locked out
    ''' </summary>
    '''     ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Public Function DSC_GetComputerAccountIsAccountLockedOut(ByVal ComputerName As String, Optional ByRef ErrMsg As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim ctx As System.DirectoryServices.AccountManagement.PrincipalContext
            If AuthenticationIsSet() Then
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, DOMAIN_NAME, DOMAIN_USER, DOMAIN_USER_PASSWORD)
            Else
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            End If

            Dim Computer As System.DirectoryServices.AccountManagement.ComputerPrincipal = System.DirectoryServices.AccountManagement.ComputerPrincipal.FindByIdentity(ctx, ComputerName)
            If Computer IsNot Nothing Then
                bAns = Computer.IsAccountLockedOut
            End If
        Catch ex As Exception
            ErrMsg = "ERROR GetComputerAccountIsAccountLockedOut - " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return bAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to get the last time a computer account was disabled
    ''' </summary>
    '''     ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Public Function DSC_GetComputerAccountLockoutTime(ByVal ComputerName As String, Optional ByRef ErrMsg As String = "") As String
        Dim sAns As String = ""
        Try
            Dim ctx As System.DirectoryServices.AccountManagement.PrincipalContext
            If AuthenticationIsSet() Then
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, DOMAIN_NAME, DOMAIN_USER, DOMAIN_USER_PASSWORD)
            Else
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            End If
            Dim Computer As System.DirectoryServices.AccountManagement.ComputerPrincipal = System.DirectoryServices.AccountManagement.ComputerPrincipal.FindByIdentity(ctx, ComputerName)
            If Computer IsNot Nothing Then
                sAns = Computer.AccountLockoutTime.ToString
            End If
        Catch ex As Exception
            ErrMsg = "ERROR GetComputerAccountLockoutTime - " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to get the last bad password attempt from a computer account
    ''' </summary>
    '''     ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Public Function DSC_GetComputerLastBadPasswordAttempt(ByVal ComputerName As String, Optional ByRef ErrMsg As String = "") As String
        Dim sAns As String = ""
        Try
            Dim ctx As System.DirectoryServices.AccountManagement.PrincipalContext
            If AuthenticationIsSet() Then
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, DOMAIN_NAME, DOMAIN_USER, DOMAIN_USER_PASSWORD)
            Else
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            End If
            Dim Computer As System.DirectoryServices.AccountManagement.ComputerPrincipal = System.DirectoryServices.AccountManagement.ComputerPrincipal.FindByIdentity(ctx, ComputerName)
            If Computer IsNot Nothing Then
                sAns = Computer.LastBadPasswordAttempt.ToString
            End If
        Catch ex As Exception
            ErrMsg = "ERROR GetComputerLastBadPasswordAttempt - " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to get the computer description
    ''' </summary>
    '''     ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Public Function DSC_GetComputerDescription(ByVal ComputerName As String, Optional ByRef ErrMsg As String = "") As String
        Dim sAns As String = ""
        Try
            Dim ctx As System.DirectoryServices.AccountManagement.PrincipalContext
            If AuthenticationIsSet() Then
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, DOMAIN_NAME, DOMAIN_USER, DOMAIN_USER_PASSWORD)
            Else
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            End If
            Dim Computer As System.DirectoryServices.AccountManagement.ComputerPrincipal = System.DirectoryServices.AccountManagement.ComputerPrincipal.FindByIdentity(ctx, ComputerName)
            If Computer IsNot Nothing Then
                sAns = Computer.Description
            End If
        Catch ex As Exception
            ErrMsg = "ERROR GetComputerDescription - " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to Set the Computer Descrition
    ''' </summary>
    '''     ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Public Sub DSC_SetComputerDescription(ByVal ComputerName As String, ByVal NewDescription As String, Optional ByRef ErrMsg As String = "")
        Try
            Dim ctx As System.DirectoryServices.AccountManagement.PrincipalContext
            If AuthenticationIsSet() Then
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, DOMAIN_NAME, DOMAIN_USER, DOMAIN_USER_PASSWORD)
            Else
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            End If
            Dim Computer As System.DirectoryServices.AccountManagement.ComputerPrincipal = System.DirectoryServices.AccountManagement.ComputerPrincipal.FindByIdentity(ctx, ComputerName)
            If Computer IsNot Nothing Then
                Computer.Description = NewDescription
                Computer.Save()
            End If
        Catch ex As Exception
            ErrMsg = "ERROR SetComputerDescription - " & ex.Message.ToString & "::" & Err.Number
        End Try
    End Sub
    '''<summary>
    ''' Uses DirectoryServices to get the Sam Account Name of the computer
    ''' </summary>
    '''     ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Public Function DSC_GetComputerSamAccountName(ByVal ComputerName As String, Optional ByRef ErrMsg As String = "") As String
        Dim sAns As String = ""
        Try
            Dim ctx As System.DirectoryServices.AccountManagement.PrincipalContext
            If AuthenticationIsSet() Then
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, DOMAIN_NAME, DOMAIN_USER, DOMAIN_USER_PASSWORD)
            Else
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            End If
            Dim Computer As System.DirectoryServices.AccountManagement.ComputerPrincipal = System.DirectoryServices.AccountManagement.ComputerPrincipal.FindByIdentity(ctx, ComputerName)
            If Computer IsNot Nothing Then
                sAns = Computer.SamAccountName
            End If
        Catch ex As Exception
            ErrMsg = "ERROR GetComputerSamAccountName - " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to Delete the computer from Active Directory
    ''' </summary>
    '''     ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Public Sub DSC_DeleteComputer(ByVal ComputerName As String, Optional ByRef ErrMsg As String = "")
        Try
            Dim ctx As System.DirectoryServices.AccountManagement.PrincipalContext
            If AuthenticationIsSet() Then
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, DOMAIN_NAME, DOMAIN_USER, DOMAIN_USER_PASSWORD)
            Else
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            End If
            Dim Computer As System.DirectoryServices.AccountManagement.ComputerPrincipal = System.DirectoryServices.AccountManagement.ComputerPrincipal.FindByIdentity(ctx, ComputerName)
            If Computer IsNot Nothing Then
                Computer.Delete()
                Computer.Save()
            End If
        Catch ex As Exception
            ErrMsg = "ERROR SetComputerDescription - " & ex.Message.ToString & "::" & Err.Number
        End Try
    End Sub
    '''<summary>
    ''' Uses DirectoryServices to Get the Computer SID from Active Directory
    ''' </summary>
    '''     ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Public Function DSC_GetComputerSid(ByVal ComputerName As String, Optional ByRef ErrMsg As String = "") As String
        Dim sAns As String = ""
        Try
            Dim ctx As System.DirectoryServices.AccountManagement.PrincipalContext
            If AuthenticationIsSet() Then
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, DOMAIN_NAME, DOMAIN_USER, DOMAIN_USER_PASSWORD)
            Else
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            End If
            Dim Computer As System.DirectoryServices.AccountManagement.ComputerPrincipal = System.DirectoryServices.AccountManagement.ComputerPrincipal.FindByIdentity(ctx, ComputerName)
            If Computer IsNot Nothing Then
                sAns = Computer.Sid.ToString
            End If
        Catch ex As Exception
            ErrMsg = "ERROR GetComputerSid - " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to Get the Structural Object Class from Active Directory
    ''' </summary>
    '''     ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Public Function DSC_GetComputerStructuralObjectClass(ByVal ComputerName As String, Optional ByRef ErrMsg As String = "") As String
        Dim sAns As String = ""
        Try
            Dim ctx As System.DirectoryServices.AccountManagement.PrincipalContext
            If AuthenticationIsSet() Then
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain, DOMAIN_NAME, DOMAIN_USER, DOMAIN_USER_PASSWORD)
            Else
                ctx = New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            End If
            Dim Computer As System.DirectoryServices.AccountManagement.ComputerPrincipal = System.DirectoryServices.AccountManagement.ComputerPrincipal.FindByIdentity(ctx, ComputerName)
            If Computer IsNot Nothing Then
                sAns = Computer.StructuralObjectClass
            End If
        Catch ex As Exception
            ErrMsg = "ERROR GetComputerStructuralObjectClass = " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' Checks a machine name in a OU to determin is it is a workstation
    ''' </summary>
    Public Function isWorkstation(ByVal pc_name As String, ByVal PC_OU As String, Optional ByVal PC_OU_2 As String = "") As Boolean
        Dim strLocation As String = FindObject(pc_name, AD_AccountType.COMPUTER)
        Dim bAns As Boolean = False
        If strLocation = "Not Found" Then
            bAns = False
        End If
        If InStr(strLocation, PC_OU) > 0 Or InStr(strLocation, PC_OU_2) > 0 Then
            'server is found in the correct OU
            bAns = True
        Else
            bAns = False
        End If
        Return bAns
    End Function
    '''<summary>
    ''' Checks a machine name in a OU to determin is it is a Server
    ''' </summary>
    Public Function isServer(ByVal server_name As String, ByVal SERVER_OU As String, Optional ByVal SERVER_OU_2 As String = "") As Boolean
        Dim strLocation As String = FindObject(server_name, AD_AccountType.COMPUTER)
        Dim bAns As Boolean = False
        If strLocation = "Not Found" Then
            bAns = False
        End If
        If InStr(strLocation, SERVER_OU) > 0 Or InStr(strLocation, SERVER_OU_2) > 0 Then
            'server is found in the correct OU
            bAns = True
        Else
            bAns = False
        End If
        Return bAns
    End Function
    Public Function isDomainController(ByVal server_name As String) As Boolean
        Dim SERVER_OU As String = "Domain Controllers"
        Dim strLocation As String = FindObject(server_name, AD_AccountType.COMPUTER)
        Dim bAns As Boolean = False
        If strLocation = "Not Found" Then
            bAns = False
        End If
        If InStr(strLocation, SERVER_OU) > 0 Then
            'server is found in the correct OU
            bAns = True
        Else
            bAns = False
        End If
        Return bAns
    End Function
    '''<summary>
    '''Get all the Computers in Active Directory for an AutoComplete Collection Array.
    ''' This Pulls Back all PC's and Servers excluding Domain Controllers
    ''' </summary>
    Public Function ListAllADComputers_AC(Optional ByRef ErrorMessage As String = "") As AutoCompleteStringCollection
        Dim iCol As New AutoCompleteStringCollection
        Try
            Dim dirEntry As DirectoryEntry = GetDirectoryEntry()
            Dim pcList As New Collection()
            Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
            dirSearcher.PageSize = SEARCH_FILTER_PAGESIZE
            dirSearcher.Filter = ("(objectClass=computer)")
            Dim dirSearchResults As SearchResult
            Dim MachineName As String = ""
            iCol.Clear()
            For Each dirSearchResults In dirSearcher.FindAll()
                'MachineName = Replace(dirSearchResults.GetDirectoryEntry().Name.ToString(), "CN=", "")
                MachineName = dirSearchResults.GetDirectoryEntry().Name.Replace("CN=", "").ToString
                If Not iCol.Contains(MachineName) Then
                    iCol.Add(MachineName)
                    System.Windows.Forms.Application.DoEvents()
                End If
            Next
        Catch ex As Exception
            ErrorMessage = ex.Message.ToString
        End Try
        Return iCol
    End Function
    '''<summary>
    '''Get all the Computers in Active Directory as a regular Collection Array.
    ''' This Pulls Back all PC's and Servers excluding Domain Controllers
    ''' </summary>
    Public Function ListAllADComputers() As Collection
        Dim dirEntry As DirectoryEntry = GetDirectoryEntry()
        Dim pcList As New Collection()
        Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
        dirSearcher.PageSize = SEARCH_FILTER_PAGESIZE
        dirSearcher.Filter = ("(objectClass=computer)")
        Dim dirSearchResults As SearchResult
        For Each dirSearchResults In dirSearcher.FindAll()
            If Not pcList.Contains(dirSearchResults.GetDirectoryEntry().Name.ToString()) Then
                pcList.Add(dirSearchResults.GetDirectoryEntry().Name.ToString())
            End If
        Next
        Return pcList
    End Function
    ''' <summary>
    ''' create directory entry connection to the remote machine
    ''' </summary>
    ''' <param name="Computername"></param>
    ''' <param name="Username"></param>
    ''' <param name="Password"></param>
    ''' <returns>DirectoryEntry</returns>
    ''' <remarks>Dim deComputer As DirectoryEntry = GetComputerEntry(computername)</remarks>
    Public Function GetComputerEntry(ByVal Computername As String, Optional ByVal Username As String = "", Optional ByVal Password As String = "", Optional ByRef sMsg As String = "") As DirectoryEntry
        Dim deComputer As DirectoryEntry
        Try
            If Username.Length > 0 Then
                deComputer = New DirectoryEntry("WinNT://" + Computername + ",computer", Username, Password)
            Else
                deComputer = New DirectoryEntry("WinNT://" + Computername + ",computer")
            End If
            deComputer.RefreshCache()
            'deComputer.Dispose()
        Catch ex As Exception
            deComputer = Nothing
            sMsg = Computername & " " & ex.Message.ToString
        End Try
        Return deComputer
    End Function
#End Region
#Region "OU Related Functions"
    '''<summary>
    ''' This will move a user from their current OU to the a new Ou.  If there is an error it
    ''' will return as false, and it went successfully it will return true
    ''' </summary>
    ''' <remarks>
    ''' Uses the AuthenticationIsSet Function as an option for elevated access
    ''' </remarks>
    Function MoveUserToNewOU(ByVal Username As String, ByVal NewPath As String, Optional ByRef Err_MSG As String = "", Optional ByVal Simulate As Boolean = False, Optional ByVal Simulate_Return As Boolean = False) As Boolean
        Dim bAns As Boolean = True
        Try
            If Not Simulate Then
                Dim CurPath As String = GetCurrentOUPath(Username)
                Dim newUser As DirectoryEntry
                If AuthenticationIsSet() Then
                    newUser = New DirectoryEntry(CurPath, _DOMAIN_NAME & "\" & _DOMAIN_USER, _DOMAIN_USER_PASSWORD, AuthenticationTypes.Secure)
                    newUser.MoveTo(New DirectoryEntry(NewPath, _DOMAIN_NAME & "\" & _DOMAIN_USER, _DOMAIN_USER_PASSWORD))
                Else
                    newUser = New DirectoryEntry(CurPath, Nothing, Nothing, AuthenticationTypes.Secure)
                    newUser.MoveTo(New DirectoryEntry(NewPath))
                End If
            Else
                bAns = Simulate_Return
            End If
        Catch ex As Exception
            Err_MSG = Err.Number & " - ActiveDirectorySecurity.MoveUserToNewOU - " & ex.Message.ToString
            bAns = False
        End Try
        Return bAns
    End Function
    '''<summary>
    ''' Formats the OU string that is returned from AD for a user into something a little more readably
    ''' AD will return ou=mygroup,ou=other group,dc=domain,dc=com
    ''' this will return is as \domain\com\other group\mygroup
    ''' </summary>
    Public Function GetCurrentOULocation_Friendly(ByVal username As String, Optional ByRef OrginalOUFormat As String = "", Optional ByRef DCList As String = "") As String
        Dim sAns As String = ""
        Dim sSplit() As String
        Dim ibound As Long = 0
        Dim GroupSplit() As String
        Dim StructureType As String
        Dim i As Integer = 0
        Dim FriendlyPath As String = ""
        OrginalOUFormat = GetCurrentOULocation(username)
        sSplit = Split(OrginalOUFormat, ",")
        ibound = UBound(sSplit)
        For i = 0 To ibound
            GroupSplit = Split(sSplit(ibound - i), "=")
            StructureType = GroupSplit(0)
            If LCase(StructureType) = "ou" Then
                If Len(FriendlyPath) = 0 Then
                    FriendlyPath = "\" & GroupSplit(1)
                Else
                    FriendlyPath &= "\" & GroupSplit(1)
                End If
            ElseIf LCase(StructureType) = "dc" Then
                If DCList.Length = 0 Then
                    DCList = sSplit(ibound - i)
                Else
                    DCList = sSplit(ibound - i) & "," & DCList
                End If
            End If
        Next
        sAns = FriendlyPath
        Return sAns
    End Function
    '''<summary>
    ''' Returns the OU that a user is in on Active Directory
    ''' AD will return ou=mygroup,ou=other group,dc=domain,dc=com
    ''' </summary>
    Public Function GetCurrentOULocation(ByVal UsrID As String) As String
        Dim sAns As String = "Not Found"
        Dim delim As String = "\"
        Dim tempArray() As String = Split(UsrID, delim)
        Try
            Dim DomString As String = ADSIString
            Dim grp As New System.DirectoryServices.DirectoryEntry(DomString)
            Dim searcher As New System.DirectoryServices.DirectorySearcher(grp)
            searcher.Filter = "(CN=" & UsrID & ")"
            Dim results As SearchResult = searcher.FindOne
            If (IsReference(results)) Then
                Dim strPath As String = "WinNT://" & DOMAIN_NAME & "/" & UsrID
                Dim dsDirectoryEntry As DirectoryEntry
                dsDirectoryEntry = New DirectoryEntry(strPath)
                Dim fromEntry As DirectoryEntry = results.GetDirectoryEntry()
                sAns = results.Properties.Item("distinguishedName")(0).ToString
            End If
        Catch ex As Exception
            sAns = "Unable to Get"
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' Returns the current path of a user's OU
    ''' </summary>
    Public Function GetCurrentOUPath(ByVal UsrID As String) As String
        Dim sAns As String = "Not Found"
        Dim delim As String = "\"
        Dim tempArray() As String = Split(UsrID, delim)
        Try
            Dim DomString As String = ADSIString
            Dim grp As New System.DirectoryServices.DirectoryEntry(DomString)
            Dim searcher As New System.DirectoryServices.DirectorySearcher(grp)
            searcher.Filter = "(CN=" & UsrID & ")"
            Dim results As SearchResult = searcher.FindOne
            If (IsReference(results)) Then
                Dim strPath As String = "WinNT://" & DOMAIN_NAME & "/" & UsrID
                Dim dsDirectoryEntry As DirectoryEntry
                dsDirectoryEntry = New DirectoryEntry(strPath)
                Dim fromEntry As DirectoryEntry = results.GetDirectoryEntry()
                sAns = results.Path
            End If
        Catch ex As Exception
            sAns = "Unable to Get"
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' List the Children in an OU as a collection
    ''' </summary>
    Public Function GetOUChildren(ByVal sLDAP As String, Optional ByVal Username As String = "", Optional ByVal Password As String = "") As Collection
        Dim cAns As New Collection
        Dim nil() As String = Nothing
        Dim entry As New DirectoryEntry(sLDAP, Username, Password, AuthenticationTypes.Secure)
        Dim ds As DirectorySearcher = New DirectorySearcher(entry, "(objectClass=organizationalUnit)", nil, SearchScope.OneLevel)

        Dim src As SearchResultCollection
        src = ds.FindAll
        Dim sr As SearchResult
        For Each sr In src
            cAns.Add(sr.Properties("name")(0).ToString)
        Next
        Return cAns
    End Function
    '''<summary>
    ''' Get the Street Value property from an OU
    ''' </summary>
    Public Function GetOUStreet(ByVal sLDAP As String, ByVal OUName As String, Optional ByVal Username As String = "", Optional ByVal Password As String = "", Optional ByRef ErrMsg As String = "") As String
        Dim sAns As String = ""
        Try
            Dim oGrp As New System.DirectoryServices.DirectoryEntry(sLDAP)
            Dim searcher As New System.DirectoryServices.DirectorySearcher(oGrp)
            searcher.Filter = "(OU=" & OUName & ")"
            Dim results As Object = searcher.FindOne
            If (IsReference(results)) Then
                sAns = results.Properties("street")(0).ToString
            End If
        Catch ex As Exception
            ErrMsg = ex.Message.ToString
        End Try
        Return sAns
    End Function
#End Region
#Region "User Related Functions"
    '''<summary>
    ''' Gets information about a user and returns values gathered from Active Directory
    ''' </summary>
    ''' <remarks>
    ''' CITUDOMAIN is Domain, CITUID = UserID,
    ''' CITULNAME= User Last Name,CITUFNAME = User First Name
    ''' UserMemberOf is groups the user is a member of
    ''' AccStatus = status of their account, eMail is eMail address listed in AD.
    ''' ExpOn = when their account expires
    ''' pwdLastSet = the last time there password was set
    ''' lastLogon = the last time they logged into the domain.
    ''' </remarks>
    Public Sub GetDomainInfoPlus(ByVal UsrID As String, Optional ByRef CITUDOMAIN As String = "", Optional ByRef CITUID As String = "", Optional ByRef CITULNAME As String = "", Optional ByRef CITUFNAME As String = "", Optional ByRef UserMemberOf As String = "", _
                            Optional ByRef AccStatus As String = "", Optional ByRef eMail As String = "", Optional ByRef ExpOn As String = "", Optional ByRef pwdLastSet As String = "", Optional ByRef lastLogon As String = "")
        'NOTE: This Sub will get the Name, Groups and Status of the Current User that is accessing the Site.
        Dim wmiFailed As Boolean = True
        Dim delim As String = "\"
        Dim tempArray() As String = Split(UsrID, delim)
        If UBound(tempArray) > 0 Then
            If Trim(tempArray(0)) <> "" Then CITUDOMAIN = Trim(tempArray(0))
            If UBound(tempArray) > 0 Then CITUID = Trim(tempArray(1))
        Else
            CITUDOMAIN = DOMAIN_NAME
            CITUID = UsrID
        End If
        Try
            Dim fullName As String
            Dim DomString As String = ADSIString
            Dim grp As New System.DirectoryServices.DirectoryEntry(DomString)
            Dim searcher As New System.DirectoryServices.DirectorySearcher(grp)
            searcher.Filter = "(CN=" & CITUID & ")"
            Dim results As SearchResult = searcher.FindOne
            AccStatus = ""

            If (IsReference(results)) Then
                Dim strPath As String = "WinNT://" & DOMAIN_NAME & "/" & CITUID

                Dim dsDirectoryEntry As DirectoryEntry
                dsDirectoryEntry = New DirectoryEntry(strPath)
                Dim fromEntry As DirectoryEntry = results.GetDirectoryEntry()
                Dim caseResult As String

                Select Case fromEntry.Properties("userAccountControl").Value
                    Case 2 'ADS_USER_FLAG.ADS_UF_ACCOUNTDISABLE '2
                        caseResult = "Account is disabled."
                    Case 65536 'ADS_USER_FLAG.ADS_UF_LOCKOUT '65536
                        caseResult = "Account is Locked"
                    Case 512 'ADS_USER_FLAG.ADS_UF_NORMAL_ACCOUNT '512
                        caseResult = "Account Normal"
                        '    caseResult = "Normal Account OK" ' <-- always hits this, even when I disable an account
                    Case 8388608 'ADS_USER_FLAG.ADS_UF_PASSWORD_EXPIRED '8388608
                        caseResult = "Password has Expired."
                    Case 544 'Account Enabled - Require user to change password at first logon 
                        caseResult = "Account Enabled - Require user to change password at first logon"
                    Case 514 'Disable account
                        caseResult = "Account is disabled."
                    Case 262656 ' Smart Card Logon Required
                        caseResult = "Smart Card Logon Required"
                    Case 66048 Or 66080 'Password never expires
                        caseResult = "Password never expires"
                    Case 66080 'Password never expires
                        caseResult = "Password never expires"
                    Case Else
                        caseResult = fromEntry.Properties("userAccountControl").Value
                End Select
                AccStatus &= caseResult
                fullName = results.Properties("displayName")(0).ToString
                If fullName Is Nothing Then fullName = ""
                If fullName = "" Then fullName = "IUSER: Unknown"

                If InStr(fullName, ",") Then
                    CITULNAME = Trim(Split(fullName, ",")(0))
                    CITUFNAME = Trim(Split(fullName, ",")(1))
                Else
                    CITULNAME = Trim(Split(fullName, " ")(1))
                    CITUFNAME = Trim(Split(fullName, " ")(0))
                    If (UBound(Split(fullName, " ")) > 1) Then
                        CITULNAME = Trim(Split(fullName, " ")(1)) & " " & Trim(Split(fullName, " ")(2))
                    End If
                End If
                Dim xOn As String = results.Properties.Item("accountExpires")(0).ToString
                Select Case xOn
                    Case 9223372036854775807
                        ExpOn = "Account never expires."
                    Case 0
                        ExpOn = "Account never expires."
                    Case Else
                        Dim time As DateTime = New DateTime()
                        ExpOn = DateAdd(DateInterval.Hour, -5, Date.FromFileTimeUtc(xOn))
                End Select
                Dim time2 As DateTime = New DateTime()
                Dim time3 As DateTime = New DateTime()

                time2 = Date.FromFileTimeUtc(results.Properties.Item("pwdLastSet")(0).ToString)
                pwdLastSet = DateAdd(DateInterval.Hour, -5, time2)
                time3 = Date.FromFileTimeUtc(results.Properties.Item("lastLogon")(0).ToString)
                lastLogon = DateAdd(DateInterval.Hour, -5, time3)
                Dim myCollection
                Dim tempStr As Object = New System.Text.StringBuilder()
                For Each myCollection In results.Properties("memberof")
                    tempStr.Append(myCollection.ToString())
                Next myCollection

                UserMemberOf = tempStr.ToString().ToUpper()
                eMail = results.Properties("mail")(0).ToString
            Else
                CITUFNAME = "IUSER:"
                CITULNAME = "UNKNOWN"
            End If
        Catch ex As Exception
            Select Case (Err.Description)
                Case "Object variable or With block variable not set."
                    AccStatus &= "The ID that you are using does not belong to the  Domain!</br>Please login with an  Domain ID!"
            End Select
        End Try
    End Sub
    '''<summary>
    ''' Uses DirectoryServices to See if the User is locked out
    ''' </summary>
    Public Function DS_IsUserLockedOut(ByVal LoginName As String) As Boolean
        Dim bAns As Boolean = False
        Dim ctx As New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
        Dim user As System.DirectoryServices.AccountManagement.UserPrincipal = System.DirectoryServices.AccountManagement.UserPrincipal.FindByIdentity(ctx, LoginName)
        If user IsNot Nothing Then
            bAns = user.IsAccountLockedOut
        End If
        ctx = Nothing
        user = Nothing
        Return bAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to get the user's Display Name
    ''' </summary>
    Public Function DS_GetDisplayName(ByVal LoginName As String) As String
        Dim sAns As String = ""
        Dim ctx As New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
        Dim user As System.DirectoryServices.AccountManagement.UserPrincipal = System.DirectoryServices.AccountManagement.UserPrincipal.FindByIdentity(ctx, LoginName)
        If user IsNot Nothing Then
            sAns = user.DisplayName
        End If
        ctx = Nothing
        user = Nothing
        Return sAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to get the Last time the user set their password
    ''' </summary>
    Public Function DS_GetLastPasswordSet(ByVal LoginName As String, Optional ByRef ErrMsg As String = "") As String
        Dim sAns As String = Today.Date
        Try
            Dim ctx As New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            Dim user As System.DirectoryServices.AccountManagement.UserPrincipal = System.DirectoryServices.AccountManagement.UserPrincipal.FindByIdentity(ctx, LoginName)
            If user IsNot Nothing Then
                sAns = user.LastPasswordSet
            End If
            ctx = Nothing
            user = Nothing
        Catch ex As Exception
            ErrMsg = "ERROR GETTING LASTPWDSET - " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to get the Expiration Date for the user
    ''' </summary>
    Public Function DS_GetAccountExpirationDate(ByVal LoginName As String, Optional ByRef ErrMsg As String = "") As String
        Dim sAns As String = Today.Date
        Try
            Dim ctx As New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            Dim user As System.DirectoryServices.AccountManagement.UserPrincipal = System.DirectoryServices.AccountManagement.UserPrincipal.FindByIdentity(ctx, LoginName)
            If user IsNot Nothing Then
                sAns = user.AccountExpirationDate
            End If
            ctx = Nothing
            user = Nothing
        Catch ex As Exception
            ErrMsg = "ERROR GETTING AccountExpirationDate - " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to get the Last Bad Password Attempt
    ''' </summary>
    Public Function DS_GetLastBadPasswordAttempt(ByVal LoginName As String, Optional ByRef ErrMsg As String = "") As String
        Dim sAns As String = Today.Date
        Try
            Dim ctx As New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            Dim user As System.DirectoryServices.AccountManagement.UserPrincipal = System.DirectoryServices.AccountManagement.UserPrincipal.FindByIdentity(ctx, LoginName)
            If user IsNot Nothing Then
                sAns = user.LastBadPasswordAttempt
            End If
            ctx = Nothing
            user = Nothing
        Catch ex As Exception
            ErrMsg = "ERROR GETTING LastBadPasswordAttempt - " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to Get the Last Time the User Logged onto the domain
    ''' </summary>
    Public Function DS_GetLastLogon(ByVal LoginName As String, Optional ByRef ErrMsg As String = "") As String
        Dim sAns As String = Today.Date
        Try
            Dim ctx As New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            Dim user As System.DirectoryServices.AccountManagement.UserPrincipal = System.DirectoryServices.AccountManagement.UserPrincipal.FindByIdentity(ctx, LoginName)
            If user IsNot Nothing Then
                sAns = user.LastLogon
            End If
            ctx = Nothing
            user = Nothing
        Catch ex As Exception
            ErrMsg = "ERROR GETTING LastLogon - " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' Uses DirectoryServices to get what time the user was last locked out
    ''' </summary>
    Public Function DS_GetAccountLockoutTime(ByVal LoginName As String, Optional ByRef ErrMsg As String = "") As String
        Dim sAns As String = Today.Date
        Try
            Dim ctx As New System.DirectoryServices.AccountManagement.PrincipalContext(System.DirectoryServices.AccountManagement.ContextType.Domain)
            Dim user As System.DirectoryServices.AccountManagement.UserPrincipal = System.DirectoryServices.AccountManagement.UserPrincipal.FindByIdentity(ctx, LoginName)
            If user IsNot Nothing Then
                sAns = user.AccountLockoutTime
            End If
            ctx = Nothing
            user = Nothing
        Catch ex As Exception
            ErrMsg = "ERROR GETTING AccountLockoutTime - " & ex.Message.ToString & "::" & Err.Number
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' This function searches for a supplied UserID and Domain for existence
    ''' It returns the OU container hierarchy
    ''' </summary>
    ''' <remarks>Uses the LDAP_STRING property</remarks>
    Public Function LocateUser(ByVal samAccountName)
        Dim objConnection
        Dim objCommand
        Dim objRecordset
        Dim nTranslatedObject
        Dim sTranslateAccount
        Dim iOUCounter
        Dim sOU
        Dim sResult As String = ""
        Dim sUserName

        sUserName = samAccountName
        objConnection = CreateObject("ADODB.Connection")
        objConnection.Open("Provider=ADsDSOObject;")
        objCommand = CreateObject("ADODB.Command")
        With objCommand
            .ActiveConnection = objConnection
            .CommandText = "<LDAP://" & LDAP_STRING & ">;(&(objectCategory=User)" & "(samAccountName=" & sUserName & "));samAccountName;subtree"
            objRecordset = .Execute
        End With 'objCommand
        If objRecordset.RecordCount = 0 Then
            LocateUser = "no"
        Else
            sTranslateAccount = DOMAIN_NAME & "\" & samAccountName
            nTranslatedObject = CreateObject("NameTranslate")
            With nTranslatedObject
                .Init(ADS_NAME_INITTYPE_GC, vbNullString)
                .Set(ADS_NAME_TYPE_NT4, sTranslateAccount)
                sOU = Split(.Get(ADS_NAME_TYPE_1779), ",", -1, vbTextCompare)
            End With 'nTranslatedObject
            For iOUCounter = 0 To UBound(sOU)
                sResult = sResult & sOU(iOUCounter) & ","
            Next iOUCounter
            LocateUser = LCase(Left(sResult, Len(sResult) - 1))
        End If
        objConnection.Close()

    End Function
    '''<summary>
    ''' Uses WMI to Run the net localgroup command on the target machine to add a user
    ''' or group to the local administrators of the target machine
    ''' </summary>
    Public Function AddAdministrator(ByVal userToAdd As String, ByVal computerToAddTo As String) As Boolean
        Dim bAns As Boolean = False
        Try
            Const SW_NORMAL = 1
            Dim ObjLocator As Object
            Dim objWMIService As Object
            Dim objStartup As Object
            Dim objConfig As Object
            Dim objProcess As Object
            Dim intReturn As Integer = 0
            Dim intProcessID As Long = 0

            Dim LoginID As String = DOMAIN_USER
            Dim LIDpass As String = DOMAIN_USER_PASSWORD
            Dim UserIdToAdd As String = userToAdd
            Dim strCommand As String = "NET.EXE LOCALGROUP Administrators """ & DOMAIN_NAME & "\" & UserIdToAdd & """ /ADD"

            ObjLocator = CreateObject("WbemScripting.SWbemLocator")
            objWMIService = ObjLocator.ConnectServer(computerToAddTo, "root\cimv2", LoginID, LIDpass)
            objWMIService.Security_.ImpersonationLevel = 3
            objStartup = objWMIService.Get("Win32_ProcessStartup")
            objConfig = objStartup.SpawnInstance_
            objConfig.ShowWindow = SW_NORMAL
            objProcess = objWMIService.Get("Win32_Process")
            Dim NULL As String = vbNullString
            intReturn = objProcess.Create(strCommand, NULL, objConfig, intProcessID)
            bAns = True
        Catch ex As Exception
            bAns = False
        End Try
        Return bAns
    End Function
    '''<summary>
    ''' Uses ADSI to add a userto the Local Administrators group of the target machine
    ''' </summary>
    Public Function AddUserToLocalAdministrator(ByVal userToAdd As String, ByVal computerToAddTo As String) As Boolean
        Dim bAns As Boolean = False
        Try
            Dim objNetwork, strDomain, objAdmGroup, objUser

            objNetwork = CreateObject("Wscript.Network")
            strDomain = objNetwork.UserDomain

            objAdmGroup = GetObject("WinNT://" & computerToAddTo & "/Administrators,group")
            objUser = GetObject("WinNT://" & strDomain & "/" & userToAdd & ",user")

            If (objAdmGroup.IsMember(objUser.ADsPath) = False) Then
                objAdmGroup.Add(objUser.ADsPath)
            End If
            bAns = True
        Catch ex As Exception
            Dim sMsg As String = ex.Message.ToString
            bAns = False
        End Try
        Return bAns
    End Function
    '''<summary>
    ''' Uses ADSI to remove a user from the Local Administrators group of the target machine
    ''' </summary>
    Public Function RemoveUserFromLocalAdministrator(ByVal userToRemove As String, ByVal computerToAddTo As String) As Boolean
        Dim bAns As Boolean = False
        Try
            Dim objNetwork, strDomain, objAdmGroup, objUser

            objNetwork = CreateObject("Wscript.Network")
            strDomain = objNetwork.UserDomain

            objAdmGroup = GetObject("WinNT://" & computerToAddTo & "/Administrators,group")
            objUser = GetObject("WinNT://" & computerToAddTo & "/" & userToRemove & ",user")

            If (objAdmGroup.IsMember(objUser.ADsPath) = False) Then
                objAdmGroup.remove(objUser.ADsPath)
            End If
            bAns = True
        Catch ex As Exception
            Dim sMsg As String = ex.Message.ToString
            bAns = False
        End Try
        Return bAns
    End Function
    '''<summary>
    ''' Uses WMI to run the net localgroup command to remove a user fromt eh local 
    ''' administrators group of the target machine
    ''' </summary>
    Public Function RemoveAdministrator(ByVal userToAdd As String, ByVal computerToAddTo As String) As Boolean
        Dim bans As Boolean = False
        Try
            Const SW_NORMAL = 1
            Dim ObjLocator As Object
            Dim objWMIService As Object
            Dim objStartup As Object
            Dim objConfig As Object
            Dim objProcess As Object
            Dim intReturn As Integer = 0
            Dim intProcessID As Long = 0
            Dim LoginID As String = DOMAIN_USER
            Dim LIDpass As String = DOMAIN_USER_PASSWORD

            Dim UserIdToAdd As String = userToAdd

            Dim strCommand As String = "NET.EXE LOCALGROUP Administrators """ & DOMAIN_NAME & "\" & UserIdToAdd & """ /DEL"

            ObjLocator = CreateObject("WbemScripting.SWbemLocator")
            objWMIService = ObjLocator.ConnectServer(computerToAddTo, "root\cimv2", LoginID, LIDpass)
            objWMIService.Security_.ImpersonationLevel = 3
            objStartup = objWMIService.Get("Win32_ProcessStartup")
            objConfig = objStartup.SpawnInstance_
            objConfig.ShowWindow = SW_NORMAL

            ' Create Notepad process
            objProcess = objWMIService.Get("Win32_Process")
            Dim NULL As String = vbNullString
            intReturn = objProcess.Create(strCommand, NULL, objConfig, intProcessID)
            bans = True
        Catch ex As Exception
            bans = False
        End Try
        Return bans
    End Function
    '''<summary>
    ''' Checks to see if a user is found in the local administrators group of the curent machine
    ''' </summary>
    Public Function UsersFoundInLocalAdmin(ByVal sValue As String, Optional ByRef sError As String = "") As Boolean
        Dim bAns As Boolean = False
        Try
            Dim computername As String = SystemInformation.ComputerName
            Dim deComputer As New DirectoryEntry("WinNT://" + computername + ",computer")
            deComputer.RefreshCache()
            Dim deGroup As DirectoryEntry = deComputer.Children.Find("administrators", "group")

            Dim members As IEnumerable = deGroup.Invoke("members", Nothing)
            Dim sName As String = ""
            For Each o As Object In members
                Dim deMember As DirectoryEntry = New DirectoryEntry(o)
                sName = deMember.Name
                If LCase(sName) = LCase(sValue) Then
                    bAns = True
                    Exit For
                End If
            Next
        Catch ex As Exception
            sError = ex.Message.ToString
        End Try
        Return bAns
    End Function
    '''<summary>
    ''' Remove Users from a local group
    ''' </summary>
    Public Sub RemoveUserFromGroup(ByVal deGroup As DirectoryEntry, ByVal User As DirectoryEntry)
        deGroup.RefreshCache()
        deGroup.Invoke("Remove", User.Path.ToString())
        deGroup.CommitChanges()
    End Sub
    '''<summary>
    ''' add users to a local group
    ''' </summary>
    Public Sub AddUserToGroup2(ByVal deGroup As DirectoryEntry, ByVal user As DirectoryEntry)
        deGroup.RefreshCache()
        deGroup.Invoke("Add", user.Path.ToString())
        deGroup.CommitChanges()
    End Sub
    '''<summary>
    ''' Add Users to an Active Directory Group
    ''' </summary>
    ''' <remarks>
    ''' Uses the ADSIString, LDAP_DOMAIN_NAME properties for the domain connection
    ''' </remarks>
    Public Sub adUserToGroup(ByVal sGroupName As String, ByVal sUserComputerName As String, Optional ByVal Username As String = "", Optional ByVal Password As String = "")
        Dim Buf As String = ""
        Dim sDomainName As String = _LDAP_DOMAIN_NAME
        Dim adUserFolder As DirectoryEntry = New DirectoryEntry(_ADSIString)

        Dim sUserComputerName_OU As String = GetCurrentOULocation(sUserComputerName)
        adUserFolder.Username = Username
        adUserFolder.Password = Password
        Dim adSearch As New System.DirectoryServices.DirectorySearcher(adUserFolder)
        adSearch.Filter = String.Format("(&(objectCategory=group)(sAMAccountName= {0}))", sGroupName)
        For Each x As SearchResult In adSearch.FindAll
            Dim group As DirectoryEntry = x.GetDirectoryEntry
            group.Properties("member").Add(sUserComputerName_OU)
            group.CommitChanges()
        Next
    End Sub
    '''<summary>
    ''' Adds a user to a group in AD
    ''' </summary>
    Public Sub AddUserToADGroup(ByVal sUser As String, ByVal sGroup As String, Optional ByVal ErrMsg As String = "")
        Try
            Dim ctx As New System.DirectoryServices.AccountManagement.PrincipalContext(ContextType.Domain)
            Dim mygroup As GroupPrincipal = GroupPrincipal.FindByIdentity(ctx, sGroup)
            mygroup.Members.Add(ctx, IdentityType.Name, sUser)
            mygroup.Save()
            mygroup.Dispose()
            ctx.Dispose()
        Catch ex As Exception
            ErrMsg = ex.Message.ToString
        End Try
    End Sub
    '''<summary>
    ''' Delets a user from a group in AD
    ''' </summary>
    Public Sub DeleteUserFromADGroup(ByVal sUser As String, ByVal sGroup As String)
        Dim ctx As New System.DirectoryServices.AccountManagement.PrincipalContext(ContextType.Domain)
        Dim mygroup As GroupPrincipal = GroupPrincipal.FindByIdentity(ctx, sGroup)
        mygroup.Members.Remove(ctx, IdentityType.Name, sUser)
        mygroup.Save()
        mygroup.Dispose()
        ctx.Dispose()
    End Sub
    ''' <summary>
    ''' Deletes a Domain User from the Local Machint, this sub uses the rights of the user that runs it.
    ''' </summary>
    ''' <param name="sUser"></param>
    ''' <param name="sGroup"></param>
    ''' <param name="sComputer"></param>
    ''' <param name="sDomain"></param>
    ''' <remarks></remarks>
    Public Sub DeleteDomainUserFromRemoteGroup(ByVal sUser As String, ByVal sGroup As String, ByVal sComputer As String, Optional ByVal sDomain As String = "", Optional ByRef ErrMsg As String = "")
        Try
            Dim LCL As New DirectoryEntry
            Dim DOM As New DirectoryEntry
            Dim DOMUSR As DirectoryEntry
            Dim LCLGRP As DirectoryEntry

            LCL = New DirectoryEntry("WinNT://" & sComputer & ",computer")
            DOM = New DirectoryEntry("WinNT://" & sDomain)
            DOMUSR = DOM.Children.Find(sUser, "user")
            LCLGRP = LCL.Children.Find(sGroup, "group")

            LCLGRP.Invoke("Remove", New Object() {DOMUSR.Path.ToString})
            LCLGRP.Dispose()
            DOMUSR.Dispose()
            DOM.Dispose()
            LCL.Dispose()
        Catch ex As Exception
            ErrMsg = Err.Number & vbTab & ex.Message.ToString
        End Try

    End Sub
#End Region
#Region "Active Directory Group Related Functions"
    '''<summary>
    ''' Uses ADSI to add or remove a group from a local group on the target machine
    ''' sMachineName is the target, sGroupName is the Group that you want to add or remove
    ''' sLocalGroup is the local group that you want to add or remove to
    ''' sOperations is either "add" or "del" to determain the action
    ''' </summary>
    Public Sub UpdateAccount(ByVal sMachineName, ByVal sGroupName, ByVal sLocalGroup, ByVal sOperation)
        On Error Resume Next
        Dim oGroup As Object
        Dim bIsMember As Boolean

        'This sub users ADSI to access the local group on the machine
        oGroup = GetObject("WinNT://" & sMachineName & "/" & sLocalGroup)

        'Set boolean to 0 or 1 after checking for account existence
        bIsMember = oGroup.IsMember("WinNT://" & DOMAIN_NAME & "/" & sGroupName)

        'Perform operation
        If LCase(sOperation) = LCase("Add") Then
            'Check to see if group is already a member
            If Not bIsMember Then
                'Add the global group into the local group on this machine
                oGroup.Add("WinNT://" & DOMAIN_NAME & "/" & sGroupName)
            End If
        Else
            'Check to see if group is already a member
            If bIsMember Then
                'Remove the global group into the local group on this machine
                oGroup.Remove("WinNT://" & DOMAIN_NAME & "/" & sGroupName)
            End If
        End If

        'Clean up by removing the connection to the local group
        oGroup = Nothing

        On Error GoTo 0

    End Sub
    '''<summary>
    ''' Checks to see if the group Exists in AD
    ''' </summary>
    Public Function ADGroupExists(ByVal sGroupName As String) As Boolean
        Dim bAns As Boolean = False
        Try
            Dim ctx As New System.DirectoryServices.AccountManagement.PrincipalContext(ContextType.Domain)
            Dim mygroup As GroupPrincipal = GroupPrincipal.FindByIdentity(ctx, sGroupName)

            If mygroup IsNot Nothing Then
                bAns = True
            Else
                bAns = False
            End If
            mygroup.Dispose()
            ctx.Dispose()
        Catch ex As Exception
            Dim SMesg As String = Err.Number & vbTab & ex.Message.ToString
            bAns = False
        End Try
        Return bAns
    End Function
    '''<summary>
    ''' Creates a Group in Active Directory and puts it in an OU
    ''' </summary>
    Public Sub CreateADGroup(ByVal sNewGroupName As String, ByVal sParentOU As String, Optional ByVal sDesc As String = "")
        Dim dom As New DirectoryEntry()
        Dim ou As DirectoryEntry = dom.Children.Find("OU=" & sParentOU)

        Dim group As DirectoryEntry = ou.Children.Add("CN=" & sNewGroupName, "group")
        group.Properties("sAMAccountName").Value = sNewGroupName
        group.Properties("Description").Value = sDesc
        group.CommitChanges()
        group.Dispose()
        dom.Dispose()
    End Sub
    '''<summary>
    ''' Deletes a Group in AD
    ''' </summary>
    Public Sub DeleteADGroup(ByVal sGroupName As String)
        Dim ctx As New System.DirectoryServices.AccountManagement.PrincipalContext(ContextType.Domain)
        Dim mygroup As GroupPrincipal = GroupPrincipal.FindByIdentity(ctx, sGroupName)
        mygroup.Delete()
        mygroup.Save()
        mygroup.Dispose()
        ctx.Dispose()
    End Sub
    '''<summary>
    ''' Gets groups for a user and returns it as a collection
    ''' </summary>
    Private Function GetGroups(ByVal _path As String, ByVal username As String, _
                 ByVal password As String) As Collection
        Dim Groups As New Collection
        Dim dirEntry As New _
            System.DirectoryServices.DirectoryEntry(_path, username, password)
        Dim dirSearcher As New DirectorySearcher(dirEntry)
        dirSearcher.Filter = String.Format("(sAMAccountName={0}))", username)
        dirSearcher.PropertiesToLoad.Add("memberOf")
        Dim propCount As Integer
        Try
            Dim dirSearchResults As SearchResult = dirSearcher.FindOne()
            propCount = dirSearchResults.Properties("memberOf").Count
            Dim dn As String
            Dim equalsIndex As String
            Dim commaIndex As String
            For i As Integer = 0 To propCount - 1
                dn = dirSearchResults.Properties("memberOf")(i)
                equalsIndex = dn.IndexOf("=", 1)
                commaIndex = dn.IndexOf(",", 1)
                If equalsIndex = -1 Then
                    Return Nothing
                End If
                If Not Groups.Contains(dn.Substring((equalsIndex + 1), _
                                      (commaIndex - equalsIndex) - 1)) Then
                    Groups.Add(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1))
                End If
            Next
        Catch ex As Exception
            If ex.GetType Is GetType(System.NullReferenceException) Then
                MessageBox.Show("Selected user isn't a member of any groups " & _
                                "at this time.", "No groups listed", _
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
                'they are still a good user just does not
                'have a "memberOf" attribute so it errors out.
                'code to do something else here if you want
            Else
                MessageBox.Show(ex.Message.ToString, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
        Return Groups
    End Function
    ''' <summary>
    ''' get admin group info
    ''' </summary>
    ''' <param name="DE"></param>
    ''' <param name="Groupname"></param>
    ''' <returns>DirectoryEntr</returns>
    ''' <remarks>Dim deGroup As DirectoryEntry = GetGroupByName(deComputer, "administrators")</remarks>
    Public Function GetGroupByName(ByVal DE As DirectoryEntry, ByVal Groupname As String) As DirectoryEntry
        Dim deGroup As DirectoryEntry = DE.Children.Find(Groupname, "group")
        Return deGroup
    End Function
    ''' <summary>
    ''' Returns a DirectoryEntry List of group members on the selected machine
    ''' </summary>
    ''' <param name="deGroup"></param>
    ''' <returns>List(Of DirectoryEntry)</returns>
    ''' <remarks>Dim groupMembers As List(Of DirectoryEntry) = GetGroupMembers(deGroup)</remarks>
    Public Function GetGroupMembers(ByVal deGroup As DirectoryEntry) As List(Of DirectoryEntry)
        Dim members As IEnumerable = deGroup.Invoke("members", Nothing)
        Dim r As New List(Of DirectoryEntry)()
        For Each o As Object In members
            Dim deMember As DirectoryEntry = New DirectoryEntry(o)
            r.Add(deMember)
        Next
        Return r
    End Function
    '''<summary>
    ''' Uses ADSI to add a Group to the Local Administrators group of the target machine
    ''' </summary>
    Public Function AddGroupToLocalAdministrator(ByVal userToAdd As String, ByVal computerToAddTo As String) As Boolean
        Dim bAns As Boolean = False
        Try
            Dim objNetwork, strDomain, objAdmGroup, objUser

            objNetwork = CreateObject("Wscript.Network")
            strDomain = objNetwork.UserDomain

            objAdmGroup = GetObject("WinNT://" & computerToAddTo & "/Administrators,group")
            objUser = GetObject("WinNT://" & strDomain & "/" & userToAdd & ",group")

            If (objAdmGroup.IsMember(objUser.ADsPath) = False) Then
                objAdmGroup.Add(objUser.ADsPath)
            End If
            bAns = True
        Catch ex As Exception
            Dim sMsg As String = ex.Message.ToString
            bAns = False
        End Try
        Return bAns
    End Function
#End Region
#Region "Other Functions for AD and What not"
    '''<summary>
    ''' ADSI Translator to convert the integer to a redable string
    ''' 1=class, 2=computer,3=domain, etc
    ''' </summary>
    Private Function ADSIObject_EnumToString(ByVal iValue As ADSIObject) As String
        Dim sAns As String = ""
        Select Case iValue
            Case 1
                sAns = "Class"
            Case 2
                sAns = "Computer"
            Case 3
                sAns = "Domain"
            Case 4
                sAns = "FileService"
            Case 5
                sAns = "FileShare"
            Case 6
                sAns = "FPNWFileService"
            Case 7
                sAns = "FPNWFileShare"
            Case 8
                sAns = "FPNWResource"
            Case 9
                sAns = "FPNWResourcesCollection"
            Case 10
                sAns = "FPNWSession"
            Case 11
                sAns = "FPNWSessionsCollection"
            Case 12
                sAns = "Group"
            Case 13
                sAns = "GroupCollection"
            Case 14
                sAns = "LocalGroup"
            Case 15
                sAns = "LocalgroupCollection"
            Case 16
                sAns = "Namespace"
            Case 17
                sAns = "PrintJob "
            Case 18
                sAns = "Service"
            Case 19
                sAns = "User"
            Case 20
                sAns = "PrintJobsCollection"
            Case 21
                sAns = "PrintQueue"
            Case 22
                sAns = "Property"
        End Select
        Return sAns
    End Function
    '''<summary>
    ''' works with the APPLICATION_LAUNCH_PATH property to determin is the application is only suppose to run 
    ''' from a certain location.
    ''' </summary>
    Public Function IsShareRan() As Boolean
        Dim bAns As Boolean = False
        If UseShareRunDir Then
            If Application.ExecutablePath <> APPLICATION_LAUNCH_PATH Then
                bAns = False
            Else
                bAns = True
            End If
        Else
            bAns = True
        End If
        Return bAns
    End Function
    '''<summary>
    ''' Uses the DOMAIN_NAME, DOMAIN_USER and DOMAIN_USER_PASSWORD properties to see if all 3 properties
    ''' has been set, if they have been then it return as true, otherwise if one is missed then it returns
    ''' as false.  This is handy for some functions that require elivated access to perform certain functions
    ''' only if the user that is running it does not have that access.
    ''' </summary>
    Private Function AuthenticationIsSet(Optional ByRef Err_MSG As String = "") As Boolean
        Dim bAns As Boolean = False
        Dim CheckUser As Boolean = False
        Dim CheckDomain As Boolean = False
        Dim CheckPassword As Boolean = False
        Try
            If Not IsDBNull(_DOMAIN_NAME) Then
                If _DOMAIN_NAME.Length > 0 Then CheckDomain = True
            End If
            If Not IsDBNull(_DOMAIN_USER) Then
                If Len(_DOMAIN_USER) > 0 Then CheckUser = True
            End If
            If Not IsDBNull(_DOMAIN_USER_PASSWORD) Then
                If Len(_DOMAIN_USER_PASSWORD) > 0 Then CheckPassword = True
            End If
            If CheckDomain And CheckUser And CheckPassword Then bAns = True
        Catch ex As Exception
            Err_MSG = Err.Number & " - " & ex.Message.ToString
            bAns = False
        End Try
        Return bAns
    End Function
    '''<summary>
    ''' Quick Domain Look up for the user that is running the application
    ''' </summary>
    Public Function GetDomainInfo(Optional ByRef oUser As String = "", Optional ByRef oDomain As String = "") As String
        Dim sAns As String = ""
        Try
            oUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString()
            Dim delim As String = "\"
            Dim tempArray() As String = Split(oUser, delim)
            If Trim(tempArray(0)) <> "" Then oDomain = Trim(tempArray(0))
            If UBound(tempArray) > 0 Then oUser = Trim(tempArray(1))
            Dim oGrp As New System.DirectoryServices.DirectoryEntry(ADSIString)
            Dim searcher As New System.DirectoryServices.DirectorySearcher(oGrp)
            searcher.Filter = "(CN=" & oUser & ")"
            Dim results As Object = searcher.FindOne

            If (IsReference(results)) Then
                Dim fullName As String = results.Properties("displayName")(0).ToString
                Dim eMail As String = results.Properties("mail")(0).ToString
                Dim strPath As String = "WinNT://" & DOMAIN_NAME & "/" & oUser
                Dim dsDirectoryEntry As DirectoryEntry
                dsDirectoryEntry = New DirectoryEntry(strPath)
                Dim fromEntry As DirectoryEntry = results.GetDirectoryEntry()
            End If
            Dim myCollection
            Dim tempStr As Object = New System.Text.StringBuilder()

            For Each myCollection In results.Properties("memberof")
                tempStr.Append(myCollection.ToString())
            Next myCollection

            sAns = tempStr.ToString().ToUpper()
        Catch ex As Exception
            sAns = ex.Message.ToString
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' Internal Function to looks up the account to see if account is in ad
    ''' </summary>
    Function FindObject(ByVal samAccountName As String, Optional ByVal sAccountType As AD_AccountType = AD_AccountType.USER, Optional ByRef ErrorMessage As String = "") As String
        Dim sAns As String = ""

        Try
            Dim MachineName As String = ""
            Dim dirEntry As DirectoryEntry = GetDirectoryEntry()
            Dim pcList As New Collection()
            Dim dirSearcher As DirectorySearcher = New DirectorySearcher(dirEntry)
            dirSearcher.Filter = "(CN=" & samAccountName & ")"
            Dim results As Object = dirSearcher.FindOne

            If (IsReference(results)) Then
                If sAccountType = AD_AccountType.USER Then
                    sAns = results.Properties("distinguishedName")(0).ToString
                Else
                    sAns = results.Properties("distinguishedName")(0).ToString
                End If
            Else
                sAns = "Not Found"
            End If
        Catch ex As Exception
            ErrorMessage = ex.Message.ToString
        End Try
        Return sAns
    End Function
    '''<summary>
    ''' This Sub will get the Name, Groups and Status of the Current User that is accessing the Site.
    ''' </summary>
    Public Sub SetLDAPAttribute(ByVal UsrID As String, Optional ByRef CITUDOMAIN As String = "", Optional ByRef CITUID As String = "")
        Dim wmiFailed As Boolean = True
        Dim delim As String = "\"
        Dim tempArray() As String = Split(UsrID, delim)
        If UBound(tempArray) > 0 Then
            If Trim(tempArray(0)) <> "" Then CITUDOMAIN = Trim(tempArray(0))
            If UBound(tempArray) > 0 Then CITUID = Trim(tempArray(1))
        Else
            CITUDOMAIN = DOMAIN_NAME
            CITUID = UsrID
        End If
        Try
            Dim DomString As String = ADSIString
            Dim grp As New System.DirectoryServices.DirectoryEntry(DomString)
            Dim searcher As New System.DirectoryServices.DirectorySearcher(grp)
            searcher.Filter = "(CN=" & CITUID & ")"
            Dim results As SearchResult = searcher.FindOne

            If (IsReference(results)) Then
                Dim strPath As String = "WinNT://" & DOMAIN_NAME & "/" & CITUID

                Dim dsDirectoryEntry As DirectoryEntry
                dsDirectoryEntry = New DirectoryEntry(strPath)
                Dim fromEntry As DirectoryEntry = results.GetDirectoryEntry()
                Dim caseResult As String

                Dim someObject As String = fromEntry.Properties("nTSecurityDescriptor").Value.ToString

                Select Case fromEntry.Properties("userAccountControl").Value
                    Case 2 'ADS_USER_FLAG.ADS_UF_ACCOUNTDISABLE '2
                        caseResult = "Account is disabled."
                    Case 65536 'ADS_USER_FLAG.ADS_UF_LOCKOUT '65536
                        caseResult = "Account is Locked"
                    Case 512 'ADS_USER_FLAG.ADS_UF_NORMAL_ACCOUNT '512
                        caseResult = "Account Normal"
                        '    caseResult = "Normal Account OK" ' <-- always hits this, even when I disable an account
                    Case 8388608 'ADS_USER_FLAG.ADS_UF_PASSWORD_EXPIRED '8388608
                        caseResult = "Password has Expired."
                    Case 544 'Account Enabled - Require user to change password at first logon 
                        caseResult = "Account Enabled - Require user to change password at first logon"
                    Case 514 'Disable account
                        caseResult = "Account is disabled."
                    Case 262656 ' Smart Card Logon Required
                        caseResult = "Smart Card Logon Required"
                    Case 66048 Or 66080 'Password never expires
                        caseResult = "Password never expires"
                    Case 66080 'Password never expires
                        caseResult = "Password never expires"
                    Case Else
                        caseResult = fromEntry.Properties("userAccountControl").Value
                End Select
            End If
        Catch ex As Exception
            Select Case (Err.Description)
                Case "Object variable or With block variable not set."
            End Select
        End Try
    End Sub
    '''<summary>
    ''' Get rid of all the AICN, CN, DC, OU, etc crap out of the string
    ''' </summary>
    Private Function TrimADCrap(ByVal sValue As String) As String
        Dim sAns As String = ""
        sAns = Microsoft.VisualBasic.Strings.Replace(sValue, "AICN=", "")
        sAns = Microsoft.VisualBasic.Strings.Replace(sAns, "cn=", "")
        sAns = Microsoft.VisualBasic.Strings.Replace(sAns, "dc=", "")
        sAns = Microsoft.VisualBasic.Strings.Replace(sAns, "ou=", "")
        sAns = Microsoft.VisualBasic.Strings.Replace(sAns, "CN=", "")
        sAns = Microsoft.VisualBasic.Strings.Replace(sAns, "DC=", "")
        sAns = Microsoft.VisualBasic.Strings.Replace(sAns, "OU=", "")
        Return sAns
    End Function
    '''<summary>
    ''' Quick Check to see if the user is allowed to use the application
    ''' This is based off of passing the list of groups that they are in as the iGroup
    ''' and Putting the Group Name in the AdminGroupName parameter for group that is allowed
    ''' to use the application.  This function will look through the iGroup for a match
    ''' tot he AdminGroupName
    ''' </summary>
    Public Function isAllowedToUseApp(ByVal iGroup As String, ByVal AdminGRoupName As String) As Boolean
        Dim bAns As Boolean = False
        Dim sSplit() As String = Split(iGroup, ",")
        Dim iBound As Integer = UBound(sSplit)
        Dim i As Integer = 0
        Dim sValue As String = ""
        For i = 0 To iBound - 1
            sValue = LCase(TrimADCrap(sSplit(i)))
            If sValue = LCase(AdminGRoupName) Then
                bAns = True
                Exit For
            End If
        Next
        Return bAns
    End Function
    '''<summary>
    ''' Get the Directory Entry
    ''' </summary>
    ''' 
    '''<remarks> Requires setting the Properties for ADSIString, DOMAIN_USER, and DOMAIN_USER_PASSWORD</remarks>
    Public Function GetDirectoryEntry() As DirectoryEntry
        Dim dirEntry As DirectoryEntry = New DirectoryEntry()
        dirEntry.Path = ADSIString
        dirEntry.Username = _DOMAIN_USER
        dirEntry.Password = _DOMAIN_USER_PASSWORD
        Return dirEntry
    End Function
#End Region
End Class
