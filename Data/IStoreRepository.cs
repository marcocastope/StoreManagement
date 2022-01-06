using StoreManagement.Data.Entities;
using System.Collections.Generic;

namespace StoreManagement.Data
{
    public interface IStoreRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetAllProductsByCategory(string category);
    }
}