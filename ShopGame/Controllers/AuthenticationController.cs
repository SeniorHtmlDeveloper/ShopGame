using Microsoft.AspNetCore.Mvc;

namespace ShopGame.Controllers
{
    public class AuthenticationController : Controller
    {
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
