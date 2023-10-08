using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Equipo_5
{
    public partial class Home : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }       
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulos = negocio.listarArticulos();
            if (!IsPostBack)
            {
                repRepetidorArticulos.DataSource = ListaArticulos;
                repRepetidorArticulos.DataBind();
            }
        }
        
        protected void repImagenes_DataBinding(object sender, EventArgs e)
        {
            Repeater rep = (Repeater)sender;
            var art = (RepeaterItem)rep.NamingContainer;
            int artIndex = art.ItemIndex;

            rep.DataSource = ListaArticulos[artIndex].Imagenes;
        }
        
    }
}