using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using BE;
using ORM;
using SERVICIOS;

namespace BLL
{
    public class PermisoBLL490WC
    {
        public void AsignarRolSesion(string nuevoRol)
        {
            SesionManager490WC.GestorSesion.UsuarioSesion.Rol = nuevoRol;
            SesionManager490WC.GestorSesion.permisosDeLaSesion = ObtenerPermisoCompuesto(SesionManager490WC.GestorSesion.UsuarioSesion.Rol);
        }
        public bool AgregarPermisoCompuesto(string nombrePermiso, List<string> permisos, bool esRol) 
        {
            Permiso490WC permisoCompuesto = new PermisoCompuesto490WC(nombrePermiso);
            PermisoORM490WC GestorPermiso = PermisoORM490WC.GestorPermisoORM;
            List<Permiso490WC> ListaPermisos = GestorPermiso.LeerPermisosEnArbol();
            foreach(string nomP in permisos) 
            {
                PermisoCompuesto490WC compuesto = (PermisoCompuesto490WC)ListaPermisos.Find(x => x.obtenerPermisoNombre() == nomP);
                if(BuscarPermiso(nombrePermiso,compuesto)) 
                {
                  return false;
                }
            }

            if(GestorPermiso.permisoExiste(nombrePermiso)) 
            {
                return false;
            }
            else 
            {

                GestorPermiso.InsertarPermiso(permisoCompuesto, esRol);
                foreach(string permiso in permisos) 
                {
                    GestorPermiso.InsertarRelacion(nombrePermiso,permiso);
                }
            }

            BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
            GestorBitacora.AltaEvento("Gestion de Permisos","Alta de un Permiso Compuesto",5);
            return true;
        
        }

        public bool BorrarPermiso(string nombrePermiso) 
        {
         
            PermisoORM490WC GestorPermiso = PermisoORM490WC.GestorPermisoORM;
            return GestorPermiso.BorrarPermiso(nombrePermiso);
        }

        public void ModificarPermiso(string nombrePermiso, string nuevoNombrePermiso) 
        {

            PermisoORM490WC GestorPermiso = PermisoORM490WC.GestorPermisoORM;
            if(GestorPermiso.ModificarPermiso(nombrePermiso, nuevoNombrePermiso)) 
            {
                BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
                GestorBitacora.AltaEvento("Gestion de Permiso","Se modifico el nombre de un permiso", 3);
            }
        }

        public bool ModificarPermisoCompuesto(string nombrePermiso,List<string> permisos) 
        {

            Permiso490WC permiso = new PermisoCompuesto490WC(nombrePermiso);
            PermisoORM490WC GestorPermiso = PermisoORM490WC.GestorPermisoORM;
            List<Permiso490WC> Lista = GestorPermiso.LeerPermisosEnArbol();

            foreach (string perm in permisos)
            {

                PermisoCompuesto490WC compuesto = (PermisoCompuesto490WC)Lista.Find(x => x.obtenerPermisoNombre() == perm);
                if (BuscarPermiso(nombrePermiso, compuesto))
                {
                    return false;
                } 
            }
            if(permisos.Contains(nombrePermiso)) 
            {
               return false;
            }
            else 
            {
               GestorPermiso.BorrarRelacion(nombrePermiso);
               foreach(string perm in permisos) 
               {
                    GestorPermiso.InsertarRelacion(nombrePermiso, perm);
               }
               BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
                GestorBitacora.AltaEvento("Gestion de Permisos","Se modifico la estructura de un permiso", 5);
                return true;
            }
        }

        #region Funciones para el Mapeo de Permisos

        public List<Permiso490WC> ObtenerPermisos()
        {
           return PermisoORM490WC.GestorPermisoORM.ObtenerPermisos();
        }

        public List<Permiso490WC> ObtenerPermisosSimples()
        {
            return PermisoORM490WC.GestorPermisoORM.ObtenerPermisosSimples();
        }

        public List<Permiso490WC> ObtenerPermisosCompuestos()
        {
            return PermisoORM490WC.GestorPermisoORM.ObtenerPermisosCompuestos();
        }

        public List<Permiso490WC> ObtenerRoles()
        {
          return PermisoORM490WC.GestorPermisoORM.ObtenerRoles();
        }
        public List<Permiso490WC> ObtenerTodoSinRoles()
        {
           return PermisoORM490WC.GestorPermisoORM.ObtenerTodoSinRoles();
        }
        public List<Permiso490WC> ObtenerPermisosArbol() 
        {
          return PermisoORM490WC.GestorPermisoORM.LeerPermisosEnArbol();
        }
        #endregion


        private bool BuscarPermiso(string nombrePermiso, PermisoCompuesto490WC raiz)
        {
            if (raiz == null)
            {
                return false;
            }

            foreach (var permiso in raiz.PermisosIncluidos())
            {
                if (permiso.obtenerPermisoNombre() == nombrePermiso || (permiso.esCompuesto() && BuscarPermiso(nombrePermiso, (PermisoCompuesto490WC)permiso)))
                {
                    return true;
                }
            }
            return false;
        }

        public PermisoCompuesto490WC ObtenerPermisoCompuesto(string nombreRol) 
        {
            PermisoORM490WC GestorPermiso = PermisoORM490WC.GestorPermisoORM;
            return GestorPermiso.LeerPermisoCompuesto(nombreRol);
        }

        public bool ConfigurarControl(string tag, bool estadoSecundario) 
        {

            if (!estadoSecundario) 
            {
                return false;
            }

            if(tag == null || SesionManager490WC.GestorSesion.UsuarioSesion.Rol == "AdminSistema" || tag == "") 
            {

                return true;
            }
            return SesionManager490WC.GestorSesion.SesionTienePermisos(tag);
        }
    }
}
