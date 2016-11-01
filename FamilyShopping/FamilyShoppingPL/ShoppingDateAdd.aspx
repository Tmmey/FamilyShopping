<%@ Page Title="Új Időpont" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingDateAdd.aspx.cs" Inherits="FamilyShopping.FamilyShoppingPL.ShoppingDateAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Új Időpont</h1>
    <p>
        <asp:Calendar ID="calendar" runat="server"></asp:Calendar>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="btnShoppingDateAdd" runat="server" OnClick="btnShoppingDateAdd_Click" Text="Hozzáad" />
    </p>

</asp:Content>
