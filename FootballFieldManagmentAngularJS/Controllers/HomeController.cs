using FootballFieldManagment.Core.Entities;
using FootballFieldManagment.Core.Services;
using FootballFieldManagmentAngularJS.Cache;
using FootballFieldManagmentAngularJS.Models;
using FootballFieldManagmentAngularJS.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Diagnostics;

namespace FootballFieldManagmentAngularJS.Controllers
{
   


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager; 
        private readonly IAppUserDetailService _appUserDetailService;
        private readonly RedisService _redisService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAppUserDetailService appUserDetailService, RedisService redisService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _appUserDetailService = appUserDetailService;
            _redisService = redisService;
        }

        [HttpGet]
        public async  Task<IActionResult> Index()
        
       {

            IDatabase db = _redisService.GetDb(0);

           var password = await db.ListRightPopAsync("userCredential");
           var email = await db.ListRightPopAsync("userCredential");
   

           ViewBag.Email = String.IsNullOrEmpty(email.ToString()) ? "" : email.ToString();
           ViewBag.Password = String.IsNullOrEmpty(password.ToString()) ? "" : password.ToString();
          
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginViewModel Login)
        {
            return View();
        }

        [HttpGet]   
        public IActionResult SignUp() {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody]SignUpViewModel SignUpModel)
        {

            string errors = "";

            IDatabase db = _redisService.GetDb(0);

            List<string> usersInfo = new List<string>();

            usersInfo.Add(SignUpModel.Email);
            usersInfo.Add(SignUpModel.Password);



            foreach (var  item in usersInfo)
            {
               await db.ListRightPushAsync("userCredential",item);
            }




            if (SignUpModel.Password != SignUpModel.RePassword)
            {
                return Json(new { title = "İşleminiz başarısız", message ="Şifreler uyuşmuyor<br/>", buttonText = "Oke", statu = false });
            }

            var appUser = new AppUser
            {
                UserName = SignUpModel.UserName,
                Email = SignUpModel.Email,  
                PhoneNumber = SignUpModel.PhoneNumber
            };
         var result =  await _userManager.CreateAsync(appUser,SignUpModel.Password);

            if (result.Succeeded)
            {
                usersInfo.Add(SignUpModel.Email);
                usersInfo.Add(SignUpModel.Password);
                return Json(new { title = "İşlem başarılı", message = "", buttonText = "Oke", statu = true });
            }


            else
            {
                foreach (var item in result.Errors)
                {
                    errors = errors + item.Description + "<br/>";
                }


                return Json(new { title = "Hata !", message = errors, buttonText = "Oke", statu = false });
            }



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