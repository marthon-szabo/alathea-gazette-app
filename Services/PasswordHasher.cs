using System.Text;

namespace AlatheaGazette.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string[] HashMe(string plainText)
        {
            StringBuilder saltedPassword = new StringBuilder();
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            saltedPassword.Append(salt);
            saltedPassword.Append(BCrypt.Net.BCrypt.HashPassword(plainText));

            return new string[2] { salt, saltedPassword.ToString() };
        }
    }
}
