namespace gui
{
    partial class FormBitacoraDeEventos
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
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            this.ID_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APELLIDO_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROL_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.CB_Usuario = new System.Windows.Forms.ComboBox();
            this.CB_Descripcion = new System.Windows.Forms.ComboBox();
            this.CB_Modulo = new System.Windows.Forms.ComboBox();
            this.CB_Criticidad = new System.Windows.Forms.ComboBox();
            this.labelCBUsuario = new System.Windows.Forms.Label();
            this.labelCBCriticidad = new System.Windows.Forms.Label();
            this.labelCBDescripcion = new System.Windows.Forms.Label();
            this.labelCBModulo = new System.Windows.Forms.Label();
            this.monthCalendarFechaInicio = new System.Windows.Forms.MonthCalendar();
            this.monthCalendarFechaFin = new System.Windows.Forms.MonthCalendar();
            this.labelFechaInicio = new System.Windows.Forms.Label();
            this.labelFechaFin = new System.Windows.Forms.Label();
            this.BT_Filtrar = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.labelDNI = new System.Windows.Forms.Label();
            this.BT_LimpiarFiltros = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.AllowUserToAddRows = false;
            this.dgvBitacora.AllowUserToDeleteRows = false;
            this.dgvBitacora.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_USUARIO,
            this.NOMBRE_USUARIO,
            this.APELLIDO_USUARIO,
            this.DNI_USUARIO,
            this.EMAIL_USUARIO,
            this.ROL_USUARIO});
            this.dgvBitacora.Location = new System.Drawing.Point(12, 12);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.ReadOnly = true;
            this.dgvBitacora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBitacora.Size = new System.Drawing.Size(956, 238);
            this.dgvBitacora.TabIndex = 4;
            this.dgvBitacora.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBitacora_CellMouseClick);
            // 
            // ID_USUARIO
            // 
            this.ID_USUARIO.HeaderText = "Usuario";
            this.ID_USUARIO.Name = "ID_USUARIO";
            this.ID_USUARIO.ReadOnly = true;
            // 
            // NOMBRE_USUARIO
            // 
            this.NOMBRE_USUARIO.HeaderText = "Fecha";
            this.NOMBRE_USUARIO.Name = "NOMBRE_USUARIO";
            this.NOMBRE_USUARIO.ReadOnly = true;
            // 
            // APELLIDO_USUARIO
            // 
            this.APELLIDO_USUARIO.HeaderText = "Hora";
            this.APELLIDO_USUARIO.Name = "APELLIDO_USUARIO";
            this.APELLIDO_USUARIO.ReadOnly = true;
            // 
            // DNI_USUARIO
            // 
            this.DNI_USUARIO.HeaderText = "Modulo";
            this.DNI_USUARIO.Name = "DNI_USUARIO";
            this.DNI_USUARIO.ReadOnly = true;
            // 
            // EMAIL_USUARIO
            // 
            this.EMAIL_USUARIO.HeaderText = "Descripcion";
            this.EMAIL_USUARIO.Name = "EMAIL_USUARIO";
            this.EMAIL_USUARIO.ReadOnly = true;
            // 
            // ROL_USUARIO
            // 
            this.ROL_USUARIO.HeaderText = "Criticidad";
            this.ROL_USUARIO.Name = "ROL_USUARIO";
            this.ROL_USUARIO.ReadOnly = true;
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(12, 289);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(132, 29);
            this.labelUsuario.TabIndex = 54;
            this.labelUsuario.Text = "Username";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(12, 333);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(107, 29);
            this.labelNombre.TabIndex = 55;
            this.labelNombre.Text = "Nombre";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelApellido.Location = new System.Drawing.Point(12, 375);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(110, 29);
            this.labelApellido.TabIndex = 56;
            this.labelApellido.Text = "Apellido";
            // 
            // CB_Usuario
            // 
            this.CB_Usuario.FormattingEnabled = true;
            this.CB_Usuario.Location = new System.Drawing.Point(272, 276);
            this.CB_Usuario.Name = "CB_Usuario";
            this.CB_Usuario.Size = new System.Drawing.Size(164, 21);
            this.CB_Usuario.TabIndex = 57;
            // 
            // CB_Descripcion
            // 
            this.CB_Descripcion.FormattingEnabled = true;
            this.CB_Descripcion.Location = new System.Drawing.Point(272, 398);
            this.CB_Descripcion.Name = "CB_Descripcion";
            this.CB_Descripcion.Size = new System.Drawing.Size(164, 21);
            this.CB_Descripcion.TabIndex = 58;
            // 
            // CB_Modulo
            // 
            this.CB_Modulo.FormattingEnabled = true;
            this.CB_Modulo.Location = new System.Drawing.Point(272, 341);
            this.CB_Modulo.Name = "CB_Modulo";
            this.CB_Modulo.Size = new System.Drawing.Size(164, 21);
            this.CB_Modulo.TabIndex = 59;
            // 
            // CB_Criticidad
            // 
            this.CB_Criticidad.FormattingEnabled = true;
            this.CB_Criticidad.Location = new System.Drawing.Point(272, 454);
            this.CB_Criticidad.Name = "CB_Criticidad";
            this.CB_Criticidad.Size = new System.Drawing.Size(164, 21);
            this.CB_Criticidad.TabIndex = 60;
            // 
            // labelCBUsuario
            // 
            this.labelCBUsuario.AutoSize = true;
            this.labelCBUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCBUsuario.Location = new System.Drawing.Point(268, 253);
            this.labelCBUsuario.Name = "labelCBUsuario";
            this.labelCBUsuario.Size = new System.Drawing.Size(71, 20);
            this.labelCBUsuario.TabIndex = 61;
            this.labelCBUsuario.Text = "Usuario";
            // 
            // labelCBCriticidad
            // 
            this.labelCBCriticidad.AutoSize = true;
            this.labelCBCriticidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCBCriticidad.Location = new System.Drawing.Point(268, 431);
            this.labelCBCriticidad.Name = "labelCBCriticidad";
            this.labelCBCriticidad.Size = new System.Drawing.Size(84, 20);
            this.labelCBCriticidad.TabIndex = 62;
            this.labelCBCriticidad.Text = "Criticidad";
            // 
            // labelCBDescripcion
            // 
            this.labelCBDescripcion.AutoSize = true;
            this.labelCBDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCBDescripcion.Location = new System.Drawing.Point(268, 375);
            this.labelCBDescripcion.Name = "labelCBDescripcion";
            this.labelCBDescripcion.Size = new System.Drawing.Size(103, 20);
            this.labelCBDescripcion.TabIndex = 63;
            this.labelCBDescripcion.Text = "Descripción";
            // 
            // labelCBModulo
            // 
            this.labelCBModulo.AutoSize = true;
            this.labelCBModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCBModulo.Location = new System.Drawing.Point(268, 313);
            this.labelCBModulo.Name = "labelCBModulo";
            this.labelCBModulo.Size = new System.Drawing.Size(67, 20);
            this.labelCBModulo.TabIndex = 64;
            this.labelCBModulo.Text = "Módulo";
            // 
            // monthCalendarFechaInicio
            // 
            this.monthCalendarFechaInicio.Enabled = false;
            this.monthCalendarFechaInicio.Location = new System.Drawing.Point(448, 289);
            this.monthCalendarFechaInicio.Name = "monthCalendarFechaInicio";
            this.monthCalendarFechaInicio.TabIndex = 67;
            // 
            // monthCalendarFechaFin
            // 
            this.monthCalendarFechaFin.Enabled = false;
            this.monthCalendarFechaFin.Location = new System.Drawing.Point(720, 289);
            this.monthCalendarFechaFin.Name = "monthCalendarFechaFin";
            this.monthCalendarFechaFin.TabIndex = 68;
            // 
            // labelFechaInicio
            // 
            this.labelFechaInicio.AutoSize = true;
            this.labelFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaInicio.Location = new System.Drawing.Point(444, 260);
            this.labelFechaInicio.Name = "labelFechaInicio";
            this.labelFechaInicio.Size = new System.Drawing.Size(107, 20);
            this.labelFechaInicio.TabIndex = 69;
            this.labelFechaInicio.Text = "Fecha Inicio";
            // 
            // labelFechaFin
            // 
            this.labelFechaFin.AutoSize = true;
            this.labelFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFechaFin.Location = new System.Drawing.Point(716, 260);
            this.labelFechaFin.Name = "labelFechaFin";
            this.labelFechaFin.Size = new System.Drawing.Size(89, 20);
            this.labelFechaFin.TabIndex = 70;
            this.labelFechaFin.Text = "Fecha Fin";
            // 
            // BT_Filtrar
            // 
            this.BT_Filtrar.Location = new System.Drawing.Point(505, 454);
            this.BT_Filtrar.Name = "BT_Filtrar";
            this.BT_Filtrar.Size = new System.Drawing.Size(145, 21);
            this.BT_Filtrar.TabIndex = 71;
            this.BT_Filtrar.Text = "Filtrar";
            this.BT_Filtrar.UseVisualStyleBackColor = true;
            this.BT_Filtrar.Click += new System.EventHandler(this.BT_Filtrar_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.649485F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(846, 262);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 20);
            this.checkBox1.TabIndex = 72;
            this.checkBox1.Text = "Incluir Fecha?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDNI.Location = new System.Drawing.Point(12, 422);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(57, 29);
            this.labelDNI.TabIndex = 73;
            this.labelDNI.Text = "DNI";
            // 
            // BT_LimpiarFiltros
            // 
            this.BT_LimpiarFiltros.Location = new System.Drawing.Point(775, 454);
            this.BT_LimpiarFiltros.Name = "BT_LimpiarFiltros";
            this.BT_LimpiarFiltros.Size = new System.Drawing.Size(145, 21);
            this.BT_LimpiarFiltros.TabIndex = 74;
            this.BT_LimpiarFiltros.Text = "Limpiar Filtros";
            this.BT_LimpiarFiltros.UseVisualStyleBackColor = true;
            // 
            // FormBitacoraDeEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 483);
            this.Controls.Add(this.BT_LimpiarFiltros);
            this.Controls.Add(this.labelDNI);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.BT_Filtrar);
            this.Controls.Add(this.labelFechaFin);
            this.Controls.Add(this.labelFechaInicio);
            this.Controls.Add(this.monthCalendarFechaFin);
            this.Controls.Add(this.monthCalendarFechaInicio);
            this.Controls.Add(this.labelCBModulo);
            this.Controls.Add(this.labelCBDescripcion);
            this.Controls.Add(this.labelCBCriticidad);
            this.Controls.Add(this.labelCBUsuario);
            this.Controls.Add(this.CB_Criticidad);
            this.Controls.Add(this.CB_Modulo);
            this.Controls.Add(this.CB_Descripcion);
            this.Controls.Add(this.CB_Usuario);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelUsuario);
            this.Controls.Add(this.dgvBitacora);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.164948F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormBitacoraDeEventos";
            this.Text = "FormBitacoraDeEventos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBitacora;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn APELLIDO_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL_USUARIO;
        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.ComboBox CB_Usuario;
        private System.Windows.Forms.ComboBox CB_Descripcion;
        private System.Windows.Forms.ComboBox CB_Modulo;
        private System.Windows.Forms.ComboBox CB_Criticidad;
        private System.Windows.Forms.Label labelCBUsuario;
        private System.Windows.Forms.Label labelCBCriticidad;
        private System.Windows.Forms.Label labelCBDescripcion;
        private System.Windows.Forms.Label labelCBModulo;
        private System.Windows.Forms.MonthCalendar monthCalendarFechaInicio;
        private System.Windows.Forms.MonthCalendar monthCalendarFechaFin;
        private System.Windows.Forms.Label labelFechaInicio;
        private System.Windows.Forms.Label labelFechaFin;
        private System.Windows.Forms.Button BT_Filtrar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.Button BT_LimpiarFiltros;
    }
}