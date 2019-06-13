using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Services.Abstract
{
    public interface IProductServices
    {
        IEnumerable<Product> GetProducts(string userId);
        IEnumerable<Product> GetProducts(string userId, List<FoodItem> foodItems);
        IEnumerable<Product> GetProducts(string userId, List<Day> days);
        List<Product> GetCustomProducts(string userId);
        Product GetProduct(string userId, string code);
        void CreateProduct(Product product, int userId);
        void CreateProduct(Product product, string userId);
        void UpdateProduct(string userId, Product product);
        void DeleteProduct(string code);
        Dictionary<string, decimal> GetNutrients(Product product);
        Dictionary<string, decimal> GetMacroNutrients(Product product);
        Dictionary<string, decimal> GetMicroNutrients(Product product);
        ProductMacronutrients UpdateProductMacronutrients(Dictionary<string, decimal> nutrients);
        ProductMicronutrients UpdateProductMicronutrients(Dictionary<string, decimal> nutrients);
    }
}
