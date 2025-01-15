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
        
        public FormMenu()
        {
            InitializeComponent();
            
        }

        private void BT_CERRARSESION_Click(object sender, EventArgs e)
        {
            //RECORDAR CUANDO SE IMPLEMENTE EL SESION MANAGER LIMPIAR LA SESION
            GestorForm.gestorFormSG.DefinirEstado(new EstadoIniciarSesion());
        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            GestorForm.gestorFormSG.DefinirEstado(new EstadoCerrarAplicacion());
        }
    }
}
