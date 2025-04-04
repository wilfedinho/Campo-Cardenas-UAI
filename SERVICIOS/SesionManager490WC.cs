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
        private static SesionManager490WC Instancia;

        public Usuario490WC UsuarioSesion;
        public string IdiomaSesion = "Español";
        public PermisoCompuesto490WC permisosDeLaSesion;

        public void aplicarLenguaje(string nuevoIdioma) 
        {
            Traductor490WC.TraductorSG.Actualizar(nuevoIdioma);
        }

        public static SesionManager490WC GestorSesion
        {
            get 
            {
              if(Instancia == null)
              {
                    Instancia = new SesionManager490WC();
              }
              return Instancia;
            }
        }

        public void Login(Usuario490WC UsuarioLoguear)
        {
            if(GestorSesion.UsuarioSesion == null)
            {
                GestorSesion.UsuarioSesion = UsuarioLoguear;
                aplicarLenguaje(UsuarioSesion.IdiomaUsuario);
               
            }
        }
        public void Logout()
        {
            if(GestorSesion.UsuarioSesion != null)
            {
                GestorSesion.UsuarioSesion = null;
            }
        }
    
        public bool SesionTienePermisos(string permisoSolicitado) 
        {
            PermisoCompuesto490WC permiso = new PermisoCompuesto490WC(permisoSolicitado);
            return permiso.VerificarPermisoIncluido(permisosDeLaSesion, permisoSolicitado);
        }
      
    }
}
