using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    internal class EstadoCerrarAplicacion490WC : Estado490WC
    {
        public override void CerrarEstado490WC()
        {
            
        }

        public override void EjecutarEstado490WC()
        {
            Environment.Exit(0);
        }
    }
}
