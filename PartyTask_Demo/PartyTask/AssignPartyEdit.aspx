<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignPartyEdit.aspx.cs" Inherits="PartyTask.AssignPartyEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; font-size: xx-large;">
        Assign Party Edit
    </p>
    <table align="center">
        <tr>
            <td>Party Name :</td>
            <td>&nbsp;
                <asp:DropDownList ID="ddlAssignPartyNameEdit" runat="server" Width="200px" Height="30px">
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
                <asp:DropDownList ID="ddlAssignProductNameEdit" runat="server" Width="200px" Height="30px">
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
                <asp:Button ID="btnUpdateAssignPartyEdit" runat="server" BackColor="#5CB85C" BorderColor="#4CAE4C" ForeColor="White" Text="Update" OnClick="btnUpdateAssignPartyEdit_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnCancelAssignPartyEdit" runat="server" BackColor="#CCCCCC" BorderColor="#CCCCCC" ForeColor="White" Text="Cancel" PostBackUrl="~/AssignParty.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
