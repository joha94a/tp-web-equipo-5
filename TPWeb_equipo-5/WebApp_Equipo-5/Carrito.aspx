<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebApp_Equipo_5.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Carrito de compras</h1>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <h2></h2>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
