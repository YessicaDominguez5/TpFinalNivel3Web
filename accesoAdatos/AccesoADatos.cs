﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            conexion = new SqlConnection("server =.\\SQLEXPRESS; database = CATALOGO_WEB_DB; integrated security = true");
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
    }
}
