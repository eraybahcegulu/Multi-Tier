using DAL.Configs;
using ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DAL.Context
{

    public class MyContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public MyContext(DbContextOptions<MyContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
              .HasOne(c => c.Category)
              .WithMany(u => u.Products)
              .HasForeignKey(c => c.CategoryID)
              .IsRequired();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    } 
}