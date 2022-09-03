<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="PartyTask.ProductEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Products.css" rel="stylesheet" />
    <script>
        function ConfirmCancel() {
            var txt = document.getElementById("<%= txtProductEdit.ClientID%>").value;

            if (txt) {
                var z = confirm("Are You Sure You don't want to Edit Record...?");
                if (z) {
                    return true;
                } else {
                    return false;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; font-size: xx-large;">
        Product Edit
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblProductEditExist" runat="server" ForeColor="#CC0000"></asp:Label>
    </p>
    <table align="center">
        <tr>
            <td>Product Name :&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:TextBox ID="txtProductEdit" runat="server" Width="195px" Height="25px" CssClass="BoxShaddow"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Product Rate :</td>
            <td>
                <asp:TextBox ID="txtProductRateEdit" runat="server" TextMode="Number" Width="195px" Height="25px" CssClass="BoxShaddow"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Date Of Rate :</td>
            <td>
                <asp:TextBox ID="txtDateOfRateEdit" runat="server" Width="195px" Height="25px" ReadOnly="True" CssClass="BoxShaddow"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: center">
                <asp:Button ID="btnUpdateProduct" runat="server" Text="Update" OnClick="btnUpdateProduct_Click" CssClass="btnSave" />
&nbsp;
                <asp:Button ID="btnCancelProduct" runat="server" Text="Cancel" OnClientClick="return ConfirmCancel();" CssClass="btnCancel" OnClick="btnCancelProduct_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
