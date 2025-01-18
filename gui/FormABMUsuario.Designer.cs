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
            this.BT_USUARIO_MODIFICAR = new System.Windows.Forms.Button();
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.ID_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APELLIDO_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CONTRASENA_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROL_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTENTOS_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISBLOQUEADO_USUARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_ALTA_USUARIO
            // 
            this.BT_ALTA_USUARIO.Location = new System.Drawing.Point(60, 217);
            this.BT_ALTA_USUARIO.Name = "BT_ALTA_USUARIO";
            this.BT_ALTA_USUARIO.Size = new System.Drawing.Size(90, 44);
            this.BT_ALTA_USUARIO.TabIndex = 0;
            this.BT_ALTA_USUARIO.Text = "Alta";
            this.BT_ALTA_USUARIO.UseVisualStyleBackColor = true;
            this.BT_ALTA_USUARIO.Click += new System.EventHandler(this.BT_ALTA_USUARIO_Click);
            // 
            // BT_BAJA_USUARIO
            // 
            this.BT_BAJA_USUARIO.Location = new System.Drawing.Point(168, 217);
            this.BT_BAJA_USUARIO.Name = "BT_BAJA_USUARIO";
            this.BT_BAJA_USUARIO.Size = new System.Drawing.Size(90, 44);
            this.BT_BAJA_USUARIO.TabIndex = 1;
            this.BT_BAJA_USUARIO.Text = "Baja";
            this.BT_BAJA_USUARIO.UseVisualStyleBackColor = true;
            this.BT_BAJA_USUARIO.Click += new System.EventHandler(this.BT_BAJA_USUARIO_Click);
            // 
            // BT_USUARIO_MODIFICAR
            // 
            this.BT_USUARIO_MODIFICAR.Location = new System.Drawing.Point(277, 217);
            this.BT_USUARIO_MODIFICAR.Name = "BT_USUARIO_MODIFICAR";
            this.BT_USUARIO_MODIFICAR.Size = new System.Drawing.Size(90, 44);
            this.BT_USUARIO_MODIFICAR.TabIndex = 2;
            this.BT_USUARIO_MODIFICAR.Text = "Modificar";
            this.BT_USUARIO_MODIFICAR.UseVisualStyleBackColor = true;
            this.BT_USUARIO_MODIFICAR.Click += new System.EventHandler(this.BT_USUARIO_MODIFICAR_Click);
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.AllowUserToAddRows = false;
            this.dgvUsuario.AllowUserToDeleteRows = false;
            this.dgvUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_USUARIO,
            this.NOMBRE_USUARIO,
            this.APELLIDO_USUARIO,
            this.DNI_USUARIO,
            this.CONTRASENA_USUARIO,
            this.EMAIL_USUARIO,
            this.ROL_USUARIO,
            this.INTENTOS_USUARIO,
            this.ISBLOQUEADO_USUARIO});
            this.dgvUsuario.Location = new System.Drawing.Point(58, 35);
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.ReadOnly = true;
            this.dgvUsuario.Size = new System.Drawing.Size(927, 159);
            this.dgvUsuario.TabIndex = 3;
            // 
            // ID_USUARIO
            // 
            this.ID_USUARIO.HeaderText = "ID";
            this.ID_USUARIO.Name = "ID_USUARIO";
            this.ID_USUARIO.ReadOnly = true;
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
            // CONTRASENA_USUARIO
            // 
            this.CONTRASENA_USUARIO.HeaderText = "Contraseña";
            this.CONTRASENA_USUARIO.Name = "CONTRASENA_USUARIO";
            this.CONTRASENA_USUARIO.ReadOnly = true;
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
            // INTENTOS_USUARIO
            // 
            this.INTENTOS_USUARIO.HeaderText = "Intentos";
            this.INTENTOS_USUARIO.Name = "INTENTOS_USUARIO";
            this.INTENTOS_USUARIO.ReadOnly = true;
            // 
            // ISBLOQUEADO_USUARIO
            // 
            this.ISBLOQUEADO_USUARIO.HeaderText = "Bloqueado";
            this.ISBLOQUEADO_USUARIO.Name = "ISBLOQUEADO_USUARIO";
            this.ISBLOQUEADO_USUARIO.ReadOnly = true;
            // 
            // FormABMUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 462);
            this.Controls.Add(this.dgvUsuario);
            this.Controls.Add(this.BT_USUARIO_MODIFICAR);
            this.Controls.Add(this.BT_BAJA_USUARIO);
            this.Controls.Add(this.BT_ALTA_USUARIO);
            this.Name = "FormABMUsuario";
            this.Text = "FormABMUsuario";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_ALTA_USUARIO;
        private System.Windows.Forms.Button BT_BAJA_USUARIO;
        private System.Windows.Forms.Button BT_USUARIO_MODIFICAR;
        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn APELLIDO_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CONTRASENA_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTENTOS_USUARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBLOQUEADO_USUARIO;
    }
}