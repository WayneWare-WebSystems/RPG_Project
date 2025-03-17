using Microsoft.AspNetCore.Mvc;

namespace RPG_Project.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
