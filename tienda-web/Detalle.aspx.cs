using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tienda_web
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            

            if (Request.QueryString["id"] != null) {

                string id = Request.QueryString["id"];
                Articulo seleccionado = negocio.Listar(id)[0];

                imagenDetalle.ImageUrl = seleccionado.UrlImagenArticulo;

                labelCodigoDetalle.Text = "Código de Artículo: " + seleccionado.CodigoArticulo;
                labelNombreDetalle.Text = "Artículo: " + seleccionado.NombreArticulo;
                labelDescripcionDetalle.Text = "Descripción: " + seleccionado.DescripcionArticulo;
                labelMarcaDetalle.Text = "Marca: " + seleccionado.MarcaArticulo.DescripcionMarca;
                labelCategoriaDetalle.Text = "Categoría: " + seleccionado.CategoriaArticulo.DescripcionCategoria;
                labelPrecioDetalle.Text = "Precio: " + seleccionado.PrecioArticulo.ToString();

            
            }
        }
    }
}