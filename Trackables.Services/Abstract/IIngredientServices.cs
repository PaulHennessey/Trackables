using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Services.Abstract
{
    public interface IIngredientServices
    {
        void CreateIngredient(string code, int mealId);
        void DeleteIngredient(int id);
        void UpdateIngredient(int id, int quantity);
    }
}
