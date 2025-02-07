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
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public int Intentos { get; set; }
        public bool IsBloqueado { get; set; }

        public Usuario(int nID, string nUsername, string nNombre, string nApellido, string nDNI, string nContraseña, string nEmail, string rOL, int nIntentos = 0, bool nIsBloqueado = false)
        {
            ID_Usuario = nID;
            Username = nUsername;
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
