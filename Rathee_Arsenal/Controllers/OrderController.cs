using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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

       
        public OrderController(IConfiguration config, AppDbContext appDbContext, IOrderRepository orderRepository, ShoppingCart shoppingCart)
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
                ModelState.AddModelError("", "Your cart is empty.Nothing found to checkout");
            }

            if (ModelState.IsValid)
            {
                var token = GetToken(order).Result;
                ValidateToken(token);
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }
        private bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            try
            {
                ClaimsPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
                if (principal == null)
                    return false;
                ClaimsIdentity identity = null;
                try
                {
                    identity = (ClaimsIdentity)principal.Identity;
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);

                    //var SignInResult =SignIn(principal, CookieAuthenticationDefaults.AuthenticationScheme);
                }
                catch (NullReferenceException)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = "Sample",
                ValidAudience = "Sample",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])) // The same key as the one that generate the token
            };
        }
        //public string ValidateToken(string token)
        //{
        //    string username = null;
        //    ClaimsPrincipal principal = GetPrincipal(token);
        //    if (principal == null)
        //        return null;
        //    ClaimsIdentity identity = null;
        //    try
        //    {
        //        identity = (ClaimsIdentity)principal.Identity;
        //    }
        //    catch (NullReferenceException)
        //    {
        //        return null;
        //    }
        //    Claim usernameClaim = identity.FindFirst(ClaimTypes.Email);
        //    username = usernameClaim.Value;
        //    return username;
        //}
        public ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null)
                    return null;
                var jti = jwtToken.Claims.First(claim => claim.Type == "email").Value;
                byte[] key = Convert.FromBase64String(_config["Jwt:Key"]);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _config["Jwt:Issuer"],
                    ValidAudience = _config["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]))
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                    parameters, out securityToken);
                return principal;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutMessage = "Thanks for your order !";
            return View();
        }

        public async Task<string> GetToken(Order order)
        {
            LoginVM loginVm = new LoginVM
            {
                UserName = "abc@xyz",// order.Email;
                Password = "123456"//order.Password;
            };
            //LoginController lc=new LoginController(_config,_appDbContext);
            //return lc.Login2(loginVm);
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:62305/api/");
                //HTTP GET
                var result = await client.PostAsJsonAsync("http://localhost:62305/api/mytoken5", loginVm);
                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadAsStringAsync();
                }
            }
            return null;
        }


    }
}