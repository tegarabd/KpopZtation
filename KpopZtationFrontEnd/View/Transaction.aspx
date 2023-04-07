<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="KpopZtationFrontEnd.View.Transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Transaction</h3>
    <% if (authenticationController.IsCurrentCustomerAuthorizedByRole(Master, "Admin"))
        { %>
    <a href="Reports.aspx">Report</a>
    <% } %>
    <% foreach (var transactionHeader in transactionHeaders)
        { %>

    <a><%= transactionHeader.Customer.CustomerName %> | <%= transactionHeader.TransactionDate %></a>
    <div class="grid">
        <% foreach (var transactionDetail in transactionHeader.TransactionDetails)
            { %>
        <div class="card">
            <img src="../../Assets/Albums/<%= transactionDetail.Album.AlbumImage %>" />
            <h3><%= transactionDetail.Album.AlbumName %></h3>
            <h4>IDR <%= transactionDetail.Album.AlbumPrice %></h4>
            <h4>Quantity <%= transactionDetail.Qty %></h4>
        </div>
        <% } %>
    </div>
    <% } %>
</asp:Content>
