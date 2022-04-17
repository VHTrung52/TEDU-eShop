using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;

namespace eShopSolution.BackendApi.Controllers
{
    public class BaseController : ControllerBase
    {
        private const string UnexpectedServerErrorStr = "An Unexpected Server Error has occurred.";

        protected ILogger<BaseController> Logger { get; }

        protected BaseController(ILogger<BaseController> lgr)
        {
            Logger = lgr;
        }

        protected ObjectResult ServerError(string errMsg = null)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, errMsg ?? UnexpectedServerErrorStr);
        }
    }
}