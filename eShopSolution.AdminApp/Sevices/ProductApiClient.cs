using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Sevices
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        public ProductApiClient(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public Task<ApiResult<bool>> DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResult<ProductViewModel>> GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<PagedResult<ProductViewModel>>> GetProductPagings(GetManageProductPagingRequest request)
        {
            return await GetAsync<ApiResult<PagedResult<ProductViewModel>>>("" +
                "/api/products/paging?" +
                $"pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyWord={request.Keyword}" +
                $"&languageId={request.LanguageId}");
        }

        public Task<ApiResult<bool>> UpdateProduct(Guid id, ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}