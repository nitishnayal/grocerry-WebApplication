using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace eTickets.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company_Product>().HasKey(am => new
            {
                am.CompanyId,
                am.ProductId
            });

            modelBuilder.Entity<Company_Product>().HasOne(m => m.Product).WithMany(am => am.Company_Products).HasForeignKey(m => m.ProductId);
            modelBuilder.Entity<Company_Product>().HasOne(m => m.Company).WithMany(am => am.Company_Products).HasForeignKey(m => m.CompanyId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company_Product> Company_Products { get; set; }
        public DbSet<Store> Stores { get; set; }
     


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }

}

