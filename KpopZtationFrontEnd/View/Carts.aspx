<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Carts.aspx.cs" Inherits="KpopZtationFrontEnd.View.Carts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Cart</h3>
    <div class="grid">
        <% foreach (var cart in carts)
            { %>
        <div class="card">
            <img src="../../Assets/Albums/<%= cart.Album.AlbumImage %>" />
            <h3><%= cart.Album.AlbumName %></h3>
            <h4>IDR <%= cart.Album.AlbumPrice %></h4>
            <h4>Quantity <%= cart.Qty %></h4>
            <a href="CartPage/Delete.aspx?albumId=<%= cart.Album.AlbumID %>">Delete</a>
        </div>
        <% } %>
    </div>
    <% if (carts.Count == 0)
        { %>
    <div class="center">
        <h4>You have no item yet</h4>
    </div>
    <% }
        else
        { %>
    <asp:Button ID="ButtonPurchase" runat="server" Text="Purchase" OnClick="ButtonPurchase_Click" Width="100%" />
    <% } %>
</asp:Content>
