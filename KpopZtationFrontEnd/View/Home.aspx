<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KpopZtationFrontEnd.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Artists</h3>
    <% if (authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Admin"))
        { %>
    <a href="ArtistPage/Insert.aspx">Insert</a>
    <% } %>
    <div class="grid">
        <% foreach (var artist in artists)
            { %>
        <div class="card">
            <img src="../Assets/Artists/<%= artist.ArtistImage %>" />
            <h3><%= artist.ArtistName %></h3>
            <div class="card-operation">
                <a href="ArtistPage/Detail.aspx?id=<%= artist.ArtistID %>">Detail</a>
                <% if (authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Admin"))
                    { %>
                <a href="ArtistPage/Update.aspx?id=<%= artist.ArtistID %>">Update</a>
                <a href="ArtistPage/Delete.aspx?id=<%= artist.ArtistID %>">Delete</a>
                <% } %>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
