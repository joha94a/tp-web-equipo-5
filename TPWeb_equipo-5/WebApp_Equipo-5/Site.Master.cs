using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Equipo_5
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public Dominio.Carrito Carrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Carrito"] == null)
            { 
                Dominio.Carrito carrito = new Dominio.Carrito();
                Session.Add("Carrito", carrito);
            }
            Carrito = Session["Carrito"] as Dominio.Carrito;
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx", false);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = txtBuscar.Text;
            if(!string.IsNullOrEmpty(busqueda))
            {
                Response.Redirect("Default.aspx?busqueda=" + busqueda, false);
            }
        }
    }
}