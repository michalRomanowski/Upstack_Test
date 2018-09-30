using System.Text;
using System.Security.Cryptography;

namespace UpstackTest
{
    public class Encryptor
    {
        private readonly HashAlgorithm cryptoService = new MD5CryptoServiceProvider();

        public string Encrypt(string input)
        {
            var data = Encoding.ASCII.GetBytes(input);
            data = cryptoService.ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }

        public bool IsMatch(string input, string encrypted)
        {
            return string.Equals(Encrypt(input), encrypted);
        }
    }
}