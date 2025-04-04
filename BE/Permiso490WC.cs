using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Permiso490WC
    {

        private string Nombre;
        protected Permiso490WC(string nNombre) 
        {
          Nombre = nNombre;
        }
        public virtual void Agregar(Permiso490WC nPermiso) 
        {
        
        }

        public virtual void Borrar(Permiso490WC nPermiso) 
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
