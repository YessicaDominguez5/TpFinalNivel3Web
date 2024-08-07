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
            try
            {
            //lista los artículos en el gridview
            dgvArticulos.DataSource = negocio.Listar();
            dgvArticulos.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }

        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //paginación del gridview
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgvArticulos.SelectedDataKey.Value.ToString());
            //trae el id que es el dataKey del artículo seleccionado
            Response.Redirect("FormArticulo.aspx?id=" + id);
            //Apretando el lápiz de la grilla redirige a la pantalla FormArticulo y envía el id que se trajo en la linea 41.
        }
    }
}