<%@ Control Language="VB" AutoEventWireup="false" CodeFile="View_Device_Details.ascx.vb" Inherits="Controls_View_Device_Details" %>
<%@ Register Assembly="BSTabControl" Namespace="BurnSoft.Controls" TagPrefix="cc1" %>
<cc1:TabControl ID="tabBar" runat="server" ContentWidth="75%" ControlImagePath="<%$ AppSettings:TABPATH %>" ControlScriptPath="<%$ AppSettings:TABPATH %>" />
<div id="divTab1" style="display:none">
<table>
        <tr>
            <td style="width: 100px">
                Server Name:</td>
            <td style="width: 179px">
                <asp:Label ID="lblDevice" runat="server" Text="Label" Width="188px"></asp:Label></td>
            <td style="width: 203px">
                Ping Tests:</td>
            <td style="width: 180px">
                <asp:CheckBox ID="chkPing" runat="server" Enabled="False" Text="Yes" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Display Name:</td>
            <td style="width: 179px">
                <asp:Label ID="lblDisplayName" runat="server" Text="Label" Width="188px"></asp:Label></td>
            <td style="width: 203px">
                Attempts:</td>
            <td style="width: 180px">
                <asp:Label ID="lblAttempts" runat="server" Text="Label" Width="188px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
                IP Address:</td>
            <td style="width: 179px">
                <asp:Label ID="lblIP" runat="server" Text="Label" Width="188px"></asp:Label></td>
            <td style="width: 203px">
                Collect Trace Data:</td>
            <td style="width: 180px">
                <asp:CheckBox ID="chkTrace" runat="server" Enabled="False" Text="Yes" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Last Status:</td>
            <td style="width: 179px">
                <asp:Label ID="lblLastStatus" runat="server" Text="Label" Width="188px"></asp:Label></td>
            <td style="width: 203px">
                Collect Port Info:</td>
            <td style="width: 180px">
                <asp:CheckBox ID="chkPort" runat="server" Enabled="False" Text="Yes" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Date Added:</td>
            <td style="width: 179px">
                <asp:Label ID="lblDateAdd" runat="server" Text="Label" Width="188px"></asp:Label></td>
            <td style="width: 203px">
                HTTP Tests:</td>
            <td style="width: 180px">
                <asp:CheckBox ID="chkHttp" runat="server" Enabled="False" Text="Yes" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Enabled:</td>
            <td style="width: 179px">
                <asp:CheckBox ID="chkEnabled" runat="server" Enabled="False" Text="Yes" /></td>
            <td style="width: 203px">
                Ignore IP Address Change:</td>
            <td style="width: 180px">
                <asp:CheckBox ID="chkIgnore" runat="server" Enabled="False" Text="Yes" /></td>
        </tr>
        <tr>
            <td style="width: 100px">
                Type:</td>
            <td style="width: 179px">
                <asp:Label ID="lblType" runat="server" Text="Label" Width="188px"></asp:Label></td>
            <td style="width: 203px">
                Collector:</td>
            <td style="width: 180px">
                <asp:Label ID="lblCollector" runat="server" Text="Label" Width="188px"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 179px">
            </td>
            <td style="width: 203px">
            </td>
            <td style="width: 180px">
            </td>
        </tr>
    </table>
</div>
<div id="divTab2" style="display:none">
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" DataSourceID="SqlDataSource1"
        ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
        <RowStyle BackColor="#EFF3FB" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="DT" HeaderText="Date &amp; Time" SortExpression="DT" />
            <asp:BoundField DataField="shrtEv" HeaderText="Description" SortExpression="shrtEv" />
            <asp:BoundField DataField="lngEv" HeaderText="Details" SortExpression="lngEv" />
            <asp:BoundField DataField="Sev" HeaderText="Severity" SortExpression="Sev" />
        </Columns>
    </asp:GridView>
    &nbsp;
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:bssmConnectionString %>"
        ProviderName="<%$ ConnectionStrings:bssmConnectionString.ProviderName %>">
    </asp:SqlDataSource>
</div>
<div id="divTab3" style="display:none">
<br />
    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="DTID" HeaderText="Date &amp; Time" SortExpression="DTID" />
            <asp:BoundField DataField="ls" HeaderText="Last Status" SortExpression="ls" />
            <asp:BoundField DataField="Packets_Sent" HeaderText="Packets Sent" SortExpression="Packets_Sent" />
            <asp:BoundField DataField="Packets_Rec" HeaderText="Packets Rec" SortExpression="Packets_Rec" />
            <asp:BoundField DataField="Packets_Lost" HeaderText="Packets Lost" SortExpression="Packets_Lost" />
            <asp:BoundField DataField="RoundTrip_Min" HeaderText="RoundTrip Min" SortExpression="RoundTrip_Min" />
            <asp:BoundField DataField="RoundTrip_Max" HeaderText="RoundTrip Max" SortExpression="RoundTrip_Max" />
            <asp:BoundField DataField="RoundTrip_Avg" HeaderText="RoundTrip Avg" SortExpression="RoundTrip_Avg" />
            <asp:BoundField DataField="uptime" HeaderText="uptime" SortExpression="uptime" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <br />
<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:bssmConnectionString %>"
        ProviderName="<%$ ConnectionStrings:bssmConnectionString.ProviderName %>">
    </asp:SqlDataSource>
<br />
</div>
<div id="divTab4" style="display:none">
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="Port" HeaderText="Port" SortExpression="Port" />
            <asp:BoundField DataField="protocol" HeaderText="protocol" SortExpression="protocol" />
            <asp:BoundField DataField="IsMonitored" HeaderText="IsMonitored" SortExpression="IsMonitored" />
            <asp:BoundField DataField="CurrentStatus" HeaderText="CurrentStatus" SortExpression="CurrentStatus" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <br />
<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:bssmConnectionString %>"
        ProviderName="<%$ ConnectionStrings:bssmConnectionString.ProviderName %>">
    </asp:SqlDataSource>
<br />
</div>
<div id="divTab5" style="display:none">
    &nbsp;<br />
    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="SqlDataSource4" ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField DataField="hopno" HeaderText="Hop Number" SortExpression="hopno" />
            <asp:BoundField DataField="ttl" HeaderText="Time To Live" SortExpression="ttl" />
            <asp:BoundField DataField="rtt" HeaderText="Round-Trip Time" SortExpression="rtt" />
            <asp:BoundField DataField="ipaddr" HeaderText="IP Address" SortExpression="ipaddr" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <br />
<asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:bssmConnectionString %>"
        ProviderName="<%$ ConnectionStrings:bssmConnectionString.ProviderName %>">
    </asp:SqlDataSource>
</div>