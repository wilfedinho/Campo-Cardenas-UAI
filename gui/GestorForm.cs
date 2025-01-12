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
            using(FormLogin login = new FormLogin(this)) //Implementar Singleton
            {
                login.ShowDialog();                      //ESTA LINEA DE CODIGO SIGUE EJECUTANDOSE MIENTRAS EL FORM ESTÉ ACTIVO
                if(login.DevolverEstadoLogin() == false)
                {
                    Environment.Exit(0);
                }
                else
                {
                    MostrarMenuForm();
                }
            }
        }
        public void MostrarMenuForm()
        {
            using (FormMenu menu = new FormMenu(this))
            {
                
                menu.ShowDialog();
                menu.Dispose();
            }
            MostrarLoginForm();
        }
    }
}
