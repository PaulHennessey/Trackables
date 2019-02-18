using System.Collections.Generic;
using System.Data;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Abstract
{
    public interface IMealRepository
    {
        DataTable GetMeals(int userId);
        DataTable GetMeal(int id);
        void CreateMeal(Meal meal, int userId);
        void UpdateMeal(Meal meal);
        void DeleteMeal(int id);
    }
}
