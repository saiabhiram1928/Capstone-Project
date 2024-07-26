﻿using System.Security.Cryptography;
using System.Text;

namespace Health_Insurance_Application.Services.Helpers
{
    public class HashHelper
    {
        public bool AuthenticatePassword(string enteredpasswd, byte[] salt, byte[] realpasswd)
        {
            HMACSHA512 hmac = new HMACSHA512(salt);
            var encryptpasswd = hmac.ComputeHash(Encoding.UTF8.GetBytes(enteredpasswd));
            if (realpasswd.Length != encryptpasswd.Length) return false;
            for (int i = 0; i < realpasswd.Length; i++)
            {
                if (realpasswd[i] != encryptpasswd[i])
                    return false;
            }
            return true;

        }

        public (byte[], byte[]) HashPasswd(string passwd)
        {
            HMACSHA512 hmac = new HMACSHA512();
            var salt = hmac.Key;
            var enypasswd = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwd));
            return (enypasswd, salt);
        }
    }
}
