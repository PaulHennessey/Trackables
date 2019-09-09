using System;
using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Services.Abstract
{
    public interface IChartServices
    {

        List<List<decimal?>> CalculateMacronutrientByProduct(DateTime start, DateTime end, string nutrient, string UserId);
        List<List<decimal?>> CalculateMicronutrientByProduct(DateTime start, DateTime end, string nutrient, string UserId);
        List<List<decimal?>> CalculateMacronutrientByDay(DateTime start, DateTime end, string nutrient, string UserId);
        List<List<decimal?>> CalculateMicronutrientByDay(DateTime start, DateTime end, string nutrient, string UserId);
        List<List<decimal?>> CalculateMacronutrientRatioData(List<Day> days, List<Product> products);
        List<List<decimal?>> CalculateAlcoholByProduct(List<Day> days, List<Product> products);
        List<List<decimal?>> CalculateAlcoholByDay(List<Day> days, List<Product> products);
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
