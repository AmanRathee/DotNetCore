using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rathee_Arsenal.Data;
using Rathee_Arsenal.Data.Model;
using Rathee_Arsenal.ViewModels;

namespace Rathee_Arsenal.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IWeaponRepository _weaponRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IWeaponRepository weaponRepository,ShoppingCart shoppingCart)
        {
            _weaponRepository = weaponRepository;
            _shoppingCart = shoppingCart;

        }
        public ViewResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            var shoppingCartVM = new ShoppingCartVM
            {
                ShoppingCart = _shoppingCart,ShoppingCartTotal=_shoppingCart.GetShoppingCartTotal()                
            };
            return View(shoppingCartVM);
        }

        public RedirectToActionResult AddToShoppingCart(int weaponId)
        {
            var selectedWeapon = _weaponRepository.GetAllWeapons.FirstOrDefault(p => p.WeaponId == weaponId);
            if (selectedWeapon != null)
            {
                _shoppingCart.AddToCart(selectedWeapon, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromShoppingCart(int weaponId)
        {
            var selectedWeapon = _weaponRepository.GetAllWeapons.FirstOrDefault(p => p.WeaponId == weaponId);
            if (selectedWeapon != null)
            {
                _shoppingCart.RemoveFromCart(selectedWeapon);
            }
            return RedirectToAction("Index");
        }


    }
}