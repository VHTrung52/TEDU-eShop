//using System.ComponentModel.DataAnnotations;

namespace eShopSolution.ViewModels.System.Users
{
    public class LoginRequest
    {
        //[Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}