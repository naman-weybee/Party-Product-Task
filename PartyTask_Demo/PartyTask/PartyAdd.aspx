<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PartyAdd.aspx.cs" Inherits="PartyTask.PartyAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; font-size: xx-large;">
        Party Add
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblPartyAdd" runat="server" Text=""></asp:Label>
    </p>
    <table align="center">
        <tr>
            <td>Party Name :&nbsp;&nbsp;&nbsp;&nbsp; </td>
            <td>
                <asp:TextBox ID="txtPartyAdd" runat="server" Width="195px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldPartyAdd" runat="server" ControlToValidate="txtPartyAdd" ErrorMessage="* Please Enter Party Name" Font-Size="Small" ForeColor="#CC0000" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: center">
                <asp:Button ID="btnSavePartyAdd" runat="server" BackColor="#5CB85C" BorderColor="#4CAE4C" ForeColor="White" Text="Save"  OnClick="btnSavePartyAdd_Click" ValidationGroup="submit" />
                &nbsp;
                <asp:Button ID="btnCancelPartyAdd" runat="server" BackColor="#CCCCCC" BorderColor="#CCCCCC" ForeColor="White" Text="Cancel" PostBackUrl="~/Party.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
