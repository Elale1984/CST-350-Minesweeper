using Microsoft.AspNetCore.Mvc;

namespace CST_350_Minesweeper.Controllers
{
    public class RegisterAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
