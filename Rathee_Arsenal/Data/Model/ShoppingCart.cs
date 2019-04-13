using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rathee_Arsenal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rathee_Arsenal.Data.Model
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;
        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public Guid ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        #region Cart Methods
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            Guid CartId;
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var dbContext = services.GetService<AppDbContext>();

            //var cartIdFromSession = session.GetString("CartId");
            Guid cartIdFromSession;
            if (!string.IsNullOrEmpty(session.GetString("CartId")) && Guid.TryParse(session.GetString("CartId"), out cartIdFromSession))
            {
                CartId = cartIdFromSession;
            }
            else
            {
                CartId = Guid.NewGuid();
            }
            session.SetString("CartId", CartId.ToString());
            return new ShoppingCart(dbContext) { ShoppingCartId = CartId };
        }
        public void AddToCart(Weapon weapon, int amount=1)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Weapon.WeaponId == weapon.WeaponId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem() { ShoppingCartId = ShoppingCartId, Weapon = weapon, Number = amount };
                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Number++;
            }
            _appDbContext.SaveChanges();
        }
        public int RemoveFromCart(Weapon weapon)
        {
            var shoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Weapon.WeaponId == weapon.WeaponId && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Number > 1)
                {
                    localAmount = shoppingCartItem.Number--;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _appDbContext.SaveChanges();
            return localAmount;
        }
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                                                                  .Include(s => s.Weapon).ToList());
        }
        public void ClearCart()
        {
            var cartItems = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId);
            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }
        public decimal GetShoppingCartTotal()
        {
            return _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                            .Select(c => c.Weapon.Price * c.Number).Sum();
        }
        #endregion

    }
}
