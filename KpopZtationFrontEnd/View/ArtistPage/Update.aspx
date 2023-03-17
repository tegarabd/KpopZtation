<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="KpopZtationFrontEnd.View.ArtistPage.Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Update Artist</h3>
    <div class="center">
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
                    <div class="card">
                        <asp:Image ID="ImageArtist" runat="server" />
                    </div>
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
    </div>

</asp:Content>
