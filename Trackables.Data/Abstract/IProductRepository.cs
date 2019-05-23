using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface IProductRepository
    {
        DataTable GetProducts(string userId);
        DataTable GetCustomProducts(int userId);
        DataTable GetCustomProducts(string userId);
        DataTable GetProduct(string code);
        DataTable GetProducts(IEnumerable<FoodItem> foodItems);
        void CreateProduct(Product product, int userId);
        void CreateProduct(Product product, string userId);
        void UpdateProduct(Product product);
        void DeleteProduct(string code);
    }
}
