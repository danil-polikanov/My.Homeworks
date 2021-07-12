using Dapper.Core.Entities;
using Dapper.Core.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dapper.BLL
{
    public class Service
    {
        private readonly IRepository repository;

        public Service(IRepository repository)
        {
            this.repository = repository;
        }

        public void CoverUser(string email)
        {
            var user = this.repository.GetAllAsync<User>().Result.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                var merchant = this.repository.GetAllAsync<Merchant>().Result.FirstOrDefault(x => x.UserId == user.Id);
                var orders = this.repository.GetAllAsync<Order>().Result.Where(x => x.UserID == user.Id);
                var product = this.repository.GetAllAsync<Product>().Result.Where(x => x.MerchantId == merchant.Id);
                if (merchant != null)
                {
                    merchant.CreatedAt = new DateTime(2015, 7, 20);
                    merchant.CountryCode = 0;
                    merchant.Name = "*****";
                    this.repository.UpdateAsync<Merchant>(merchant);
                }
                else
                {
                    Console.WriteLine("Такого торговца не существует");
                }
                user.CountryCode = 0;
                user.CreatedAt = new DateTime(2015, 7, 20);
                user.DateOfBirth = new DateTime(2015, 7, 20);
                user.Email = "*****";
                user.FullName = "*****";
                user.Gender = "*****";
                this.repository.UpdateAsync<User>(user);
                if (product != null)
                {
                    foreach (var i in product)
                    {
                        i.CreatedAt = new DateTime(2015, 7, 20);
                        i.Name = "*****";
                        i.Price = 0;
                        i.Status = "*****";
                        this.repository.UpdateAsync<Product>(i);
                    }

                }
                if (orders != null)
                {
                    foreach (var i in orders)
                    {
                        i.CreatedAt = new DateTime(2015, 7, 20);
                        i.Status = "*****";
                        i.OrderJson = JsonConvert.SerializeObject(new OrderJson(1,
                        new User { FullName = "*****", Email = "*****" },
                        new List<Product> { new Product {
                        Merchant = new Merchant { Name = "*****" }, Name = "*****", Price = 0 } }));
                        this.repository.UpdateAsync<Order>(i);
                    }

                }
            }
            else
            {
                Console.WriteLine($"Такого пользователя с таким емейлом не существует");
            }
        }

    }
}
