using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoAdatos;
using dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> listadeCategorias= new List<Categoria>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.SetearConsulta("select Id, Descripcion from CATEGORIAS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.IdCategoria = (int)datos.Lector["Id"];
                    aux.DescripcionCategoria = (string)datos.Lector["Descripcion"];


                    listadeCategorias.Add(aux);

                }

                return listadeCategorias;

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
