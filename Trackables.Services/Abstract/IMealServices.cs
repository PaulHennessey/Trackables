﻿using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Services.Abstract
{
    public interface IMealServices
    {
        IEnumerable<Meal> GetMeals(int userId);
        Meal GetMeal(int mealId);
        void CreateMeal(Meal meal, int userId);
        void UpdateMeal(Meal meal);
        void DeleteMeal(Meal meal);
    }
}