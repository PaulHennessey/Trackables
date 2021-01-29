using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface IProductRepository
    {
        DataTable GetProducts(string userId);
        DataTable GetCustomProducts(string userId);
        DataTable GetProduct(string userId, string code);
        DataTable GetProducts(string userId, IEnumerable<Serving> servings);
        void CreateProduct(Product product, int userId);
        void CreateProduct(Product product, string userId);
        void UpdateProduct(string userId, Product product);
        void DeleteProduct(string code);
    }
}
