<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Party.aspx.cs" Inherits="PartyTask.Party" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; font-size: xx-large;">
        Party List
    </p>
    <div class="btnArea">
        <div class="btnPage">
            <asp:Button ID="btnParty" runat="server" Text="Add New Party" BackColor="#F0AD4E" BorderColor="#EEA236" ForeColor="White" PostBackUrl="~/PartyAdd.aspx" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div class="TableContent">
        <asp:GridView ID="gdParty" runat="server" AutoGenerateColumns="False" CellPadding="10" GridLines="None" Width="100%" ForeColor="#333333" OnRowCommand="gdParty_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="#" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="PartyName" HeaderText="Party Name" SortExpression="PartyName" />
                <asp:ButtonField CommandName="cmdPartyEdit" ButtonType="Button" Text="Edit" HeaderText="Action" >
                <ControlStyle BackColor="#66CCFF" BorderColor="#66FFFF" />
                </asp:ButtonField>
                <asp:ButtonField CommandName="cmdPartyDelete" ButtonType="Button" Text="Delete" >
                <ControlStyle BackColor="#FFCCCC" BorderColor="#FFCCCC" />
                </asp:ButtonField>
            </Columns>
            <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#F8F4F4" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#CCFFFF" ForeColor="#333333" Wrap="True" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString %>" SelectCommand="SELECT * FROM [Party]"></asp:SqlDataSource>--%>
        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>--%>
    </div>
</asp:Content>
