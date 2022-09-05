<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignPartyAddEdit.aspx.cs" Inherits="PartyTask.AssignPartyAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/AssignParty.css" rel="stylesheet" />
    <script>
        function ConfirmCancel() {
            var ddlParty = document.getElementById("<%= ddlAssignPartyNameAdd.ClientID%>");
            var x = ddlParty.options[ddlParty.selectedIndex].value;

            var ddlProduct = document.getElementById("<%= ddlAssignProductNameAdd.ClientID%>");
            var y = ddlProduct.options[ddlProduct.selectedIndex].value;

            if (x != "-1" || y != "-1") {
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
        Assign Party Add
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblAssignData" runat="server" Text=""></asp:Label>
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblAlreadyDataExist" runat="server" ForeColor="#CC0000"></asp:Label>
    </p>
    <table align="center">
        <tr>
            <td>Party Name :</td>
            <td>
                <asp:DropDownList ID="ddlAssignPartyNameAdd" runat="server" Width="200px" Height="30px" CssClass="BoxShaddow">
                </asp:DropDownList>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldAssignPartyName" runat="server" ControlToValidate="ddlAssignPartyNameAdd" ErrorMessage="* Please Select Party Name" Font-Size="Small" ForeColor="#CC0000" InitialValue="-1" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Product Name :</td>
            <td>
                <asp:DropDownList ID="ddlAssignProductNameAdd" runat="server" Width="200px" Height="30px" CssClass="BoxShaddow">
                </asp:DropDownList>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldAssignProductName" runat="server" ControlToValidate="ddlAssignProductNameAdd" ErrorMessage="* Please Select Product Name" Font-Size="Small" ForeColor="#CC0000" InitialValue="-1" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSaveAssignPartyAdd" runat="server" Text="Save" OnClick="btnSaveAssignPartyAdd_Click" ValidationGroup="submit" CssClass="btnSave" />
                &nbsp;
                <asp:Button ID="btnCancelAssignPartyAdd" runat="server" Text="Cancel" CssClass="btnCancel" OnClientClick="return ConfirmCancel();" OnClick="btnCancelAssignPartyAdd_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
