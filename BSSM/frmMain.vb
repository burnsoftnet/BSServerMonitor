Imports System.IO.File
Imports System.Windows.Forms
Imports System.Diagnostics
Public Class frmMain
    Dim TIMER_INTERVAL As Long
    Dim cInterval As Long
    Dim chInterval As Long
    Dim iInterval As Long
    Dim wInterval As Long
    Dim pInterval As Long
    Public RunOnFirstRun As Boolean
    Public DBMAINT_ENABLED As Boolean
    Public COLHEALTH_ENABLED As Boolean
    Public COLHEALTH_APP As String
    Public COLLECTDATA_ENABLED As Boolean
    Public COLLECTDATA_APP As String
    Public DBMAINT_TIMER_INTERVAL As Long
    Public DBMAINT_TIMER_APP As String
    Public DO_DAILY_ARCHIVE As Boolean
    Public DO_MONTHLY_ARCHIVE As Boolean
    Public COLHEALTH_APP_xTimesInterval As Long
    Public WEBCHECK_APP As String
    Public WEBCHECK_ENABLED As Boolean
    Public WEBCHECK_INTERVAL As Long
    Public PORTCHECK_APP As String
    Public PORTCHECK_ENABLED As Boolean
    Public PORTCHECK_INTERVAL As Long

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        DO_DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
        DEBUG_LOGFILE = System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
        MyLogFile = System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
        CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
        If Not System.Diagnostics.EventLog.SourceExists(System.Configuration.ConfigurationManager.AppSettings("EVENT_SOURCE")) Then
            System.Diagnostics.EventLog.CreateEventSource(System.Configuration.ConfigurationManager.AppSettings("EVENT_SOURCE"), System.Configuration.ConfigurationManager.AppSettings("EVENT_LOG"))
        End If
        USE_LOGFILE = CBool(System.Configuration.ConfigurationManager.AppSettings("USE_LOGFILE"))
        USE_EVENT_LOG = CBool(System.Configuration.ConfigurationManager.AppSettings("USE_EVENT_LOG"))
        EventLog1.Source = System.Configuration.ConfigurationManager.AppSettings("EVENT_SOURCE")
        EventLog1.Log = System.Configuration.ConfigurationManager.AppSettings("EVENT_LOG")
        EventLog1.WriteEntry("Service Started", EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")))
        cInterval = 1
        chInterval = 1
        iInterval = 11
        TIMER_INTERVAL = CLng(System.Configuration.ConfigurationManager.AppSettings("TIMER_INTERVAL"))
        RunOnFirstRun = CBool(System.Configuration.ConfigurationManager.AppSettings("RunOnFirstRun"))
        COLHEALTH_APP = System.Configuration.ConfigurationManager.AppSettings("COLHEALTH_APP")
        COLHEALTH_ENABLED = CBool(System.Configuration.ConfigurationManager.AppSettings("COLHEALTH_ENABLED"))
        COLHEALTH_APP_xTimesInterval = CLng(System.Configuration.ConfigurationManager.AppSettings("COLHEALTH_APP_xTimesInterval"))
        COLLECTDATA_APP = System.Configuration.ConfigurationManager.AppSettings("COLLECTDATA_APP")
        COLLECTDATA_ENABLED = CBool(System.Configuration.ConfigurationManager.AppSettings("COLLECTDATA_ENABLED"))
        DBMAINT_ENABLED = CBool(System.Configuration.ConfigurationManager.AppSettings("DBMAINT_ENABLED"))
        DBMAINT_TIMER_INTERVAL = CLng(System.Configuration.ConfigurationManager.AppSettings("DBMAINT_TIMER_INTERVAL"))
        DBMAINT_TIMER_APP = System.Configuration.ConfigurationManager.AppSettings("DBMAINT_TIMER_APP")
        DO_DAILY_ARCHIVE = CBool(System.Configuration.ConfigurationManager.AppSettings("DO_DAILY_ARCHIVE"))
        DO_MONTHLY_ARCHIVE = CBool(System.Configuration.ConfigurationManager.AppSettings("DO_MONTHLY_ARCHIVE"))
        WEBCHECK_APP = System.Configuration.ConfigurationManager.AppSettings("WEBCHECK_APP")
        WEBCHECK_ENABLED = CBool(System.Configuration.ConfigurationManager.AppSettings("WEBCHECK_ENABLED"))
        WEBCHECK_INTERVAL = CLng(System.Configuration.ConfigurationManager.AppSettings("WEBCHECK_INTERVAL"))
        PORTCHECK_APP = System.Configuration.ConfigurationManager.AppSettings("PORTCHECK_APP")
        PORTCHECK_ENABLED = CBool(System.Configuration.ConfigurationManager.AppSettings("PORTCHECK_ENABLED"))
        PORTCHECK_INTERVAL = CLng(System.Configuration.ConfigurationManager.AppSettings("PORTCHECK_INTERVAL"))

        tmrSched.Enabled = True
        tmrSched.Interval = 59000
    End Sub
#Region "Running another Process"
    Sub COLLECTDATA(ByVal sArg As String)
        'NOTE: the CheckCollectorHealth sub will execute the BSSM_ColHel application, 
        '       which will check the report times of the collectors and if they have not
        '       reported back in twice amount of time of the regular interval, it will move it's load to another collector.
        Try
            Dim myProcess As New Process
            Dim ProcessName As String = COLLECTDATA_APP
            myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
            myProcess.StartInfo.FileName = ProcessName
            myProcess.StartInfo.Arguments = sArg
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            myProcess.Start()
            If DO_DEBUG Then EventLog1.WriteEntry("Running Daily Device Collection (" & sArg & ")", EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")) + 3)
            If DO_DEBUG Then Call CatchDebug("Working Path " & myProcess.StartInfo.WorkingDirectory, "frmMain.CollectData")
            If DO_DEBUG Then Call CatchDebug("Running Application: " & ProcessName & " " & sArg, "frmMain.CollectData")
        Catch ex As Exception
            Dim strform As String = "frmMain"
            Dim strProcedure As String = "COLLECTDATA"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            If USE_EVENT_LOG Then EventLog1.WriteEntry(sMessage, EventLogEntryType.Error, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_ERROR")))
            If USE_LOGFILE Then Call CatchError(sMessage, strform & "." & strProcedure)
        End Try
    End Sub
    Sub CheckCollectorHealth()
        'NOTE: the CheckCollectorHealth sub will execute the BSSM_ColHel application, 
        '       which will check the report times of the collectors and if they have not
        '       reported back in twice amount of time of the regular interval, it will move it's load to another collector.
        Try
            Dim myProcess As New Process
            Dim ProcessName As String = COLHEALTH_APP
            Dim returnValue As Process() = Process.GetProcessesByName(ProcessName)
            If returnValue.Length <= 1 Then
                myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
                myProcess.StartInfo.FileName = ProcessName
                myProcess.StartInfo.Arguments = "/interval=" & TIMER_INTERVAL & "/xtime=" & COLHEALTH_APP_xTimesInterval
                myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                myProcess.Start()
                If DO_DEBUG Then EventLog1.WriteEntry("Running Collector health Check", EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")) + 4)
                'If DO_DEBUG Then EventLog1.WriteEntry("Working Path " & myProcess.StartInfo.WorkingDirectory, EventLogEntryType.Information)
                'If DO_DEBUG Then EventLog1.WriteEntry("Running Application: " & ProcessName, EventLogEntryType.Information)
                If DO_DEBUG Then Call CatchDebug("Working Path " & myProcess.StartInfo.WorkingDirectory, "frmMain.CheckCollectorHealth")
                If DO_DEBUG Then Call CatchDebug("Running Application: " & ProcessName, "frmMain.CheckCollectorHealth")
            Else
                If DO_DEBUG Then EventLog1.WriteEntry(ProcessName & " is already running", EventLogEntryType.Information)
            End If

        Catch ex As Exception
            Dim strform As String = "frmMain"
            Dim strProcedure As String = "CheckCollectorHealth"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            If USE_EVENT_LOG Then EventLog1.WriteEntry(sMessage, EventLogEntryType.Error, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_ERROR")))
            If USE_LOGFILE Then Call CatchError(sMessage, strform & "." & strProcedure)
        End Try
    End Sub
    Sub RunApp()
        'NOTE: The RunApp sub will execute the BSSM_PingManager process which will
        '   Ping all the Servers/ all assigned servers in the database.
        Try
            Dim myProcess As New Process
            Dim StartTime As Object
            Dim EndTime As Object
            Dim OverallTime As Long = 0
            Dim ProcessName As String = System.Configuration.ConfigurationManager.AppSettings("RUNPROGRAM")
            myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
            'If DO_DEBUG Then EventLog1.WriteEntry("Working Path " & myProcess.StartInfo.WorkingDirectory, EventLogEntryType.Information)
            'If DO_DEBUG Then EventLog1.WriteEntry("Running Application: " & ProcessName, EventLogEntryType.Information) ', CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")))
            If DO_DEBUG Then Call CatchDebug("Working Path " & myProcess.StartInfo.WorkingDirectory, "frmMain.RunApp")
            If DO_DEBUG Then Call CatchDebug("Running Application: " & ProcessName, "frmMain.RunApp")
            myProcess.StartInfo.FileName = ProcessName
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            StartTime = Now
            myProcess.Start()
            myProcess.WaitForExit()
            EndTime = Now
            OverallTime = DateDiff(DateInterval.Minute, StartTime, EndTime)
            If DO_DEBUG Then EventLog1.WriteEntry("Overall Run Time: " & OverallTime, EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")) + 2)
        Catch ex As Exception
            Dim strform As String = "frmMain"
            Dim strProcedure As String = "RunApp"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            If USE_EVENT_LOG Then EventLog1.WriteEntry(sMessage, EventLogEntryType.Error, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_ERROR")))
            If USE_LOGFILE Then Call CatchError(sMessage, strform & "." & strProcedure)
        End Try
    End Sub
    Sub DO_DB_Maint()
        'NOTE: the DO_DB_Maint sub will execute the DBMaint application which will
        '   trim down the data in the database and other database maintance tasks.
        Try
            Dim myProcess As New Process
            Dim ProcessName As String = DBMAINT_TIMER_APP
            myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
            myProcess.StartInfo.FileName = ProcessName
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            If DO_DEBUG Then EventLog1.WriteEntry("Running Database Maintenance App", EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")) + 3)
            myProcess.Start()
        Catch ex As Exception
            Dim strform As String = "frmMain"
            Dim strProcedure As String = "DO_DB_Maint"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            If USE_EVENT_LOG Then EventLog1.WriteEntry(sMessage, EventLogEntryType.Error, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_ERROR")))
            If USE_LOGFILE Then Call CatchError(sMessage, strform & "." & strProcedure)
        End Try
    End Sub
    Sub DO_DB_Maint_STATS()
        'NOTE: the DO_DB_Maint sub will execute the DBMaint application which will
        '   trim down the data in the database and other database maintance tasks.
        Try
            Dim myProcess As New Process
            Dim ProcessName As String = DBMAINT_TIMER_APP
            myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
            myProcess.StartInfo.FileName = ProcessName
            myProcess.StartInfo.Arguments = "/cleandb"
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            If DO_DEBUG Then EventLog1.WriteEntry("Running Database Maintenance Stats CLEANUP", EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")) + 3)
            myProcess.Start()
        Catch ex As Exception
            Dim strform As String = "frmMain"
            Dim strProcedure As String = "DO_DB_Maint_Daily"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            If USE_EVENT_LOG Then EventLog1.WriteEntry(sMessage, EventLogEntryType.Error, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_ERROR")))
            If USE_LOGFILE Then Call CatchError(sMessage, strform & "." & strProcedure)
        End Try
    End Sub
    Sub DO_DB_Maint_Daily()
        'NOTE: the DO_DB_Maint sub will execute the DBMaint application which will
        '   trim down the data in the database and other database maintance tasks.
        Try
            Dim myProcess As New Process
            Dim ProcessName As String = DBMAINT_TIMER_APP
            myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
            myProcess.StartInfo.FileName = ProcessName
            myProcess.StartInfo.Arguments = "/archday=1"
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            If DO_DEBUG Then EventLog1.WriteEntry("Running Database Maintenance Daily App", EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")) + 3)
            myProcess.Start()
        Catch ex As Exception
            Dim strform As String = "frmMain"
            Dim strProcedure As String = "DO_DB_Maint_Daily"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            If USE_EVENT_LOG Then EventLog1.WriteEntry(sMessage, EventLogEntryType.Error, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_ERROR")))
            If USE_LOGFILE Then Call CatchError(sMessage, strform & "." & strProcedure)
        End Try
    End Sub
    Sub DO_DB_Maint_Monthly()
        'NOTE: the DO_DB_Maint sub will execute the DBMaint application which will
        '   trim down the data in the database and other database maintance tasks.
        Try
            Dim myProcess As New Process
            Dim ProcessName As String = DBMAINT_TIMER_APP
            myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
            myProcess.StartInfo.FileName = ProcessName
            myProcess.StartInfo.Arguments = "/archmonth=1"
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            If DO_DEBUG Then EventLog1.WriteEntry("Running Database Maintenance MOnthly App", EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")) + 3)
            myProcess.Start()
        Catch ex As Exception
            Dim strform As String = "frmMain"
            Dim strProcedure As String = "DO_DB_Maint_Monthly"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            If USE_EVENT_LOG Then EventLog1.WriteEntry(sMessage, EventLogEntryType.Error, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_ERROR")))
            If USE_LOGFILE Then Call CatchError(sMessage, strform & "." & strProcedure)
        End Try
    End Sub
    Sub DO_WEB_CHECKS()
        'NOTE: the DO_WEB_CHECKS sub will execute the WebManager application which will
        ' download the list of sites and hosts that it needs to check and check those sites
        Try
            Dim myProcess As New Process
            Dim ProcessName As String = WEBCHECK_APP
            myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
            myProcess.StartInfo.FileName = ProcessName
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            If DO_DEBUG Then EventLog1.WriteEntry("Running WebCheck App", EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")) + 3)
            myProcess.Start()
        Catch ex As Exception
            Dim strform As String = "frmMain"
            Dim strProcedure As String = "DO_WEB_CHECKS"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            If USE_EVENT_LOG Then EventLog1.WriteEntry(sMessage, EventLogEntryType.Error, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_ERROR")))
            If USE_LOGFILE Then Call CatchError(sMessage, strform & "." & strProcedure)
        End Try
    End Sub
    Sub DO_PORT_CHECKS()
        'NOTE: the DO_WEB_CHECKS sub will execute the WebManager application which will
        ' download the list of sites and hosts that it needs to check and check those sites
        Try
            Dim myProcess As New Process
            Dim ProcessName As String = PORTCHECK_APP
            myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
            myProcess.StartInfo.FileName = ProcessName
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
            If DO_DEBUG Then EventLog1.WriteEntry("Running PortCheck App", EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")) + 3)
            myProcess.Start()
        Catch ex As Exception
            Dim strform As String = "frmMain"
            Dim strProcedure As String = "DO_PORT_CHECKS"
            Dim sMessage As String = strform & "." & strProcedure & "::" & Err.Number & "::" & ex.Message.ToString()
            If USE_EVENT_LOG Then EventLog1.WriteEntry(sMessage, EventLogEntryType.Error, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_ERROR")))
            If USE_LOGFILE Then Call CatchError(sMessage, strform & "." & strProcedure)
        End Try
    End Sub
#End Region

    Function IsDataTime(ByVal sMode As String) As Boolean
        Dim bAns As Boolean = False
        Dim sAPPSettingNameHour As String = UCase(sMode) & "_TIME_HOUR"
        Dim sAPPSettingNameMin As String = UCase(sMode) & "_TIME_MINUTE"
        Dim cHour As Integer = Now.TimeOfDay.Hours
        Dim cMin As Integer = Now.TimeOfDay.Minutes
        Dim iHour As Integer = CInt(System.Configuration.ConfigurationManager.AppSettings(sAPPSettingNameHour))
        Dim iMin As Integer = CInt(System.Configuration.ConfigurationManager.AppSettings(sAPPSettingNameMin))
        If iHour = cHour Then
            If iMin = cMin Then
                bAns = True
            Else
                bAns = False
            End If
        Else
            bAns = False
        End If
        Dim sMsg As String = "Current Hour:  " & cHour & ":" & cMin & Chr(10) & "Matching Time:" & iHour & ":" & iMin & Chr(10) & "IsMatch: " & bAns
        If DO_DEBUG Then EventLog1.WriteEntry(sMsg, EventLogEntryType.Information)
        If DO_DEBUG Then Call CatchDebug(sMsg, "frmMain.IsDataTime")
        Return bAns
    End Function
    Private Sub tmrSched_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSched.Tick
        If RunOnFirstRun Then
            RunOnFirstRun = False
            Call RunApp()
        End If
        If cInterval = TIMER_INTERVAL Then
            Call RunApp()
            cInterval = 1
        Else
            cInterval += 1
        End If
        If DBMAINT_ENABLED Then
            If iInterval = DBMAINT_TIMER_INTERVAL Then
                Call DO_DB_Maint()
                Call DO_DB_Maint_STATS()
                iInterval = 1
            Else
                iInterval += 1
            End If
        End If
        If COLHEALTH_ENABLED Then
            If chInterval = (TIMER_INTERVAL * COLHEALTH_APP_xTimesInterval) Then
                Call CheckCollectorHealth()
                chInterval = 1
            Else
                chInterval += 1
            End If
        End If
        If WEBCHECK_ENABLED Then
            If wInterval = WEBCHECK_INTERVAL Then
                Call DO_WEB_CHECKS()
                wInterval = 1
            Else
                wInterval += 1
            End If
        End If
        If PORTCHECK_ENABLED Then
            If pInterval = PORTCHECK_INTERVAL Then
                Call DO_PORT_CHECKS()
                pInterval = 1
            Else
                pInterval += 1
            End If
        End If
        If COLLECTDATA_ENABLED Then
            If IsDataTime("COLLECTDATA") Then
                Call COLLECTDATA(System.Configuration.ConfigurationManager.AppSettings("COLLECTDATA_APP_ARG"))
            End If
            If IsDataTime("PROCESSDATA") Then
                Call COLLECTDATA(System.Configuration.ConfigurationManager.AppSettings("PROCESSDATA_APP_ARG"))
            End If
        End If
        If DO_DAILY_ARCHIVE Then
            If IsDataTime("DO_DAILY_ARCHIVE") Then
                Call DO_DB_Maint_Daily()
            End If
        End If
        If DO_MONTHLY_ARCHIVE Then
            If IsDataTime("DO_MONTHLY_ARCHIVE") Then
                Call DO_DB_Maint_Monthly()
            End If
        End If
    End Sub
End Class
