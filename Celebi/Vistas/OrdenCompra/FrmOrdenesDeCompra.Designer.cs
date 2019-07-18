namespace celebi.Vistas.OrdenCompra
{
    partial class FrmOrdenesDeCompra
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvComp = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbProveedor = new System.Windows.Forms.RadioButton();
            this.rbOrdCompra = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblCostoTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCostoNeto = new System.Windows.Forms.Label();
            this.txtCostoEnvio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnNuevo2 = new System.Windows.Forms.Button();
            this.btnSalir2 = new System.Windows.Forms.Button();
            this.btnActualizar2 = new System.Windows.Forms.Button();
            this.btnGuardar2 = new System.Windows.Forms.Button();
            this.btnEliminar2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbxProveedor = new System.Windows.Forms.ComboBox();
            this.companiasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cELEBI_DataSet = new celebi.CELEBI_DataSet();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFormaEntrega = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCondicionPago = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxSolicitante = new System.Windows.Forms.ComboBox();
            this.dtpFechaSolicitud = new System.Windows.Forms.DateTimePicker();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.empleadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empleadosTableAdapter = new celebi.CELEBI_DataSetTableAdapters.EmpleadosTableAdapter();
            this.cELEBIDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.companiasTableAdapter = new celebi.CELEBI_DataSetTableAdapters.CompaniasTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComp)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.companiasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cELEBI_DataSet)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cELEBIDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(742, 429);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.dgvComp);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(734, 403);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackgroundImage = global::celebi.Properties.Resources.search2;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Location = new System.Drawing.Point(532, 17);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(45, 44);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvComp
            // 
            this.dgvComp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvComp.Location = new System.Drawing.Point(3, 91);
            this.dgvComp.Name = "dgvComp";
            this.dgvComp.Size = new System.Drawing.Size(728, 309);
            this.dgvComp.TabIndex = 2;
            this.dgvComp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvComp_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBusqueda);
            this.groupBox2.Location = new System.Drawing.Point(200, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 63);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Busqueda";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusqueda.Location = new System.Drawing.Point(6, 24);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(297, 20);
            this.txtBusqueda.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbProveedor);
            this.groupBox1.Controls.Add(this.rbOrdCompra);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // rbProveedor
            // 
            this.rbProveedor.AutoSize = true;
            this.rbProveedor.Location = new System.Drawing.Point(111, 25);
            this.rbProveedor.Name = "rbProveedor";
            this.rbProveedor.Size = new System.Drawing.Size(74, 17);
            this.rbProveedor.TabIndex = 1;
            this.rbProveedor.TabStop = true;
            this.rbProveedor.Text = "Proveedor";
            this.rbProveedor.UseVisualStyleBackColor = true;
            // 
            // rbOrdCompra
            // 
            this.rbOrdCompra.AutoSize = true;
            this.rbOrdCompra.Location = new System.Drawing.Point(6, 25);
            this.rbOrdCompra.Name = "rbOrdCompra";
            this.rbOrdCompra.Size = new System.Drawing.Size(93, 17);
            this.rbOrdCompra.TabIndex = 0;
            this.rbOrdCompra.TabStop = true;
            this.rbOrdCompra.Text = "Orden Compra";
            this.rbOrdCompra.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblCostoTotal);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.lblCostoNeto);
            this.tabPage2.Controls.Add(this.txtCostoEnvio);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(734, 403);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edición";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblCostoTotal
            // 
            this.lblCostoTotal.AutoSize = true;
            this.lblCostoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoTotal.Location = new System.Drawing.Point(668, 125);
            this.lblCostoTotal.Name = "lblCostoTotal";
            this.lblCostoTotal.Size = new System.Drawing.Size(45, 24);
            this.lblCostoTotal.TabIndex = 32;
            this.lblCostoTotal.Text = "0.00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(598, 117);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Costo Total:";
            // 
            // lblCostoNeto
            // 
            this.lblCostoNeto.AutoSize = true;
            this.lblCostoNeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoNeto.Location = new System.Drawing.Point(668, 77);
            this.lblCostoNeto.Name = "lblCostoNeto";
            this.lblCostoNeto.Size = new System.Drawing.Size(45, 24);
            this.lblCostoNeto.TabIndex = 30;
            this.lblCostoNeto.Text = "0.00";
            // 
            // txtCostoEnvio
            // 
            this.txtCostoEnvio.Location = new System.Drawing.Point(600, 30);
            this.txtCostoEnvio.Name = "txtCostoEnvio";
            this.txtCostoEnvio.Size = new System.Drawing.Size(113, 20);
            this.txtCostoEnvio.TabIndex = 29;
            this.txtCostoEnvio.Text = "0.00";
            this.txtCostoEnvio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(598, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Costo de Envío:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(598, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Costo Neto:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnNuevo2);
            this.groupBox5.Controls.Add(this.btnSalir2);
            this.groupBox5.Controls.Add(this.btnActualizar2);
            this.groupBox5.Controls.Add(this.btnGuardar2);
            this.groupBox5.Controls.Add(this.btnEliminar2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(3, 334);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(728, 66);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            // 
            // btnNuevo2
            // 
            this.btnNuevo2.BackgroundImage = global::celebi.Properties.Resources.new_2;
            this.btnNuevo2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNuevo2.Location = new System.Drawing.Point(115, 14);
            this.btnNuevo2.Name = "btnNuevo2";
            this.btnNuevo2.Size = new System.Drawing.Size(46, 46);
            this.btnNuevo2.TabIndex = 3;
            this.btnNuevo2.Tag = "Nuevo";
            this.btnNuevo2.UseVisualStyleBackColor = true;
            // 
            // btnSalir2
            // 
            this.btnSalir2.BackgroundImage = global::celebi.Properties.Resources.back;
            this.btnSalir2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSalir2.Location = new System.Drawing.Point(492, 19);
            this.btnSalir2.Name = "btnSalir2";
            this.btnSalir2.Size = new System.Drawing.Size(87, 34);
            this.btnSalir2.TabIndex = 5;
            this.btnSalir2.Tag = "Salir";
            this.btnSalir2.UseVisualStyleBackColor = true;
            // 
            // btnActualizar2
            // 
            this.btnActualizar2.BackgroundImage = global::celebi.Properties.Resources.update;
            this.btnActualizar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnActualizar2.Location = new System.Drawing.Point(308, 13);
            this.btnActualizar2.Name = "btnActualizar2";
            this.btnActualizar2.Size = new System.Drawing.Size(46, 46);
            this.btnActualizar2.TabIndex = 2;
            this.btnActualizar2.Tag = "Actualizar";
            this.btnActualizar2.UseVisualStyleBackColor = true;
            // 
            // btnGuardar2
            // 
            this.btnGuardar2.BackgroundImage = global::celebi.Properties.Resources.save;
            this.btnGuardar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardar2.Location = new System.Drawing.Point(211, 13);
            this.btnGuardar2.Name = "btnGuardar2";
            this.btnGuardar2.Size = new System.Drawing.Size(46, 46);
            this.btnGuardar2.TabIndex = 1;
            this.btnGuardar2.Tag = "Guardar";
            this.btnGuardar2.UseVisualStyleBackColor = true;
            // 
            // btnEliminar2
            // 
            this.btnEliminar2.BackgroundImage = global::celebi.Properties.Resources.delete;
            this.btnEliminar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEliminar2.Location = new System.Drawing.Point(406, 14);
            this.btnEliminar2.Name = "btnEliminar2";
            this.btnEliminar2.Size = new System.Drawing.Size(46, 46);
            this.btnEliminar2.TabIndex = 4;
            this.btnEliminar2.Tag = "Borrar";
            this.btnEliminar2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbxProveedor);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtFormaEntrega);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtCondicionPago);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(351, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(237, 185);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos Proveedor";
            // 
            // cbxProveedor
            // 
            this.cbxProveedor.DataSource = this.companiasBindingSource;
            this.cbxProveedor.DisplayMember = "NombComp";
            this.cbxProveedor.FormattingEnabled = true;
            this.cbxProveedor.Location = new System.Drawing.Point(10, 47);
            this.cbxProveedor.Name = "cbxProveedor";
            this.cbxProveedor.Size = new System.Drawing.Size(218, 21);
            this.cbxProveedor.TabIndex = 18;
            this.cbxProveedor.ValueMember = "IdComp";
            // 
            // companiasBindingSource
            // 
            this.companiasBindingSource.DataMember = "Companias";
            this.companiasBindingSource.DataSource = this.cELEBI_DataSet;
            // 
            // cELEBI_DataSet
            // 
            this.cELEBI_DataSet.DataSetName = "CELEBI_DataSet";
            this.cELEBI_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Forma de Entrega";
            // 
            // txtFormaEntrega
            // 
            this.txtFormaEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFormaEntrega.Location = new System.Drawing.Point(10, 99);
            this.txtFormaEntrega.MaxLength = 75;
            this.txtFormaEntrega.Name = "txtFormaEntrega";
            this.txtFormaEntrega.Size = new System.Drawing.Size(219, 20);
            this.txtFormaEntrega.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Proveedor";
            // 
            // txtCondicionPago
            // 
            this.txtCondicionPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCondicionPago.Location = new System.Drawing.Point(10, 149);
            this.txtCondicionPago.MaxLength = 130;
            this.txtCondicionPago.Name = "txtCondicionPago";
            this.txtCondicionPago.Size = new System.Drawing.Size(218, 20);
            this.txtCondicionPago.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Condicion de Pago";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxSolicitante);
            this.groupBox3.Controls.Add(this.dtpFechaSolicitud);
            this.groupBox3.Controls.Add(this.chkActivo);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtId);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 185);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Orden";
            // 
            // cbxSolicitante
            // 
            this.cbxSolicitante.DataSource = this.empleadosBindingSource;
            this.cbxSolicitante.DisplayMember = "NombreEmp";
            this.cbxSolicitante.FormattingEnabled = true;
            this.cbxSolicitante.Location = new System.Drawing.Point(92, 91);
            this.cbxSolicitante.Name = "cbxSolicitante";
            this.cbxSolicitante.Size = new System.Drawing.Size(232, 21);
            this.cbxSolicitante.TabIndex = 28;
            this.cbxSolicitante.ValueMember = "CodEmp";
            // 
            // dtpFechaSolicitud
            // 
            this.dtpFechaSolicitud.Location = new System.Drawing.Point(92, 60);
            this.dtpFechaSolicitud.Name = "dtpFechaSolicitud";
            this.dtpFechaSolicitud.Size = new System.Drawing.Size(232, 20);
            this.dtpFechaSolicitud.TabIndex = 27;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(92, 162);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(56, 17);
            this.chkActivo.TabIndex = 7;
            this.chkActivo.Text = "Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Solicitante";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Solicitud";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(92, 31);
            this.txtId.MaxLength = 11;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(232, 20);
            this.txtId.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnGuardar,
            this.btnActualizar,
            this.btnEliminar,
            this.btnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(742, 37);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = global::celebi.Properties.Resources.new_2;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(34, 34);
            this.btnNuevo.Text = "Nuevo";
            // 
            // btnGuardar
            // 
            this.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGuardar.Image = global::celebi.Properties.Resources.save;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(34, 34);
            this.btnGuardar.Text = "Guardar";
            // 
            // btnActualizar
            // 
            this.btnActualizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnActualizar.Image = global::celebi.Properties.Resources.update;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(34, 34);
            this.btnActualizar.Text = "Actualizar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Image = global::celebi.Properties.Resources.delete;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(34, 34);
            this.btnEliminar.Text = "Eliminar";
            // 
            // btnSalir
            // 
            this.btnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSalir.Image = global::celebi.Properties.Resources.back;
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(34, 34);
            this.btnSalir.Text = "Salir";
            // 
            // empleadosBindingSource
            // 
            this.empleadosBindingSource.DataMember = "Empleados";
            this.empleadosBindingSource.DataSource = this.cELEBI_DataSet;
            // 
            // empleadosTableAdapter
            // 
            this.empleadosTableAdapter.ClearBeforeFill = true;
            // 
            // cELEBIDataSetBindingSource
            // 
            this.cELEBIDataSetBindingSource.DataSource = this.cELEBI_DataSet;
            this.cELEBIDataSetBindingSource.Position = 0;
            // 
            // companiasTableAdapter
            // 
            this.companiasTableAdapter.ClearBeforeFill = true;
            // 
            // FrmOrdenesDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 466);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmOrdenesDeCompra";
            this.Text = "Ordenes de Compra";
            this.Load += new System.EventHandler(this.FrmOrdenesDeCompra_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComp)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.companiasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cELEBI_DataSet)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empleadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cELEBIDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvComp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbProveedor;
        private System.Windows.Forms.RadioButton rbOrdCompra;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnNuevo2;
        private System.Windows.Forms.Button btnSalir2;
        private System.Windows.Forms.Button btnActualizar2;
        private System.Windows.Forms.Button btnGuardar2;
        private System.Windows.Forms.Button btnEliminar2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtCondicionPago;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.TextBox txtFormaEntrega;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.ComboBox cbxProveedor;
        private System.Windows.Forms.ComboBox cbxSolicitante;
        private System.Windows.Forms.DateTimePicker dtpFechaSolicitud;
        private System.Windows.Forms.Label lblCostoTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCostoNeto;
        private System.Windows.Forms.TextBox txtCostoEnvio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private CELEBI_DataSet cELEBI_DataSet;
        private System.Windows.Forms.BindingSource empleadosBindingSource;
        private CELEBI_DataSetTableAdapters.EmpleadosTableAdapter empleadosTableAdapter;
        private System.Windows.Forms.BindingSource cELEBIDataSetBindingSource;
        private System.Windows.Forms.BindingSource companiasBindingSource;
        private CELEBI_DataSetTableAdapters.CompaniasTableAdapter companiasTableAdapter;
    }
}