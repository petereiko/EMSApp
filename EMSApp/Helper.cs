using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSApp
{
    public static class Helper
    {
        public static string Encrypt(int id)
        {
            string plainText = id.ToString();
            byte[] encrypted = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(encrypted);
            
        }

        public static int Decrypt(string encrypted)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(encrypted);
            string plainText = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            return Convert.ToInt32(plainText);
        }
    }
}