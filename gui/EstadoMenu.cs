using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    internal class EstadoMenu : Estado
    {
        public override void CambiarEstado()
        {
            GestorForm.gestorFormSG.DefinirEstado(new EstadoIniciarSesion());
        }

        public override void EjecutarEstado()
        {
            CambiarEstado();
            using (FormMenu menu = new FormMenu())
            {

                menu.ShowDialog();
                //menu.Dispose();
            }
            
        }
    }
}
