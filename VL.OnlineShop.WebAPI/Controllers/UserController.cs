using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        /// 登入
        /// </summary>
        /// <returns></returns>
        [Route(nameof(SignIn))]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(string userName,string password)
        {
            List<Claim> claims = null;
            ClaimsIdentity identity = null;
            ClaimsPrincipal principal = null;
            if (!ModelState.IsValid)
            {
            }
            //UserDomain 验证登录
            if (userName == "vlong638" && password == "701616")
            {
                claims = new List<Claim>() {
                            new Claim(ClaimTypes.Name,userName),
                            new Claim(ClaimTypes.Role,RoleType.Admin.ToString()),
                            new Claim(ClaimTypes.Role,RoleType.Admin.ToString()),
                    };
                identity = new ClaimsIdentity(claims, AuthenticationType.Password.ToString());
                principal = new ClaimsPrincipal(identity);
            }
            else
            {
                throw new NotImplementedException("暂不支持其他用户登录");
            }
            //httpContext登录信息存储
            //string vlCookieName = Request.Cookies[Constants.VLCookieName];
            await HttpContext.SignInAsync(principal);
            return Ok();
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [Route(nameof(SignOut))]
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            if (User?.Identity.IsAuthenticated == true)
            {
                await HttpContext.SignOutAsync();
            }

            return Ok();
        }

        /// <summary>
        /// 测试 未登录
        /// </summary>
        /// <returns></returns>
        [Route(nameof(TestNoAuthorize))]
        [HttpGet]
        public ActionResult<string> TestNoAuthorize()
        {
            return Ok("访问成功");
        }

        /// <summary>
        /// 测试 登录
        /// </summary>
        /// <returns></returns>
        [Route(nameof(TestAuthorize))]
        [HttpGet]
        [Authorize]
        public ActionResult<string> TestAuthorize()
        {
            return Ok("访问成功");
        }

        /// <summary>
        /// 测试 角色登录
        /// </summary>
        /// <returns></returns>
        [Route(nameof(TestRoles))]
        [HttpGet]
        [Authorize(Roles = nameof(RoleType.Admin))]
        public ActionResult<string> TestRoles()
        {
            return Ok("访问成功");
        }

        /// <summary>
        /// 测试 
        /// </summary>
        /// <returns></returns>
        // VLTODO 未测试通过
        [Route(nameof(TestAuthenticationSchemes))]
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Cookies")]
        public ActionResult<string> TestAuthenticationSchemes()
        {
            return Ok("访问成功");
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        // VLTODO 未测试通过
        [Route(nameof(TestPolicy))]
        [HttpGet]
        [Authorize(Policy = "EmployeeOnly")]
        public ActionResult<string> TestPolicy()
        {
            return Ok("访问成功");
        }

        /// <summary>
        /// 测试指定权限
        /// 自定义(功能)
        /// </summary>
        /// <returns></returns>
        // VLTODO 未测试通过
        [Route(nameof(TestVLApiAuthentication))]
        [HttpGet]
        [VLApiAuthentication(new FunctionAuthority[] { FunctionAuthority.功能项01 })]
        public ActionResult<string> TestVLApiAuthentication()
        {
            return Ok("访问成功");
        }

        /// <summary>
        /// 测试指定角色
        /// 自定义(角色)
        /// </summary>
        /// <returns></returns>
        // VLTODO 未测试通过
        [Route(nameof(TestVLRoles))]
        [HttpGet]
        [VLApiAuthentication(new RoleType[] { RoleType.Admin })]
        public ActionResult<string> TestVLRoles()
        {
            return Ok("访问成功");
        }
    }
}
