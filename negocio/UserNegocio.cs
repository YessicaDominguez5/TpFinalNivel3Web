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

                if (!(string.IsNullOrEmpty(usuario.Usuario) || string.IsNullOrEmpty(usuario.Pass))){ 
				datos.SetearConsulta("select Id,email,pass,nombre,apellido,urlImagenPerfil,admin from USERS where email=@user AND pass=@pass");
				datos.SetearParametros("@user", usuario.Usuario);
				datos.SetearParametros("@pass", usuario.Pass);
				datos.EjecutarLectura();
				}
				else
				{
					return false;
				}

				while(datos.Lector.Read())
				{
					usuario.Id = (int)datos.Lector["Id"];
					usuario.TipoUsuario = (bool)datos.Lector["admin"] == true ? User.TipoUser.ADMIN : User.TipoUser.NORMAL;
					if (!(datos.Lector["nombre"] is DBNull))
					{
						usuario.Nombre = (string)datos.Lector["nombre"];

					}
					if (!(datos.Lector["apellido"] is DBNull))
					{
						usuario.Apellido = (string)datos.Lector["apellido"];

					}
					if (!(datos.Lector["urlImagenPerfil"] is DBNull))
					{
						usuario.UrlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];

					}
					
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

		public int InsertarNuevoRegistro(User usuarioNuevo)
		{
			AccesoADatos datos = new AccesoADatos();

			try
			{
				if (!(string.IsNullOrEmpty(usuarioNuevo.Usuario) || (string.IsNullOrEmpty(usuarioNuevo.Pass)) || (string.IsNullOrEmpty(usuarioNuevo.Nombre)) || (string.IsNullOrEmpty(usuarioNuevo.Apellido))))
				{
					datos.SetearConsulta("insert into USERS (email,pass,nombre,apellido,admin) output inserted.Id values (@email,@pass,@nombre,@apellido,0)");

					datos.SetearParametros("@email", usuarioNuevo.Usuario);
					datos.SetearParametros("@pass", usuarioNuevo.Pass);
					datos.SetearParametros("@nombre", usuarioNuevo.Nombre);
					datos.SetearParametros("@apellido", usuarioNuevo.Apellido);
					return datos.EjecutarAccionScalar(); //devuelve el id del registro que acabamos de ingresar
				}
				else
				{
					return 0;
				}
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
		public void Actualizar(User usuarioAActualizar)
		{

			AccesoADatos datos = new AccesoADatos();

			try
			{
				datos.SetearConsulta("Update USERS set nombre = @nombre, apellido = @apellido, urlImagenPerfil = @img where Id = @id");

				datos.SetearParametros("@id", usuarioAActualizar.Id);
				datos.SetearParametros("@nombre", usuarioAActualizar.Nombre);
                datos.SetearParametros("@apellido", usuarioAActualizar.Apellido);
                datos.SetearParametros("@img", usuarioAActualizar.UrlImagenPerfil);
				datos.EjecutarAccion();

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
