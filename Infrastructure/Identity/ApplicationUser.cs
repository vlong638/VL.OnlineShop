using Microsoft.AspNetCore.Identity;
using Microsoft.eShopWeb.ApplicationCore.Entities;
using System;

namespace Microsoft.eShopWeb.Infrastructure.Identity
{
    /// <summary>
    /// 注:应用程序用户表User的一种存在形态
    /// 可以来自不同的终端,来自不同的IP等
    /// 当形成了同样结构的应用程序用户
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }

        public ApplicationUser(User user)
        {
            Id = user.Id.ToString();
            UserName = user.UserName;
            Password = user.Password;
            Sex = user.Sex;
        }

        public User ToUser()
        {
            return new User(Id, UserName, Password, Nickname, Sex);
        }

        public override string Id { set; get; }
        /// <summary>
        /// 用户名
        /// </summary>
        public override string UserName { set; get; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public ESex Sex { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public override string PhoneNumber { set; get; }
        /// <summary>
        /// 手机号是否已验证
        /// </summary>
        public override bool PhoneNumberConfirmed { set; get; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public override string Email { set; get; }
        /// <summary>
        /// 邮箱是否已验证
        /// </summary>
        public override bool EmailConfirmed { set; get; }
        /// <summary>
        /// 连续登录失败计数
        /// </summary>
        public override int AccessFailedCount { get; set; }
        /// <summary>
        /// 账户锁定截止时间
        /// </summary>
        public override DateTimeOffset? LockoutEnd { get; set; }
    }
}
