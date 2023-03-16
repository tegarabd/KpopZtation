<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="KpopZtationFrontEnd.View.ArtistPage.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <img src="../../Assets/Artists/<%= Artist.ArtistImage %>" />
    <h2><%= Artist.ArtistName %></h2>

</asp:Content>
