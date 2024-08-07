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
			
			try
			{
				if(!IsPostBack) 
				{
                    MarcaNegocio negocioMarca = new MarcaNegocio();
                    CategoriaNegocio negocioCategoria = new CategoriaNegocio();

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

					if (Request.QueryString["id"] != null) {
					
						ArticuloNegocio negocio = new ArticuloNegocio();

						string id = Request.QueryString["id"];

						Articulo seleccionado = negocio.Listar(id)[0];//Le mandamos el id para que traiga un único artículo, y esa lista en el índice 0 lo guardamos en seleccionado para manejarlo como Artículo en lugar de una lista.

						txtIdArticulo.Text = id;//(Request.QueryString["id"])
						txtCodigoArticulo.Text = seleccionado.CodigoArticulo;
						txtNombreArticulo.Text = seleccionado.NombreArticulo;
						txtDescripcionArticulo.Text = seleccionado.DescripcionArticulo;
						txtUrlImagenArticulo.Text = seleccionado.UrlImagenArticulo;
						imgArticulo.ImageUrl = txtUrlImagenArticulo.Text;
						//txtUrlImagenArticulo_TextChanged(sender, e);
						txtPrecioArticulo.Text = seleccionado.PrecioArticulo.ToString();
						ddlMarcaArticulo.SelectedValue = seleccionado.MarcaArticulo.IdMarca.ToString();
						ddlCategoriaArticulo.SelectedValue = seleccionado.CategoriaArticulo.IdCategoria.ToString();


                    }
		
				
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
				

				if (Request.QueryString["id"] != null)
				{
					articulo.Id = int.Parse(Request.QueryString["id"]);
					negocio.modificar(articulo);
					Response.Redirect("ListaDeArticulos.aspx", false);

				}
				else
				{
				
				negocio.agregar(articulo);
				Response.Redirect("ListaDeArticulos.aspx", false);

				}

			}
			catch (Exception ex)
			{
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");

            }
        }

        protected void txtUrlImagenArticulo_TextChanged(object sender, EventArgs e)
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

