using BE;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class SesionManager490WC
    {
        private static SesionManager490WC Instancia490WC;

        public Usuario490WC UsuarioSesion490WC;
        public string IdiomaSesion490WC = "Español";
        public PermisoCompuesto490WC permisosDeLaSesion490WC;

        public void aplicarLenguaje490WC(string nuevoIdioma490WC) 
        {
            Traductor490WC.TraductorSG490WC.Actualizar490WC(nuevoIdioma490WC);
        }

        public static SesionManager490WC GestorSesion490WC
        {
            get 
            {
              if(Instancia490WC == null)
              {
                    Instancia490WC = new SesionManager490WC();
              }
              return Instancia490WC;
            }
        }

        public void Login490WC(Usuario490WC UsuarioLoguear490WC)
        {
            if(GestorSesion490WC.UsuarioSesion490WC == null)
            {
                GestorSesion490WC.UsuarioSesion490WC = UsuarioLoguear490WC;
                aplicarLenguaje490WC(UsuarioSesion490WC.IdiomaUsuario490WC);
            }
        }
        public void Logout490WC()
        {
            if(GestorSesion490WC.UsuarioSesion490WC != null)
            {
                GestorSesion490WC.UsuarioSesion490WC = null;
            }
        }
    
        public bool SesionTienePermisos490WC(string permisoSolicitado490WC) 
        {
            PermisoCompuesto490WC permiso490WC = new PermisoCompuesto490WC(permisoSolicitado490WC);
            return permiso490WC.VerificarPermisoIncluido490WC(permisosDeLaSesion490WC, permisoSolicitado490WC);
        }
      
    }
}
