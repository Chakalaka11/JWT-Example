using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BackEnd.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BackEnd.Services
{
    public class AuthService
    {
        private IConfiguration _config;
        private UserService _userService;
        public AuthService(
            IConfiguration config,
            UserService userService)
        {
            _config = config;
            _userService = userService;
        }
        public string GenerateTestUserToken()
        {
            return GenerateJSONWebToken(_userService.GetTestUser());
        }
        public List<ClaimInfo> GetInfoFromClaims(ClaimsPrincipal user)
        {
            List<ClaimInfo> claimInfo = new List<ClaimInfo>();
            foreach(var claim in user.Claims)
            {
                claimInfo.Add(new ClaimInfo{
                    Type = claim.Type,Value = claim.Value
                });
            }
            return claimInfo;
        }
        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWTConfiguration:SymmetricKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.FirstName+" "+user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["JWTConfiguration:Issuer"],
                audience: _config["JWTConfiguration:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}