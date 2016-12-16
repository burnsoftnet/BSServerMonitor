Imports System.Net.NetworkInformation
Imports System
Imports System.Data
Imports System.IO
Imports System.Net
Imports System.Xml
Imports System.Xml.XPath
Imports System.Configuration
Imports System.Windows.Forms
Imports System.Text
Imports System.Diagnostics
Imports BSSM_Setup.BurnSoft.GlobalClasses
Public Class frmMain
    Const BSSM As String = "\BSSM.exe"
    Const PINGMANAGER As String = "\BSSM_PingManager.exe"
    Const NMAP As String = "\BSSM_NMAP.exe"
    Const ADDSVR As String = "\bsaddsrv.exe"
    Const PORTMON As String = "\BSPortManager.exe"
    Const COLHEALTH As String = "\BSSM_ColHealth.exe"
    Const PINGER As String = "\BSSM_Pinger.exe"
    Const PORTSCANNER As String = "\bssm_PortScanner.exe"
    Const BSSMSERVICE As String = "\BSSMService.exe"
    Const DBMAINT As String = "\dbmaint.exe"
    Public EXISTS_BSSM As Boolean
    Public EXISTS_PINGMANAGER As Boolean
    Public EXISTS_NMAP As Boolean
    Public EXISTS_ADDSVR As Boolean
    Public EXISTS_PORTMON As Boolean
    Public EXISTS_COLHEALTH As Boolean
    Public EXISTS_PINGER As Boolean
    Public EXISTS_PORTSCANNER As Boolean
    Public EXISTS_BSSMSERVICE As Boolean
    Public EXISTS_DBMAINT As Boolean
