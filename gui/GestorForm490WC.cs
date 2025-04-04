using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gui
{
    public class GestorForm490WC
    {
        private static GestorForm490WC instance;
        private Estado490WC estadoGestor = new EstadoIniciarSesion490WC();
        public static GestorForm490WC gestorFormSG
        {
            get
            {
                if (instance == null) 
                {
                    instance = new GestorForm490WC(); 
                }
                return instance;
            }
        }
        public void DefinirEstado(Estado490WC estadoNuevo)
        {
            estadoGestor?.CerrarEstado();
            estadoGestor = estadoNuevo;
            estadoGestor.EjecutarEstado();
        }
    }
}
