using BE;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class SesionManager
    {
        private static SesionManager Instancia;

        public Usuario UsuarioSesion;
        public string IdiomaSesion = "Español";
        public PermisoCompuesto permisosDeLaSesion;

        public void aplicarLenguaje(string nuevoIdioma) 
        {
            Traductor.TraductorSG.Actualizar(nuevoIdioma);
        }

        public static SesionManager GestorSesion
        {
            get 
            {
              if(Instancia == null)
              {
                    Instancia = new SesionManager();
              }
              return Instancia;
            }
        }

        public void Login(Usuario UsuarioLoguear)
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
            PermisoCompuesto permiso = new PermisoCompuesto(permisoSolicitado);
            return permiso.VerificarPermisoIncluido(permisosDeLaSesion, permisoSolicitado);
        }
    }
}
