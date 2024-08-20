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
    public partial class Favoritos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            User user = (User)Session["usuario"];

            if (Seguridad.SesionActiva(user))
            {

                if (!IsPostBack)
                {
                    ListarFavoritos(user.Id);
                }

            }


        }

        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
        {
           FavoritosNegocio negocio = new FavoritosNegocio();
           
            User user = (User)Session["usuario"];

            string id = ((Button)sender).CommandArgument;

            negocio.EliminarDeFavoritos(int.Parse(id),user.Id);
            
            ListarFavoritos(user.Id);
        }

        private void ListarFavoritos(int userId)
        {
            FavoritosNegocio negocio = new FavoritosNegocio();
            ArticuloNegocio negocioArticulo = new ArticuloNegocio();
      

            List<Favorito> listaFavoritos = negocio.ListarArticulosFavoritos(userId);
            //lista todos los favoritos del usuario en la session
            List<Articulo> listaArticulosFavoritos = new List<Articulo>();

            foreach (Favorito articulo in listaFavoritos)
            {
                listaArticulosFavoritos.AddRange(negocioArticulo.Listar(articulo.IdArticulo.ToString()));
                //lista los articulos Favoritos a través del Id 

            }

            repFavoritos.DataSource = listaArticulosFavoritos;
            repFavoritos.DataBind();
        }
    }
}