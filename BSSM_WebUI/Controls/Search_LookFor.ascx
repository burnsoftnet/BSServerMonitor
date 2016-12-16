<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Search_LookFor.ascx.vb" Inherits="Controls_Search_LookFor" %>
<table border="0">
    <tr>
        <td style="width: 100px">
            Look For:</td>
        <td style="width: 100px">
            <asp:TextBox ID="txtLookFor" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 100px">
            In:</td>
        <td style="width: 100px">
            <asp:DropDownList ID="ddlLookIn" runat="server">
                <asp:ListItem Selected="True" Value="servername">Server Name</asp:ListItem>
                <asp:ListItem Value="IP">IP Address</asp:ListItem>
                <asp:ListItem Value="Dispay">Dispay Name</asp:ListItem>
            </asp:DropDownList></td>
    </tr>
    <tr>
        <td style="width: 100px">
        </td>
        <td style="width: 100px">
            <asp:Button ID="btnSearch" runat="server" Text="Search" /></td>
    </tr>
</table>
