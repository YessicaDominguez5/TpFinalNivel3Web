using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
using System.IO;

namespace tienda_web
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UserNegocio negocio = new UserNegocio();

            User usuario = (User)Session["usuario"];

            if (usuario != null)
            {
                txtEmailPerfil.Text = usuario.Usuario;
                txtEmailPerfil.Enabled = false;
                txtNombrePerfil.Text = usuario.Nombre;
                txtApellidoPerfil.Text = usuario.Apellido;
            }

            if (Seguridad.SesionActiva(Session["usuario"]) && !string.IsNullOrEmpty(usuario.UrlImagenPerfil))
            {

                imgPerfil.ImageUrl = "~/Imagenes/" + usuario.UrlImagenPerfil;

            }
            else if(Seguridad.SesionActiva(Session["usuario"]) && string.IsNullOrEmpty(usuario.UrlImagenPerfil)){
               
                imgPerfil.ImageUrl = "https://lh5.googleusercontent.com/proxy/9vqIPeIeHQHyGEo43DlSgD-DUtidieclv56O6UoAcYNGPXGNnZwFJL2V7oSodehCB1YT28jit7pMSVjNTnrBOnlBxW0CiRmOeH22FlPockzEbfdQPHLkDMPcgMwWdNfVHF1r2QpUk6W_aY_J87A9lFtYKMHf8_xhkMB7l_4=w1200-h630-p-k-no-nu";

            }
            else
            {
                imgPerfil.ImageUrl = "https://lh5.googleusercontent.com/proxy/9vqIPeIeHQHyGEo43DlSgD-DUtidieclv56O6UoAcYNGPXGNnZwFJL2V7oSodehCB1YT28jit7pMSVjNTnrBOnlBxW0CiRmOeH22FlPockzEbfdQPHLkDMPcgMwWdNfVHF1r2QpUk6W_aY_J87A9lFtYKMHf8_xhkMB7l_4=w1200-h630-p-k-no-nu";

            }






        }

        protected void btnAceptarPerfil_Click(object sender, EventArgs e)
        {
            UserNegocio negocio = new UserNegocio();
            try
            {
                string ruta = Server.MapPath("./Imagenes/");

                User user = (User)Session["usuario"];

                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");

                user.Nombre = txtNombrePerfil.Text;
                user.Apellido = txtApellidoPerfil.Text;
                user.UrlImagenPerfil = "perfil-" + user.Id + ".jpg";

                negocio.Actualizar(user);

                imgPerfil.ImageUrl = "~/Imagenes/" + user.UrlImagenPerfil;    
                


               



            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}