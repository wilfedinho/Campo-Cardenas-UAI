namespace gui
{
    partial class FormPermisos
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
            this.CB_Familias = new System.Windows.Forms.ComboBox();
            this.BT_ElimiarSeleccionado = new System.Windows.Forms.Button();
            this.BT_ModificarNombre = new System.Windows.Forms.Button();
            this.BT_CrearRol = new System.Windows.Forms.Button();
            this.BT_CrearGrupoDePermisos = new System.Windows.Forms.Button();
            this.BT_GuardarCambios = new System.Windows.Forms.Button();
            this.TB_NuevoNombre = new System.Windows.Forms.TextBox();
            this.listaPermisos = new System.Windows.Forms.CheckedListBox();
            this.vistaPermisosArbol = new System.Windows.Forms.TreeView();
            this.labelRolyGrupo = new System.Windows.Forms.Label();
            this.labelNuevoNombre = new System.Windows.Forms.Label();
            this.labelPermisosAsignados = new System.Windows.Forms.Label();
            this.labelVista = new System.Windows.Forms.Label();
            this.labelErrorRolSesion = new System.Windows.Forms.Label();
            this.labelErrorPermisoDuplicado = new System.Windows.Forms.Label();
            this.labelPermisoCreado = new System.Windows.Forms.Label();
            this.labelNoSePuedeSeleccionarElRolAdmin = new System.Windows.Forms.Label();
            this.labelDeseaBorrarLaFamilia = new System.Windows.Forms.Label();
            this.labelIngreseElNuevoNombre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CB_Familias
            // 
            this.CB_Familias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.CB_Familias.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CB_Familias.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.CB_Familias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.CB_Familias.FormattingEnabled = true;
            this.CB_Familias.Items.AddRange(new object[] {
            "TROLITA",
            "CHUPAME LA VERGAAAAAAAAAAAAA"});
            this.CB_Familias.Location = new System.Drawing.Point(17, 55);
            this.CB_Familias.Name = "CB_Familias";
            this.CB_Familias.Size = new System.Drawing.Size(215, 27);
            this.CB_Familias.TabIndex = 0;
            this.CB_Familias.SelectedIndexChanged += new System.EventHandler(this.CB_Familias_SelectedIndexChanged);
            // 
            // BT_ElimiarSeleccionado
            // 
            this.BT_ElimiarSeleccionado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_ElimiarSeleccionado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_ElimiarSeleccionado.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_ElimiarSeleccionado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_ElimiarSeleccionado.Location = new System.Drawing.Point(17, 88);
            this.BT_ElimiarSeleccionado.Name = "BT_ElimiarSeleccionado";
            this.BT_ElimiarSeleccionado.Size = new System.Drawing.Size(215, 52);
            this.BT_ElimiarSeleccionado.TabIndex = 1;
            this.BT_ElimiarSeleccionado.Text = "EliminarSeleccionado_TD";
            this.BT_ElimiarSeleccionado.UseVisualStyleBackColor = false;
            this.BT_ElimiarSeleccionado.Click += new System.EventHandler(this.BT_ElimiarSeleccionado_Click);
            // 
            // BT_ModificarNombre
            // 
            this.BT_ModificarNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_ModificarNombre.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_ModificarNombre.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_ModificarNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_ModificarNombre.Location = new System.Drawing.Point(17, 158);
            this.BT_ModificarNombre.Name = "BT_ModificarNombre";
            this.BT_ModificarNombre.Size = new System.Drawing.Size(215, 52);
            this.BT_ModificarNombre.TabIndex = 2;
            this.BT_ModificarNombre.Text = "ModificarNombre_TD";
            this.BT_ModificarNombre.UseVisualStyleBackColor = false;
            this.BT_ModificarNombre.Click += new System.EventHandler(this.BT_ModificarNombre_Click);
            // 
            // BT_CrearRol
            // 
            this.BT_CrearRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_CrearRol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_CrearRol.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_CrearRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_CrearRol.Location = new System.Drawing.Point(13, 295);
            this.BT_CrearRol.Name = "BT_CrearRol";
            this.BT_CrearRol.Size = new System.Drawing.Size(219, 52);
            this.BT_CrearRol.TabIndex = 3;
            this.BT_CrearRol.Text = "CrearRol_TD";
            this.BT_CrearRol.UseVisualStyleBackColor = false;
            this.BT_CrearRol.Click += new System.EventHandler(this.BT_CrearRol_Click);
            // 
            // BT_CrearGrupoDePermisos
            // 
            this.BT_CrearGrupoDePermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_CrearGrupoDePermisos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_CrearGrupoDePermisos.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_CrearGrupoDePermisos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_CrearGrupoDePermisos.Location = new System.Drawing.Point(12, 353);
            this.BT_CrearGrupoDePermisos.Name = "BT_CrearGrupoDePermisos";
            this.BT_CrearGrupoDePermisos.Size = new System.Drawing.Size(220, 52);
            this.BT_CrearGrupoDePermisos.TabIndex = 4;
            this.BT_CrearGrupoDePermisos.Text = "CrearGrupoDePermisos_TD";
            this.BT_CrearGrupoDePermisos.UseVisualStyleBackColor = false;
            this.BT_CrearGrupoDePermisos.Click += new System.EventHandler(this.BT_CrearGrupoDePermisos_Click);
            // 
            // BT_GuardarCambios
            // 
            this.BT_GuardarCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_GuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_GuardarCambios.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_GuardarCambios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_GuardarCambios.Location = new System.Drawing.Point(12, 411);
            this.BT_GuardarCambios.Name = "BT_GuardarCambios";
            this.BT_GuardarCambios.Size = new System.Drawing.Size(220, 52);
            this.BT_GuardarCambios.TabIndex = 5;
            this.BT_GuardarCambios.Text = "GuardarCambios_TD";
            this.BT_GuardarCambios.UseVisualStyleBackColor = false;
            this.BT_GuardarCambios.Click += new System.EventHandler(this.BT_GuardarCambios_Click);
            // 
            // TB_NuevoNombre
            // 
            this.TB_NuevoNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.TB_NuevoNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_NuevoNombre.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.TB_NuevoNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.TB_NuevoNombre.Location = new System.Drawing.Point(17, 262);
            this.TB_NuevoNombre.Name = "TB_NuevoNombre";
            this.TB_NuevoNombre.Size = new System.Drawing.Size(215, 27);
            this.TB_NuevoNombre.TabIndex = 6;
            // 
            // listaPermisos
            // 
            this.listaPermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.listaPermisos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listaPermisos.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.listaPermisos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.listaPermisos.FormattingEnabled = true;
            this.listaPermisos.Location = new System.Drawing.Point(271, 35);
            this.listaPermisos.Name = "listaPermisos";
            this.listaPermisos.Size = new System.Drawing.Size(259, 420);
            this.listaPermisos.TabIndex = 7;
            // 
            // vistaPermisosArbol
            // 
            this.vistaPermisosArbol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(31)))));
            this.vistaPermisosArbol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vistaPermisosArbol.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.vistaPermisosArbol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.vistaPermisosArbol.Location = new System.Drawing.Point(562, 33);
            this.vistaPermisosArbol.Name = "vistaPermisosArbol";
            this.vistaPermisosArbol.Size = new System.Drawing.Size(259, 422);
            this.vistaPermisosArbol.TabIndex = 8;
            // 
            // labelRolyGrupo
            // 
            this.labelRolyGrupo.AutoSize = true;
            this.labelRolyGrupo.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.labelRolyGrupo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.labelRolyGrupo.Location = new System.Drawing.Point(13, 12);
            this.labelRolyGrupo.Name = "labelRolyGrupo";
            this.labelRolyGrupo.Size = new System.Drawing.Size(200, 20);
            this.labelRolyGrupo.TabIndex = 9;
            this.labelRolyGrupo.Text = "labelRolesyGrupos_TD";
            // 
            // labelNuevoNombre
            // 
            this.labelNuevoNombre.AutoSize = true;
            this.labelNuevoNombre.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.labelNuevoNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.labelNuevoNombre.Location = new System.Drawing.Point(17, 239);
            this.labelNuevoNombre.Name = "labelNuevoNombre";
            this.labelNuevoNombre.Size = new System.Drawing.Size(162, 20);
            this.labelNuevoNombre.TabIndex = 10;
            this.labelNuevoNombre.Text = "NuevoNombre_TD";
            // 
            // labelPermisosAsignados
            // 
            this.labelPermisosAsignados.AutoSize = true;
            this.labelPermisosAsignados.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.labelPermisosAsignados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.labelPermisosAsignados.Location = new System.Drawing.Point(267, 12);
            this.labelPermisosAsignados.Name = "labelPermisosAsignados";
            this.labelPermisosAsignados.Size = new System.Drawing.Size(212, 20);
            this.labelPermisosAsignados.TabIndex = 11;
            this.labelPermisosAsignados.Text = "PermisosAsignados_TD";
            // 
            // labelVista
            // 
            this.labelVista.AutoSize = true;
            this.labelVista.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.labelVista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.labelVista.Location = new System.Drawing.Point(558, 12);
            this.labelVista.Name = "labelVista";
            this.labelVista.Size = new System.Drawing.Size(85, 20);
            this.labelVista.TabIndex = 12;
            this.labelVista.Text = "Vista_TD";
            // 
            // labelErrorRolSesion
            // 
            this.labelErrorRolSesion.AutoSize = true;
            this.labelErrorRolSesion.Font = new System.Drawing.Font("Roboto", 8.164948F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorRolSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.labelErrorRolSesion.Location = new System.Drawing.Point(704, 458);
            this.labelErrorRolSesion.Name = "labelErrorRolSesion";
            this.labelErrorRolSesion.Size = new System.Drawing.Size(117, 13);
            this.labelErrorRolSesion.TabIndex = 13;
            this.labelErrorRolSesion.Text = "ErrorRolSesion_TD";
            this.labelErrorRolSesion.Visible = false;
            // 
            // labelErrorPermisoDuplicado
            // 
            this.labelErrorPermisoDuplicado.AutoSize = true;
            this.labelErrorPermisoDuplicado.Font = new System.Drawing.Font("Roboto", 8.164948F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorPermisoDuplicado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.labelErrorPermisoDuplicado.Location = new System.Drawing.Point(641, 471);
            this.labelErrorPermisoDuplicado.Name = "labelErrorPermisoDuplicado";
            this.labelErrorPermisoDuplicado.Size = new System.Drawing.Size(165, 13);
            this.labelErrorPermisoDuplicado.TabIndex = 14;
            this.labelErrorPermisoDuplicado.Text = "ErrorPermisoDuplicado_TD";
            this.labelErrorPermisoDuplicado.Visible = false;
            // 
            // labelPermisoCreado
            // 
            this.labelPermisoCreado.AutoSize = true;
            this.labelPermisoCreado.Font = new System.Drawing.Font("Roboto", 8.164948F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPermisoCreado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.labelPermisoCreado.Location = new System.Drawing.Point(687, 458);
            this.labelPermisoCreado.Name = "labelPermisoCreado";
            this.labelPermisoCreado.Size = new System.Drawing.Size(119, 13);
            this.labelPermisoCreado.TabIndex = 15;
            this.labelPermisoCreado.Text = "PermisoCreado_TD";
            this.labelPermisoCreado.Visible = false;
            // 
            // labelNoSePuedeSeleccionarElRolAdmin
            // 
            this.labelNoSePuedeSeleccionarElRolAdmin.AutoSize = true;
            this.labelNoSePuedeSeleccionarElRolAdmin.Font = new System.Drawing.Font("Roboto", 8.164948F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoSePuedeSeleccionarElRolAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.labelNoSePuedeSeleccionarElRolAdmin.Location = new System.Drawing.Point(588, 458);
            this.labelNoSePuedeSeleccionarElRolAdmin.Name = "labelNoSePuedeSeleccionarElRolAdmin";
            this.labelNoSePuedeSeleccionarElRolAdmin.Size = new System.Drawing.Size(233, 13);
            this.labelNoSePuedeSeleccionarElRolAdmin.TabIndex = 16;
            this.labelNoSePuedeSeleccionarElRolAdmin.Text = "NoSePuedeSeleccionarElRolAdmin_TD";
            this.labelNoSePuedeSeleccionarElRolAdmin.Visible = false;
            // 
            // labelDeseaBorrarLaFamilia
            // 
            this.labelDeseaBorrarLaFamilia.AutoSize = true;
            this.labelDeseaBorrarLaFamilia.Font = new System.Drawing.Font("Roboto", 8.164948F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDeseaBorrarLaFamilia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.labelDeseaBorrarLaFamilia.Location = new System.Drawing.Point(450, 458);
            this.labelDeseaBorrarLaFamilia.Name = "labelDeseaBorrarLaFamilia";
            this.labelDeseaBorrarLaFamilia.Size = new System.Drawing.Size(160, 13);
            this.labelDeseaBorrarLaFamilia.TabIndex = 17;
            this.labelDeseaBorrarLaFamilia.Text = "DeseaBorrarLaFamilia_TD";
            this.labelDeseaBorrarLaFamilia.Visible = false;
            // 
            // labelIngreseElNuevoNombre
            // 
            this.labelIngreseElNuevoNombre.AutoSize = true;
            this.labelIngreseElNuevoNombre.Font = new System.Drawing.Font("Roboto", 8.164948F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIngreseElNuevoNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.labelIngreseElNuevoNombre.Location = new System.Drawing.Point(532, 471);
            this.labelIngreseElNuevoNombre.Name = "labelIngreseElNuevoNombre";
            this.labelIngreseElNuevoNombre.Size = new System.Drawing.Size(166, 13);
            this.labelIngreseElNuevoNombre.TabIndex = 18;
            this.labelIngreseElNuevoNombre.Text = "IngreseElNuevoNombre_TD";
            this.labelIngreseElNuevoNombre.Visible = false;
            // 
            // FormPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(845, 485);
            this.Controls.Add(this.labelIngreseElNuevoNombre);
            this.Controls.Add(this.labelDeseaBorrarLaFamilia);
            this.Controls.Add(this.labelNoSePuedeSeleccionarElRolAdmin);
            this.Controls.Add(this.labelPermisoCreado);
            this.Controls.Add(this.labelErrorPermisoDuplicado);
            this.Controls.Add(this.labelErrorRolSesion);
            this.Controls.Add(this.labelVista);
            this.Controls.Add(this.labelPermisosAsignados);
            this.Controls.Add(this.labelNuevoNombre);
            this.Controls.Add(this.labelRolyGrupo);
            this.Controls.Add(this.vistaPermisosArbol);
            this.Controls.Add(this.listaPermisos);
            this.Controls.Add(this.TB_NuevoNombre);
            this.Controls.Add(this.BT_GuardarCambios);
            this.Controls.Add(this.BT_CrearGrupoDePermisos);
            this.Controls.Add(this.BT_CrearRol);
            this.Controls.Add(this.BT_ModificarNombre);
            this.Controls.Add(this.BT_ElimiarSeleccionado);
            this.Controls.Add(this.CB_Familias);
            this.Name = "FormPermisos";
            this.Text = "FormPermisos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_Familias;
        private System.Windows.Forms.Button BT_ElimiarSeleccionado;
        private System.Windows.Forms.Button BT_ModificarNombre;
        private System.Windows.Forms.Button BT_CrearRol;
        private System.Windows.Forms.Button BT_CrearGrupoDePermisos;
        private System.Windows.Forms.Button BT_GuardarCambios;
        private System.Windows.Forms.TextBox TB_NuevoNombre;
        private System.Windows.Forms.CheckedListBox listaPermisos;
        private System.Windows.Forms.TreeView vistaPermisosArbol;
        private System.Windows.Forms.Label labelRolyGrupo;
        private System.Windows.Forms.Label labelNuevoNombre;
        private System.Windows.Forms.Label labelPermisosAsignados;
        private System.Windows.Forms.Label labelVista;
        private System.Windows.Forms.Label labelErrorRolSesion;
        private System.Windows.Forms.Label labelErrorPermisoDuplicado;
        private System.Windows.Forms.Label labelPermisoCreado;
        private System.Windows.Forms.Label labelNoSePuedeSeleccionarElRolAdmin;
        private System.Windows.Forms.Label labelDeseaBorrarLaFamilia;
        private System.Windows.Forms.Label labelIngreseElNuevoNombre;
    }
}