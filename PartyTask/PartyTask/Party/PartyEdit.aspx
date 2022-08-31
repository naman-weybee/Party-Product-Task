<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PartyEdit.aspx.cs" Inherits="PartyTask.PartyEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Party.css" rel="stylesheet" />
    <script>
        function ConfirmCancel() {
            var txt = document.getElementById("<%= txtPartyEdit.ClientID%>").value;

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
        Party Edit
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblPartyEditExist" runat="server" ForeColor="#CC0000"></asp:Label>
    </p>
    <table align="center">
        <tr>
            <td>Party Name :&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:TextBox ID="txtPartyEdit" runat="server" Width="195px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: center">
                <asp:Button ID="btnUpdateParty" runat="server" Text="Update" OnClick="btnUpdateParty_Click" CssClass="btnSave" />
                &nbsp;
                <asp:Button ID="btnCancelParty" runat="server" Text="Cancel" OnClientClick="return ConfirmCancel();" CssClass="btnCancel" OnClick="btnCancelParty_Click1" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
