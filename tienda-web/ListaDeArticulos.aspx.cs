using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace tienda_web
{
    public partial class ListaDeArticulos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            dgvArticulos.DataSource = negocio.Listar();
            dgvArticulos.DataBind();

        }
    }
}