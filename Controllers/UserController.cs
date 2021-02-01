using AlatheaGazette.Models;
using AlatheaGazette.Models.Repositories;
using AlatheaGazette.Services;
using AlatheaGazette.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Text;
using System.Web;

namespace AlatheaGazette.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepo;
        private IUserFactory _userFactory;
        private IPasswordHasher _passwordHasher;
        private IMemoryCache _memoryCache;

        public UserController(IUserRepository userRepo, IUserFactory userFactory, 
            IPasswordHasher passwordHasher, IMemoryCache memoryCache)
        {
            _userRepo = userRepo;
            _userFactory = userFactory;
            _passwordHasher = passwordHasher;
            _memoryCache = memoryCache;
        }
        
        // GET
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            if (_passwordHasher.ValidateMe(loginVM.UserEmail, loginVM.UserPassword))
            {
                string sessionId =  BCrypt.Net.BCrypt.GenerateSalt();
                HttpContext.Session.SetString("id", sessionId);

                ViewData["sessionId"] = HttpContext.Session.GetString("id");
            }
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

            return RedirectToAction("Login");
        }
    }
}