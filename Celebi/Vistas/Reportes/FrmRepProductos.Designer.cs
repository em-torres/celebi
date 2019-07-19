namespace celebi.Vistas.Reportes
{
    partial class FrmRepProductos
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cELEBI_DataSet = new celebi.CELEBI_DataSet();
            this.cELEBIDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productosTableAdapter = new celebi.CELEBI_DataSetTableAdapters.ProductosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cELEBI_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cELEBIDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsProductos";
            reportDataSource1.Value = this.productosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "celebi.Reportes.RepProductos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // cELEBI_DataSet
            // 
            this.cELEBI_DataSet.DataSetName = "CELEBI_DataSet";
            this.cELEBI_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cELEBIDataSetBindingSource
            // 
            this.cELEBIDataSetBindingSource.DataSource = this.cELEBI_DataSet;
            this.cELEBIDataSetBindingSource.Position = 0;
            // 
            // productosBindingSource
            // 
            this.productosBindingSource.DataMember = "Productos";
            this.productosBindingSource.DataSource = this.cELEBI_DataSet;
            // 
            // productosTableAdapter
            // 
            this.productosTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRepProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRepProductos";
            this.Text = "FrmRepProductos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRepProductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cELEBI_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cELEBIDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource cELEBIDataSetBindingSource;
        private CELEBI_DataSet cELEBI_DataSet;
        private System.Windows.Forms.BindingSource productosBindingSource;
        private CELEBI_DataSetTableAdapters.ProductosTableAdapter productosTableAdapter;
    }
}