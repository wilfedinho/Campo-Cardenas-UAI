using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Permiso
    {

        private string Nombre;
        protected Permiso(string nNombre) 
        {
          Nombre = nNombre;
        }
        public virtual void Agregar(Permiso nPermiso) 
        {
        
        }

        public virtual void Borrar(Permiso nPermiso) 
        {
         
        }

        public virtual bool esCompuesto() 
        {
          return false;
        }

        public string obtenerPermisoNombre()
        {
            return Nombre;
        }

    }
}
