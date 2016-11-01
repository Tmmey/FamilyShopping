<%@ Page Title="Bevásárlólista" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingItemsList.aspx.cs" Inherits="FamilyShopping.FamilyShoppingPL.ShoppingItemsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Bevásárlólista</h1>
    <p>
        <asp:DropDownList ID="dropdownShoppingDate" runat="server" OnSelectedIndexChanged="dropdownShoppingDate_SelectedIndexChanged" OnTextChanged="dropdownShoppingDate_TextChanged" AutoPostBack="True">
        </asp:DropDownList>
        <asp:Label ID="lblShoppingDateWarning" runat="server" Text="Kérem előbb vásárlási dátumot adjon hozzá!" Visible="False"></asp:Label>
    </p>
    <p>
        <asp:TextBox ID="txtWishList" runat="server" Height="262px" ReadOnly="True" TextMode="MultiLine" Width="780px"></asp:TextBox>
    </p>

</asp:Content>
