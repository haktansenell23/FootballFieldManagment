using FootballFieldManagment.Core.Entities;
using FootballFieldManagmentAngularJS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace FootballFieldManagmentAngularJS.Attributes
{
    public class SessionAuthAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var deneme = context.HttpContext.User.Claims.IsNullOrEmpty();
            if (context.HttpContext.User.Claims.IsNullOrEmpty())
            {
                context.Result = new RedirectResult("~/Home/Index");
            }

            else
            {
                var userID = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value == null ? "" : context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                if (userID == null)
                {
                    if (context.HttpContext.Request?.ContentType?.Contains("application/json") == true)
                        context.Result = new UnauthorizedResult();
                    else
                        context.Result = new RedirectResult("~/Home/Index");
                    return;
                }

            }

            base.OnActionExecuting(context);
        }
    }
}
