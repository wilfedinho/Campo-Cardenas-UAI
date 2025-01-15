using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    public class EstadoError : Estado
    {
        public override void CambiarEstado()
        {
            throw new NotImplementedException();
        }

        public override void EjecutarEstado()
        {
            throw new NotImplementedException();
        }
    }
}
