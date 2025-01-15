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
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 449);
            this.Controls.Add(this.BT_CERRARSESION);
            this.Name = "FormMenu";
            this.Text = "MenuForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMenu_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_CERRARSESION;
    }
}