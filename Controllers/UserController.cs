using Asp.net_core_Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_core_Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDbContext userDbContext;

        public UserController(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                await userDbContext.Users.AddAsync(user);
                await userDbContext.SaveChangesAsync();
                TempData["Register"] = "User Registered successfully";
            }
            return View();
        }

        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var userData = userDbContext.Users.Where(item=>item.Email == user.Email && item.Password == user.Password).FirstOrDefault();
            if (userData != null)
            {
                HttpContext.Session.SetString("email",userData.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login Failed";
            }
            return View();
        }

        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("email").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("email") != null)
            {
                HttpContext.Session.Remove("email");
                return RedirectToAction("Login");
            }
            return View();
        }

    }
}