#Region "Loading Data"
    Sub Load_BSSM()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & BSSM
        Dim MyConfig As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        cmbDebug_BSSM.Text = MyConfig.AppSettings.Settings.Item("DEBUG").Value.ToString
        cmbConsole_BSSM.Text = MyConfig.AppSettings.Settings.Item("CONSOLE").Value.ToString
        cmbLog_BSSM.Text = MyConfig.AppSettings.Settings.Item("USE_LOGFILE").Value.ToString
        cmbEventLog_BSSM.Text = MyConfig.AppSettings.Settings.Item("USE_EVENT_LOG").Value.ToString
        txtLogName_BSSM.Text = MyConfig.AppSettings.Settings.Item("LOGFILE").Value.ToString
        txtDebugLog_bssm.Text = MyConfig.AppSettings.Settings.Item("BUGFILE").Value.ToString
        txtSHORTPATH_bssm.Text = MyConfig.AppSettings.Settings.Item("SHORTPATH").Value.ToString
        nudTimer_bssm.Value = MyConfig.AppSettings.Settings.Item("TIMER_INTERVAL").Value.ToString
        txtEVENT_SOURCE_bssm.Text = MyConfig.AppSettings.Settings.Item("EVENT_SOURCE").Value.ToString
        txtEVENT_LOG_bssm.Text = MyConfig.AppSettings.Settings.Item("EVENT_LOG").Value.ToString
        nudEVENT_ID_INFO_bssm.Value = MyConfig.AppSettings.Settings.Item("EVENT_ID_INFO").Value.ToString
        nudEVENT_ID_WARN_bssm.Value = MyConfig.AppSettings.Settings.Item("EVENT_ID_WARN").Value.ToString
        nudEVENT_ID_ERROR_bssm.Value = MyConfig.AppSettings.Settings.Item("EVENT_ID_ERROR").Value.ToString
        cmbRunonFirst_bssm.Text = MyConfig.AppSettings.Settings.Item("RunOnFirstRun").Value.ToString
        txtRUNPROGRAM_bssm.Text = MyConfig.AppSettings.Settings.Item("RUNPROGRAM").Value.ToString
        cmbDBMAINT_ENABLED_bssm.Text = MyConfig.AppSettings.Settings.Item("DBMAINT_ENABLED").Value.ToString
        nudDBMAINT_TIMER_INTERVAL_bssm.Value = MyConfig.AppSettings.Settings.Item("DBMAINT_TIMER_INTERVAL").Value.ToString
        txtDBMAINT_TIMER_APP_bssm.Text = MyConfig.AppSettings.Settings.Item("DBMAINT_TIMER_APP").Value.ToString
        cmbDO_DAILY_ARCHIVE_bssm.Text = MyConfig.AppSettings.Settings.Item("DO_DAILY_ARCHIVE").Value.ToString
        cmbDO_MONTHLY_ARCHIVE_bssm.Text = MyConfig.AppSettings.Settings.Item("DO_MONTHLY_ARCHIVE").Value.ToString
        nudDO_DAILY_ARCHIVE_TIME_HOUR.Value = MyConfig.AppSettings.Settings.Item("DO_DAILY_ARCHIVE_TIME_HOUR").Value.ToString
        nudDO_DAILY_ARCHIVE_TIME_MINUTE.Value = MyConfig.AppSettings.Settings.Item("DO_DAILY_ARCHIVE_TIME_MINUTE").Value.ToString
        nudDO_MONTHLY_ARCHIVE_TIME_HOUR.Value = MyConfig.AppSettings.Settings.Item("DO_MONTHLY_ARCHIVE_TIME_HOUR").Value.ToString
        nudDO_MONTHLY_ARCHIVE_TIME_MINUTE.Value = MyConfig.AppSettings.Settings.Item("DO_MONTHLY_ARCHIVE_TIME_MINUTE").Value.ToString
        cmbCOLHEALTH_ENABLED.Text = MyConfig.AppSettings.Settings.Item("COLHEALTH_ENABLED").Value.ToString
        txtCOLHEALTH_APP.Text = MyConfig.AppSettings.Settings.Item("COLHEALTH_APP").Value.ToString
        nudCOLHEALTH_APP_xTimesInterval.Value = MyConfig.AppSettings.Settings.Item("COLHEALTH_APP_xTimesInterval").Value.ToString
        cmbCOLLECTDATA_ENABLED.Text = MyConfig.AppSettings.Settings.Item("COLLECTDATA_ENABLED").Value.ToString
        txtCOLLECTDATA_APP.Text = MyConfig.AppSettings.Settings.Item("COLLECTDATA_APP").Value.ToString
        txtCOLLECTDATA_APP_ARG.Text = MyConfig.AppSettings.Settings.Item("COLLECTDATA_APP_ARG").Value.ToString
        nudCOLLECTDATA_TIME_HOUR.Value = MyConfig.AppSettings.Settings.Item("COLLECTDATA_TIME_HOUR").Value.ToString
        nudCOLLECTDATA_TIME_MINUTE.Value = MyConfig.AppSettings.Settings.Item("COLLECTDATA_TIME_MINUTE").Value.ToString
        txtPROCESSDATA_APP.Text = MyConfig.AppSettings.Settings.Item("PROCESSDATA_APP").Value.ToString
        txtPROCESSDATA_APP_ARG.Text = MyConfig.AppSettings.Settings.Item("PROCESSDATA_APP_ARG").Value.ToString
        nudPROCESSDATA_TIME_HOUR.Value = MyConfig.AppSettings.Settings.Item("PROCESSDATA_TIME_HOUR").Value.ToString
        nudPROCESSDATA_TIME_MINUTE.Value = MyConfig.AppSettings.Settings.Item("PROCESSDATA_TIME_MINUTE").Value.ToString
        cmbWebEnabled.Text = MyConfig.AppSettings.Settings.Item("WEBCHECK_ENABLED").Value.ToString
        nudWebInterval.Value = MyConfig.AppSettings.Settings.Item("WEBCHECK_INTERVAL").Value.ToString
        txtWebApp.Text = MyConfig.AppSettings.Settings.Item("WEBCHECK_APP").Value.ToString
        cmbPortCheck.Text = MyConfig.AppSettings.Settings.Item("PORTCHECK_ENABLED").Value.ToString
        nudPortInterval.Value = MyConfig.AppSettings.Settings.Item("PORTCHECK_INTERVAL").Value.ToString
        txtPortApp.Text = MyConfig.AppSettings.Settings.Item("PORTCHECK_APP").Value.ToString
    End Sub
    Sub Load_PINGMANAGER()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & PINGMANAGER
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        nudDataCollectorID_pm.Value = Config.AppSettings.Settings.Item("DataCollectorID").Value
        nudThrottle_pm.Value = Config.AppSettings.Settings.Item("Throttle").Value
        nudPingXTimes_pm.Value = Config.AppSettings.Settings.Item("PingXTimes").Value
        nudDataLimits_pm.Value = Config.AppSettings.Settings.Item("DataLimits").Value
        cmbDataPull_pm.Text = Config.AppSettings.Settings.Item("DataPull").Value
        txtXMLFILENAME_pm.Text = Config.AppSettings.Settings.Item("XMLFILENAME").Value
        cmbDEBUG_pm.Text = Config.AppSettings.Settings.Item("DEBUG").Value
        cmbCONSOLE_pm.Text = Config.AppSettings.Settings.Item("CONSOLE").Value
        txtLOGFILE_pm.Text = Config.AppSettings.Settings.Item("LOGFILE").Value
        txtBUGFILE_pm.Text = Config.AppSettings.Settings.Item("BUGFILE").Value
        txtDB_SERVER_pm.Text = Config.AppSettings.Settings.Item("DB_SERVER").Value
        txtDBName.Text = Config.AppSettings.Settings.Item("DB_NAME").Value
        DBServer_DS.Text = txtDB_SERVER_pm.Text
        DBNAME_DS.Text = txtDBName.Text
        If nudDataCollectorID_pm.Value = 0 Then
            chkIsMaster.Checked = True
        Else
            chkIsMaster.Checked = False
        End If
    End Sub
    Sub Load_NMAP()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & NMAP
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        cmbDEBUG_n.Text = Config.AppSettings.Settings.Item("DEBUG").Value
        cmbCONSOLE_n.Text = Config.AppSettings.Settings.Item("CONSOLE").Value
        txtLOGFILE_n.Text = Config.AppSettings.Settings.Item("LOGFILE").Value
        txtBUGFILE_n.Text = Config.AppSettings.Settings.Item("BUGFILE").Value
        txtDATAFOLDER_n.Text = Config.AppSettings.Settings.Item("DATAFOLDER").Value
        txtXMLFILENAME_n.Text = Config.AppSettings.Settings.Item("XMLFILENAME").Value
        nudThrottle_n.Value = Config.AppSettings.Settings.Item("Throttle").Value
        cmbMODE_n.Text = Config.AppSettings.Settings.Item("MODE").Value
        txtNMAP_APPNAME_n.Text = Config.AppSettings.Settings.Item("NMAP_APPNAME").Value
        txtNMAP_FULL_n.Text = Config.AppSettings.Settings.Item("NMAP_FULL").Value
        txtNMAP_TRACE_n.Text = Config.AppSettings.Settings.Item("NMAP_TRACE").Value
        txtNMAP_PORT_n.Text = Config.AppSettings.Settings.Item("NMAP_PORT").Value
        cmbCOLLECTIONMODE_n.Text = Config.AppSettings.Settings.Item("COLLECTIONMODE").Value
        nudDataCollectorID_n.Value = Config.AppSettings.Settings.Item("DataCollectorID").Value
    End Sub
    Sub Load_ADDSVR()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & ADDSVR
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        cmbDEBUG_a.Text = Config.AppSettings.Settings.Item("DEBUG").Value
        cmbCONSOLE_a.Text = Config.AppSettings.Settings.Item("CONSOLE").Value
        txtLOGFILE_a.Text = Config.AppSettings.Settings.Item("LOGFILE").Value
        txtBUGFILE_a.Text = Config.AppSettings.Settings.Item("BUGFILE").Value
        nudDataCollectorID_a.Value = Config.AppSettings.Settings.Item("DataCollectorID").Value
        txtSP_ADDSRV.Text = Config.AppSettings.Settings.Item("SP_ADDSRV").Value
    End Sub
    Sub Load_PORTMON()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & PORTMON
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        cmbDEBUG_p.Text = Config.AppSettings.Settings.Item("DEBUG").Value
        cmbCONSOLE_p.Text = Config.AppSettings.Settings.Item("CONSOLE").Value
        txtLOGFILE_p.Text = Config.AppSettings.Settings.Item("LOGFILE").Value
        txtBUGFILE_p.Text = Config.AppSettings.Settings.Item("BUGFILE").Value
        nudThrottle_p.Value = Config.AppSettings.Settings.Item("Throttle").Value
        nudPingXTimes_p.Value = Config.AppSettings.Settings.Item("PingXTimes").Value
        nudDataCollectorID_p.Value = Config.AppSettings.Settings.Item("DataCollectorID").Value
    End Sub
    Sub Load_COLHEALTH()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & COLHEALTH
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        cmbDEBUG_c.Text = Config.AppSettings.Settings.Item("DEBUG").Value
        cmbCONSOLE_c.Text = Config.AppSettings.Settings.Item("CONSOLE").Value
        txtLOGFILE_c.Text = Config.AppSettings.Settings.Item("LOGFILE").Value
        txtBUGFILE_c.Text = Config.AppSettings.Settings.Item("BUGFILE").Value
        nudPingXTimes_c.Value = Config.AppSettings.Settings.Item("xTimesInterval").Value
        nudDataCollectorID_c.Value = Config.AppSettings.Settings.Item("DEFAULTCOLLECTOR").Value
    End Sub
    Sub Load_PINGER()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & PINGER
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        cmbDEBUG_pi.Text = Config.AppSettings.Settings.Item("DEBUG").Value
        cmbCONSOLE_pi.Text = Config.AppSettings.Settings.Item("CONSOLE").Value
        txtLOGFILE_pi.Text = Config.AppSettings.Settings.Item("LOGFILE").Value
        txtBUGFILE_pi.Text = Config.AppSettings.Settings.Item("BUGFILE").Value
        nudPING_TIMEOUT_pi.Value = Config.AppSettings.Settings.Item("PING_TIMEOUT").Value
        nudREPEAT_EVT_HRS_pi.Value = Config.AppSettings.Settings.Item("REPEAT_EVT_HRS").Value
        cmbUSETRACE_pi.Text = Config.AppSettings.Settings.Item("USETRACE").Value
    End Sub
    Sub Load_PORTscanner()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & PORTSCANNER
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        cmbDEBUG_po.Text = Config.AppSettings.Settings.Item("DEBUG").Value
        cmbCONSOLE_po.Text = Config.AppSettings.Settings.Item("CONSOLE").Value
        txtLOGFILE_po.Text = Config.AppSettings.Settings.Item("LOGFILE").Value
        txtBUGFILE_po.Text = Config.AppSettings.Settings.Item("BUGFILE").Value
        nudPORT_TIMEOUT_po.Value = Config.AppSettings.Settings.Item("PORT_TIMEOUT").Value
    End Sub
    Sub Load_BSSMSERVICE()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & BSSMSERVICE
        Dim MyConfig As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        cmbDebug_service.Text = MyConfig.AppSettings.Settings.Item("DEBUG").Value.ToString
        cmbDO_HEALTH_CHECK_service.Text = MyConfig.AppSettings.Settings.Item("DO_HEALTH_CHECK").Value.ToString
        txtSHORTPATH_service.Text = MyConfig.AppSettings.Settings.Item("SHORTPATH").Value.ToString
        nudTimer_service.Value = MyConfig.AppSettings.Settings.Item("TIMER_INTERVAL").Value.ToString
        txtEVENT_SOURCE_service.Text = MyConfig.AppSettings.Settings.Item("EVENT_SOURCE").Value.ToString
        txtEVENT_LOG_service.Text = MyConfig.AppSettings.Settings.Item("EVENT_LOG").Value.ToString
        nudEVENT_ID_INFO_service.Value = MyConfig.AppSettings.Settings.Item("EVENT_ID_INFO").Value.ToString
        nudEVENT_ID_WARN_service.Value = MyConfig.AppSettings.Settings.Item("EVENT_ID_WARN").Value.ToString
        nudEVENT_ID_ERROR_service.Value = MyConfig.AppSettings.Settings.Item("EVENT_ID_ERROR").Value.ToString

    End Sub
    Sub Load_DBMAINT()
        On Error Resume Next
        Dim AppPath As String = Application.StartupPath & DBMAINT
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(AppPath)
        cmbDEBUG_d.Text = Config.AppSettings.Settings.Item("DEBUG").Value
        cmbCONSOLE_d.Text = Config.AppSettings.Settings.Item("CONSOLE").Value
        txtLOGFILE_d.Text = Config.AppSettings.Settings.Item("LOGFILE").Value
        txtBUGFILE_d.Text = Config.AppSettings.Settings.Item("BUGFILE").Value
        cmbUSE_SP_d.Text = Config.AppSettings.Settings.Item("USE_SP").Value
        cmbUSE_RAWDATA_d.Text = Config.AppSettings.Settings.Item("USE_RAWDATA").Value
        cmbKEEPDATA.Text = Config.AppSettings.Settings.Item("KEEPDATA").Value
        nudKEEPDATA_DAYS.Value = Config.AppSettings.Settings.Item("KEEPDATA_DAYS").Value
        nudKEEPDATA_HOURS.Value = Config.AppSettings.Settings.Item("KEEPDATA_HOURS").Value
        cmbKEEPRAWDATA_USE.Text = Config.AppSettings.Settings.Item("KEEPRAWDATA_USE").Value
        nudKEEPRAWDATA_DAYS.Value = Config.AppSettings.Settings.Item("KEEPRAWDATA_DAYS").Value
        nudKEEPRAWDATA_HOURS.Value = Config.AppSettings.Settings.Item("KEEPRAWDATA_HOURS").Value
        txtSP_DELETEDATA_DAILY.Text = Config.AppSettings.Settings.Item("SP_DELETEDATA_DAILY").Value
        txtSP_DELETEDATA_HOURLY.Text = Config.AppSettings.Settings.Item("SP_DELETEDATA_HOURLY").Value
        cmbDO_DAILY_ARCHIVE.Text = Config.AppSettings.Settings.Item("DO_DAILY_ARCHIVE").Value
        nudDO_DAILY_ARCHIVE_HOUR.Value = Config.AppSettings.Settings.Item("DO_DAILY_ARCHIVE_HOUR").Value
        nudDO_DAILY_ARCHIVE_MIN.Value = Config.AppSettings.Settings.Item("DO_DAILY_ARCHIVE_MIN").Value
        cmbDO_DELETEMARKEDDEVICES.Text = Config.AppSettings.Settings.Item("DO_DELETEMARKEDDEVICES").Value
        nudDO_DELETEMARKEDDEVICES_DAYS.Value = Config.AppSettings.Settings.Item("DO_DELETEMARKEDDEVICES_DAYS").Value
        nudMAINT_DELETE_DAILY_DAYS.Value = Config.AppSettings.Settings.Item("MAINT_DELETE_DAILY_DAYS").Value
        nudMAINT_DELETE_DAILY_DAYS_EVENTS.Value = Config.AppSettings.Settings.Item("MAINT_DELETE_DAILY_DAYS_EVENTS").Value
        nudMAINT_DELETE_MONTHLY_MONTHS.Value = Config.AppSettings.Settings.Item("MAINT_DELETE_MONTHLY_MONTHS").Value
        nudMAINT_DELETE_YEARLYLY_YEARS.value = Config.AppSettings.Settings.Item("MAINT_DELETE_YEARLYLY_YEARS").Value

    End Sub
