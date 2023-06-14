<%@ Page Title="" Language="C#" MasterPageFile="~/View/NavBar.Master" AutoEventWireup="true" CodeBehind="DeleteAccount.aspx.cs" Inherits="KpopZtationFrontEnd.View.DeleteAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h3>Delete Account</h3>
    <% if (toBeDeleteCustomer == null)
        { %>
    <table class="table">
        <thead>
            <tr>
                <td>Id</td>
                <td>Name</td>
                <td>Email</td>
                <td>Gender</td>
                <td>Address</td>
                <td>Role</td>
                <td>Delete</td>
            </tr>
        </thead>
        <tbody>
            <% foreach (var customer in customers)
                { %>
            <tr>
                <td><%= customer.CustomerID %></td>
                <td><%= customer.CustomerName %></td>
                <td><%= customer.CustomerEmail %></td>
                <td><%= customer.CustomerGender %></td>
                <td><%= customer.CustomerAddress %></td>
                <td><%= customer.CustomerRole %></td>
                <td>
                    <a href="DeleteAccount.aspx?id=<%= customer.CustomerID %>">Delete</a>
                </td>
            </tr>
            <%} %>
        </tbody>
    </table>
    <% }
        else
        { %>
    <p>Are you sure want to delete <%= currentCustomer.CustomerID == toBeDeleteCustomer.CustomerID ? "Your" : toBeDeleteCustomer.CustomerName %> account?</p>
    <asp:Button ID="CancelButton" runat="server" Text="No" OnClick="CancelButton_Click" />
    <asp:Button ID="DeleteButton" runat="server" Text="Yes" OnClick="DeleteButton_Click" />
    <% } %>
</asp:Content>
