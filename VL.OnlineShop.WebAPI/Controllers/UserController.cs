using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VL.OnlineShop.WebAPI.Controllers
{
    //三种授权模式
    //[Authorize(Roles = "Admin")]
    //[Authorize(AuthenticationSchemes = "Cookies")]
    //[Authorize(Policy = "EmployeeOnly")]

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
