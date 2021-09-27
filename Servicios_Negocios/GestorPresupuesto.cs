using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrimerProyectoPII.AccesoDatos;
using System.Data.SqlClient;
using System.Data;

namespace PrimerProyectoPII.Servicios
{
    class GestorPresupuesto //Se encarga de la gestion de presupuesto
                           // Por ende tiene que mandar todo lo necesario
    {
        private IPresupuestoDao dao;

        public GestorPresupuesto(AbstractDaoFactory factory)
        {
            dao = factory.CrearPresupuestoDao();
        }
        public int ProximoPresupuesto() 
        {
           return dao.ObtenerProximoPresup(); //Esto devuelve un entero, de la clase PresupuestoDAO (Capa de acceso a datos)
        }

        public DataTable ObtenerProductos()
        {
            return dao.ListarProductos();
        }

        public bool ConfirmarPresupuesto(Presupuesto oPresupuesto)
        {
            return dao.Crear(oPresupuesto);
        }

        public bool ConfirmarUpdate(Presupuesto oPresupuesto)
        {
            return dao.Update(oPresupuesto);
        }

        public void ConfirmarDelete(int id)
        {
           dao.Delete(id);
        }

        public DataTable CargarPresupuestos()
        {
           return dao.CargarGrilla();
        }

        public Presupuesto Read(int id)
        {
            return dao.Read(id);
        }



        

    }
}