#End Region
#Region "Saving Data"
    Sub Save_BSSM()
        Dim sPath As String = Application.StartupPath & BSSM
        Call ChangeAppSettings(sPath, "DEBUG", cmbDebug_BSSM.Text)
        Call ChangeAppSettings(sPath, "CONSOLE", cmbConsole_BSSM.Text)
        Call ChangeAppSettings(sPath, "USE_LOGFILE", cmbLog_BSSM.Text)
        Call ChangeAppSettings(sPath, "USE_EVENT_LOG", cmbEventLog_BSSM.Text)
        Call ChangeAppSettings(sPath, "LOGFILE", txtLogName_BSSM.Text)
        Call ChangeAppSettings(sPath, "BUGFILE", txtDebugLog_bssm.Text)
        Call ChangeAppSettings(sPath, "SHORTPATH", txtSHORTPATH_bssm.Text)
        Call ChangeAppSettings(sPath, "TIMER_INTERVAL", nudTimer_bssm.Value)
        Call ChangeAppSettings(sPath, "EVENT_SOURCE", txtEVENT_SOURCE_bssm.Text)
        Call ChangeAppSettings(sPath, "EVENT_LOG", txtEVENT_LOG_bssm.Text)
        Call ChangeAppSettings(sPath, "EVENT_ID_INFO", nudEVENT_ID_INFO_bssm.Value)
        Call ChangeAppSettings(sPath, "EVENT_ID_WARN", nudEVENT_ID_WARN_bssm.Value)
        Call ChangeAppSettings(sPath, "EVENT_ID_ERROR", nudEVENT_ID_ERROR_bssm.Value)
        Call ChangeAppSettings(sPath, "RunOnFirstRun", cmbRunonFirst_bssm.Text)
        Call ChangeAppSettings(sPath, "RUNPROGRAM", txtRUNPROGRAM_bssm.Text)
        Call ChangeAppSettings(sPath, "DBMAINT_ENABLED", cmbDBMAINT_ENABLED_bssm.Text)
        Call ChangeAppSettings(sPath, "DBMAINT_TIMER_INTERVAL", nudDBMAINT_TIMER_INTERVAL_bssm.Value)
        Call ChangeAppSettings(sPath, "DBMAINT_TIMER_APP", txtDBMAINT_TIMER_APP_bssm.Text)
        Call ChangeAppSettings(sPath, "DO_DAILY_ARCHIVE", cmbDO_DAILY_ARCHIVE_bssm.Text)
        Call ChangeAppSettings(sPath, "DO_MONTHLY_ARCHIVE", cmbDO_MONTHLY_ARCHIVE_bssm.Text)
        Call ChangeAppSettings(sPath, "DO_DAILY_ARCHIVE_TIME_HOUR", nudDO_DAILY_ARCHIVE_TIME_HOUR.Value)
        Call ChangeAppSettings(sPath, "DO_DAILY_ARCHIVE_TIME_MINUTE", nudDO_DAILY_ARCHIVE_TIME_MINUTE.Value)
        Call ChangeAppSettings(sPath, "DO_MONTHLY_ARCHIVE_TIME_HOUR", nudDO_MONTHLY_ARCHIVE_TIME_HOUR.Value)
        Call ChangeAppSettings(sPath, "DO_MONTHLY_ARCHIVE_TIME_MINUTE", nudDO_MONTHLY_ARCHIVE_TIME_MINUTE.Value)
        Call ChangeAppSettings(sPath, "COLHEALTH_ENABLED", cmbCOLHEALTH_ENABLED.Text)
        Call ChangeAppSettings(sPath, "COLHEALTH_APP", txtCOLHEALTH_APP.Text)
        Call ChangeAppSettings(sPath, "COLHEALTH_APP_xTimesInterval", nudCOLHEALTH_APP_xTimesInterval.Value)
        Call ChangeAppSettings(sPath, "COLLECTDATA_ENABLED", cmbCOLLECTDATA_ENABLED.Text)
        Call ChangeAppSettings(sPath, "COLLECTDATA_APP", txtCOLLECTDATA_APP.Text)
        Call ChangeAppSettings(sPath, "COLLECTDATA_APP_ARG", txtCOLLECTDATA_APP_ARG.Text)
        Call ChangeAppSettings(sPath, "COLLECTDATA_TIME_HOUR", nudCOLLECTDATA_TIME_HOUR.Value)
        Call ChangeAppSettings(sPath, "COLLECTDATA_TIME_MINUTE", nudCOLLECTDATA_TIME_MINUTE.Value)
        Call ChangeAppSettings(sPath, "PROCESSDATA_APP", txtPROCESSDATA_APP.Text)
        Call ChangeAppSettings(sPath, "PROCESSDATA_APP_ARG", txtPROCESSDATA_APP_ARG.Text)
        Call ChangeAppSettings(sPath, "PROCESSDATA_TIME_HOUR", nudPROCESSDATA_TIME_HOUR.Value)
        Call ChangeAppSettings(sPath, "PROCESSDATA_TIME_MINUTE", nudPROCESSDATA_TIME_MINUTE.Value)
        Call ChangeAppSettings(sPath, "WEBCHECK_ENABLED", cmbWebEnabled.Text)
        Call ChangeAppSettings(sPath, "WEBCHECK_INTERVAL", nudWebInterval.Value)
        Call ChangeAppSettings(sPath, "WEBCHECK_APP", txtWebApp.Text)
        Call ChangeAppSettings(sPath, "PORTCHECK_ENABLED", cmbPortCheck.Text)
        Call ChangeAppSettings(sPath, "PORTCHECK_INTERVAL", nudPortInterval.Value)
        Call ChangeAppSettings(sPath, "PORTCHECK_APP", txtPortApp.Text)
    End Sub
    Sub Save_PINGMANAGER()
        Dim sPath As String = Application.StartupPath & PINGMANAGER
        Call ChangeAppSettings(sPath, "DataCollectorID", nudDataCollectorID_pm.Value)
        Call ChangeAppSettings(sPath, "Throttle", nudThrottle_pm.Value)
        Call ChangeAppSettings(sPath, "PingXTimes", nudPingXTimes_pm.Value)
        Call ChangeAppSettings(sPath, "DataLimits", nudDataLimits_pm.Value)
        Call ChangeAppSettings(sPath, "DataPull", cmbDataPull_pm.Text)
        Call ChangeAppSettings(sPath, "XMLFILENAME", txtXMLFILENAME_pm.Text)
        Call ChangeAppSettings(sPath, "DEBUG", cmbDEBUG_pm.Text)
        Call ChangeAppSettings(sPath, "CONSOLE", cmbCONSOLE_pm.Text)
        Call ChangeAppSettings(sPath, "LOGFILE", txtLOGFILE_pm.Text)
        Call ChangeAppSettings(sPath, "BUGFILE", txtBUGFILE_pm.Text)
        Call ChangeAppSettings(sPath, "DB_SERVER", txtDB_SERVER_pm.Text)
        Call ChangeAppSettings(sPath, "DB_NAME", txtDBName.Text)
    End Sub
    Sub Save_NMAP()
        Dim sPath As String = Application.StartupPath & NMAP
        Call ChangeAppSettings(sPath, "DEBUG", cmbDEBUG_n.Text)
        Call ChangeAppSettings(sPath, "CONSOLE", cmbCONSOLE_n.Text)
        Call ChangeAppSettings(sPath, "LOGFILE", txtLOGFILE_n.Text)
        Call ChangeAppSettings(sPath, "BUGFILE", txtBUGFILE_n.Text)
        Call ChangeAppSettings(sPath, "DATAFOLDER", txtDATAFOLDER_n.Text)
        Call ChangeAppSettings(sPath, "XMLFILENAME", txtXMLFILENAME_n.Text)
        Call ChangeAppSettings(sPath, "Throttle", nudThrottle_n.Value)
        Call ChangeAppSettings(sPath, "MODE", cmbMODE_n.Text)
        Call ChangeAppSettings(sPath, "NMAP_APPNAME", txtNMAP_APPNAME_n.Text)
        Call ChangeAppSettings(sPath, "NMAP_FULL", txtNMAP_FULL_n.Text)
        Call ChangeAppSettings(sPath, "NMAP_TRACE", txtNMAP_TRACE_n.Text)
        Call ChangeAppSettings(sPath, "NMAP_PORT", txtNMAP_PORT_n.Text)
        Call ChangeAppSettings(sPath, "COLLECTIONMODE", cmbCOLLECTIONMODE_n.Text)
        Call ChangeAppSettings(sPath, "DataCollectorID", nudDataCollectorID_n.Value)
    End Sub
    Sub Save_ADDSVR()
        Dim sPath As String = Application.StartupPath & ADDSVR
        Call ChangeAppSettings(sPath, "DEBUG", cmbDEBUG_a.Text)
        Call ChangeAppSettings(sPath, "CONSOLE", cmbCONSOLE_a.Text)
        Call ChangeAppSettings(sPath, "LOGFILE", txtLOGFILE_a.Text)
        Call ChangeAppSettings(sPath, "BUGFILE", txtBUGFILE_a.Text)
        Call ChangeAppSettings(sPath, "DataCollectorID", nudDataCollectorID_a.Value)
        Call ChangeAppSettings(sPath, "SP_ADDSRV", txtSP_ADDSRV.Text)
    End Sub
    Sub Save_PORTMON()
        Dim sPath As String = Application.StartupPath & PORTMON
        Call ChangeAppSettings(sPath, "DEBUG", cmbDEBUG_p.Text)
        Call ChangeAppSettings(sPath, "CONSOLE", cmbCONSOLE_p.Text)
        Call ChangeAppSettings(sPath, "LOGFILE", txtLOGFILE_p.Text)
        Call ChangeAppSettings(sPath, "BUGFILE", txtBUGFILE_p.Text)
        Call ChangeAppSettings(sPath, "DataCollectorID", nudDataCollectorID_p.Value)
        Call ChangeAppSettings(sPath, "Throttle", nudThrottle_p.Value)
        Call ChangeAppSettings(sPath, "PingXTimes", nudPingXTimes_p.Value)
    End Sub
    Sub Save_COLHEALTH()
        Dim sPath As String = Application.StartupPath & COLHEALTH
        Call ChangeAppSettings(sPath, "DEBUG", cmbDEBUG_c.Text)
        Call ChangeAppSettings(sPath, "CONSOLE", cmbCONSOLE_c.Text)
        Call ChangeAppSettings(sPath, "LOGFILE", txtLOGFILE_c.Text)
        Call ChangeAppSettings(sPath, "BUGFILE", txtBUGFILE_c.Text)
        Call ChangeAppSettings(sPath, "DEFAULTCOLLECTOR", nudDataCollectorID_c.Value)
        Call ChangeAppSettings(sPath, "xTimesInterval", nudPingXTimes_c.Value)
    End Sub
    Sub Save_PINGER()
        Dim sPath As String = Application.StartupPath & PINGER
        Call ChangeAppSettings(sPath, "DEBUG", cmbDEBUG_pi.Text)
        Call ChangeAppSettings(sPath, "CONSOLE", cmbCONSOLE_pi.Text)
        Call ChangeAppSettings(sPath, "LOGFILE", txtLOGFILE_pi.Text)
        Call ChangeAppSettings(sPath, "BUGFILE", txtBUGFILE_pi.Text)
        Call ChangeAppSettings(sPath, "PING_TIMEOUT", nudPING_TIMEOUT_pi.Value)
        Call ChangeAppSettings(sPath, "REPEAT_EVT_HRS", nudREPEAT_EVT_HRS_pi.Value)
        Call ChangeAppSettings(sPath, "USETRACE", cmbUSETRACE_pi.Text)
    End Sub
    Sub Save_PORTSCANNER()
        Dim sPath As String = Application.StartupPath & PORTSCANNER
        Call ChangeAppSettings(sPath, "DEBUG", cmbDEBUG_po.Text)
        Call ChangeAppSettings(sPath, "CONSOLE", cmbCONSOLE_po.Text)
        Call ChangeAppSettings(sPath, "LOGFILE", txtLOGFILE_po.Text)
        Call ChangeAppSettings(sPath, "BUGFILE", txtBUGFILE_po.Text)
        Call ChangeAppSettings(sPath, "PORT_TIMEOUT", nudPort_TIMEOUT_po.Value)
    End Sub
    Sub Save_BSSMSERVICE()
        Dim sPath As String = Application.StartupPath & BSSMSERVICE
        Call ChangeAppSettings(sPath, "DEBUG", cmbDebug_service.Text)
        Call ChangeAppSettings(sPath, "DO_HEALTH_CHECK", cmbDO_HEALTH_CHECK_service.Text)
        Call ChangeAppSettings(sPath, "SHORTPATH", txtSHORTPATH_service.Text)
        Call ChangeAppSettings(sPath, "TIMER_INTERVAL", nudTimer_service.Value)
        Call ChangeAppSettings(sPath, "EVENT_SOURCE", txtEVENT_SOURCE_service.Text)
        Call ChangeAppSettings(sPath, "EVENT_LOG", txtEVENT_LOG_service.Text)
        Call ChangeAppSettings(sPath, "EVENT_ID_INFO", nudEVENT_ID_INFO_service.Value)
        Call ChangeAppSettings(sPath, "EVENT_ID_WARN", nudEVENT_ID_WARN_service.Value)
        Call ChangeAppSettings(sPath, "EVENT_ID_ERROR", nudEVENT_ID_ERROR_service.Value)
    End Sub
    Sub Save_DBMAINT()
        Dim sPath As String = Application.StartupPath & DBMAINT
        Call ChangeAppSettings(sPath, "DEBUG", cmbDEBUG_d.Text)
        Call ChangeAppSettings(sPath, "CONSOLE", cmbCONSOLE_d.Text)
        Call ChangeAppSettings(sPath, "LOGFILE", txtLOGFILE_d.Text)
        Call ChangeAppSettings(sPath, "BUGFILE", txtBUGFILE_d.Text)
        Call ChangeAppSettings(sPath, "USE_SP", cmbUSE_SP_d.Text)
        Call ChangeAppSettings(sPath, "USE_RAWDATA", cmbUSE_RAWDATA_d.Text)
        Call ChangeAppSettings(sPath, "KEEPDATA", cmbKEEPDATA.Text)
        Call ChangeAppSettings(sPath, "KEEPDATA_DAYS", nudKEEPDATA_DAYS.Value)
        Call ChangeAppSettings(sPath, "KEEPDATA_HOURS", nudKEEPDATA_HOURS.Value)
        Call ChangeAppSettings(sPath, "KEEPRAWDATA_USE", cmbKEEPRAWDATA_USE.Text)
        Call ChangeAppSettings(sPath, "KEEPRAWDATA_DAYS", nudKEEPRAWDATA_DAYS.Value)
        Call ChangeAppSettings(sPath, "KEEPRAWDATA_HOURS", nudKEEPRAWDATA_HOURS.Value)
        Call ChangeAppSettings(sPath, "SP_DELETEDATA_DAILY", txtSP_DELETEDATA_DAILY.Text)
        Call ChangeAppSettings(sPath, "SP_DELETEDATA_HOURLY", txtSP_DELETEDATA_HOURLY.Text)
        Call ChangeAppSettings(sPath, "DO_DAILY_ARCHIVE", cmbDO_DAILY_ARCHIVE.Text)
        Call ChangeAppSettings(sPath, "DO_DAILY_ARCHIVE_HOUR", nudDO_DAILY_ARCHIVE_HOUR.Value)
        Call ChangeAppSettings(sPath, "DO_DAILY_ARCHIVE_MIN", nudDO_DAILY_ARCHIVE_MIN.Value)
        Call ChangeAppSettings(sPath, "DO_DELETEMARKEDDEVICES", cmbDO_DELETEMARKEDDEVICES.Text)
        Call ChangeAppSettings(sPath, "DO_DELETEMARKEDDEVICES_DAYS", nudDO_DELETEMARKEDDEVICES_DAYS.Value)
        Call ChangeAppSettings(sPath, "MAINT_DELETE_DAILY_DAYS", nudMAINT_DELETE_DAILY_DAYS.Value)
        Call ChangeAppSettings(sPath, "MAINT_DELETE_DAILY_DAYS_EVENTS", nudMAINT_DELETE_DAILY_DAYS_EVENTS.Value)
        Call ChangeAppSettings(sPath, "MAINT_DELETE_MONTHLY_MONTHS", nudMAINT_DELETE_MONTHLY_MONTHS.Value)
        Call ChangeAppSettings(sPath, "MAINT_DELETE_YEARLYLY_YEARS", nudMAINT_DELETE_YEARLYLY_YEARS.Value)
    End Sub
