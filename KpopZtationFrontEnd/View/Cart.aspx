<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="KpopZtationFrontEnd.View.Cart" %>
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
        </div>
        <% } %>
    </div>
</asp:Content>
