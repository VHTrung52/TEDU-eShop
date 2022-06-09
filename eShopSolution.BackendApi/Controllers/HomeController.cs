using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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