using BLL;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public partial class FormCambiarClave490WC : Form ,  iObserverLenguaje490WC
    {
        UsuarioBLL490WC GestorUsuario490WC;
        public FormCambiarClave490WC()
        {
            InitializeComponent();
            GestorUsuario490WC = new UsuarioBLL490WC();
            ActualizarLenguaje490WC();
        }


        public void ActualizarLenguaje490WC()
        {
            RecorrerControles490WC(this);
        }

        public void RecorrerControles490WC(Control control490WC)
        {
            foreach (Control c490WC in control490WC.Controls)
            {
                 if((c490WC is TextBox) == false) 
              
                 c490WC.Text = Traductor490WC.TraductorSG490WC.Traducir490WC(c490WC.Name);

             
                 if (c490WC.HasChildren)
                 {
                     RecorrerControles490WC(c490WC);
                 }
            }
        }

        private void BT_ADMINISTRAR_Click(object sender, EventArgs e)
        {
            if (GestorUsuario490WC.VerificarCambioClave490WC(TB_ClaveNueva.Text,TB_ConfirmarClave.Text))
            {
                MessageBox.Show(labelCambioExitoso.Text);
            }
            else
            {
                MessageBox.Show(labelCambioErroneo.Text);
            }
        }

        private void FormCambiarClave_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }
    }
}
