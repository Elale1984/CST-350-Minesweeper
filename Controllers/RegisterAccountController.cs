using CST_350_Minesweeper.Models;
using CST_350_Minesweeper.Services;
using Microsoft.AspNetCore.Mvc;

namespace CST_350_Minesweeper.Controllers
{
    public class RegisterAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessRegisterUser(User user)
        {
            RegisterService service= new RegisterService();
            if (!service.IsValid(user))
                return View("RegisterFailure", user);
            else
            {
                return View("RegisterSuccess", user);
            }
        }
    }
}
