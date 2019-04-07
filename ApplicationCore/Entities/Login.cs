using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Microsoft.eShopWeb.ApplicationCore.Entities
{
    [Table("login")]
    public class Login
    {
        [Key, Column(Order = 0)]
        public int login_id { get; set; }
        public int user_id { get; set; }
        public string mobile_phone { get; set; }
        public string email { get; set; }
        public string login_name { get; set; }
        public string password { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
    }
}
