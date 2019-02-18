﻿using System.Collections.Generic;
using System.Data;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Data.Abstract
{
    public interface IIngredientRepository
    {
        DataTable GetIngredients(int userId);
        DataTable GetIngredient(int id);
        void CreateIngredient(string code, int mealId);
        void UpdateIngredient(int id, int quantity);
        void DeleteIngredient(int id);
    }
}
