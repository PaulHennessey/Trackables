using System.Collections.Generic;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Services.Abstract
{
    public interface IIngredientServices
    {
        void CreateIngredient(string code, int mealId);
        void DeleteIngredient(int id);
        void UpdateIngredient(int id, int quantity);
    }
}
