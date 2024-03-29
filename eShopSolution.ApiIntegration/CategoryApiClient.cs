﻿using eShopSolution.ViewModels.Catalog.Categories;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public class CategoryApiClient : BaseApiClient, ICategoryApiClient
    {
        public CategoryApiClient(
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public Task<ApiResult<List<CategoryViewModel>>> GetAllCategories(string languageId)
        {
            return GetAsync<ApiResult<List<CategoryViewModel>>>($"/api/categories?languageId={languageId}");
        }

        public async Task<CategoryViewModel> GetCategoryById(int categoryId, string languageId)
        {
            return await GetAsync<CategoryViewModel>($"/api/categories/{categoryId}/{languageId}");
        }
    }
}