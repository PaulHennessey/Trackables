using System.Collections.Generic;
using System.Data;
using Trackables.Domain;

namespace Trackables.Data.Abstract
{
    public interface IIngredientRepository
    {
        DataTable GetIngredients(string userId, int mealId);
//        DataTable GetIngredient(int id);
        void CreateIngredient(string code, int mealId);
        void UpdateIngredient(int id, int quantity);
        void DeleteIngredient(int id);
    }
}
