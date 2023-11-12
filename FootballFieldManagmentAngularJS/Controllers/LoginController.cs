using Microsoft.AspNetCore.Mvc;

namespace FootballFieldManagmentAngularJS.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]  
        //public IActionResult Login()
        //{


        //    return View();
        //}


    }
}
