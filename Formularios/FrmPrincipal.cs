using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimerProyectoPII.Formularios
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevosPresupuestos nuevo = new FrmNuevosPresupuestos();
            nuevo.Bandera = 0;
            nuevo.ShowDialog();
        }

        private void hora_Tick(object sender, EventArgs e)
        {
            lblReloj.Text = DateTime.Now.ToLongTimeString();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FrmConsultar nuevo = new FrmConsultar();
            
            nuevo.ShowDialog();
        }

        private void presupuestosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmReportes nuevo = new FrmReportes();
            nuevo.ShowDialog();
        }

        private void graficosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGraficos nuevo = new FrmGraficos();
            nuevo.ShowDialog();
        }
    }
}
