using MySQLApp;
using System;
using System.Net;

namespace _111
{
    public class Utils
    {
        const string md5_salt = "hbJHhbjh1g27@";

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string MD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(md5_salt+input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }

        public static bool CheckToken(ApplicationContext db, string authorization)
        {
            try
            {
                var finded = db.Users.FirstOrDefault(x => x.token == authorization.Replace("Bearer ", ""));
                return finded != null;
            }catch { return false; }
        }

        public static Dictionary<string, string> GenerateError (string desc)
        {
            return new Dictionary<string, string> { { "error", desc } };
        }
    }
}
