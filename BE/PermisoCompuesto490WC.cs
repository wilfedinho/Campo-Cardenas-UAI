using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PermisoCompuesto490WC : Permiso490WC
    {
        public PermisoCompuesto490WC(string nNombre) : base(nNombre)
        {

        }
        protected List<Permiso490WC> permisos = new List<Permiso490WC>();

        public override void Agregar(Permiso490WC nPermiso)
        {
            this.permisos.Add(nPermiso);
        }

        public override void Borrar(Permiso490WC nPermiso)
        {
            this.permisos.Remove(nPermiso);
        }

        public override bool esCompuesto()
        {
            return true;
        }

        public Permiso490WC BuscarPermiso(Permiso490WC raiz, Permiso490WC permiso) 
        {
            if(raiz == permiso)
            {
                return raiz;
            }
            else 
            {
                if (raiz.esCompuesto()) 
                {

                    foreach(Permiso490WC permi in (raiz as PermisoCompuesto490WC).permisos) 
                    {
                        Permiso490WC permisoEncontrado = BuscarPermiso(permi, permiso);
                        if(permisoEncontrado != null)
                        {
                            return permisoEncontrado;
                        }
                    }

                }
            }
            return null;
        }

        public bool VerificarPermisoIncluido(Permiso490WC raiz, string permiso) 
        {
            if(raiz.obtenerPermisoNombre() == permiso) 
            {
                return true;
            }
            else 
            {
                if(raiz.esCompuesto())
                {
                    foreach(Permiso490WC permi in (raiz as PermisoCompuesto490WC).permisos) 
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

        public List<Permiso490WC> PermisosIncluidos() 
        {
            return permisos;
        }

    }
}
