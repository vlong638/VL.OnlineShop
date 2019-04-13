using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VL.OnlineShop.WebAPI.Attibutes
{
    /*权限枚举值规则：前三位为分组，后三位为组内编号*/

    /// <summary>
    /// 
    /// </summary>
    public enum FunctionAuthority
    {

        #region 组 110

        /// <summary>
        /// 
        /// </summary>
        功能项01 = 110010,
        /// <summary>
        /// 
        /// </summary>
        功能项02 = 110020,
        /// <summary>
        /// 
        /// </summary>
        功能项03 = 110030,
        /// <summary>
        /// 
        /// </summary>
        功能项04 = 110040,

        #endregion
    }

    static class FunctionAuthorityEx
    {
        const string PolicyPrefix = "ApiAuthorization:";

        const string Separator = ",";

        static readonly char[] Separators = new char[] { ',' };


        public static FunctionAuthority[] FromPolicy(this string policyName)
        {
            if (policyName.StartsWith(PolicyPrefix))
            {
                return policyName.Substring(PolicyPrefix.Length).Split(Separators, StringSplitOptions.RemoveEmptyEntries).Select(p => (FunctionAuthority)Convert.ToInt32(p)).ToArray();
            }
            else
            {
                return Array.Empty<FunctionAuthority>();
            }
        }

        public static string ToPolicy(this FunctionAuthority[] functionAuthorities)
        {
            if (functionAuthorities == null || functionAuthorities.Length == 0)
            {
                return PolicyPrefix;
            }
            return PolicyPrefix + string.Join(Separator, functionAuthorities.Select(p => ((int)p).ToString()));
        }

        public static bool IsApiPolicy(this string policyName)
        {
            return policyName.StartsWith(PolicyPrefix);
        }
    }

    public class VLApiAuthentication : AuthorizeAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly FunctionAuthority[] _functionAuthority;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="functionAuthority"></param>
        public VLApiAuthentication(params FunctionAuthority[] functionAuthority) : base()
        {
            _functionAuthority = functionAuthority;
            Policy = functionAuthority.ToPolicy();
        }
    }
}
