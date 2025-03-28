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
    public class PermisoORM
    {
        private static PermisoORM Instancia;
        public static PermisoORM GestorPermisoORM
        {
            get
            {
                if (Instancia == null)
                {
                    Instancia = new PermisoORM();
                }
                return Instancia;
            }
        }
        public List<Permiso> LeerPermisosEnArbol() 
        {
          List<Permiso> ListaPermiso = new List<Permiso>();
          List<Permiso> PermisosCompuestos = new List<Permiso>();
            try
            {
                DataTable tablaPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso");
                DataTable tablaRelacionPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso");
                DataView dvPermiso = new DataView(tablaPermiso);
                foreach(DataRowView drv in dvPermiso) 
                {
                    if (drv["tipoPermiso"].ToString() == "Compuesto") 
                    {
                      PermisoCompuesto compuesto = new PermisoCompuesto(drv["nombrePermiso"].ToString());
                      PermisosCompuestos.Add(compuesto);
                      ListaPermiso.Add(compuesto);
                    }
                    else 
                    {
                        PermisoSimple permisoS = new PermisoSimple(drv["nombrePermiso"].ToString());
                        ListaPermiso.Add(permisoS);
                    }
                }
                DataView dvRelacionPermiso = new DataView(tablaRelacionPermiso);
                PermisoCompuesto permisoCompuestoLeido;
                Permiso permisoLeido;
                foreach (DataRowView drv in dvRelacionPermiso) 
                {
                    permisoCompuestoLeido = (PermisoCompuesto)PermisosCompuestos.Find(x => x.obtenerPermisoNombre() == drv["permisoCompuestoNombre"].ToString());
                    permisoLeido = ListaPermiso.Find(x => x.obtenerPermisoNombre() == drv["permisoIncluidoNombre"].ToString());
                    permisoCompuestoLeido.Agregar(permisoLeido);
                }
                return PermisosCompuestos;
            }
            catch { PermisosCompuestos.Clear(); return ListaPermiso; }
        }

        public PermisoCompuesto LeerPermisoCompuesto(string PermisoLeer)
        {
            PermisoCompuesto PermisoLeidoGlobal;
            List<Permiso> listaPermiso = new List<Permiso>();
            List<Permiso> permisosCompuestos = new List<Permiso>();
            try 
            {
                DataTable tablaPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso");
                DataView dvPermiso = new DataView(tablaPermiso);
                foreach(DataRowView drv in dvPermiso) 
                {
                    if (drv["tipoPermiso"].ToString() == "Compuesto") 
                    {
                        PermisoCompuesto compuesto = new PermisoCompuesto(drv["nombrePermiso"].ToString());
                        permisosCompuestos.Add(compuesto);
                        listaPermiso.Add(compuesto);
                    }
                    else 
                    {
                        PermisoSimple permisoS = new PermisoSimple(drv["nombrePermiso"].ToString());
                        listaPermiso.Add(permisoS);
                    }
                }
                DataTable tablaRelacionPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso");
                DataView dvRelacionPermiso = new DataView(tablaRelacionPermiso);
                PermisoCompuesto compuestoLeido;
                Permiso permisoLeido;
                foreach(DataRowView drv in dvRelacionPermiso) 
                {
                    compuestoLeido = (PermisoCompuesto)permisosCompuestos.Find(x => x.obtenerPermisoNombre() == drv["permisoCompuestoNombre"].ToString());
                    permisoLeido = listaPermiso.Find(x => x.obtenerPermisoNombre() == drv["permisoIncluidoNombre"].ToString());
                    compuestoLeido.Agregar(permisoLeido);
                }
                PermisoLeidoGlobal = (PermisoCompuesto)permisosCompuestos.Find(x => x.obtenerPermisoNombre() == PermisoLeer);
                return PermisoLeidoGlobal;
            }
            catch { permisosCompuestos.Clear(); return null; }
        }
        public bool InsertarPermiso(Permiso permisoNuevo, bool esRol) 
        {
            try 
            {
                DataRow dr = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso").NewRow();
                dr["nombrePermiso"] = permisoNuevo.obtenerPermisoNombre();
                dr["tipoPermiso"] = permisoNuevo.esCompuesto() == true ? "Compuesto" : "Simple";
                dr["esRolPermiso"] = esRol == true ? "True" : "False";
                GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso").Rows.Add(dr);
                GestorBaseDeDatos.GestorBaseDeDatosSG.ActualizarPorTabla("Permiso");
                return true;
            }
            catch { return false; }
        }

        public bool InsertarRelacion(string Compuesto, string Incluido) 
        {
            try
            {
                DataRow dr = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso").NewRow();
                dr["permisoCompuestoNombre"] = Compuesto;
                dr["permisoIncluidoNombre"] = Incluido;
                GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso").Rows.Add(dr);
                GestorBaseDeDatos.GestorBaseDeDatosSG.ActualizarPorTabla("RelacionPermiso");
                return true;
            }
            catch { return false; }
        }

        public bool BorrarPermiso(string NombrePermiso)
        {
            try
            {
                Usuario usuarioConPermisoBorrar = UsuarioORM.GestorUsuarioORM.ObtenerUsuariosPorConsulta("Simple", "Rol", NombrePermiso)[0];
                if (usuarioConPermisoBorrar != null)
                {
                    throw new Exception();
                }
                DataRow drEliminar = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso").Rows.Find(NombrePermiso);
                if (drEliminar != null)
                {
                    drEliminar.Delete();
                }
                DataTable dtRelacionPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso");
                DataView dv = new DataView(dtRelacionPermiso);
                foreach (DataRowView drv in dv)
                {
                    if (NombrePermiso == drv["permisoCompuestoNombre"].ToString() || NombrePermiso == drv["permisoIncluidoNombre"].ToString())
                    {
                        drv.Delete();
                    }
                }
                GestorBaseDeDatos.GestorBaseDeDatosSG.ActualizarPorTabla("Permiso");
                return true;
            }
            catch { return false; }
        }

        public bool BorrarRelacion(string nombrePermisoCompuesto) 
        {
            try
            {
                DataTable dtRelacionPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso");
                DataView dv = new DataView(dtRelacionPermiso);
                foreach (DataRowView drv in dv)
                {
                    if (drv["permisoCompuestoNombre"].ToString() == nombrePermisoCompuesto)
                    {
                        drv.Delete();
                        GestorBaseDeDatos.GestorBaseDeDatosSG.ActualizarPorTabla("Permiso");
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
                DataRow drPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso").Rows.Find(nombrePermiso);
                if (drPermiso != null)
                {
                    drPermiso["nombrePermiso"] = nuevoNombrePermiso;
                }
                DataTable dtRelacionPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso");
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
                GestorBaseDeDatos.GestorBaseDeDatosSG.ActualizarPorTabla("Permiso");
                GestorBaseDeDatos.GestorBaseDeDatosSG.ActualizarPorTabla("RelacionPermiso");
                return true;
            }
            catch { return false; }
        }

        public bool esRol(string nombrePermiso) 
        {
            try 
            {
               DataRow drPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso").Rows.Find(nombrePermiso);
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
               DataRow drPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso").Rows.Find(nombrePermiso);
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

        public List<Permiso> ObtenerPermisos() 
        {
            List<Permiso> ListaPermisos = new List<Permiso>();
            DataTable dtPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso");
            DataView dvPermiso = new DataView(dtPermiso);
            foreach(DataRowView drv in dvPermiso) 
            {
                Permiso permiso; 
                string nombrePermiso = drv["nombrePermiso"].ToString();
                string tipoPermiso = drv["tipoPermiso"].ToString();
                if(tipoPermiso == "Compuesto") 
                {
                    permiso = new PermisoCompuesto(nombrePermiso);
                    ListaPermisos.Add(permiso);
                }
                else 
                {
                    permiso = new PermisoSimple(nombrePermiso);
                    ListaPermisos.Add(permiso);
                }
            }
            return ListaPermisos;
        }

        public List<Permiso> ObtenerPermisosSimples() 
        {
            List<Permiso> ListaPermisos = new List<Permiso>();
            DataTable dtPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso");
            DataView dvPermiso = new DataView(dtPermiso);
            foreach (DataRowView drv in dvPermiso)
            {
                string tipoPermiso = drv["tipoPermiso"].ToString();
                if (tipoPermiso == "Simple")
                {
                    Permiso permiso;
                    string nombrePermiso = drv["nombrePermiso"].ToString();
                    permiso = new PermisoSimple(nombrePermiso);
                    ListaPermisos.Add(permiso);
                }
            }
            return ListaPermisos;
        }

        public List<Permiso> ObtenerPermisosCompuestos() 
        {
            List<Permiso> ListaPermisos = new List<Permiso>();
            DataTable dtPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso");
            DataView dvPermiso = new DataView(dtPermiso);
            foreach (DataRowView drv in dvPermiso)
            {
                string tipoPermiso = drv["tipoPermiso"].ToString();
                if (tipoPermiso == "Compuesto")
                {
                    Permiso permiso;
                    string nombrePermiso = drv["nombrePermiso"].ToString();
                    permiso = new PermisoCompuesto(nombrePermiso);
                    ListaPermisos.Add(permiso);
                }
            }
            return ListaPermisos;
        }

        public List<Permiso> ObtenerRoles() 
        {
            List<Permiso> ListaPermisos = new List<Permiso>();
            DataTable dtPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso");
            DataView dvPermiso = new DataView(dtPermiso);
            foreach (DataRowView drv in dvPermiso)
            {
                string nombrePermiso = drv["nombrePermiso"].ToString();
                if(esRol(nombrePermiso)== true) 
                {
                  string tipoPermiso = drv["tipoPermiso"].ToString();
                  if (tipoPermiso == "Compuesto")
                  {
                    Permiso permiso;
                    permiso = new PermisoCompuesto(nombrePermiso);
                    ListaPermisos.Add(permiso);
                  }
                }
            }
            return ListaPermisos;
        }
        public List<Permiso> ObtenerTodoSinRoles() 
        {
            List<Permiso> ListaPermisos = new List<Permiso>();
            DataTable dtPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso");
            DataView dvPermiso = new DataView(dtPermiso);
            foreach (DataRowView drv in dvPermiso)
            {
                string nombrePermiso = drv["nombrePermiso"].ToString();
                if (esRol(nombrePermiso) == false)
                {
                    string tipoPermiso = drv["tipoPermiso"].ToString();
                    if (tipoPermiso == "Compuesto")
                    {
                        Permiso permiso;
                        permiso = new PermisoCompuesto(nombrePermiso);
                        ListaPermisos.Add(permiso);
                    }
                    else 
                    {
                        Permiso permiso;
                        permiso = new PermisoSimple(nombrePermiso);
                        ListaPermisos.Add(permiso);
                    }
                }
            }
            return ListaPermisos;

        }

        #endregion

    }
}
