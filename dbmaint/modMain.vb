Imports dbmaint.BurnSoft.GlobalClasses
Imports System.Diagnostics
Imports MySql.Data.MySqlClient
Module modMain
    Public DEBUG As Boolean
    Public DEBUG_LOGFILE As String
    Public MaxDays As Long
    Public SP_DELETEDATA_DAILY As String
    Public SP_DELETEDATA_HOURLY As String
    Public KEEPRAWDATA_USE As String
    Public KEEPRAWDATA_VALUE As Long
    Public KEEPRAWDATA_SP As String
    Public DELETERESULTS As Boolean
    Public KEEPDATA As String
    Public USE_SP As Boolean
    Public USE_RAWDATA As Boolean
    Public DO_DELETEMARKEDDEVICES As Boolean
    Public DO_DELETEMARKEDDEVICES_DAYS As Integer
    Public DO_DAILY_ARCHIVE As Boolean
    Public DO_DAILY_ARCHIVE_HOUR As Integer
    Public DO_DAILY_ARCHIVE_MIN As Integer
    Public DO_DAILY_ARCHIVE_ONLY As Boolean
    Public DO_DAILY_ARCHIVE_ONLY_DAYS As Integer
    Public DO_MONTHLY_ARCHIVE_ONLY As Boolean
    Public DO_MONTHLY_ARCHIVE_ONLY_MONTHS As Integer
    Public DO_YEARLY_ARCHIVE_ONLY As Boolean
    Public DO_YEARLY_ARCHIVE_ONLY_YEARS As Integer
    Public DO_DB_CLEANUP As Boolean
    Public DO_GET_OLDEST_RAWDATE As Boolean
    Private _DO_DB_CLEANUP As Boolean

    Sub INIT()
        Try
            DO_DAILY_ARCHIVE_ONLY = False
            DO_MONTHLY_ARCHIVE_ONLY = False
            MaxDays = CLng(System.Configuration.ConfigurationManager.AppSettings("KEEPDATA_DAYS"))
            MyLogFile = System.Configuration.ConfigurationManager.AppSettings("LOGFILE")
            DEBUG_LOGFILE = System.Configuration.ConfigurationManager.AppSettings("BUGFILE")
            CONSOLEMODE = CBool(System.Configuration.ConfigurationManager.AppSettings("CONSOLE"))
            DEBUG = CBool(System.Configuration.ConfigurationManager.AppSettings("DEBUG"))
            USE_SP = CBool(System.Configuration.ConfigurationManager.AppSettings("USE_SP"))
            USE_RAWDATA = CBool(System.Configuration.ConfigurationManager.AppSettings("USE_RAWDATA"))
            SP_DELETEDATA_DAILY = System.Configuration.ConfigurationManager.AppSettings("SP_DELETEDATA_DAILY")
            SP_DELETEDATA_HOURLY = System.Configuration.ConfigurationManager.AppSettings("SP_DELETEDATA_HOURLY")
            KEEPDATA = System.Configuration.ConfigurationManager.AppSettings("KEEPDATA")
            DO_DAILY_ARCHIVE = CBool(System.Configuration.ConfigurationManager.AppSettings("DO_DAILY_ARCHIVE"))
            DO_DAILY_ARCHIVE_HOUR = System.Configuration.ConfigurationManager.AppSettings("DO_DAILY_ARCHIVE_HOUR")
            DO_DAILY_ARCHIVE_MIN = System.Configuration.ConfigurationManager.AppSettings("DO_DAILY_ARCHIVE_MIN")
            DO_DELETEMARKEDDEVICES = CBool(System.Configuration.ConfigurationManager.AppSettings("DO_DELETEMARKEDDEVICES"))
            DO_DELETEMARKEDDEVICES_DAYS = System.Configuration.ConfigurationManager.AppSettings("DO_DELETEMARKEDDEVICES_DAYS")
            Dim Obj As New BSRegistry
            MYCONNSTRING = Obj.GetDBSettings
            Call CatchDebug("Max Days: " & MaxDays, "INIT")
            KEEPRAWDATA_USE = System.Configuration.ConfigurationManager.AppSettings("KEEPRAWDATA_USE")
            Select Case LCase(KEEPRAWDATA_USE)
                Case "days"
                    KEEPRAWDATA_VALUE = CLng(System.Configuration.ConfigurationManager.AppSettings("KEEPRAWDATA_DAYS"))
                    KEEPRAWDATA_SP = "sp_mnt_rawpingdata_day"
                Case "day"
                    KEEPRAWDATA_VALUE = CLng(System.Configuration.ConfigurationManager.AppSettings("KEEPRAWDATA_DAYS"))
                    KEEPRAWDATA_SP = "sp_mnt_rawpingdata_day"
                Case "hours"
                    KEEPRAWDATA_VALUE = CLng(System.Configuration.ConfigurationManager.AppSettings("KEEPRAWDATA_HOURS"))
                    KEEPRAWDATA_SP = "sp_mnt_rawpingdata_hrs"
                Case "hour"
                    KEEPRAWDATA_VALUE = CLng(System.Configuration.ConfigurationManager.AppSettings("KEEPRAWDATA_HOURS"))
                    KEEPRAWDATA_SP = "sp_mnt_rawpingdata_hrs"
                Case Else
                    KEEPRAWDATA_VALUE = CLng(System.Configuration.ConfigurationManager.AppSettings("KEEPRAWDATA_HOURS"))
                    KEEPRAWDATA_SP = "sp_mnt_rawpingdata_hrs"
            End Select

            Dim DidExist As Boolean
            DELETERESULTS = CBool(GetCommand("deleteresults", "bool", DidExist))
            DO_DAILY_ARCHIVE_ONLY_DAYS = CInt(GetCommand("archday", "int", DO_DAILY_ARCHIVE_ONLY))
            DO_MONTHLY_ARCHIVE_ONLY_MONTHS = CInt(GetCommand("archmonth", "int", DO_MONTHLY_ARCHIVE_ONLY))
            DO_YEARLY_ARCHIVE_ONLY_YEARS = CInt(GetCommand("archyear", "int", DO_YEARLY_ARCHIVE_ONLY))

            _DO_DB_CLEANUP = CBool(GetCommand("cleandb", "bool", DO_DB_CLEANUP))
            Dim _Get_Old_Date As Boolean = CBool(GetCommand("getoldraw", "bool", DO_GET_OLDEST_RAWDATE))


            'If DidExist Then DO_DAILY_ARCHIVE_ONLY = True
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "INIT"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
    End Sub
    Sub GetOldestRawDate()
        If ConnectDB() = 0 Then
            Dim SQL As String = "select rts.sid, rts.dtid from results_timestamp rts inner join results_ping_raw rpr on rpr.tsid=rts.id order by dtid asc limit 0,1;"
            Dim CMD As New MySqlCommand(SQL, Conn)
            Dim RS As MySqlDataReader
            RS = CMD.ExecuteReader
            While RS.Read
                Console.Write(RS("dtid"))
            End While
            RS.Close()
            RS = Nothing
            CMD = Nothing
        End If
        Call CloseDB()
    End Sub
    Function LastOldPingID(ByVal iValue As Long, ByVal sDOW As String) As Long
        Dim iAns As Long = 0
        Try
            Dim SQL As String = ""
            Select Case LCase(sDOW)
                Case "day"
                    SQL = "SELECT ID from results_timestamp where DTID > adddate(CURRENT_TIMESTAMP, INTERVAL -" & iValue & " DAY) Order by DTID ASC limit 0,1;"
                Case "days"
                    SQL = "SELECT ID from results_timestamp where DTID > adddate(CURRENT_TIMESTAMP, INTERVAL -" & iValue & " DAY) Order by DTID ASC limit 0,1;"
                Case "hour"
                    SQL = "SELECT ID from results_timestamp where DTID > adddate(CURRENT_TIMESTAMP, INTERVAL -" & iValue & " HOUR) Order by DTID ASC limit 0,1;"
                Case "hours"
                    SQL = "SELECT ID from results_timestamp where DTID > adddate(CURRENT_TIMESTAMP, INTERVAL -" & iValue & " HOUR) Order by DTID ASC limit 0,1;"
                Case Else
                    SQL = "SELECT ID from results_timestamp where DTID > adddate(CURRENT_TIMESTAMP, INTERVAL -" & iValue & " HOUR) Order by DTID ASC limit 0,1;"
            End Select
            If ConnectDB() = 0 Then
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    iAns = RS("ID")
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Call CloseDB()
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "LastOldPingID"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
            Console.WriteLine(sMsg)
        End Try
        Return iAns
    End Function
    Sub DeleteRawPings()
        Dim RegID As Long = LastOldPingID(KEEPRAWDATA_VALUE, KEEPRAWDATA_USE)
        Dim SQL As String = "Delete from results_ping_raw where TSID < " & RegID
        Call CatchDebug(SQL, "DeleteRawPings")
        ConnExe(SQL)
    End Sub
    Sub DeletePingResults()
        Dim RegID As Long = LastOldPingID(MaxDays, "day")
        Dim SQL As String = "Delete from results_ping_stats where TSID < " & RegID
        Call CatchDebug(SQL, "DeletePingResults")
        ConnExe(SQL)
    End Sub
    Sub DeletePingResultsTimeStamp()
        Dim RegID As Long = LastOldPingID(MaxDays, "day")
        Dim SQL As String = "Delete from results_timestamp where ID < " & RegID
        Call CatchDebug(SQL, "DeletePingResultsTimeStamp")
        ConnExe(SQL)
    End Sub
    Sub TrimRawData()
        Call DeletePingResults()
        Call DeleteRawPings()
        Console.WriteLine("Raw data was trimed down!")
        Call DeletePingResultsTimeStamp()
        Console.WriteLine(MaxDays & " days of data was deleted from the database")

    End Sub
    Sub TrimData()
        Dim SQL As String = ""
        Select Case UCase(KEEPDATA)
            Case "DAYS"
                Console.WriteLine("Running Stored Procedure to Trim the Data back " & MaxDays & " days")
                SQL = "call " & SP_DELETEDATA_DAILY & "(" & MaxDays & ");"
                Call CatchDebug(SQL, "TrimData")
                ConnExe(SQL)
            Case "HOURS"
                Console.WriteLine("Running Stored Procedure to Trim the Data back " & MaxDays & " hours")
                SQL = "call " & SP_DELETEDATA_HOURLY & "(" & MaxDays & ");"
                Call CatchDebug(SQL, "TrimData")
                ConnExe(SQL)
            Case Else
                Console.WriteLine("Option is currently Set to Disabled.")
        End Select
    End Sub
    Sub RunSP()
        Try
            Dim SQL As String = "" '"call " & SP_DELETEDATA & "(" & MaxDays & ");"
            If Not DELETERESULTS Then
                Call CatchDebug(SQL, "RunSP Calling TrimRaw data and Trim Data")
                If USE_RAWDATA Then Call TrimRawData()
                If USE_SP Then Call TrimData()
            Else
                'SQL = "delete from results_ping_raw"
                SQL = "truncate results_ping_raw"
                ConnExe(SQL)
                SQL = "truncate results_ping_stats"
                ConnExe(SQL)
                SQL = "truncate results_timestamp"
                ConnExe(SQL)
                Console.WriteLine("Raw data was Deleted!")
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "INIT"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
            Console.WriteLine(sMsg)
        End Try
    End Sub
    Sub Main()
        Dim returnValue As Process() = Process.GetProcessesByName("dbmaint")
        Dim REQUESTARCHIVE As Boolean = False
        'Call RunYEarlyArchive(1, True)
        If returnValue.Length <= 1 Then
            Call INIT()
            If Not DO_GET_OLDEST_RAWDATE Then
                Console.WriteLine("Starting Database Maintenance.")
                If DO_DELETEMARKEDDEVICES Then RunDeletedDeviceCleanup(DO_DELETEMARKEDDEVICES_DAYS)
                If DO_DAILY_ARCHIVE_ONLY Then
                    REQUESTARCHIVE = True
                ElseIf DO_MONTHLY_ARCHIVE_ONLY Then
                    REQUESTARCHIVE = True
                ElseIf DO_YEARLY_ARCHIVE_ONLY Then
                    REQUESTARCHIVE = True
                Else
                    REQUESTARCHIVE = False
                End If
                'If Not DO_DAILY_ARCHIVE_ONLY Then Call RunSP()
                If Not REQUESTARCHIVE Then Call RunSP()
                If DO_DAILY_ARCHIVE_ONLY Then
                    Call RunDailyArchive(DO_DAILY_ARCHIVE_ONLY_DAYS, True)
                    End
                End If
                If DO_MONTHLY_ARCHIVE_ONLY Then
                    Call RunMonthlyArchive(DO_MONTHLY_ARCHIVE_ONLY_MONTHS, True)
                    End
                End If
                If DO_YEARLY_ARCHIVE_ONLY Then
                    Call RunYEarlyArchive(DO_YEARLY_ARCHIVE_ONLY_YEARS, True)
                    End
                End If
                If DO_DAILY_ARCHIVE Then Call RunDailyArchive(1)
                If DO_DB_CLEANUP Then Call Run_DBCleanup()
            Else
                Call GetOldestRawDate()
            End If
        Else
            Console.WriteLine("There is another instance of this application already running!")
        End If
    End Sub
    Sub RunDailyArchive(ByVal iDays As Integer, Optional ByVal DoOverRide As Boolean = False)
        Call CatchDebug("Starting Daily Archive", "RunDailyArchive")
        Try
            If IsDateTime("DO_DAILY_ARCHIVE") Or DoOverRide Then

                Dim MyStartDate As Date = DateAdd(DateInterval.Day, -iDays, Now)
                Dim MyEndDate As String = DateAdd(DateInterval.Day, iDays, MyStartDate)
                Dim sDate As String = Year(MyStartDate) & "-" & _
                                      Month(MyStartDate) & "-" & _
                                      Day(MyStartDate)
                Dim eDate As String = Year(MyEndDate) & "-" & Month(MyEndDate) & "-" & Day(MyEndDate)
                Dim SQL As String = "SELECT SID, AVG(ls) as dAVG from results_timestamp where DTID > '" & _
                                    sDate & "' and DTID < '" & eDate & "' GROUP BY SID"
                Dim SID As Long = 0
                Dim dUptime As Double = 0
                Dim MySQL As String = ""
                If ConnectDB() = 0 Then
                    Dim CMD As New MySqlCommand(SQL, Conn)
                    Dim RS As MySqlDataReader
                    RS = CMD.ExecuteReader
                    While RS.Read
                        SID = RS("sid")
                        dUptime = RS("davg") * 100
                        MySQL = "INSERT INTO uptime_stats_daily (DT,SID,uptime) VALUES('" & sDate & "'," & _
                                SID & "," & dUptime & ")"
                        Call CatchDebug("MySQL=" & MySQL, "RunDailyArchive")
                        ConnExe(MySQL)
                    End While
                    RS.Close()
                    RS = Nothing
                    CMD = Nothing
                    Conn.Close()
                    Conn = Nothing
                End If
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "RunDailyArchive"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Call CatchDebug("Ending Daily Archive", "RunDailyArchive")
    End Sub
    Sub RunMonthlyArchive(ByVal iMonth As Integer, Optional ByVal DoOverRide As Boolean = False)
        Call CatchDebug("Starting Monthly Archive", "RunDailyArchive")
        Try
            Dim WorkingMonthDate As Date = DateAdd(DateInterval.Month, -iMonth, Now)
            Dim WorkingMonthInt As Integer = CInt(Month(WorkingMonthDate))
            Dim WorkingMonthYearInt As Integer = CInt(Year(WorkingMonthDate))
            Dim WorkingDaysinMonth As Integer = Date.DaysInMonth(WorkingMonthYearInt, WorkingMonthInt)
            Dim sDate As String = Year(WorkingMonthDate) & "-" & Month(WorkingMonthDate) & _
                                    "-1"
            Dim eDate As String = Year(WorkingMonthDate) & "-" & Month(WorkingMonthDate) & _
                                    "-" & WorkingDaysinMonth
            Dim SQL As String = "SELECT SID, AVG(uptime) as mAVG from uptime_stats_daily where DT > '" & _
                                sDate & "' and DT < '" & eDate & "' GROUP BY SID"
            Dim SID As Long = 0
            Dim dUptime As Double = 0
            Dim MySQL As String = ""
            If ConnectDB() = 0 Then
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    SID = RS("sid")
                    dUptime = RS("mavg") '* 100
                    MySQL = "INSERT INTO uptime_stats_monthly (DT,SID,uptime) VALUES('" & sDate & "'," & _
                            SID & "," & dUptime & ")"
                    Call CatchDebug("MySQL=" & MySQL, "RunMonthlyArchive")
                    ConnExe(MySQL)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
            Call RunMonthlyArchiveGeneral(WorkingMonthInt, WorkingMonthYearInt, sDate, eDate)
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "RunMonthlyArchive"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Call CatchDebug("Ending Monthly Archive", "RunDailyArchive")
    End Sub
    Sub RunYEarlyArchive(ByVal iYear As Integer, Optional ByVal DoOverRide As Boolean = False)
        Call CatchDebug("Starting Yearly Archive", "RunYearlyArchive")
        Try
            Dim WorkingyearDate As Date = DateAdd(DateInterval.Year, -iYear, Now)
            Dim WorkingMonthInt As Integer = CInt(Month(WorkingyearDate))
            'Dim WorkingMonthYearInt As Integer = CInt(Year(WorkingyearDate))
            'Dim WorkingDaysinMonth As Integer = Date.DaysInMonth(WorkingMonthYearInt, WorkingMonthInt)
            Dim ydate As String = Year(WorkingyearDate)
            Dim sDate As String = Year(WorkingyearDate) & "-1-1"
            Dim eDate As String = Year(WorkingyearDate) & "-12-31"
            Dim SQL As String = "SELECT SID, AVG(uptime) as mAVG from uptime_stats_monthly where DT > '" & _
                                sDate & "' and DT < '" & eDate & "' GROUP BY SID"
            Dim SID As Long = 0
            Dim dUptime As Double = 0
            Dim MySQL As String = ""
            If ConnectDB() = 0 Then
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                RS = CMD.ExecuteReader
                While RS.Read
                    SID = RS("sid")
                    dUptime = RS("mavg") '* 100
                    MySQL = "INSERT INTO uptime_stats_yearly (myyear,SID,uptime) VALUES('" & ydate & "'," & _
                            SID & "," & dUptime & ")"
                    Call CatchDebug("MySQL=" & MySQL, "RunYearlyArchive")
                    ConnExe(MySQL)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
            'Call RunMonthlyArchiveGeneral(WorkingMonthInt, WorkingMonthYearInt, sDate, eDate)
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "RunYearlyArchive"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Call CatchDebug("Ending Yearlyly Archive", "RunYearlyArchive")
    End Sub
    Sub RunMonthlyArchiveGeneral(ByVal iMonth As Integer, ByVal iYear As Integer, ByVal sDate As String, ByVal eDate As String)
        Call CatchDebug("Starting Monthly Archive", "RunDailyArchive")
        Try
            Dim SQL As String = "SELECT AVG(uptime) as mAVG from uptime_stats_daily where DT > '" & _
                                sDate & "' and DT < '" & eDate & "'"
            Dim MySQL As String = ""
            If ConnectDB() = 0 Then
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                Dim dUptime As Double = 0
                'Dim dDownTime As Double = 100 - dUptime
                RS = CMD.ExecuteReader
                While RS.Read
                    dUptime = RS("mavg") '* 100
                    MySQL = "INSERT INTO uptime_stats_monthly_general (dt_m,dt_y,t_uptime) VALUES('" & iMonth & "','" & _
                            iYear & "'," & dUptime & ")"
                    Call CatchDebug("MySQL=" & MySQL, "RunMonthlyArchiveGeneral")
                    ConnExe(MySQL)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "RunMonthlyArchiveGeneral"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Call CatchDebug("Ending Monthly Archive Overall", "RunDailyArchiveGeneral")
    End Sub
    Function FDT(ByVal sValue As String) As String
        Dim sAns As String = sValue
        If Len(sValue) = 1 Then sAns = "0" & sValue
        Return sValue
    End Function
    Sub RunDeletedDeviceCleanup(ByVal iDays As Integer)
        Call CatchDebug("Starting Removal", "RunDeletedDeviceCleanup")
        Try
            Dim sDate As Date = DateAdd(DateInterval.Day, -iDays, Date.Now)
            Dim SQLDate As String = sDate.Year & "-" & FDT(sDate.Month) & "-" & FDT(sDate.Day)
            Dim SQL As String = "SELECT SID from events_general where shrtEv like '%Deleted%' and dt < '" & SQLDate & "'"
            Dim MySQL As String = ""
            If ConnectDB() = 0 Then
                Dim CMD As New MySqlCommand(SQL, Conn)
                Dim RS As MySqlDataReader
                Dim dUptime As Double = 0
                RS = CMD.ExecuteReader
                Dim SID As Long = 0
                While RS.Read
                    SID = RS("SID")
                    MySQL = "call sp_server_delete(" & SID & ")"
                    Call CatchDebug("MySQL=" & MySQL, "RunDeletedDeviceCleanup")
                    ConnExe(MySQL)
                End While
                RS.Close()
                RS = Nothing
                CMD = Nothing
                Conn.Close()
                Conn = Nothing
            End If
        Catch ex As Exception
            Dim strForm As String = "modMain"
            Dim strSubFunc As String = "RunDeletedDeviceCleanup"
            Dim sMsg As String = " - ERROR - " & Err.Number & " - " & ex.Message.ToString
            Call CatchError(sMsg, strForm & "." & strSubFunc)
        End Try
        Call CatchDebug("Ending Device Removal", "RunDeletedDeviceCleanup")
    End Sub
    Sub Run_DBCleanup()
        Dim DaysBack As Long = CLng(System.Configuration.ConfigurationManager.AppSettings("MAINT_DELETE_DAILY_DAYS"))
        Dim EventsDaysBack As Long = CLng(System.Configuration.ConfigurationManager.AppSettings("MAINT_DELETE_DAILY_DAYS_EVENTS"))
        Dim MonthsBack As Long = CLng(System.Configuration.ConfigurationManager.AppSettings("MAINT_DELETE_MONTHLY_MONTHS"))
        Dim YearsBack As Long = CLng(System.Configuration.ConfigurationManager.AppSettings("MAINT_DELETE_YEARLYLY_YEARS"))
        Dim Obj As New BSDatabase
        Dim SQL As String = "DELETE from uptime_stats_daily where dt < adddate(CURRENT_TIMESTAMP,INTERVAL -" & DaysBack & "DAY)"
        Obj.ConnExe(SQL)
        SQL = "DELETE from uptime_stats_monthly where dt < adddate(CURRENT_TIMESTAMP, INTERVAL -" & MonthsBack & " MONTH)"
        Obj.ConnExe(SQL)
        'no enough data to do this one yet
        'sql = "DELETE from uptime_stats_yearly"
        SQL = "DELETE from events_general where dt < adddate(CURRENT_TIMESTAMP,INTERVAL -" & EventsDaysBack & "DAY)"
        Obj.ConnExe(SQL)
    End Sub
End Module
