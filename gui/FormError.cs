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
    public partial class FormError : Form
    {
        public FormError()
        {
            InitializeComponent();
        }

        private void FormError_FormClosed(object sender, FormClosedEventArgs e)
        {
            GestorForm.gestorFormSG.DefinirEstado(new EstadoCerrarAplicacion());
        }
    }
}
