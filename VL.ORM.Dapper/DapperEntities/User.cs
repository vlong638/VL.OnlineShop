using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VL.ORM.Dapper.DapperEntities
{
    public enum Sex
    {
        None,
        Man,
        Woman,
    }

    [Table(nameof(User))]
    public class User
    {
        [Key]
        public long user_id { set; get; }
        public DateTime? AddTime { set; get; }
        public DateTime? EditTime { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string PhoneNumber { set; get; }
        public string Email { set; get; }
        public string NickName { set; get; }
        public Sex Sex { set; get; }
        public DateTime Birthday { set; get; }
    }
}