#End Region
    Sub INIT()
        Dim ObjFS As New BSSM_Setup.BurnSoft.GlobalClasses.BSFileSystem
        DEBUG_LOGFILE = "settings.debug.log"
        DEBUG = False
        MyLogFile = "settings.log"
        EXISTS_BSSM = ObjFS.FileExists(Application.StartupPath & BSSM)
        EXISTS_PINGMANAGER = ObjFS.FileExists(Application.StartupPath & PINGMANAGER)
        EXISTS_NMAP = ObjFS.FileExists(Application.StartupPath & NMAP)
        EXISTS_ADDSVR = ObjFS.FileExists(Application.StartupPath & ADDSVR)
        EXISTS_PORTMON = ObjFS.FileExists(Application.StartupPath & PORTMON)
        EXISTS_COLHEALTH = ObjFS.FileExists(Application.StartupPath & COLHEALTH)
        EXISTS_PINGER = ObjFS.FileExists(Application.StartupPath & PINGER)
        EXISTS_PORTSCANNER = ObjFS.FileExists(Application.StartupPath & PORTSCANNER)
        EXISTS_BSSMSERVICE = ObjFS.FileExists(Application.StartupPath & BSSMSERVICE)
        EXISTS_DBMAINT = ObjFS.FileExists(Application.StartupPath & DBMAINT)
        ObjFS = Nothing
    End Sub
    Sub RemoveUselessTabs()
        If Not EXISTS_BSSM Then TabControl1.TabPages.Remove(TabPage1)
        If Not EXISTS_PINGMANAGER Then TabControl1.TabPages.Remove(TabPage2)
        If Not EXISTS_NMAP Then TabControl1.TabPages.Remove(TabPage3)
        If Not EXISTS_ADDSVR Then TabControl1.TabPages.Remove(TabPage4)
        If Not EXISTS_PORTMON Then TabControl1.TabPages.Remove(TabPage5)
        If Not EXISTS_COLHEALTH Then TabControl1.TabPages.Remove(TabPage6)
        If Not EXISTS_PINGER Then TabControl1.TabPages.Remove(TabPage7)
        If Not EXISTS_PORTSCANNER Then TabControl1.TabPages.Remove(TabPage8)
        If Not EXISTS_BSSMSERVICE Then TabControl1.TabPages.Remove(TabPage9)
        If Not EXISTS_DBMAINT Then TabControl1.TabPages.Remove(TabPage10)
    End Sub
    Sub LoadData()
        If EXISTS_BSSM Then Call Load_BSSM()
        If EXISTS_PINGMANAGER Then Call Load_PINGMANAGER()
        If EXISTS_NMAP Then Call Load_NMAP()
        If EXISTS_ADDSVR Then Call Load_ADDSVR()
        If EXISTS_PORTMON Then Load_PORTMON()
        If EXISTS_COLHEALTH Then Load_COLHEALTH()
        If EXISTS_PINGER Then Load_PINGER()
        If EXISTS_PORTSCANNER Then Load_PORTscanner()
        If EXISTS_BSSMSERVICE Then Load_BSSMSERVICE()
        If EXISTS_DBMAINT Then Load_DBMAINT()
    End Sub
    Sub SaveData()
        If EXISTS_BSSM Then Call Save_BSSM()
        If EXISTS_PINGMANAGER Then Call Save_PINGMANAGER()
        If EXISTS_NMAP Then Call Save_NMAP()
        If EXISTS_ADDSVR Then Call Save_ADDSVR()
        If EXISTS_PORTMON Then Save_PORTMON()
        If EXISTS_COLHEALTH Then Save_COLHEALTH()
        If EXISTS_PINGER Then Save_PINGER()
        If EXISTS_PORTSCANNER Then Save_PORTSCANNER()
        If EXISTS_BSSMSERVICE Then Save_BSSMSERVICE()
        If EXISTS_DBMAINT Then Save_DBMAINT()
        MsgBox("All Data was Saved!")
    End Sub
    Public Sub ChangeAppSettings(ByVal SPath As String, ByVal sKey As String, ByVal sValue As String)
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(SPath)
        Config.AppSettings.Settings.Remove(sKey)
        Config.AppSettings.Settings.Add(sKey, sValue)
        Config.Save(ConfigurationSaveMode.Modified)
        ConfigurationManager.RefreshSection("appSettings")
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call INIT()
        Call RemoveUselessTabs()
        Call LoadData()
    End Sub
