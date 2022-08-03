using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public class UserApiClient : BaseApiClient, IUserApiClient
    {
        public UserApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor
            )
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            return await PostWithoutTokenAsync<ApiResult<string>, LoginRequest>("/api/users/authenticate", request);
        }

        public async Task<ApiResult<bool>> DeleteUser(Guid id)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/users/{id}");
        }

        public async Task<ApiResult<UserViewModel>> GetUserById(Guid id)
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
            return await PostWithoutTokenAsync<ApiResult<bool>, RegisterRequest>("/api/Users", request);
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid userId, RoleAssignRequest request)
        {
            return await PutAsync<ApiResult<bool>, RoleAssignRequest>($"/api/users/{userId}/roles", request);
        }

        public async Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request)
        {
            return await PutAsync<ApiResult<bool>, UserUpdateRequest>($"/api/users/{id}", request);
        }

        private async Task<TResponse> PostWithoutTokenAsync<TResponse, TInput>(string url, TInput request)
        {
            // only for register and authenticate
            // when user dont have bearer token
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, httpContent);

            return await ReturnResultAsync<TResponse>(response);
        }
    }
}