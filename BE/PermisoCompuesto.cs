using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PermisoCompuesto : Permiso
    {
        public PermisoCompuesto(string nNombre) : base(nNombre)
        {

        }
        protected List<Permiso> permisos = new List<Permiso>();

        public override void Agregar(Permiso nPermiso)
        {
            this.permisos.Add(nPermiso);
        }

        public override void Borrar(Permiso nPermiso)
        {
            this.permisos.Remove(nPermiso);
        }

        public override bool esCompuesto()
        {
            return true;
        }

        public Permiso BuscarPermiso(Permiso raiz, Permiso permiso) 
        {
            if(raiz == permiso)
            {
                return raiz;
            }
            else 
            {
                if (raiz.esCompuesto()) 
                {

                    foreach(Permiso permi in (raiz as PermisoCompuesto).permisos) 
                    {
                        Permiso permisoEncontrado = BuscarPermiso(permi, permiso);
                        if(permisoEncontrado != null)
                        {
                            return permisoEncontrado;
                        }
                    }

                }
            }
            return null;
        }

        public bool VerificarPermisoIncluido(Permiso raiz, string permiso) 
        {
            if(raiz.obtenerPermisoNombre() == permiso) 
            {
                return true;
            }
            else 
            {
                if(raiz.esCompuesto())
                {
                    foreach(Permiso permi in (raiz as PermisoCompuesto).permisos) 
                    {
                        if(VerificarPermisoIncluido(permi, permiso)) 
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public List<Permiso> PermisosIncluidos() 
        {
            return permisos;
        }

    }
}
