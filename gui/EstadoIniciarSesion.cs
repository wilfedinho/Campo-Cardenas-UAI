using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    internal class EstadoIniciarSesion : Estado
    {
        FormLogin login;
        public override void CerrarEstado()
        {
            login?.Close();
            login?.Dispose();
            login = null;
        }

        public override void EjecutarEstado()
        {
            using (login = new FormLogin())
            {
                login.ShowDialog();
            }
        }
    }
}
