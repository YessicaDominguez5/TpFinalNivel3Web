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
    public partial class ListaDeArticulos : System.Web.UI.Page
    {
        public bool filtradoListaDeArticulos { get; set; } = false;
        public bool filtroAvanzadoListaArticulos { get; set; } = false;
        public bool filtradoAvanzadoConfiguracionDDlLArticulos { get; set; } = false;
        public bool filtradoAvanzadoVolverLArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {

                //lista los artículos en el gridview
                if (!IsPostBack)
                {

                    dgvArticulos.DataSource = negocio.Listar();
                    dgvArticulos.DataBind();

                }
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

        protected void txtFiltroRapidoListaArticulos_TextChanged(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> lista = negocio.Listar();
            List<Articulo> listaFiltrada = lista.FindAll(x => x.NombreArticulo.ToUpper().Contains(txtFiltroRapidoListaArticulos.Text.ToUpper()));
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.DataBind();

            if(listaFiltrada.Count == 0) {

                labelSinFiltrosListaDeArticulos.Text = "No se encontraron artículos";
            } else
            {
                labelSinFiltrosListaDeArticulos.Text = "";
            }
            filtradoListaDeArticulos = true;


        }

        protected void cBoxFAvanzadoLDeArticulos_CheckedChanged(object sender, EventArgs e)
        {

            filtradoAvanzadoConfiguracionDDlLArticulos = true;

            filtroAvanzadoListaArticulos = cBoxFAvanzadoLDeArticulos.Checked;//se le asigna a filtro avanzado si el checkBox está en true o false

            //txtFiltroRapido.Enable = false; filtro desactivado
            //si el checkBox de filtro avanzado está activado, desactivo el filtro rápido. Lo contrario a filtroAvanzado.

            txtFiltroRapidoListaArticulos.Enabled = !filtroAvanzadoListaArticulos;

            if (!txtFiltroRapidoListaArticulos.Enabled)
            {
                txtFiltroRapidoListaArticulos.Text = "";
                labelSinFiltrosListaDeArticulos.Text = "";
                // si el filtro rápido está desactivado que no se muestre la labelSinFiltros ni el contenido del textBox del filtro rápido
            }
            if (filtradoAvanzadoConfiguracionDDlLArticulos)
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

                if (ddlCampo.SelectedItem.ToString() == "Precio")
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
                List<Articulo> listaDeArticulos = negocio.filtrarAvanzado(ddlCampo.SelectedItem.ToString(), ddlCriterio.SelectedItem.ToString(), txtFiltroAvanzado.Text);
                dgvArticulos.DataSource = listaDeArticulos;
                dgvArticulos.DataBind();

                if (listaDeArticulos.Count == 0)
                {
                    labelSinFiltrosAvanzados.Text = "No se encontraron artículos";
                }

                filtradoListaDeArticulos = false;
                filtradoAvanzadoVolverLArticulos = true;
              

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}