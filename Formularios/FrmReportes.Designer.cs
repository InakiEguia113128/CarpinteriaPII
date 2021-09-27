
namespace PrimerProyectoPII.Formularios
{
    partial class FrmReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dTPresupuestoBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new PrimerProyectoPII.Reporters.DataSet1();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTPresupuestoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dTPresupuestoTableAdapter = new PrimerProyectoPII.Reporters.DataSet1TableAdapters.DTPresupuestoTableAdapter();
            this.dTPresupuestoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dTPresupuestoBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTPresupuestoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTPresupuestoBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dTPresupuestoBindingSource2
            // 
            this.dTPresupuestoBindingSource2.DataMember = "DTPresupuesto";
            this.dTPresupuestoBindingSource2.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // dTPresupuestoBindingSource
            // 
            this.dTPresupuestoBindingSource.DataMember = "DTPresupuesto";
            this.dTPresupuestoBindingSource.DataSource = this.dataSet1BindingSource;
            // 
            // dTPresupuestoTableAdapter
            // 
            this.dTPresupuestoTableAdapter.ClearBeforeFill = true;
            // 
            // dTPresupuestoBindingSource1
            // 
            this.dTPresupuestoBindingSource1.DataMember = "DTPresupuesto";
            this.dTPresupuestoBindingSource1.DataSource = this.dataSet1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dTPresupuestoBindingSource2;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PrimerProyectoPII.Reporters.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 576);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 576);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReportes";
            this.Text = "FrmReportes";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dTPresupuestoBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTPresupuestoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dTPresupuestoBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Reporters.DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private System.Windows.Forms.BindingSource dTPresupuestoBindingSource;
        private Reporters.DataSet1TableAdapters.DTPresupuestoTableAdapter dTPresupuestoTableAdapter;
        private System.Windows.Forms.BindingSource dTPresupuestoBindingSource1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dTPresupuestoBindingSource2;
    }
}