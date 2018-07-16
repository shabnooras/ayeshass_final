using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BASITraining.Models;

namespace BASITraining.Models
{
    public class p_context : DbContext
    {
        public p_context() : base("BASITraining")
        {
        }
        public DbSet<category> Categories { get; set; }
        public DbSet<product> Products { get; set; }
        public DbSet<cartitem> coursecartitems { get; set; }
    }
}