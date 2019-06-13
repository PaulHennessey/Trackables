using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Services.Abstract
{
    public interface IMealServices
    {
        IEnumerable<Meal> GetMeals(string userId);
        Meal GetMeal(string userId, int mealId);        
        void CreateMeal(Meal meal, string userId);
        void UpdateMeal(Meal meal);
        void DeleteMeal(Meal meal);
    }
}
