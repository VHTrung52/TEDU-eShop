using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace eShopSolution.WebApp.Controllers
{
    public class BaseController : Controller
    {
        protected string GetLanguageId()
        {
            var languageId = CultureInfo.CurrentCulture.Name;
            return languageId;
        }
    }
}
