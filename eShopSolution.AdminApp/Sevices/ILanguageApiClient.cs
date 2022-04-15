using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Language;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Sevices
{
    public interface ILanguageApiClient
    {
        Task<ApiResult<List<LanguageViewModel>>> GetAll();
    }
}