using FootballFieldManagment.Core.Entities;
using FootballFieldManagment.Core.Services;
using FootballFieldManagmentAngularJS.Models;
using FootballFieldManagmentAngularJS.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FootballFieldManagmentAngularJS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
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
        public async Task<IActionResult> SignUp([FromBody]SignUpViewModel SignUpModel)
        {

            if (SignUpModel.Password != SignUpModel.RePassword)
            {
                return Json(new { title = "İşleminiz başarısız", message ="Şifreler uyuşmuyor<br/>", buttonText = "Oke", statu = false });
            }

            //var result = await  _userManager.CreateAsync(new() {UserName = SignUpModel.UserName,Email=SignUpModel.Email,PhoneNumber=SignUpModel.PhoneNumber},SignUpModel.RePassword);
          

            //if (!result.Succeeded)
            //{
            //    var errorStr = "";

            //    foreach (var item in result.Errors)
            //    {
            //        errorStr = item.Description + "<br/>";
            //    }

            //    return Json(new {title="İşleminiz başarısız",message=errorStr,buttonText="Oke",statu=false});
            //}


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