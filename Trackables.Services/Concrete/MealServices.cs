﻿//public void DeleteProduct(string code)
//{
//    _productRepository.DeleteProduct(code);
//}
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MyFoodDiary.Data.Abstract;
using MyFoodDiary.Domain;
using MyFoodDiary.Services.Abstract;

namespace MyFoodDiary.Services.Concrete
{
    public class MealServices : IMealServices
    {
        private readonly IMealRepository _mealRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMealMapper _mealMapper;

        public MealServices()
        { }

        public MealServices(IMealRepository mealRepository, IMealMapper mealMapper, IIngredientRepository ingredientRepository)
        {
            _mealRepository = mealRepository;
            _mealMapper = mealMapper;
            _ingredientRepository = ingredientRepository;
        }

        public IEnumerable<Meal> GetMeals(int userId)
        {
            DataTable dataTable = _mealRepository.GetMeals(userId);
            return _mealMapper.HydrateMeals(dataTable);
        }

        public void CreateMeal(Meal meal, int userId)
        {
            _mealRepository.CreateMeal(meal, userId);
        }

        public void UpdateMeal(Meal meal)
        {
            _mealRepository.UpdateMeal(meal);
        }

        public Meal GetMeal(int mealId)
        {
            DataTable mealTable = _mealRepository.GetMeal(mealId);
            DataTable ingredientsTable = _ingredientRepository.GetIngredients(mealId);

            return _mealMapper.HydrateMeal(mealTable, ingredientsTable).FirstOrDefault();
        }

        public void DeleteMeal(Meal meal)
        {
            foreach (Ingredient ingredient in meal.Ingredients)
            {
                _ingredientRepository.DeleteIngredient(ingredient.Id);
            }

            _mealRepository.DeleteMeal(meal.Id);
        }
    }
}
