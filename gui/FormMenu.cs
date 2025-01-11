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
    public partial class FormMenu : Form
    {
        private readonly GestorForm gestorForm;
        public FormMenu(GestorForm NgestorForm)
        {
            InitializeComponent();
            gestorForm = NgestorForm;
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            gestorForm.VolverAlLogin();
        }
    }
}
