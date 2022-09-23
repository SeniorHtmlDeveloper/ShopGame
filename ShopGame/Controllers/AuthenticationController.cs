using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopGame.Models;
using System.Security.Claims;

namespace ShopGame.Controllers
{
    public class AuthenticationController : Controller
    {
        ShopContext db;

        public AuthenticationController(ShopContext _context)
        {
            db = _context;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult SignIn()
        //{
        //    return View();
        //}

        //public IActionResult Registration()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Registration(string userName, string password)
        //{
        //    var user = new User() { UserName = userName, Password = password };
        //    db.Users.Add(user);
        //    db.SaveChanges();
        //    return Redirect(@"https://localhost:7095/");
        //}


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginModel model)
        {
            

            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.UserName); // аутентификация

                    return RedirectToAction("Main", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User? user = await db.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    db.Users.Add(new User { UserName = model.UserName, Password = model.Password });
                    await db.SaveChangesAsync();

                    await Authenticate(model.UserName); // аутентификация

                    return RedirectToAction("Main", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {

            //создаем один claim
           var claims = new List<Claim>
           {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
           };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Main", "Home");
        }


    }
}
