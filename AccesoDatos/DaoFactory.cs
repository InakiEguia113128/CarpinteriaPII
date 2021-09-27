using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerProyectoPII.AccesoDatos
{
    class DaoFactory : AbstractDaoFactory
    {
        public override IPresupuestoDao CrearPresupuestoDao()
        {
            return new PresupuestoDAO();
        }
    }
}
