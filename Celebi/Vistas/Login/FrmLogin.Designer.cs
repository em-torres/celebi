namespace celebi
{
    partial class FrmLogin
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
            this.GrpLogin = new System.Windows.Forms.GroupBox();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.LblClave = new System.Windows.Forms.Label();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.GrpLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GrpLogin
            // 
            this.GrpLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpLogin.Controls.Add(this.pictureBox1);
            this.GrpLogin.Controls.Add(this.BtnAceptar);
            this.GrpLogin.Controls.Add(this.BtnCerrar);
            this.GrpLogin.Controls.Add(this.TxtClave);
            this.GrpLogin.Controls.Add(this.TxtUsuario);
            this.GrpLogin.Controls.Add(this.LblClave);
            this.GrpLogin.Controls.Add(this.LblUsuario);
            this.GrpLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GrpLogin.Location = new System.Drawing.Point(12, 12);
            this.GrpLogin.Name = "GrpLogin";
            this.GrpLogin.Size = new System.Drawing.Size(367, 183);
            this.GrpLogin.TabIndex = 0;
            this.GrpLogin.TabStop = false;
            this.GrpLogin.Text = "AUTENTICACION DE USUARIO";
            // 
            // TxtClave
            // 
            this.TxtClave.Location = new System.Drawing.Point(68, 69);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.Size = new System.Drawing.Size(167, 20);
            this.TxtClave.TabIndex = 3;
            this.TxtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtClave_KeyPress);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Location = new System.Drawing.Point(68, 35);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(167, 20);
            this.TxtUsuario.TabIndex = 2;
            this.TxtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUsuario_KeyPress);
            // 
            // LblClave
            // 
            this.LblClave.AutoSize = true;
            this.LblClave.Location = new System.Drawing.Point(6, 76);
            this.LblClave.Name = "LblClave";
            this.LblClave.Size = new System.Drawing.Size(41, 13);
            this.LblClave.TabIndex = 1;
            this.LblClave.Text = "CLAVE";
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Location = new System.Drawing.Point(6, 42);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(56, 13);
            this.LblUsuario.TabIndex = 0;
            this.LblUsuario.Text = "USUARIO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::celebi.Properties.Resources.keys;
            this.pictureBox1.Location = new System.Drawing.Point(283, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAceptar.BackgroundImage = global::celebi.Properties.Resources.accept;
            this.BtnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnAceptar.FlatAppearance.BorderSize = 0;
            this.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAceptar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnAceptar.Location = new System.Drawing.Point(19, 117);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(66, 60);
            this.BtnAceptar.TabIndex = 5;
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar.BackgroundImage = global::celebi.Properties.Resources.cancel;
            this.BtnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnCerrar.Location = new System.Drawing.Point(283, 117);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(66, 60);
            this.BtnCerrar.TabIndex = 4;
            this.BtnCerrar.UseVisualStyleBackColor = true;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(391, 207);
            this.Controls.Add(this.GrpLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.GrpLogin.ResumeLayout(false);
            this.GrpLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpLogin;
        private System.Windows.Forms.Label LblClave;
        private System.Windows.Forms.Label LblUsuario;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

