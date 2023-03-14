<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="KpopZtationFrontEnd.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Artists</h3>
    <asp:GridView ID="GridViewArtists" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="ArtistId" HeaderText="Artist Id" />
            <asp:BoundField DataField="ArtistName" HeaderText="Artist Name" />
            <asp:ImageField DataImageUrlField="ArtistImage" ControlStyle-Width="200px" ControlStyle-Height="200px" HeaderText="Artist Image" />
            <asp:ButtonField Text="Delete" Visible="false" />
        </Columns>
    </asp:GridView>
</asp:Content>
