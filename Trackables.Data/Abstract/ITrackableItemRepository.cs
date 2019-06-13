using System;
using System.Data;
namespace Trackables.Data.Abstract
{
    public interface ITrackableItemRepository
    {
        DataTable GetTrackableItems(DateTime dt, string userId);
        void InsertTrackableItem(int? trackableId, DateTime dt, decimal? quantity);
        void UpdateTrackableItem(int? id, decimal? quantity);
    }
}
