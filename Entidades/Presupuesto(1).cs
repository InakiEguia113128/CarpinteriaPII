using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PrimerProyectoPII
{
    class Presupuesto
    {
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public double Total { get; set; }
        public double Descuento { get; set; }
        public DateTime FechaBaja { get; set; }
        public List<DetallePresupuesto> Detalles { set; get; }

        public Presupuesto()
        {
            Detalles = new List<DetallePresupuesto>();
        }
        public void AgregarDetalle(DetallePresupuesto detalle)
        {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int indice) //Mande el indice del detalle de la lista que quiere quitar
        {
            Detalles.RemoveAt(indice);
                //RemoveAt quita uno del indice
        }
        public double CalcularTotal()
        {
            double total = 0;
            for (int i = 0; i < Detalles.Count; i++)
            {
                total += Detalles[i].CalcularSubtotal();
            }
            //foreach (DetallePresupuesto item in Detalles)
            //{
            //    total += item.CalcularSubtotal();
            //}
            return total;


        }

        internal bool Comfirmar()
        {
            bool estado = true;
            SqlConnection cnn = new SqlConnection();
            SqlTransaction transaccion = null;
            try
            {
               
                cnn.ConnectionString = @"Data Source=PCGALACTICA\SQLEXPRESS01;Initial Catalog=carpinteria_db;Integrated Security=True";
                cnn.Open();
                transaccion = cnn.BeginTransaction(); //Conectese, haga el open, y lo que hago bajo esta coneccion, es una transaccion

                SqlCommand cmd = new
                SqlCommand();

                cmd.Connection = cnn;
                cmd.Transaction = transaccion; //Le digo al comando que transaccion usar
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERTAR_MAESTRO";

                cmd.Parameters.AddWithValue("@cliente", this.Cliente);           //Este metodo recibe el nombre y el  valor del parametro
                cmd.Parameters.AddWithValue("@dto", this.Descuento);
                cmd.Parameters.AddWithValue("@total", this.Total);

                SqlParameter param = new SqlParameter();                      //El sp tiene un parametro de salida, nosotros lo tenemos que crear
                param.ParameterName = "@presupuesto_nro";
                param.SqlDbType = SqlDbType.Int;                            // tipo de parametro
                param.Direction = ParameterDirection.Output;               // Direccion del paramtro

                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();
                this.Numero = Convert.ToInt32(param.Value);

                //Ahora necesitamos agregar los detalles
                int contadorDetalles = 1;
                foreach (DetallePresupuesto item in Detalles)      //Detalles es una list de detalles de presupuesto
                {
                    SqlCommand cmdDetalle = new
                    SqlCommand();

                    cmdDetalle.Connection = cnn;
                    cmdDetalle.Transaction = transaccion;
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.CommandText = "SP_INSERTAR_DETALLE";
                    cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", this.Numero);
                    cmdDetalle.Parameters.AddWithValue("@detalle", contadorDetalles);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", item.Producto.Numero);   //Le pasamos el id del producto
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.ExecuteNonQuery();
                    contadorDetalles++;
                }
                transaccion.Commit(); //Ejecuta toda la transaccion
            }

            catch (Exception ex)
            {
                transaccion.Rollback(); //No ejecuta nada de la transaccion
                estado = false;
            }
            finally
            {
                if (cnn.State ==ConnectionState.Open)
                {
                    cnn.Close();
                }
            }

            return estado;
        }
    }
}
 