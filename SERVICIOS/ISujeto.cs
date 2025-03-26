using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public interface ISujeto
    {

        void Suscribir(iObserverLenguaje observer);
        void Desuscribir(iObserverLenguaje observer);
        void Notificar();


    }
}
