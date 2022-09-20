using eShopSolution.ApiIntegration;
using eShopSolution.Utilities.Constants;
using eShopSolution.WebApp.Models;
using LazZiya.ExpressLocalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISlideApiClient _slideApiClient;
        private readonly IProductApiClient _productApiClient;
        private readonly ISharedCultureLocalizer _localizer;

        public HomeController(ILogger<HomeController> logger, ISlideApiClient slideApiClient, IProductApiClient productApiClient, ISharedCultureLocalizer localizer)
        {
            _logger = logger;
            _slideApiClient = slideApiClient;
            _productApiClient = productApiClient;
            _localizer = localizer;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ShowVC = true;
            var languageId = CultureInfo.CurrentCulture.Name;
            var model = new HomeViewModel()
            {
                Slides = await _slideApiClient.GetAllSlide(languageId),
                FeaturedProducts = await _productApiClient.GetFeaturedProducts(languageId, SystemConstants.ProductSettings.NumberOfFeaturedProducts),
                LastestProducts = await _productApiClient.GetLatestProducts(languageId, SystemConstants.ProductSettings.NumberOfLatestProducts)

            };

            return View(model);
        }

        public IActionResult SetCultureCookie(string cltr, string returnUrl, string currentUrl)
        {
            //culture = languageId
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(cltr)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            //var test = Request;

            if (currentUrl.Contains("/en/"))
                returnUrl = currentUrl.Replace("/en/", "/vi/");
            else if(currentUrl.Contains("/vi/"))
                returnUrl = currentUrl.Replace("/vi/", "/en/");

            return LocalRedirect(returnUrl);
        }
    }
}