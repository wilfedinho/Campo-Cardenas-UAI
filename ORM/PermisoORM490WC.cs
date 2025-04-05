using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Security.Cryptography.X509Certificates;

namespace ORM
{
    public class PermisoORM490WC
    {
        private static PermisoORM490WC Instancia490WC;
        public static PermisoORM490WC GestorPermisoORM490WC
        {
            get
            {
                if (Instancia490WC == null)
                {
                    Instancia490WC = new PermisoORM490WC();
                }
                return Instancia490WC;
            }
        }
        public List<Permiso490WC> LeerPermisosEnArbol490WC() 
        {
          List<Permiso490WC> ListaPermiso490WC = new List<Permiso490WC>();
          List<Permiso490WC> PermisosCompuestos490WC = new List<Permiso490WC>();
            try
            {
                DataTable tablaPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Permiso490WC");
                DataTable tablaRelacionPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("RelacionPermiso490WC");
                DataView dvPermiso490WC = new DataView(tablaPermiso490WC);
                foreach(DataRowView drv490WC in dvPermiso490WC) 
                {
                    if (drv490WC["tipoPermiso490WC"].ToString() == "Compuesto") 
                    {
                      PermisoCompuesto490WC compuesto490WC = new PermisoCompuesto490WC(drv490WC["nombrePermiso490WC"].ToString());
                      PermisosCompuestos490WC.Add(compuesto490WC);
                      ListaPermiso490WC.Add(compuesto490WC);
                    }
                    else 
                    {
                        PermisoSimple490WC permisoS490WC = new PermisoSimple490WC(drv490WC["nombrePermiso490WC"].ToString());
                        ListaPermiso490WC.Add(permisoS490WC);
                    }
                }
                DataView dvRelacionPermiso490WC = new DataView(tablaRelacionPermiso490WC);
                PermisoCompuesto490WC permisoCompuestoLeido490WC;
                Permiso490WC permisoLeido490WC;
                foreach (DataRowView drv490WC in dvRelacionPermiso490WC) 
                {
                    permisoCompuestoLeido490WC = (PermisoCompuesto490WC)PermisosCompuestos490WC.Find(x => x.obtenerPermisoNombre490WC() == drv490WC["permisoCompuestoNombre490WC"].ToString());
                    permisoLeido490WC = ListaPermiso490WC.Find(x => x.obtenerPermisoNombre490WC() == drv490WC["permisoIncluidoNombre490WC"].ToString());
                    permisoCompuestoLeido490WC.Agregar490WC(permisoLeido490WC);
                }
                return PermisosCompuestos490WC;
            }
            catch { PermisosCompuestos490WC.Clear(); return ListaPermiso490WC; }
        }

        public PermisoCompuesto490WC LeerPermisoCompuesto490WC(string PermisoLeer490WC)
        {
            PermisoCompuesto490WC PermisoLeidoGlobal490WC;
            List<Permiso490WC> listaPermiso490WC = new List<Permiso490WC>();
            List<Permiso490WC> permisosCompuestos490WC = new List<Permiso490WC>();
            try 
            {
                DataTable tablaPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Permiso490WC");
                DataView dvPermiso490WC = new DataView(tablaPermiso490WC);
                foreach(DataRowView drv490WC in dvPermiso490WC) 
                {
                    if (drv490WC["tipoPermiso490WC"].ToString() == "Compuesto") 
                    {
                        PermisoCompuesto490WC compuesto = new PermisoCompuesto490WC(drv490WC["nombrePermiso490WC"].ToString());
                        permisosCompuestos490WC.Add(compuesto);
                        listaPermiso490WC.Add(compuesto);
                    }
                    else 
                    {
                        PermisoSimple490WC permisoS490WC = new PermisoSimple490WC(drv490WC["nombrePermiso490WC"].ToString());
                        listaPermiso490WC.Add(permisoS490WC);
                    }
                }
                DataTable tablaRelacionPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("RelacionPermiso490WC");
                DataView dvRelacionPermiso490WC = new DataView(tablaRelacionPermiso490WC);
                PermisoCompuesto490WC compuestoLeido490WC;
                Permiso490WC permisoLeido490WC;
                foreach(DataRowView drv490WC in dvRelacionPermiso490WC) 
                {
                    compuestoLeido490WC = (PermisoCompuesto490WC)permisosCompuestos490WC.Find(x => x.obtenerPermisoNombre490WC() == drv490WC["permisoCompuestoNombre490WC"].ToString());
                    permisoLeido490WC = listaPermiso490WC.Find(x => x.obtenerPermisoNombre490WC() == drv490WC["permisoIncluidoNombre490WC"].ToString());
                    compuestoLeido490WC.Agregar490WC(permisoLeido490WC);
                }
                PermisoLeidoGlobal490WC = (PermisoCompuesto490WC)permisosCompuestos490WC.Find(x => x.obtenerPermisoNombre490WC() == PermisoLeer490WC);
                return PermisoLeidoGlobal490WC;
            }
            catch { permisosCompuestos490WC.Clear(); return null; }
        }
        public bool InsertarPermiso490WC(Permiso490WC permisoNuevo490WC, bool esRol490WC) 
        {
            try 
            {
                DataRow dr490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Permiso490WC").NewRow();
                dr490WC["nombrePermiso490WC"] = permisoNuevo490WC.obtenerPermisoNombre490WC();
                dr490WC["tipoPermiso490WC"] = permisoNuevo490WC.esCompuesto490WC() == true ? "Compuesto" : "Simple";
                dr490WC["esRolPermiso490WC"] = esRol490WC == true ? "True" : "False";
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Permiso490WC").Rows.Add(dr490WC);
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.ActualizarPorTabla490WC("Permiso490WC");
                return true;
            }
            catch { return false; }
        }

