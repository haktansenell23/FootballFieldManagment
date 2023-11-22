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
        public async Task<IActionResult> Index()
        {
             

            IDatabase db = _redisService.GetDb(0);
            var email = await db.ListRightPopAsync("userCredential");
            ViewBag.Email = String.IsNullOrEmpty(email.ToString()) ? "" : email.ToString();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index([FromBody] LoginViewModel Login,string? returnUrl=null)
        {

            returnUrl = returnUrl ?? Url.Action("Index", "Home");

            var user = await _userManager.FindByEmailAsync(Login.Email);

            if (user == null)
            {
                return Json(new { title = "", message = "Kullanıcı adı veya şifre yanlış", buttonText = "Tamam", statu = false });
            }

            var result = await _signInManager.PasswordSignInAsync(user, Login.Password, Login.RememberMe, false);
      

            if (result.Succeeded)
            {
                return Json(new { title = "", message = "Kullanıcı adı veya şifre yanlış", buttonText = "Tamam", statu = true });
            }
            else if (result.IsLockedOut)
            {
                var lockoutEndUtc = await _userManager.GetLockoutEndDateAsync(user);
                var timeLeft = lockoutEndUtc.Value - DateTime.UtcNow;


                return Json(new { title = "", message = $"Hesap {timeLeft} gün boyunca kapalı kalıcaktır. ", buttonText = "Tamam", statu = false });
            }

            else if (result.IsNotAllowed)
            {
                  var lockoutEndUtc = await _userManager.GetLockoutEndDateAsync(user);
                var timeLeft = lockoutEndUtc.Value - DateTime.UtcNow;
                return Json(new { title = "", message = $"Hesap {timeLeft} gün boyunca kapalı kalıcaktır. ", buttonText = "Tamam", statu = false });

            }
            else
            {
                
                return Json(new { title = "İşlem başarılı", message = "", buttonText = "Tamam", statu = false });
            }

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
            foreach (var  item in usersInfo)
            {
                await db.ListRightPushAsync("userCredential", item);
            }
            if (SignUpModel.Password != SignUpModel.RePassword)
            {
                return Json(new { title = "İşleminiz başarısız", message ="Şifreler uyuşmuyor<br/>", buttonText = "Tamam", statu = false });
            }
            var appUser = new AppUser
            {
                UserName = SignUpModel.UserName,
                Email = SignUpModel.Email,  
                PhoneNumber = SignUpModel.PhoneNumber
            };
            var user  =   await  _userManager.FindByEmailAsync(SignUpModel.Email);
            var userByUserName = await  _userManager.FindByNameAsync(SignUpModel.UserName);    
            if (user != null)
            {
                string definitionErrors = "";
                definitionErrors = "Bu email kullanılmaktadır" + definitionErrors + "<br/>";
                definitionErrors = user.UserName == SignUpModel.UserName ? "Email veya kullanıcı adı sistemde bulunmaktadır" : definitionErrors;
                return Json(new { title = "Hata !", message = definitionErrors, buttonText = "Tamam", statu = false });
            }

            if (userByUserName !=null)
            {
                string definitionErrors = "";
                definitionErrors = "Bu kullanıcı adı kullanımdadır." + definitionErrors + "<br/>";

                definitionErrors = userByUserName.UserName == SignUpModel.UserName ? "Kullanıcı adı kullanımdadır" : definitionErrors;

                return Json(new { title = "Hata !", message = definitionErrors, buttonText = "Tamam", statu = false });
            }


            var result =  await _userManager.CreateAsync(appUser,SignUpModel.Password);

          
            
            if (result.Succeeded)
            {
                usersInfo.Add(SignUpModel.Email);
                await db.ListRightPushAsync("userCredential", usersInfo[0]);

                AppUserDetail appUserDetail = new AppUserDetail
                {

                    AppUserDetailID = new Guid(),
                    AppUserID = appUser.Id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    isDeleted = false,
                    MatchCount = 0,
                    PerGoalAssistCount = 0,
                    CreatedSessionCount = 0,
                    PerGoalMatchCount = 0,
                };
                await _appUserDetailService.AddItem(appUserDetail);

                return Json(new { title = "İşlem başarılı", message = "İşlem Başarılı", buttonText = "Tamam", statu = true });
            }


            else
            {
                foreach (var item in result.Errors)
                {
                    errors = errors + item.Description + "<br/>";
                }


                return Json(new { title = "Hata !", message = errors, buttonText = "Tamam", statu = false });
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