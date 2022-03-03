using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Sevices
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);

        Task<PagedResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request);

        Task<bool> RegiterUser(RegisterRequest request);
    }
}