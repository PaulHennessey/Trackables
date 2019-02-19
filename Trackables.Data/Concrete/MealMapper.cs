using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Trackables.Data.Abstract;
using Trackables.Domain;
using Trackables.Domain.Extensions;

namespace Trackables.Data.Concrete
{
    public class MealMapper : IMealMapper
    {
        public IEnumerable<Meal> HydrateMeals(DataTable mealTable)
        {
            return from DataRow row in mealTable.Rows select new Meal
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = row["Name"].ToString(),
                Ingredients = new List<Ingredient>()
            };
        }

        public IEnumerable<Meal> HydrateMeal(DataTable mealTable, DataTable ingredientsTable)
        {
            return from DataRow row in mealTable.Rows
                   select new Meal
                   {
                       Id = Convert.ToInt32(row["Id"]),
                       Name = row["Name"].ToString(),
                       Ingredients = HydrateIngredients(ingredientsTable).ToList()
                   };
        }

        private IEnumerable<Ingredient> HydrateIngredients(DataTable ingredientsTable)
        {
            return from DataRow row in ingredientsTable.Rows
                   select new Ingredient
                   {
                       Id = Convert.ToInt32(row["Id"]),
                       MealId = Convert.ToInt32(row["MealId"]),
                       Code = row["Code"].ToString(),
                       Name = row["Name"].ToString(),
                       Quantity = Convert.ToInt32(row["Quantity"])
                   };
        }

    }
}