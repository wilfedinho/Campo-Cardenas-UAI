namespace gui
{
    partial class FormLogin490WC
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
            this.LabelNombreUsuarioa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BT_LOGIN
            // 
            this.BT_LOGIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_LOGIN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_LOGIN.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_LOGIN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_LOGIN.Location = new System.Drawing.Point(145, 252);
            this.BT_LOGIN.Name = "BT_LOGIN";
            this.BT_LOGIN.Size = new System.Drawing.Size(171, 40);
            this.BT_LOGIN.TabIndex = 0;
            this.BT_LOGIN.Text = "Iniciar Sesion";
            this.BT_LOGIN.UseVisualStyleBackColor = false;
            this.BT_LOGIN.Click += new System.EventHandler(this.BT_LOGIN_Click);
            // 
            // TB_Username
            // 
            this.TB_Username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.TB_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_Username.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.TB_Username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.TB_Username.Location = new System.Drawing.Point(145, 142);
            this.TB_Username.Name = "TB_Username";
            this.TB_Username.Size = new System.Drawing.Size(171, 27);
            this.TB_Username.TabIndex = 3;
            // 
            // TB_Contrasena
            // 
            this.TB_Contrasena.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.TB_Contrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_Contrasena.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.TB_Contrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.TB_Contrasena.Location = new System.Drawing.Point(145, 216);
            this.TB_Contrasena.Name = "TB_Contrasena";
            this.TB_Contrasena.PasswordChar = '*';
            this.TB_Contrasena.Size = new System.Drawing.Size(171, 27);
            this.TB_Contrasena.TabIndex = 4;
            // 
            // LabelNombreUsuarioa
            // 
            this.LabelNombreUsuarioa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.04124F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNombreUsuarioa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.LabelNombreUsuarioa.Location = new System.Drawing.Point(139, 29);
            this.LabelNombreUsuarioa.Name = "LabelNombreUsuarioa";
            this.LabelNombreUsuarioa.Size = new System.Drawing.Size(200, 29);
            this.LabelNombreUsuarioa.TabIndex = 55;
            this.LabelNombreUsuarioa.Text = "Iniciar Sesion";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.label1.Location = new System.Drawing.Point(190, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 29);
            this.label1.TabIndex = 56;
            this.label1.Text = "Clave";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.label2.Location = new System.Drawing.Point(179, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 29);
            this.label2.TabIndex = 57;
            this.label2.Text = "Usuario";
            // 
            // FormLogin490WC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(496, 344);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelNombreUsuarioa);
            this.Controls.Add(this.TB_Contrasena);
            this.Controls.Add(this.TB_Username);
            this.Controls.Add(this.BT_LOGIN);
            this.Name = "FormLogin490WC";
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLogin_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_LOGIN;
        private System.Windows.Forms.TextBox TB_Username;
        private System.Windows.Forms.TextBox TB_Contrasena;
        private System.Windows.Forms.Label LabelNombreUsuarioa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