        public bool InsertarRelacion490WC(string Compuesto490WC, string Incluido490WC) 
        {
            try
            {
                DataRow dr490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("RelacionPermiso490WC").NewRow();
                dr490WC["permisoCompuestoNombre490WC"] = Compuesto490WC;
                dr490WC["permisoIncluidoNombre490WC"] = Incluido490WC;
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("RelacionPermiso490WC").Rows.Add(dr490WC);
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.ActualizarPorTabla490WC("RelacionPermiso490WC");
                return true;
            }
            catch { return false; }
        }

        public bool BorrarPermiso490WC(string NombrePermiso490WC)
        {
            try
            {
                Usuario490WC usuarioConPermisoBorrar490WC = UsuarioORM490WC.GestorUsuarioORM490WC.ObtenerUsuariosPorConsulta490WC("Simple", "Rol", NombrePermiso490WC)[0];
                if (usuarioConPermisoBorrar490WC != null)
                {
                    
                }
                DataRow drEliminar490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Permiso490WC").Rows.Find(NombrePermiso490WC);
                if (drEliminar490WC != null)
                {
                    drEliminar490WC.Delete();
                }
                DataTable dtRelacionPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("RelacionPermiso490WC");
                DataView dv490WC = new DataView(dtRelacionPermiso490WC);
                foreach (DataRowView drv490WC in dv490WC)
                {
                    if (NombrePermiso490WC == drv490WC["permisoCompuestoNombre490WC"].ToString() || NombrePermiso490WC == drv490WC["permisoIncluidoNombre490WC"].ToString())
                    {
                        drv490WC.Delete();
                    }
                }
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.ActualizarPorTabla490WC("Permiso490WC");
                return true;
            }
            catch { return false; }
        }

        public bool BorrarRelacion490WC(string nombrePermisoCompuesto490WC) 
        {
            try
            {
                DataTable dtRelacionPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("RelacionPermiso490WC");
                DataView dv490WC = new DataView(dtRelacionPermiso490WC);
                foreach (DataRowView drv490WC in dv490WC)
                {
                    if (drv490WC["permisoCompuestoNombre490WC"].ToString() == nombrePermisoCompuesto490WC)
                    {
                        drv490WC.Delete();
                        GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.ActualizarPorTabla490WC("Permiso490WC");
                    }
                }
                return true;
            }
            catch { return false; }
        }

        public bool ModificarPermiso490WC(string nombrePermiso490WC,string nuevoNombrePermiso490WC) 
        {
            try
            {
                DataRow drPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Permiso490WC").Rows.Find(nombrePermiso490WC);
                if (drPermiso490WC != null)
                {
                    drPermiso490WC["nombrePermiso490WC"] = nuevoNombrePermiso490WC;
                }
                DataTable dtRelacionPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("RelacionPermiso490WC");
                DataView dv490WC = new DataView(dtRelacionPermiso490WC);
                foreach (DataRowView drv490WC in dv490WC)
                {
                    if (drv490WC["permisoCompuestoNombre490WC"].ToString() == nombrePermiso490WC)
                    {
                        drv490WC["permisoCompuestoNombre490WC"] = nuevoNombrePermiso490WC;
                    }
                    if (drv490WC["permisoIncluidoNombre490WC"].ToString() == nombrePermiso490WC)
                    {
                        drv490WC["permisoIncluidoNombre490WC"] = nuevoNombrePermiso490WC;
                    }
                }
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.ActualizarPorTabla490WC("Permiso490WC");
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.ActualizarPorTabla490WC("RelacionPermiso490WC");
                return true;
            }
            catch { return false; }
        }

        public bool esRol490WC(string nombrePermiso490WC) 
        {
            try 
            {
               DataRow drPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Permiso490WC").Rows.Find(nombrePermiso490WC);
               if (drPermiso490WC["esRolPermiso490WC"].ToString() == "True") 
               {
                   return true;
               }
               else 
               {
                  return false; 
               }
            }
            catch { return false; }
        }

        public bool permisoExiste490WC(string nombrePermiso490WC) 
        {
            try 
            {
               DataRow drPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Permiso490WC").Rows.Find(nombrePermiso490WC);
               if(drPermiso490WC != null) 
               {
                  return true;
               }
               else 
               {
                  return false;
               }
            }
            catch { return false; }
        }
        #region Funciones para el Mapeo de Permisos

