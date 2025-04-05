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
        public void AsignarRolSesion490WC(string nuevoRol490WC)
        {
            SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC.Rol490WC = nuevoRol490WC;
            SesionManager490WC.GestorSesion490WC.permisosDeLaSesion490WC = ObtenerPermisoCompuesto490WC(SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC.Rol490WC);
        }
        public bool AgregarPermisoCompuesto490WC(string nombrePermiso490WC, List<string> permisos490WC, bool esRol490WC) 
        {
            Permiso490WC permisoCompuesto490WC = new PermisoCompuesto490WC(nombrePermiso490WC);
            PermisoORM490WC GestorPermiso490WC = PermisoORM490WC.GestorPermisoORM490WC;
            List<Permiso490WC> ListaPermisos490WC = GestorPermiso490WC.LeerPermisosEnArbol490WC();
            foreach(string nomP490WC in permisos490WC) 
            {
                PermisoCompuesto490WC compuesto490WC = (PermisoCompuesto490WC)ListaPermisos490WC.Find(x => x.obtenerPermisoNombre490WC() == nomP490WC);
                if(BuscarPermiso490WC(nombrePermiso490WC,compuesto490WC)) 
                {
                  return false;
                }
            }

            if(GestorPermiso490WC.permisoExiste490WC(nombrePermiso490WC)) 
            {
                return false;
            }
            else 
            {

                GestorPermiso490WC.InsertarPermiso490WC(permisoCompuesto490WC, esRol490WC);
                foreach(string permiso490WC in permisos490WC) 
                {
                    GestorPermiso490WC.InsertarRelacion490WC(nombrePermiso490WC,permiso490WC);
                }
            }

            BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
            GestorBitacora490WC.AltaEvento490WC("Gestion de Permisos","Alta de un Permiso Compuesto",5);
            return true;
        
        }

        public bool BorrarPermiso490WC(string nombrePermiso490WC) 
        {
         
            PermisoORM490WC GestorPermiso490WC = PermisoORM490WC.GestorPermisoORM490WC;
            return GestorPermiso490WC.BorrarPermiso490WC(nombrePermiso490WC);
        }

        public void ModificarPermiso490WC(string nombrePermiso490WC, string nuevoNombrePermiso490WC) 
        {

            PermisoORM490WC GestorPermiso490WC = PermisoORM490WC.GestorPermisoORM490WC;
            if(GestorPermiso490WC.ModificarPermiso490WC(nombrePermiso490WC, nuevoNombrePermiso490WC)) 
            {
                BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
                GestorBitacora490WC.AltaEvento490WC("Gestion de Permiso","Se modifico el nombre de un permiso", 3);
            }
        }

        public bool ModificarPermisoCompuesto490WC(string nombrePermiso490WC,List<string> permisos490WC) 
        {

            Permiso490WC permiso490WC = new PermisoCompuesto490WC(nombrePermiso490WC);
            PermisoORM490WC GestorPermiso490WC = PermisoORM490WC.GestorPermisoORM490WC;
            List<Permiso490WC> Lista490WC = GestorPermiso490WC.LeerPermisosEnArbol490WC();

            foreach (string perm490WC in permisos490WC)
            {

                PermisoCompuesto490WC compuesto490WC = (PermisoCompuesto490WC)Lista490WC.Find(x => x.obtenerPermisoNombre490WC() == perm490WC);
                if (BuscarPermiso490WC(nombrePermiso490WC, compuesto490WC))
                {
                    return false;
                } 
            }
            if(permisos490WC.Contains(nombrePermiso490WC)) 
            {
               return false;
            }
            else 
            {
               GestorPermiso490WC.BorrarRelacion490WC(nombrePermiso490WC);
               foreach(string perm490WC in permisos490WC) 
               {
                    GestorPermiso490WC.InsertarRelacion490WC(nombrePermiso490WC, perm490WC);
               }
               BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
                GestorBitacora490WC.AltaEvento490WC("Gestion de Permisos","Se modifico la estructura de un permiso", 5);
                return true;
            }
        }

        #region Funciones para el Mapeo de Permisos

        public List<Permiso490WC> ObtenerPermisos490WC()
        {
           return PermisoORM490WC.GestorPermisoORM490WC.ObtenerPermisos490WC();
        }

        public List<Permiso490WC> ObtenerPermisosSimples490WC()
        {
            return PermisoORM490WC.GestorPermisoORM490WC.ObtenerPermisosSimples490WC();
        }

        public List<Permiso490WC> ObtenerPermisosCompuestos490WC()
        {
            return PermisoORM490WC.GestorPermisoORM490WC.ObtenerPermisosCompuestos490WC();
        }

        public List<Permiso490WC> ObtenerRoles490WC()
        {
          return PermisoORM490WC.GestorPermisoORM490WC.ObtenerRoles490WC();
        }
        public List<Permiso490WC> ObtenerTodoSinRoles490WC()
        {
           return PermisoORM490WC.GestorPermisoORM490WC.ObtenerTodoSinRoles490WC();
        }
        public List<Permiso490WC> ObtenerPermisosArbol490WC() 
        {
          return PermisoORM490WC.GestorPermisoORM490WC.LeerPermisosEnArbol490WC();
        }
        #endregion


        private bool BuscarPermiso490WC(string nombrePermiso490WC, PermisoCompuesto490WC raiz490WC)
        {
            if (raiz490WC == null)
            {
                return false;
            }

            foreach (var permiso490WC in raiz490WC.PermisosIncluidos490WC())
            {
                if (permiso490WC.obtenerPermisoNombre490WC() == nombrePermiso490WC || (permiso490WC.esCompuesto490WC() && BuscarPermiso490WC(nombrePermiso490WC, (PermisoCompuesto490WC)permiso490WC)))
                {
                    return true;
                }
            }
            return false;
        }

        public PermisoCompuesto490WC ObtenerPermisoCompuesto490WC(string nombreRol490WC) 
        {
            PermisoORM490WC GestorPermiso490WC = PermisoORM490WC.GestorPermisoORM490WC;
            return GestorPermiso490WC.LeerPermisoCompuesto490WC(nombreRol490WC);
        }

        public bool ConfigurarControl490WC(string tag490WC, bool estadoSecundario490WC) 
        {

            if (!estadoSecundario490WC) 
            {
                return false;
            }

            if(tag490WC == null || SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC.Rol490WC == "AdminSistema" || tag490WC == "") 
            {

                return true;
            }
            return SesionManager490WC.GestorSesion490WC.SesionTienePermisos490WC(tag490WC);
        }
    }
}
