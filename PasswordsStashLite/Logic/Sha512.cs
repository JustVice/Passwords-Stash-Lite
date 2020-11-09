using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordsStashLite.Logic
{
    public class Sha512
    {
        public static string string_to_sha512(string string_to_sha512)
        {
            using (SHA512 sha512Hash = SHA512.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(string_to_sha512);
                byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                return hash;
            }
        }
    }
}
