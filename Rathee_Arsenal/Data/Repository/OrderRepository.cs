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

        public void CreateOrder(Order order)
        {
            order.OrderPlacedAt = DateTime.Now;
            _appDbContext.Orders.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            foreach (var item in shoppingCartItems)
            {
                var orderdetail = new OrderDetail()
                {
                    Amount = item.Number,
                    WeaponId = item.Weapon.WeaponId,
                    Price = item.Weapon.Price,
                    OrderId = order.OrderId
                };
            }
        }
    }
}
