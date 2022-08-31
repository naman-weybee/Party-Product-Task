<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductAdd.aspx.cs" Inherits="PartyTask.ProductAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; font-size: xx-large;">
        Product Add
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblProductAdd" runat="server" Text=""></asp:Label>
    </p>
    <table align="center">
        <tr>
            <td>Product Name :&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:TextBox ID="txtProductAdd" runat="server" Width="195px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldProductAdd" runat="server" ControlToValidate="txtProductAdd" ErrorMessage="* Please Enter Product Name" Font-Size="Small" ForeColor="#CC0000" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: center">
                <asp:Button ID="btnSaveProductAdd" runat="server" BackColor="#5CB85C" BorderColor="#4CAE4C" ForeColor="White" Text="Save" OnClick="btnSaveProductAdd_Click" ValidationGroup="submit" />
                &nbsp;
                <asp:Button ID="btnCancelProductAdd" runat="server" BackColor="#CCCCCC" BorderColor="#CCCCCC" ForeColor="White" Text="Cancel" PostBackUrl="~/Products.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
