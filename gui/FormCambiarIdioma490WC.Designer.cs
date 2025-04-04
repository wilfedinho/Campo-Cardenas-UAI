namespace gui
{
    partial class FormCambiarIdioma490WC
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
            this.CB_IdiomasDisponibles = new System.Windows.Forms.ComboBox();
            this.labelIdiomaActual = new System.Windows.Forms.Label();
            this.labelIdiomasDisponibles = new System.Windows.Forms.Label();
            this.BT_CambiarIdioma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CB_IdiomasDisponibles
            // 
            this.CB_IdiomasDisponibles.FormattingEnabled = true;
            this.CB_IdiomasDisponibles.Location = new System.Drawing.Point(88, 181);
            this.CB_IdiomasDisponibles.Name = "CB_IdiomasDisponibles";
            this.CB_IdiomasDisponibles.Size = new System.Drawing.Size(221, 21);
            this.CB_IdiomasDisponibles.TabIndex = 58;
            // 
            // labelIdiomaActual
            // 
            this.labelIdiomaActual.AutoSize = true;
            this.labelIdiomaActual.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.labelIdiomaActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.labelIdiomaActual.Location = new System.Drawing.Point(71, 63);
            this.labelIdiomaActual.Name = "labelIdiomaActual";
            this.labelIdiomaActual.Size = new System.Drawing.Size(154, 20);
            this.labelIdiomaActual.TabIndex = 62;
            this.labelIdiomaActual.Text = "TD_IdiomaActual";
            // 
            // labelIdiomasDisponibles
            // 
            this.labelIdiomasDisponibles.AutoSize = true;
            this.labelIdiomasDisponibles.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.labelIdiomasDisponibles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.labelIdiomasDisponibles.Location = new System.Drawing.Point(99, 120);
            this.labelIdiomasDisponibles.Name = "labelIdiomasDisponibles";
            this.labelIdiomasDisponibles.Size = new System.Drawing.Size(210, 20);
            this.labelIdiomasDisponibles.TabIndex = 63;
            this.labelIdiomasDisponibles.Text = "TD_IdiomasDisponibles";
            // 
            // BT_CambiarIdioma
            // 
            this.BT_CambiarIdioma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(6)))), ((int)(((byte)(13)))));
            this.BT_CambiarIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BT_CambiarIdioma.Font = new System.Drawing.Font("Roboto", 11.87629F, System.Drawing.FontStyle.Bold);
            this.BT_CambiarIdioma.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.BT_CambiarIdioma.Location = new System.Drawing.Point(88, 224);
            this.BT_CambiarIdioma.Name = "BT_CambiarIdioma";
            this.BT_CambiarIdioma.Size = new System.Drawing.Size(221, 44);
            this.BT_CambiarIdioma.TabIndex = 64;
            this.BT_CambiarIdioma.Text = "TD_CambiarIdioma";
            this.BT_CambiarIdioma.UseVisualStyleBackColor = false;
            this.BT_CambiarIdioma.Click += new System.EventHandler(this.BT_CambiarIdioma_Click);
            // 
            // FormCambiarIdioma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(412, 357);
            this.Controls.Add(this.BT_CambiarIdioma);
            this.Controls.Add(this.labelIdiomasDisponibles);
            this.Controls.Add(this.labelIdiomaActual);
            this.Controls.Add(this.CB_IdiomasDisponibles);
            this.Name = "FormCambiarIdioma";
            this.Text = "FormCambiarIdioma";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormCambiarIdioma_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_IdiomasDisponibles;
        private System.Windows.Forms.Label labelIdiomaActual;
        private System.Windows.Forms.Label labelIdiomasDisponibles;
        private System.Windows.Forms.Button BT_CambiarIdioma;
    }
}