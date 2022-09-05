<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="PartyTask.Products" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Products.css" rel="stylesheet" />
    <script src="../JavaScript/JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; font-size: xx-large;">
        Products List
    </p>
    <div class="btnArea">
        <div class="btnPage">
            <asp:Button ID="btnProduct" runat="server" Text="Add New Product" PostBackUrl="~/Products/ProductAddEdit.aspx" CssClass="ProductsAdd" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div class="TableContent">
        <asp:GridView ID="gdProducts" runat="server" AutoGenerateColumns="False" CellPadding="10" GridLines="None" Width="100%" ForeColor="#333333" OnRowCommand="gdProducts_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="#" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                <asp:ButtonField CommandName="cmdProductEdit" ButtonType="Image" ImageUrl="~/Images/Edit.ico" HeaderText="Action"></asp:ButtonField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false" ImageUrl="~/Images/Delete.ico" Text="" OnClientClick="Confirm()" OnClick="btnDelete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#0099CC" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#99CCFF" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString2 %>" SelectCommand="SELECT * FROM [Products]"></asp:SqlDataSource>--%>
    </div>
</asp:Content>

