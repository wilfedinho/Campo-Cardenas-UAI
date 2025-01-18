using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public interface Iabm<T> where T : class
    {
        void Alta(T Entidad);
        void Baja(T Entidad);
        void Modifar(T Entidad);

    }
}
