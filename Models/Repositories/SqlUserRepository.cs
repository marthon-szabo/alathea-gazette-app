using System.Linq;

namespace AlatheaGazette.Models.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        private AppDbContext _context;

        public SqlUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateUser(UserModel newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public void DeleteUserById(int id)
        {
            UserModel toDelete = _context.Users.Find(id);
            _context.Users.Remove(toDelete);
            _context.SaveChanges();
        }

        public IQueryable<UserModel> GetUsers()
        {
            return _context.Users;
        }

        public void UpdateUser(UserModel update)
        {
            var updated = _context.Users.Attach(update);
            updated.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
