<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="WebApp_Equipo_5.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <%--<div class="row row-cols-1 row-cols-md-3 g-4">--%>
    <div class="detalleContainer">
        <div class="detalleContainer_columnLeft">
            <div id="carouselExample" class="carousel slide">
              <div class="carousel-inner">
                  <%string primeraImagen = Imagenes.FirstOrDefault().ImagenUrl;%>
                <div class="carousel-item active">
                  <img src="<%:primeraImagen%>" class="d-block w-100" alt="..."  width="500" height="400">
                </div>
                <%foreach(Dominio.Imagen item in Imagenes.Where(i => !String.Equals(i.ImagenUrl, primeraImagen)))
                {
                        %>
                <div class="carousel-item">
                    <img src="<%: item.ImagenUrl%>" class="d-block w-100" alt="Imagen_<%: item.Id%>"  width="500" height="400">
                </div>
                <%}%>
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
        </div>
        <div class="detalleContainer_columnRight">
            <h2><%:articulo.Nombre%></h2>
            <p><%:articulo.Descripcion%></p>
            <h3><%:articulo.Precio%></h3>

            
            <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregarCarrito_Click" />
            <a href="Default.aspx" class="btn btn-primary" onclick="">Volver</a>
        </div>
    </div>
    <%--</div>--%>
</asp:Content>

