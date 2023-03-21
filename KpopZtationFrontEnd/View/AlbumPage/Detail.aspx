<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="KpopZtationFrontEnd.View.AlbumPage.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Detail Album</h3>
    <div class="center">
        <div class="card">
            <img src="../../Assets/Albums/<%= album.AlbumImage %>" />
            <h3><%= album.AlbumName %></h3>
            <h4>IDR <%= album.AlbumPrice %></h4>
            <h4>Stock <%= album.AlbumStock %></h4>
            <p><%= album.AlbumDescription %></p>
        </div>
        <% if (authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Customer"))
            { %>
        <asp:TextBox ID="TextBoxQuantity" runat="server" TextMode="Number" Text="1"></asp:TextBox>
        <asp:Label ID="LabelResult" ForeColor="Red" runat="server" Text=""></asp:Label>
        <asp:Button ID="ButtonAddToCart" runat="server" Text="Add To Cart" OnClick="ButtonAddToCart_Click" />
        <% } %>
    </div>
    
</asp:Content>
