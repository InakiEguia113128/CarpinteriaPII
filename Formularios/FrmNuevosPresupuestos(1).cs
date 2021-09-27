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
    public partial class FrmNuevosPresupuestos : Form
    {
        Presupuesto presup; //Variable
        public FrmNuevosPresupuestos()   
        {
            InitializeComponent();
            presup = new Presupuesto(); //Instancia de la variable
        }

        private void FrmNuevosPresupuestos_Load(object sender, EventArgs e)
        {
            CargarTextsBox();
            NuevoPresupuesto();
            CargarProductos();
        }

        private void NuevoPresupuesto() //Se basa en consumir un SP que tenga como objetivo devolver el valor del metodo
        {
            SqlConnection cnn = new SqlConnection(@"Data Source=PCGALACTICA\SQLEXPRESS01;Initial Catalog=carpinteria_db;Integrated Security=True");
            cnn.Open();
            SqlCommand cmd = new                    //creamos un comando
            SqlCommand();     


            cmd.Connection = cnn;                                   // Le asignamos la conexion
            cmd.CommandType = CommandType.StoredProcedure;         // El comando se interpreta como un SP
            cmd.CommandText = "SP_PROXIMO_ID";                    // El texto del CMD es el nombre del SP



            SqlParameter param = new SqlParameter("@next", SqlDbType.Int);             //Creamos un parametro, y le ponemos nombre y tipo
            param.Direction = ParameterDirection.Output;                              //Le damos direccion de salida
            cmd.Parameters.Add(param);                                               // Agregamos a la coleccion de parametros el que acabamos de crear
            cmd.ExecuteNonQuery();                                                  //Ejecutamos
            int next = Convert.ToInt32(param.Value);
            cnn.Close();
            lblPresupuesto.Text = "Presupuesto Nro : " + next.ToString();
        }

        private void CargarProductos()
        {
            SqlConnection cnn = new SqlConnection();
            cnn.ConnectionString = @"Data Source=PCGALACTICA\SQLEXPRESS01;Initial Catalog=carpinteria_db;Integrated Security=True";
            cnn.Open();

            SqlCommand cmd = new                    
            SqlCommand();

            cmd.Connection = cnn;                                   
            cmd.CommandType = CommandType.StoredProcedure;         
            cmd.CommandText = "SP_CONSULTAR_PRODUCTOS";

            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());                //Cargamos una tabla, para luego darle las propertyes al combo
            cnn.Close();

            cboProductos.DataSource = tabla;             //Fuente de datos
            cboProductos.DisplayMember = "n_producto";
            cboProductos.ValueMember = "id_producto";            
        }

        private void CargarTextsBox()
        {
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yy");
            txtFecha.Enabled = false;
            txtCliente.Text = "CONSUMIDOR FINAL";
            txtDescuento.Text = "0";
            txtCantidad.Text = "1";
            txtSubtotal.Enabled = false;
            txtTotal.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProductos.Text.Equals(string.Empty))
            {
                MessageBox.Show("Seleccione un producto","Control",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text))                // || es el OR && es el AND
            {
                MessageBox.Show("Ingrese una cantidad", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;       
            }
            if (!int.TryParse(txtCantidad.Text, out _))            // Si la salida no es un entero, muestre el mensaje
            {
                MessageBox.Show("Ingrese NUMEROS en la cantidad", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            
            foreach (DataGridViewRow row  in dgvDetalles.Rows)
            {
                if (row.Cells["colProd"].Value.ToString().Equals(cboProductos.Text))
                {
                    MessageBox.Show("Este producto ya fue ingresado", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }


                                                                                     //Fila de data grid view, cada fila sera un item de mi grilla
            DataRowView item = (DataRowView)cboProductos.SelectedItem;              //El item seleccionado en el combo, va a ser una fila de mi grilla

            int prod = Convert.ToInt32(item.Row.ItemArray[0]);                    //El data table que me cargo el cbo tiene en la fila 0 en ese array,
                                                                                 //tiene el id de productos

          
            string nom = Convert.ToString(item.Row.ItemArray[1]);              //En la fila 1 esta el nombre
            double pre = Convert.ToDouble(item.Row.ItemArray[2]);             //En la fila 2 esta el precio
            

            Producto p = new Producto(prod, nom, pre);                      //Este producto con la cantidad, es un detalle de presupuesto
                                                                           // Por eso ahora creamos un detalle_presupuest y le pasamos ese prod, con la cantidad                                                                        
            int cant = Convert.ToInt32(txtCantidad.Text);                 
            DetallePresupuesto detalle = new DetallePresupuesto(p, cant);
            presup.AgregarDetalle(detalle);                             //Agrego el detalle en el presupesto nuevo
            dgvDetalles.Rows.Add(new object[] { prod, nom, pre, cant });

            CalcularTotales();
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                presup.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
                CalcularTotales();
            }           
        }
        private void CalcularTotales()
        {
            txtSubtotal.Text = presup.CalcularTotal().ToString();
            double desc = (presup.CalcularTotal() * Convert.ToDouble(txtDescuento.Text)) / 100;
            txtTotal.Text = (presup.CalcularTotal() - desc).ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Validar
            if (txtCliente.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un cliente", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCliente.Focus();
                return;
            }
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar un detalle como minimo", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Grabar Maestro y Detalles
            GuardarPresupuesto();
        }

        private void GuardarPresupuesto()
        {
            presup.Fecha = Convert.ToDateTime(txtFecha.Text);
            presup.Cliente = txtCliente.Text;
            presup.Descuento = Convert.ToDouble(txtDescuento.Text);
            presup.Total = Convert.ToDouble(txtTotal.Text);

            if (presup.Comfirmar())
            {
                MessageBox.Show("El presupuesto se grabo correctamente", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("El presupuesto NO se pudo grabar", "Notificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }  
}
