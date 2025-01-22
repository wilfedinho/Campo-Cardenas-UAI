using BE;
using ORM;
using SERVICIOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
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
        
        public bool VerificarDNI(string DNI)
        {
            Regex rgx = new Regex("^[0-9]{2}[.]{1}[0-9]{3}[.]{1}[0-9]{3}$");
            //Sie esta bien el formato devolverá True
            if(rgx.IsMatch(DNI))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarDNIDuplicado(string DNI)
        {
            Usuario usuario = DevolverUsuariosPorConsulta().Find(x => x.DNI == DNI);
            //Si el usuario Posee un DNI Duplicado devovlerá True
            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
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

        public void Modificar(Usuario UsuarioModificado)
        {
            UsuarioORM.GestorUsuarioORM.Modificar(UsuarioModificado);
        }
        public List<Usuario> DevolverUsuariosPorConsulta(string query = "")
        {
            return UsuarioORM.GestorUsuarioORM.DevolverLosUsuariosPorConsulta(query);
        }
    }
}
