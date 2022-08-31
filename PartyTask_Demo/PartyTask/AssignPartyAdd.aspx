<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AssignPartyAdd.aspx.cs" Inherits="PartyTask.AssignPartyAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; font-size: xx-large;">
        Assign Party Add
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblAssignData" runat="server" Text=""></asp:Label>
    </p>
    <p style="text-align: center;">
        &nbsp;
    </p>
    <table align="center">
        <tr>
            <td>Party Name :</td>
            <td>
                <asp:DropDownList ID="ddlAssignPartyNameAdd" runat="server" Width="200px" Height="30px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldAssignPartyName" runat="server" ControlToValidate="ddlAssignPartyNameAdd" ErrorMessage="* Please Select Party Name" Font-Size="Small" ForeColor="#CC0000" InitialValue="-1" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Product Name :</td>
            <td>
                <asp:DropDownList ID="ddlAssignProductNameAdd" runat="server" Width="200px" Height="30px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldAssignProductName" runat="server" ControlToValidate="ddlAssignProductNameAdd" ErrorMessage="* Please Select Product Name" Font-Size="Small" ForeColor="#CC0000" InitialValue="-1" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: center">
                <asp:Button ID="btnSaveAssignPartyAdd" runat="server" BackColor="#5CB85C" BorderColor="#4CAE4C" ForeColor="White" Text="Save" OnClick="btnSaveAssignPartyAdd_Click" ValidationGroup="submit" />
                &nbsp;
                <asp:Button ID="btnCancelAssignPartyAdd" runat="server" BackColor="#CCCCCC" BorderColor="#CCCCCC" ForeColor="White" Text="Cancel" PostBackUrl="~/AssignParty.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
