using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public class GestorForm
    {
        private static GestorForm instance;
        private Estado estadoGestor = new EstadoIniciarSesion();
        public static GestorForm gestorFormSG
        {
            get
            {
                if (instance == null) 
                {
                    instance = new GestorForm(); 
                }
                return instance;
            }
        }
        public void DefinirEstado(Estado estadoNuevo)
        {
            estadoGestor?.CerrarEstado();
            estadoGestor = estadoNuevo;
            estadoGestor.EjecutarEstado();
        }
    }
}
