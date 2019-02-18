using System.Collections.Generic;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Services.Abstract
{
    public interface IProductServices
    {
        IEnumerable<Product> GetProducts(int userId);
        IEnumerable<Product> GetProducts(List<FoodItem> foodItems);
        IEnumerable<Product> GetProducts(List<Day> days);
        List<Product> GetCustomProducts(int userId);
        Product GetProduct(string code);
        void CreateProduct(Product product, int userId);
        void UpdateProduct(Product product);
        void DeleteProduct(string code);
        Dictionary<string, decimal> GetNutrients(Product product);
        Dictionary<string, decimal> GetMacroNutrients(Product product);
        Dictionary<string, decimal> GetMicroNutrients(Product product);
        ProductMacronutrients UpdateProductMacronutrients(Dictionary<string, decimal> nutrients);
        ProductMicronutrients UpdateProductMicronutrients(Dictionary<string, decimal> nutrients);
    }
}
