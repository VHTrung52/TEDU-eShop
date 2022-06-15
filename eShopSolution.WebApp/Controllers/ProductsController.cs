using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult GetProductDetail(int id)
        {
            return View();
        }

        public IActionResult GetProductsByCategory(int id)
        {
            return View();
        }
    }
}
