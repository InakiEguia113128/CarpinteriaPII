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
    public partial class FrmGraficos : Form
    {
        public FrmGraficos()
        {
            InitializeComponent();
        }

        private void FrmProfeReportes_Load(object sender, EventArgs e)
        {
            //Lo que esta comentado, es para usarlos con un rango de fecha que ingresamos por detalle
            //string fecDesde = dtpDtp.value.ToString();
            //string fecHasta = dtpDtp.Text;
            //this.reportViewer2.RefreshReport();

          



            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=PCGALACTICA\SQLEXPRESS01;Initial Catalog=carpinteria_db;Integrated Security=True";
            cnn.Open();

            string query = "Select   n_producto Producto, COUNT(td.id_producto) Cantidad From T_PRODUCTOS tp join T_DETALLES_PRESUPUESTO td on tp.id_producto = td.id_producto group by n_producto";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = cnn;
            cmd.CommandText = query;
            //cmd.Parameters.AddWithValue("@fecha1", fecDesde);
            //cmd.Parameters.AddWithValue("@fecha2", fecHasta);

            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            this.reportViewer2.LocalReport.DataSources.Clear();
            this.reportViewer2.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", tabla));
            reportViewer2.RefreshReport();

            cnn.Close();
        }
    }
}
