using eShopSolution.ViewModels.Catalog.Categories;
using eShopSolution.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<ApiResult<List<CategoryViewModel>>> GetAllCategories(string languageId);
    }
}