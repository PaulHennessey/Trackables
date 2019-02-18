using System;
using System.Data;
namespace MyFoodDiary.Data.Abstract
{
    public interface ITrackableItemRepository
    {
        DataTable GetTrackableItems(DateTime dt, int userId);
        void InsertTrackableItem(int? trackableId, DateTime dt, decimal? quantity);
        void UpdateTrackableItem(int? id, decimal? quantity);
    }
}
