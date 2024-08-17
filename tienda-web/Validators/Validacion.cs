using System.Web.UI.WebControls;

namespace tienda_web
{
    public class Validacion
    {
        public static bool validaTextoVacio(object control)//como es object puede recibir cualquier cosa
        {
            if (control is TextBox texto) //crea una variable texto de la clase TextBox, control es reemplazado por texto, si control es un TextBox que cree una variable nueva(texto)
            {
                //return string.IsNullOrEmpty(texto.Text);
                if (string.IsNullOrEmpty(texto.Text))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }


    }
}