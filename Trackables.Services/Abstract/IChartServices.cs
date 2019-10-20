using System;
using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Services.Abstract
{
    public interface IChartServices
    {
        IEnumerable<Series> GetSeries(DateTime start, DateTime end, IEnumerable<int> selectedIds, string UserId);
        List<List<decimal?>> CalculateMacronutrientByProduct(DateTime start, DateTime end, List<string> nutrients, string UserId);
        List<List<decimal?>> CalculateMicronutrientByProduct(DateTime start, DateTime end, List<string> nutrients, string UserId);
        List<List<decimal?>> CalculateMacronutrientByDay(DateTime start, DateTime end, List<string> nutrients, string UserId);
        List<List<decimal?>> CalculateMicronutrientByDay(DateTime start, DateTime end, List<string> nutrients, string UserId);
        List<List<decimal?>> CalculateMacronutrientRatioData(DateTime start, DateTime end, string UserId);
        List<string> GetProductNames(DateTime start, DateTime end, string UserId);
        List<string> GetDates(DateTime start, DateTime end, string UserId);
        List<string> GetMacronutrientRatioCategories();
        List<string> GetMacronutrientTitle(string nutrient);
        List<string> GetMicronutrientTitle(string nutrient);
        decimal GetMacronutrientRDA(string nutrient);
        decimal GetMicronutrientRDA(string nutrient);
    }
}
