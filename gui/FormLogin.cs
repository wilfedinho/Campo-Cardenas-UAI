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
    public partial class FormLogin : Form
    {
        private readonly GestorForm gestorForm;
        public FormLogin(GestorForm NgestorForm)
        {
            InitializeComponent();
            gestorForm = NgestorForm;
        }

        private void BT_LOGIN_Click(object sender, EventArgs e)
        {
            gestorForm.LoginExitoso();
        }

        private void BT_CERRARAPP_Click(object sender, EventArgs e)
        {
            gestorForm.CerrarAplicacion();
        }
    }
}
