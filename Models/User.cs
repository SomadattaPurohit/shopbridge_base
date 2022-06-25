using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Bridge.Models
{
    public class User
    {


        [Key] 
        public int user_id { get; set; }
        public string user_name { get; set; } 
        public string user_role { get; set; } 
        public string user_password { get; set; } 
        public string user_mail { get; set; } 
        public string user_username { get; set; }

    }
}
