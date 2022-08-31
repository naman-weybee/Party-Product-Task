<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PartyEdit.aspx.cs" Inherits="PartyTask.PartyEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; font-size: xx-large;">
        Party Edit
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
                <asp:Button ID="btnUpdateParty" runat="server" BackColor="#5CB85C" BorderColor="#4CAE4C" ForeColor="White" Text="Update" OnClick="btnUpdateParty_Click" />
                &nbsp;
                <asp:Button ID="btnCancelParty" runat="server" BackColor="#CCCCCC" BorderColor="#CCCCCC" ForeColor="White" Text="Cancel" PostBackUrl="~/Party.aspx" />
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
