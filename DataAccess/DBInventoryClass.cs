using Microsoft.EntityFrameworkCore;
using Shop_Bridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Bridge.DataAccess
{
    public class DBInventoryClass: DbContext
    {

        public DBInventoryClass(DbContextOptions<DBInventoryClass> options) : base(options)
        {

        }

        public DbSet<Inventory> inventory { get; set; }


    }
}
