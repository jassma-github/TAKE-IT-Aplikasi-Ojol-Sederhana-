using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace ISA_LIB
{
    public class IsaAesCrypt
    {
        public static string iv = "takeittakeittake";
        public static string key ="takeittakeittakeittakeittakeitta";

        public static string EncryptedData(string decrypted)
        {
          byte[] textbytes = Encoding.UTF8.GetBytes(decrypted);
          AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key=Encoding.UTF8.GetBytes(key);
            aes.IV= Encoding.UTF8.GetBytes(iv);
          
            aes.Mode = CipherMode.CBC;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            byte[] enc = encryptor.TransformFinalBlock(textbytes, 0, textbytes.Length);
            encryptor.Dispose();

            return Convert.ToBase64String(enc);
            
        }
        public static string DecryptedData(string encrypted)
        {
            byte[] encbytes =Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = Encoding.UTF8.GetBytes(iv);
          
            aes.Mode = CipherMode.CBC;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            byte[] dec = decryptor.TransformFinalBlock(encbytes, 0, encbytes.Length);
            decryptor.Dispose();

            return Encoding.UTF8.GetString(dec);

        }

    }
}
