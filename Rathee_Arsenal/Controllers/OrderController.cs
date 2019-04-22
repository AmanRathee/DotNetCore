using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rathee_Arsenal.Data;
using Rathee_Arsenal.Data.Model;
using Rathee_Arsenal.ViewModels;

namespace Rathee_Arsenal.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly IConfiguration _config;
        private readonly AppDbContext _appDbContext;


        public OrderController(IConfiguration config, AppDbContext appDbContext, IOrderRepository orderRepository,ShoppingCart shoppingCart)
        {
            _config = config;
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _appDbContext = appDbContext;

        }
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            if (!_shoppingCart.ShoppingCartItems.Any())
            {
                ModelState.AddModelError("","Your cart is empty.Nothing found to checkout");
            }
            
            if (ModelState.IsValid)
            {
                var token = GetToken(order);
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        //[Authorize]
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutMessage = "Thanks for your order !";
            return View();
        }

        public string GetToken(Order order)
        {
            LoginVM loginVm = new LoginVM
            {
                UserName = "abc@xyz",// order.Email;
                Password = "123456"//order.Password;
            };
            LoginController lc=new LoginController(_config,_appDbContext);
            return lc.Login2(loginVm);
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:52056/api/");
            //    //HTTP GET
            //    var result =await client.PostAsJsonAsync("token1", loginVm);
            //    if (result.IsSuccessStatusCode)
            //    {
            //        return await result.Content.ReadAsAsync<string>();
            //    }
            //}
            //return null;
        }


    }
}