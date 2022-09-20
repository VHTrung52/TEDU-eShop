using eShopSolution.ApiIntegration;
using eShopSolution.Utilities.Constants;
using eShopSolution.ViewModels.Sales;
using eShopSolution.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductApiClient _productApiClient;
        private readonly IOrderApiClient _orderApiClient;
        public CartController(IProductApiClient productApiClient, IOrderApiClient orderApiClient)
        {
            _productApiClient = productApiClient;
            _orderApiClient = orderApiClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetListItems()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            var currentCart = session == null ? new List<CartItemViewModel>() : JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            return Ok(currentCart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, string languageId)
        {
            var product = await _productApiClient.GetProductById(id, languageId);
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);           
            var currentCart = session == null ? new List<CartItemViewModel>() : JsonConvert.DeserializeObject<List<CartItemViewModel>>(session); 

            var cartExist = currentCart.FirstOrDefault(x => x.ProductId == id);
            if(cartExist != null)
            {
                cartExist.Quantity++;
            }
            else
            {
                currentCart.Add(new CartItemViewModel()
                {
                    ProductId = product.Id,
                    Description = product.Description,
                    ImagePath = product.ThumbnailImagePath,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        public IActionResult UpdateCart(int id, int quantity)
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            var currentCart = session == null ? new List<CartItemViewModel>() : JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            var cartExist = currentCart.FirstOrDefault(x => x.ProductId == id);
            if (cartExist != null)
            {
                if(quantity == 0)
                    currentCart.Remove(cartExist);
                else
                    cartExist.Quantity = quantity;
            }  

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        public IActionResult CheckOut()
        {
            return View(GetCheckOutViewModel());
        }

        [HttpPost]
        public IActionResult CheckOut(CheckOutViewModel request)
        {
            var model = GetCheckOutViewModel();
            var orderDetails = new List<OrderDetailViewModel>();
            foreach (var item in model.CartItems)
            {
                orderDetails.Add(new OrderDetailViewModel()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                });
            }

            var checkoutRequest = new CheckoutRequest()
            {
                Address = request.CheckOutModel.Address,
                Name = request.CheckOutModel.Name,
                Email = request.CheckOutModel.Email,
                PhoneNumber = request.CheckOutModel.PhoneNumber,
                OrderDetails = orderDetails,
            };

            //đẩy vào order api
            _orderApiClient.CreateOrder(checkoutRequest);
            TempData["SuccessMsg"] = "Order puschased successful";
            return View(model);
        }

        private CheckOutViewModel GetCheckOutViewModel()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);
            List<CartItemViewModel> currentCart = session == null ? new List<CartItemViewModel>() : JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            var checkoutViewModel = new CheckOutViewModel()
            {
                CartItems = currentCart,
                CheckOutModel = new CheckoutRequest()
            };
            return checkoutViewModel;
        }
    }
}
