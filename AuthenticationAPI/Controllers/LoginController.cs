using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using AuthenticationAPI.Data;
using AuthenticationAPI.Data.Model;
using AuthenticationAPI.ViewModels;

namespace AuthenticationAPI.Controllers
{
    public class TokenResponse
    {
        public string Token { get; set; }
    }

    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _appDbContext;

        public LoginController(IConfiguration config, AppDbContext appDbContext)
        {
            _config = config;
            _appDbContext = appDbContext;
        }
        [Route("test")]

        public string Get()
        {
            return "ahgfhgfhgf";
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/mytoken5")]
        public string Login([FromBody]LoginVM login)
        {
            string response = null;
            if (ModelState.IsValid)
            {
                var authenticatedUser = AuthenticatedUser(login);
                if (authenticatedUser != null)
                {
                    response = GenerateJsonWebToken(authenticatedUser);
                }
            }

            return response;
        }
        private string GenerateJsonWebToken(User authenticatedUser)
        {
            var key = _config["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var secToken = new JwtSecurityToken(
                signingCredentials: credentials,
                issuer: "Sample",
                audience: "Sample",
                claims: new[] {
                                new Claim(JwtRegisteredClaimNames.Email, authenticatedUser.Email),
                                new Claim(JwtRegisteredClaimNames.GivenName, authenticatedUser.BuyerName),
                                new Claim("DateOfJoining", authenticatedUser.CreationDateTime.ToString("yyyy-MM-dd")),
                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        },
                expires: DateTime.UtcNow.AddDays(1));
            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(secToken);

            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity( new[] {
            //            new Claim(JwtRegisteredClaimNames.Email, authenticatedUser.Email),
            //            new Claim(JwtRegisteredClaimNames.GivenName, authenticatedUser.BuyerName),
            //            new Claim("DateOfJoining", authenticatedUser.CreationDateTime.ToString("yyyy-MM-dd")),
            //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //return tokenHandler.WriteToken(token);



            //byte[] key = Convert.FromBase64String(_config["Jwt:Key"]);
            //SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            //SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new[] {
            //        new Claim(JwtRegisteredClaimNames.Email, authenticatedUser.Email),
            //           new Claim(JwtRegisteredClaimNames.GivenName, authenticatedUser.BuyerName),
            //           new Claim("DateOfJoining", authenticatedUser.CreationDateTime.ToString("yyyy-MM-dd")),
            //           new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())}),
            //    Expires = DateTime.UtcNow.AddMinutes(30),
            //    SigningCredentials = new SigningCredentials(securityKey,
            //        SecurityAlgorithms.HmacSha256Signature)
            //};

            //JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            //JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            //return handler.WriteToken(token);



            ////var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] + authenticatedUser.Email));
            //// byte[] byt = System.Text.Encoding.UTF8.GetBytes(_config["Jwt:Key"] + authenticatedUser.Email);
            //var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Jwt:Key"] + authenticatedUser.Email));

            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //var claims = new[] {
            //    new Claim(JwtRegisteredClaimNames.Email, authenticatedUser.Email),
            //    new Claim(JwtRegisteredClaimNames.GivenName, authenticatedUser.BuyerName),
            //    new Claim("DateOfJoining", authenticatedUser.CreationDateTime.ToString("yyyy-MM-dd")),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //};

            //var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            //    _config["Jwt:Issuer"],
            //    claims,
            //    expires: DateTime.Now.AddMinutes(120),
            //    signingCredentials: credentials);

            ////await HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(token,
            ////    new JsonSerializerSettings { Formatting = Formatting.Indented }));
            //return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticatedUser(LoginVM login)
        {
            return _appDbContext.Users.FirstOrDefault(x =>
                x.Email.Equals(login.UserName) && x.Password.Equals(login.Password));
        }
    }
}