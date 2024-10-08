﻿using System;
using System.Configuration;
using System.Data.SqlClient;

namespace accesoAdatos
{
    public class AccesoADatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {

            get { return lector; }
        }




        public AccesoADatos()
        {
            conexion = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]);

            //conexion = new SqlConnection("server =.\\SQLEXPRESS; database = CATALOGO_WEB_DB; integrated security = true");

            comando = new SqlCommand();

        }

        public void SetearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void EjecutarLectura()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public void EjecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }



        }
        public void SetearParametros(string nombre, object valor)
        {

            comando.Parameters.AddWithValue(nombre, valor);

            //para setear los valores del insert @IdMarca, @IdCategoria

        }

        public void CerrarConexion()
        {
            if (lector != null)
            {
                lector.Close();
                conexion.Close();

            }



        }

        public int EjecutarAccionScalar()
        {
            comando.Connection = conexion;

            try
            {
                conexion.Open();
                return int.Parse(comando.ExecuteScalar().ToString());
                //devuelve el id del registro que acabamos de ingresar
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
