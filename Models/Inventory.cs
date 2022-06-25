using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Bridge.Models
{
    public class Inventory
    {
        [Key]
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
}
