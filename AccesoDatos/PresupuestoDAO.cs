using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PrimerProyectoPII.AccesoDatos
{
    class PresupuestoDAO : IPresupuestoDao
    {
        public int ObtenerProximoPresup()
        {

            return HelperDao.ObtenerInstancia().ProximoId("SP_PROXIMO_ID","@next");
        }

        public DataTable ListarProductos()
        {
            
            return HelperDao.ObtenerInstancia().ConsultaSQL("SP_CONSULTAR_PRODUCTOS"); //Desde el helper, ejecutamos el metodo
        }

        public bool Crear(Presupuesto oPresupuesto)
        {
            bool estado = true;
            Dictionary<string, object> param = new Dictionary<string, object>();
            // esperar a que el profe pase una solucion 
            //SqlConnection cnn = new SqlConnection();
            //SqlTransaction transaccion = null;
            //try
            //{

            //    cnn.ConnectionString = @"Data Source=PCGALACTICA\SQLEXPRESS01;Initial Catalog=carpinteria_db;Integrated Security=True";
            //    cnn.Open();
            //    transaccion = cnn.BeginTransaction(); //Conectese, haga el open, y lo que hago bajo esta coneccion, es una transaccion

            //    SqlCommand cmd = new
            //    SqlCommand();

            //    cmd.Connection = cnn;
            //    cmd.Transaction = transaccion; //Le digo al comando que transaccion usar
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandText = "SP_INSERTAR_MAESTRO";

            //    cmd.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);           //Este metodo recibe el nombre y el  valor del parametro
            //    cmd.Parameters.AddWithValue("@dto", oPresupuesto.Descuento);
            //    cmd.Parameters.AddWithValue("@total", oPresupuesto.Total);

            //    SqlParameter param = new SqlParameter();                      //El sp tiene un parametro de salida, nosotros lo tenemos que crear
            //    param.ParameterName = "@presupuesto_nro";
            //    param.SqlDbType = SqlDbType.Int;                            // tipo de parametro
            //    param.Direction = ParameterDirection.Output;               // Direccion del paramtro

            //    cmd.Parameters.Add(param);
            //    cmd.ExecuteNonQuery();
            //    oPresupuesto.Numero = Convert.ToInt32(param.Value);

            //    //Ahora necesitamos agregar los detalles
            //    int contadorDetalles = 1;
            //    foreach (DetallePresupuesto item in oPresupuesto.Detalles)      //Detalles es una list de detalles de presupuesto
            //    {
            //        SqlCommand cmdDetalle = new
            //        SqlCommand();

            //        cmdDetalle.Connection = cnn;
            //        cmdDetalle.Transaction = transaccion;
            //        cmdDetalle.CommandType = CommandType.StoredProcedure;
            //        cmdDetalle.CommandText = "SP_INSERTAR_DETALLE";
            //        cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", oPresupuesto.Numero);
            //        cmdDetalle.Parameters.AddWithValue("@detalle", contadorDetalles);
            //        cmdDetalle.Parameters.AddWithValue("@id_producto", item.Producto.Numero);   //Le pasamos el id del producto
            //        cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
            //        cmdDetalle.ExecuteNonQuery();
            //        contadorDetalles++;
            //    }
            //    transaccion.Commit(); //Ejecuta toda la transaccion
            //}

            //catch (Exception ex)
            //{
            //    transaccion.Rollback(); //No ejecuta nada de la transaccion
            //    estado = false;
            //}
            //finally
            //{
            //    if (cnn.State == ConnectionState.Open)
            //    {
            //        cnn.Close();
            //    }
            //}
            return estado;
        }


        bool IPresupuestoDao.Update(Presupuesto oPresupuesto)
        {
            bool estado = true;
            SqlConnection cnn = new SqlConnection();
            SqlTransaction transaccion = null;
            try
            {

                cnn.ConnectionString = @"Data Source=PCGALACTICA\SQLEXPRESS01;Initial Catalog=carpinteria_db;Integrated Security=True";
                cnn.Open();
                transaccion = cnn.BeginTransaction(); 
                SqlCommand cmd = new
                SqlCommand();

                cmd.Connection = cnn;
                cmd.Transaction = transaccion; 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_MODIFICAR_PROSUPUESTO";

                cmd.Parameters.AddWithValue("@cliente", oPresupuesto.Cliente);           
                cmd.Parameters.AddWithValue("@dto", oPresupuesto.Descuento);
                cmd.Parameters.AddWithValue("@total", oPresupuesto.Total);
                cmd.Parameters.AddWithValue("@presupuesto_nro", oPresupuesto.Numero);

              
                cmd.ExecuteNonQuery();
                

                
                int contadorDetalles = 1;
                foreach (DetallePresupuesto item in oPresupuesto.Detalles)      
                {
                    SqlCommand cmdDetalle = new
                    SqlCommand();

                    cmdDetalle.Connection = cnn;
                    cmdDetalle.Transaction = transaccion;
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.CommandText = "SP_INSERTAR_DETALLE";
                    cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", oPresupuesto.Numero);
                    cmdDetalle.Parameters.AddWithValue("@detalle", contadorDetalles);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", item.Producto.Numero);   
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                    contadorDetalles++;
                }
                transaccion.Commit(); 
            }

            catch (Exception ex)
            {
                transaccion.Rollback(); //No ejecuta nada de la transaccion
                estado = false;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return estado;
        }

        void IPresupuestoDao.Delete(int id)
        {

            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=PCGALACTICA\SQLEXPRESS01;Initial Catalog=carpinteria_db;Integrated Security=True";
            cnn.Open();

            SqlCommand comando = new SqlCommand("SP_ELIMINAR_PRESUPUESTO", cnn);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter parametro = new SqlParameter("@numero", SqlDbType.Int);
            parametro.Direction = ParameterDirection.Input;
            comando.Parameters.Add(parametro);
            parametro.Value = id;
            comando.ExecuteNonQuery();
            cnn.Close();

        }


        DataTable IPresupuestoDao.CargarGrilla()
        {
            DataTable table = new DataTable();
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=PCGALACTICA\SQLEXPRESS01;Initial Catalog=carpinteria_db;Integrated Security=True";


            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_PRESUPUESTOS",cnn); 
            cmd.CommandType = CommandType.StoredProcedure;


            cnn.Open();
            table.Load(cmd.ExecuteReader());
            cnn.Close();


            return table;           
        }

        Presupuesto IPresupuestoDao.Read(int id)
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=PCGALACTICA\SQLEXPRESS01;Initial Catalog=carpinteria_db;Integrated Security=True";

            DataTable tabla = new DataTable();


            SqlParameter param = new SqlParameter("@nro",SqlDbType.Int);

            param.Value = id;
            SqlCommand cmd = new SqlCommand("SP_CONSULTAR_DETALLE_PRESUPUESTO", cnn);
                        
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(param);
            cnn.Open();
            tabla.Load(cmd.ExecuteReader());
            
            cnn.Close();

            Presupuesto p = new Presupuesto();

            p.Numero = Convert.ToInt32(tabla.Rows[0][0]);
            p.Fecha = Convert.ToDateTime(tabla.Rows[0][1]);
            p.Cliente = Convert.ToString(tabla.Rows[0][2]);
            p.Descuento = Convert.ToDecimal(tabla.Rows[0][3]);
            p.Total = Convert.ToDecimal(tabla.Rows[0][5]);


            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                int idProducto = Convert.ToInt32(tabla.Rows[i][8]);
                string nombre = Convert.ToString(tabla.Rows[i][11]);
                decimal precio = Convert.ToDecimal(tabla.Rows[i][12]);
                int cantidad = Convert.ToInt32(tabla.Rows[i][10]);

                Producto prod = new Producto(idProducto, nombre, precio);

                DetallePresupuesto detalle = new DetallePresupuesto(prod, cantidad);

                p.AgregarDetalle(detalle);             
            }

            return p;
        }
    }
}
