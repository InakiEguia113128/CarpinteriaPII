using System.Data;

namespace PrimerProyectoPII.AccesoDatos
{
    interface IPresupuestoDao
    {
        int ObtenerProximoPresup();
        DataTable ListarProductos();
        bool Crear(Presupuesto oPresupuesto);
        bool Update(Presupuesto oPresupueto);
        void Delete(int id);
        DataTable CargarGrilla();
        Presupuesto Read(int id);
    }
}