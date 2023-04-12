using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EShop.Data.ConfigurationDataContext;
using Microsoft.AspNetCore.Identity;

namespace EShop.Data
{
    public class EShopContext : IdentityDbContext<User, UserRole, Guid>
    {
        public EShopContext (DbContextOptions<EShopContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens").HasKey(x => x.UserId);

        }

        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Product> Products { get; set; } 
        public DbSet<Product_InvoiceDetail> Product_InvoiceDetails { get; set; } 
        public DbSet<Invoice>Invoices { get; set; } 
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<User> Users { get; set; } 
        public DbSet<UserRole> UserRoles { get; set; } 
        public DbSet<EShop.Models.Product_ProductType>? Product_ProductType { get; set; }


    }
}
