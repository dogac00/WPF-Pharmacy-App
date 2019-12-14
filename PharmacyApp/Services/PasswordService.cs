using System.Security.Cryptography;
using System.Text;

namespace PharmacyApp.Services
{
    class PasswordService
    {
        public string HashPassword(string plainPassword)
        {
            using SHA256 sha256Hash = SHA256.Create();
            
            var plainBytes = Encoding.UTF8.GetBytes(plainPassword);
                
            byte[] bytes = sha256Hash.ComputeHash(plainBytes);

            StringBuilder builder = new StringBuilder();
                
            foreach (var t in bytes)
            {
                builder.Append(t.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
