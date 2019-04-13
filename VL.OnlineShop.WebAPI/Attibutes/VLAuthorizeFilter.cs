using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VL.OnlineShop.WebAPI.Attibutes
{
    ///// <summary>
    ///// 跳过检查
    ///// </summary>
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    //public sealed class SkipUserAuthorizeAttribute : Attribute, IFilterMetadata
    //{
    //}

    ///// <summary>
    ///// 登录验证
    ///// </summary>
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    //public class MyAuthorizeFilter : AuthorizeAttribute, IAuthorizationFilter
    //{
    //    public void OnAuthorization(AuthorizationFilterContext context)
    //    {
    //    }

    //    public class MyAsyncAuthorizeFilter : IAsyncAuthorizationFilter
    //    {
    //        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
    //        {
    //            return Task.CompletedTask;
    //        }
    //    }
    //}
}
