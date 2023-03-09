<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="KpopZtationFrontEnd.View.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Register</h3>
    <asp:Table ID="Table" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelUsername" runat="server" Text="Username"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RadioButton ID="RadioButtonMale" runat="server" Text="Male" GroupName="Gender" />
                <asp:RadioButton ID="RadioButtonFemale" runat="server" Text="Female" GroupName="Gender" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelAddress" runat="server" Text="Address"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click" Width="100%" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>
