using eShopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Sevices
{
    public class BaseApiClient
    {
        protected readonly IConfiguration _configuration;
        protected readonly IHttpClientFactory _httpClientFactory;
        protected readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var client = CreateNewHttpClient();

            var response = await client.GetAsync(url);

            return await ReturnResultAsync<TResponse>(response);
        }

        protected async Task<TResponse> DeleteAsync<TResponse>(string url)
        {
            var client = CreateNewHttpClient();

            var response = await client.DeleteAsync(url);

            return await ReturnResultAsync<TResponse>(response);
        }

        protected async Task<TResponse> PutAsync<TResponse, TInput>(string url, TInput request)
        {
            var client = CreateNewHttpClient();

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(url, httpContent);

            return await ReturnResultAsync<TResponse>(response);
        }

        protected async Task<TResponse> PostAsync<TResponse, TInput>(string url, TInput request)
        {
            var client = CreateNewHttpClient();

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, httpContent);

            return await ReturnResultAsync<TResponse>(response);
        }

        protected HttpClient CreateNewHttpClient()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            var session = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", session);
            return client;
        }

        protected async Task<TResponse> ReturnResultAsync<TResponse>(HttpResponseMessage response)
        {
            var data = await response.Content.ReadAsStringAsync();
            TResponse result;
            // ok x
            // badrequest
            // server error x
            // unotherize ?

            if (response.IsSuccessStatusCode)
            {
                result = JsonConvert.DeserializeObject<TResponse>(data);
                return result;
            }
            else
                return default(TResponse);
        }
    }
}