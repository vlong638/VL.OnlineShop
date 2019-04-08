using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VL.OnlineShop.WebAPI.Attibutes;

namespace VL.OnlineShop.WebAPI.Controllers
{
    //三种授权模式
    //[Authorize(Roles = "Admin")]
    //[Authorize(AuthenticationSchemes = "Cookies")]
    //[Authorize(Policy = "EmployeeOnly")]

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        /// <summary>
        /// 测试是否登陆后可以访问
        /// </summary>
        /// <returns></returns>
        [Route("TestSuccess")]
        [HttpGet]
        public ActionResult<string> TestSuccess()
        {
            return Ok("访问成功");
        }

        /// <summary>
        /// 测试指定权限
        /// </summary>
        /// <returns></returns>
        [Route("TestZhangsan")]
        [HttpGet]
        [VLApiAuthentication(new FunctionAuthority[] { FunctionAuthority.功能项01 })]
        public ActionResult<string> TestVLApiAuthentication()
        {
            return Ok("访问成功");
        }

        /// <summary>
        /// 测试指定角色
        /// </summary>
        /// <returns></returns>
        [Route("TestRoles")]
        [HttpGet]
        public ActionResult<string> TestRoles()
        {
            return Ok("访问成功");
        }
    }
}
