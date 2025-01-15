using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    internal class EstadoMenu : Estado
    {
        FormMenu menu;
        public override void CerrarEstado()
        {
            menu?.Close();
            menu?.Dispose();
            menu = null;
        }

        public override void EjecutarEstado()
        {
            using (menu = new FormMenu())
            {
              menu.ShowDialog();
            }
        }
    }
}
