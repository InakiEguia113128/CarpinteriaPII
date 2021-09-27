using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PrimerProyectoPII
{
    public class Presupuesto
    {
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public decimal Total { get; set; }
        public decimal Descuento { get; set; }
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
        public decimal CalcularTotal()
        {
            decimal total = 0;
            for (int i = 0; i < Detalles.Count; i++)
            {
                total += Detalles[i].CalcularSubtotal();
            }
            return total;
        }

        //internal bool Comfirmar() //Instancia un presupuesto en la base de datos
        //{
            //Lo delegamos al DAO
        //}
    }
}
 