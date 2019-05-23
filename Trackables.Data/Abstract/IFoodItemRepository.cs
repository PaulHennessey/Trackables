using System;
using System.Data;

namespace Trackables.Data.Abstract
{
    public interface IFoodItemRepository
    {
        DataTable GetFoodItems(DateTime dt, string userId);
        DataTable GetFoodItems(DateTime dt, int userId);
        void InsertFoodItem(string code, int quantity, DateTime dt, int userId);
        void InsertFoodItem(string code, int quantity, DateTime dt, string userId);
        void UpdateFoodItem(int id, int quantity);
        void DeleteFoodItem(int id);
    }
}
