using Microsoft.AspNetCore.Mvc;

using CST_350_Minesweeper.Models;
using CST_350_Minesweeper.Services;

namespace login.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(User user)
        {
            LoginService securityService = new LoginService();
            if (securityService.IsValid(user))
            {
                return RedirectToAction("Index", "Home", new { user = user });
            }
            else
            {
                return View("LoginFailure", user);
            }
        }
    }
}