#Region "Button Subs"
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
    Private Sub btnSaveBSSM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveBSSM.Click
        Call Save_BSSM()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call Save_PINGMANAGER()
    End Sub
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Application.Exit()
    End Sub
    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Call Save_NMAP()
    End Sub
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Application.Exit()
    End Sub
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Call Save_ADDSVR()
    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Application.Exit()
    End Sub
    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Call Save_PORTMON()
    End Sub
    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Application.Exit()
    End Sub
    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Call Save_COLHEALTH()
    End Sub
    Private Sub SaveAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveAllToolStripMenuItem.Click
        Call SaveData()
    End Sub
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Call Save_PINGER()
    End Sub
    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Application.Exit()
    End Sub
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Call Save_PORTSCANNER()
    End Sub
    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Application.Exit()
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Application.Exit()
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        Call Save_BSSMSERVICE()
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        Call Save_DBMAINT()
    End Sub

#End Region

    Public Sub SetDBServer(ByVal sServer As String, Optional ByVal UID As String = "bssm", Optional ByVal PWD As String = "bs.server.mon", Optional ByVal sDB As String = "bssm")
        Dim sConnection As String = ""
        sConnection = "Server=" & sServer & ";user id=" & UID & ";password=" & PWD & ";persist security info=True;database=" & sDB
        Dim Obj As New BSRegistry
        Obj.SaveDBSettings(sConnection)
        Obj = Nothing
    End Sub
    Public Function CollectorExists(ByVal sName As String, Optional ByRef CollectorID As Long = 0) As Boolean
        Dim bans As Boolean = False
        Dim SQL As String = "SELECT * FROM list_collectors Where ServerName='" & sName & "'"
        If ConnectDB() = 0 Then
            Dim CMD As New MySql.Data.MySqlClient.MySqlCommand(SQL, Conn)
            Dim RS As MySql.Data.MySqlClient.MySqlDataReader
            RS = CMD.ExecuteReader
            While RS.Read
                bans = True
                CollectorID = RS("ID")
            End While
            RS.Close()
            RS = Nothing
            CMD = Nothing
        End If
        Return bans
    End Function
    Function GetCollectorID_loner(ByVal sName As String) As Long
        Dim lAns As Long
        Dim SQL As String = "SELECT * FROM list_collectors Where ServerName='" & sName & "'"
        Dim Obj As New BSDatabase
        Obj.MYCONNSTRING = MyConnString
        If Obj.ConnectDB = 0 Then
            Dim CMD As New MySql.Data.MySqlClient.MySqlCommand(SQL, Obj.Conn)
            Dim RS As MySql.Data.MySqlClient.MySqlDataReader
            RS = CMD.ExecuteReader
            While RS.Read
                lAns = RS("ID")
            End While
            RS.Close()
            RS = Nothing
            CMD = Nothing
        End If
        Return lAns
    End Function
    Sub AddCollector(ByVal sName As String)
        Dim SQL As String = "INSERT INTO list_collectors (ServerName) VALUES('" & sName & "')"
        ConnExe(SQL)
    End Sub
    Public Function GetCollectorID() As Long
        Dim MyName As String = System.Environment.MachineName
        Dim lAns As Long = 0
        Dim DataCollector As Long = 0
        Dim ColExists As Boolean = CollectorExists(MyName, DataCollector)
        If ColExists And DataCollector <> 0 Then
            lAns = DataCollector
        Else
            Call AddCollector(MyName)
            lAns = GetCollectorID_loner(MyName)
        End If
        Return lans
    End Function

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        Dim sServer As String = DBServer_DS.Text
        Dim sDB As String = DBNAME_DS.Text
        If sServer.Length > 0 Then
            Call SetDBServer(sServer, , , sDB)
            Dim ObjR As New BSRegistry
            MyConnString = ObjR.GetDBSettings
            txtDB_SERVER_pm.Text = sServer
            txtDBName.Text = sDB
            If Not chkIsMaster.Checked Then
                Dim COLID As Long = GetCollectorID()
                If COLID <> 0 Then
                    nudDataCollectorID_pm.Value = COLID
                    nudDataCollectorID_n.Value = COLID
                    nudDataCollectorID_a.Value = COLID
                    nudDataCollectorID_p.Value = COLID
                    nudDataCollectorID_c.Value = COLID
                Else
                    MsgBox("There is an error while attempting to add this machine as a collector!")
                End If
                MsgBox("Database Server and Database Name was saved to the registry!")
            End If
        Else
            MsgBox("Please type in the Database Server Name!")
        End If
    End Sub
    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        Call Save_BSSM()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub
End Class
