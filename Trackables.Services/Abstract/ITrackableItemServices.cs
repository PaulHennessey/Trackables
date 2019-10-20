using System;
using System.Collections.Generic;
using Trackables.Domain;

namespace Trackables.Services.Abstract
{
    public interface ITrackableItemServices
    {
        IEnumerable<TrackableItem> GetTrackableItems(DateTime dt, string userId);
        void InsertTrackableItem(int? trackableId, DateTime dt, decimal? quantity);
        void UpdateTrackableItem(int? id, decimal? quantity);
    }
}
