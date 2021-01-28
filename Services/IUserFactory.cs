using AlatheaGazette.Models;

namespace AlatheaGazette.Services
{
    public interface IUserFactory
    {
        public UserModel createInstance(int id, string email, string password);
    }
}