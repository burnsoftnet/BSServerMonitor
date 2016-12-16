<%@ Page Language="VB" MasterPageFile="~/Master/bssm_default.Master" AutoEventWireup="false" CodeFile="search.aspx.vb" Inherits="search" title="Untitled Page" %>

<%@ Register Src="Controls/Search_LookFor.ascx" TagName="Search_LookFor" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1><%=sHeader %></h1>
<br />
<div align=center>
    <uc1:Search_LookFor ID="Search_LookFor1" runat="server" />
    &nbsp;</div>
</asp:Content>

