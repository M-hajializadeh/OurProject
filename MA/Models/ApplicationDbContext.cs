using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Models
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser,ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>()
                .HasIndex(c => new { c.ForeName, c.SurName });
            builder.Entity<Product>()
                .HasIndex(p => new { p.ProductName });
            builder.Entity<MainGroup>()
                .HasIndex(mg => new { mg.GroupName });
            builder.Entity<Command>()
                .HasIndex(co=>new { co.Title});
        }
        public DbSet<Customer> Tbl_Customers { get; set; }
        public DbSet<Address> Tbl_Addresses { get; set; }
        public DbSet<OptionalItem> Tbl_OptionalItems { get; set; }
        public DbSet<Item> Tbl_Items { get; set; }
        public DbSet<Product> Tbl_Products { get; set; }
        public DbSet<Command> Tbl_Commands { get; set; }
        public DbSet<MainGroup> Tbl_MainGroups { get; set; }
    }
}
