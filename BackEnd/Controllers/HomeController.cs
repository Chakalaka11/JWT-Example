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
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            var result = new string[]{"","something"};
            return new JsonResult(result);
        }        
    }
}
