using System.Collections.Generic;
using System.Data;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Abstract
{
    public interface IIngredientMapper
    {
        IEnumerable<Ingredient> HydrateIngredients(DataTable dataTable);
    }
}
