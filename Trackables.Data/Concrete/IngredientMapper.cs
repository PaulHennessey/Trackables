using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyFoodDiary.Data.Abstract;
using MyFoodDiary.Domain;
using MyFoodDiary.Domain.Extensions;

namespace MyFoodDiary.Data.Concrete
{
    public class IngredientMapper : IIngredientMapper
    {
        public IEnumerable<Ingredient> HydrateIngredients(DataTable dataTable)
        {
            return from DataRow row in dataTable.Rows select new Ingredient
            {
                Id = Convert.ToInt32(row["Id"]),
                Code = row["Code"].ToString(),
                Name = row["Name"].ToString()
            };
        }

    }
}