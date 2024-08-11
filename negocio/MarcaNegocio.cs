using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using accesoAdatos;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca>listar()
        {
            List<Marca> listadeMarcas= new List<Marca>();
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.SetearConsulta("select Id, Descripcion from MARCAS");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.IdMarca = (int)datos.Lector["Id"];
                    aux.DescripcionMarca = (string)datos.Lector["Descripcion"];


                    listadeMarcas.Add(aux);

                }

                return listadeMarcas;

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
