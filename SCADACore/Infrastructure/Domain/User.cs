using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SCADACore.Infrastructure.Domain
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(100)]
        [Index(IsUnique = true)]
        public string Username { get; set; }
        
        public string EncryptedPassword { get; set; }


        public User() { }

        public User(string username, string encryptedPassword)
        {
            Username = username;
            EncryptedPassword = encryptedPassword;
        }
    }
}