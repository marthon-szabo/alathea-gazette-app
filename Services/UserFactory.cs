using AlatheaGazette.Models;

namespace AlatheaGazette.Services
{
    public class UserFactory : IUserFactory
    {
        public UserModel createInstance(int id, string email, string password)
        {
            return new UserModel()
            {
                UserId = id,
                Email = email,
                Password = password
            };
        }
    }
}