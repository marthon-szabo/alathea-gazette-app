using AlatheaGazette.Models;

namespace AlatheaGazette.Services
{
    public interface IUserFactory
    {
        public UserModel createInstance(string email, string password);
    }
}