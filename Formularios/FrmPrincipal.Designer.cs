
namespace PrimerProyectoPII.Formularios
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soporteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.presupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblReloj = new System.Windows.Forms.Label();
            this.hora = new System.Windows.Forms.Timer(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet1 = new PrimerProyectoPII.Reporters.DataSet1();
            this.dTPresupuestoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTPresupuestoTableAdapter = new PrimerProyectoPII.Reporters.DataSet1TableAdapters.DTPresupuestoTableAdapter();
            this.reportesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.presupuestosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.graficosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTPresupuestoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.soporteToolStripMenuItem,
            this.presupuestosToolStripMenuItem,
            this.reportesToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(817, 38);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(95, 34);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.BackColor = System.Drawing.Color.SlateBlue;
            this.salirToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(125, 34);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // soporteToolStripMenuItem
            // 
            this.soporteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenuItem});
            this.soporteToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soporteToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.soporteToolStripMenuItem.Name = "soporteToolStripMenuItem";
            this.soporteToolStripMenuItem.Size = new System.Drawing.Size(97, 34);
            this.soporteToolStripMenuItem.Text = "Soporte";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.BackColor = System.Drawing.Color.SlateBlue;
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem1});
            this.productosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(179, 34);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // consultarToolStripMenuItem1
            // 
            this.consultarToolStripMenuItem1.Name = "consultarToolStripMenuItem1";
            this.consultarToolStripMenuItem1.Size = new System.Drawing.Size(180, 34);
            this.consultarToolStripMenuItem1.Text = "Consultar ";
            // 
            // presupuestosToolStripMenuItem
            // 
            this.presupuestosToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.presupuestosToolStripMenuItem.DoubleClickEnabled = true;
            this.presupuestosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarToolStripMenuItem,
            this.nuevoToolStripMenuItem});
            this.presupuestosToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.presupuestosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.presupuestosToolStripMenuItem.Name = "presupuestosToolStripMenuItem";
            this.presupuestosToolStripMenuItem.Size = new System.Drawing.Size(148, 34);
            this.presupuestosToolStripMenuItem.Text = "Presupuestos";
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.BackColor = System.Drawing.Color.SlateBlue;
            this.consultarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(180, 34);
            this.consultarToolStripMenuItem.Text = "Consultar";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.BackColor = System.Drawing.Color.SlateBlue;
            this.nuevoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(180, 34);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // lblReloj
            // 
            this.lblReloj.AutoSize = true;
            this.lblReloj.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReloj.ForeColor = System.Drawing.Color.SlateBlue;
            this.lblReloj.Location = new System.Drawing.Point(12, 49);
            this.lblReloj.Name = "lblReloj";
            this.lblReloj.Size = new System.Drawing.Size(100, 37);
            this.lblReloj.TabIndex = 1;
            this.lblReloj.Text = "label1";
            // 
            // hora
            // 
            this.hora.Enabled = true;
            this.hora.Tick += new System.EventHandler(this.hora_Tick);
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            this.reportViewer1.IsDocumentMapWidthFixed = true;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(396, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dTPresupuestoBindingSource
            // 
            this.dTPresupuestoBindingSource.DataMember = "DTPresupuesto";
            this.dTPresupuestoBindingSource.DataSource = this.dataSet1;
            // 
            // dTPresupuestoTableAdapter
            // 
            this.dTPresupuestoTableAdapter.ClearBeforeFill = true;
            // 
            // reportesToolStripMenuItem2
            // 
            this.reportesToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.presupuestosToolStripMenuItem1,
            this.graficosToolStripMenuItem});
            this.reportesToolStripMenuItem2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportesToolStripMenuItem2.ForeColor = System.Drawing.SystemColors.Control;
            this.reportesToolStripMenuItem2.ImageTransparentColor = System.Drawing.Color.SlateBlue;
            this.reportesToolStripMenuItem2.Name = "reportesToolStripMenuItem2";
            this.reportesToolStripMenuItem2.Size = new System.Drawing.Size(106, 34);
            this.reportesToolStripMenuItem2.Text = "Reportes";
            // 
            // presupuestosToolStripMenuItem1
            // 
            this.presupuestosToolStripMenuItem1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.presupuestosToolStripMenuItem1.ForeColor = System.Drawing.SystemColors.Control;
            this.presupuestosToolStripMenuItem1.Name = "presupuestosToolStripMenuItem1";
            this.presupuestosToolStripMenuItem1.Size = new System.Drawing.Size(209, 34);
            this.presupuestosToolStripMenuItem1.Text = "Presupuestos";
            this.presupuestosToolStripMenuItem1.Click += new System.EventHandler(this.presupuestosToolStripMenuItem1_Click);
            // 
            // graficosToolStripMenuItem
            // 
            this.graficosToolStripMenuItem.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.graficosToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.graficosToolStripMenuItem.Name = "graficosToolStripMenuItem";
            this.graficosToolStripMenuItem.Size = new System.Drawing.Size(209, 34);
            this.graficosToolStripMenuItem.Text = "Graficos";
            this.graficosToolStripMenuItem.Click += new System.EventHandler(this.graficosToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(817, 450);
            this.Controls.Add(this.lblReloj);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "Principal";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTPresupuestoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soporteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem presupuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.Label lblReloj;
        private System.Windows.Forms.Timer hora;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reporters.DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dTPresupuestoBindingSource;
        private Reporters.DataSet1TableAdapters.DTPresupuestoTableAdapter dTPresupuestoTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem presupuestosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem graficosToolStripMenuItem;
    }
}

