using System.Linq;

namespace AlatheaGazette.Models.Repositories
{
    public interface IUserRepository
    {
        public void CreateUser(UserModel newUser);
        public IQueryable<UserModel> GetUsers();
        public void UpdateUser(UserModel update);
        public void DeleteUserById(int id);
    }
}
