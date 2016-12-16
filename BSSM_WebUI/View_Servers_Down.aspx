<%@ Page Language="VB" MasterPageFile="~/Master/bssm_refresh.Master" AutoEventWireup="false" CodeFile="View_Servers_Down.aspx.vb" Inherits="View_Servers_Down" title="Untitled Page" %>

<%@ Register Src="Controls/View_DownServers.ascx" TagName="View_DownServers" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>All Down Devices</h1>
<br />
<div align="center">
    <uc1:View_DownServers ID="View_DownServers1" runat="server" />
    
    </div>
</asp:Content>

