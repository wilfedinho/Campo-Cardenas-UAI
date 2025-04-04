using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    internal class EstadoMenu490WC : Estado490WC
    {
        FormMenu490WC menu;
        public override void CerrarEstado()
        {
            menu?.Dispose();
        }

        public override void EjecutarEstado()
        {
            menu = new FormMenu490WC();
            menu.ShowDialog();
        }
    }
}
