<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductAddEdit.aspx.cs" Inherits="PartyTask.ProductAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Products.css" rel="stylesheet" />
    <script>
        function ConfirmCancel() {
            var txt = document.getElementById("<%= txtProductAdd.ClientID%>").value;

            if (txt != "") {
                var z = confirm("Are You Sure You don't want to Add Record...?");
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
        Product Add
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblProductAdd" runat="server" Text=""></asp:Label>
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblProductAddExist" runat="server" ForeColor="#CC0000"></asp:Label>
    </p>
    <table align="center">
        <tr>
            <td>Product Name :&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:TextBox ID="txtProductAdd" runat="server" Width="195px" Height="25px" CssClass="BoxShaddow"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldProductAdd" runat="server" ControlToValidate="txtProductAdd" ErrorMessage="* Please Enter Product Name" Font-Size="Small" ForeColor="#CC0000" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Product Rate :</td>
            <td>
                <asp:TextBox ID="txtProductRateAdd" runat="server" TextMode="Number" Width="195px" Height="25px" CssClass="BoxShaddow"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldProductRateProductRate" runat="server" ControlToValidate="txtProductRateAdd" ErrorMessage="* Please Enter Product Rate" Font-Size="Small" ForeColor="#CC0000" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Date Of Rate :</td>
            <td>
                <asp:TextBox ID="txtDateOfRateAdd" runat="server" Width="195px" Height="25px" ReadOnly="True" CssClass="BoxShaddow"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldProductRateDateOfRate" runat="server" ControlToValidate="txtDateOfRateAdd" ErrorMessage="* Please Select Date Of Rate" Font-Size="Small" ForeColor="#CC0000" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSaveProductAdd" runat="server" Text="Save" OnClick="btnSaveProductAdd_Click" ValidationGroup="submit" CssClass="btnSave" />
                &nbsp;
                <asp:Button ID="btnCancelProductAdd" runat="server" Text="Cancel" OnClientClick="return ConfirmCancel();" CssClass="btnCancel" OnClick="btnCancelProductAdd_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
