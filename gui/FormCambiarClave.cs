using BLL;
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
    public partial class FormCambiarClave : Form
    {
        UsuarioBLL GestorUsuario;
        public FormCambiarClave()
        {
            InitializeComponent();
            GestorUsuario = new UsuarioBLL();
        }

        private void BT_ADMINISTRAR_Click(object sender, EventArgs e)
        {
            if (GestorUsuario.VerificarCambioClave(TB_ClaveNueva.Text,TB_ConfirmarClave.Text))
            {
                MessageBox.Show("El Cambio de Clave fue exitoso!!");
            }
            else
            {
                MessageBox.Show("Datos ingresados Incorrectos!!!");
            }
        }

        private void FormCambiarClave_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorForm.gestorFormSG.DefinirEstado(new EstadoMenu());
        }
    }
}
