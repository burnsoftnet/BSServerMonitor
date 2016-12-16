<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="View_Servers_ErrorsOnly.ascx.vb" Inherits="BSSM_WebUI.View_Servers_ErrorsOnly" %>
<div style="text-align:center">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1"
        ForeColor="#333333" GridLines="None" PageSize="100">
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"
                Visible="False" />
            <asp:BoundField DataField="CS" HeaderText="Status" HtmlEncode="False" SortExpression="CS" />
            <asp:BoundField DataField="CSText" HeaderText="Details" HtmlEncode="False" SortExpression="CSText" />
            <asp:BoundField DataField="ServerName" HeaderText="Server Name" HtmlEncode="False"
                SortExpression="ServerName" />
            <asp:BoundField DataField="DisplayName" HeaderText="Display Name" SortExpression="DisplayName" />
            <asp:BoundField DataField="Cat" HeaderText="Type" SortExpression="Cat" />
            <asp:BoundField DataField="ServerIPAddress" HeaderText="IP Address" SortExpression="ServerIPAddress" />
        </Columns>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bssmConnectionString %>"
        ProviderName="<%$ ConnectionStrings:bssmConnectionString.ProviderName %>" SelectCommand="SELECT * FROM web_view_servers_errorsonly">
    </asp:SqlDataSource>

</div>