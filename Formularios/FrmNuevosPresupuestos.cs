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
    public partial class FrmNuevosPresupuestos : Form
    {
        public delegate void Delegado(object sender, EventArgs e);
        public event Delegado evento;
        Presupuesto presup ;


        GestorPresupuesto gestor;
        private 

        enum Aceptar
        {
            Create,
            Read,
            Update,
            Delete
        }
        public int Bandera { get; set; }
        public FrmNuevosPresupuestos()   
        {
            InitializeComponent();
            presup = new Presupuesto(); //Instancia de la variable
            gestor = new GestorPresupuesto(new DaoFactory()); //Factory
            // en vez de usar el new presupuesto dao, usamos el factory

        }

        private void FrmNuevosPresupuestos_Load(object sender, EventArgs e)
        {
            if (Bandera == 0)
            {
                CargarTextsBox();
                lblPresupuesto.Text += gestor.ProximoPresupuesto(); //Se lo delego al gestor, el gestor se lo delega al DAO.
            }
           
            CargarProductos();
        }

   
        private void CargarProductos()
        {
            DataTable tabla = gestor.ObtenerProductos();
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
            decimal pre = Convert.ToDecimal(item.Row.ItemArray[2]);             //En la fila 2 esta el precio
            

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
                if (dgvDetalles.Rows.Count !=0)
                {
                    CalcularTotales();
                }
                else
                {
                    txtSubtotal.Text = "";
                    txtTotal.Text = "";
                }
            }           
        }
        private void CalcularTotales()
        {
            decimal desc = (presup.CalcularTotal() * Convert.ToDecimal(txtDescuento.Text)) / 100;
            txtSubtotal.Text = Convert.ToString(presup.CalcularTotal());
            txtTotal.Text = Convert.ToString(presup.CalcularTotal() - desc);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           
            if (txtCliente.Text == string.Empty)
            {
                MessageBox.Show("Ingrese un cliente", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCliente.Focus();
                return;
            }
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar un detalle como minimo", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            presup.Fecha = Convert.ToDateTime(txtFecha.Text);
            presup.Cliente = txtCliente.Text;
            presup.Descuento = Convert.ToDecimal(txtDescuento.Text);
            presup.Total = Convert.ToDecimal(txtTotal.Text);

            if (Bandera == 0)
            {
                if (gestor.ConfirmarPresupuesto(presup))
                {
                    MessageBox.Show("Se ingreso su presupuesto con exito", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("No ingreso su presupuesto ", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);                   
                }

            }
            else
            {
                if (gestor.ConfirmarUpdate(presup))
                {
                    MessageBox.Show($"Se actualizo el presupuesto {presup.Numero} con exito", "Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    evento(this, EventArgs.Empty);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("No se puedo actualizar su presupuesto ", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            
            
        }

        public void GenerarPresupuesto(Presupuesto oPresupuesto)
        {
            this.presup = oPresupuesto;
            lblPresupuesto.Text += Convert.ToString(presup.Numero);
            txtFecha.Text = presup.Fecha.ToString("dd/MM/yy");
            txtFecha.Enabled = false;
            txtCliente.Enabled = false;
            txtCliente.Text = Convert.ToString(presup.Cliente);
            txtDescuento.Text = Convert.ToString(presup.Descuento);
            txtCantidad.Text = "";
            
            txtTotal.Text = Convert.ToString(presup.CalcularTotal());

            foreach (DetallePresupuesto item in oPresupuesto.Detalles)
            {
                dgvDetalles.Rows.Add(new object[] { item.Producto.Numero, item.Producto.Nombre, item.Producto.Precio, item.Cantidad });
            }
            CalcularTotales();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }  
}
 