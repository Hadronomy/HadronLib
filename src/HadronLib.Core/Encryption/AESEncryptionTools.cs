using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace HadronLib.Encryption
{
    /// <summary>
    /// A set of encryption/decryption functions for the AES algorithm
    /// </summary>
    public static class AESEncryptionTools
    {
        /// <summary>
        /// Decrypts an array of bytes into plain text
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] DecryptFromBytes(byte[] cipherText, byte[] Key)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");

            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.Mode = CipherMode.ECB;

                using (var memStream = new MemoryStream())
                {
                    using (var cryptoStream =
                        new CryptoStream(memStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(cipherText, 0, cipherText.Length);
                    }

                    return memStream.ToArray();
                }
            }
        }

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        public static byte[] RemoveHeader(byte[] bytes)
        {
            var cSharpHeader = Utils.StringToByteArray("0001000000FFFFFFFF01000000000000000601000000");
            var resultingBytes = bytes.Skip(cSharpHeader.Length).Take(bytes.Length - cSharpHeader.Length - 1).ToArray();

            return resultingBytes;
        }

        public static byte[] DecodeHollow(byte[] bytes)
        {
            string key = "UKu52ePUBwetZ9wNX88o54dnfKRu0T1l";
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            bytes = RemoveHeader(bytes);
            var base64String = Encoding.UTF8.GetString(bytes);
            base64String = Regex.Replace(base64String, "[^-A-Za-z0-9+/=]", "");
            bytes = DecodeBase64Bytes(Encoding.UTF8.GetBytes(base64String));
            bytes = DecryptFromBytes(bytes, keyBytes);
            
            return bytes;
        }

        public static byte[] DecodeBase64Bytes(this byte[] base64Bytes)
        {
            using (var memStream = new MemoryStream())
            {
                using (var crypto = new CryptoStream(memStream, new FromBase64Transform(), CryptoStreamMode.Write))
                {
                    crypto.Write(base64Bytes, 0, base64Bytes.Length);
                }

                return memStream.ToArray();
            }
        }
    }
}