using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using Negocio;

namespace tienda_web
{
    public partial class FormArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			MarcaNegocio negocioMarca = new MarcaNegocio();
			CategoriaNegocio negocioCategoria = new CategoriaNegocio();
			
			try
			{
				if(!IsPostBack) {

					//se carga el desplegable con las marcas cargadas en la base de datos
					ddlMarcaArticulo.DataSource = negocioMarca.listar();
					
					ddlMarcaArticulo.DataValueField = "IdMarca";
					ddlMarcaArticulo.DataTextField = "DescripcionMarca";

                    ddlMarcaArticulo.DataBind();

                    //se carga el desplegable con las categorías cargadas en la base de datos
                    ddlCategoriaArticulo.DataSource = negocioCategoria.listar();

					ddlCategoriaArticulo.DataValueField = "IdCategoria";
					ddlCategoriaArticulo.DataTextField = "DescripcionCategoria";

                    ddlCategoriaArticulo.DataBind();

					//se desactiva el textbox del id para que no se modifique
					txtIdArticulo.Enabled = false;
		
				
				}

			}
			catch (Exception ex)
			{
				Session.Add("error", ex);
				Response.Redirect("Error.aspx");
				
			}
        }

        protected void btnAceptarFormulario_Click(object sender, EventArgs e)
        {
			Articulo articulo = new Articulo();

			ArticuloNegocio negocio = new ArticuloNegocio();

			try
			{
				//se capturan los valores del formulario
				articulo.CodigoArticulo = txtCodigoArticulo.Text;
				articulo.NombreArticulo = txtNombreArticulo.Text;
				articulo.DescripcionArticulo = txtDescripcionArticulo.Text;
				articulo.PrecioArticulo = decimal.Parse(txtPrecioArticulo.Text);
				articulo.UrlImagenArticulo = txtUrlImagenArticulo.Text;
				articulo.MarcaArticulo = new Marca(); //como es una composición se tiene que crear una instancia
				articulo.MarcaArticulo.IdMarca = int.Parse(ddlMarcaArticulo.SelectedValue);
				articulo.CategoriaArticulo = new Categoria();
				articulo.CategoriaArticulo.IdCategoria = int.Parse(ddlCategoriaArticulo.SelectedValue);
				//articulo.Activo = ckbActivoArticulo.Checked;

				negocio.agregar(articulo);
				Response.Redirect("ListaDeArticulos.aspx", false);

			}
			catch (Exception ex)
			{
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");

            }
        }

        protected void txtUrlImagenArticulo_TextChanged(object sender, EventArgs e)
        {
			if(!IsPostBack)
			{
				try
				{
				imgArticulo.ImageUrl = txtUrlImagenArticulo.Text;

				}
				catch (Exception ex) 
				{
                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx");

                }

			}
        }
    }
}

