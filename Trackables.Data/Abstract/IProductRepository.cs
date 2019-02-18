using System.Collections.Generic;
using System.Data;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Abstract
{
    public interface IProductRepository
    {
        DataTable GetProducts(int userId);
        DataTable GetCustomProducts(int userId);
        DataTable GetProduct(string code);
        DataTable GetProducts(IEnumerable<FoodItem> foodItems);
        void CreateProduct(Product product, int userId);
        void UpdateProduct(Product product);
        void DeleteProduct(string code);
    }
}
