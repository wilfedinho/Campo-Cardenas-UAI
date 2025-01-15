using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gui
{
    internal class EstadoIniciarSesion : Estado
    {
        public override void CambiarEstado()
        {
            GestorForm.gestorFormSG.DefinirEstado(new EstadoMenu());
        }

        public override void EjecutarEstado()
        {
            CambiarEstado();
            using (FormLogin login = new FormLogin()) 
            {
                login.ShowDialog(); //ESTA LINEA DE CODIGO SIGUE EJECUTANDOSE MIENTRAS EL FORM ESTÉ ACTIVO
                //login.Dispose();
            }
            
        }
    }
}
