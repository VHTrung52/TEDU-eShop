using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Roles;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Sevices
{
    public class RoleApiClient : IRoleApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoleApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResult<List<RoleViewModel>>> GetAll()
        {
            var client = CreateNewHttpClient();

            var response = await client.GetAsync($"/api/roles");

            var data = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                List<RoleViewModel> deserializedObjList = (List<RoleViewModel>)JsonConvert.DeserializeObject(data, typeof(List<RoleViewModel>));
                return new ApiSuccessResult<List<RoleViewModel>>(deserializedObjList);
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<List<RoleViewModel>>>(data);
        }

        private HttpClient CreateNewHttpClient()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var session = _httpContextAccessor.HttpContext.Session.GetString("Token");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);
            return client;
        }
    }
}