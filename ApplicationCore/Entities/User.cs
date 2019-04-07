using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum ESex
    {
        /// <summary>
        /// 未知
        /// </summary>
        None = 0,
        /// <summary>
        /// 男
        /// </summary>
        Male,
        /// <summary>
        /// 女
        /// </summary>
        Female,
    }

    [Table("user")]
    public class User:BaseEntity
    {
        private string id;
        private ESex sex;

        public User(string userName, string password, string nickName, ESex sex)
        {
            UserName = userName;
            Password = password;
            NickName = nickName;
            Sex = sex;
            AddTime = DateTime.Now;
        }

        public User(string id, string userName, string password, string nickname, ESex sex)
        {
            this.id = id;
            UserName = userName;
            Password = password;
            NickName = nickname;
            this.sex = sex;
        }

        [Key, Column("user_id")]
        public override int Id { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public ESex Sex { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 邮箱号码
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
    }
}
