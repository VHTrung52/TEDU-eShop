using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Catalog.Categories;
using eShopSolution.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Categories
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(ILogger<CategoryService> lgr, EShopDbContext context) : base(lgr, context)
        {
        }

        public async Task<ApiResult<List<CategoryViewModel>>> GetAllCategories(string languageId)
        {
            var query = from categories in DbContext.Categories
                        join categoryTranslations in DbContext.CategoryTranslations
                            on categories.Id equals categoryTranslations.CategoryId
                        where categoryTranslations.LanguageId == languageId
                        select new { categories, categoryTranslations };

            var data = await query.Select(x => new CategoryViewModel()
            {
                Id = x.categories.Id,
                Name = x.categoryTranslations.Name
            }).ToListAsync();

            return new ApiSuccessResult<List<CategoryViewModel>>(data);
        }
    }
}