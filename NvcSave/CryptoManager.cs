
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace NvcUtils.NvcSave
{
    public static class CryptoManager
    {
        private static readonly string key = "your-128-196-256-bit-key";
        private static readonly string iv = "your-128-bit-iv";
        /// <summary>
        /// Encrypt string
        /// </summary>
        /// <param name="stringToEncrypt">String to encrypt</param>
        /// <returns>Return encrypted and converted to string string</returns>
        public static string Encrypt(string stringToEncrypt)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = Encoding.UTF8.GetBytes(iv);

                    ICryptoTransform cryptoTransform = aes.CreateEncryptor();

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                            {
                                streamWriter.Write(stringToEncrypt);
                            }
                            return Convert.ToBase64String(memoryStream.ToArray());
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return null;
            }
        }
        /// <summary>
        /// Decrypt string
        /// </summary>
        /// <param name="stringToDecrypt">String to decrypt</param>
        /// <returns>Return decrypted string</returns>
        public static string Decrypt(string stringToDecrypt)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = Encoding.UTF8.GetBytes(iv);

                    ICryptoTransform cryptoTransform = aes.CreateDecryptor();
                    byte[] bytes = Convert.FromBase64String(stringToDecrypt);

                    using (MemoryStream memoryStream = new MemoryStream(bytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader(cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return null;
            }
        }
    }
}
