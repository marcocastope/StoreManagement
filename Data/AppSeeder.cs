using Microsoft.AspNetCore.Hosting;
using StoreManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace StoreManagement.Data
{
    public class AppSeeder
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment environment;

        public AppSeeder(AppDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        public void Seed()
        {
            context.Database.EnsureCreated();

            if (!context.Products.Any())
            {
                var filePath = Path.Combine(environment.ContentRootPath, "Data/products.json");
                var json = File.ReadAllText(filePath);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);
                context.AddRange(products);

                var order = new Order()
                {
                    OrderDate = DateTime.Today,
                    OrderNumber = "10000",
                    Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 10
                        }
                    }
                };
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}
