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
        public bool VerificarDNI490WC(string DNI490WC)
        {
            Regex rgx490WC = new Regex("^[0-9]{2}[.]{1}[0-9]{3}[.]{1}[0-9]{3}$");
           
            if(rgx490WC.IsMatch(DNI490WC))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarEmail490WC(string email490WC)
        {
            
            Regex rgx490WC = new Regex (@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$");
            if(rgx490WC.IsMatch(email490WC))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public bool VerificarDNIDuplicado490WC(string DNI490WC)
        {
            Usuario490WC usuario490WC = DevolverUsuariosPorConsulta490WC().Find(x => x.DNI490WC == DNI490WC);
          
            if (usuario490WC != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarEmailDuplicado490WC(string Email490WC)
        {
            Usuario490WC usuario490WC = DevolverUsuariosPorConsulta490WC().Find(x => x.Email490WC == Email490WC);
        
            if (usuario490WC != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool VerificarUsernameDuplicado490WC(string username490WC)
        {
           
            Usuario490WC usuario = DevolverUsuariosPorConsulta490WC().Find(x => x.Username490WC == username490WC);
            if(usuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool VerificarCambioClave490WC(string ClaveNueva490WC, string ClaveConfirmacion490WC)
        {
            if(Cifrador490WC.GestorCifrador490WC.EncriptarIrreversible490WC(ClaveNueva490WC) == Cifrador490WC.GestorCifrador490WC.EncriptarIrreversible490WC(ClaveConfirmacion490WC) && Cifrador490WC.GestorCifrador490WC.EncriptarIrreversible490WC(ClaveNueva490WC) != SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC.Contraseña490WC)
            {
                SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC.Contraseña490WC = Cifrador490WC.GestorCifrador490WC.EncriptarIrreversible490WC(ClaveNueva490WC);
                Modificar490WC(SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC);
                BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
                GestorBitacora490WC.AltaEvento490WC("Cambio de Clave","Usuario Cambió clave",1);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        public void CambiarIdioma490WC(string nuevoIdioma490WC)
        {
            SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC.IdiomaUsuario490WC = nuevoIdioma490WC;
            UsuarioORM490WC GestorORM490WC = new UsuarioORM490WC();
            GestorORM490WC.Modificar490WC(SesionManager490WC.GestorSesion490WC.UsuarioSesion490WC);
            SesionManager490WC.GestorSesion490WC.aplicarLenguaje490WC(nuevoIdioma490WC);
        }
        public void Alta490WC(Usuario490WC UsuarioAlta490WC)
        {
            UsuarioAlta490WC.Contraseña490WC = Cifrador490WC.GestorCifrador490WC.EncriptarIrreversible490WC(UsuarioAlta490WC.Contraseña490WC);
            UsuarioORM490WC.GestorUsuarioORM490WC.Alta490WC(UsuarioAlta490WC);
            BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
            GestorBitacora490WC.AltaEvento490WC("Gestion de Usuario","Alta de Usuario",3);
        }

        public void Baja490WC(Usuario490WC UsuarioBaja490WC)
        {
            UsuarioORM490WC.GestorUsuarioORM490WC.Baja490WC(UsuarioBaja490WC);
            BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
            GestorBitacora490WC.AltaEvento490WC("Gestion de Usuario", "Baja de Usuario", 5);
        }

        public void Modificar490WC(Usuario490WC UsuarioModificado490WC)
        {
            UsuarioORM490WC.GestorUsuarioORM490WC.Modificar490WC(UsuarioModificado490WC);
            BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
            GestorBitacora490WC.AltaEvento490WC("Gestion de Usuario", "Modificacion de Usuario", 3);
        }
        public List<Usuario490WC> DevolverUsuariosPorConsulta490WC(string tipoConsulta490WC = "", string itemSeleccionado490WC = "", string itemValor490WC = "", string itemValor2490WC = "")
        {
            BitacoraBLL490WC GestorBitacora490WC = new BitacoraBLL490WC();
            GestorBitacora490WC.AltaEvento490WC("Gestion de Usuario", "Consulta de Usuario", 1);
            return UsuarioORM490WC.GestorUsuarioORM490WC.ObtenerUsuariosPorConsulta490WC(tipoConsulta490WC,itemSeleccionado490WC,itemValor490WC, itemValor2490WC);
        }
    }
}
