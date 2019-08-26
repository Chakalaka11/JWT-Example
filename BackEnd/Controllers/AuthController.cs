using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Services;
using BackEnd.Models;
using Microsoft.Extensions.Configuration;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private AuthService _authService;
        public AuthController(IConfiguration configuration)
        {
            _authService = new AuthService(configuration, new UserService());
        }

        [AllowAnonymous]
        [Route("GetTestJwt")]
        public JsonResult GetTestJwt()
        {
            Token result = new Token { 
                Value = _authService.GenerateTestUserToken() 
            };
            return new JsonResult(result);
        }

        [Route("GetClaimsInfo")]
        public JsonResult GetClaimsInfo()
        {
            var result = _authService.GetInfoFromClaims(HttpContext.User);
            return new JsonResult(result);
        }
    }
}
