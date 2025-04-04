using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public interface ISujeto490WC
    {

        void Suscribir(iObserverLenguaje490WC observer);
        void Desuscribir(iObserverLenguaje490WC observer);
        void Notificar();


    }
}
