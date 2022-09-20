using eShopSolution.Application.Common;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;
using eShopSolution.ViewModels.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Sales
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(
            ILogger<BaseService> logger,
            EShopDbContext dbContext)
            : base(logger, dbContext)
        {
        }

        public async Task<bool> ValidateCheckoutRequest(CheckoutRequest request)
        {
            foreach(OrderDetailViewModel item in request.OrderDetails)
            {
                var product = await DbContext.Products.FirstOrDefaultAsync(x => x.Id == item.ProductId);
                if (product == null)
                {
                    return false;
                }

                if (product.Stock < item.Quantity)
                {
                    return false;
                }               
            }

            return true;
        }

        public bool CreateOrder(CheckoutRequest request)
        {         
            Order order = new Order()
            {
                OrderDate = DateTime.Now,
                UserId = new Guid("5F5D0F29-F012-411A-970E-97835C440947"),
                ShipName = request.Name,
                ShipAddress = request.Address,
                ShipEmail = request.Email,
                ShipPhoneNumber = request.PhoneNumber,
                Status = 0
            };

            order.OrderDetails = request.OrderDetails.Select(i => new OrderDetail()
            {
                OrderId = order.Id,
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                Price = 10000
            }).ToList();

            foreach(OrderDetail item in order.OrderDetails)
            {
                var product = DbContext.Products.FirstOrDefault(x => x.Id == item.ProductId);
                product.Stock = product.Stock - item.Quantity;
            }

            DbContext.Orders.Add(order);
            
            DbContext.SaveChanges();
            return true;
           
        }
    }
}


