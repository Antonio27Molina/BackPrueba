using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Back.Comun.Encrypt
{
    public static class Encrypt
    {
        public static string EncryptString(string plainText)
        {
            string password = "Prueba123";

            SHA256 mySHA256 = SHA256Managed.Create();
            byte[] key = mySHA256.ComputeHash(Encoding.ASCII.GetBytes(password));

            byte[] iv = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };

            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;

            byte[] aesKey = new byte[32];
            Array.Copy(key, 0, aesKey, 0, 32);
            encryptor.Key = aesKey;
            encryptor.IV = iv;

            MemoryStream memoryStream = new MemoryStream();

            ICryptoTransform aesEncryptor = encryptor.CreateEncryptor();


            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);

            byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);

            cryptoStream.Write(plainBytes, 0, plainBytes.Length);

            cryptoStream.FlushFinalBlock();

            byte[] cipherBytes = memoryStream.ToArray();


            memoryStream.Close();
            cryptoStream.Close();

            string cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);

            return cipherText;
        }
    }
}
