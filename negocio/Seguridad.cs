using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Seguridad
    {
        public static bool SesionActiva(object usuario)
        {
            //me traigo el usuario en la session, si devuelve true hay un usuario logueado
            User user = usuario != null?(User)usuario : null;
           if(user != null && (user.Id != 0) ) 
            {
                return true;
            }else
            {
                return false;
            }

        }
    }
}
