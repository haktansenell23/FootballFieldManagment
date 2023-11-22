using FootballFieldManagment.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace FootballFieldManagmentAngularJS.Controllers
{
    public class MainController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public MainController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var appUser = _signInManager.Context.Request.Cookies["FMSCookie"];

            var appUser1 = _signInManager.Context.User;

            var userId = appUser1.FindFirst(ClaimTypes.NameIdentifier)?.Value;
          


            if (_signInManager.Context.Request.Cookies["FMSCookie"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

           

            
            return View();
        }

        public async Task<IActionResult> Logout()
        {

           await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
