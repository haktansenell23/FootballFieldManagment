using FootballFieldManagment.Core.Entities;
using FootballFieldManagmentAngularJS.Attributes;
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
        [SessionAuth]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Ana sayfa";
            if (_signInManager.Context.Request.Cookies["FMSCookie"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var appUser = _signInManager.Context.Request.Cookies["FMSCookie"];
            var appUser1 = _signInManager.Context.User;
            var userId = appUser1.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = appUser1.FindFirst(ClaimTypes.Name)?.Value;
            TempData["UserName"] = userName!=null ? userName : "";
            if (String.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        [SessionAuth]
        public async Task<IActionResult> Logout()
        {

           await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
