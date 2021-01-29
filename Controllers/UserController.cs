using AlatheaGazette.Models;
using AlatheaGazette.Models.Repositories;
using AlatheaGazette.Services;
using AlatheaGazette.ViewModels;
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

        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Register(LoginVM loginVM)
        {
            // check if the user already exists
            UserModel registered = _userRepo.GetUserById(loginVM.UserId);

            if (registered != null && registered.Email == loginVM.UserEmail)
            {
                ViewData["Error"] = "This email address has been registered, already!";

                return View();
            }

            registered = _userFactory.createInstance(loginVM.UserEmail, loginVM.UserPassword);
            _userRepo.CreateUser(registered);

            return View();
        }
    }
}