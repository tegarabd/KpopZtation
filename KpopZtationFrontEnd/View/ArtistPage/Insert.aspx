<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="KpopZtationFrontEnd.View.ArtistPage.Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Insert Artist</h3>
    <asp:Table ID="Table" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelArtistName" runat="server" Text="Artist Name"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxArtistName" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelArtistImage" runat="server" Text="Artist Image"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:FileUpload ID="FileUploadArtistImage" runat="server" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Label ID="LabelResult" ForeColor="Red" runat="server" Text="" Width="100%"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" Width="100%" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
