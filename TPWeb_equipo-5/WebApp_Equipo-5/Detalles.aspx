<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="WebApp_Equipo_5.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Detalles del producto</h2>

    

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <itemtemplate>
            <div class="col">
                <div class="card">
                    <div class="card-body">
                        <p><%: articuloSeleccionado.Categoria.Descripcion %></p>
                        <h5 class="card-title"><%: articuloSeleccionado.Nombre %></h5>
                        <p><%: articuloSeleccionado.Marca.Descripcion %></p>

                        <!-- carrusel -->

                        <div id="carouselExample" class="carousel slide">

                            <div class="carousel-inner">
                                <asp:Repeater ID="RepImagenes" runat="server">
                                    <ItemTemplate>
                                        <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                            <img src="<%# Eval("ImagenUrl")   %>" class="d-block w-100">
                                        </div>
                                    </ItemTemplate>

                                </asp:Repeater>

                            </div>
                            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Previous</span>
                            </button>
                            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                <span class="visually-hidden">Next</span>
                            </button>
                        </div>

                        <!-- /carrusel -->

                        <p class="card-text"><%: articuloSeleccionado.Descripcion  %></p>
                        <h5>Precio:</h5>
                        <p class="card-text"><%: articuloSeleccionado.Precio %></p>
                        <a href="#" class="btn btn-primary" onclick="">Agregar</a>
                        <a href="Carrito.aspx" class="btn btn-primary" onclick="">Ver carrito</a>
                        <a href="Default.aspx" class="btn btn-primary" onclick="">Volver</a>

                        <%--<asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar" CommandArgument='<%#Eval("Id")%>' CommandName="IdArticulo" OnClick="btnAgregarCarrito_Click" />--%>
                    </div>
                </div>
            </div>
        </itemtemplate>
    </div>
</asp:Content>
