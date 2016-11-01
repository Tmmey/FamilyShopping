<%@ Page Title="Bolt Hozzáadása" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingPlaceAdd.aspx.cs" Inherits="FamilyShopping.FamilyShoppingPL.ShoppingPlaceAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Új Bolt</h1>
<p>
    <asp:Label ID="lblDescription" runat="server" Text="Név: "></asp:Label>
    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="lblAddress" runat="server" Text="Cím: "></asp:Label>
    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
</p>
<p>
    <asp:Button ID="btnShoppingPlaceAdd" runat="server" OnClick="btnShoppingPlaceAdd_Click" Text="Hozzáad" />
</p>

</asp:Content>
