using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace gui
{
    public abstract class Estado
    {
        public abstract void CerrarEstado(); 

        public abstract void EjecutarEstado();
    }
}
