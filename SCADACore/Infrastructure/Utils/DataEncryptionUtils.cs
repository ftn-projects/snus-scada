using System;
using System.Security.Cryptography;
using System.Text;

namespace SCADACore.Infrastructure.Utils
{
    public static class DataEncryptionUtils
    {


        public static string EncryptData(string password) 
        {
            return EncryptValue(password);
        }
        
        public static bool ValidateEncryptedData(string password, string encryptedPassword)
        {
            string[] databaseEntry = encryptedPassword.Split(':');
            string hashedSaltAndPassword = databaseEntry[0];
            string salt = databaseEntry[1];

            byte[] saltedPassword = Encoding.UTF8.GetBytes(salt + password);
            using(var sha = new SHA256Managed())
            {
                byte[] hash = sha.ComputeHash(saltedPassword);
                string passwordToValidate = Convert.ToBase64String(hash);
                return hashedSaltAndPassword.Equals(passwordToValidate);
            }
        }

        private static string GenerateSalt()
        {
            using(var cryptoService = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[32];
                cryptoService.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }

        private static string EncryptValue(string password)
        {
            string salt = GenerateSalt();
            byte[] saltedPassword = Encoding.UTF8.GetBytes(salt + password);
            
            using(var sha = new SHA256Managed())
            {
                byte[] hash = sha.ComputeHash(saltedPassword);
                return $"{Convert.ToBase64String(hash)}:{salt}";
            }
        }

    }
}