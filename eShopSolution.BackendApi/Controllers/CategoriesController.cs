using eShopSolution.Application.Catalog.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(
            ILogger<CategoriesController> lgr,
            ICategoryService categoryService)
            : base(lgr)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories(string languageId)
        {
            try
            {
                var response = await _categoryService.GetAllCategories(languageId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\CategoriesController\\GetAllCategories");
                return ServerError();
            }
        }

        [HttpGet("{categoryId}/{languageId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId, string languageId)
        {
            try
            {
                var response = await _categoryService.GetCategoryById(categoryId, languageId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Exception in BackendApi\\CategoriesController\\GetCategoryById");
                return ServerError();
            }
        }
    }
}