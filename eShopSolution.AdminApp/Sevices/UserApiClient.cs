﻿using eShopSolution.Utilities.Constants;
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
            return await PostWithoutTokenAsync<ApiResult<bool>, RegisterRequest>("/api/users/register", request);
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