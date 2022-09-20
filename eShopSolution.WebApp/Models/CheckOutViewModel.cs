using eShopSolution.ViewModels.Sales;
using System.Collections.Generic;

namespace eShopSolution.WebApp.Models
{
    public class CheckOutViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; }
        public CheckoutRequest CheckOutModel { get; set; }
    }
}
