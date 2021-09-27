using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PrimerProyectoPII.Servicios;
using PrimerProyectoPII.AccesoDatos;


namespace PrimerProyectoPII.Formularios
{
    public partial class FrmConsultar : Form
    {
        GestorPresupuesto gestor;
        public FrmConsultar()
        {
            InitializeComponent();
        }

        private void FrmConsultar_Load(object sender, EventArgs e)
        {           
            gestor = new GestorPresupuesto(new DaoFactory());
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            DataTable tabla = gestor.CargarPresupuestos();
           
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                dgvPresupuestos.Rows.Add(new object[] { tabla.Rows[i][0].ToString(), Convert.ToDateTime(tabla.Rows[i][1]).ToString("dd/MM/yy"), tabla.Rows[i][2].ToString(), tabla.Rows[i][3].ToString(), tabla.Rows[i][5].ToString() });
            }
        }

        private void dgvPresupuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idPresupuesto = Convert.ToInt32(dgvPresupuestos.CurrentRow.Cells[0].Value);
            
            if (dgvPresupuestos.CurrentCell.ColumnIndex == 5)
            {
                gestor.ConfirmarDelete(idPresupuesto);
                dgvPresupuestos.Rows.Remove(dgvPresupuestos.CurrentRow);                      
            }
            if (dgvPresupuestos.CurrentCell.ColumnIndex == 6)
            {
                FrmNuevosPresupuestos nuevo = new FrmNuevosPresupuestos();
                nuevo.evento += ActualizarGrilla;
                nuevo.Text = "Modificar Presupuesto";
                nuevo.Bandera = 1;
                nuevo.GenerarPresupuesto(gestor.Read(idPresupuesto));
                nuevo.ShowDialog();               
            }
        }

        public void ActualizarGrilla(object sender,EventArgs e)
        {
            dgvPresupuestos.Rows.Clear();
            CargarGrilla();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
        }
    }
}
