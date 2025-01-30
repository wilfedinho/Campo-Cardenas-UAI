using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class Encriptador
    {
        private static Encriptador instance;
        public static Encriptador GestorEncriptador
        {
            get
            {
                if (instance == null)
                {
                    instance = new Encriptador();
                }
                return instance;
            }
        }
        public string Hashear(string ClaveAEncryptar)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(ClaveAEncryptar);
                byte[] Hashbytes = sha.ComputeHash(bytes);
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < Hashbytes.Length; i++)
                {
                    stringBuilder.Append(Hashbytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

    }
}
