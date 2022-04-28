using eShopSolution.BackendApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(
            ILogger<HomeController> lgr)
            : base(lgr)
        {
        }

        public IActionResult Index()
        {
            return Ok();
        }
    }
}