        public List<Permiso490WC> ObtenerPermisos490WC() 
        {
            List<Permiso490WC> ListaPermisos490WC = new List<Permiso490WC>();
            DataTable dtPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Permiso490WC");
            DataView dvPermiso490WC = new DataView(dtPermiso490WC);
            foreach(DataRowView drv490WC in dvPermiso490WC) 
            {
                Permiso490WC permiso490WC; 
                string nombrePermiso490WC = drv490WC["nombrePermiso490WC"].ToString();
                string tipoPermiso490WC = drv490WC["tipoPermiso490WC"].ToString();
                if(tipoPermiso490WC == "Compuesto") 
                {
                    permiso490WC = new PermisoCompuesto490WC(nombrePermiso490WC);
                    ListaPermisos490WC.Add(permiso490WC);
                }
                else 
                {
                    permiso490WC = new PermisoSimple490WC(nombrePermiso490WC);
                    ListaPermisos490WC.Add(permiso490WC);
                }
            }
            return ListaPermisos490WC;
        }

        public List<Permiso490WC> ObtenerPermisosSimples490WC() 
        {
            List<Permiso490WC> ListaPermisos490WC = new List<Permiso490WC>();
            DataTable dtPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Permiso490WC");
            DataView dvPermiso490WC = new DataView(dtPermiso490WC);
            foreach (DataRowView drv490WC in dvPermiso490WC)
            {
                string tipoPermiso490WC = drv490WC["tipoPermiso490WC"].ToString();
                if (tipoPermiso490WC == "Simple")
                {
                    Permiso490WC permiso490WC;
                    string nombrePermiso490WC = drv490WC["nombrePermiso490WC"].ToString();
                    permiso490WC = new PermisoSimple490WC(nombrePermiso490WC);
                    ListaPermisos490WC.Add(permiso490WC);
                }
            }
            return ListaPermisos490WC;
        }

        public List<Permiso490WC> ObtenerPermisosCompuestos490WC() 
        {
            List<Permiso490WC> ListaPermisos490WC = new List<Permiso490WC>();
            DataTable dtPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Permiso490WC");
            DataView dvPermiso490WC = new DataView(dtPermiso490WC);
            foreach (DataRowView drv490WC in dvPermiso490WC)
            {
                string tipoPermiso490WC = drv490WC["tipoPermiso490WC"].ToString();
                if (tipoPermiso490WC == "Compuesto")
                {
                    Permiso490WC permiso490WC;
                    string nombrePermiso490WC = drv490WC["nombrePermiso490WC"].ToString();
                    permiso490WC = new PermisoCompuesto490WC(nombrePermiso490WC);
                    ListaPermisos490WC.Add(permiso490WC);
                }
            }
            return ListaPermisos490WC;
        }

        public List<Permiso490WC> ObtenerRoles490WC() 
        {
            List<Permiso490WC> ListaPermisos490WC = new List<Permiso490WC>();
            DataTable dtPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Permiso490WC");
            DataView dvPermiso490WC = new DataView(dtPermiso490WC);
            foreach (DataRowView drv in dvPermiso490WC)
            {
                string nombrePermiso490WC = drv["nombrePermiso490WC"].ToString();
                if(esRol490WC(nombrePermiso490WC)== true) 
                {
                  string tipoPermiso490WC = drv["tipoPermiso490WC"].ToString();
                  if (tipoPermiso490WC == "Compuesto")
                  {
                    Permiso490WC permiso490WC;
                    permiso490WC = new PermisoCompuesto490WC(nombrePermiso490WC);
                    ListaPermisos490WC.Add(permiso490WC);
                  }
                }
            }
            return ListaPermisos490WC;
        }
        public List<Permiso490WC> ObtenerTodoSinRoles490WC() 
        {
            List<Permiso490WC> ListaPermisos490WC = new List<Permiso490WC>();
            DataTable dtPermiso490WC = GestorBaseDeDatos490WC.GestorBaseDeDatosSG490WC.DevolverTabla490WC("Permiso490WC");
            DataView dvPermiso490WC = new DataView(dtPermiso490WC);
            foreach (DataRowView drv490WC in dvPermiso490WC)
            {
                string nombrePermiso490WC = drv490WC["nombrePermiso490WC"].ToString();
                if (esRol490WC(nombrePermiso490WC) == false)
                {
                    string tipoPermiso490WC = drv490WC["tipoPermiso490WC"].ToString();
                    if (tipoPermiso490WC == "Compuesto")
                    {
                        Permiso490WC permiso490WC;
                        permiso490WC = new PermisoCompuesto490WC(nombrePermiso490WC);
                        ListaPermisos490WC.Add(permiso490WC);
                    }
                    else 
                    {
                        Permiso490WC permiso490WC;
                        permiso490WC = new PermisoSimple490WC(nombrePermiso490WC);
                        ListaPermisos490WC.Add(permiso490WC);
                    }
                }
            }
            return ListaPermisos490WC;

        }

        #endregion

    }
}
