using eShopSolution.ViewModels.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Sales
{
    public interface IOrderService
    {
        public Task<bool> ValidateCheckoutRequest(CheckoutRequest request);
        public bool CreateOrder(CheckoutRequest request);
    }
}
