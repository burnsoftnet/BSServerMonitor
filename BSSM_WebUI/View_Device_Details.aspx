<%@ Page Language="VB" MasterPageFile="~/Master/bssm_default.Master" AutoEventWireup="false" CodeFile="View_Device_Details.aspx.vb" Inherits="View_Device_Details" title="Untitled Page" %>

<%@ Register Src="Controls/View_Device_Details.ascx" TagName="View_Device_Details"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1><%= DEVICENAME %></h1>
<hr />
<br />
    <uc1:View_Device_Details ID="View_Device_Details1" runat="server" />
    <br />
    <br />
    <br />
</asp:Content>

