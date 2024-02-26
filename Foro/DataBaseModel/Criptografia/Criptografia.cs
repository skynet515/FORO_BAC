using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseModel.Criptografia
{
    public class Criptografia
    {
        internal static string cadenaConexion
        {
            get
            {
                //servidor
                return "hFTmsXw9Fs4mvqG+VvV2LYS3v8l/rNWyt8rJRKcokbww2bjK5yBtNdNF1EKC3kgxXFKWo/qAbCbzTpN+XLwKBhQFfqJVAeL9ADxmhSdkgddUkjXG6NtjoZdwSnI9xY8hJKATT1BbVewqv4bh5c62k14jx7Bm258P4YutZnFJvtoDkcIveSsBNigpUM6jwtEZg1JXnfB2kXPkK4UF4AavnPC+cP7MRp7iw53pvMt15+c=";
                //local
                //return "kz5UStCmuB5MHCsAdnM+fkSackixrJZsOS/f8lDeyRTB0F+EplERyQ/wNnV78Ckqb8V5SMsVZsCLT8hsOQYsubsHtJvd8t8zo+q74+FQFCzKZNhQTH+JmKW2vW+S9kGp5a9yJROWkeslERwwOvhWKBkACXfLBMP+tbpffz59aOtb60I4BcBXtlV/em9Rw74orU6DTe0O+/8o5SpaLQq0IA==";
            }
        }

        public static string Encrypt(string cadenaOriginal)
        {
            string cadenaEncriptada = "";
            try
            {
                string EncryptionKey = "APP_KEY";
                byte[] clearBytes = Encoding.Unicode.GetBytes(cadenaOriginal);
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[]
                      { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(),
                      CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        cadenaEncriptada = Convert.ToBase64String(ms.ToArray());
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cadenaEncriptada;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "APP_KEY";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[]
                     { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(),
                                               CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
