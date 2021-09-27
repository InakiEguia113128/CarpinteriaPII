using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerProyectoPII
{
    class Producto
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public double Precio { get; set; }

        public Producto(int numero, string nombre, double precio)
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

       
        //private int numero;
        //private string nombre;
        //private double precio;
        //private bool activo;
        //public int Numero
        //{
        //    set { numero = value; }
        //    get { return numero; }
        //}
        //public string Nombre
        //{
        //    set { nombre = value; }
        //    get { return nombre; }
        //}
        //public double Precio
        //{
        //    set { precio = value; }
        //    get { return precio; }
        //}
        //public bool Activo
        //{
        //    set { activo = value; }
        //    get { return activo; }
        //}
    }
}
