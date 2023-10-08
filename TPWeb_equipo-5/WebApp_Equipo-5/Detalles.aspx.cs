using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_Equipo_5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public Articulo articuloSeleccionado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            int articuloId = -1;

            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    articuloId = Convert.ToInt32(Request.QueryString["Id"]);
                }
            }
           
            articuloSeleccionado = negocio.obtenerArticulo(articuloId);

            RepImagenes.DataSource = articuloSeleccionado.Imagenes;
            RepImagenes.DataBind();
        }

        
    }
}