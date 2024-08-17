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
            if (!IsPostBack)
            {

                UserNegocio negocio = new UserNegocio();

                string ruta = Server.MapPath("./Imagenes/");

                bool existeImagen = true;

                User usuario = (User)Session["usuario"];

                if (usuario != null)
                {
                    txtEmailPerfil.Text = usuario.Usuario;
                    txtEmailPerfil.Enabled = false;
                    txtNombrePerfil.Text = usuario.Nombre;
                    txtApellidoPerfil.Text = usuario.Apellido;
                    existeImagen = File.Exists(ruta + usuario.UrlImagenPerfil);
                }

                if (Seguridad.SesionActiva(Session["usuario"]) && !string.IsNullOrEmpty(usuario.UrlImagenPerfil) && existeImagen)
                {
               
                    imgPerfil.ImageUrl = "~/Imagenes/" + usuario.UrlImagenPerfil;

                }
                else if (!existeImagen && !string.IsNullOrEmpty(usuario.UrlImagenPerfil))
                {
                    negocio.ActualizarImagenUsuario(usuario.Id);
                    usuario.UrlImagenPerfil = null;
                    Session.Add("usuario", usuario);
                    imgPerfil.ImageUrl = "https://lh5.googleusercontent.com/proxy/9vqIPeIeHQHyGEo43DlSgD-DUtidieclv56O6UoAcYNGPXGNnZwFJL2V7oSodehCB1YT28jit7pMSVjNTnrBOnlBxW0CiRmOeH22FlPockzEbfdQPHLkDMPcgMwWdNfVHF1r2QpUk6W_aY_J87A9lFtYKMHf8_xhkMB7l_4=w1200-h630-p-k-no-nu";
                }
                else if (Seguridad.SesionActiva(Session["usuario"]) && string.IsNullOrEmpty(usuario.UrlImagenPerfil))
                {

                    imgPerfil.ImageUrl = "https://lh5.googleusercontent.com/proxy/9vqIPeIeHQHyGEo43DlSgD-DUtidieclv56O6UoAcYNGPXGNnZwFJL2V7oSodehCB1YT28jit7pMSVjNTnrBOnlBxW0CiRmOeH22FlPockzEbfdQPHLkDMPcgMwWdNfVHF1r2QpUk6W_aY_J87A9lFtYKMHf8_xhkMB7l_4=w1200-h630-p-k-no-nu";

                }
                else
                {
                    imgPerfil.ImageUrl = "https://lh5.googleusercontent.com/proxy/9vqIPeIeHQHyGEo43DlSgD-DUtidieclv56O6UoAcYNGPXGNnZwFJL2V7oSodehCB1YT28jit7pMSVjNTnrBOnlBxW0CiRmOeH22FlPockzEbfdQPHLkDMPcgMwWdNfVHF1r2QpUk6W_aY_J87A9lFtYKMHf8_xhkMB7l_4=w1200-h630-p-k-no-nu";

                }


            }




        }

        protected void btnAceptarPerfil_Click(object sender, EventArgs e)
        {
            UserNegocio negocio = new UserNegocio();
            try
            {
                string ruta = Server.MapPath("./Imagenes/");

                User user = (User)Session["usuario"];

                if (!string.IsNullOrEmpty(txtImagen.PostedFile.FileName))
                {
                    //que guarde la imágen solo si el txt está cargado con la imagen
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.UrlImagenPerfil = "perfil-" + user.Id + ".jpg";
                    imgPerfil.ImageUrl = "~/Imagenes/" + user.UrlImagenPerfil;
                }

                user.Nombre = txtNombrePerfil.Text;
                user.Apellido = txtApellidoPerfil.Text;

                negocio.Actualizar(user);

                Session.Add("usuario", user);



                Response.Redirect("Default.aspx", false);




            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}