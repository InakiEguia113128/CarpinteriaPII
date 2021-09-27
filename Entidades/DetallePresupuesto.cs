using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerProyectoPII
{
    public class DetallePresupuesto
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }

        public DetallePresupuesto(Producto producto, int cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }

        public decimal CalcularSubtotal()
        {
            decimal _subtotal = 0;
            _subtotal = Cantidad * Producto.Precio;
            return _subtotal;
        }
    }
}
