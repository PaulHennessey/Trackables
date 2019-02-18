﻿using System.Collections.Generic;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Services.Abstract
{
    public interface IChartServices
    {
        List<List<decimal>> CalculateMacroNutrientByProduct(List<Day> days, List<Product> products, string nutrient);
        List<List<decimal>> CalculateMicroNutrientByProduct(List<Day> days, List<Product> products, string nutrient);
        List<List<decimal>> CalculateMacroNutrientByDay(List<Day> days, List<Product> products, string nutrient);
        List<List<decimal>> CalculateMicroNutrientByDay(List<Day> days, List<Product> products, string nutrient);
        List<List<decimal>> CalculateMacronutrientRatioData(List<Day> days, List<Product> products);
        List<List<decimal>> CalculateAlcoholByProduct(List<Day> days, List<Product> products);
        List<List<decimal>> CalculateAlcoholByDay(List<Day> days, List<Product> products);
        List<string> GetBarNames(IEnumerable<Day> days);
        List<string> GetDates(IEnumerable<Day> days);
        List<string> GetBarNames(IEnumerable<FoodItem> foodItems);
        List<string> GetMacronutrientRatioCategories();
        List<string> GetMacronutrientTitle(string nutrient);
        List<string> GetMicronutrientTitle(string nutrient);
        decimal GetMacronutrientRDA(string nutrient);
        decimal GetMicronutrientRDA(string nutrient);
    }
}
