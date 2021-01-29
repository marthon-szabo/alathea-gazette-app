using AlatheaGazette.Models;


namespace AlatheaGazette.Services
{
    public class UserFactory : IUserFactory
    {
        private IPasswordHasher _passwordHasher;

        public UserFactory(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public UserModel createInstance(string email, string password)
        {
            string[] saltAndPassword = _passwordHasher.HashMe(password);

            return new UserModel()
            {
                Email = email,
                PasswordSalt = saltAndPassword[0],
                HashedPassword = saltAndPassword[1]
            };
        }
    }
}