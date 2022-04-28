using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Catalog.Categories;
using eShopSolution.ViewModels.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace eShopSolution.Application.Catalog.Categories
{
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(
            ILogger<CategoryService> lgr,
            EShopDbContext context)
            : base(lgr, context)
        {
        }

        public async Task<ApiResult<List<CategoryViewModel>>> GetAllCategories(string languageId)
        {
            var query = from c in DbContext.Categories
                        join ct in DbContext.CategoryTranslations on c.Id equals ct.CategoryId
                        where ct.LanguageId == languageId
                        select new { c, ct };
            var data = await query.Select(x => new CategoryViewModel()
            {
                Id = x.c.Id,
                Name = x.ct.Name
            }).ToListAsync();

            return new ApiSuccessResult<List<CategoryViewModel>>(data);
        }
    }
}