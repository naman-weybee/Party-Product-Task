<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignPartyEdit.aspx.cs" Inherits="PartyTask.AssignPartyEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/AssignParty.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style2 {
            height: 23px;
        }
    </style>
    <script>
        function ConfirmCancel() {
            var ddlParty = document.getElementById("<%= ddlAssignPartyNameEdit.ClientID%>");
            var x = ddlParty.options[ddlParty.selectedIndex].value;

            var ddlProduct = document.getElementById("<%= ddlAssignProductNameEdit.ClientID%>");
            var y = ddlProduct.options[ddlProduct.selectedIndex].value;

            if (x || y) {
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
        Assign Party Edit
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblAlreadyDataEditExist" runat="server" ForeColor="#CC0000"></asp:Label>
    </p>
    <table align="center">
        <tr>
            <td>Party Name :</td>
            <td>&nbsp;
                <asp:DropDownList ID="ddlAssignPartyNameEdit" runat="server" Width="200px" Height="30px" CssClass="BoxShaddow">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Product Name :</td>
            <td class="auto-style2">&nbsp;
                <asp:DropDownList ID="ddlAssignProductNameEdit" runat="server" Width="200px" Height="30px" CssClass="BoxShaddow">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnUpdateAssignPartyEdit" runat="server" Text="Update" OnClick="btnUpdateAssignPartyEdit_Click" CssClass="btnSave"/>
                &nbsp;&nbsp;
                <asp:Button ID="btnCancelAssignPartyEdit" runat="server" Text="Cancel" OnClientClick="return ConfirmCancel();" CssClass="btnCancel" OnClick="btnCancelAssignPartyEdit_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
