using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace tienda_web
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                User usuario = new User();
                UserNegocio negocio = new UserNegocio();

                usuario.Usuario = txtEmailRegistro.Text;
                usuario.Pass = txtPassRegistro.Text;
                usuario.Nombre = txtNombreRegistro.Text;
                usuario.Apellido = txtApellidoRegistro.Text;

                usuario.Id = negocio.InsertarNuevoRegistro(usuario);
                //Le mando el usuario con los datos cargados del registro, lo guarda en la base de datos y me devuelve el id del registro guardado.
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