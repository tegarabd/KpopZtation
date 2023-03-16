<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KpopZtationFrontEnd.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Artists</h3>
    <asp:Button ID="ButtonInsertArtist" runat="server" Text="Insert" OnClick="ButtonInsertArtist_Click" />
    <table>
        <thead>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Image</th>
                <th>Action</th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var artist in artists)
                { %>
            <tr>
                <td><%= artist.ArtistID %></td>
                <td><%= artist.ArtistName %></td>
                <td>
                    <img width="150" height="150" src="../Assets/Artists/<%= artist.ArtistImage %>" /></td>
                <td>
                    <a href="ArtistDetail.aspx?id=<%= artist.ArtistID %>">Detail</a>
                    <% if (authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Admin"))
                        { %>
                    <a href="ArtistUpdate.aspx?id=<%= artist.ArtistID %>">Update</a>
                    <a href="ArtistDelete.aspx?id=<%= artist.ArtistID %>">Delete</a>
                    <% } %>
                </td>
            </tr>
            <% } %>
        </tbody>
    </table>



</asp:Content>
