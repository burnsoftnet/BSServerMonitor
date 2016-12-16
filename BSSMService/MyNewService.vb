Imports System.ServiceProcess
Imports System.IO.File
Imports System.ServiceProcess.ServiceBase
Imports System.Windows.Forms
Imports System.Diagnostics
Public Class MyNewService
    Public TIMER_INTERVAL As Long
    Dim cInterval As Long
    Dim iInterval As Long
    Public RunOnFirstRun As Boolean
    Public myProcess As New Process
    Shared Sub Main()
        DO_DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
        DO_HEALTH_CHECK = CBool(System.Configuration.ConfigurationManager.AppSettings("DO_HEALTH_CHECK"))
        Dim ServicestoRun() As System.ServiceProcess.ServiceBase
        ServicestoRun = New System.ServiceProcess.ServiceBase() _
                    {New MyNewService()}
        System.ServiceProcess.ServiceBase.Run(ServicestoRun)
    End Sub
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        If Not System.Diagnostics.EventLog.SourceExists(System.Configuration.ConfigurationManager.AppSettings("EVENT_SOURCE")) Then
            System.Diagnostics.EventLog.CreateEventSource(System.Configuration.ConfigurationManager.AppSettings("EVENT_SOURCE"), System.Configuration.ConfigurationManager.AppSettings("EVENT_LOG"))
        End If
        EventLog1.Source = System.Configuration.ConfigurationManager.AppSettings("EVENT_SOURCE")
        EventLog1.Log = System.Configuration.ConfigurationManager.AppSettings("EVENT_LOG")
    End Sub
    Protected Overrides Sub OnStart(ByVal args() As String)
        Const iTIME_INTERVAL As Integer = 60000      ' 60 seconds.
        Dim oTimer As System.Threading.Timer
        EventLog1.WriteEntry("Service Started", EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")))
        cInterval = 1
        TIMER_INTERVAL = CLng(System.Configuration.ConfigurationManager.AppSettings("TIMER_INTERVAL"))
        RunOnFirstRun = True
        Call StartSchedAgent()
        Dim tDelegate As Threading.TimerCallback = AddressOf EventAction
        oTimer = New System.Threading.Timer(tDelegate, Me, 0, iTIME_INTERVAL)
    End Sub
    Sub StartSchedAgent()
        Dim ProcessName As String = "bssm.exe"
        myProcess.StartInfo.WorkingDirectory = Application.StartupPath & "\"
        If DO_DEBUG Then EventLog1.WriteEntry("Working Path " & myProcess.StartInfo.WorkingDirectory, EventLogEntryType.Information)
        If DO_DEBUG Then EventLog1.WriteEntry("Running Application: " & ProcessName, EventLogEntryType.Information) ', CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")))
        myProcess.StartInfo.FileName = ProcessName
        myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        myProcess.Start()
        'myProcess.WaitForExit()
    End Sub
    Protected Overrides Sub OnStop()
        myProcess.Kill()
        EventLog1.WriteEntry("Service Stopped", EventLogEntryType.Information, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_INFO")) + 1)
    End Sub

    Public Sub EventAction(ByVal sender As Object)
        If DO_DEBUG Then EventLog1.WriteEntry("Running EventAction", EventLogEntryType.Information)
        If DO_HEALTH_CHECK Then
            If RunOnFirstRun Then
                If DO_DEBUG Then EventLog1.WriteEntry("FIRST RUN: " & cInterval, EventLogEntryType.Information)
                If cInterval >= (TIMER_INTERVAL + 5) Then
                    RunOnFirstRun = False
                Else
                    cInterval += 1
                End If
            Else
                If DO_DEBUG Then EventLog1.WriteEntry("OFF FIRST RUN", EventLogEntryType.Information)
                If Not IsWorking(TIMER_INTERVAL) Then
                    EventLog1.WriteEntry("BSSM Processs Manager not updating, attempting to restart.", EventLogEntryType.Warning, CInt(System.Configuration.ConfigurationManager.AppSettings("EVENT_ID_WARN")) + 1)
                    myProcess.Kill()
                End If
            End If
        End If
        Dim returnValue As Process() = Process.GetProcessesByName("BSSM")
        If returnValue.Length = 0 Then Call StartSchedAgent()
    End Sub
End Class
