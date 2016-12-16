<%@ Page Language="VB" MasterPageFile="~/Master/bssm_default.Master" AutoEventWireup="false" CodeFile="search_results.aspx.vb" Inherits="search_results" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1><%=sheader %></h1>
<hr />
<br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="ServerName" HeaderText="Server Name" SortExpression="ServerName" HtmlEncode="false" />
            <asp:BoundField DataField="ServerIPAddress" HeaderText=" IP Address" SortExpression="ServerIPAddress" HtmlEncode="false" />
            <asp:BoundField DataField="DisplayName" HeaderText="Display Name" SortExpression="DisplayName" HtmlEncode="false" />
            <asp:BoundField DataField="CS" HeaderText="Current Status" SortExpression="CS" HtmlEncode="false" />
            <asp:BoundField DataField="cat" HeaderText="Device Type" SortExpression="cat" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
<br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bssmConnectionString %>"
        ProviderName="<%$ ConnectionStrings:bssmConnectionString.ProviderName %>">
    </asp:SqlDataSource>

</asp:Content>

