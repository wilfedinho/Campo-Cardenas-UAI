namespace gui
{
    partial class FormABMUsuario
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
            this.BT_ALTA_USUARIO = new System.Windows.Forms.Button();
            this.BT_BAJA_USUARIO = new System.Windows.Forms.Button();
            this.BT_MODIFICAR_USUARIO = new System.Windows.Forms.Button();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.ID_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APELLIDO_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROL_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISBLOQUEADO_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BT_DESBLOQUEAR_USUARIO = new System.Windows.Forms.Button();
            this.BT_CANCELAR = new System.Windows.Forms.Button();
            this.BT_APLICAR = new System.Windows.Forms.Button();
            this.BT_SALIR = new System.Windows.Forms.Button();
            this.TB_NOMBRE = new System.Windows.Forms.TextBox();
            this.TB_APELLIDO = new System.Windows.Forms.TextBox();
            this.TB_DNI = new System.Windows.Forms.TextBox();
            this.TB_EMAIL = new System.Windows.Forms.TextBox();
            this.LABEL_NOMBRE_ABM_USUARIO = new System.Windows.Forms.Label();
            this.LABEL_APELLIDO_ABM_USUARIO = new System.Windows.Forms.Label();
            this.LABEL_DNI_ABM_USUARIO = new System.Windows.Forms.Label();
            this.LABEL_EMAIL_ABM_USUARIO = new System.Windows.Forms.Label();
            this.LABEL_ROL_ABM_USUARIO = new System.Windows.Forms.Label();
            this.CB_ROL = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Usuario = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_ALTA_USUARIO
            // 
            this.BT_ALTA_USUARIO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_ALTA_USUARIO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_ALTA_USUARIO.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_ALTA_USUARIO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_ALTA_USUARIO.Location = new System.Drawing.Point(794, 277);
            this.BT_ALTA_USUARIO.Name = "BT_ALTA_USUARIO";
            this.BT_ALTA_USUARIO.Size = new System.Drawing.Size(158, 44);
            this.BT_ALTA_USUARIO.TabIndex = 0;
            this.BT_ALTA_USUARIO.Text = "Alta";
            this.BT_ALTA_USUARIO.UseVisualStyleBackColor = false;
            this.BT_ALTA_USUARIO.Click += new System.EventHandler(this.BT_ALTA_USUARIO_Click);
            // 
            // BT_BAJA_USUARIO
            // 
            this.BT_BAJA_USUARIO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_BAJA_USUARIO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_BAJA_USUARIO.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_BAJA_USUARIO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_BAJA_USUARIO.Location = new System.Drawing.Point(794, 327);
            this.BT_BAJA_USUARIO.Name = "BT_BAJA_USUARIO";
            this.BT_BAJA_USUARIO.Size = new System.Drawing.Size(158, 44);
            this.BT_BAJA_USUARIO.TabIndex = 1;
            this.BT_BAJA_USUARIO.Text = "Baja";
            this.BT_BAJA_USUARIO.UseVisualStyleBackColor = false;
            this.BT_BAJA_USUARIO.Click += new System.EventHandler(this.BT_BAJA_USUARIO_Click);
            // 
            // BT_MODIFICAR_USUARIO
            // 
            this.BT_MODIFICAR_USUARIO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_MODIFICAR_USUARIO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_MODIFICAR_USUARIO.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_MODIFICAR_USUARIO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_MODIFICAR_USUARIO.Location = new System.Drawing.Point(630, 277);
            this.BT_MODIFICAR_USUARIO.Name = "BT_MODIFICAR_USUARIO";
            this.BT_MODIFICAR_USUARIO.Size = new System.Drawing.Size(158, 44);
            this.BT_MODIFICAR_USUARIO.TabIndex = 2;
            this.BT_MODIFICAR_USUARIO.Text = "Modificar";
            this.BT_MODIFICAR_USUARIO.UseVisualStyleBackColor = false;
            this.BT_MODIFICAR_USUARIO.Click += new System.EventHandler(this.BT_USUARIO_MODIFICAR_Click);
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.AllowUserToAddRows = false;
            this.dgvUsuario.AllowUserToDeleteRows = false;
            this.dgvUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_USUARIO,
            this.Column1,
            this.NOMBRE_USUARIO,
            this.APELLIDO_USUARIO,
            this.DNI_USUARIO,
            this.EMAIL_USUARIO,
            this.ROL_USUARIO,
            this.ISBLOQUEADO_USUARIO});
            this.dgvUsuario.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvUsuario.Location = new System.Drawing.Point(25, 33);
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.ReadOnly = true;
            this.dgvUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuario.Size = new System.Drawing.Size(927, 238);
            this.dgvUsuario.TabIndex = 3;
            this.dgvUsuario.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsuario_CellMouseClick);
            // 
            // ID_USUARIO
            // 
            this.ID_USUARIO.HeaderText = "ID";
            this.ID_USUARIO.Name = "ID_USUARIO";
            this.ID_USUARIO.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Usuario";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // NOMBRE_USUARIO
            // 
            this.NOMBRE_USUARIO.HeaderText = "Nombre";
            this.NOMBRE_USUARIO.Name = "NOMBRE_USUARIO";
            this.NOMBRE_USUARIO.ReadOnly = true;
            // 
            // APELLIDO_USUARIO
            // 
            this.APELLIDO_USUARIO.HeaderText = "Apellido";
            this.APELLIDO_USUARIO.Name = "APELLIDO_USUARIO";
            this.APELLIDO_USUARIO.ReadOnly = true;
            // 
            // DNI_USUARIO
            // 
            this.DNI_USUARIO.HeaderText = "DNI";
            this.DNI_USUARIO.Name = "DNI_USUARIO";
            this.DNI_USUARIO.ReadOnly = true;
            // 
            // EMAIL_USUARIO
            // 
            this.EMAIL_USUARIO.HeaderText = "Email";
            this.EMAIL_USUARIO.Name = "EMAIL_USUARIO";
            this.EMAIL_USUARIO.ReadOnly = true;
            // 
            // ROL_USUARIO
            // 
            this.ROL_USUARIO.HeaderText = "Rol";
            this.ROL_USUARIO.Name = "ROL_USUARIO";
            this.ROL_USUARIO.ReadOnly = true;
            // 
            // ISBLOQUEADO_USUARIO
            // 
            this.ISBLOQUEADO_USUARIO.HeaderText = "Bloqueado";
            this.ISBLOQUEADO_USUARIO.Name = "ISBLOQUEADO_USUARIO";
            this.ISBLOQUEADO_USUARIO.ReadOnly = true;
            // 
            // BT_DESBLOQUEAR_USUARIO
            // 
            this.BT_DESBLOQUEAR_USUARIO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_DESBLOQUEAR_USUARIO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_DESBLOQUEAR_USUARIO.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_DESBLOQUEAR_USUARIO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_DESBLOQUEAR_USUARIO.Location = new System.Drawing.Point(630, 327);
            this.BT_DESBLOQUEAR_USUARIO.Name = "BT_DESBLOQUEAR_USUARIO";
            this.BT_DESBLOQUEAR_USUARIO.Size = new System.Drawing.Size(158, 44);
            this.BT_DESBLOQUEAR_USUARIO.TabIndex = 4;
            this.BT_DESBLOQUEAR_USUARIO.Text = "Desbloquear";
            this.BT_DESBLOQUEAR_USUARIO.UseVisualStyleBackColor = false;
            this.BT_DESBLOQUEAR_USUARIO.Click += new System.EventHandler(this.BT_DESBLOQUEAR_USUARIO_Click);
            // 
            // BT_CANCELAR
            // 
            this.BT_CANCELAR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_CANCELAR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_CANCELAR.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_CANCELAR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_CANCELAR.Location = new System.Drawing.Point(630, 377);
            this.BT_CANCELAR.Name = "BT_CANCELAR";
            this.BT_CANCELAR.Size = new System.Drawing.Size(158, 44);
            this.BT_CANCELAR.TabIndex = 5;
            this.BT_CANCELAR.Text = "Cancelar";
            this.BT_CANCELAR.UseVisualStyleBackColor = false;
            this.BT_CANCELAR.Click += new System.EventHandler(this.BT_CANCELAR_Click);
            // 
            // BT_APLICAR
            // 
            this.BT_APLICAR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_APLICAR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_APLICAR.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_APLICAR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_APLICAR.Location = new System.Drawing.Point(794, 377);
            this.BT_APLICAR.Name = "BT_APLICAR";
            this.BT_APLICAR.Size = new System.Drawing.Size(158, 44);
            this.BT_APLICAR.TabIndex = 6;
            this.BT_APLICAR.Text = "Aplicar";
            this.BT_APLICAR.UseVisualStyleBackColor = false;
            this.BT_APLICAR.Click += new System.EventHandler(this.BT_APLICAR_Click);
            // 
            // BT_SALIR
            // 
            this.BT_SALIR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_SALIR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_SALIR.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_SALIR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_SALIR.Location = new System.Drawing.Point(631, 427);
            this.BT_SALIR.Name = "BT_SALIR";
            this.BT_SALIR.Size = new System.Drawing.Size(321, 44);
            this.BT_SALIR.TabIndex = 7;
            this.BT_SALIR.Text = "Salir";
            this.BT_SALIR.UseVisualStyleBackColor = false;
            this.BT_SALIR.Click += new System.EventHandler(this.BT_SALIR_Click);
            // 
            // TB_NOMBRE
            // 
            this.TB_NOMBRE.Location = new System.Drawing.Point(140, 311);
            this.TB_NOMBRE.Name = "TB_NOMBRE";
            this.TB_NOMBRE.Size = new System.Drawing.Size(194, 20);
            this.TB_NOMBRE.TabIndex = 47;
            // 
            // TB_APELLIDO
            // 
            this.TB_APELLIDO.Location = new System.Drawing.Point(140, 348);
            this.TB_APELLIDO.Name = "TB_APELLIDO";
            this.TB_APELLIDO.Size = new System.Drawing.Size(194, 20);
            this.TB_APELLIDO.TabIndex = 48;
            // 
            // TB_DNI
            // 
            this.TB_DNI.Location = new System.Drawing.Point(140, 388);
            this.TB_DNI.Name = "TB_DNI";
            this.TB_DNI.Size = new System.Drawing.Size(194, 20);
            this.TB_DNI.TabIndex = 49;
            // 
            // TB_EMAIL
            // 
            this.TB_EMAIL.Location = new System.Drawing.Point(140, 422);
            this.TB_EMAIL.Name = "TB_EMAIL";
            this.TB_EMAIL.Size = new System.Drawing.Size(194, 20);
            this.TB_EMAIL.TabIndex = 50;
            // 
            // LABEL_NOMBRE_ABM_USUARIO
            // 
            this.LABEL_NOMBRE_ABM_USUARIO.AutoSize = true;
            this.LABEL_NOMBRE_ABM_USUARIO.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.LABEL_NOMBRE_ABM_USUARIO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.LABEL_NOMBRE_ABM_USUARIO.Location = new System.Drawing.Point(20, 305);
            this.LABEL_NOMBRE_ABM_USUARIO.Name = "LABEL_NOMBRE_ABM_USUARIO";
            this.LABEL_NOMBRE_ABM_USUARIO.Size = new System.Drawing.Size(77, 20);
            this.LABEL_NOMBRE_ABM_USUARIO.TabIndex = 51;
            this.LABEL_NOMBRE_ABM_USUARIO.Text = "Nombre";
            // 
            // LABEL_APELLIDO_ABM_USUARIO
            // 
            this.LABEL_APELLIDO_ABM_USUARIO.AutoSize = true;
            this.LABEL_APELLIDO_ABM_USUARIO.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.LABEL_APELLIDO_ABM_USUARIO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.LABEL_APELLIDO_ABM_USUARIO.Location = new System.Drawing.Point(20, 341);
            this.LABEL_APELLIDO_ABM_USUARIO.Name = "LABEL_APELLIDO_ABM_USUARIO";
            this.LABEL_APELLIDO_ABM_USUARIO.Size = new System.Drawing.Size(79, 20);
            this.LABEL_APELLIDO_ABM_USUARIO.TabIndex = 52;
            this.LABEL_APELLIDO_ABM_USUARIO.Text = "Apellido";
            // 
            // LABEL_DNI_ABM_USUARIO
            // 
            this.LABEL_DNI_ABM_USUARIO.AutoSize = true;
            this.LABEL_DNI_ABM_USUARIO.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.LABEL_DNI_ABM_USUARIO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.LABEL_DNI_ABM_USUARIO.Location = new System.Drawing.Point(20, 381);
            this.LABEL_DNI_ABM_USUARIO.Name = "LABEL_DNI_ABM_USUARIO";
            this.LABEL_DNI_ABM_USUARIO.Size = new System.Drawing.Size(40, 20);
            this.LABEL_DNI_ABM_USUARIO.TabIndex = 53;
            this.LABEL_DNI_ABM_USUARIO.Text = "DNI";
            // 
            // LABEL_EMAIL_ABM_USUARIO
            // 
            this.LABEL_EMAIL_ABM_USUARIO.AutoSize = true;
            this.LABEL_EMAIL_ABM_USUARIO.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.LABEL_EMAIL_ABM_USUARIO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.LABEL_EMAIL_ABM_USUARIO.Location = new System.Drawing.Point(20, 416);
            this.LABEL_EMAIL_ABM_USUARIO.Name = "LABEL_EMAIL_ABM_USUARIO";
            this.LABEL_EMAIL_ABM_USUARIO.Size = new System.Drawing.Size(56, 20);
            this.LABEL_EMAIL_ABM_USUARIO.TabIndex = 54;
            this.LABEL_EMAIL_ABM_USUARIO.Text = "Email";
            // 
            // LABEL_ROL_ABM_USUARIO
            // 
            this.LABEL_ROL_ABM_USUARIO.AutoSize = true;
            this.LABEL_ROL_ABM_USUARIO.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.LABEL_ROL_ABM_USUARIO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.LABEL_ROL_ABM_USUARIO.Location = new System.Drawing.Point(20, 454);
            this.LABEL_ROL_ABM_USUARIO.Name = "LABEL_ROL_ABM_USUARIO";
            this.LABEL_ROL_ABM_USUARIO.Size = new System.Drawing.Size(36, 20);
            this.LABEL_ROL_ABM_USUARIO.TabIndex = 55;
            this.LABEL_ROL_ABM_USUARIO.Text = "Rol";
            // 
            // CB_ROL
            // 
            this.CB_ROL.FormattingEnabled = true;
            this.CB_ROL.Items.AddRange(new object[] {
            "Admin",
            "Normal"});
            this.CB_ROL.Location = new System.Drawing.Point(140, 461);
            this.CB_ROL.Name = "CB_ROL";
            this.CB_ROL.Size = new System.Drawing.Size(194, 21);
            this.CB_ROL.TabIndex = 56;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.checkBox1.Location = new System.Drawing.Point(364, 282);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(202, 24);
            this.checkBox1.TabIndex = 57;
            this.checkBox1.Text = "Mostrar Bloqueados";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.label1.Location = new System.Drawing.Point(20, 271);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 59;
            this.label1.Text = "Usuario";
            // 
            // TB_Usuario
            // 
            this.TB_Usuario.Location = new System.Drawing.Point(140, 277);
            this.TB_Usuario.Name = "TB_Usuario";
            this.TB_Usuario.Size = new System.Drawing.Size(194, 20);
            this.TB_Usuario.TabIndex = 58;
            // 
            // FormABMUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(963, 488);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_Usuario);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.CB_ROL);
            this.Controls.Add(this.LABEL_ROL_ABM_USUARIO);
            this.Controls.Add(this.LABEL_EMAIL_ABM_USUARIO);
            this.Controls.Add(this.LABEL_DNI_ABM_USUARIO);
            this.Controls.Add(this.LABEL_APELLIDO_ABM_USUARIO);
            this.Controls.Add(this.LABEL_NOMBRE_ABM_USUARIO);
            this.Controls.Add(this.TB_EMAIL);
            this.Controls.Add(this.TB_DNI);
            this.Controls.Add(this.TB_APELLIDO);
            this.Controls.Add(this.TB_NOMBRE);
            this.Controls.Add(this.BT_SALIR);
            this.Controls.Add(this.BT_APLICAR);
            this.Controls.Add(this.BT_CANCELAR);
            this.Controls.Add(this.BT_DESBLOQUEAR_USUARIO);
            this.Controls.Add(this.dgvUsuario);
            this.Controls.Add(this.BT_MODIFICAR_USUARIO);
            this.Controls.Add(this.BT_BAJA_USUARIO);
            this.Controls.Add(this.BT_ALTA_USUARIO);
            this.Name = "FormABMUsuario";
            this.Text = "FormABMUsuario";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormABMUsuario_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_ALTA_USUARIO;
        private System.Windows.Forms.Button BT_BAJA_USUARIO;
        private System.Windows.Forms.Button BT_MODIFICAR_USUARIO;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.Button BT_DESBLOQUEAR_USUARIO;
        private System.Windows.Forms.Button BT_CANCELAR;
        private System.Windows.Forms.Button BT_APLICAR;
        private System.Windows.Forms.Button BT_SALIR;
        private System.Windows.Forms.TextBox TB_NOMBRE;
        private System.Windows.Forms.TextBox TB_APELLIDO;
        private System.Windows.Forms.TextBox TB_DNI;
        private System.Windows.Forms.TextBox TB_EMAIL;
        private System.Windows.Forms.Label LABEL_NOMBRE_ABM_USUARIO;
        private System.Windows.Forms.Label LABEL_APELLIDO_ABM_USUARIO;
        private System.Windows.Forms.Label LABEL_DNI_ABM_USUARIO;
        private System.Windows.Forms.Label LABEL_EMAIL_ABM_USUARIO;
        private System.Windows.Forms.Label LABEL_ROL_ABM_USUARIO;
        private System.Windows.Forms.ComboBox CB_ROL;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn APELLIDO_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBLOQUEADO_USUARIO;
    }
}