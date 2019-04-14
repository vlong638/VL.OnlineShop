using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VL.OnlineShop.WebAPI.Authorization
{
    /// <summary>
    /// 授权策略:年龄限制
    /// </summary>
    public class VLAgeRequirement : IAuthorizationRequirement
    {

        public VLAgeRequirement(int minimumAge)
        {
            MinimumAge = minimumAge;
        }

        public int MinimumAge { get; private set; }
    }

    /// <summary>
    /// 授权处理方案:年龄限制
    /// </summary>
    public class VLAgeRequirementHandler : AuthorizationHandler<VLAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, VLAgeRequirement requirement)
        {
            if (context.User != null && context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth))
            {
                DateTime dateOfBirth = DateTime.MinValue;
                var user = context.User.FindFirst(c => c.Type == ClaimTypes.DateOfBirth);
                var str = user == null ? "" : user.Value;
                DateTime.TryParse(str, out dateOfBirth);
                int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
                if (calculatedAge >= requirement.MinimumAge)
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
            return Task.CompletedTask;
        }
    }
}
