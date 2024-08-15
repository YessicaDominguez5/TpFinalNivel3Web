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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresarLogin_Click(object sender, EventArgs e)
        {
            User usuario = new User();
            UserNegocio negocio = new UserNegocio();
            usuario.Usuario = txtUser.Text;
            usuario.Pass = txtPass.Text;

            try
            {
                if (negocio.Loguear(usuario))
                {
                    //si el negocio.Loguear devuelve true es porque lo encontró en la base de datos(user y pass) y puede ingresar

                    Session.Add("usuario", usuario);
                    Response.Redirect("Perfil.aspx", false);

                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos.");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }

        }
    }
}