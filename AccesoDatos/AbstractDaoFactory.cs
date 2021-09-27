using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerProyectoPII.AccesoDatos
{
    abstract class AbstractDaoFactory
    {
        public abstract IPresupuestoDao CrearPresupuestoDao();
    }
}
