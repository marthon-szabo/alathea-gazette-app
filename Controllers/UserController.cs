using AlatheaGazette.Models;
using AlatheaGazette.Models.Repositories;
using AlatheaGazette.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlatheaGazette.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepo;
        private IUserFactory _userFactory;

        public UserController(IUserRepository userRepo, IUserFactory userFactory)
        {
            _userRepo = userRepo;
            _userFactory = userFactory;
        }
        
        // GET
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            UserModel newUserModel = _userFactory.createInstance(1, email, password);
            _userRepo.CreateUser(newUserModel);
            
            return View();
        }
    }
}