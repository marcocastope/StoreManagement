using Microsoft.Extensions.Logging;
using StoreManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreManagement.Data
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<StoreRepository> logger;

        public StoreRepository(AppDbContext context, ILogger<StoreRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                logger.LogInformation("GetAllProducts call");
                return context.Products.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }

        public IEnumerable<Product> GetAllProductsByCategory(string category)
        {
            try
            {
                logger.LogInformation("GetAllProductsByCategory call");
                return context.Products.Where(p => p.Category == category).ToList();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get all products by category: {ex}");
                throw;
            }
        }
    }
}
