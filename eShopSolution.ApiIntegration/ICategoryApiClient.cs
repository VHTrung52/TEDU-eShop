using eShopSolution.ViewModels.Catalog.Categories;
using eShopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public interface ICategoryApiClient
    {
        Task<ApiResult<List<CategoryViewModel>>> GetAllCategories(string languageId);
        Task<CategoryViewModel> GetCategoryById(int categoryId, string languageId);

    }
}