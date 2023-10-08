<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp_Equipo_5.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Listado de productos con filtros - asdlaskdj</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidorArticulos" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">

                        <div id="carouselImagenes<%# Container.ItemIndex%>" class="carousel slide">
                            <div class="carousel-indicators">
                                <button type="button" data-bs-target="#carouselImagenes<%# Container.ItemIndex%>" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                                <button type="button" data-bs-target="#carouselImagenes<%# Container.ItemIndex%>" data-bs-slide-to="1" aria-label="Slide 2"></button>
                                <button type="button" data-bs-target="#carouselImagenes<%# Container.ItemIndex%>" data-bs-slide-to="2" aria-label="Slide 3"></button>
                            </div>
                            <div class="carousel-inner" style="height: 20rem;">
                                <asp:Repeater ID="repImagenes" runat="server" OnDataBinding="repImagenes_DataBinding">
                                    <ItemTemplate>
                                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                            <img src="<%#Eval("ImagenUrl") %>" class="d-block w-100">
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carouselImagenes<%# Container.ItemIndex%>" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carouselImagenes<%# Container.ItemIndex%>" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>
                        
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <a href="Carrito.aspx?id=<%#Eval("Id") %>" class="btn btn-primary">Ver detalle</a>
                            <%--<asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar" CommandArgument='<%#Eval("Id")%>' CommandName="IdArticulo" OnClick="btnAgregarCarrito_Click" />--%>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
