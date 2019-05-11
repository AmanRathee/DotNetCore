using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rathee_Arsenal.Data.Model;
using Rathee_Arsenal.Model;

namespace Rathee_Arsenal.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public async Task CreateOrderAsync(OrderVM order)
        {
            order.OrderPlacedAt = DateTime.Now;
            var useruid = Guid.NewGuid();
            var createdUser = _appDbContext.Users.Add(new User()
            {
                UserUid = useruid,
                BuyerName = order.BuyerName,
                Address = order.Address,
                Email = order.Email,
                CreationDateTime = DateTime.Now,
                Password = order.Password
            });

            List<OrderDetail> orderDetails = new List<OrderDetail>();
            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            foreach (var item in shoppingCartItems)
            {
                orderDetails.Add(new OrderDetail()
                {
                    Amount = item.Number,
                    WeaponId = item.Weapon.WeaponId,
                    Price = item.Weapon.Price,
                    OrderId = order.OrderId
                });
            }


            _appDbContext.Orders.Add(
                new Order()
                {
                    OrderId = order.OrderId,
                    Orderdetails = orderDetails,
                    UserUid = useruid
                });
           await _appDbContext.SaveChangesAsync();           
        }
    }
}
