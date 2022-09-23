using Microsoft.AspNetCore.Mvc;
using ShopGame.Models;

namespace ShopGame.Controllers
{
    public class AuthenticationController : Controller
    {
        ShopContext db;

        public AuthenticationController(ShopContext _context)
        {
            db = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(string userName, string password)
        {
            var user = new User() { UserName = userName, Password = password };
            db.Users.Add(user);
            db.SaveChanges();
            return Redirect(@"https://localhost:7095/");
        }

    }
}
