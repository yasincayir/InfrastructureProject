using CoreLayer.Entities.Concrete;
using EntitiesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class NorthwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CarMap
            modelBuilder.Entity<Product>().ToTable("Products");

            modelBuilder.Entity<Product>().Property(p => p.ProductId).HasColumnName("ProductID");
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("ProductName");
            modelBuilder.Entity<Product>().Property(p => p.QuantityPerUnit).HasColumnName("QuantityPerUnit");
            modelBuilder.Entity<Product>().Property(p => p.CategoryId).HasColumnName("CategoryID");
            modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasColumnName("UnitPrice");

            //CategoryMap
            modelBuilder.Entity<Category>().ToTable("Categories");

            modelBuilder.Entity<Category>().Property(p => p.CategoryId).HasColumnName("CategoryID");
            modelBuilder.Entity<Category>().Property(p => p.CategoryName).HasColumnName("CategoryName");

        }
    }
}
