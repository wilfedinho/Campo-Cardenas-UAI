using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    internal class EstadoIniciarSesion490WC : Estado490WC
    {
        FormLogin490WC login490WC;
        public override void CerrarEstado490WC()
        {
            login490WC?.Dispose();
        }

        public override void EjecutarEstado490WC()
        {
            login490WC = new FormLogin490WC();
            login490WC.ShowDialog();
        }
    }
}
