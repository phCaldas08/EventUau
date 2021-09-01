using System;
using System.Security.Cryptography;
using System.Text;

namespace Event.Uau.Comum.Util.Extensoes
{
    public static class HashMd5
    {
        private static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string ToHash(this string secret)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(secret))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
