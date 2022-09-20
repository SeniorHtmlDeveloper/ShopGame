using Microsoft.AspNetCore.Mvc;
using ShopGame.Models;

namespace ShopGame.Controllers
{
    public class AuthenticationController : Controller
    {
        ShopContext context;

        public AuthenticationController(ShopContext _context)
        {
            this.context = _context;
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
    }
}
