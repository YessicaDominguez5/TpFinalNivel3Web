using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using Negocio;
using tienda_web;
using static System.Net.Mime.MediaTypeNames;

namespace tienda_web
{
    public partial class Default : System.Web.UI.Page
    {
        public bool filtrado { get; set; } = false;
        public bool filtroAvanzado { get; set; } = false;
        public bool filtradoAvanzadoConfiguracionDDl { get; set; } = false;
        public bool filtradoAvanzadoVolver { get; set; }
        public bool meGusta { get; set; } = false;
        public List<Favorito> favoritos { get; set; } = new List<Favorito>();


        public List<Articulo> listaDeArticulos {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
            listaDeArticulos = negocio.Listar();

                if (!IsPostBack)
                {
                    repCards.DataSource = listaDeArticulos;
                    repCards.DataBind();

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
            
     
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> aux = new List<Articulo>();

            aux.AddRange(listaDeArticulos.FindAll(x => x.NombreArticulo.ToUpper().Contains(txtFiltroRapido.Text.ToUpper())));

            //addRange agrega una lista a aux
           
                listaDeArticulos = aux;

            if(listaDeArticulos.Count == 0)
            {
                labelSinFiltros.Text = "No se encontraron artículos";
            }

            filtrado = true;
           

        }

        protected void cBoxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            filtradoAvanzadoConfiguracionDDl = true;
           
            filtroAvanzado = cBoxFiltroAvanzado.Checked;//se le asigna a filtro avanzado si el checkBox está en true o false

            //txtFiltroRapido.Enable = false; filtro desactivado
            //si el checkBox de filtro avanzado está activado, desactivo el filtro rápido. Lo contrario a filtroAvanzado.

            txtFiltroRapido.Enabled = !filtroAvanzado;
            
            if(!txtFiltroRapido.Enabled)
            {
                txtFiltroRapido.Text = "";
                labelSinFiltros.Text = "";
                // si el filtro rápido está desactivado que no se muestre la labelSinFiltros ni el contenido del textBox del filtro rápido
            }
            if (filtradoAvanzadoConfiguracionDDl)
            {
                // Forzamos el metodo selected index changed cuando 
                // apretamos en el check de filtro avanzado
                ddlCampo_SelectedIndexChanged(sender, e);
            }


        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            //para que no acumule los criterios cargados
            try
            {

            if(ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("igual a");
                ddlCriterio.Items.Add("menor a");
                ddlCriterio.Items.Add("mayor a");

            }
            else
            {
                ddlCriterio.Items.Add("contiene");
                ddlCriterio.Items.Add("comienza con");
                ddlCriterio.Items.Add("termina con");

            }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnBuscarFiltroAvanzado_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                List<Articulo> aux = negocio.filtrarAvanzado(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                listaDeArticulos = aux;

                if (listaDeArticulos.Count == 0)
                {
                    labelSinFiltrosAvanzados.Text = "No se encontraron artículos";
                }
                else
                {
                    labelSinFiltrosAvanzados.Text = "";
                }

                filtrado = false;
                filtradoAvanzadoVolver = true;
              

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnFavoritos_Click(object sender, EventArgs e)
        {
            List<Articulo> aux = new List<Articulo>();

            FavoritosNegocio negocio = new FavoritosNegocio();
            Favorito articuloFavorito = new Favorito();

            User usuario =(User)Session["usuario"];
            
            string id = ((Button)sender).CommandArgument;

            if(Seguridad.SesionActiva(usuario))
            {

            aux.Add(listaDeArticulos.Find(x => x.Id.ToString().Equals(id)));

                articuloFavorito.IdArticulo = aux[0].Id;
                articuloFavorito.IdUser = usuario.Id;

                if(!negocio.ExisteFavorito(int.Parse(id),usuario.Id))
                {

                negocio.AgregarFavorito(articuloFavorito);

                Response.Redirect("Favoritos.aspx", false);
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }



        }
    }
}
                        


