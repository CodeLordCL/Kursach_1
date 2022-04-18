using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Kursach_1.Managers
{
    internal class AES_Cypher
    {
        public string Encrypt_AES(string plain_text, string pass, byte[] vector)
        {
            byte[] key = Encoding.ASCII.GetBytes(pass);

            AesManaged aes_managed = new AesManaged();

            aes_managed.Key = key;

            aes_managed.IV = vector;

            MemoryStream memory_stream = new MemoryStream();

            CryptoStream crypto_stream = new CryptoStream(memory_stream, aes_managed.CreateEncryptor(), CryptoStreamMode.Write);

            byte[] input = Encoding.ASCII.GetBytes(plain_text);

            crypto_stream.Write(input, 0, input.Length);

            crypto_stream.FlushFinalBlock();

            byte[] encrypted = memory_stream.ToArray();

            return Convert.ToBase64String(encrypted);
        }

        public string Decrypt_AES(string plain_text, string pass, byte[] vector)
        {
            byte[] key = Encoding.ASCII.GetBytes(pass);

            AesManaged aes_managed = new AesManaged();

            aes_managed.Key = key;

            aes_managed.IV = vector;

            MemoryStream memory_stream = new MemoryStream();

            CryptoStream crypto_stream = new CryptoStream(memory_stream, aes_managed.CreateDecryptor(), CryptoStreamMode.Write);

            byte[] inputBytes = Convert.FromBase64String(plain_text);

            crypto_stream.Write(inputBytes, 0, inputBytes.Length);

            crypto_stream.FlushFinalBlock();

            byte[] decrypted = memory_stream.ToArray();

            return UTF8Encoding.ASCII.GetString(decrypted, 0, decrypted.Length);
        }
    }
}
