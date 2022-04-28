using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.System.Languages
{
    public class LanguageService : BaseService, ILanguageService
    {
        private readonly EShopDbContext _dbContext;

        public LanguageService(
            ILogger<LanguageService> lgr,
            EShopDbContext context)
            : base(lgr, context)
        {
        }

        public async Task<ApiResult<List<LanguageViewModel>>> GetAllLanguages()
        {
            var languages = await _dbContext.Languages.Select(x => new LanguageViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return new ApiSuccessResult<List<LanguageViewModel>>(languages);
        }
    }
}