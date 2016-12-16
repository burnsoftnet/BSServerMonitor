<%@ Page Language="VB" MasterPageFile="~/Master/bssm_default.Master" AutoEventWireup="false" CodeFile="downloads.aspx.vb" Inherits="downloads" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Downloads</h1>
<hr />
<br />
    <div style="text-align: center" align=center>
        <table border="0" style="width: 676px">
            <tr>
                <td style="width: 100px">
                    <a href="downloads/BSSM_UI_Installer_x86_ReadOnly.msi">Read-Only GUI</a></td>
                <td align="left" style="width: 350px">
                    This is the read only GUI for the Server Monitor Software.You can view everything
                    that the admins are seeing you just can't do anything else</td>
            </tr>
            <%If Session("ISADMIN") = True Then%>
            <tr>
                <td style="width: 100px">
                    <a href="downloads/BSSM_UI_Installer_x86.msi">Admin GUI</a></td>
                <td align="left" style="width: 350px">
                    This is the full admin GUI which will allow you to administer the all the devices.</td>
            </tr>
            <tr>
                <td style="width: 100px">
                    <a href="downloads/BSSM_CollectorInstaller.msi">Collector Install</a></td>
                <td align="left" style="width: 350px">
                    This is the install package for the collectors</td>
            </tr>
            <%End If%>
            <tr>
                <td style="width: 100px">
                </td>
                <td align="left" style="width: 350px">
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

