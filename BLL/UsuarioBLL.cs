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
            //Si el usuario Posee un DNI Duplicado devolverá True
            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarEmailDuplicado(string Email)
        {
            Usuario usuario = DevolverUsuariosPorConsulta().Find(x => x.Email == Email);
            //Si el usuario Posee un Email Duplicado devolverá True
            if (usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarEmail(string email)
        {
            //Devolverá True si el formato de mail ta correcto
            Regex rgx = new Regex (@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$");
            if(rgx.IsMatch(email))
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
            UsuarioAlta.Contraseña = Cifrador.GestorCifrador.EncriptarIrreversible(UsuarioAlta.Contraseña);
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
        public List<Usuario> DevolverUsuariosPorConsulta(string tipoConsulta = "", string itemSeleccionado = "", string itemValor = "")
        {
            return UsuarioORM.GestorUsuarioORM.DevolverLosUsuariosPorConsulta(tipoConsulta,itemSeleccionado,itemValor);
        }
    }
}
