<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductRate.aspx.cs" Inherits="PartyTask.ProductRate" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/ProductRate.css" rel="stylesheet" />
    <script src="../JavaScript/JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; font-size: xx-large;">
        Current Product Rate</p>
    <div class="btnArea">
        <div class="btnPage">
            <%--<asp:Button ID="btnProductRate" runat="server" Text="Add New Product Rate" PostBackUrl="~/ProductRate/ProductRateAddEdit.aspx" CssClass="ProductRateAdd"/>--%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder2">
    <div class="TableContent">
        <asp:GridView ID="gdProductRate" runat="server" AutoGenerateColumns="False" CellPadding="10" GridLines="None" Width="100%" ForeColor="#333333" OnRowCommand="gdProductRate_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="#" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="ProductName" />
                <asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="Rate" />
                <asp:BoundField DataField="DateOfRate" HeaderText="Date Of Rate (Last Updated)" SortExpression="DateOfRate" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="30%"/>                
                <%--<asp:ButtonField CommandName="cmdProductRateEdit" ButtonType="Image" ImageUrl="~/Images/Edit.ico" Text="Edit" HeaderText="Action" >
                </asp:ButtonField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="false"  ImageUrl="~/Images/Delete.ico" Text="" OnClientClick = "Confirm()" OnClick="btnDelete_Click" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#0099CC" Font-Bold="True" ForeColor="Black" HorizontalAlign="Left" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#99CCFF" ForeColor="#333333" BorderStyle="None" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString4 %>" SelectCommand="SELECT * FROM [Product Rate]"></asp:SqlDataSource>--%>
    </div>
</asp:Content>

