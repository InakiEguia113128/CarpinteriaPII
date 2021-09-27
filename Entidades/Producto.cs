using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerProyectoPII
{
    public class Producto
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public decimal Precio { get; set; }

        public Producto(int numero, string nombre, decimal precio)
        {
            Numero = numero;
            Nombre = nombre;
            Activo = true;
            Precio = precio;
        }

        public override string ToString()
        {
            return $"Producto {Nombre} | Precio {Precio} | Numero {Numero} | Estado activo {Activo}";
        }
    }
}
