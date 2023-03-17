<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="KpopZtationFrontEnd.View.AlbumPage.Insert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Insert Album</h3>
    <div class="center">
        <asp:Table ID="Table" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAlbumName" runat="server" Text="Album Name"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAlbumName" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAlbumDescription" runat="server" Text="Album Description"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAlbumDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAlbumPrice" runat="server" Text="Album Price"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAlbumPrice" runat="server" TextMode="Number"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAlbumStock" runat="server" Text="Album Stock"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="TextBoxAlbumStock" runat="server" TextMode="Number"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="LabelAlbumImage" runat="server" Text="Album Image"></asp:Label>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:FileUpload ID="FileUploadAlbumImage" runat="server" />
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
