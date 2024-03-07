using System.Security.Cryptography;

namespace RansomSharp.Encrypt
{
    public static class EncryptionHelper
    {
        private static readonly Aes aesAlg = Aes.Create();

        static EncryptionHelper()
        {
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;
        }

        public static string GenerateRandomKey()
        {
            byte[] keyBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(keyBytes);
            }
            return Convert.ToBase64String(keyBytes);
        }

        public static string Encrypt(string plainText, string key)
        {
            ValidateInput(plainText, key);

            byte[] encryptedBytes;
            aesAlg.Key = Convert.FromBase64String(key);
            aesAlg.GenerateIV();

            using (ICryptoTransform encryptor = aesAlg.CreateEncryptor())
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    byte[] plainBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                    csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                }
                encryptedBytes = msEncrypt.ToArray();
            }

            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string encryptedText, string key)
        {
            ValidateInput(encryptedText, key);

            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] iv = new byte[16];
            Array.Copy(encryptedBytes, iv, 16);

            aesAlg.Key = Convert.FromBase64String(key);
            aesAlg.IV = iv;

            using (ICryptoTransform decryptor = aesAlg.CreateDecryptor())
            using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes, 16, encryptedBytes.Length - 16))
            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
            {
                return srDecrypt.ReadToEnd();
            }
        }

        private static void ValidateInput(string text, string key)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Text cannot be null or empty.", nameof(text));

            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));
        }
    }
}
