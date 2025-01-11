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
            this.BT_CERRARAPP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BT_LOGIN
            // 
            this.BT_LOGIN.Location = new System.Drawing.Point(263, 187);
            this.BT_LOGIN.Name = "BT_LOGIN";
            this.BT_LOGIN.Size = new System.Drawing.Size(171, 40);
            this.BT_LOGIN.TabIndex = 0;
            this.BT_LOGIN.Text = "Iniciar Sesion";
            this.BT_LOGIN.UseVisualStyleBackColor = true;
            this.BT_LOGIN.Click += new System.EventHandler(this.BT_LOGIN_Click);
            // 
            // BT_CERRARAPP
            // 
            this.BT_CERRARAPP.Location = new System.Drawing.Point(263, 278);
            this.BT_CERRARAPP.Name = "BT_CERRARAPP";
            this.BT_CERRARAPP.Size = new System.Drawing.Size(171, 40);
            this.BT_CERRARAPP.TabIndex = 1;
            this.BT_CERRARAPP.Text = "Cerrar Aplicacion";
            this.BT_CERRARAPP.UseVisualStyleBackColor = true;
            this.BT_CERRARAPP.Click += new System.EventHandler(this.BT_CERRARAPP_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 395);
            this.Controls.Add(this.BT_CERRARAPP);
            this.Controls.Add(this.BT_LOGIN);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_LOGIN;
        private System.Windows.Forms.Button BT_CERRARAPP;
    }
}

