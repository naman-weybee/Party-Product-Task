<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PartyAdd.aspx.cs" Inherits="PartyTask.PartyAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Party.css" rel="stylesheet" />
    <script>
        function ConfirmCancel() {
            var txt = document.getElementById("<%= txtPartyAdd.ClientID%>").value;

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
        Party Add
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblPartyAdd" runat="server" Text=""></asp:Label>
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblPartyAddExist" runat="server" ForeColor="#CC0000"></asp:Label>
    </p>
    <table align="center">
        <tr>
            <td>Party Name :&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:TextBox ID="txtPartyAdd" runat="server" Width="195px" Height="25px"></asp:TextBox>
                &nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldPartyAdd" runat="server" ControlToValidate="txtPartyAdd" ErrorMessage="* Please Enter Party Name" Font-Size="Small" ForeColor="#CC0000" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnSavePartyAdd" runat="server" Text="Save" OnClick="btnSavePartyAdd_Click" ValidationGroup="submit" CssClass="btnSave" />
                &nbsp;
                <asp:Button ID="btnCancelPartyAdd" runat="server" Text="Cancel" OnClientClick="return ConfirmCancel();" CssClass="btnCancel" OnClick="btnCancelPartyAdd_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
