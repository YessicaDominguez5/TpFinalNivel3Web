using dominio;
using System;
using System.Collections.Generic;
using accesoAdatos;

namespace Negocio
{
    public class FavoritosNegocio
    {
        public List<Favorito> ListarArticulosFavoritos(int idUsuario)
        {
            AccesoADatos datos = new AccesoADatos();
            List<Favorito> listaFavoritos = new List<Favorito>();

            try
            {
                string query = "select IdArticulo from FAVORITOS where IdUser = @idUser";

                datos.SetearConsulta(query);
                datos.SetearParametros("@idUser", idUsuario);
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Favorito aux = new Favorito();
                    //aux.IdUser = (int)datos.Lector["IdUser"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];

                    listaFavoritos.Add(aux);
                }
                return listaFavoritos;
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

        public void AgregarFavorito(Favorito nuevoFavorito)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string query = "insert into FAVORITOS(IdUser,IdArticulo) values (@idUser,@idArticulo)";
                
                datos.SetearConsulta(query);

                datos.SetearParametros("@idUser", nuevoFavorito.IdUser);
                datos.SetearParametros("@idArticulo", nuevoFavorito.IdArticulo);

                
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
        
        public void EliminarDeFavoritos(int idArticulo, int idUsuario)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                string query = "delete from FAVORITOS where IdArticulo = @idArticulo AND IdUser = @idUser";
               
                datos.SetearConsulta(query);
                datos.SetearParametros("@idArticulo", idArticulo);
                datos.SetearParametros("@idUser", idUsuario);
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

        public bool ExisteFavorito(int idArticulo, int idUser)
        {
            AccesoADatos datos = new AccesoADatos();
            List<Favorito> lista = new List<Favorito>();

            try
            {
                string query = "select Id, IdUser, IdArticulo from FAVORITOS where IdUser = @idUser AND IdArticulo = @idArticulo";

                datos.SetearConsulta(query);
                datos.SetearParametros("@idUser",idUser);
                datos.SetearParametros("@idArticulo",idArticulo);

                datos.EjecutarLectura();

                while(datos.Lector.Read())
                {
                    Favorito aux = new Favorito();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.IdUser = (int)datos.Lector["IdUser"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];

                    lista.Add(aux);
                }

                if(lista.Count > 0)
                {
                    return true;
                }
                else
                {
                return false;

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

        


    }
}

