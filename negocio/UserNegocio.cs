using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesoAdatos;
using System.Security.Cryptography;

namespace Negocio
{
    public class UserNegocio
    {
        public bool Loguear(User usuario)
        {
			AccesoADatos datos = new AccesoADatos();
			try
			{
				datos.SetearConsulta("select Id,email,pass,nombre,apellido,urlImagenPerfil,admin from USERS where email=@user AND pass=@pass");
				datos.SetearParametros("@user", usuario.Usuario);
				datos.SetearParametros("@pass", usuario.Pass);
				datos.EjecutarLectura();

				while(datos.Lector.Read())
				{
					usuario.Id = (int)datos.Lector["Id"];
					usuario.TipoUsuario = (bool)datos.Lector["admin"] == true ? User.TipoUser.ADMIN : User.TipoUser.NORMAL;
					return true;

				}return false;

			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.CerrarConexion();
			}
        }
    }
}
