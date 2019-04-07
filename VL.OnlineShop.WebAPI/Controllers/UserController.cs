using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VL.OnlineShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Authorization.AllowAnonymous]
    public class UserController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public void Post(string name, string password)
        {
        }
    }
}
