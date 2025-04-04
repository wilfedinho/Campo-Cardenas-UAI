using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    internal class EstadoIniciarSesion490WC : Estado490WC
    {
        FormLogin490WC login;
        public override void CerrarEstado()
        {
            login?.Dispose();
        }

        public override void EjecutarEstado()
        {
            login = new FormLogin490WC();
            login.ShowDialog();
        }
    }
}
