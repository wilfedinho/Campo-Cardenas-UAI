using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public interface Iabm490WC<T> where T : class
    {
        void Alta490WC(T Entidad);
        void Baja490WC(T Entidad);
        void Modificar490WC(T Entidad);

    }
}
