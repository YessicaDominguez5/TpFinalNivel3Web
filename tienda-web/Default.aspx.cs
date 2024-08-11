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
        public bool filtroAvanzado { get; set; } = false;
        public List<Articulo> listaDeArticulos {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
      
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaDeArticulos = negocio.Listar();
            
     
        }

        protected void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> aux = new List<Articulo>();

            aux.AddRange(listaDeArticulos.FindAll(x => x.NombreArticulo.ToUpper().Contains(txtFiltroRapido.Text.ToUpper())));

            if(aux.Count > 0 )
            {
                listaDeArticulos = aux;
            }

        }

        protected void cBoxFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
           //se le asigna a filtro avanzado si el checkBox está en true o false
            filtroAvanzado = cBoxFiltroAvanzado.Checked;

            //txtFiltroRapido.Enable = false; filtro desactivado
            //si el checkBox de filtro avanzado está activado, desactivo el filtro rápido. Lo contrario a filtroAvanzado.

            txtFiltroRapido.Enabled = !filtroAvanzado;
            


        }
    }
}