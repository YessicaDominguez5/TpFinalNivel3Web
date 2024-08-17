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
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User sessionActiva = (User)Session["usuario"];


            //si no es la pagina de Login o Registro o Error o Default y no hay una sesion activa que lo redireccione al login
            if (!(Page is Login || Page is Registro || Page is Error || Page is Default))
            {
                if (!Seguridad.SesionActiva(sessionActiva))
                {
                    Response.Redirect("Login.aspx",false);
                }
            
            }

            if (Seguridad.SesionActiva(sessionActiva) && !string.IsNullOrEmpty(sessionActiva.UrlImagenPerfil))
            {

               imgAvatar.ImageUrl = "~/Imagenes/" + sessionActiva.UrlImagenPerfil;

            }
            else if (Seguridad.SesionActiva(sessionActiva) && string.IsNullOrEmpty(sessionActiva.UrlImagenPerfil))
            {

                imgAvatar.ImageUrl = "https://lh5.googleusercontent.com/proxy/9vqIPeIeHQHyGEo43DlSgD-DUtidieclv56O6UoAcYNGPXGNnZwFJL2V7oSodehCB1YT28jit7pMSVjNTnrBOnlBxW0CiRmOeH22FlPockzEbfdQPHLkDMPcgMwWdNfVHF1r2QpUk6W_aY_J87A9lFtYKMHf8_xhkMB7l_4=w1200-h630-p-k-no-nu";

            }
            else
            {
                imgAvatar.ImageUrl = "https://lh5.googleusercontent.com/proxy/9vqIPeIeHQHyGEo43DlSgD-DUtidieclv56O6UoAcYNGPXGNnZwFJL2V7oSodehCB1YT28jit7pMSVjNTnrBOnlBxW0CiRmOeH22FlPockzEbfdQPHLkDMPcgMwWdNfVHF1r2QpUk6W_aY_J87A9lFtYKMHf8_xhkMB7l_4=w1200-h630-p-k-no-nu";

            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");

        }

        protected void btnDesloguearse_Click(object sender, EventArgs e)
        {
            Session.Clear(); //borra toda la session
            //Session.Remove("trainee"); borra solo el objeto trainee
            Response.Redirect("Login.aspx");
        }
    }
}