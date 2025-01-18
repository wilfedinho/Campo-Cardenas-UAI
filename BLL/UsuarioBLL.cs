using BE;
using ORM;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL : Iabm<Usuario>
    {
        private static UsuarioBLL instance;
        public static UsuarioBLL GestorUsuarioBLLSG 
        {
            get 
            {
                if(instance == null)
                {
                    instance = new UsuarioBLL();
                }
                return instance;
            }
        }
        public void Alta(Usuario UsuarioAlta)
        {
            UsuarioORM.GestorUsuarioORM.Alta(UsuarioAlta);  
        }

        public void Baja(Usuario UsuarioBaja)
        {
            UsuarioORM.GestorUsuarioORM.Baja(UsuarioBaja);
        }

        public void Modifar(Usuario UsuarioModificado)
        {
            UsuarioORM.GestorUsuarioORM.Modificar(UsuarioModificado);
        }
        public List<Usuario> DevolverUsuariosPorConsulta(string query = "")
        {
            return UsuarioORM.GestorUsuarioORM.DevolverLosUsuariosPorConsulta(query);
        }
    }
}
