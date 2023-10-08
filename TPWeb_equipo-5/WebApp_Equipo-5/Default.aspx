<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp_Equipo_5.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Listado de productos con filtros - asdlaskdj</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%
            foreach (Dominio.Articulo articulo in ListaArticulos)
            {
        %>
        <div class="col">
            <div class="card">
                <img src="<%:articulo.Imagenes[0].ImagenUrl %>" class="card-img-top" alt="<%: articulo.Nombre %>">
                <div class="card-body">
                    <h5 class="card-title"><%: articulo.Nombre %></h5>
                    <p class="card-text"> <%: articulo.Descripcion %></p>
                    <a href="Carrito.aspx?id=<%: articulo.Id.ToString() %>">+</a>
                </div>
            </div>
        </div>
        <%
             }
        %>
    </div>
</asp:Content>
