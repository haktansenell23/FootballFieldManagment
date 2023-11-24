using FootballFieldManagment.Core.Entities;
using FootballFieldManagmentAngularJS.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FootballFieldManagmentAngularJS.Controllers
{
    [SessionAuth]
    public class ProfileController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult ProfileInformations()
        {
            ClaimsPrincipal claimsPrincipal = _signInManager.Context.User;
            TempData["UserName"] = claimsPrincipal.FindFirst(ClaimTypes.Name)?.Value;
            return View();
        }

        public async Task<IActionResult> GetLoginUserInformations()
        {
            ClaimsPrincipal claimsPrincipal = _signInManager.Context.User;

            var userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId ==null )
            {
                Redirect("Home/Index");
            }


            var user = await _userManager.FindByIdAsync(userId);

           var serializeUser = JsonSerializer.Serialize(user);


            return Json(serializeUser);
        }






    }
}
