using eShopSolution.ViewModels.System.Users;
using System.Threading.Tasks;

namespace eShopSolution.AdminApp.Sevices
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}