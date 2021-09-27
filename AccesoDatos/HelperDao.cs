using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PrimerProyectoPII.AccesoDatos
{
    class HelperDao
    {
        //Patron singleton, una sola instancia
        private static HelperDao instancia;
        private string connectionString;
        private HelperDao()
        {
            //connectionString = @"Data Source=PCGALACTICA\SQLEXPRESS01;Initial Catalog=carpinteria_db;Integrated Security=True";
            connectionString = Properties.Resources.strConeccion;
        }
        public static HelperDao ObtenerInstancia() //Devuelve la instancia del helperDao
        {
            if (instancia == null) //Si la variable que es un helper es null, por lo tanto no hay ninguna coneccion creada
            {
                instancia = new HelperDao();
            }
            return instancia;
        }

        private void CloseConnection(SqlConnection cnn)
        {
            if (cnn != null && cnn.State == ConnectionState.Open)
            {
                cnn.Close();
            }
        }
        public DataTable ConsultaSQL(string storeName) //Todos los sp que retornan datatable se pueden usar aca, +o-
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            DataTable tabla = new DataTable();
            
            try
            {
                
                cnn.Open();

                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storeName;


                tabla.Load(cmd.ExecuteReader());
                
                return tabla;
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                if(cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
        }

        public int ProximoId(string storeName,string nombParam)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new  SqlCommand();
            SqlParameter param = new SqlParameter(nombParam, SqlDbType.Int); //Creamos un parametro, y le ponemos nombre y tipo
            try
            {
               
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storeName;                                   // El texto del CMD es el nombre del SP



                           
                param.Direction = ParameterDirection.Output;              //Le damos direccion de salida
                cmd.Parameters.Add(param);                               // Agregamos a la coleccion de parametros el que acabamos de crear
                cmd.ExecuteNonQuery();                                  //Ejecutamos
                int next = Convert.ToInt32(param.Value);

                return next;
            }
            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
        }
        

        public int EjecutarSql(string storeName,Dictionary<string,object> parametros)
        {
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            int filasAfectadas = 0;

            try
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storeName;
                
                foreach (var item in parametros)
                {     
                    cmd.Parameters.AddWithValue(item.Key, item.Value);               
                }
                filasAfectadas = cmd.ExecuteNonQuery();                  
            }

            catch (SqlException ex)
            {
                throw (ex);
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            return filasAfectadas;
        }
    }
}


