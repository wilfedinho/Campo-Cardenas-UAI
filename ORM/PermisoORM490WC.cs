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
        private static PermisoORM490WC Instancia;
        public static PermisoORM490WC GestorPermisoORM
        {
            get
            {
                if (Instancia == null)
                {
                    Instancia = new PermisoORM490WC();
                }
                return Instancia;
            }
        }
        public List<Permiso490WC> LeerPermisosEnArbol() 
        {
          List<Permiso490WC> ListaPermiso = new List<Permiso490WC>();
          List<Permiso490WC> PermisosCompuestos = new List<Permiso490WC>();
            try
            {
                DataTable tablaPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("Permiso");
                DataTable tablaRelacionPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso");
                DataView dvPermiso = new DataView(tablaPermiso);
                foreach(DataRowView drv in dvPermiso) 
                {
                    if (drv["tipoPermiso"].ToString() == "Compuesto") 
                    {
                      PermisoCompuesto490WC compuesto = new PermisoCompuesto490WC(drv["nombrePermiso"].ToString());
                      PermisosCompuestos.Add(compuesto);
                      ListaPermiso.Add(compuesto);
                    }
                    else 
                    {
                        PermisoSimple490WC permisoS = new PermisoSimple490WC(drv["nombrePermiso"].ToString());
                        ListaPermiso.Add(permisoS);
                    }
                }
                DataView dvRelacionPermiso = new DataView(tablaRelacionPermiso);
                PermisoCompuesto490WC permisoCompuestoLeido;
                Permiso490WC permisoLeido;
                foreach (DataRowView drv in dvRelacionPermiso) 
                {
                    permisoCompuestoLeido = (PermisoCompuesto490WC)PermisosCompuestos.Find(x => x.obtenerPermisoNombre() == drv["permisoCompuestoNombre"].ToString());
                    permisoLeido = ListaPermiso.Find(x => x.obtenerPermisoNombre() == drv["permisoIncluidoNombre"].ToString());
                    permisoCompuestoLeido.Agregar(permisoLeido);
                }
                return PermisosCompuestos;
            }
            catch { PermisosCompuestos.Clear(); return ListaPermiso; }
        }

        public PermisoCompuesto490WC LeerPermisoCompuesto(string PermisoLeer)
        {
            PermisoCompuesto490WC PermisoLeidoGlobal;
            List<Permiso490WC> listaPermiso = new List<Permiso490WC>();
            List<Permiso490WC> permisosCompuestos = new List<Permiso490WC>();
            try 
            {
                DataTable tablaPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("Permiso");
                DataView dvPermiso = new DataView(tablaPermiso);
                foreach(DataRowView drv in dvPermiso) 
                {
                    if (drv["tipoPermiso"].ToString() == "Compuesto") 
                    {
                        PermisoCompuesto490WC compuesto = new PermisoCompuesto490WC(drv["nombrePermiso"].ToString());
                        permisosCompuestos.Add(compuesto);
                        listaPermiso.Add(compuesto);
                    }
                    else 
                    {
                        PermisoSimple490WC permisoS = new PermisoSimple490WC(drv["nombrePermiso"].ToString());
                        listaPermiso.Add(permisoS);
                    }
                }
                DataTable tablaRelacionPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso");
                DataView dvRelacionPermiso = new DataView(tablaRelacionPermiso);
                PermisoCompuesto490WC compuestoLeido;
                Permiso490WC permisoLeido;
                foreach(DataRowView drv in dvRelacionPermiso) 
                {
                    compuestoLeido = (PermisoCompuesto490WC)permisosCompuestos.Find(x => x.obtenerPermisoNombre() == drv["permisoCompuestoNombre"].ToString());
                    permisoLeido = listaPermiso.Find(x => x.obtenerPermisoNombre() == drv["permisoIncluidoNombre"].ToString());
                    compuestoLeido.Agregar(permisoLeido);
                }
                PermisoLeidoGlobal = (PermisoCompuesto490WC)permisosCompuestos.Find(x => x.obtenerPermisoNombre() == PermisoLeer);
                return PermisoLeidoGlobal;
            }
            catch { permisosCompuestos.Clear(); return null; }
        }
        public bool InsertarPermiso(Permiso490WC permisoNuevo, bool esRol) 
        {
            try 
            {
                DataRow dr = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("Permiso").NewRow();
                dr["nombrePermiso"] = permisoNuevo.obtenerPermisoNombre();
                dr["tipoPermiso"] = permisoNuevo.esCompuesto() == true ? "Compuesto" : "Simple";
                dr["esRolPermiso"] = esRol == true ? "True" : "False";
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("Permiso").Rows.Add(dr);
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG.ActualizarPorTabla("Permiso");
                return true;
            }
            catch { return false; }
        }

        public bool InsertarRelacion(string Compuesto, string Incluido) 
        {
            try
            {
                DataRow dr = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso").NewRow();
                dr["permisoCompuestoNombre"] = Compuesto;
                dr["permisoIncluidoNombre"] = Incluido;
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso").Rows.Add(dr);
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG.ActualizarPorTabla("RelacionPermiso");
                return true;
            }
            catch { return false; }
        }

        public bool BorrarPermiso(string NombrePermiso)
        {
            try
            {
                Usuario490WC usuarioConPermisoBorrar = UsuarioORM490WC.GestorUsuarioORM.ObtenerUsuariosPorConsulta("Simple", "Rol", NombrePermiso)[0];
                if (usuarioConPermisoBorrar != null)
                {
                    throw new Exception();
                }
                DataRow drEliminar = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("Permiso").Rows.Find(NombrePermiso);
                if (drEliminar != null)
                {
                    drEliminar.Delete();
                }
                DataTable dtRelacionPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso");
                DataView dv = new DataView(dtRelacionPermiso);
                foreach (DataRowView drv in dv)
                {
                    if (NombrePermiso == drv["permisoCompuestoNombre"].ToString() || NombrePermiso == drv["permisoIncluidoNombre"].ToString())
                    {
                        drv.Delete();
                    }
                }
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG.ActualizarPorTabla("Permiso");
                return true;
            }
            catch { return false; }
        }

        public bool BorrarRelacion(string nombrePermisoCompuesto) 
        {
            try
            {
                DataTable dtRelacionPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso");
                DataView dv = new DataView(dtRelacionPermiso);
                foreach (DataRowView drv in dv)
                {
                    if (drv["permisoCompuestoNombre"].ToString() == nombrePermisoCompuesto)
                    {
                        drv.Delete();
                        GestorBaseDeDatos490WC.GestorBaseDeDatosSG.ActualizarPorTabla("Permiso");
                    }
                }
                return true;
            }
            catch { return false; }
        }

        public bool ModificarPermiso(string nombrePermiso,string nuevoNombrePermiso) 
        {
            try
            {
                DataRow drPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("Permiso").Rows.Find(nombrePermiso);
                if (drPermiso != null)
                {
                    drPermiso["nombrePermiso"] = nuevoNombrePermiso;
                }
                DataTable dtRelacionPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso");
                DataView dv = new DataView(dtRelacionPermiso);
                foreach (DataRowView drv in dv)
                {
                    if (drv["permisoCompuestoNombre"].ToString() == nombrePermiso)
                    {
                        drv["permisoCompuestoNombre"] = nuevoNombrePermiso;
                    }
                    if (drv["permisoIncluidoNombre"].ToString() == nombrePermiso)
                    {
                        drv["permisoIncluidoNombre"] = nuevoNombrePermiso;
                    }
                }
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG.ActualizarPorTabla("Permiso");
                GestorBaseDeDatos490WC.GestorBaseDeDatosSG.ActualizarPorTabla("RelacionPermiso");
                return true;
            }
            catch { return false; }
        }

        public bool esRol(string nombrePermiso) 
        {
            try 
            {
               DataRow drPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("Permiso").Rows.Find(nombrePermiso);
               if (drPermiso["esRolPermiso"].ToString() == "True") 
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

        public bool permisoExiste(string nombrePermiso) 
        {
            try 
            {
               DataRow drPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("Permiso").Rows.Find(nombrePermiso);
               if(drPermiso != null) 
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

        public List<Permiso490WC> ObtenerPermisos() 
        {
            List<Permiso490WC> ListaPermisos = new List<Permiso490WC>();
            DataTable dtPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("Permiso");
            DataView dvPermiso = new DataView(dtPermiso);
            foreach(DataRowView drv in dvPermiso) 
            {
                Permiso490WC permiso; 
                string nombrePermiso = drv["nombrePermiso"].ToString();
                string tipoPermiso = drv["tipoPermiso"].ToString();
                if(tipoPermiso == "Compuesto") 
                {
                    permiso = new PermisoCompuesto490WC(nombrePermiso);
                    ListaPermisos.Add(permiso);
                }
                else 
                {
                    permiso = new PermisoSimple490WC(nombrePermiso);
                    ListaPermisos.Add(permiso);
                }
            }
            return ListaPermisos;
        }

        public List<Permiso490WC> ObtenerPermisosSimples() 
        {
            List<Permiso490WC> ListaPermisos = new List<Permiso490WC>();
            DataTable dtPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("Permiso");
            DataView dvPermiso = new DataView(dtPermiso);
            foreach (DataRowView drv in dvPermiso)
            {
                string tipoPermiso = drv["tipoPermiso"].ToString();
                if (tipoPermiso == "Simple")
                {
                    Permiso490WC permiso;
                    string nombrePermiso = drv["nombrePermiso"].ToString();
                    permiso = new PermisoSimple490WC(nombrePermiso);
                    ListaPermisos.Add(permiso);
                }
            }
            return ListaPermisos;
        }

        public List<Permiso490WC> ObtenerPermisosCompuestos() 
        {
            List<Permiso490WC> ListaPermisos = new List<Permiso490WC>();
            DataTable dtPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("Permiso");
            DataView dvPermiso = new DataView(dtPermiso);
            foreach (DataRowView drv in dvPermiso)
            {
                string tipoPermiso = drv["tipoPermiso"].ToString();
                if (tipoPermiso == "Compuesto")
                {
                    Permiso490WC permiso;
                    string nombrePermiso = drv["nombrePermiso"].ToString();
                    permiso = new PermisoCompuesto490WC(nombrePermiso);
                    ListaPermisos.Add(permiso);
                }
            }
            return ListaPermisos;
        }

        public List<Permiso490WC> ObtenerRoles() 
        {
            List<Permiso490WC> ListaPermisos = new List<Permiso490WC>();
            DataTable dtPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("Permiso");
            DataView dvPermiso = new DataView(dtPermiso);
            foreach (DataRowView drv in dvPermiso)
            {
                string nombrePermiso = drv["nombrePermiso"].ToString();
                if(esRol(nombrePermiso)== true) 
                {
                  string tipoPermiso = drv["tipoPermiso"].ToString();
                  if (tipoPermiso == "Compuesto")
                  {
                    Permiso490WC permiso;
                    permiso = new PermisoCompuesto490WC(nombrePermiso);
                    ListaPermisos.Add(permiso);
                  }
                }
            }
            return ListaPermisos;
        }
        public List<Permiso490WC> ObtenerTodoSinRoles() 
        {
            List<Permiso490WC> ListaPermisos = new List<Permiso490WC>();
            DataTable dtPermiso = GestorBaseDeDatos490WC.GestorBaseDeDatosSG.DevolverTabla("Permiso");
            DataView dvPermiso = new DataView(dtPermiso);
            foreach (DataRowView drv in dvPermiso)
            {
                string nombrePermiso = drv["nombrePermiso"].ToString();
                if (esRol(nombrePermiso) == false)
                {
                    string tipoPermiso = drv["tipoPermiso"].ToString();
                    if (tipoPermiso == "Compuesto")
                    {
                        Permiso490WC permiso;
                        permiso = new PermisoCompuesto490WC(nombrePermiso);
                        ListaPermisos.Add(permiso);
                    }
                    else 
                    {
                        Permiso490WC permiso;
                        permiso = new PermisoSimple490WC(nombrePermiso);
                        ListaPermisos.Add(permiso);
                    }
                }
            }
            return ListaPermisos;

        }

        #endregion

    }
}
