using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Bridge.Models
{
    public class login
    {
        
        [Required(ErrorMessage = "Enter the Password")]
        [DataType(DataType.Password)]
        public string user_password { get; set; }

        [Required(ErrorMessage = "Enter the Mail")]
        [DataType(DataType.EmailAddress)]
        public string user_mail { get; set; }

    }
}
