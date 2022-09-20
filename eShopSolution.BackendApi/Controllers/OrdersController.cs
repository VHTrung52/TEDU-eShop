using eShopSolution.Application.Sales;
using eShopSolution.ViewModels.Sales;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateOrderAsync(CheckoutRequest request)
        {
            try
            {
                if(await _orderService.ValidateCheckoutRequest(request))
                {
                    _orderService.CreateOrder(request);
                }

                return Ok();
            }
            catch(Exception ex)
            {
                return Problem(ex.Message,null,404);
            }
          
        }
        
    }
}
