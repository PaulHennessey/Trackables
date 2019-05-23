using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface IMealRepository
    {
        DataTable GetMeals(string userId);
        DataTable GetMeal(int id);
        void CreateMeal(Meal meal, string userId);
        void UpdateMeal(Meal meal);
        void DeleteMeal(int id);
    }
}
