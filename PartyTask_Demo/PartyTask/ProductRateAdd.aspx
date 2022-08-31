<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductRateAdd.aspx.cs" Inherits="PartyTask.ProductRateAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; font-size: xx-large;">
        Product Rate Add
    </p>
    <p style="text-align: center;">
        <asp:Label ID="lblProductRateAddSuccess" runat="server" Text=""></asp:Label>
    </p>
    <table align="center">
        <tr>
            <td>Product Name :</td>
            <td>&nbsp;
                <asp:DropDownList ID="ddlProductNameAdd" runat="server" Width="200px" Height="30px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td text-align: center>
                <asp:RequiredFieldValidator ID="RequiredFieldProductRateProductName" runat="server" ControlToValidate="ddlProductNameAdd" ErrorMessage="* Please Select Product Name" Font-Size="Small" ForeColor="#CC0000" InitialValue="-1" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Product Rate :</td>
            <td>&nbsp;
                <asp:TextBox ID="txtProductRateAdd" runat="server" TextMode="Number" Width="195px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td text-align: center>
                <asp:RequiredFieldValidator ID="RequiredFieldProductRateProductRate" runat="server" ControlToValidate="txtProductRateAdd" ErrorMessage="* Please Enter Product Rate" Font-Size="Small" ForeColor="#CC0000" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Date Of Rate :</td>
            <td>&nbsp;
                <asp:TextBox ID="txtDateOfRateAdd" runat="server" Width="195px" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td text-align: center>
                <asp:RequiredFieldValidator ID="RequiredFieldProductRateDateOfRate" runat="server" ControlToValidate="txtDateOfRateAdd" ErrorMessage="* Please Select Date Of Rate" Font-Size="Small" ForeColor="#CC0000" ValidationGroup="submit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: center">
                <asp:Button ID="btnSaveProductRateAdd" runat="server" BackColor="#5CB85C" BorderColor="#4CAE4C" ForeColor="White" Text="Save" OnClick="btnSaveProductRateAdd_Click" ValidationGroup="submit" />
                &nbsp;
                <asp:Button ID="btnCancelProductRateAdd" runat="server" BackColor="#CCCCCC" BorderColor="#CCCCCC" ForeColor="White" Text="Cancel" PostBackUrl="~/ProductRate.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
