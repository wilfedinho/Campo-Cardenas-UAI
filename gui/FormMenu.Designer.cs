namespace gui
{
    partial class FormMenu
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
            this.BT_CERRARSESION = new System.Windows.Forms.Button();
            this.LabelRolUsuario = new System.Windows.Forms.Label();
            this.LabelNombreUsuario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BT_CERRARSESION
            // 
            this.BT_CERRARSESION.Location = new System.Drawing.Point(732, 406);
            this.BT_CERRARSESION.Name = "BT_CERRARSESION";
            this.BT_CERRARSESION.Size = new System.Drawing.Size(104, 31);
            this.BT_CERRARSESION.TabIndex = 0;
            this.BT_CERRARSESION.Text = "Cerrar Sesion";
            this.BT_CERRARSESION.UseVisualStyleBackColor = true;
            this.BT_CERRARSESION.Click += new System.EventHandler(this.BT_CERRARSESION_Click);
            // 
            // LabelRolUsuario
            // 
            this.LabelRolUsuario.AutoSize = true;
            this.LabelRolUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRolUsuario.Location = new System.Drawing.Point(295, 122);
            this.LabelRolUsuario.Name = "LabelRolUsuario";
            this.LabelRolUsuario.Size = new System.Drawing.Size(143, 29);
            this.LabelRolUsuario.TabIndex = 52;
            this.LabelRolUsuario.Text = "RolUsuario";
            // 
            // LabelNombreUsuario
            // 
            this.LabelNombreUsuario.AutoSize = true;
            this.LabelNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.3299F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNombreUsuario.Location = new System.Drawing.Point(295, 61);
            this.LabelNombreUsuario.Name = "LabelNombreUsuario";
            this.LabelNombreUsuario.Size = new System.Drawing.Size(197, 29);
            this.LabelNombreUsuario.TabIndex = 53;
            this.LabelNombreUsuario.Text = "NombreUsuario";
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 449);
            this.Controls.Add(this.LabelNombreUsuario);
            this.Controls.Add(this.LabelRolUsuario);
            this.Controls.Add(this.BT_CERRARSESION);
            this.Name = "FormMenu";
            this.Text = "MenuForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMenu_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_CERRARSESION;
        private System.Windows.Forms.Label LabelRolUsuario;
        private System.Windows.Forms.Label LabelNombreUsuario;
    }
}