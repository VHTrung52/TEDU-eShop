using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Sevices
{
    public class UserApiClient : BaseApiClient, IUserApiClient
    {
        public UserApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("/api/users/authenticate", httpContent);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<ApiSuccessResult<string>>(await response.Content.ReadAsStringAsync());
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<string>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/users/{id}");
        }

        public async Task<ApiResult<UserViewModel>> GetById(Guid id)
        {
            return await GetAsync<ApiResult<UserViewModel>>($"/api/users/{id}");
        }

        public async Task<ApiResult<PagedResult<UserViewModel>>> GetUsersPagings(GetUserPagingRequest request)
        {
            return await GetAsync<ApiResult<PagedResult<UserViewModel>>>("" +
                "/api/users/paging?" +
                $"pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyWord={request.Keyword}");
        }

        public async Task<ApiResult<bool>> RegiterUser(RegisterRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/users/register", httpContent);

            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiSuccessResult<bool>>(result);
            }

            return JsonConvert.DeserializeObject<ApiErrorResult<bool>>(result);
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            return await PutAsync<ApiResult<bool>, RoleAssignRequest>($"/api/users/{id}/roles", request);
        }

        public async Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request)
        {
            return await PutAsync<ApiResult<bool>, UserUpdateRequest>($"/api/users/{id}", request);
        }
    }
}