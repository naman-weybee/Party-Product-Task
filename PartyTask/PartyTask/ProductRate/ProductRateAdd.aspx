<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductRateAdd.aspx.cs" Inherits="PartyTask.ProductRateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/ProductRate.css" rel="stylesheet" />
    <script>
        function ConfirmCancel() {
            var ddlParty = document.getElementById("<%= ddlProductNameAdd.ClientID%>");
            var x = ddlParty.options[ddlParty.selectedIndex].value;
            var txt = document.getElementById("<%= txtProductRateAdd.ClientID%>").value;
            var date = document.getElementById("<%= txtDateOfRateAdd.ClientID%>").value;

            if (x != "-1" || txt || date ) {
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
        Product Rate Add
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblProductRateAddSuccess" runat="server" Text=""></asp:Label>
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblProductRateExist" runat="server" ForeColor="#CC0000"></asp:Label>
    </p>
    <table align="center">
        <tr>
            <td>Product Name :</td>
            <td>&nbsp;
                <asp:DropDownList ID="ddlProductNameAdd" runat="server" Width="200px" Height="30px" CssClass="BoxShaddow">
                </asp:DropDownList>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldProductRateProductName" runat="server" ControlToValidate="ddlProductNameAdd" ErrorMessage="* Please Select Product Name" Font-Size="Small" ForeColor="#CC0000" InitialValue="-1" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Product Rate :</td>
            <td>&nbsp;
                <asp:TextBox ID="txtProductRateAdd" runat="server" TextMode="Number" Width="195px" Height="25px" CssClass="BoxShaddow"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldProductRateProductRate" runat="server" ControlToValidate="txtProductRateAdd" ErrorMessage="* Please Enter Product Rate" Font-Size="Small" ForeColor="#CC0000" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Date Of Rate :</td>
            <td>&nbsp;
                <asp:TextBox ID="txtDateOfRateAdd" runat="server" Width="195px" Height="25px" CssClass="BoxShaddow"></asp:TextBox>
            &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldProductRateDateOfRate" runat="server" ControlToValidate="txtDateOfRateAdd" ErrorMessage="* Please Select Date Of Rate" Font-Size="Small" ForeColor="#CC0000" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td text-align: center>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSaveProductRateAdd" runat="server" Text="Save" OnClick="btnSaveProductRateAdd_Click" ValidationGroup="submit" CssClass="btnSave" />
                &nbsp;
                <asp:Button ID="btnCancelProductRateAdd" runat="server" Text="Cancel" OnClientClick="return ConfirmCancel();" CssClass="btnCancel" OnClick="btnCancelProductRateAdd_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
