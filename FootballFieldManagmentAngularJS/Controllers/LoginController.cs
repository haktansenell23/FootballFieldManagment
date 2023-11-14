using Microsoft.AspNetCore.Mvc;

namespace FootballFieldManagmentAngularJS.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
