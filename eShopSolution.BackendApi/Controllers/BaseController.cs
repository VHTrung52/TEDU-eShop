using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace eShopSolution.BackendApi.Controllers
{
    public class BaseController : ControllerBase
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
    }
}