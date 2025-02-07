namespace gui
{
    partial class FormLogin
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BT_LOGIN = new System.Windows.Forms.Button();
            this.TB_Username = new System.Windows.Forms.TextBox();
            this.TB_Contrasena = new System.Windows.Forms.TextBox();
            this.LABEL_NOMBRE_ABM_USUARIO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BT_LOGIN
            // 
            this.BT_LOGIN.Location = new System.Drawing.Point(145, 252);
            this.BT_LOGIN.Name = "BT_LOGIN";
            this.BT_LOGIN.Size = new System.Drawing.Size(171, 40);
            this.BT_LOGIN.TabIndex = 0;
            this.BT_LOGIN.Text = "Iniciar Sesion";
            this.BT_LOGIN.UseVisualStyleBackColor = true;
            this.BT_LOGIN.Click += new System.EventHandler(this.BT_LOGIN_Click);
            // 
            // TB_Username
            // 
            this.TB_Username.Location = new System.Drawing.Point(145, 142);
            this.TB_Username.Name = "TB_Username";
            this.TB_Username.Size = new System.Drawing.Size(171, 20);
            this.TB_Username.TabIndex = 3;
            // 
            // TB_Contrasena
            // 
            this.TB_Contrasena.Location = new System.Drawing.Point(145, 216);
            this.TB_Contrasena.Name = "TB_Contrasena";
            this.TB_Contrasena.PasswordChar = '*';
            this.TB_Contrasena.Size = new System.Drawing.Size(171, 20);
            this.TB_Contrasena.TabIndex = 4;
            // 
            // LABEL_NOMBRE_ABM_USUARIO
            // 
            this.LABEL_NOMBRE_ABM_USUARIO.AutoSize = true;
            this.LABEL_NOMBRE_ABM_USUARIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_NOMBRE_ABM_USUARIO.Location = new System.Drawing.Point(131, 35);
            this.LABEL_NOMBRE_ABM_USUARIO.Name = "LABEL_NOMBRE_ABM_USUARIO";
            this.LABEL_NOMBRE_ABM_USUARIO.Size = new System.Drawing.Size(209, 29);
            this.LABEL_NOMBRE_ABM_USUARIO.TabIndex = 52;
            this.LABEL_NOMBRE_ABM_USUARIO.Text = "INICIAR SESION";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(182, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 29);
            this.label1.TabIndex = 53;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(161, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 29);
            this.label2.TabIndex = 54;
            this.label2.Text = "Contraseña";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 344);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LABEL_NOMBRE_ABM_USUARIO);
            this.Controls.Add(this.TB_Contrasena);
            this.Controls.Add(this.TB_Username);
            this.Controls.Add(this.BT_LOGIN);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogin_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_LOGIN;
        private System.Windows.Forms.TextBox TB_Username;
        private System.Windows.Forms.TextBox TB_Contrasena;
        private System.Windows.Forms.Label LABEL_NOMBRE_ABM_USUARIO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

