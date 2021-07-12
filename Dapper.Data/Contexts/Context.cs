using Dapper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Data.Contexts
{
    public class Context : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Merchant> AudioFiles { get; set; }
        public virtual DbSet<Order> Directories { get; set; }
        public virtual DbSet<OrderItem> DirectoryPermissions { get; set; }
        public virtual DbSet<Product> Files { get; set; }
        public virtual DbSet<Country> Countries { get; set; }

        public Context()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BNTF795;Database=DapperPractisedb;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sch");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<User>().HasData(
                new User[]
                {
            new User { Id=1,FullName = "Tom Jons", Email = "Jons@mail.com", Gender = "Male", DateOfBirth = new DateTime(2005, 7, 20), CountryId = 1, CreatedAt = DateTime.Now, },
            new User { Id=2,FullName = "Sara Ken", Email = "Ken@mail.com", Gender = "Female", DateOfBirth = new DateTime(1999, 3, 30), CountryId = 2, CreatedAt = DateTime.Now },
            new User { Id=3,FullName = "Justin Son", Email = "Son@mail.com", Gender = "Male", DateOfBirth = new DateTime(1998, 5, 15), CountryId = 3, CreatedAt = DateTime.Now },
            new User { Id=4, FullName = "Nasty Yon", Email = "Yon@mail.com", Gender = "Female", DateOfBirth = new DateTime(1995, 10, 7), CountryId = 4, CreatedAt = DateTime.Now }
                });

            modelBuilder.Entity<Country>().HasData(
              new Country[]
              {
             new Country { Id=1,Country_Code = 65346, Name = "USA" },
             new Country { Id=2,Country_Code = 54356, Name = "Canada" },
             new Country { Id=3,Country_Code = 35425, Name = "Pakistan" },
             new Country { Id=4,Country_Code = 65467, Name = "Serbia" }
              });

            modelBuilder.Entity<Merchant>().HasData(
            new Merchant[]
            {
             new Merchant {Id=1, CountryId=  1, Name = "Tom",CreatedAt=DateTime.Now,UserId=1 },
             new Merchant {Id=2, CountryId = 2, Name = "Sara",CreatedAt=DateTime.Now,UserId=2, },
            });

            modelBuilder.Entity<Order>().HasData(
         new Order[]
         {
             new Order {Id=1,UserID=1,CreatedAt=DateTime.Now,Status="in the process",OrderJson
             =JsonConvert.SerializeObject(new OrderJson(1,new User{ FullName="Tom Jons",Email = "Jons@mail.com"},new List<Product>{ new Product { Merchant = new Merchant { Name = "Tom" }, Name = "Computer", Price = 2000.00 } })) } ,

             new Order {Id=2,UserID=1,CreatedAt=DateTime.Now,Status="in the process",OrderJson
             =JsonConvert.SerializeObject(new OrderJson(1,new User{ FullName = "Tom Jons",Email = "Jons@mail.com"},new List<Product>{ new Product { Merchant = new Merchant { Name = "Tom" }, Name = "DVD", Price = 1000.00 } })) },

              new Order {Id=3,UserID=2,CreatedAt=DateTime.Now,Status="Finished",OrderJson
             =JsonConvert.SerializeObject(new OrderJson(1,new User{ FullName = "Sara Ken",Email = "Ken@mail.com"},new List<Product>{ new Product { Merchant = new Merchant { Name = "Sara" }, Name = "Smart TV", Price = 4000.00 } })) }

          });

            modelBuilder.Entity<Product>().HasData(
           new Product[]
           {
             new Product { Id=1,Name="Computer",Status="In the process",MerchantId=1,Price=2000.00,CreatedAt=DateTime.Now},
             new Product { Id=2,Name="DVD",Status="In the process",MerchantId=1,Price=1000.00,CreatedAt=DateTime.Now},
             new Product { Id = 3, Name = "Smart TV", Status = "Finished", MerchantId = 2, Price = 4000.00, CreatedAt = DateTime.Now }
           });

            modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem[]
            {
             new OrderItem { Id=1,OrderId=1,ProductId=1,Quantity=2 },
             new OrderItem { Id=2,OrderId=2,ProductId=2,Quantity=1 },
             new OrderItem { Id=3,OrderId=3,ProductId=3,Quantity=1 }
            });

        }
    }
}