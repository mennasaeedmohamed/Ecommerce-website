using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Commerce.Models.Models;

namespace Commerce.Context.Context
{
    public class CommerceDbContext: IdentityDbContext<IdentityUser>
    {
        public CommerceDbContext(DbContextOptions<CommerceDbContext> options) : base(options) { }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<OrderProducts> OrderProducts { get; set; }


    }
}
