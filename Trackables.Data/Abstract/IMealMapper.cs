using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface IMealMapper
    {
        IEnumerable<Meal> HydrateMeals(DataTable mealTable);
        IEnumerable<Meal> HydrateMeal(DataTable mealTable, DataTable ingredientsTable);
    }
}
