using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopGame.Models;
using System;
using System.Diagnostics;

namespace ShopGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ShopContext db;


        public HomeController(ILogger<HomeController> logger, ShopContext context)
        {
            _logger = logger;
            db = context;
            FixedImageUrl(db);
        }

        public void FixedImageUrl(ShopContext context)
        {
            var games = db.Games.ToList();
            foreach (var game in games)
                game.Image = "https://" + game.Image;
        }

       
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var users = db.Users.ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public IActionResult Main()
        {
            IsLogin();
            var games = db.Games.ToList();
            return View(games);
        }

        

        public IActionResult GamePage(int GameId)
        {
            IsLogin();  
            var game = db.Games.Find(GameId);
            return View(game);
        }

        [AllowAnonymous]
        public IActionResult AddOrder(int GameId)
        {
            if (User.Identity != null)
            {
                User? user = db.Users.FirstOrDefault(item => item.UserName == User.Identity.Name);
                Game game = db.Games.Find(GameId);
                var order = new Order() { User = user, Games = new List<Game>() { game } };
                
            }

            return RedirectToAction("Main", "Home");
        }

        [AllowAnonymous]
        public void IsLogin()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                ViewData["ButtonContent"] = "ВЫЙТИ";
                ViewData["UserName"] = User.Identity.Name;
                ViewData["Action"] = "Logout";

            }
            else
            {
                ViewData["ButtonContent"] = "ВОЙТИ";
                ViewData["Action"] = "SignIn";
            }
        }
    }
}