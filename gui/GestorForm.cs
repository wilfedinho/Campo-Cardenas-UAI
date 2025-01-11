using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public class GestorForm
    {
        private Form FormActual;
        public void Iniciar()
        {
            MostrarLoginForm();
        }
        private void MostrarLoginForm()
        {
            FormActual?.Dispose();
            FormActual = null;
            FormActual = new FormLogin(this);
            FormActual.Show();
        }
        public void LoginExitoso()
        {
            MostrarMenuForm();
        }
        public void MostrarMenuForm()
        {
            using (FormMenu menu = new FormMenu(this))
            {
                this.FormActual?.Close();
                menu.ShowDialog();

            }
            MostrarLoginForm();
        }
        public void VolverAlLogin()
        {
            MostrarLoginForm();
        }
        public void CerrarAplicacion()
        {
            FormActual?.Dispose();
            FormActual = null;
            Application.Exit();
        }

    }
}
