<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="PartyTask.Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; font-size: xx-large;">
        Invoice Add
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblInvoiceAddSuccess" runat="server" Text=""></asp:Label>
    </p>
    <table align="center">
        <tr>
            <td>
                <h4>Party Name :</h4>
            </td>
            <td>&nbsp;
                <asp:DropDownList ID="ddlInvoicePartyName" runat="server" Width="200px" Height="30px" AutoPostBack="true" OnSelectedIndexChanged="ddlInvoicePartyName_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldInvoicePartyName" runat="server" ControlToValidate="ddlInvoicePartyName" ErrorMessage="* Please Select Party Name" Font-Size="Small" ForeColor="#CC0000" InitialValue="-1" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <h4>Product Name :</h4>
            </td>
            <td>&nbsp;
                <asp:DropDownList ID="ddlInvoiceProductName" runat="server" Width="200px" Height="30px" AutoPostBack="true" OnSelectedIndexChanged="ddlInvoiceProductName_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldInvoiceProductName" runat="server" ControlToValidate="ddlInvoiceProductName" ErrorMessage="* Please Select Product Name" Font-Size="Small" ForeColor="#CC0000" InitialValue="-1" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <h4>Current Rate :</h4>
            </td>
            <td>&nbsp;
                <asp:TextBox ID="txtCurrentRate" runat="server" Width="195px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldInvoiceCurrentRate" runat="server" ControlToValidate="txtCurrentRate" ErrorMessage="* Please Enter Rate" Font-Size="Small" ForeColor="#CC0000" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <h4>Quantity :</h4>
            </td>
            <td>&nbsp;
                <asp:TextBox ID="txtQuantity" runat="server" Width="195px" Height="25px" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldInvoiceQuantity" runat="server" ControlToValidate="txtQuantity" ErrorMessage="* Please Enter Quantity" Font-Size="Small" ForeColor="#CC0000" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: center">
                <asp:Button ID="btnAddToInvoice" runat="server" BackColor="#5CB85C" BorderColor="#4CAE4C" Text="Add To Invoice" OnClick="btnAddToInvoice_Click" ValidationGroup="submit" />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <div class="TableContent">
        <asp:GridView ID="gdInvoice" runat="server" AutoGenerateColumns="False" DataKeyNames="id" Width="100%"  CellPadding="4" GridLines="None" ForeColor="#333333">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="#" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="PartyName" HeaderText="Party" SortExpression="PartyName" />
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="ProductName" />
                <asp:BoundField DataField="RateOfProduct" HeaderText="Rate Of Product" SortExpression="RateOfProduct" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle HorizontalAlign="Left" BackColor="#F8F4F4" Font-Bold="True" ForeColor="Black" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#CCFFFF" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PartyProductConnectionString6 %>" SelectCommand="SELECT * FROM [Invoice]"></asp:SqlDataSource>--%>
    </div>
    <br />
    <br />
    <div class="total">
        <b>Grand Total : </b>
        <asp:Label ID="lblGrandTotal" runat="server" Text=""></asp:Label>
    </div>
    <br />
    <div class="closeinvoice">
        <asp:Button ID="btnClearInvoice" runat="server" BackColor="#D9534F" BorderColor="#D43F3A" OnClick="btnClearInvoice_Click" Text="Clear Invoice" />
        <asp:Button ID="btnCloseInvoice" runat="server" Text="Close Invoice" BackColor="#D9534F" BorderColor="#D43F3A" OnClick="btnCloseInvoice_Click" />
    </div>
</asp:Content>
