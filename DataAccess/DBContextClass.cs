using Microsoft.EntityFrameworkCore;
using Shop_Bridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Bridge.DataAccess
{
    public class DBContextClass : DbContext
    {
        //public DBContextClass()
        //{
        //}

        public DBContextClass(DbContextOptions<DBContextClass> options): base(options)
        {
                
        }

        public DbSet<User> user { get; set; }


    }
}
