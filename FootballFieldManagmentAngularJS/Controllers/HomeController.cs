using FootballFieldManagmentAngularJS.Models;
using FootballFieldManagmentAngularJS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FootballFieldManagmentAngularJS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        
        {

            if (ViewBag.model !=null)
            {
                ViewBag.model = ViewBag.model;
            }
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel Login)
        {
            return View();
        }
        public IActionResult SignUp() {

            return View();
        }

        [HttpPost]
        public IActionResult SignUp([FromBody]SignUpViewModel SignUpModel)
        {

            ViewBag.model = SignUpModel;
            return RedirectToAction("Index","Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}