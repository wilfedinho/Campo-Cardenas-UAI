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
        public bool VerificarUsernameDuplicado(string username)
        {
            //Si el usuario Posee un Username Duplicado devolverá True
            Usuario usuario = DevolverUsuariosPorConsulta().Find(x => x.Username == username);
            if(usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarCambioClave(string ClaveNueva, string ClaveConfirmacion)
        {
            if(Cifrador.GestorCifrador.EncriptarIrreversible(ClaveNueva) == Cifrador.GestorCifrador.EncriptarIrreversible(ClaveConfirmacion) && Cifrador.GestorCifrador.EncriptarIrreversible(ClaveNueva) != SesionManager.GestorSesion.UsuarioSesion.Contraseña)
            {
                SesionManager.GestorSesion.UsuarioSesion.Contraseña = Cifrador.GestorCifrador.EncriptarIrreversible(ClaveNueva);
                Modificar(SesionManager.GestorSesion.UsuarioSesion);
                BitacoraBLL GestorBitacora = new BitacoraBLL();
                GestorBitacora.AltaEvento("Cambio de Clave","Usuario Cambió clave",1);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void CambiarIdioma(string nuevoIdioma)
        {
            SesionManager.GestorSesion.UsuarioSesion.IdiomaUsuario = nuevoIdioma;
            UsuarioORM GestorORM = new UsuarioORM();
            GestorORM.Modificar(SesionManager.GestorSesion.UsuarioSesion);
            SesionManager.GestorSesion.aplicarLenguaje(nuevoIdioma);
        }
        public void Alta(Usuario UsuarioAlta)
        {
            UsuarioAlta.Contraseña = Cifrador.GestorCifrador.EncriptarIrreversible(UsuarioAlta.Contraseña);
            UsuarioORM.GestorUsuarioORM.Alta(UsuarioAlta);
            BitacoraBLL GestorBitacora = new BitacoraBLL();
            GestorBitacora.AltaEvento("Gestion de Usuario","Alta de Usuario",3);
        }

        public void Baja(Usuario UsuarioBaja)
        {
            UsuarioORM.GestorUsuarioORM.Baja(UsuarioBaja);
            BitacoraBLL GestorBitacora = new BitacoraBLL();
            GestorBitacora.AltaEvento("Gestion de Usuario", "Baja de Usuario", 5);
        }

        public void Modificar(Usuario UsuarioModificado)
        {
            UsuarioORM.GestorUsuarioORM.Modificar(UsuarioModificado);
            BitacoraBLL GestorBitacora = new BitacoraBLL();
            GestorBitacora.AltaEvento("Gestion de Usuario", "Modificacion de Usuario", 3);
        }
        public List<Usuario> DevolverUsuariosPorConsulta(string tipoConsulta = "", string itemSeleccionado = "", string itemValor = "", string itemValor2 = "")
        {
            BitacoraBLL GestorBitacora = new BitacoraBLL();
            GestorBitacora.AltaEvento("Gestion de Usuario", "Consulta de Usuario", 1);
            return UsuarioORM.GestorUsuarioORM.ObtenerUsuariosPorConsulta(tipoConsulta,itemSeleccionado,itemValor, itemValor2);
        }
    }
}
