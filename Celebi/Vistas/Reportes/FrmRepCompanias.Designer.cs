﻿namespace celebi.Vistas.Reportes
{
    partial class FrmRepCompanias
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
            this.companiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companiasTableAdapter = new celebi.CELEBI_DataSetTableAdapters.CompaniasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cELEBI_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companiasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DScompanias";
            reportDataSource1.Value = this.companiasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "celebi.Reportes.RepCompanias.rdlc";
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
            // companiasBindingSource
            // 
            this.companiasBindingSource.DataMember = "Companias";
            this.companiasBindingSource.DataSource = this.cELEBI_DataSet;
            // 
            // companiasTableAdapter
            // 
            this.companiasTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRepCompanias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRepCompanias";
            this.Text = "FrmRepCompanias";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRepCompanias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cELEBI_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companiasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private CELEBI_DataSet cELEBI_DataSet;
        private System.Windows.Forms.BindingSource companiasBindingSource;
        private CELEBI_DataSetTableAdapters.CompaniasTableAdapter companiasTableAdapter;
    }
}