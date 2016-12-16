<%@ Page Language="VB" MasterPageFile="~/Master/bssm_default.Master" AutoEventWireup="false" CodeFile="View_Servers_All.aspx.vb" Inherits="View_Servers_All" title="Untitled Page" %>

<%@ Register Src="Controls/View_AllServers.ascx" TagName="View_AllServers" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>All Devices</h1>
<br />
<div align="center">
    <uc1:View_AllServers ID="View_AllServers1" runat="server" />
    </div>
</asp:Content>

