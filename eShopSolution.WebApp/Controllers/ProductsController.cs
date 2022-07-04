using eShopSolution.ApiIntegration;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly ICategoryApiClient _categoryApiClient;

        public ProductsController(
            IProductApiClient productApiClient,
            ICategoryApiClient categoryApiClient)
        {
            _productApiClient = productApiClient;
            _categoryApiClient = categoryApiClient;
        }
        public async Task<IActionResult> Detail(string languageId, int id)
        {
            var model = await _productApiClient.GetProductById(id, languageId);
            return View(model);
        }

        public async Task<IActionResult> Category(int id, string languageId, int pageIndex = 1, int pageSize = 9)
        {
            //var userIdent = (ClaimsIdentity)User?.Identity;
            //if (userIdent == null || !userIdent.IsAuthenticated)
            //{
            //    return Unauthorized();
            //}
            var model = new ProductCategoryViewModel();
            var response = await _productApiClient.GetProductPaging(new GetManageProductPagingRequest()
            {
                CategoryId = id,
                PageIndex = pageIndex,
                PageSize = pageSize,
                LanguageId = languageId
            });
            model.Products = response.ResultObj;
            model.Category = await _categoryApiClient.GetCategoryById(id, languageId);
            return View(model);
        }
    }
}
