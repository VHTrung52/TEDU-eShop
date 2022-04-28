﻿using eShopSolution.AdminApp.Models;
using eShopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Controllers
{
    //[Authorize]
    public class HomeController : BaseController
    {
        public HomeController(
            ILogger<HomeController> lgr)
            : base(lgr)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Language(NavigationViewModel model)
        {
            HttpContext.Session.SetString(SystemConstants.AppSettings.DefaultLanguageId, model.CurrentLanguageId);
            return RedirectToAction("Index");
        }
    }
}