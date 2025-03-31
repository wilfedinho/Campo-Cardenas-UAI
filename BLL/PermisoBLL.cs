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
    public class PermisoBLL
    {
        public void AsignarRolSesion(string nuevoRol)
        {
            SesionManager.GestorSesion.UsuarioSesion.Rol = nuevoRol;
            SesionManager.GestorSesion.permisosDeLaSesion = ObtenerPermisoCompuesto(SesionManager.GestorSesion.UsuarioSesion.Rol);
        }
        public bool AgregarPermisoCompuesto(string nombrePermiso, List<string> permisos, bool esRol) 
        {
            Permiso permisoCompuesto = new PermisoCompuesto(nombrePermiso);
            PermisoORM GestorPermiso = PermisoORM.GestorPermisoORM;
            List<Permiso> ListaPermisos = GestorPermiso.LeerPermisosEnArbol();
            foreach(string nomP in permisos) 
            {
                PermisoCompuesto compuesto = (PermisoCompuesto)ListaPermisos.Find(x => x.obtenerPermisoNombre() == nomP);
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

            BitacoraBLL GestorBitacora = new BitacoraBLL();
            GestorBitacora.AltaEvento("Gestion de Permisos","Alta de un Permiso Compuesto",5);
            return true;
        
        }

        public bool BorrarPermiso(string nombrePermiso) 
        {
         
            PermisoORM GestorPermiso = PermisoORM.GestorPermisoORM;
            return GestorPermiso.BorrarPermiso(nombrePermiso);
        }

        public void ModificarPermiso(string nombrePermiso, string nuevoNombrePermiso) 
        {

            PermisoORM GestorPermiso = PermisoORM.GestorPermisoORM;
            if(GestorPermiso.ModificarPermiso(nombrePermiso, nuevoNombrePermiso)) 
            {
                BitacoraBLL GestorBitacora = new BitacoraBLL();
                GestorBitacora.AltaEvento("Gestion de Permiso","Se modifico el nombre de un permiso", 3);
            }
        }

        public bool ModificarPermisoCompuesto(string nombrePermiso,List<string> permisos) 
        {

            Permiso permiso = new PermisoCompuesto(nombrePermiso);
            PermisoORM GestorPermiso = PermisoORM.GestorPermisoORM;
            List<Permiso> Lista = GestorPermiso.LeerPermisosEnArbol();

            foreach (string perm in permisos)
            {

                PermisoCompuesto compuesto = (PermisoCompuesto)Lista.Find(x => x.obtenerPermisoNombre() == perm);
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
               BitacoraBLL GestorBitacora = new BitacoraBLL();
                GestorBitacora.AltaEvento("Gestion de Permisos","Se modifico la estructura de un permiso", 5);
                return true;
            }
        }

        #region Funciones para el Mapeo de Permisos

        public List<Permiso> ObtenerPermisos()
        {
           return PermisoORM.GestorPermisoORM.ObtenerPermisos();
        }

        public List<Permiso> ObtenerPermisosSimples()
        {
            return PermisoORM.GestorPermisoORM.ObtenerPermisosSimples();
        }

        public List<Permiso> ObtenerPermisosCompuestos()
        {
            return PermisoORM.GestorPermisoORM.ObtenerPermisosCompuestos();
        }

        public List<Permiso> ObtenerRoles()
        {
          return PermisoORM.GestorPermisoORM.ObtenerRoles();
        }
        public List<Permiso> ObtenerTodoSinRoles()
        {
           return PermisoORM.GestorPermisoORM.ObtenerTodoSinRoles();
        }
        public List<Permiso> ObtenerPermisosArbol() 
        {
          return PermisoORM.GestorPermisoORM.LeerPermisosEnArbol();
        }
        #endregion


        private bool BuscarPermiso(string nombrePermiso, PermisoCompuesto raiz)
        {
            if (raiz == null)
            {
                return false;
            }

            foreach (var permiso in raiz.PermisosIncluidos())
            {
                if (permiso.obtenerPermisoNombre() == nombrePermiso || (permiso.esCompuesto() && BuscarPermiso(nombrePermiso, (PermisoCompuesto)permiso)))
                {
                    return true;
                }
            }
            return false;
        }

        public PermisoCompuesto ObtenerPermisoCompuesto(string nombreRol) 
        {
            PermisoORM GestorPermiso = PermisoORM.GestorPermisoORM;
            return GestorPermiso.LeerPermisoCompuesto(nombreRol);
        }

        public bool ConfigurarControl(string tag, bool estadoSecundario) 
        {

            if (!estadoSecundario) 
            {
                return false;
            }

            if(tag == null || SesionManager.GestorSesion.UsuarioSesion.Rol == "AdminSistema" || tag == "") 
            {

                return true;
            }
            return SesionManager.GestorSesion.SesionTienePermisos(tag);
        }
    }
}
