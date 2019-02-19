using System;
using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Services.Abstract
{
    public interface IFoodItemServices
    {
        IEnumerable<FoodItem> GetFoodItems(DateTime dt, int userId);
        IEnumerable<Day> GetDays(DateTime start, DateTime end, int userId);
        Day GetDay(DateTime date, int userId);
        void InsertFoodItem(string code, int quantity, DateTime dt, int userId);
        void UpdateFoodItem(int id, int quantity);
        void DeleteFoodItem(int id);
        IEnumerable<Favourite> GetFavourites(int userId);
        void MergeFavourite(int userId, int id, int quantity);
        void DeleteFavourite(int userId, string code);
    }
}
