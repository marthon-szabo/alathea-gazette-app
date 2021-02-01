using AlatheaGazette.Models;
using AlatheaGazette.Models.Repositories;
using System.Text;

namespace AlatheaGazette.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        private IUserRepository _userRepo;

        public PasswordHasher(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public string[] HashMe(string plainText)
        {
            StringBuilder saltedPassword = new StringBuilder();
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            saltedPassword.Append(salt);
            saltedPassword.Append(BCrypt.Net.BCrypt.HashPassword(plainText));

            return new string[2] { salt, saltedPassword.ToString() };
        }

        public bool ValidateMe(string plainText, string email)
        {
            string[] saltAndPassword = this.HashMe(plainText);

            UserModel referenceUser = _userRepo.GetUserByEmail(email);

            if (referenceUser.PasswordSalt == saltAndPassword[0] && 
                referenceUser.HashedPassword == saltAndPassword[1])
            {
                return true;
            }

            return false;
        }
    }
}
