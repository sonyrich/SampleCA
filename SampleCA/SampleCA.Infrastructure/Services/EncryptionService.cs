using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SampleCA.Application.Common.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace SampleCA.Infrastructure.Services
{
    public class EncryptionService : IEncryptionService
    {
        #region Utilities

        private byte[] EncryptTextToMemory(string data, byte[] key, byte[] iv)
        {
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, TripleDES.Create().CreateEncryptor(key, iv), CryptoStreamMode.Write))
            {
                var toEncrypt = Encoding.Unicode.GetBytes(data);
                cs.Write(toEncrypt, 0, toEncrypt.Length);
                cs.FlushFinalBlock();
            }

            return ms.ToArray();
        }

        private string DecryptTextFromMemory(byte[] data, byte[] key, byte[] iv)
        {
            using var ms = new MemoryStream(data);
            using var cs = new CryptoStream(ms, TripleDES.Create().CreateDecryptor(key, iv), CryptoStreamMode.Read);
            using var sr = new StreamReader(cs, Encoding.Unicode);
            return sr.ReadToEnd();
        }

        #endregion
        public string CreatePasswordHash(string password, string saltstring)
        {
            byte[] salt = Convert.FromBase64String(saltstring);
            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
        public string CreateSaltKey()
        {
            //generate a cryptographic random number
            using var provider = RandomNumberGenerator.Create();
            var buff = new byte[128 / 8];
            provider.GetBytes(buff);

            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        public virtual string EncryptText(string plainText, string encryptionPrivateKey = "")
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;

            if (string.IsNullOrEmpty(encryptionPrivateKey))
                encryptionPrivateKey = "asjklfhjasklasd";

            using var provider = TripleDES.Create();
            provider.Key = Encoding.ASCII.GetBytes(encryptionPrivateKey[0..16]);
            provider.IV = Encoding.ASCII.GetBytes(encryptionPrivateKey[8..16]);

            var encryptedBinary = EncryptTextToMemory(plainText, provider.Key, provider.IV);
            return Convert.ToBase64String(encryptedBinary);
        }

        public virtual string DecryptText(string cipherText, string encryptionPrivateKey = "")
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;

            if (string.IsNullOrEmpty(encryptionPrivateKey))
                encryptionPrivateKey = "asjklfhjasklasd";

            using var provider = TripleDES.Create();
            provider.Key = Encoding.ASCII.GetBytes(encryptionPrivateKey[0..16]);
            provider.IV = Encoding.ASCII.GetBytes(encryptionPrivateKey[8..16]);

            var buffer = Convert.FromBase64String(cipherText);
            return DecryptTextFromMemory(buffer, provider.Key, provider.IV);
        }

    }
}