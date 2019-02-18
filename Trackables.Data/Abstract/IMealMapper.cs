using System.Collections.Generic;
using System.Data;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Abstract
{
    public interface IMealMapper
    {
        IEnumerable<Meal> HydrateMeals(DataTable mealTable);
        IEnumerable<Meal> HydrateMeal(DataTable mealTable, DataTable ingredientsTable);
    }
}
