using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
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

        public async Task<bool> CreateProduct(ProductCreateRequest request)
        {
            var client = CreateNewHttpClient();

            var requestContent = new MultipartFormDataContent();

            if (request.ThumbnailImage != null)
            {
                byte[] data;
                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }
                ByteArrayContent byteArrayContent = new ByteArrayContent(data);
                requestContent.Add(byteArrayContent, "ThumbnailImage", request.ThumbnailImage.FileName);
            }

            requestContent.Add(new StringContent(request.Price.ToString()), "price");
            requestContent.Add(new StringContent(request.OriginalPrice.ToString()), "originalPrice");
            requestContent.Add(new StringContent(request.Stock.ToString()), "stock");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Name) ? "" : request.Name.ToString()), "name");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Description) ? "" : request.Description.ToString()), "description");

            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.Details) ? "" : request.Details.ToString()), "details");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoDescription) ? "" : request.SeoDescription.ToString()), "seoDescription");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoTitle) ? "" : request.SeoTitle.ToString()), "seoTitle");
            requestContent.Add(new StringContent(string.IsNullOrEmpty(request.SeoAlias) ? "" : request.SeoAlias.ToString()), "seoAlias");
            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);
            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PostAsync($"/api/products/", requestContent);

            return response.IsSuccessStatusCode;
            //return await ReturnResultAsync<ApiResult<bool>>(response);
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
                $"&categoryId={request.CategoryId}" +
                $"&languageId={request.LanguageId}");
        }

        public Task<ApiResult<bool>> UpdateProduct(Guid id, ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}