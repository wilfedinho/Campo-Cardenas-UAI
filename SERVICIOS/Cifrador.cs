using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIOS
{
    public class Cifrador
    {
          private static Cifrador Instancia;
          public static Cifrador GestorCifrador
          {
            get
             {
              if (Instancia == null)
              {
               Instancia = new Cifrador();
              }
              return Instancia;
            }
          }
           private readonly byte[] key;
           private readonly byte[] iv;
          private Cifrador()
          {
            using (Aes aesAlg = Aes.Create())
            {

              aesAlg.GenerateKey();
              aesAlg.GenerateIV();
              key = aesAlg.Key;
              iv = aesAlg.IV;
            }
          }
          public string EncriptarIrreversible(string textoEncriptar)
          {
            using (SHA256 sha256 = SHA256.Create())
            {
               // Convertir la cadena de entrada en bytes antes de aplicar el hash
               byte[] bytes = Encoding.UTF8.GetBytes(textoEncriptar);

               // Calcular el hash de los bytes
               byte[] hashBytes = sha256.ComputeHash(bytes);

               // Convertir el hash en una cadena hexadecimal
               StringBuilder stringBuilder = new StringBuilder();
               for (int i = 0; i < hashBytes.Length; i++)
               {
                 stringBuilder.Append(hashBytes[i].ToString("x2"));
               }
                return stringBuilder.ToString();
            }
          }

          public string EncriptarReversible(string textoEncriptar)
          {
             using (Aes aesAlg = Aes.Create())
             {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform Encriptador = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                   using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, Encriptador, CryptoStreamMode.Write))
                   using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                   {
                     swEncrypt.Write(textoEncriptar);
                   }
                   return Convert.ToBase64String(msEncrypt.ToArray());
                }
             }
          }

          public string DesencriptarReversible(string textoEncriptar)
          {
             using (Aes aesAlg = Aes.Create())
             {
               aesAlg.Key = key;
               aesAlg.IV = iv;

               ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(textoEncriptar)))
                {
                  using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                  using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                  {
                            return srDecrypt.ReadToEnd();
                  }
                }
             }
          }
    }
}
