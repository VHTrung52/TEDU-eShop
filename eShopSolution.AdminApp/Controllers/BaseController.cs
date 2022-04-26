using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace eShopSolution.AdminApp.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private const string UnexpectedServerErrorStr = "An Unexpected Server Error has occurred.";

        protected readonly ILogger<BaseController> logger;

        protected BaseController(ILogger<BaseController> lgr)
        {
            logger = lgr;
        }

        protected ObjectResult ServerError()
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, UnexpectedServerErrorStr);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessions = context.HttpContext.Session.GetString("Token");
            if (sessions == null)
            {
                context.Result = new RedirectToActionResult("Index", "Login", null);
            }
            base.OnActionExecuting(context);
        }
    }
}