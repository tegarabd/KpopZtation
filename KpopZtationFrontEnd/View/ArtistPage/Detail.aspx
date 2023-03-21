<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="KpopZtationFrontEnd.View.ArtistPage.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Detail Artist</h3>
    <div class="center">
        <div class="card">
            <img src="../../Assets/Artists/<%= artist.ArtistImage %>" />
            <h3><%= artist.ArtistName %></h3>
        </div>
    </div>
    <% if (authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Admin"))
        { %>
    <a href="../AlbumPage/Insert.aspx?artistId=<%= artist.ArtistID %>">Insert Album</a>
    <% } %>
    <h3>Albums</h3>
    <div class="grid">
        <% foreach (var album in artist.Albums)
            { %>
        <div class="card">
            <img src="../../Assets/Albums/<%= album.AlbumImage %>" />
            <h3><%= album.AlbumName %></h3>
            <h4>IDR <%= album.AlbumPrice %></h4>
            <p><%= album.AlbumDescription %></p>
            <div class="card-operation">
                <a href="../AlbumPage/Detail.aspx?id=<%= album.AlbumID %>">Detail</a>
                <% if (authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Admin"))
                    { %>
                <a href="../AlbumPage/Update.aspx?id=<%= album.AlbumID %>">Update</a>
                <a href="../AlbumPage/Delete.aspx?id=<%= album.AlbumID %>&artistId=<%= artist.ArtistID %>">Delete</a>
                <% } %>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
