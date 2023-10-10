<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebApp_Equipo_5.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Carrito de compras</h1>
    <asp:Repeater ID="repCarrito" runat="server">
        <ItemTemplate>
            <div class="container text-center">
                <div class="row">
                    <div class="col">
                        <asp:Label ID="lblArticuloNombre" runat="server" Text='<%# Eval("Articulo.Nombre") %>'></asp:Label>
                    </div>
                    <div class="col">
                        <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label>
                        <asp:Label ID="lblPrecio" runat="server" Text='<%# " x $ " + Eval("Articulo.Precio") %>'></asp:Label>
                    </div>
                    <div class="col">
                        <asp:Label ID="lblTotal" runat="server" Text='<%# "$ " + ((decimal)Eval("Articulo.Precio") * (int)Eval("Cantidad")).ToString() %>'></asp:Label>
                    </div>
                    <div class="col">
                        <asp:LinkButton ID="lknEliminar" runat="server">Borrar</asp:LinkButton>
                    </div>
                </div>
            </div>

            
            
        </ItemTemplate>
    </asp:Repeater>


    <div class="divTotal">
    <h3>Total:</h3> 
    <asp:Label ID="LabelPrecio" runat="server" Text=""></asp:Label>

    </div>
</asp:Content>
