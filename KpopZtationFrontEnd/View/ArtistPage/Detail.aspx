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
</asp:Content>
