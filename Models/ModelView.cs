using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Bridge.Models
{
    public class ModelView
    {





        [Key]
        public int user_id { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "Enter the User Name")]
        public string user_name { get; set; }

        [DisplayName("Role")]
        public string user_role { get; set; }

        [DisplayName("Role")]
        [Required(ErrorMessage = "Enter the Role")]
        public UserRole role { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Enter the Password")]
        [DataType(DataType.Password)]
        public string user_password { get; set; }

        [DisplayName("Mail")]
        [Required(ErrorMessage = "Enter the Mail")]
        [DataType(DataType.EmailAddress)]
        public string user_mail { get; set; }

        [DisplayName("UserName")]
        public string user_username { get; set; }







        //  SELECT TOP(1000) [user_id]
        //,[user_name]
        //,[user_role]
        //,[user_password]
        //,[user_mail]
        //,[user_username]
        //  FROM[ShopBridge].[dbo].[user]




        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string discount { get; set; }



        //  SELECT TOP(1000) [id]
        //,[name]
        //,[description]
        //,[price]
        //,[discount]
        //  FROM[ShopBridge].[dbo].[inventory]

    }

    public enum UserRole
    {
        Admin,
        Shopkeeper,
        Standard
    }


}
