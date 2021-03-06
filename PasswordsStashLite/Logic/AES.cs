﻿using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordsStashLite.Logic
{
    public class AES
    {
        public static string Encrypt(string input, string password)
        {
            string result = "";
            if (!String.IsNullOrEmpty(input))
            {
                try
                {
                    byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
                    byte[] bytesEncrypted = AES_Encrypt(bytesToBeEncrypted, passwordBytes);
                    result = Convert.ToBase64String(bytesEncrypted);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return input;
                }
            }
            return result;
        }
        public static string Decrypt(string input, string password)
        {
            string result = "";
            if (!String.IsNullOrEmpty(input))
            {
                try
                {
                    byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    passwordBytes = SHA256.Create().ComputeHash(passwordBytes);
                    byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);
                    result = Encoding.UTF8.GetString(bytesDecrypted);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return input;
                }
            }
            return result;
        }

        #region CLASS METHODS

        static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;
                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }
                    encryptedBytes = ms.ToArray();
                }
            }
            return encryptedBytes;
        }
        static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;
                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);
                    AES.Mode = CipherMode.CBC;
                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }
            return decryptedBytes;
        }

        #endregion
    }
}