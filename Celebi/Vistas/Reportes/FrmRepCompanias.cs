﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace celebi.Vistas.Reportes
{
    public partial class FrmRepCompanias : Form
    {
        public FrmRepCompanias()
        {
            InitializeComponent();
        }

        private void FrmRepCompanias_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cELEBI_DataSet.Companias' table. You can move, or remove it, as needed.
            this.companiasTableAdapter.FillBy(this.cELEBI_DataSet.Companias);

            this.reportViewer1.RefreshReport();
        }
    }
}
