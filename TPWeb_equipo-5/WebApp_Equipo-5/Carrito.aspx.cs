using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Equipo_5
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dominio.Carrito carrito;
            if (Session["Carrito"] != null)
                carrito = Session["Carrito"] as Dominio.Carrito;
            else
                carrito= new Dominio.Carrito();

            repCarrito.DataSource = carrito.ListarItems();
            repCarrito.DataBind();
            
            LabelPrecio.Text = carrito.PrecioTotal().ToString("0.00");

        }
    }
}