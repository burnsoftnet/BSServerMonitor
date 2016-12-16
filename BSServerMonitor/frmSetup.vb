Imports BSServerMonitor.BurnSoft.GlobalClasses
Imports system.IO
Imports System.Configuration
Imports System.Xml
Public Class frmSetup
    Public Function GetXMLNode(ByVal instance As XmlNode) As String
        'NOTE:This will Get the Values that are stored in the XML Note.
        Dim MyAns As String = ""
        On Error Resume Next
        MyAns = instance.InnerText
        Return MyAns
    End Function
    Sub DoServerSetup(ByVal sConn As String, ByVal XMLSQL As String)
        Dim doc As New XmlDocument
        Dim Obj As New BSDatabase
        Dim i As Integer = 0
        Dim SQL As String = ""
        doc.Load(XMLSQL)
        Obj.MYCONNSTRING = sConn
        Dim elemList As XmlNodeList = doc.GetElementsByTagName("db")
        For i = 0 To elemList.Count - 1
            SQL = GetXMLNode(elemList(i).Item("sql"))
            Obj.ConnExe(SQL)
        Next
        elemList = Nothing
        doc = Nothing
    End Sub
    Sub ChangeConnSettings(ByVal sKey As String, ByVal sValue As String)
        Dim Config As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Config.ConnectionStrings.ConnectionStrings.Remove(sKey)
        Dim ConfigString As New System.Configuration.ConnectionStringSettings
        ConfigString.Name = sKey
        ConfigString.ConnectionString = sValue
        ConfigString.ProviderName = "MySql.Data.MySqlClient"
        Config.ConnectionStrings.ConnectionStrings.Add(ConfigString)
        Config.Save(ConfigurationSaveMode.Modified)
        ConfigurationManager.RefreshSection("connectionStrings")
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Obj As New BSRegistry
        Dim sServer As String = txtServer.Text
        Dim sUID As String = txtUID.Text
        Dim sPWD As String = txtPWD.Text
        Dim sDb As String = txtDB.Text
        Dim sConnection As String = ""
        Dim sConnectionAdmin As String = ""
        Dim ObjDB As New BSDatabase
        Dim UID As String = System.Configuration.ConfigurationManager.AppSettings("UID")
        Dim PWD As String = System.Configuration.ConfigurationManager.AppSettings("PWD")
        Dim XMLSQL As String = ""
        sConnection = "Server=" & txtServer.Text & ";user id=" & UID & ";password=" & PWD & ";persist security info=True;database=" & txtDB.Text
        sConnectionAdmin = "Server=" & txtServer.Text & ";user id=" & txtUID.Text & ";password=" & txtPWD.Text & ";persist security info=True;database=" & txtDB.Text
        XMLSQL = "dbsetup.xml"
        Call ChangeConnSettings("BSServerMonitor.My.MySettings.bssmConnectionString", sConnection)
        ObjDB.MYCONNSTRING = Replace(sConnectionAdmin, ";database=" & txtDB.Text, "")
        If ObjDB.ConnectDB = 0 Then
            If chkNew.Checked Then
                ObjDB.ConnExe("CREATE USER '" & UID & "'@'%' IDENTIFIED BY '" & PWD & "'")
                ObjDB.ConnExe("create database if not exists `" & txtDB.Text & "`")
                ObjDB.ConnExe("GRANT ALL ON *.* TO '" & UID & "'@'%'")
                ObjDB.ConnExe("GRANT ALL ON " & txtDB.Text & ".* TO '" & UID & "'@'%'")
                Call DoServerSetup(sConnection, XMLSQL)
            End If
            Obj.SaveDBSettings(sConnection)
            Obj = Nothing
            ObjDB = Nothing
            Call RunUI()
        Else
            MsgBox("Problem Connecting to the database!" & Chr(13) & "Please check your settings and try again")
        End If
    End Sub
    Sub RunUI()
        frmMain.Show()
        Me.Close()
    End Sub
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Obj As New BSRegistry
        MyLogFile = Application.StartupPath & "\" & System.Configuration.ConfigurationManager.AppSettings("ERRFILE")
        Obj.UpDateAppDetails()
        If Len(Obj.GetDBSettings) = 0 Then
            Me.Show()
        Else
            Call RunUI()
            Me.Close()
        End If
    End Sub

    Private Sub chkNew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNew.CheckedChanged
        If Not chkNew.Checked Then
            txtUID.Text = System.Configuration.ConfigurationManager.AppSettings("UID")
            txtPWD.Text = System.Configuration.ConfigurationManager.AppSettings("PWD")
            txtUID.Enabled = False
            txtPWD.Enabled = False
        Else
            txtUID.Enabled = True
            txtPWD.Enabled = True
            txtUID.Text = "root"
            txtPWD.Text = ""
        End If
    End Sub
End Class
