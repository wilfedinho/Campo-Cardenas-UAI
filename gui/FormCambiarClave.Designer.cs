namespace gui
{
    partial class FormCambiarClave
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
            this.TB_ClaveNueva = new System.Windows.Forms.TextBox();
            this.TB_ConfirmarClave = new System.Windows.Forms.TextBox();
            this.LabelNombreUsuarioa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_ADMINISTRAR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TB_ClaveNueva
            // 
            this.TB_ClaveNueva.Location = new System.Drawing.Point(122, 100);
            this.TB_ClaveNueva.Name = "TB_ClaveNueva";
            this.TB_ClaveNueva.PasswordChar = '*';
            this.TB_ClaveNueva.Size = new System.Drawing.Size(189, 20);
            this.TB_ClaveNueva.TabIndex = 0;
            // 
            // TB_ConfirmarClave
            // 
            this.TB_ConfirmarClave.Location = new System.Drawing.Point(122, 190);
            this.TB_ConfirmarClave.Name = "TB_ConfirmarClave";
            this.TB_ConfirmarClave.PasswordChar = '*';
            this.TB_ConfirmarClave.Size = new System.Drawing.Size(189, 20);
            this.TB_ConfirmarClave.TabIndex = 1;
            // 
            // LabelNombreUsuarioa
            // 
            this.LabelNombreUsuarioa.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNombreUsuarioa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.LabelNombreUsuarioa.Location = new System.Drawing.Point(137, 50);
            this.LabelNombreUsuarioa.Name = "LabelNombreUsuarioa";
            this.LabelNombreUsuarioa.Size = new System.Drawing.Size(267, 29);
            this.LabelNombreUsuarioa.TabIndex = 53;
            this.LabelNombreUsuarioa.Text = "Clave Nueva";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.label1.Location = new System.Drawing.Point(117, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 29);
            this.label1.TabIndex = 54;
            this.label1.Text = "Confirmar Clave";
            // 
            // BT_ADMINISTRAR
            // 
            this.BT_ADMINISTRAR.FlatAppearance.BorderSize = 0;
            this.BT_ADMINISTRAR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_ADMINISTRAR.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BT_ADMINISTRAR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_ADMINISTRAR.Location = new System.Drawing.Point(121, 243);
            this.BT_ADMINISTRAR.Name = "BT_ADMINISTRAR";
            this.BT_ADMINISTRAR.Size = new System.Drawing.Size(190, 50);
            this.BT_ADMINISTRAR.TabIndex = 55;
            this.BT_ADMINISTRAR.Text = "Cambiar Clave";
            this.BT_ADMINISTRAR.UseVisualStyleBackColor = true;
            this.BT_ADMINISTRAR.Click += new System.EventHandler(this.BT_ADMINISTRAR_Click);
            // 
            // FormCambiarClave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 348);
            this.Controls.Add(this.BT_ADMINISTRAR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelNombreUsuarioa);
            this.Controls.Add(this.TB_ConfirmarClave);
            this.Controls.Add(this.TB_ClaveNueva);
            this.Name = "FormCambiarClave";
            this.Text = "FormCambiarClave";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCambiarClave_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_ClaveNueva;
        private System.Windows.Forms.TextBox TB_ConfirmarClave;
        private System.Windows.Forms.Label LabelNombreUsuarioa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_ADMINISTRAR;
    }
}