<%@ Page Language="VB" MasterPageFile="~/Master/bssm_refresh.Master" AutoEventWireup="false" CodeFile="View_Servers_With_Errors.aspx.vb" Inherits="View_Servers_With_Errors" title="Untitled Page" %>

<%@ Register Src="Controls/View_Servers_ErrorsOnly.ascx" TagName="View_Servers_ErrorsOnly"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>All Devices with Errors</h1>
    
<br />
<div align="center">
   <uc1:View_Servers_ErrorsOnly ID="View_Servers_ErrorsOnly1" runat="server" />
    
    </div>
</asp:Content>

