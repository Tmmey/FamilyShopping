<%@ Page Title="Kívánságok" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingItemAdd.aspx.cs" Inherits="FamilyShopping.FamilyShoppingPL.ShoppingItemAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Kívánságok</h1>
    <p>
        <asp:DropDownList ID="dropdownDate" runat="server">
        </asp:DropDownList>
        <asp:Label ID="lblShoppingDateWarning" runat="server" Font-Bold="True" Font-Names="Arial Black" Font-Size="Large" ForeColor="Red" Text="Nincs választható dátum" Visible="False"></asp:Label>
    </p>
    <table>
        <tr>
            <td>
                Megnevezés:
            </td>
            <td>

                <asp:TextBox ID="txtDescription" runat="server" Width="300px"></asp:TextBox>

            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                Mennyiség:
            </td>
            <td>

                <asp:TextBox ID="txtQunatity" runat="server" Width="300px" TextMode="Number"></asp:TextBox>

            </td>
            <td>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtQunatity" ErrorMessage="Kérem adjon meg mennyiséget!"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td>
                Mennyiség Egysége:
            </td>
            <td>

                <asp:DropDownList ID="dropdownUnit" runat="server">
                </asp:DropDownList>

            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                Honnan:
            </td>
            <td>

                <asp:DropDownList ID="dropdownShoppingPlace" runat="server">
                </asp:DropDownList>

            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                Maximum ár:
            </td>
            <td>

                <asp:TextBox ID="txtMaxPrice" runat="server" Width="300px"></asp:TextBox>

            </td>
            <td>

            </td>
        </tr>
    </table>
    <p>

        <asp:Button ID="btnAdd" runat="server" Height="63px" OnClick="btnAdd_Click" Text="Hozzáad" Width="441px" />

    </p>
    <p>

        <asp:Label ID="lblMessage" runat="server"></asp:Label>

    </p>

</asp:Content>
