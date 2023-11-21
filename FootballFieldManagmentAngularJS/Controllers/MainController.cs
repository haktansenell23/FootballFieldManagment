using Microsoft.AspNetCore.Mvc;

namespace FootballFieldManagmentAngularJS.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
