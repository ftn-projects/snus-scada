using SCADACore.Infrastructure.Domain;
using SCADACore.Infrastructure.Repository;
using SCADACore.Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SCADACore.Infrastructure.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        
        private static Dictionary<string, User> _authenticatedUsers = new Dictionary<string, User>();

        public bool IsAuthenticated(string token)
        {
            return _authenticatedUsers.ContainsKey(token);
        }

        public string Login(string username, string password)
        {
            using (var db = new UserContext())
            {
                foreach(var user in db.Users)
                {
                    if(username == user.Username &&
                        DataEncryptionUtils.ValidateEncryptedData(password, user.EncryptedPassword))
                    {
                        string token = GenerateToken(username);
                        _authenticatedUsers.Add(token, user);
                        return token;
                    }
                }
            }
            return null;
        }


        public bool Logout(string token)
        {
            return _authenticatedUsers.Remove(token);   
        }

        public bool Register(string username, string password)
        {
            string encryptedPassword = DataEncryptionUtils.EncryptData(password);
            User user = new User(username, encryptedPassword);
            
            using(var db = new UserContext())
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                } catch(Exception ex)
                {
                    return false;
                }
            }
            return true;
        }


        private string GenerateToken(string username)
        {
            using (var cryptoService = new RNGCryptoServiceProvider())
            {
                byte[] randomValue = new byte[32];
                cryptoService.GetBytes(randomValue);
                string randomString = Convert.ToBase64String(randomValue);
                return username + randomString;
            }
            
        }

    }
}