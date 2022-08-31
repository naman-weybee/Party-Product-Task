<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductRateEdit.aspx.cs" Inherits="PartyTask.ProductRateEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; font-size: xx-large;">
        Product Rate Edit
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
                <asp:Button ID="btnUpdateProductRateEdit" runat="server" BackColor="#5CB85C" BorderColor="#4CAE4C" ForeColor="White" Text="Update" OnClick="btnUpdateProductRateEdit_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnCancelProductRateEdit" runat="server" BackColor="#CCCCCC" BorderColor="#CCCCCC" ForeColor="White" Text="Cancel" PostBackUrl="~/ProductRate.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
