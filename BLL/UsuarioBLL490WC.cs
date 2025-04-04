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
    public class UsuarioBLL490WC : Iabm490WC<Usuario490WC>
    {
        #region Verificadores
        public bool VerificarDNI(string DNI)
        {
            Regex rgx = new Regex("^[0-9]{2}[.]{1}[0-9]{3}[.]{1}[0-9]{3}$");
           
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
            Usuario490WC usuario = DevolverUsuariosPorConsulta().Find(x => x.DNI == DNI);
          
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
            Usuario490WC usuario = DevolverUsuariosPorConsulta().Find(x => x.Email == Email);
        
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
           
            Usuario490WC usuario = DevolverUsuariosPorConsulta().Find(x => x.Username == username);
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
            if(Cifrador490WC.GestorCifrador.EncriptarIrreversible(ClaveNueva) == Cifrador490WC.GestorCifrador.EncriptarIrreversible(ClaveConfirmacion) && Cifrador490WC.GestorCifrador.EncriptarIrreversible(ClaveNueva) != SesionManager490WC.GestorSesion.UsuarioSesion.Contraseña)
            {
                SesionManager490WC.GestorSesion.UsuarioSesion.Contraseña = Cifrador490WC.GestorCifrador.EncriptarIrreversible(ClaveNueva);
                Modificar(SesionManager490WC.GestorSesion.UsuarioSesion);
                BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
                GestorBitacora.AltaEvento("Cambio de Clave","Usuario Cambió clave",1);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        public void CambiarIdioma(string nuevoIdioma)
        {
            SesionManager490WC.GestorSesion.UsuarioSesion.IdiomaUsuario = nuevoIdioma;
            UsuarioORM490WC GestorORM = new UsuarioORM490WC();
            GestorORM.Modificar(SesionManager490WC.GestorSesion.UsuarioSesion);
            SesionManager490WC.GestorSesion.aplicarLenguaje(nuevoIdioma);
        }
        public void Alta(Usuario490WC UsuarioAlta)
        {
            UsuarioAlta.Contraseña = Cifrador490WC.GestorCifrador.EncriptarIrreversible(UsuarioAlta.Contraseña);
            UsuarioORM490WC.GestorUsuarioORM.Alta(UsuarioAlta);
            BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
            GestorBitacora.AltaEvento("Gestion de Usuario","Alta de Usuario",3);
        }

        public void Baja(Usuario490WC UsuarioBaja)
        {
            UsuarioORM490WC.GestorUsuarioORM.Baja(UsuarioBaja);
            BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
            GestorBitacora.AltaEvento("Gestion de Usuario", "Baja de Usuario", 5);
        }

        public void Modificar(Usuario490WC UsuarioModificado)
        {
            UsuarioORM490WC.GestorUsuarioORM.Modificar(UsuarioModificado);
            BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
            GestorBitacora.AltaEvento("Gestion de Usuario", "Modificacion de Usuario", 3);
        }
        public List<Usuario490WC> DevolverUsuariosPorConsulta(string tipoConsulta = "", string itemSeleccionado = "", string itemValor = "", string itemValor2 = "")
        {
            BitacoraBLL490WC GestorBitacora = new BitacoraBLL490WC();
            GestorBitacora.AltaEvento("Gestion de Usuario", "Consulta de Usuario", 1);
            return UsuarioORM490WC.GestorUsuarioORM.ObtenerUsuariosPorConsulta(tipoConsulta,itemSeleccionado,itemValor, itemValor2);
        }
    }
}
