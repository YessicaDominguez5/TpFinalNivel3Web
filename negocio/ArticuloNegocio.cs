using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using dominio;
using System.Data.SqlClient;
using accesoAdatos;
using System.Net;
using static System.Net.WebRequestMethods;

namespace negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> Listar(string id="") //parámetro opcional
        {


            AccesoADatos datos = new AccesoADatos();

            try
            {
                string query = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca,A.IdCategoria,A.ImagenUrl,A.Precio,C.Id as 'IdCategoria',C.Descripcion as 'DescripcionCategoria',M.Id as 'IdMarca',M.Descripcion as 'DescripcionMarca' from ARTICULOS A, CATEGORIAS C, MARCAS M where IdMarca = M.Id AND IdCategoria = C.Id ";

                if(id != "")
                {
                    query += "AND A.Id=" + id;
                }

                datos.SetearConsulta(query);
                datos.EjecutarLectura();

                return CargarLista(datos);

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

        public void agregar(Articulo nuevo) //recibe el artículo que se manda dentro del evento Aceptar_Click desde el formulario AgregarModificar
        {
            AccesoADatos datos = new AccesoADatos();
            string sinImagen = "https://icon-library.com/images/no-image-icon/no-image-icon-0.jpg";

            try
            {

                datos.SetearConsulta("insert into ARTICULOS (Codigo,Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) VALUES(@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@ImagenUrl,@Precio)");

                datos.SetearParametros("@Codigo", nuevo.CodigoArticulo);
                datos.SetearParametros("@Nombre", nuevo.NombreArticulo);
                datos.SetearParametros("@Descripcion", nuevo.DescripcionArticulo);
                datos.SetearParametros("@IdMarca", nuevo.MarcaArticulo.IdMarca);
                datos.SetearParametros("@IdCategoria", nuevo.CategoriaArticulo.IdCategoria);

                if(!string.IsNullOrEmpty(nuevo.UrlImagenArticulo))
                {
                datos.SetearParametros("@ImagenUrl", nuevo.UrlImagenArticulo);

                }
                else
                {
                    datos.SetearParametros("@ImagenUrl", sinImagen);
                }
                datos.SetearParametros("@Precio", nuevo.PrecioArticulo);
               

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

        public void modificar(Articulo articuloAModificar)
        {
            AccesoADatos datos = new AccesoADatos();

            try
            {
                datos.SetearConsulta("update ARTICULOS set Codigo = @CodigoArticulo, Nombre = @NombreArticulo,Descripcion = @DescripcionArticulo,IdMarca = @MarcaArticulo, IdCategoria = @CategoriaArticulo, ImagenUrl = @UrlImagenArticulo,precio = @PrecioArticulo where Id = @Id");

                datos.SetearParametros("@CodigoArticulo", articuloAModificar.CodigoArticulo);
                datos.SetearParametros("@NombreArticulo", articuloAModificar.NombreArticulo);
                datos.SetearParametros("@DescripcionArticulo", articuloAModificar.DescripcionArticulo);
                datos.SetearParametros("@MarcaArticulo", articuloAModificar.MarcaArticulo.IdMarca);
                datos.SetearParametros("@CategoriaArticulo", articuloAModificar.CategoriaArticulo.IdCategoria);
                datos.SetearParametros("UrlImagenArticulo", articuloAModificar.UrlImagenArticulo);
                datos.SetearParametros("@PrecioArticulo", articuloAModificar.PrecioArticulo);
                datos.SetearParametros("@Id", articuloAModificar.Id);

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

        public void EliminarFisico(int id)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                datos.SetearConsulta("delete from ARTICULOS where Id = @Id");
                datos.SetearParametros("@Id", id);
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
      

        public List<Articulo> filtrarAvanzado(string campo, string criterio, string filtro)
        {
            AccesoADatos datos = new AccesoADatos();
            try
            {
                string consulta = "select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca,A.IdCategoria,A.ImagenUrl,A.Precio,C.Id as 'IdCategoria',C.Descripcion as 'DescripcionCategoria',M.Id as 'IdMarca',M.Descripcion as 'DescripcionMarca' from ARTICULOS A, CATEGORIAS C, MARCAS M where IdMarca = M.Id AND IdCategoria = C.Id AND ";

                switch (campo)
                {
                    case "Artículo":

                        switch (criterio)
                        {
                            case "comienza con":
                                consulta += "A.Nombre like '" + filtro + "%'";

                                break;

                            case "termina con":

                                consulta += "A.Nombre like '%" + filtro + "'";

                                break;
                            default://Contiene...

                                consulta += "A.Nombre like '%" + filtro + "%'";
                                break;

                        }


                        break;

                    case "Marca":

                        switch (criterio)
                        {
                            case "comienza con":
                                consulta += "M.Descripcion like '" + filtro + "%'";

                                break;

                            case "termina con":

                                consulta += "M.Descripcion like '%" + filtro + "'";

                                break;
                            default://Contiene...

                                consulta += "M.Descripcion like '%" + filtro + "%'";
                                break;

                        }


                        break;

                    default://precio

                        switch (criterio)
                        {
                            case "mayor a":
                                consulta += "A.Precio >" + filtro;

                                break;

                            case "menor a":

                                consulta += "A.Precio <" + filtro;

                                break;
                            default://Igual a...

                                consulta += "A.Precio =" + filtro;
                                break;

                        }

                        break;


                }
                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();

               

                return CargarLista(datos);
            }
            catch (Exception ex)
            {

               throw ex;
            }
        }

        private List<Articulo> CargarLista(AccesoADatos datos)
        {
            List<Articulo> lista = new List<Articulo>();
            while (datos.Lector.Read())
            {
                Articulo aux = new Articulo();
                aux.Id = (int)datos.Lector["Id"];
                aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                aux.NombreArticulo = (string)datos.Lector["Nombre"];
                aux.DescripcionArticulo = (string)datos.Lector["Descripcion"];
                aux.CategoriaArticulo = new Categoria();
                aux.CategoriaArticulo.IdCategoria = (int)datos.Lector["IdCategoria"];
                aux.CategoriaArticulo.DescripcionCategoria = (string)datos.Lector["DescripcionCategoria"];
                aux.MarcaArticulo = new Marca();
                aux.MarcaArticulo.IdMarca = (int)datos.Lector["IdMarca"];
                aux.MarcaArticulo.DescripcionMarca = (string)datos.Lector["DescripcionMarca"];

                if (!(datos.Lector["ImagenUrl"] is DBNull)) //para que lo lea solo si no es Null
                {
                    aux.UrlImagenArticulo = (string)datos.Lector["ImagenUrl"];


                }
               
                aux.PrecioArticulo = (decimal)datos.Lector["Precio"];

                lista.Add(aux);
            }

            return lista;

        }
        public bool soloNumeros(string cadena)
        {
            int cont = 0;

            foreach (char caracter in cadena)
            { 
                if(caracter == '.')
                {
                    cont++;
                }

                if (!(char.IsNumber(caracter)) && caracter != '.')
                {
                    return false; //si no es Número retorna falso a validarFiltro
                }
                
                if(cont >= 2)
                {
                    return false;
                }
            }

            return true;

        }
    }
}
