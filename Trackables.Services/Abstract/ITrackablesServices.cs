using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Services.Abstract
{
    public interface ITrackablesServices
    {
        IEnumerable<Trackable> GetTrackables(int userId);
        //IEnumerable<Product> GetProducts(List<FoodItem> foodItems);
        //IEnumerable<Product> GetProducts(List<Day> days);
        //List<Product> GetCustomProducts(int userId);
        Trackable GetTrackable(int id);
        void CreateTrackable(Trackable trackable, int userId);
        void UpdateTrackable(Trackable trackable);
        void DeleteTrackable(int id);
        //Dictionary<string, decimal> GetNutrients(Product product);
        //ProductMacronutrients UpdateProductMacronutrients(Dictionary<string, decimal> nutrients);
        //ProductMicronutrients UpdateProductMicronutrients(Dictionary<string, decimal> nutrients);
    }
}
