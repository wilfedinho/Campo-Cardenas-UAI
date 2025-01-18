using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public int Intentos { get; set; }
        public bool IsBloqueado { get; set; }

        public Usuario(int nID,string nNombre, string nApellido, string nDNI, string nContraseña, string nEmail, string rOL)
        {
            ID_Usuario = nID;
            Nombre = nNombre;
            Apellido = nApellido;
            DNI = nDNI;
            Contraseña = nContraseña;
            Email = nEmail;
            Rol = rOL;
            Intentos = 0;
            IsBloqueado = false;
        }
        public Usuario(int nID, string nNombre, string nApellido, string nDNI, string nContraseña, string nEmail, string rOL, int nIntentos, bool nIsBloqueado)
        {
            ID_Usuario = nID;
            Nombre = nNombre;
            Apellido = nApellido;
            DNI = nDNI;
            Contraseña = nContraseña;
            Email = nEmail;
            Rol = rOL;
            Intentos = nIntentos;
            IsBloqueado = nIsBloqueado;
        }


    }
}
