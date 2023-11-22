//using FootballFieldManagmentAngularJS.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;

//namespace FootballFieldManagmentAngularJS.Attributes
//{
//    public class SessionAuthAttribute : ActionFilterAttribute
//    {

//        public override void OnActionExecuting(ActionExecutingContext context)
//        {
//            var _sessionUser = context.HttpContext.RequestServices.GetService(typeof(SessionUser)) as SessionUser;
//            if (_sessionUser?.user?.userID == null)
//            {
//                if (context.HttpContext.Request?.ContentType?.Contains("application/json") == true)
//                    context.Result = new UnauthorizedResult();
//                else
//                    context.Result = new RedirectResult("~/account/login");
//                return;
//            }
//            base.OnActionExecuting(context);
//        }
//    }
//}
