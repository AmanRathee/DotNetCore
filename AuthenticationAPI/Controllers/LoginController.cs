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
        [Route("api/token")]
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

        [AllowAnonymous]
        [Route("api/create")]

        public async Task<bool> CreateUser([FromBody]User user)
        {
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        [AllowAnonymous]
        [Route("api/{userUid}")]
        public async Task<User> GetUserAsync(Guid userUid)
        {
            return await _appDbContext.Users.FindAsync(userUid);
        }
        [Authorize]
        [Route("api/update")]
        public async Task<bool> UpdateUser([FromBody]User user)
        {
            var userFromDB=await _appDbContext.Users.FindAsync(user.UserUid);
            userFromDB = user;
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        [Authorize]
        [Route("api/delete")]
        public async Task<bool> DeleteUserAsync(Guid userUid)
        {
            var userFromDB = await _appDbContext.Users.FindAsync(userUid);
            _appDbContext.Users.Remove(userFromDB);
            return true;
        }

        #region Private Methods
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
                expires: DateTime.UtcNow.AddMinutes(1));
            var handler = new JwtSecurityTokenHandler();
            return handler.WriteToken(secToken);
        }

        private User AuthenticatedUser(LoginVM login)
        {
            return _appDbContext.Users.FirstOrDefault(x =>
                x.Email.Equals(login.UserName) && x.Password.Equals(login.Password));
        }
        #endregion

    }
}