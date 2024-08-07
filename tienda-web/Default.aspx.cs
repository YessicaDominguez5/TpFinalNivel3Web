using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace tienda_web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> listaDeArticulos {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaDeArticulos = negocio.Listar();
            //traer de la base de datos la lista de artículos para mostrarlas en forma de cards
        }
    }
}