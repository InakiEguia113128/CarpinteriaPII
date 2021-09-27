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
namespace PrimerProyectoPII.Formularios
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dataSet1.DTPresupuesto' Puede moverla o quitarla según sea necesario.
            this.dTPresupuestoTableAdapter.Fill(this.dataSet1.DTPresupuesto);

            this.reportViewer1.RefreshReport();
        }
    }
}
