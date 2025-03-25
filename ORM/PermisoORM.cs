using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace ORM
{
    public class PermisoORM
    {
        public List<Permiso> LeerPermisosEnArbol() 
        {
          List<Permiso> ListaPermiso = new List<Permiso>();
          List<Permiso> PermisosCompuestos = new List<Permiso>();
            try
            {
                DataTable tablaPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso");
                DataTable tablaRelacionPermiso = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("RelacionPermiso");


                //Recorrido para la tabla Permiso
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

                //Recorrido para la tabla PermisoRelacion
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

        //Faltan todas las variantes de leer los distintos tipos de permisos

        public bool InsertarPermiso(Permiso permisoNuevo, bool esRol) 
        {
            try 
            {
                DataRow dr = GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso").NewRow();
                dr["nombrePermiso"] = permisoNuevo.obtenerPermisoNombre();
                dr["tipoPermiso"] = permisoNuevo.esCompuesto() == true ? "Compuesto" : "Simple";
                dr["esRolPermiso"] = esRol == true ? "True" : "False";
                GestorBaseDeDatos.GestorBaseDeDatosSG.DevolverTabla("Permiso").Rows.Add(dr);
                GestorBaseDeDatos.GestorBaseDeDatosSG.ActualizarGeneral();
                return true;
            }
            catch { return false; }
        
        }



    }
}
