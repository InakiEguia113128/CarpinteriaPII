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
    public partial class FrmConsultar : Form
    {

        SqlDataReader read;
        List <Presupuesto> lPresupuestos;
        public FrmConsultar()
        {
            InitializeComponent();
        }

        private void FrmConsultar_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=PCGALACTICA\SQLEXPRESS01;Initial Catalog=carpinteria_db;Integrated Security=True";

            lPresupuestos.Clear();
            SqlCommand cmd = new
            SqlCommand();

            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_CONSULTAR_PRESUPUESTOS";

            cnn.Open();

            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());



            while (read.Read() == true)
            {
                Presupuesto p = new Presupuesto();
                if (!read.IsDBNull(0))
                    p.Numero = read.GetInt32(0);
                if (!read.IsDBNull)
                {

                }


            }

            cnn.Close();

        }

        private void dgvPresupuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
