using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    internal class EstadoCerrarAplicacion : Estado
    {
        public override void CerrarEstado()
        {
            
        }

        public override void EjecutarEstado()
        {
            Environment.Exit(0);
        }
    }
}
