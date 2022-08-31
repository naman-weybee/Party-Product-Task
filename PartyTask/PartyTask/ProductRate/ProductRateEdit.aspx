<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductRateEdit.aspx.cs" Inherits="PartyTask.ProductRateEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/ProductRate.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
    <script>
        function ConfirmCancel() {
            var ddlParty = document.getElementById("<%= ddlProductNameEdit.ClientID%>");
            var x = ddlParty.options[ddlParty.selectedIndex].value;
            var txt = document.getElementById("<%= txtProductRateEdit.ClientID%>").value;
            var date = document.getElementById("<%= txtDateOfRateEdit.ClientID%>").value;

            if (x || txt || date) {
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
        Product Rate Edit
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblProductRateEditExist" runat="server" ForeColor="#CC0000"></asp:Label>
    </p>
    <table align="center">
        <tr>
            <td>Product Name :</td>
            <td>
                <asp:DropDownList ID="ddlProductNameEdit" runat="server" Width="200px" Height="30px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Product Rate :</td>
            <td>
                <asp:TextBox ID="txtProductRateEdit" runat="server" TextMode="Number" Width="195px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Date Of Rate :</td>
            <td>
                <asp:TextBox ID="txtDateOfRateEdit" runat="server" Width="195px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnUpdateProductRateEdit" runat="server" Text="Update" OnClick="btnUpdateProductRateEdit_Click" CssClass="btnSave" />
                &nbsp;&nbsp;
                <asp:Button ID="btnCancelProductRateEdit" runat="server" Text="Cancel" OnClientClick="return ConfirmCancel();" CssClass="btnCancel" OnClick="btnCancelProductRateEdit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
