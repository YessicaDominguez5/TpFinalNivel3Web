using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace tienda_web
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserNegocio negocio = new UserNegocio();

            User usuario = (User)Session["usuario"];

            if(usuario != null)
            {
            txtEmailPerfil.Text = usuario.Usuario;
            txtEmailPerfil.Enabled = false;
            txtNombrePerfil.Text = usuario.Nombre;
            txtApellidoPerfil.Text = usuario.Apellido;
            }

            

            

            
        }

        protected void btnAceptarPerfil_Click(object sender, EventArgs e)
        {
            try
            {



            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}