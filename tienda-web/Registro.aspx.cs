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
            User usuario = new User();
            UserNegocio negocio = new UserNegocio();

            string mail = txtEmailRegistro.Text;
            string pass = txtPassRegistro.Text;
            string repitePass = txtRepetirPass.Text;
            string nombre = txtNombreRegistro.Text;
            string apellido = txtApellidoRegistro.Text;

            if (Validacion.validaTextoVacio(mail) || Validacion.validaTextoVacio(pass) || Validacion.validaTextoVacio(nombre) || Validacion.validaTextoVacio(apellido))
            {

                Session.Add("error", "Debe completar todos los campos para poder registrarse.");
                Response.Redirect("Error.aspx", false);
            }else if(pass != repitePass)
            {
                Session.Add("error", "No coinciden las contraseñas");
                Response.Redirect("Error.aspx", false);

            }
            else
            {
                try
                {
                    usuario.Usuario = mail;
                    usuario.Pass = pass;
                    usuario.Nombre = nombre;
                    usuario.Apellido = apellido;


                    usuario.Id = negocio.InsertarNuevoRegistro(usuario);
                    //Le mando el usuario con los datos cargados del registro, lo guarda en la base de datos y me devuelve el id del registro guardado.

                    if(usuario.Id != 0)
                    {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Default.aspx", false);

                    }
                    else
                    {
                        Session.Add("error", "Debe completar todos los campos para poder registrarse.");
                        Response.Redirect("Error.aspx");
                    }

                }
                catch (Exception)
                {

                    Session.Add("error", "Debe completar todos los campos para poder registrarse.");
                    Response.Redirect("Error.aspx");
                }
            }
        }
    }
}