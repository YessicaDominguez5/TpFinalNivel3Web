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
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = (User)Session["usuario"];
            
            if(Seguridad.SesionActiva(user))
            {
                if(Session["error"] != null)
                {
                    labelError.Text = Session["error"].ToString();
                   
                }
                else
                {
                    Response.Redirect("Default.aspx", false);
                }
            }
            else
            {
                if(Session["error"] != null)
                {
                    labelError.Text = Session["error"].ToString();
                }
                else 
                {
                    Response.Redirect("Login.aspx", false);
                }

            }
            
        }

        protected void btnErrorVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}

