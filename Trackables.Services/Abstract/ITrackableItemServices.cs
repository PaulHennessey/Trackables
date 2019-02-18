using System;
using System.Collections.Generic;
using MyFoodDiary.Domain;

namespace MyFoodDiary.Services.Abstract
{
    public interface ITrackableItemServices
    {
        IEnumerable<TrackableItem> GetTrackableItems(DateTime dt, int userId);
        void InsertTrackableItem(int? trackableId, DateTime dt, decimal? quantity);
        void UpdateTrackableItem(int? id, decimal? quantity);
    }
}
