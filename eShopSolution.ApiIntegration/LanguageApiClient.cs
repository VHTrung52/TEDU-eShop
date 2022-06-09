using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Language;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public class LanguageApiClient : BaseApiClient, ILanguageApiClient
    {
        public LanguageApiClient(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<List<LanguageViewModel>>> GetAllLanguages()
        {
            return await GetAsync<ApiResult<List<LanguageViewModel>>>("/api/languages");
        }
    }
}