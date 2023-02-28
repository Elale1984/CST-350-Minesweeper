using Microsoft.AspNetCore.Mvc;

using CST_350_Minesweeper.Models;
using CST_350_Minesweeper.Services;
using Milestone.Controllers;

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
            LoginService loginService = new LoginService();
            
            if (loginService.IsValid(user))
            {
                User currentUser = loginService.GetCurrentLoggedInUser();
                var minesweeperBoardController = new MinesweeperBoardController();

                return RedirectToAction("Index", "MinesweeperBoard");

            }
            else
            {
                return View("LoginFailure", user);
            }
        }
    }
}